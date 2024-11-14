using Microsoft.AspNetCore.Mvc;

namespace GamblersDen.Controllers
{

    [Route("[controller]")]
    public class LoginController : Controller
    {
        
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string username, string password)
        {
            // Simple login check - replace with actual authentication logic
            if (username == "admin" && password == "password")
            {
                HttpContext.Session.SetString("IsLoggedIn", "true"); // Set session
                return RedirectToAction("Index", "Home"); // Redirect to a home page after login
            }

            ViewBag.ErrorMessage = "Invalid username or password";
            return View();
        }

    }
}
