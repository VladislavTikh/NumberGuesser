using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumberGuesser.Validators
{
    class StringValidator : IValidator<string>
    {
        private int _number;

        public int getNumber() => _number;

        public bool IsValid { get; set; }

        public bool Validate(string value)
        {
            return IsValid =int.TryParse(value, out _number);
        }
    }
}
