using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BKNBrauhelferKonverter.Enums;
using BKNBrauhelferKonverter.Utils;

namespace BKNBrauhelferKonverter.Models
{
    public class Bewertung
    {
        [DbField("ID")]
        public int Id { get; set; }

        [DbField("SudID")]
        public int SudId { get; set; }

        [DbField("Woche")]
        public int Woche { get; set; }

        [DbField("Datum")]
        public DateTime Datum { get; set; }

        [DbField("Sterne")]
        public int Sterne { get; set; }

        [DbField("Bemerkung")]
        public string Bemerkung { get; set; }

        [DbField("Farbe")]
        public int FarbeIntern { private get; set; }

        [DbField("FarbeBemerkung")]
        public string FarbeBemerkung { get; set; }

        [DbField("Schaum")]
        public int SchaumIntern { private get; set; }

        [DbField("SchaumBemerkung")]
        public string SchaumBemerkung { get; set; }

        [DbField("Geruch")]
        public int GeruchIntern { private get; set; }

        [DbField("GeruchBemerkung")]
        public string GeruchBemerkung { get; set; }

        [DbField("Geschmack")]
        public int GeschmackIntern { private get; set; }

        [DbField("GeschmackBemerkung")]
        public string GeschmackBemerkung { get; set; }

        [DbField("Antrunk")]
        public int AntrunkIntern { private get; set; }

        [DbField("AntrunkBemerkung")]
        public string AntrunkBemerkung { get; set; }

        [DbField("Haupttrunk")]
        public int HaupttrunkIntern { private get; set; }

        [DbField("HaupttrunkBemerkung")]
        public string HaupttrunkBemerkung { get; set; }

        [DbField("Nachtrunk")]
        public int NachtrunkIntern { private get; set; }

        [DbField("NachtrunkBemerkung")]
        public string NachtrunkBemerkung { get; set; }

        [DbField("Gesamteindruck")]
        public int GesamteindruckIntern { private get; set; }

        [DbField("GesamteindruckBemerkung")]
        public string GesamteindruckBemerkung { get; set; }


        public Farbe Farbe => (Farbe) FarbeIntern;
        public Schaum Schaum => (Schaum) SchaumIntern;
        public Geruch Geruch => (Geruch) GeruchIntern;
        public Geschmack Geschmack => (Geschmack) GeschmackIntern;
        public Antrunk Antrunk => (Antrunk) AntrunkIntern;
        public Haupttrunk Haupttrunk => (Haupttrunk) HaupttrunkIntern;
        public Nachtrunk Nachtrunk => (Nachtrunk) NachtrunkIntern;
        public Gesamteindruck Gesamteindruck => (Gesamteindruck) GesamteindruckIntern;
    }
}
