using Microsoft.Win32;
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
using System.IO;
using Pitpm4.Data;


namespace Pitpm4
{
    /// <summary>
    /// Логика взаимодействия для AddingPage.xaml
    /// </summary>
    public partial class AddingPage : Window
    {
        public AddingPage()
        {
            InitializeComponent();
        }

        private string selectedImagePath;

        private void ChooseImage_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
            {
                selectedImagePath = openFileDialog.FileName;

                BitmapImage bitmap = new BitmapImage();
                bitmap.BeginInit();
                bitmap.UriSource = new Uri(selectedImagePath);
                bitmap.EndInit();
                productImage.Source = bitmap;
            }
        }

        private void AddProduct_Click(object sender, RoutedEventArgs e)
        {
            string name = productNameTextBox.Text;
            string description = productDescriptionTextBox.Text;
            decimal price;
            if (!decimal.TryParse(productPriceTextBox.Text, out price))
            {
                MessageBox.Show("Пожалуйста, введите корректную цену товара.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            byte[] imageBytes = File.ReadAllBytes(selectedImagePath);

            using (MyDbContext db = new MyDbContext())
            {
                Product newProduct = new Product
            {
                Name = name,
                Description = description,
                Price = price,
                Image = imageBytes
            };

                db.Products.Add(newProduct);
                db.SaveChanges();

                MessageBox.Show("Товар успешно добавлен.", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);

                void ClearFields()
                {
                    productNameTextBox.Text = "";
                    productDescriptionTextBox.Text = "";
                    productPriceTextBox.Text = "";
                    productImage.Source = null;
                }

                ClearFields();
            }
        }

        private void BackToMainWindow_Click(object sender, RoutedEventArgs e)
        {
            MainWindow main = new MainWindow();
            this.Close();
            main.Show();
        }


    }
}

