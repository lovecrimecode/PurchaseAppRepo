//using PurchaseApp.Models;
using System.Collections.Generic;
namespace PurchaseApp.Domain
{
    public class CartItem
    {
        public int Id { get; set; }
        //public int UserId { get; set; }
        public int CartId { get; set; } // Foreign key to Cart
        public int ProductId { get; set; } // Foreign key to Product
        public int Quantity { get; set; }
        public Product Product { get; set; }
    }
}
