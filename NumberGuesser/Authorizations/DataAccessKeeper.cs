using DataAccess.Models;
using DataAccess.Repository;
using NumberGuesser.IAuthorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumberGuesser.Authorizations
{
    public class DataAccessKeeper:IDataAccessKeeper
    {
        #region Private Members
        private PlayerRepository Base;
        private PlayersCountRepository UniquePlayers;
        private List<Player> Players;
        #endregion
        #region Constructor
        public DataAccessKeeper()
        {
            Base = new PlayerRepository();
            UniquePlayers = new PlayersCountRepository();
            Players = LoadAllPlayers();
        }
        #endregion

        public int GetPlayersCount() => UniquePlayers?.Get(0).Count ?? new PlayersCount { ID = 0, Count = 0 }.Count;
      
        /// <summary>
        /// Get account from repo
        /// </summary>
        /// <param name="login"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        /// 
        public Player GetAccount(string login, string password)
        {
            return Players.Where(x => x != null).SingleOrDefault(x => x.Password == password && x.Login == login);
        }

        public void UpdatePlayersCount(int count)=>
            UniquePlayers.Save(new PlayersCount { ID = 0, Count = count });

        private List<Player> LoadAllPlayers()
        {
            var players = new List<Player>();
            for(var i=0;i<GetPlayersCount();i++)
                players.Add(Base.Get(i));
            return players;
        }
    }
}
