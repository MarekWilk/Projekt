using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WpfProjekt
{
    /// <summary>
    /// Logika interakcji dla klasy Window3.xaml
    /// </summary>
    public partial class Window3 : Window
    {
        public Window3()
        {
            InitializeComponent();
            MyDBDataSet db = new MyDBDataSet();
            var docs = from d in db.Fryzier_męski
                       select d;
            foreach (var item in docs)
            {
                Console.WriteLine(item.imie);
                Console.WriteLine(item.nazwisko);
                Console.WriteLine(item.Telefon);
                Console.WriteLine(item.RodzajUsługi);
                
            }
            this.gridman.ItemsSource = docs.ToList();       
        }

        private void gridman_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
