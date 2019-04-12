using NumberGuesser.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumberGuesser
{
    class InputHandler
    {
        /// <summary>
        /// get correct number depending on validator
        /// </summary>
        /// <param name="validator"></param>
        /// <returns></returns>
        public static int GetCorrectNumber(IValidator<int> validator = null)
        {
            var stringValidator = new StringValidator();
            do
            {
                var line = Console.ReadLine();
                while (!stringValidator.Validate(line))
                {
                    Console.WriteLine($"'{line}' it is not a number. Please enter number");
                    line = Console.ReadLine();
                }

            } while (!validator?.Validate(stringValidator.getNumber()) ?? false);
            return stringValidator.getNumber();
        }
        /// <summary>
        /// correct string depending on validator
        /// </summary>
        /// <param name="validator"></param>
        /// <returns></returns>
        public static string GetCorrectString(IValidator<string> validator = null)
        {
            string line;
            do
            {
                line = Console.ReadLine();
            } while (!validator?.Validate(line) ?? false);
            return line;
        }
    }
}
