using Microsoft.AspNetCore.Mvc;
using PurchaseApp.Data; // Ensure you have the correct namespace for your repository
using PurchaseApp.Domain; // Ensure you import the domain namespace

namespace PurchaseApp.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductRepository _productRepository;

        public ProductController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        // GET: /Product
        public IActionResult Index()
        {
            var products = _productRepository.GetAllProducts(); // Fetch all products
            return View(products); // Pass the products to the view
        }

        // GET: /Product/Details/5
        public IActionResult Details(int id)
        {
            var product = _productRepository.GetProductById(id);
            if (product == null)
            {
                return NotFound(); // Return 404 if product not found
            }
            return View(product); // Return the details view for the product
        }
    }
}