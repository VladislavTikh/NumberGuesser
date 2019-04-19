using DataAccess.Models;
using NumberGuesser.Authorizations;
using NumberGuesser.IAuthorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumberGuesser
{
    public class AccountCreator : IAccountCreator
    {
        private IDataAccessKeeper _keeper;

        public AccountCreator(IDataAccessKeeper keeper) => _keeper = keeper;

        /// <summary>
        /// Create new unique entity
        /// </summary>
        /// <returns></returns>
        public Player CreateAccount(string login, string password)
        {
            Player createdPlayer;
            Console.Clear();
            if (_keeper.GetAccount(login, password) != null)
                createdPlayer = null;
            else
            {
                var playerInfo = _keeper.GetPlayersCount();
                var newID = ++playerInfo;
                createdPlayer = new Player
                {
                    ID = newID,
                    Score = 0,
                    Login = login,
                    Password = password,
                    Level = 0,
                    Wins = 0,
                    Loses = 0
                };
                _keeper.UpdatePlayersCount(playerInfo);
            }
            return createdPlayer;
        }
    }
}
