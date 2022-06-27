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
    /// Lógica de interacción para HomePage.xaml
    /// </summary>
    public partial class HomePage : Page
    {
        public static Classes.Client Client;
        public HomePage(Classes.Client client)
        {
            Client = client;
            InitializeComponent();
            txtClientLogin.Text = Client.Login;
            txtClientName.Text = Client.Name;
            txtClientLink.Text = Client.Link;
            txtClientLastName.Text = Client.LastName;
            if (Client.Role == 2)
            {
                txtPlace.Visibility = Visibility.Hidden;
                txtCountPlace.Visibility = Visibility.Hidden;
            }
            else
            {
                 
                txtCountPlace.Text = Classes.BD_Connection.bd.Owner.Where(o => o.Client.Login == Client.Login).ToList().Count().ToString();
            }
        }

        
        private void BtnEditContent_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Classes.Model.Client client = Classes.BD_Connection.bd.Client.Where(c => c.Login == Client.Login && c.idClient == Client.Id).FirstOrDefault();
                Classes.Model.Client SearchClient = Classes.BD_Connection.bd.Client.Where(c => c.Link == txtClientLink.Text).FirstOrDefault();
                client.Name = txtClientName.Text;
                client.LastName = txtClientLastName.Text;
                if (SearchClient == null)
                {
                    client.Link = txtClientLink.Text;
                }
                MessageBox.Show("Content Edit");
                Classes.BD_Connection.bd.SaveChanges();
            }
            catch(Exception)
            {
                return;
            }
            
            
        }
    }
}
