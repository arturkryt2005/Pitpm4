using Pitpm4.Data;
using Pitpm4.Models;
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

namespace Pitpm4
{
    /// <summary>
    /// Логика взаимодействия для Edditing.xaml
    /// </summary>
    public partial class Edditing : Window
    {
        private Product _product;

        public Edditing(Product product)
        {
            InitializeComponent();
            _product = product;

            productNameTextBox.Text = _product.Name;
            productDescriptionTextBox.Text = _product.Description;
            productPriceTextBox.Text = _product.Price.ToString();
        }

        private void SaveChanges_Click(object sender, RoutedEventArgs e)
        {
            _product.Name = productNameTextBox.Text;
            _product.Description = productDescriptionTextBox.Text;

            decimal price;
            if (decimal.TryParse(productPriceTextBox.Text, out price))
            {
                _product.Price = price;
            }
            else
            {
                MessageBox.Show("Пожалуйста, введите корректную цену товара.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            using (MyDbContext db = new MyDbContext())
            {
                db.Products.Update(_product);
                db.SaveChanges();
            }

            MessageBox.Show("Изменения успешно сохранены.", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
            Addm addm = new Addm();
            this.Close();
            addm.Show();
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            Addm addm = new Addm();
            this.Close();
            addm.Show();
        }
    }
}
