using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShoppingCart.Entities
{
    [Table("Cart")]
    public class Cart
    {

        public Cart()
        {
            this.CreatedAt=DateTime.Now;
        }
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        public DateTime CreatedAt { get; private set; }

        public ICollection<CartItem> Items { get; set; } = new List<CartItem>();
    }
}