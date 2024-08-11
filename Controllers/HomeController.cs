using Microsoft.AspNetCore.Mvc;

namespace PurchaseApp.Controllers
{
    public class HomeController : Controller
    {

        public IActionResult Index()
        {
            return View();// Return the Home view
        }

        public IActionResult Privacy()
        {
            return View(); // Return the Privacy view
        }
    }
}