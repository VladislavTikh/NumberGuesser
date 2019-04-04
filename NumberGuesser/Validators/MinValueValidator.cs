using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumberGuesser.Validators
{
    class MinValueValidator : IValidator<int>
    {
        private int _minValue;
        public bool IsValid { get; set; }

        public MinValueValidator(int minValue)
        {
            _minValue = minValue;
        }

        public bool Validate(int value)
        {
            IsValid = true;
            if (value < _minValue)
            {
                Console.WriteLine($"Enter value that is greater than {_minValue}");
                IsValid = false;
            }
            return IsValid;
        }
    }
}
