using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using BKNBrauhelferKonverter.Database;
using BKNBrauhelferKonverter.Enums;
using BKNBrauhelferKonverter.Models;

// ReSharper disable LoopCanBeConvertedToQuery

namespace BKNBrauhelferKonverter.Utils
{
    public class SudKonverter
    {
        private readonly BrauhelferDbConnection _dbConnection;

        public SudKonverter()
        {
            _dbConnection = new BrauhelferDbConnection();
        }

        public IEnumerable<SudBase> GetSudOverview()
        {
            return _dbConnection.GetSude();
        }

        public void ConvertToMarkdown(int sudId, string filename)
        {
            var templateText = GetMarkdownTemplate();
            var sud = _dbConnection.GetSud(sudId);

            ReplaceHeader(sud, filename, ref templateText);
            ReplaceMalts(sud, ref templateText);
            ReplaceWater(sud, ref templateText);
            ReplaceMashingGuidelines(sud, ref templateText);
            ReplaceBoiling(sud, ref templateText);
            ReplaceYeast(sud, ref templateText);
            ReplaceAdditional(sud, ref templateText);
            ReplaceInformation(sud, ref templateText);
            ReplaceRating(sud, ref templateText);

            File.WriteAllText(filename, templateText);
        }

        private void ReplaceVariable(string variable, string value, ref string text)
        {
            text = text.Replace(variable, value);
        }

        private string GetMarkdownTemplate()
        {
            const string templateFilename = "RecipeTemplate.md";

            if (!File.Exists(templateFilename))
                throw new FileNotFoundException($"Die Template-Datei konnte nicht gefunden werden ({templateFilename})");

            return File.ReadAllText(templateFilename);
        }

        private string GetBeerStyle(string filename)
        {
            var beerStyle = "?";
            var split = Path.GetFileNameWithoutExtension(filename)?.Split('-');
            if (split != null && split.Length > 1)
            {
                beerStyle = split[0].Trim();
            }

            return beerStyle;
        }

        private void ReplaceHeader( Sud sud, string filename, ref string templateText)
        {
            ReplaceVariable("{SUDNAME}", sud.Sudname, ref templateText);
            ReplaceVariable("{BEERSTYLE}", GetBeerStyle(filename), ref templateText);
            ReplaceVariable("{BATCHSIZE}", sud.Menge.ToString(CultureInfo.InvariantCulture), ref templateText);
            ReplaceVariable("{HIGHGRAVITYFACTOR}", sud.HighGravityFaktor.ToString(), ref templateText);
            ReplaceVariable("{ORIGINALGRAVITY}", sud.StammwuerzeAnstellen.ToString(CultureInfo.InvariantCulture), ref templateText);
            ReplaceVariable("{FINALGRAVITY}", sud.SwJungbier.ToString(CultureInfo.InvariantCulture), ref templateText);
            ReplaceVariable("{ALCOHOL}", sud.ErgAlkohol.ToString(CultureInfo.InvariantCulture), ref templateText);
            ReplaceVariable("{BITTERNESS}", sud.Ibu.ToString(), ref templateText);
        }

        private void ReplaceMalts(Sud sud, ref string templateText)
        {
            var malts = string.Empty;
            foreach (var malzschuettung in sud.Malzschuettung)
            {
                malts += "| " + malzschuettung.Name + " | " + malzschuettung.Menge + " kg | " + malzschuettung.Prozent + " % |\n";
            }

            foreach (var weitereZutatenGabe in sud.WeitereZutatenGabe.Where(x => x.Zeitpunkt == Zeitpunkt.Maischen))
            {
                malts += "| " + weitereZutatenGabe.Name + " | " + weitereZutatenGabe.ErgMenge + " " + weitereZutatenGabe.Einheit + " | " + weitereZutatenGabe.Menge + " g/L |\n";
            }

            ReplaceVariable("{MALTS}", malts, ref templateText);
        }

        private void ReplaceWater(Sud sud, ref string templateText)
        {
            var water = "| Mash | " + sud.ErgWHauptguss + " L |\n"
                        + "| Sparge | " + sud.ErgWNachguss + " L |";

            ReplaceVariable("{WATER}", water, ref templateText);
        }

        private void ReplaceMashingGuidelines(Sud sud, ref string templateText)
        {
            var mash = "| Mash In | " + sud.EinmaischenTemp + "° C | - |\n";
            // ReSharper disable once LoopCanBeConvertedToQuery
            foreach (var rast in sud.Rasten.OrderBy(x => x.Temperatur))
            {
                mash += "| " + rast.Name + " | " + rast.Temperatur + "° C | " + rast.Dauer + " min |\n";
            }

            ReplaceVariable("{MASHING}", mash, ref templateText);
        }

        private void ReplaceBoiling(Sud sud, ref string templateText)
        {
            var boiling = string.Empty;
            foreach (var hopfengabe in sud.Hopfengabe)
            {
                boiling += "| " + hopfengabe.Menge + " g | " + hopfengabe.Hopfentext + " | " + (hopfengabe.Vorderwuerze ? " First wort hopping" : hopfengabe.Zeit + " min") + " |\n";
            }

            foreach (var weitereZutatenGabe in sud.WeitereZutatenGabe.Where(x => x.Zeitpunkt == Zeitpunkt.Kochbeginn))
            {
                boiling += "| " + weitereZutatenGabe.ErgMenge + " " + weitereZutatenGabe.Einheit + " | " + weitereZutatenGabe.Name + " | " 
                           + (string.IsNullOrEmpty(weitereZutatenGabe.Bemerkung) ? "Begin boiling" : weitereZutatenGabe.Bemerkung) + " |\n";
            }

            ReplaceVariable("{BOILING}", boiling, ref templateText);
        }

        private void ReplaceYeast(Sud sud, ref string templateText)
        {
            ReplaceVariable("{YEAST}", sud.HefeAnzahlEinheiten + "x " + sud.AuswahlHefe, ref templateText);
        }

        private void ReplaceAdditional(Sud sud, ref string templateText)
        {
            var additional = string.Empty;

            if (sud.WeitereZutatenGabe.Any())
            {
                additional += "### Additional\n\n"
                              + "| Days | Amount | Type |\n"
                              + "| ---- | ------ | ---- |\n";
            }

            foreach (var weitereZutatenGabe in sud.WeitereZutatenGabe.Where(x => x.Zeitpunkt == Zeitpunkt.Gaerung))
            {

                additional += "| " + weitereZutatenGabe.Zugabedauer + " | " + weitereZutatenGabe.ErgMenge + " " + weitereZutatenGabe.Einheit + " | " +
                              weitereZutatenGabe.Name + " |\n";
            }

            ReplaceVariable("{ADDITIONAL}", additional, ref templateText);
        }

        private void ReplaceInformation(Sud sud, ref string templateText)
        {
            var info = string.Empty;

            if (!string.IsNullOrEmpty(sud.Kommentar))
            {
                info += "### Information\n\n"
                    + sud.Kommentar;
            }

            ReplaceVariable("{INFORMATION}", info, ref templateText);
        }

        private void ReplaceRating(Sud sud, ref string templateText)
        {
            var rating = string.Empty;

            if (sud.Bewertungen.Any())
            {
                rating = "### Rating\n\n"
                         + "| Week | Rating | Color | Foam | Smell | Taste | Freshness | Mouth-Feel | Hop-Aroma | Overall impression |\n"
                         + "| ---- | ------ | ----- | ---- | ----- | ----- | --------- | ---------- | --------- | ------------------ |\n";
            }

            var text = string.Empty;
            foreach (var bewertung in sud.Bewertungen.OrderBy(x => x.Woche))
            {
                rating += "| " + bewertung.Woche
                               + " | " + bewertung.Sterne
                               + " | " + bewertung.Farbe
                               + " | " + bewertung.Schaum
                               + " | " + bewertung.Geruch
                               + " | " + bewertung.Geschmack
                               + " | " + bewertung.Antrunk
                               + " | " + bewertung.Haupttrunk
                               + " | " + bewertung.Nachtrunk
                               + " | " + bewertung.Gesamteindruck
                               + " |\n";

                if (!string.IsNullOrEmpty(bewertung.Bemerkung))
                {
                    text += "Woche " + bewertung.Woche + ": " + bewertung.Bemerkung + "\n";
                }
            }

            if (!string.IsNullOrEmpty(text))
            {
                rating += "\n\n" + text;
            }

            ReplaceVariable("{RATING}", rating, ref templateText);
        }
    }
}
