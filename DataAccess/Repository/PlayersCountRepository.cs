using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    /// <summary>
    /// Number of unique players 
    /// </summary>
    public class PlayersCountRepository : BaseRepository<PlayersCount>
    {
        public PlayersCountRepository() : base("PlayersCount")
        {}
    }
}
