using Microsoft.AspNetCore.Mvc;

namespace PurchaseApp.Controllers
{
    public class HomeController : Controller
    {

        public IActionResult Index()
        {
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Dashboard", "Home");

            }
            else
            {
                // Muestra la vista de inicio de sesi�n/registro si no est� autenticado
                return RedirectToAction("Login", "Account");
            }// Return the Home view
        }

        public IActionResult Privacy()
        {
            return View(); // Return the Privacy view
        }
    }
}