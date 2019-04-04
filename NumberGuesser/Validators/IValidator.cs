using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumberGuesser.Validators
{
    /// <summary>
    /// Provides base functionality for validators
    /// </summary>
    /// <typeparam name="T"></typeparam>
    interface IValidator<T>
    {
        bool IsValid { get; set; }
        bool Validate (T value);
    }
}
