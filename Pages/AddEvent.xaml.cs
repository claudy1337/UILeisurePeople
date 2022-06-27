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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace UIKitTutorials.Pages
{
    /// <summary>
    /// Логика взаимодействия для AddEvent.xaml
    /// </summary>
    public partial class AddEvent : Page
    {
        public static Classes.Client Client;
        public AddEvent(Classes.Client client)
        {
            Client = client;
            InitializeComponent();
            txtEventType.ItemsSource = Classes.BD_Connection.bd.TypeEvent.ToList();
            CBPlace.ItemsSource = Classes.BD_Connection.bd.Place.ToList();
        }

        private void BtnAddEvent_Click(object sender, RoutedEventArgs e)
        {
            var selectTypeEvent = txtEventType.SelectedItem as Classes.Model.TypeEvent;
            var selectPlace = CBPlace.SelectedItem as Classes.Model.Place;
            Classes.Model.Place place = Classes.BD_Connection.bd.Place.FirstOrDefault(p=>p.idPlace == selectPlace.idPlace);
            Classes.Model.Event events = new Classes.Model.Event
            {
                idType = selectTypeEvent.idType,
                DateStart = DPDateStart.ToString(),
                Name = txtEventName.Text,
                CountSeats = place.CountSeats,
                idPlace = selectPlace.idPlace,
                DateEnd = DPDateStart + "0000-00-10"
                
            };
            Classes.BD_Connection.bd.Event.Add(events);
            Classes.BD_Connection.bd.SaveChanges();
            MessageBox.Show("event Add");
        }

        private void txtSearch_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
