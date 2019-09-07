using System;
using ShoppingCart.DbContexts;
using ShoppingCart.Entities;

namespace ShoppingCart.Repositories
{
    public class CartRepository:IDisposable
    {
        private  readonly CartContext _context;

        public CartRepository(CartContext context)
        {
            this._context = context;
        }

        public void AddCart(Cart cart)=>     
            _context.Carts.Add(cart);
        
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (_context != null)
                {
                    _context.Dispose();
                }
            }
        }
    }
}