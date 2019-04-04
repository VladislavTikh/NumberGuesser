using NumberGuesser.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumberGuesser.Model
{
    class GameData
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
        {
            Initialize();
        }
        #endregion
        /// <summary>
        /// Sets range of numbers to guess and number itself
        /// </summary>
        private void Initialize()
        {
            Console.WriteLine("Enter min number you can guess");
            MinNumber = InputHandler.GetCorrectNumber();
            Console.WriteLine("Enter max number you can guess");
            MaxNumber = InputHandler.GetCorrectNumber(new MinValueValidator(MinNumber));
            Console.WriteLine("Enter you number");
            GuessedNumber = InputHandler.GetCorrectNumber(new MinMaxValueValidator(MinNumber, MaxNumber));
            Attempts = CountAttempts();
        }
        /// <summary>
        /// logN attempts to win in game
        /// </summary>
        /// <returns></returns>
        private int CountAttempts()
        {
            var range = MaxNumber - MinNumber + 1;
            var choices = 2;
            var attempts = 1;
            while (range > choices)
            {
                range /= 2;
                attempts++;
            }
            return attempts;
        }
    }
}
