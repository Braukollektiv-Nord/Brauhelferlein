using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BKNBrauhelferKonverter.Utils;

namespace BKNBrauhelferKonverter.Models
{
    public class Hopfengabe
    {
        [DbField("ID")]
        public int Id { get; set; }

        [DbField("SudID")]
        public int SudId { get; set; }

        [DbField("Aktiv")]
        public bool  Aktiv { get; set; }

        [DbField("Name")]
        public string Name { get; set; }

        [DbField("Prozent")]
        public double Prozent { get; set; }

        [DbField("Zeit")]
        public int Zeit { get; set; }

        [DbField("erg_Menge")]
        public double Menge { get; set; }

        [DbField("erg_Hopfentext")]
        public string Hopfentext { get; set; }

        [DbField("Alpha")]
        public double Alpha { get; set; }

        [DbField("Pellets")]
        public int Pellets { get; set; }

        [DbField("Vorderwuerze")]
        public bool Vorderwuerze { get; set; }
    }
}
