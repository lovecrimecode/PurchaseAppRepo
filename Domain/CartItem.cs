namespace PurchaseApp.Domain
{
    public class CartItem
    {
        public int Id { get; set; }
        public int CartId { get; set; } // Foreign key to Cart
        public int ProductId { get; set; } // Foreign key to Product
        public int Quantity { get; set; }

        public Product Product { get; set; } // Navigation property
        public decimal CalculateSubtotal()
        {
            return Quantity * Product.Price;
        }
    }
}