using System;
using System.Collections.Generic;
using BKNBrauhelferKonverter.Utils;

namespace BKNBrauhelferKonverter.Models
{
    public class SudBase
    {
        [DbField("ID")]
        public int Id { get; set; }

        [DbField("Sudname")]
        public string Sudname { get; set; }

        [DbField("Braudatum")]
        public DateTime Braudatum { get; set; }

        [DbField("Sudnummer")]
        public int Sudnummer { get; set; }
    }

    public class Sud : SudBase
    {
        [DbField("Menge")]
        public double Menge { get; set; }

        [DbField("SW")]
        public double Stammwuerze { get; set; }

        [DbField("CO2")]
        public double Co2 { get; set; }

        [DbField("IBU")]
        public int Ibu { get; set; }

        [DbField("Kommentar")]
        public string Kommentar { get; set; }

        [DbField("BierWurdeGebraut")]
        public bool BierWurdeGebraut { get; set; }

        [DbField("Anstelldatum")]
        public DateTime Anstelldatum { get; set; }

        [DbField("WuerzemengeAnstellen")]
        public double WuerzemengeAnstellen { get; set; }

        [DbField("SWAnstellen")]
        public double StammwuerzeAnstellen { get; set; }

        [DbField("Abfuelldatum")]
        public DateTime Abfuelldatum { get; set; }

        [DbField("BierWurdeAbgefuellt")]
        public bool BierWurdeAbgefuellt { get; set; }

        [DbField("SWSchnellgaerprobe")]
        public double SwSchnellgaerprobe { get; set; }

        [DbField("SWJungbier")]
        public double SwJungbier { get; set; }

        [DbField("TemperaturJungbier")]
        public double TemperaturJungbier { get; set; }

        [DbField("WuerzemengeKochende")]
        public double WuerzemengeKochende { get; set; }

        [DbField("Speisemenge")]
        public double Speisemenge { get; set; }

        [DbField("SWKochende")]
        public double SwKochende { get; set; }

        [DbField("AuswahlHefe")]
        public string AuswahlHefe { get; set; }

        [DbField("FaktorHauptguss")]
        public double FaktorHauptguss { get; set; }

        [DbField("KochdauerNachBitterhopfung")]
        public int KochdauerNachBitterhopfung { get; set; }

        [DbField("EinmaischenTemp")]
        public int EinmaischenTemp { get; set; }

        [DbField("Erstellt")]
        public DateTime Erstellt { get; set; }

        [DbField("Gespeichert")]
        public DateTime Gespeichert { get; set; }

        [DbField("AktivTab")]
        public int AktivTab { get; set; }

        [DbField("erg_S_Gesammt")]
        public double ErgSGesammt { get; set; }

        [DbField("erg_W_Gesammt")]
        public double ErgWGesammt { get; set; }

        [DbField("erg_WHauptguss")]
        public double ErgWHauptguss { get; set; }

        [DbField("erg_WNachguss")]
        public double ErgWNachguss { get; set; }

        [DbField("erg_Sudhausausbeute")]
        public double ErgSudhausausbeute { get; set; }

        [DbField("erg_Farbe")]
        public double ErgFarbe { get; set; }

        [DbField("erg_Preis")]
        public double ErgPreis { get; set; }

        [DbField("erg_Alkohol")]
        public double ErgAlkohol { get; set; }

        [DbField("KostenWasserStrom")]
        public double KostenWasserStrom { get; set; }

        [DbField("Bewertung")]
        public int Bewertung { get; set; }

        [DbField("Bewertung")]
        public string BewertungText { get; set; }

        [DbField("AktivTab_Gaerverlauf")]
        public int AktivTabGaerverlauf { get; set; }

        [DbField("Reifezeit")]
        public int Reifezeit { get; set; }

        [DbField("BierWurdeVerbraucht")]
        public bool BierWurdeVerbraucht { get; set; }

        [DbField("Nachisomerisierungszeit")]
        public int Nachisomerisierungszeit { get; set; }

        [DbField("WuerzemengeVorHopfenseihen")]
        public double WuerzemengeVorHopfenseihen { get; set; }

        [DbField("SWVorHopfenseihen")]
        public double SwVorHopfenseihen { get; set; }

        [DbField("erg_EffektiveAusbeute")]
        public double ErgEffektiveAusbeute { get; set; }

        [DbField("RestalkalitaetSoll")]
        public double RestalkalitaetSoll { get; set; }

        [DbField("SchnellgaerprobeAktiv")]
        public bool SchnellgaerprobeAktiv { get; set; }

        [DbField("JungbiermengeAbfuellen")]
        public double JungbiermengeAbfuellen { get; set; }

        [DbField("erg_AbgefuellteBiermenge")]
        public double ErgAbgefuellteBiermenge { get; set; }

        [DbField("BewertungMaxSterne")]
        public int BewertungMaxSterne { get; set; }

        [DbField("NeuBerechnen")]
        public bool NeuBerechnen { get; set; }

        [DbField("HefeAnzahlEinheiten")]
        public int HefeAnzahlEinheiten { get; set; }

        [DbField("berechnungsArtHopfen")]
        public int BerechnungsartHopfen { get; set; }

        [DbField("highGravityFaktor")]
        public int HighGravityFaktor { get; set; }

        [DbField("AuswahlBrauanlage")]
        public int AuswahlBrauanlage { get; set; }

        [DbField("AuswahlBrauanlageName")]
        public string AuswahlBrauanlageName { get; set; }

        [DbField("AusbeuteIgnorieren")]
        public bool AusbeuteIgnorieren { get; set; }

        [DbField("MerklistenID")]
        public int MerklistenId { get; set; }

        [DbField("Spunden")]
        public bool Spunden { get; set; }


        public IEnumerable<Rast> Rasten { get; set; }
        public IEnumerable<Malzschuettung> Malzschuettung { get; set; }
        public IEnumerable<Hopfengabe> Hopfengabe { get; set; }
        public IEnumerable<WeitereZutatenGabe> WeitereZutatenGabe { get; set; }
        public IEnumerable<Bewertung> Bewertungen { get; set; }
    }

    
}
