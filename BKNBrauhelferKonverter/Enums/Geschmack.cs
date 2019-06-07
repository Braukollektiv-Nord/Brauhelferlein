using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BKNBrauhelferKonverter.Enums
{
    [Flags]
    public enum Geschmack
    {
        Unbekannt,
        Rein = 1 << 0,
        Ausgewogen = 1 << 1,
        Gehaltvoll = 1 << 2,
        Unausgewogen = 1 << 3,
        Unreif = 1 << 4,
        Hopfig = 1 << 5,
        Malzig = 1 << 6,
        Suesslich = 1 << 7,
        Saeuerlich = 1 << 8,
        Gewuerzig = 1 << 9,
        Fruchtig = 1 << 10,
        Hefig = 1 << 11,
        Geschmacksfehler = 1 << 12
    }
}
