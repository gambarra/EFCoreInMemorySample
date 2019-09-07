using Microsoft.EntityFrameworkCore;
using ShoppingCart.Entities;

namespace ShoppingCart.DbContexts
{
    public class CartContext :DbContext
    {
        
        public DbSet<Product> Products { get; set; }

        public DbSet<Cart> Carts { get; set; }

        public DbSet<CartItem> CartItems { get; set; }

        public CartContext()
        { }

        public CartContext(DbContextOptions<CartContext> options)
            : base(options)
        {
        }
    }
}