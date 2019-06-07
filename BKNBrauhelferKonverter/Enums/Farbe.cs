using System;

namespace BKNBrauhelferKonverter.Enums
{
    [Flags]
    public enum Farbe
    {
        Unbekannt = 0,

        // Klarheit:
        Intensiv = 1 << 0,
        Glaenzend = 1 << 1,
        Blass = 1 << 2,
        Fahl = 1 << 3,

        // Farbe:
        Hellgelb = 1 << 4,
        Gelb = 1 << 5,
        Golden = 1 << 6,
        Bernstein = 1 << 7,
        Kupferrot = 1 << 8,
        BraunTiefbraun = 1 << 9,
        Schwarz = 1 << 10
    }
}
