using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumberGuesser.Validators
{
    /// <summary>
    /// Ensures password is valid
    /// </summary>
    class PasswordValidator : IValidator<string>
    {
        public bool IsValid { get; set; }

        private char[] invalidSymbols = { '*', '.', ',', ' ', '/', '.','@','#','&','^', };

        public bool Validate(string value)
        {
            IsValid = true;

            if (value == null || value == string.Empty)
            {
                Console.WriteLine($"Your Password cannot be empty");
                IsValid = false;
            }
            foreach (var symb in invalidSymbols)
                if (value.Contains(symb))
                {
                    IsValid = false;
                    Console.WriteLine($"Your Password shouldn't contain symbols: {string.Join(" ", invalidSymbols)}");
                }
            return IsValid;
        }
    }
}
