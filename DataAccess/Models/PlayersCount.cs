using DataAcces.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Models
{
    /// <summary>
    /// Keeps current count of unique players
    /// </summary>
    public class PlayersCount : BaseModel
    {
        public int Count { get; set; }
    }
}
