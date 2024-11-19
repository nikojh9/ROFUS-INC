using Microsoft.AspNetCore.Mvc;

namespace GamblersDen.Controllers
{
    public class GamesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }



        [HttpGet]
        [Route("/games/Coinflip")]
        public IActionResult Coinflip()
        {
            return View();
        }


    }



}
