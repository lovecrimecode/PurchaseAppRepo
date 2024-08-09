using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using PurchaseApp.Domain;
using PurchaseApp.Data;

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

        public void AddProduct(Product product)
        {
            _context.Products.Add(product);
            _context.SaveChanges(); // Save changes to the database
        }

        public void UpdateProduct(Product product)
        {
            _context.Products.Update(product);
            _context.SaveChanges(); // Save changes to the database
        }

        public void DeleteProduct(int id)
        {
            var product = _context.Products.Find(id);
            if (product != null)
            {
                _context.Products.Remove(product);
                _context.SaveChanges(); // Save changes to the database
            }
        }
    }
}

