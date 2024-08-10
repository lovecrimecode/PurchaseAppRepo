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
        public IActionResult Checkout()
        {
            return View(_cart); // Pass the cart to the checkout view
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
        [HttpPost]
        public IActionResult Pay()
        {
            // Here, you would typically process the payment.
            // For this example, we will just clear the cart and show a thank you message.
            _cart = new Cart(); // Clear the cart
            return RedirectToAction("ThankYou"); // Redirect to the thank you page
        }

        // GET: /Cart/ThankYou
        public IActionResult ThankYou()
        {
            return View(); // Return the thank you view
        }
    }
}
