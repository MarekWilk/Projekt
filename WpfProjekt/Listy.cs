using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfProjekt
{
    /*
     * Klasa, która reprezentuje obiekty przechowujące Klientów w listach.
     * Wykorzystano tutaj kolekcje generyczne.
     */
    public class Listy
    {
        public ObservableCollection<FryzjerK> FryzjerDamski { get; set; }
        public ObservableCollection<FryzjerM> FryzjerMeski { get; set; }
        public Listy()
        {
            FryzjerDamski = new ObservableCollection<FryzjerK>();
            FryzjerMeski = new ObservableCollection<FryzjerM>();
            MyDBDataSet Fryzjerk = new MyDBDataSet();
            MyDBDataSet FryzjerM = new MyDBDataSet();
        }
        

        /*
         * Zastosowanie polimorfizmu:
         */
        public void Dodaj(FryzjerM student)
        {
            FryzjerMeski.Add(student);
        }
        public void Dodaj(FryzjerK student)
        {
            FryzjerDamski.Add(student);
        }
    }
}