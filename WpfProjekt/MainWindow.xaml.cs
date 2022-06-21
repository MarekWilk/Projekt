using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml.Serialization;
using static WpfProjekt.MyDBDataSet;

namespace WpfProjekt
{
    public partial class MainWindow : Window
    {
        public enum RodzajUslugiK { ObcinanieWłosów, Czesanie, Farbowanie, Botoks, Keratynina, Przedłużanie }
        public enum RodzajUslugiM { Strzyżenie, StrzyżenieBrody, StrzyżenieWłosów }
        Listy listy = new Listy();
        
        public MainWindow()
        {
            InitializeComponent();
            dgPracownicy.ItemsSource = listy.FryzjerDamski;
            dgStudenci.ItemsSource = listy.FryzjerMeski;
            cbKierunek.ItemsSource = Enum.GetValues(typeof(RodzajUslugiM));
            cbStanowisko.ItemsSource = Enum.GetValues(typeof(RodzajUslugiK));
            cb4.Visibility = Visibility.Hidden;
            label4.Visibility = Visibility.Hidden;
            label5.Visibility = Visibility.Hidden;
            tb5.Visibility = Visibility.Hidden;
        }
        /*
         * Zaznaczenie RadioButtona "fryzjer kobiecy" przy dodawaniu nowej osoby
         */
        private void rbpracownik_Checked(object sender, RoutedEventArgs e)
        {
            tb5.Text = "";
            cb4.Text = "";
            cb4.Visibility = Visibility.Visible;
            label4.Visibility = Visibility.Visible;
            label5.Visibility = Visibility.Visible;
            tb5.Visibility = Visibility.Visible;
            label4.Content = "Rodzaj Usługi";
            label5.Content = "Cena";
            cb4.ItemsSource = Enum.GetValues(typeof(RodzajUslugiK));

        }
        /*
         * Zaznaczenie RadioButtona "fryzjer meski" przy dodawaniu nowej osoby
         */
        private void rbstudent_Checked(object sender, RoutedEventArgs e)
        {
            tb5.Text = "";
            cb4.Text = "";
            cb4.Visibility = Visibility.Visible;
            label4.Visibility = Visibility.Visible;
            label5.Visibility = Visibility.Visible;
            tb5.Visibility = Visibility.Visible;
            label4.Content = "Rodzaj Usługi";
            label5.Content = "Cena";
            cb4.ItemsSource = Enum.GetValues(typeof(RodzajUslugiM));
        }
        /*
         * Wciśniecie przycisku "dodaj nową osobę" w zakładce dodawania
         * Osbługa wyjątków
         */
        private  void Dodaj_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if ((rbstudent.IsChecked == false) && (rbpracownik.IsChecked == false))
                {
                    Exception brakWyboru = new Exception("Musisz wybrać typ osoby!");
                    throw brakWyboru;
                }
                if (String.IsNullOrEmpty(tbimie.Text))
                {
                    Exception pusteImie = new Exception("Musisz podać imię!");
                    throw pusteImie;
                }
                if (String.IsNullOrEmpty(tbnazwisko.Text))
                {
                    Exception pusteNazwisko = new Exception("Musisz podać Nazwisko!");
                    throw pusteNazwisko;
                }
                if (String.IsNullOrEmpty(tbtelefon.Text))
                {
                    Exception pusteTelefon = new Exception("Musisz podać Numer telefonu!");
                    throw pusteTelefon;
                }
                if ((String.IsNullOrEmpty(cb4.Text)) || (String.IsNullOrEmpty(tb5.Text)))
                {
                    Exception pusteKierunek = new Exception("Musisz wybrać Rodzaj usługi i podać cenę!");
                    throw pusteKierunek;
                }
                if (rbpracownik.IsChecked == true)
                {
                    string imie = tbimie.Text;
                    string nazwisko = tbnazwisko.Text;
                    int telefon = Convert.ToInt32(tbtelefon.Text);
                    RodzajUslugiK rodzajUslugi = (RodzajUslugiK)Enum.Parse(typeof(RodzajUslugiK), cb4.Text);
                    int CenaK = Convert.ToInt32(tb5.Text);
                    FryzjerK pracownik = new FryzjerK(imie, nazwisko, telefon, rodzajUslugi, CenaK);
                    listy.Dodaj(pracownik);
                 
                }
                else if (rbstudent.IsChecked == true)
                {
                    string imie = tbimie.Text;
                    string nazwisko = tbnazwisko.Text;
                    int telefon = Convert.ToInt32(tbtelefon.Text);
                    RodzajUslugiM rodzajUslugiM = (RodzajUslugiM)Enum.Parse(typeof(RodzajUslugiM), cb4.Text);
                    int CenaM = Convert.ToInt32(tb5.Text);
                    FryzjerM student = new FryzjerM(imie, nazwisko, telefon, rodzajUslugiM, CenaM);
                    listy.Dodaj(student);
                    MessageBox.Show("Dodano do listy klientów");
                }
                Czysc();
            }
            catch (FormatException)
            {
                if (rbstudent.IsChecked == true)
                    MessageBox.Show("Podaj poprawny numer telefonu i cenę");
                if (rbpracownik.IsChecked == true)
                    MessageBox.Show("Podaj poprawny numer telefonu i cenę");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Koniec_Click(object sender, RoutedEventArgs e)
        {
            System.Environment.Exit(0);
        }
        /*
         * Kliknięcie przycisku "zapisz do xml"
         */
        private void Zapisz_Click(object sender, RoutedEventArgs e)
        {
            Window2 window1 = new Window2();
            this.Visibility = Visibility.Hidden;
            window1.Show();
        }
        /*
         * Serializacja danych do XML
         */
        /*private void ListyDoPliku(string filePath)
        {
            using (var sw = new StreamWriter(filePath))
            {
                var serializer = new XmlSerializer(typeof(Listy));
                serializer.Serialize(sw, listy);
            }
        }*/
        /*
         * Kliknięcie przycisku "wczytaj z xml"
         */
        private void Wczytaj_Click(object sender, RoutedEventArgs e)
        {
            Window3 window1 = new Window3();
            this.Visibility = Visibility.Hidden;
            window1.Show();
        }
        /*
         * Deserializacja danych z XML
         */
        private void ZPlikuDoListy(string filename)
        {
            try
            {
                using (var sr = new StreamReader(filename))
                {
                    var deserializer = new XmlSerializer(typeof(Listy));
                    Listy tmpList = (Listy)deserializer.Deserialize(sr);
                    foreach (var item in tmpList.FryzjerDamski)
                    {
                        listy.Dodaj(item);
                    }
                    foreach (var item in tmpList.FryzjerMeski)
                    {
                        listy.Dodaj(item);
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Niepoprawne dane w pliku!");
            }

        }
        /*
         * Kliknięcie przycisku "wyczysc pola" w zakładce dodawania
         * Czyszczenie pól
         */
        private void Clear_Click(object sender, RoutedEventArgs e)
        {
            Czysc();
        }
        private void Czysc()
        {
            tbimie.Text = "";
            tbnazwisko.Text = "";
            tbtelefon.Text = "";
            tb5.Text = "";
            cb4.Text = "";
            rbpracownik.IsChecked = false;
            rbstudent.IsChecked = false;
            cb4.Visibility = Visibility.Hidden;
            label4.Visibility = Visibility.Hidden;
            label5.Visibility = Visibility.Hidden;
            tb5.Visibility = Visibility.Hidden;
        }
        /*
         * Kliknięcie przycisku "export studentow do txt"
         */
        private void ExportStudentow_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.SaveFileDialog dlg = new Microsoft.Win32.SaveFileDialog();
            dlg.FileName = "Studenci";
            dlg.DefaultExt = ".txt";
            dlg.Filter = "Pliki txt (.txt)|*.txt";
            Nullable<bool> result = dlg.ShowDialog();
            if (result == true)
            {
                string filePath = dlg.FileName;

                using (var sw = new StreamWriter(filePath))
                {
                    foreach (var item in listy.FryzjerMeski)
                    {
                        sw.WriteLine(item.Wypisz());
                    }
                }
            }
        }
        /*
         * Kliknięcie przycisku "export studentow do txt"
         */
        private void ExportPracownikow_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.SaveFileDialog dlg = new Microsoft.Win32.SaveFileDialog();
            dlg.FileName = "Pracownicy";
            dlg.DefaultExt = ".txt";
            dlg.Filter = "Pliki txt (.txt)|*.txt";
            Nullable<bool> result = dlg.ShowDialog();
            if (result == true)
            {
                string filePath = dlg.FileName;
                using (var sw = new StreamWriter(filePath))
                {
                    foreach (var item in listy.FryzjerDamski)
                    {
                        sw.WriteLine(item.Wypisz());
                    }
                }
            }
        }


    }
}