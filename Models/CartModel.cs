/*namespace PurchaseApp.Models
{
    public class Cart
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public List<CartItem> Items { get; set; } = new List<CartItem>();

    public void AddProduct(Product product, int quantity)
    {
        var cartItem = new CartItem { ProductId = product.Id, Quantity = quantity };
        Items.Add(cartItem);
    }

    public decimal CalculateTotal()
    {
        decimal total = 0;
        foreach (var item in Items)
        {
            var product = Product.GetProducts().FirstOrDefault(p => p.Id == item.ProductId);
            if (product != null)
            {
                total += product.Price * item.Quantity;
            }
        }
        return total;
    }
}
}*/