using DataAccess.Models;
using NumberGuesser.Authorizations;
using NumberGuesser.IAuthorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumberGuesser.Authorizations
{

    public class LoginHandler : ILoginHandler
    {
        private IDataAccessKeeper _keeper;
        private int loginTries;

        #region Constructor
        public LoginHandler(IDataAccessKeeper keeper)
        {
            _keeper = keeper;
             loginTries = 3;
        }
        #endregion

        /// <summary>
        /// Get existing player from repo or null if not exist
        /// </summary>
        /// <returns></returns>
        ///

        public Player LogIn(string login, string password)
        {
            Console.Clear();
            var player = _keeper.GetAccount(login, password); 
            loginTries--;
            return player;
        }

        public AccessStatus CheckAccessStatus(Player player)
        {
            AccessStatus status;
            if (loginTries == 0 && player == null)
            {
                Console.WriteLine("You spend all your tries, please create new account.Press key to continute");
                Console.ReadKey();
                status = AccessStatus.Expired;
            }
            else if(player==null)
            {
                Console.WriteLine($"Wrong login or password, try again please. Attempts left: {loginTries}");
                Console.ReadKey();
                status = AccessStatus.Denied;
            }
            else
                status = AccessStatus.Success;
            return status;
        }
    }
}
