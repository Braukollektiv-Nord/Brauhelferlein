using System;
using BKNBrauhelferKonverter.Enums;
using BKNBrauhelferKonverter.Utils;

namespace BKNBrauhelferKonverter.Models
{
    public class WeitereZutatenGabe
    {
        [DbField("ID")]
        public int Id { get; set; }

        [DbField("SudID")]
        public int SudId { get; set; }

        [DbField("Name")]
        public string Name { get; set; }

        [DbField("Menge")]
        public double Menge { get; set; }

        [DbField("Einheit")]
        public int EinheitIntern { private get; set; }

        [DbField("Typ")]
        public int TypIntern { private get; set; }

        [DbField("Zeitpunkt")]
        public int ZeitpunktIntern { private get; set; }

        [DbField("Bemerkung")]
        public string Bemerkung { get; set; }

        [DbField("erg_Menge")]
        public double ErgMenge { get; set; }

        [DbField("Ausbeute")]
        public int Ausbeute { get; set; }

        [DbField("Farbe")]
        public double Farbe { get; set; }

        [DbField("Zeitpunkt_von")]
        public DateTime ZeitpunktVon { get; set; }

        [DbField("Zeitpunkt_bis")]
        public DateTime ZeitpunktBis { get; set; }

        [DbField("Zugabestatus")]
        public int ZugabestatusIntern { private get; set; }

        [DbField("Entnahmeindex")]
        public int Entnahmeindex { get; set; }

        [DbField("Zugabedauer")]
        public int Zugabedauer { get; set; }


        public Einheit Einheit => (Einheit) EinheitIntern;
        public ZutatenTyp Typ => (ZutatenTyp) TypIntern;
        public Zeitpunkt Zeitpunkt => (Zeitpunkt) ZeitpunktIntern;
        public ZugabeStatus ZugabeStatus => (ZugabeStatus) ZugabestatusIntern;
    }

}
