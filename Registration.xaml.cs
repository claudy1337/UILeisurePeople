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
    /// Логика взаимодействия для Registration.xaml
    /// </summary>
    public partial class Registration : Window
    {
        public Registration()
        {
            InitializeComponent();
        }

        private void TextBlock_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Auth auth = new Auth();
            auth.Show();
            this.Close();
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

        private void BtnCreateAccount_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TxtClientLogin.Text) && string.IsNullOrWhiteSpace(TxtClientName.Text) && string.IsNullOrWhiteSpace(TxtClientPassword.Password))
            {
                return;
            }
            else
            {
                Classes.Model.Client SearchClient = Classes.BD_Connection.bd.Client.FirstOrDefault(c => c.Login == TxtClientLogin.Text);
                if (SearchClient == null)
                {
                    Classes.Model.Client client = new Classes.Model.Client
                    {
                        idRole = 2,
                        Name = TxtClientName.Text,
                        Login = TxtClientLogin.Text,
                        Password = TxtClientPassword.Password
                    };
                    Classes.BD_Connection.bd.Client.Add(client);
                    Classes.BD_Connection.bd.SaveChanges();
                    Classes.Client clients = new Classes.Client(client.idClient, client.Name, client.LastName, client.Login, Convert.ToInt32(client.idRole), client.Link);
                    MessageBox.Show("account add");
                    main main = new main(clients);
                    main.Show();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("incorrect");
                    return;
                }
            }
            
        }
    }
}
