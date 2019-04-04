using DataAccess.Models;
using DataAccess.Repository;
using NumberGuesser.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumberGuesser
{   /// <summary>
    /// Provides authentication for user
    /// </summary>
    public class Authorization
    {
        #region Private Members
        private PlayerRepository Base;
        private PlayersCountRepository UniquePlayers;
        private List<Player>Players;
        private string _login;
        private string _password;
        #endregion
        #region Constructor
        public Authorization()
        {
            Base = new PlayerRepository();
            UniquePlayers = new PlayersCountRepository();
            Players = new List<Player>();
            for (var i = 0; i < GetPlayersCount().Count; i++)
                Players.Add(Base.Get(i));
        }
        #endregion
        public Player Authorize()
        {
            Player player = null;
            do
            {
                Console.Clear();
                Console.WriteLine("Do you already have a profile?");
                Console.WriteLine("1.Log in");
                Console.WriteLine("2.Create account");
                switch (Console.ReadKey().Key)
                {
                    case ConsoleKey.D1:
                        player = LogIn();
                        break;
                    case ConsoleKey.D2:
                        player = CreateAcc();
                        break;
                    default:
                        break;
                }
            } while (player == null);
            return player;
        }
        /// <summary>
        /// Add new entity in players repo
        /// </summary>
        /// <returns></returns>
        private Player CreateAcc()
        {
            Console.Clear();
            while (GetExistingAcc() != null)
                Console.WriteLine("This account already exist, try again");
            var playerInfo = GetPlayersCount(); 
            var newID = playerInfo.Count++;
            UniquePlayers.Save(playerInfo);
            return new Player { ID = newID, Score = 0, Login = _login, Password = _password, Level = 0, Wins=0, Loses=0 };
        }
        /// <summary>
        /// Get existing player from repo
        /// </summary>
        /// <returns></returns>
        private Player LogIn()
        {
            Console.Clear();
            Player player = null;
            var loginTries = 3;
            while (loginTries-- >0  && player==null)
            {
                if ((player = GetExistingAcc()) == null)
                    Console.WriteLine("Wrong login or password");
            }
            if (player == null)
            {
                Console.WriteLine("You spend all your tries, please create new account.Press key to continute");
                Console.ReadKey();
            }
            return player ?? CreateAcc();
        }
        private PlayersCount GetPlayersCount() => UniquePlayers?.Get(0) ?? new PlayersCount { ID = 0, Count = 0 };
        /// <summary>
        /// Get account from repo
        /// </summary>
        /// <param name="login"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        private Player GetAccount(string login, string password)
        {
            return Players.Where(x=>x!=null).SingleOrDefault(x => x.Password == password && x.Login == login);          
        }
        private Player GetExistingAcc()
        {
            Console.WriteLine("Enter your Login");
            _login = InputHandler.GetCorrectString(new LoginValidator());
            Console.WriteLine("Enter your Password");
            _password = InputHandler.GetCorrectString(new PasswordValidator());
            return GetAccount(_login, _password);
        }
    }
}
