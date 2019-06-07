using System.Configuration;
using System.Collections.Specialized;
using BKNBrauhelferKonverter.Models;

namespace BKNBrauhelferKonverter.Utils
{
    public class Configuration
    {
        private const string UserKey = "GUser";
        private const string PasswordKey = "GPass";
        private const string TokenKey = "GToken";
        private const string BrauhelferDbKey = "BhDatabase";
        private const string SqlServerKey = "SqlServer";
        private const string SqlDatabaseKey = "SqlDatabase";
        private const string SqlUserKey = "SqlUser";
        private const string SqlPassKey = "SqlPass";

        private NameValueCollection _appSettings => ConfigurationManager.AppSettings;

        private static void AddUpdateAppSettings(string key, string value, bool crypt = false)
        {
            if (string.IsNullOrEmpty(key) || string.IsNullOrEmpty(value))
                return;

            var configFile = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            AddOrSetValue(ref configFile, key, value, crypt);
            configFile.Save(ConfigurationSaveMode.Modified);
            ConfigurationManager.RefreshSection(configFile.AppSettings.SectionInformation.Name);
        }

        private static void AddOrSetValue(ref System.Configuration.Configuration configFile, string key, string value, bool crypt = false)
        {
            var encryptedValue = crypt ? Cryptograph.Encrypt(value) : value;

            var settings = configFile.AppSettings.Settings;
            if (settings[key] == null)
            {
                settings.Add(key, encryptedValue);
            }
            else
            {
                settings[key].Value = encryptedValue;
            }
        }


        public void SaveSettings(Settings settings)
        {
            var configFile = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

            if (!string.IsNullOrEmpty(settings.Git.User))
                AddOrSetValue(ref configFile, UserKey, settings.Git.User);
            if (!string.IsNullOrEmpty(settings.Git.Password))
                AddOrSetValue(ref configFile, PasswordKey, settings.Git.Password, true);
            if (!string.IsNullOrEmpty(settings.Git.Token))
                AddOrSetValue(ref configFile, TokenKey, settings.Git.Token, true);
            if (!string.IsNullOrEmpty(settings.KleinerBrauhelfer.Database))
                AddOrSetValue(ref configFile, BrauhelferDbKey, settings.KleinerBrauhelfer.Database);
            if (!string.IsNullOrEmpty(settings.Sql.Server))
                AddOrSetValue(ref configFile, SqlServerKey, settings.Sql.Server);
            if (!string.IsNullOrEmpty(settings.Sql.Database))
                AddOrSetValue(ref configFile, SqlDatabaseKey, settings.Sql.Database);
            if (!string.IsNullOrEmpty(settings.Sql.User))
                AddOrSetValue(ref configFile, SqlUserKey, settings.Sql.User);
            if (!string.IsNullOrEmpty(settings.Sql.Password))
                AddOrSetValue(ref configFile, SqlPassKey, settings.Sql.Password, true);

            configFile.Save(ConfigurationSaveMode.Modified);
            ConfigurationManager.RefreshSection(configFile.AppSettings.SectionInformation.Name);
        }

        public Settings GetSettings()
        {
            var settings = new Settings
            {
                KleinerBrauhelfer =
                {
                    Database = _appSettings[BrauhelferDbKey]
                },
                Git =
                {
                    User = _appSettings[UserKey],
                    Password = Cryptograph.Decrypt(_appSettings[PasswordKey]),
                    Token = Cryptograph.Decrypt(_appSettings[TokenKey])
                },
                Sql =
                {
                    Server = _appSettings[SqlServerKey],
                    Database = _appSettings[SqlDatabaseKey],
                    User = _appSettings[SqlUserKey],
                    Password = Cryptograph.Decrypt(_appSettings[SqlPassKey])
                }
            };

            return settings;
        }
    }
}
