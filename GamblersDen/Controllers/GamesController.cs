using Microsoft.AspNetCore.Mvc;

namespace GamblersDen.Controllers
{
    public class GamesController : Controller
    {
        [HttpGet]
        [Route("/games/coinflip")]
        public IActionResult Coinflip()
        {
            // Passing the state of the animation (if it's active)
            var flipClass = TempData["FlipClass"]?.ToString() ?? "";
            return View(model: flipClass); // Passing the flip class to the view
        }

        [HttpPost]
        [Route("/games/coinflip")]
        public IActionResult CoinflipPost()
        {
            // Set TempData to trigger the coin flip animation
            TempData["FlipClass"] = "flipping";

            // Redirect to the GET method to reload the page and show the animation
            return RedirectToAction("Coinflip");
        }
    }



}
