using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumberGuesser.Validators
{
    class LoginValidator : IValidator<string>
    {
        private char [] invalidSymbols = {'*','.',',',' ','/' };
        public bool IsValid { get; set; }

        public bool Validate(string value)
        {
            IsValid = true;
            if (value == null || value == string.Empty)
            {
                Console.WriteLine($"Your Login cannot be empty");
                IsValid = false;
            }
            foreach (var symb in invalidSymbols)
                if (value.Contains(symb))
                {
                    IsValid = false;
                    Console.WriteLine($"Your Login shouldn't contain symbols: {string.Join(" ", invalidSymbols)}");
                    break;
                }
            return IsValid;
        }
    }
}
