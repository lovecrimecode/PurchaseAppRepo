namespace PurchaseApp.Domain
{
    public class Order
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public DateTime Date { get; set; }
        public decimal Total { get; set; }
        public string Status { get; set; }
        public List<CartItem> Items { get; set; } = new List<CartItem>();
        public void CreateOrder(Cart cart)
        {
            //revisar si dejar el this
            this.Date = DateTime.Now;
            this.Total = cart.CalculateTotal();
            this.Status = "Pending";
        }
       /* foreach (var item in cart.Items)
            {
                Items.Add(new OrderItem
                {
                    ProductId = item.ProductId,
                    Quantity = item.Quantity
    });*/
       //implementar items a la orden
    }
}