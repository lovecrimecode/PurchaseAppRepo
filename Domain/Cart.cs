//using PurchaseApp.Models;

namespace PurchaseApp.Domain
{
    public class Cart
    {
        public int Id { get; set; }
        //public int UserId { get; set; }
        public List<CartItem> Items { get; set; } = new List<CartItem>();

        public void AddProduct(Product product, int quantity)
        {
            var cartItem = new CartItem { ProductId = product.Id, Quantity = quantity, Product = product };
            Items.Add(cartItem);
        }
        public void RemoveProduct(int productId)
        {
            var item = Items.FirstOrDefault(i => i.ProductId == productId);
            if (item != null)
            {
                Items.Remove(item);
            }
        }
        public decimal CalculateTotal()
        {
            /*The Sum method calculates the total by iterating over each CartItem 
             * in the Items list, multiplying the Quantity of each item by its 
             * associated Product's Price, and summing up the results.*/
            return Items.Sum(item => item.Quantity * item.Product.Price);
        }
    }

}
