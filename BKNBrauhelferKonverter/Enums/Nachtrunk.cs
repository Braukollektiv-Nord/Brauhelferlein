using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BKNBrauhelferKonverter.Enums
{
    public enum Nachtrunk
    {
        Unbekannt = 0,
        SehrFein = 1 << 0,
        Ausgewogen = 1 << 1,
        NichtAnhaengend = 1 << 2,
        Nachhaengend = 1 << 3,
        StarkNachhaengend = 1 << 4,
        WenigHerb = 1 << 5,
        SehrHerb = 1 << 6,
        KaumWahrnehmbar = 1 << 7,
        Unangenehm = 1 << 8
    }
}
