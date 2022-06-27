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

namespace UIKitTutorials
{
    /// <summary>
    /// Логика взаимодействия для Auth.xaml
    /// </summary>
    public partial class Auth : Window
    {
        public Auth()
        {
            InitializeComponent();
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

        private void TextBlock_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Registration registration = new Registration();
            registration.Show();
            this.Close();
        }

        private void BtnAuth_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TxtClientPassword.Password) && string.IsNullOrWhiteSpace(TxtClienLogin.Text))
            {
                return;
            }
            else
            {
                Classes.Model.Client client = Classes.BD_Connection.bd.Client.FirstOrDefault(c=>c.Login == TxtClienLogin.Text && c.Password == TxtClientPassword.Password);
                if (client != null)
                {
                    Classes.Client clients = new Classes.Client(client.idClient, client.Name, client.LastName, client.Login, Convert.ToInt32(client.idRole), client.Link);
                    main main = new main(clients);
                    main.Show();
                    this.Close();
                }
                else return;
                
            }
            
        }
    }
}
