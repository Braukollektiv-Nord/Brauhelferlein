using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BKNBrauhelferKonverter.Enums
{
    public enum Antrunk
    {
        Unbekannt = 0,
        Angenehm = 1 << 0,
        Rezent = 1 << 1,
        GutEingebunden = 1 << 2,
        Prickelnd = 1 << 3,
        Aufdringlich = 1 << 4,
        WenigRezent = 1 << 5,
        Schal = 1 << 6,
        SehrSchal = 1 << 7
    }
}
