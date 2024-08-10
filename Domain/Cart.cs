using System.Collections.Generic;
using System.Linq;

namespace PurchaseApp.Domain
{
    public class Cart
    {
        public int Id { get; set; }
        public List<CartItem> Items { get; set; } = new List<CartItem>();

        public void AddProduct(Product product, int quantity)
        {
            var existingItem = Items.FirstOrDefault(i => i.ProductId == product.Id);
            if (existingItem != null)
            {
                existingItem.Quantity += quantity; // Update quantity if product already in cart
            }
            else
            {
                var cartItem = new CartItem { ProductId = product.Id, Quantity = quantity, Product = product };
                Items.Add(cartItem); // Add new product to cart
            }
        }

        public void RemoveProduct(int productId)
        {
            var item = Items.FirstOrDefault(i => i.ProductId == productId);
            if (item != null)
            {
                Items.Remove(item); // Remove product from cart
            }
        }

        public decimal CalculateTotal()
        {
            return Items.Sum(item => item.Quantity * item.Product.Price); // Calculate total price
        }
    }
}
/*The Sum method calculates the total by iterating over each CartItem 
 * in the Items list, multiplying the Quantity of each item by its 
 * associated Product's Price, and summing up the results.*/