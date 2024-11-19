using Microsoft.AspNetCore.Mvc;

namespace GamblersDen.Controllers
{

    public class GamesController : Controller
    {

        private static Random _random = new Random();
        private static int _currentNumber;


        public IActionResult Index()
        {
            return View();
        }



        [HttpGet]
        [Route("/games/HigherOrLower")]
        public IActionResult HigherOrLower()
        {
            // Initialize a random number for the game.
            int _computerGuess = _random.Next(1, 101);
            int _currentNumber = _random.Next(1, 101);

            //TEMP DATA
            TempData["ComputerGuess"] = _computerGuess;

            ViewBag.ComputerGuess = _computerGuess;
            ViewBag.CurrentNumber = _currentNumber;
            return View();
        }



        [HttpPost]
        [Route("/games/HigherOrLower")]
        public IActionResult HigherOrLower(string choice)
        {
            int nextNumber = _random.Next(1, 101);
            int computerGuess = Convert.ToInt32(TempData["ComputerGuess"]);
            TempData["ComputerGuess"] = computerGuess;

            bool isCorrect = (choice == "Higher" && nextNumber > computerGuess) ||
                             (choice == "Lower" && nextNumber < computerGuess);

            ViewBag.Result = isCorrect ? "Correct!" : "Wrong!";
            ViewBag.CurrentNumber = nextNumber;
            
            _currentNumber = nextNumber; // Update current number for next round

            
            ViewBag.ComputerGuess = computerGuess;
            return View();
        }

    }



}
