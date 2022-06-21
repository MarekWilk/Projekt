using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static WpfProjekt.MainWindow;

namespace WpfProjekt
{
    public class FryzjerM : Osoba, IPrintable
    {
        public int CenaM { get; set; }
        public RodzajUslugiM Uslugi { get; set; }
        public FryzjerM() { }
        public FryzjerM(string imie, string nazwisko, int telefon, RodzajUslugiM rodzajUslugiM, int cena)
        {
            Imie = imie;
            Nazwisko = nazwisko;
            Uslugi = rodzajUslugiM;
            CenaM = cena;
            Telefon = telefon;
        }
        /*
         * Metoda interfejsu
         */
        public string Wypisz()
        {
            string retVal = Uslugi+ " "+ Imie + " " + Nazwisko + " " + CenaM + "\nTelefon: " + Telefon + "\n";
            return retVal;
        }
    }
}