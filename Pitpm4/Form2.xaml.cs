using Microsoft.Data.SqlClient.Server;
using Pitpm4.Data;
using System.Windows;
using Pitpm4.Models;

namespace Pitpm4
{
    /// <summary>
    /// Логика взаимодействия для Form2.xaml
    /// </summary>
    public partial class Form2 : Window
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            using (MyDbContext db = new MyDbContext())
            {
                foreach (User user in db.Users)
                {
                    if (textbox1.Text == user.Username && textbox2.Text == user.Password)
                    {
                        if (checkBox1.IsChecked == false)
                        {
                            MessageBox.Show("Вход успешен!");
                            Us userForm = new Us();
                            userForm.Show();
                            this.Visibility = Visibility.Collapsed;
                            return;
                        }
                    }
                }
                    foreach (Admin admin in db.Admins)
                    {
                        if (textbox1.Text == admin.Username && textbox2.Text == admin.Password)
                        {
                            if (checkBox1.IsChecked == true)
                            {
                                MessageBox.Show("Вход успешен!");
                                Addm adminform = new Addm();
                                adminform.Show();
                                this.Visibility = Visibility.Collapsed;
                                return;
                            }
                        }
                    }
                MessageBox.Show("Логин или пароль указан неверно!");         
            }            
        }
    }
}
