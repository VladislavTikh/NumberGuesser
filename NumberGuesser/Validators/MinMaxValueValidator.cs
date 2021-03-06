﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumberGuesser.Validators
{
    /// <summary>
    /// Ensures number in range of min max values
    /// </summary>
    public class MinMaxValueValidator : IValidator<int>
    {
        private int _minValue;
        private int _maxValue;
        public bool IsValid { get; set; }

        public MinMaxValueValidator(int minValue, int maxValue)
        {
            _minValue = minValue;
            _maxValue = maxValue;
        }

        public bool Validate(int value)
        {
            IsValid = true;
            if (value < _minValue)
            {
                Console.WriteLine($"Enter value that is greater than {_minValue}");
                IsValid = false;
            }
            if (value > _maxValue)
            {
                Console.WriteLine($"Enter value that is less than {_maxValue}");
                IsValid = false;
            }
            return IsValid;
        }
    }
}
