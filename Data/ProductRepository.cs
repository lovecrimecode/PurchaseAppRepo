using System.Collections.Generic;
using System.Linq;
using PurchaseApp.Domain;
using Microsoft.EntityFrameworkCore;

namespace PurchaseApp.Data
{
    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationDbContext _context;

        public ProductRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Product> GetAllProducts()
        {
            return _context.Products.ToList(); // Fetch all products from the database
        }

        public Product GetProductById(int id)
        {
            return _context.Products.Find(id); // Fetch a specific product by ID
        }
    }
}