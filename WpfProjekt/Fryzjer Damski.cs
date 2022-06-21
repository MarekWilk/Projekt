using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static WpfProjekt.MainWindow;

namespace WpfProjekt
{
    public class FryzjerK : Osoba, IPrintable
    {
        public int CenaK { get; set; }
        public RodzajUslugiK RodzajUslugiK { get; set; }
        public FryzjerK() { }
        public FryzjerK(string imie, string nazwisko, int telefon, RodzajUslugiK rodzajUslugiK,int cenaK)
        {
            Imie = imie;
            Nazwisko = nazwisko;
            RodzajUslugiK = rodzajUslugiK;
            Telefon = telefon;
            CenaK = cenaK;
        }
        /*
         * Metoda interfejsu
         */

        public string Wypisz()
        {
            string retVal = RodzajUslugiK + " " + Imie + " " + Nazwisko + "\nTelefon: " + Telefon + "\n" + CenaK;
            return retVal;
        }
    }
}