using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BKNBrauhelferKonverter.Enums
{
    [Flags]
    public enum Geruch
    {
        Unbekannt = 0,
        Rein = 1 << 0,
        Frisch = 1 << 1,
        Wohlriechend = 1 << 2,
        Unausgewogen = 1 << 3,
        Hopfig = 1 << 4,
        Malzig = 1 << 5,
        Suesslich = 1 << 6,
        Hefig = 1 << 7,
        Fruchtig = 1 << 8,
        Gewuerzig = 1 << 9,
        Saeuerlich = 1 << 10,
        Geruchsfehler = 1 << 11
    }
}
