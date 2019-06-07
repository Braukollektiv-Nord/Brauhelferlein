using BKNBrauhelferKonverter.Utils;

namespace BKNBrauhelferKonverter.Models
{
    public class Rast
    {
        [DbField("ID")]
        public int Id { get; set; }

        [DbField("SudID")]
        public int SudId { get; set; }

        [DbField("RastName")]
        public string Name { get; set; }

        [DbField("RastAktiv")]
        public bool Aktiv { get; set; }

        [DbField("RastTemp")]
        public int Temperatur { get; set; }

        [DbField("RastDauer")]
        public int Dauer { get; set; }
    }
}
