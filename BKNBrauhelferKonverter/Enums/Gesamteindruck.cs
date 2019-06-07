using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BKNBrauhelferKonverter.Enums
{
    public enum Gesamteindruck
    {
        Unbekannt = 0,
        Toll = 1 << 0,
        Typisch = 1 << 1,
        Interessant = 1 << 2,
        Ueberraschend = 1 << 3,
        Kreativ = 1 << 4,
        Unauffaellig = 1 << 5,
        Langweilig = 1 << 6,
        Problematisch = 1 << 7
    }
}
