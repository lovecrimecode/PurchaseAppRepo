using Microsoft.AspNetCore.Mvc;
using PurchaseApp.Data;
using PurchaseApp.Domain;
//using System.Linq;

namespace PurchaseApp.Controllers
{
    public class CartController : Controller
    {
        private readonly IProductRepository _productRepository;
        private static Cart _cart = new Cart(); // This should ideally be stored in session or database

        public CartController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public IActionResult Index()
        {
            return View(_cart); // Pass the cart to the view
        }

        [HttpPost]
        public IActionResult AddToCart(int productId, int quantity)
        {
            var product = _productRepository.GetProductById(productId);
            if (product != null)
            {
                _cart.AddProduct(product, quantity);
            }
            return RedirectToAction("Index", "Product");
        }

        [HttpPost]
        public IActionResult RemoveFromCart(int productId)
        {
            _cart.RemoveProduct(productId);
            return RedirectToAction("Index");
        }

        // POST: /Cart/Checkout
        [HttpPost]
        public IActionResult Checkout()
        {
            // Handle checkout logic here (e.g., create an order, save to database)
            // For now, just clear the cart and redirect to the home page
            _cart = new Cart(); // Clear the cart
            return RedirectToAction("Index", "Home"); // Redirect to home or confirmation page
        }
    }
}
