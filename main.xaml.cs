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
using UIKitTutorials.Classes;

namespace UIKitTutorials
{
    /// <summary>
    /// Логика взаимодействия для main.xaml
    /// </summary>
    public partial class main : Window
    {
        public static Classes.Client Client;
        public main(Classes.Client client)
        {
            Client = client;
            InitializeComponent();
            if (Client.Role == 2)
            {
                BtnAddEvent.Visibility = Visibility.Hidden;
            }
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            try
            {
                if (e.ChangedButton == MouseButton.Left)
                    this.DragMove();
            }
            catch (System.InvalidOperationException)
            {
                return;
            }
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void btnMinimize_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void BtnHome_Click(object sender, RoutedEventArgs e)
        {
            PagesNavigation.Navigate(new Pages.HomePage(Client));
        }

        private void BtnPlace_Click(object sender, RoutedEventArgs e)
        {
            PagesNavigation.Navigate(new Pages.Place(Client));
        }

        private void BtnEvent_Click(object sender, RoutedEventArgs e)
        {
            PagesNavigation.Navigate(new Pages.Event(Client));
        }

        private void BtnAddEvent_Click(object sender, RoutedEventArgs e)
        {
            PagesNavigation.Navigate(new Pages.AddEvent(Client));
        }
    }
}
