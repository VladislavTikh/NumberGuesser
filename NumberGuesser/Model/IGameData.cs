using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumberGuesser.Model
{
    public interface IGameData
    {
        int Attempts { get; set; }
        int MinNumber { get; set; }
        int MaxNumber { get; set; }
        void Initialize();
        int GuessedNumber { get; set; }
    }
}
