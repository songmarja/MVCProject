using Microsoft.AspNetCore.Mvc;
using MVCProject.Models;
using System.Diagnostics;

namespace MVCProject.Controllers
{
    public class GameController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult GuessingGame()
        {
            // Is there any available
            string? rndStringNumber = HttpContext.Session.GetString("rndStringNumber");
            
            // No session is set
            if (rndStringNumber == null)
            {
                HttpContext.Session.SetString("rndStringNumber", GameModel.CreateRandomNumber());
            }
            //ViewBag.Message = HttpContext.Session.GetString("rndStringNumber");

            // Adds session for counter
            int? counter = HttpContext.Session.GetInt32("countedNum");

            // No session is set => Set session for counter
            if (counter == null)
            {
                HttpContext.Session.SetInt32("countedNum", 0);
            }
            return View();
        }


        [HttpPost]
        public IActionResult GuessingGame(string input)
        {
            bool foundTheNum;

            // Check if The guess counter remains
            int? counter = HttpContext.Session.GetInt32("countedNum");
            // If no session, create one..
            if (counter == null)
            {
                HttpContext.Session.SetInt32("countedNum", 0);
                counter = 0;
            }
            else
            {
                counter += 1;
                Debug.WriteLine(counter);
            }
           
            if (!String.IsNullOrEmpty(input))
            {
                string? rndStringNumber = HttpContext.Session.GetString("rndStringNumber");
               
                if(rndStringNumber != null)
                {
                    ViewBag.Message = GameModel.GuessTheNumber(input, rndStringNumber, out foundTheNum);
                    ViewBag.Message += $"  Guesses: {counter} times";
                    HttpContext.Session.SetInt32("countedNum", (int)counter);
                    // The game is finished. New random and new counter needed
                    if (foundTheNum == true)
                    {
                        HttpContext.Session.SetString("rndStringNumber", GameModel.CreateRandomNumber());
                        HttpContext.Session.SetInt32("countedNum", 0);
                        ViewBag.NewGame = true;
                    }
                }
                else
                {
                    // If rndString is null => the session has ended. Creates a new session and random number
                    HttpContext.Session.SetString("rndStringNumber", GameModel.CreateRandomNumber());
                    HttpContext.Session.SetInt32("countedNum", 0);

                    ViewBag.Message = $"Your time ran out. We start a new game for you";
                }
            }
            return View();
        }
    }
}
