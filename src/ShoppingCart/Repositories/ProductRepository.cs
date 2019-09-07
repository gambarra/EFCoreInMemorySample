using System;
using System.Collections.Generic;
using System.Linq;
using ShoppingCart.DbContexts;
using ShoppingCart.Entities;

namespace ShoppingCart.Repositories
{
    public class ProductRepository
    {
        private  readonly CartContext _context;

        public ProductRepository(CartContext context)
        {
            this._context = context;
        }

        
        public IEnumerable<Product> GetProducts() 
        { 
            return _context.Products.ToList();
        }
        public void AddProduct(Product product)=>     
            _context.Products.Add(product);
        
        public IEnumerable<Product> GetProducts(int pageNumber = 1, int pageSize = 5)=>
             _context.Products.Skip((pageNumber-1) * pageSize).Take(pageSize).ToList();
        
        public Product GetProduct(Guid productId)
        {
            if (productId == Guid.Empty)
                throw new ArgumentException(nameof(productId));         

            return _context.Products.FirstOrDefault(a => a.Id == productId);
        }
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