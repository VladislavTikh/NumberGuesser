using DataAccess.IRepository;
using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    /// <summary>
    /// Repo of players unique
    /// </summary>
    public class PlayerRepository : BaseRepository<Player>,IPlayerRepository
    {
        public PlayerRepository() : base("Players") { }
    }
}
