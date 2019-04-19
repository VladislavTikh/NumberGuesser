using NumberGuesser.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumberGuesser.Model
{
    public class GameData:IGameData
    {
        #region Public Properties
        /// <summary>
        /// public properties
        /// </summary>
        public int Attempts { get;  set; }
        public int MinNumber { get; set; }
        public int MaxNumber { get; set; }
        public int GuessedNumber { get; set; }
        #endregion
        #region Constructor
        public GameData()
        {        }
        #endregion
        /// <summary>
        /// Sets range of numbers to guess and number itself
        /// </summary>
        public void Initialize()
        {
            Console.WriteLine("Enter min number you can guess");
            MinNumber = InputHandler.GetCorrectNumber();
            Console.WriteLine("Enter max number you can guess");
            MaxNumber = InputHandler.GetCorrectNumber(new MinValueValidator(MinNumber));
            Console.WriteLine("Enter you number");
            GuessedNumber = InputHandler.GetCorrectNumber(new MinMaxValueValidator(MinNumber, MaxNumber));
            Attempts = CountAttempts(MaxNumber,MinNumber);
        }
        /// <summary>
        /// logN attempts to win in game
        /// </summary>
        /// <returns></returns>
        internal int CountAttempts(int maxNumber, int minNumber)
        {
            var range = maxNumber - minNumber + 1;
            var choices = 2;
            var attempts = 1;
            while (range > choices)
            {
                choices *= 2;
                attempts++;
            }
            return attempts;
        }
    }
}
