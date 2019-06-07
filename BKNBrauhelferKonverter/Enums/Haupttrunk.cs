using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BKNBrauhelferKonverter.Enums
{
    public enum Haupttrunk
    {
        Unbekannt = 0,
        Waessrig = 1 << 0,
        EtwasLeer = 1 << 1,
        Schlank = 1 << 2,
        Vollmundig = 1 << 3,
        Mastig = 1 << 4
    }
}
