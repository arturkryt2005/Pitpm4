using Pitpm4;
using Pitpm4.Data;
using Pitpm4.Models;
using static Pitpm4.AddingPage;
namespace TestProject5
{
        [TestClass]
        public class ProductManagerTests
        {
            [TestMethod]
            public void AddProduct_ValidData_ProductAddedSuccessfully()
            {
                // Arrange
                ProductManager productManager = new ProductManager();
                string name = "Test Product";
                string description = "Test Description";
                decimal price = 10.99m;
                byte[] imageBytes = new byte[] { 0x00, 0x01, 0x02 }; 

                // Act
                productManager.AddProduct(name, description, price, imageBytes);

                // Assert
                using (MyDbContext db = new MyDbContext())
                {
                    Product addedProduct = db.Products.FirstOrDefault(p => p.Name == name);
                    Assert.IsNotNull(addedProduct);
                    Assert.AreEqual(name, addedProduct.Name);
                    Assert.AreEqual(description, addedProduct.Description);
                    Assert.AreEqual(price, addedProduct.Price);
                    CollectionAssert.AreEqual(imageBytes, addedProduct.Image);
                }
            }
      }
  }
