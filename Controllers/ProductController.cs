using Microsoft.AspNetCore.Mvc;
using PurchaseApp.Data;
using PurchaseApp.Domain;

namespace PurchaseApp.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductRepository _productRepository;

        public ProductController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public IActionResult Index()
        {
            var products = _productRepository.GetAllProducts();
            return View(products);
        }
        public IActionResult Create()
        {
            return View(); // Return the create view
        }

        [HttpPost]
        public IActionResult Create(Product product)
        {
            if (ModelState.IsValid)
            {
                _productRepository.AddProduct(product); // Add the product to the database
                return RedirectToAction("Index"); // Redirect to the products list
            }
            return View(product); // Return the view with the product data if validation fails
        }
/*        public IActionResult Details(int id)
        {
            var product = _productRepository.GetProductById(id);
            if (product == null)
            {
                return NotFound();
            }
           return View(product); */
        public IActionResult Edit(int id)
        {
            var product = _productRepository.GetProductById(id);
            if (product == null)
            {
                return NotFound();
            }
            return View(product); // Return the edit view with the product data
        }

        [HttpPost]
        public IActionResult Edit(Product product)
        {
            if (ModelState.IsValid)
            {
                _productRepository.UpdateProduct(product); // Update the product in the database
                return RedirectToAction("Index"); // Redirect to the products list
            }
            return View(product); // Return the view with the product data if validation fails
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            _productRepository.DeleteProduct(id); // Delete the product from the database
            return RedirectToAction("Index"); // Redirect to the products list

            // Additional actions for Add, Edit, Delete can be added here
        }
    }
}
