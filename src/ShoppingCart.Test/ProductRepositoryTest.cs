using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using ShoppingCart.DbContexts;
using ShoppingCart.Repositories;
using Xunit;

namespace ShoppingCart.Test
{
    public class ProductRepositoryTest
    {
        [Fact]
        public void GetProduct_PageSizeIsThree_ReturnsThreeProducts()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<CartContext>()
                .UseInMemoryDatabase($"CartDatabaseForTesting{Guid.NewGuid()}")
                .Options;

            using (var context = new CartContext(options))
            {
                context.Products.Add(new Entities.Product()
                {Description = "book", Price = 120.3});
                context.Products.Add(new Entities.Product()
                    {Description = "pencil", Price = 0.5});
                context.Products.Add(new Entities.Product()
                    {Description = "erase", Price = 0.3});
                context.Products.Add(new Entities.Product()
                    {Description = "pen", Price = 10.3});

                context.SaveChanges();
            }

            using (var context = new CartContext(options))
            {
                var productRepository = new ProductRepository(context);

                // Act
                var products = productRepository.GetProducts(1, 3);
                
                // Assert
                Assert.Equal(3, products.Count());
            }
        }
        
        [Fact]
        public void GetProduct_EmptyGuid_ThrowsArgumentException()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<CartContext>()
                .UseInMemoryDatabase($"CartDatabaseForTesting{Guid.NewGuid().ToString()}")
                .Options;

            using (var context = new CartContext(options))
            {
                var productRepository = new ProductRepository(context);

                // Assert
                Assert.Throws<ArgumentException>(
                    // Act      
                    () => productRepository.GetProduct(Guid.Empty));
            }
        }
    }
}