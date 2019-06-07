using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BKNBrauhelferKonverter.Enums
{
    [Flags]
    public enum Schaum
    {
        Unbekannt = 0,

        // Porengroesse
        Feinporig = 1 << 0,
        Grobporig = 1 << 1,

        // Haftbarkeit
        GutHaftend = 1 << 2,
        SchlechtHaftend = 1 << 3,

        // Haltbarkeit
        GutHaltbar = 1 << 4,
        MittelHaltbar = 1 << 5,
        NichtHaltbar = 1 << 6,

        // Volumen
        GeringesVolumen = 1 << 7,
        KraeftigesVolumen = 1 << 8,
        MaechtigesVolumen = 1 << 9,
        Ueberschaeumend = 1 << 10
    }
}
