namespace PurchaseApp.Domain
{
    public class Product
    {
            public int Id { get; set; }
            public string Name { get; set; }
            public decimal Price { get; set; }
            public string Description { get; set; }
/*
            public static List<Product> GetProducts()
            {
                return new List<Product>
            {
                new Product { Id = 1, Name = "Product A", Price = 10.00m, Description = "Description A" },
                new Product { Id = 2, Name = "Product B", Price = 15.00m, Description = "Description B" }
            }; */
    }
}
