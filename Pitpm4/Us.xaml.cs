using Pitpm4.Data;
using Pitpm4.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace Pitpm4
{
    /// <summary>
    /// Логика взаимодействия для Us.xaml
    /// </summary>
    public partial class Us : Window
    {

        public ObservableCollection<Product> Products { get; set; }

        public Us()
        {
            InitializeComponent();
            Products = new ObservableCollection<Product>();
            using (MyDbContext db = new MyDbContext())
            {
                var productsFromDb = db.Products.ToList();
                foreach (var product in productsFromDb)
                {
                    Products.Add(product);
                }
            }
            DataContext = this;
        }

        private void BackToMainWindow_Click(object sender, RoutedEventArgs e)
        {
            MainWindow main = new MainWindow();
            this.Close();
            main.Show();
        }
    }
}
