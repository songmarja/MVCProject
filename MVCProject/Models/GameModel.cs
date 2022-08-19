using System.Diagnostics;

namespace MVCProject.Models
{
    public class GameModel
    {
        ///It takes in the input value from user and the created random value. <summary>
        /// It takes in the input value from user and the created random value.
        /// The method compare the parameter values and returns a message if the guess is too high, too low or is the right one.
        /// </summary>
        /// <param name="inputString"></param>
        /// <param name="rndStringNumber"></param>
        /// <returns></returns>
        public static string GuessTheNumber(string inputString, string rndStringNumber, out bool foundTheNum)
        {
            Debug.WriteLine(rndStringNumber);
            //Convert the random string to a number
            int rnd = int.Parse(rndStringNumber);
          
            // Checking the input, if string or int
            bool isNum = int.TryParse(inputString, out int inputNum);

            if (!isNum)
            {
                foundTheNum = false;
                return ($"Hmm, that doesn't look like a number. Try again.\nWhat's your guess?");
            }
            else
            {
                if (inputNum < rnd)
                {
                    foundTheNum = false;
                    return "Nope. Higher than that.";

                }
                if (inputNum > rnd)
                {
                    foundTheNum = false;
                    return ("Nope. Lower than that.");
                }
                else
                // (inputNum == rnd)
                {
                    foundTheNum = true;
                    return "CONGRATULATION! YOU'VE FOUND IT!";
                }
            }
        }
        /// <summary>
        /// Creates the random number for the game
        /// </summary>
        /// <returns>Random number, like string</returns>
        internal static string CreateRandomNumber()
        {
            var rnd = new Random();
            int number = rnd.Next(1, 101);
            return number.ToString();
        }
    }
}
