using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Reflection;
using BKNBrauhelferKonverter.Models;
using BKNBrauhelferKonverter.Utils;

namespace BKNBrauhelferKonverter.Database
{
    public class BrauhelferDbConnection
    {
        private readonly SQLiteConnection _connection;
        private string _dbDirectory;

        public BrauhelferDbConnection(string datasource = "")
        {
            // Wenn nicht als Parameter übergeben, suche mit den Brauhelfer-Standardeinstellungen
            if (string.IsNullOrEmpty(datasource))
            {
                var path = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
                _dbDirectory = path + "\\.kleiner-brauhelfer";
                datasource = _dbDirectory + "\\kb_daten.sqlite";
            }
            else
            {
                _dbDirectory = Path.GetDirectoryName(datasource);
            }

            if (!File.Exists(datasource))
                throw new Exception("Die Brauhelfer-Datenbank konnte nicht gefunden werden.");

            _connection = new SQLiteConnection { ConnectionString = "Data Source=" + datasource };
        }

        public string GetBrauhelferDbDirectory()
        {
            if (string.IsNullOrEmpty(_dbDirectory) || !Directory.Exists(_dbDirectory))
            {
                throw new Exception($"Das Brauhelfer Datenbank-Verzeichnis existiert nicht ({_dbDirectory})");
            }

            return _dbDirectory;
        }

        /// <summary>
        /// Liest nur die wichtigsten Informationen der Sude für die Listen-Anzeige (SudBase)
        /// </summary>
        /// <returns></returns>
        public IEnumerable<SudBase> GetSude()
        {
            var result = new List<SudBase>();

            _connection.Open();

            try
            {
                var command = new SQLiteCommand(_connection) { CommandText = "SELECT ID, Sudname, Braudatum FROM Sud ORDER BY Sudname" };

                var reader = command.ExecuteReader();
                try
                {

                    while (reader.Read())
                    {
                        result.Add(
                            new SudBase
                            {
                                Id = int.Parse(reader["ID"].ToString()),
                                Sudname = reader["Sudname"].ToString(),
                                Braudatum = DateTime.Parse(reader["Braudatum"].ToString())
                            });
                    }
                }
                finally
                {
                    // Beenden des Readers und Freigabe aller Ressourcen.
                    reader.Close();
                    reader.Dispose();

                    command.Dispose();
                }
            }
            finally
            {
                _connection.Close();
            }

            return result;
        }

        public Sud GetSud(int sudId)
        {
            Sud result;

            _connection.Open();
            try
            {
                result = ReadSud(sudId);
            }
            finally
            {
                _connection.Close();
            }

            return result;
        }

        private Sud ReadSud(int sudId)
        {
            var result = ReadData<Sud>($"SELECT * FROM Sud WHERE ID = {sudId}").FirstOrDefault();

            if (result != null)
            {
                result.Rasten = ReadData<Rast>($"SELECT * FROM Rasten WHERE SudID = {sudId} ORDER BY RastTemp DESC");
                result.Malzschuettung = ReadData<Malzschuettung>($"SELECT * FROM Malzschuettung WHERE SudID = {sudId} ORDER BY Prozent DESC");
                result.Hopfengabe = ReadData<Hopfengabe>($"SELECT * FROM Hopfengaben WHERE SudID = {sudId} ORDER BY Prozent DESC");
                result.WeitereZutatenGabe = ReadData<WeitereZutatenGabe>($"SELECT * FROM WeitereZutatenGaben WHERE SudID = {sudId} ORDER BY Zeitpunkt DESC");
                result.Bewertungen = ReadData<Bewertung>($"SELECT * FROM Bewertungen WHERE SudID = {sudId} ORDER BY Datum");
            }

            return result;
        }

        private IEnumerable<T> ReadData<T>(string commandText)
        {
            var result = new List<T>();

            var command = new SQLiteCommand(_connection) { CommandText = commandText };

            var reader = command.ExecuteReader();
            try
            {
                // Es folgt ein wenig Reflection-Magie. I just f*cking like it ;)
                var t = typeof(T);
                // Alle Properties von T, die mit dem DbFieldAttribute versehen sind auslesen
                var props = t.GetProperties().Where(
                    prop => Attribute.IsDefined(prop, typeof(DbFieldAttribute))).ToList();

                while (reader.Read())
                {
                    // Neuer Datensatz in Db, also neue Instanz vom Type T
                    var newInstance = (T)Activator.CreateInstance(t);

                    // Alle aus der Db auszulesenden Properties durchgehen
                    foreach (var prop in props)
                    {
                        // Instanz des DbFieldAttributes zur Property holen 
                        var attribute = (DbFieldAttribute)prop.GetCustomAttribute(typeof(DbFieldAttribute));

                        try
                        {
                            // Im Attribute gespeichertes Datenbankfeld holen und damit den Wert aus dem Db-Reader besorgen
                            var dbValue = reader[attribute.DbField];

                            // Jetzt den Wert des Datenbankfeldes in den Property-spezifischen Typ konvertieren und zuweisen
                            var propertyType = prop.PropertyType;
                            dbValue = Convert.ChangeType(dbValue, propertyType);
                            prop.SetValue(newInstance, dbValue);
                        }
                        catch (Exception e)
                        {
                            throw new Exception($"Db-Feld '{t}.{attribute.DbField}' überprüfen!");
                        }

                    }

                    result.Add(newInstance);
                }
            }
            finally
            {
                // Beenden des Readers und Freigabe aller Ressourcen.
                reader.Close();
                reader.Dispose();

                command.Dispose();
            }

            return result;
        }
    }
}
