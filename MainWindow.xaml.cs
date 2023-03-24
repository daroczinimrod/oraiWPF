using System;
using System.Collections.Generic;
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

namespace WpfApp5
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void btnOsszead_Click(object sender, RoutedEventArgs e)
        {
            double elsoSzam, masodikSzam;
            JoErtekBiztositasa(out elsoSzam, out masodikSzam);

            lblEredmeny.Content = elsoSzam + masodikSzam;
        }

        private bool JokASzamok()
        {
            double elsoSzam = 0;
            try
            {
                elsoSzam = double.Parse(txtEgyikSzam.Text);

            }
            catch (FormatException)
            {

                MessageBox.Show("Nem jó a formátum!");
                txtEgyikSzam.Text = "";
                txtEgyikSzam.Focus();
                return false;
            }

            double masodikSzam = 0;
            try
            {
                masodikSzam = double.Parse(txtMasikSzam.Text);

            }
            catch (FormatException)
            {

                MessageBox.Show("Nem jó a formátum!");
                txtMasikSzam.Focus();
                txtMasikSzam.Text = "";
                return false;
            }
            return true;
        }

        private void JoErtekBiztositasa(out double elsoSzam, out double masodikSzam)
        {
            elsoSzam = 0;
            try
            {
                elsoSzam = double.Parse(txtEgyikSzam.Text);

            }
            catch (FormatException)
            {

                MessageBox.Show("Nem jó a formátum!");
                txtEgyikSzam.Text = "";
                txtEgyikSzam.Focus();
            }

            masodikSzam = 0;
            try
            {
                masodikSzam = double.Parse(txtMasikSzam.Text);

            }
            catch (FormatException)
            {

                MessageBox.Show("Nem jó a formátum!");
                txtMasikSzam.Focus();
                txtMasikSzam.Text = "";
            }
        }

        private void btnKivon_Click(object sender, RoutedEventArgs e)
        {

            if (JokASzamok())
            {
                lblEredmeny.Content = double.Parse(txtEgyikSzam.Text) - double.Parse(txtMasikSzam.Text);

            }

        }

        private void btnSzoroz_Click(object sender, RoutedEventArgs e)
        {
            double elsoSzam, masodikSzam;
            JoErtekBiztositasa(out elsoSzam, out masodikSzam);

            lblEredmeny.Content = elsoSzam * masodikSzam;
        }

        private void btnOszt_Click(object sender, RoutedEventArgs e)
        {
            double elsoSzam, masodikSzam;
            JoErtekBiztositasa(out elsoSzam, out masodikSzam);

            lblEredmeny.Content = elsoSzam / masodikSzam;
        }

        private void btnBtolt_Click(object sender, RoutedEventArgs e)
        {
            if (txtFajlNeve.Text == "")
            {
                MessageBox.Show("Nem adott meg semmit!");
            }
            lbEredmenyek.Items.Clear();
            try
            {
                StreamReader sr = new StreamReader(txtFajlNeve.Text);
                while (!sr.EndOfStream)
                {
                    lbEredmenyek.Items.Add(sr.ReadLine());
                }
                sr.Close();
            }
            catch (FileNotFoundException)
            {
                MessageBox.Show("A fájl nem található");
                txtFajlNeve.Text= "";
                txtFajlNeve.Focus();
                return;
            }
            catch (IOException sas)
            {
                MessageBox.Show("Ismeretlen IO hiba! \n" + sas.Message);
                return;
            }
            MessageBox.Show("Sikeres beolvasás!");

        }
    }
}

