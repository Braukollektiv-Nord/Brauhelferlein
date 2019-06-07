using BKNBrauhelferKonverter.Utils;

namespace BKNBrauhelferKonverter.Models
{
    public class Malzschuettung
    {
        [DbField("ID")]
        public int Id { get; set; }

        [DbField("SudID")]
        public int SudId { get; set; }

        [DbField("Name")]
        public string Name { get; set; }

        [DbField("Prozent")]
        public double Prozent { get; set; }

        [DbField("erg_Menge")]
        public double Menge { get; set; }

        [DbField("Farbe")]
        public double Farbe { get; set; }
    }
}
