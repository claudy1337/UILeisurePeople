using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

namespace UIKitTutorials.Pages
{
    /// <summary>
    /// Логика взаимодействия для Place.xaml
    /// </summary>
    public partial class Place : Page
    {
        public static Classes.Client Client;
        public Place(Classes.Client client)
        {
            Client = client;
            InitializeComponent();
            string Actualdate = DateTime.Now.ToString();
            ListPlace.ItemsSource = Classes.BD_Connection.bd.Place.Where(p => p.isClose == false).ToList();
            txtSearch.ItemsSource = Classes.BD_Connection.bd.TypePlace.ToList();
           
        }

        private void ListPlace_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                var selectPlace = ListPlace.SelectedItem as Classes.Model.Place;
                txtPlaceAvverage.Text = selectPlace.Name;
                txtPlaceAddress.Text = selectPlace.Address;
                txtPlaceSeats.Text = selectPlace.CountSeats.ToString();
            }
            catch(Exception)
            {
                return;
            }
        }

        private void BtnVisit_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtPlaceEstimation.Text))
            {
                return;
            }
            else
            {
                var selectPlace = ListPlace.SelectedItem as Classes.Model.Place;
                Classes.Model.Stat stat = new Classes.Model.Stat
                {
                    DateVisit = DateTime.Now.ToString(),
                    idClient = Client.Id,
                    idPlace = selectPlace.idPlace,
                    Estimation = Convert.ToInt32(txtPlaceEstimation.Text)
                };
                Classes.BD_Connection.bd.Stat.Add(stat);
                Classes.BD_Connection.bd.SaveChanges();
                MessageBox.Show("ty to visit");
            }
        }

        private void txtSearch_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectTypePlace = txtSearch.SelectedItem as Classes.Model.TypePlace;
            ListPlace.ItemsSource = Classes.BD_Connection.bd.Place.Where(p => p.isClose == false && p.TypePlace.Type == selectTypePlace.Type).ToList();
        }

        private void Estimation(object sender, TextCompositionEventArgs e)
        {
            if (!Char.IsDigit(e.Text, 0))
            {
                e.Handled = true;
            }
            Regex regex = new Regex("[^1-5]+");
            e.Handled = regex.IsMatch(e.Text);
        }
    }
}
