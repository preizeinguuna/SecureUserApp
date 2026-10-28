using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Collections.Generic;
using SecureUserApp.Models;
using Microsoft.Extensions.Logging;

namespace SecureUserApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        // GET: Home/Index (Registration form view)
        public IActionResult Index()
        {
            return View();
        }

        // POST: Home/Index (Handles user registration submission and validation)
        [HttpPost]
        public IActionResult Index(UserModel model)
        {
            // Check if the input data matches the model annotations ([Required], [EmailAddress], etc.)
            if (!ModelState.IsValid)
            {
                // Return the view with the model so the entered text stays in the input fields
                return View(model);
            }

            // If valid, set success message
            ViewBag.Message = "Input accepted successfully!";
            
            // Return the view with the model so fields and message remain visible
            return View(model);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        // GET: Home/Login
        [HttpGet]
        public IActionResult Login()
        {
            // Return the login view to the browser
            return View();
        }

        // POST: Home/Login
        [HttpPost]
        public async Task<IActionResult> Login(LoginModel model)
        {
            // Validate model state
            if (ModelState.IsValid)
            {
                string role = string.Empty;
                string redirectAction = "Index";
                string redirectController = "Home";

                // Check for admin login credentials
                if (model.Username == "admin" && model.Password == "password123")
                {
                    role = "Admin";
                    redirectAction = "Dashboard";
                    redirectController = "Admin";
                }
                // Check for regular user login credentials
                else if (model.Username == "user" && model.Password == "password123")
                {
                    role = "User";
                    redirectAction = "Index";
                    redirectController = "Home";
                }

                if (!string.IsNullOrEmpty(role))
                {
                    var claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.Name, model.Username),
                        new Claim(ClaimTypes.Role, role) // Assign dynamic role claim (Admin or User)
                    };

                    var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                    // Sign in the user and create the authentication cookie
                    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity));

                    // Redirect based on the assigned role
                    return RedirectToAction(redirectAction, redirectController);
                }

                ModelState.AddModelError("", "Invalid username or password.");
            }

            return View(model);
        }

        // POST: Home/Logout (Handles user sign out and clears authentication cookie)
        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            // Sign out the user and clear the authentication cookie
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            // Redirect to the login page after logging out
            return RedirectToAction("Login", "Home");
        }
    }
}