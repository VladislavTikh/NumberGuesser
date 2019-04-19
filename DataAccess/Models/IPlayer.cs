using DataAcces.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Models
{
    public interface IPlayer
    {
        string Login { get; set; }
        int Score { get; set; }
        int Level { get; set; }
        int Wins { get; set; }
        int Loses { get; set; }
    }
}
