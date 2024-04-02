using Microsoft.Data.SqlClient.Server;
using Pitpm4.Data;
using Pitpm4.Models;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Pitpm4
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

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Form2 form2 = new Form2();
            this.Hide();
            form2.Show();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            using (MyDbContext db = new MyDbContext())
            {
                User user = new User
                {
                    Username = textbox1.Text,
                    Password = textbox2.Text,
                };

                db.Users.Add(user);
                db.SaveChanges();
                MessageBox.Show("Регистрация успешна!");
            }
        }

        private void textbox2_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
