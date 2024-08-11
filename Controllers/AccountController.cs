using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PurchaseApp.Domain;
using PurchaseApp.Models; // Ensure you have the correct namespace for your model
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace PurchaseApp.Controllers
{
    public class AccountController : Controller
    {
        private readonly SignInManager<User> _signInManager;
        private readonly UserManager<User> _userManager;
        private readonly ILogger<AccountController> _logger;
        public AccountController(SignInManager<User> signInManager, UserManager<User> userManager, ILogger<AccountController> logger) // Inject UserManager
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _logger = logger;// Assign the injected UserManager
        }

        #region Login
        // GET: /Account/Login
        [HttpGet]
        public IActionResult Login()
        {
            _logger.LogInformation("Navigated to the Login page.");
            return View();
        }

        // POST: /Account/Login
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginModel model)
        {
                _logger.LogInformation("Attempting login for user {Username}.", model.Username);
                var result = await _signInManager.PasswordSignInAsync(model.Username, model.Password, isPersistent: false, lockoutOnFailure: false);

                    _logger.LogInformation("User {Username} logged in successfully.", model.Username);
                    return RedirectToAction("Index", "Home");
             
            return View(model);
        }
        #endregion

        #region Logout
        // GET: /Account/Logout
        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            _logger.LogInformation("User logged out.");
            return RedirectToAction("Index", "Home"); // Redirect to home page after logout
        }
        #endregion

        #region Registration
        [HttpGet]
        public IActionResult Register()
        {
            _logger.LogInformation("Navigated to the Registration page.");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterModel model)
        {

                var user = new User { UserName = model.Username };
                _logger.LogInformation("Attempting to register user {Username}.", model.Username);
                var result = await _userManager.CreateAsync(user, model.Password);


                    _logger.LogInformation("User {Username} registered successfully.", model.Username);
                    await _signInManager.SignInAsync(user, isPersistent: false);
                    return RedirectToAction("Index", "Home");

            return View(model);
        }
        #endregion
    }
    
}