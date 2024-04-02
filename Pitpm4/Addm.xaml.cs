using Pitpm4.Data;
using Pitpm4.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using System.Linq;

namespace Pitpm4
{
    /// <summary>
    /// Логика взаимодействия для Addm.xaml
    /// </summary>
    public partial class Addm : Window
    {

        public ObservableCollection<Product> Products { get; set; }

        public Addm()
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

        private void AddProduct_Click(object sender, RoutedEventArgs e)
        {
            AddingPage adin = new AddingPage();
            this.Hide();
            adin.Show();
        }

        private void BackToMainWindow_Click(object sender, RoutedEventArgs e)
        {
            MainWindow main = new MainWindow();
            this.Close();
            main.Show();
        }

        private void ProductListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void DeleteProduct_Click(object sender, RoutedEventArgs e)
        {
            List<Product> selectedProducts = ProductListBox.SelectedItems.Cast<Product>().ToList();
            if (selectedProducts.Count == 0)
            {
                MessageBox.Show("Выберите товары для удаления.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            MessageBoxResult result = MessageBox.Show("Вы уверены, что хотите удалить выбранные товары?", "Подтверждение удаления", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                using (MyDbContext db = new MyDbContext())
                {
                    db.Products.RemoveRange(selectedProducts);
                    db.SaveChanges();
                }
                MessageBox.Show("Товары успешно удалены.", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void EditProduct_Click(object sender, RoutedEventArgs e)
        {
            Product selectedProduct = (Product)ProductListBox.SelectedItem;
            if (selectedProduct != null)
            {
                Edditing editt = new Edditing(selectedProduct);
                this.Close();
                editt.Show();
            }
            else
            {
                MessageBox.Show("Выберите товар для редактирования.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
