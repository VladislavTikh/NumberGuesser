using DataAccess.Models;
using DataAccess.Repository;
using NumberGuesser.IAuthorization;
using NumberGuesser.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumberGuesser.Authorizations
{   /// <summary>
    /// Provides authentication for user
    /// </summary>
    public class Authorization
    {
        #region Private Members
        private string _login;
        private string _password;
        private IAccountCreator _creator;
        private ILoginHandler _handler;
        #endregion
        #region Constructor
        public Authorization(IAccountCreator creator, ILoginHandler handler)
        {
            _creator = creator;
            _handler = handler;
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
                        FillLoginPassword();          
                        player = _handler.LogIn(_login,_password);
                        if (_handler.CheckAccessStatus(player) ==AccessStatus.Expired)
                        {
                            FillLoginPassword();
                            player = _creator.CreateAccount(_login, _password);
                        }
                        break;
                    case ConsoleKey.D2:
                        FillLoginPassword();
                        if((player = _creator.CreateAccount(_login,_password))==null)
                        {
                            Console.WriteLine("This account already exist, try again");
                            Console.ReadKey();
                        }
                        break;
                    default:
                        break;
                }
            } while (player == null);
            return player;
        }
                       
       private void FillLoginPassword()
        {
            Console.Clear();
            Console.WriteLine("Enter your Login");
            _login = InputHandler.GetCorrectString(new LoginValidator());
            Console.WriteLine("Enter your Password");
            _password = InputHandler.GetCorrectString(new PasswordValidator());
        }
    }
}
