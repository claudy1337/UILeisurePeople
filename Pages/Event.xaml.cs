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
    /// Логика взаимодействия для Event.xaml
    /// </summary>
    public partial class Event : Page
    {
        public static Classes.Client Client;
        public Event(Classes.Client client)
        {
            Client = client;
            InitializeComponent();
            ListEvent.ItemsSource = Classes.BD_Connection.bd.Event.ToList();
            txtSearch.ItemsSource = Classes.BD_Connection.bd.TypeEvent.ToList();
        }

        private void txtSearch_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectTypeEvent = txtSearch.SelectedItem as Classes.Model.TypeEvent;
            ListEvent.ItemsSource = Classes.BD_Connection.bd.Event.Where(p=>p.TypeEvent.Type == selectTypeEvent.Type).ToList();
        }

        private void ListEvent_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                var selectEvent = ListEvent.SelectedItem as Classes.Model.Event;
                txtEventName.Text = selectEvent.Name;
                txtEventSeats.Text = selectEvent.CountSeats.ToString();
                txtEventAddress.Text = selectEvent.Place.Address;
            }
            catch(Exception)
            {
                return;
            }
            
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

        private void BtnVisit_Click(object sender, RoutedEventArgs e)
        {
            var selectEvent = ListEvent.SelectedItem as Classes.Model.Event;
            Classes.Model.Place place = Classes.BD_Connection.bd.Place.FirstOrDefault(p=>p.idPlace == selectEvent.idPlace);
            Classes.Model.Stat stat = new Classes.Model.Stat
            {
                DateVisit = DateTime.Now.ToString(),
                idClient = Client.Id,
                idPlace = place.idPlace,
                Estimation = Convert.ToInt32(txtEventEstimation.Text)
            };
            selectEvent.CountSeats -= 1;
            Classes.BD_Connection.bd.Stat.Add(stat);
            Classes.BD_Connection.bd.SaveChanges();
            MessageBox.Show("ty to visit");
        }
    }
}
