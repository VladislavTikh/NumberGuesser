using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumberGuesser.IAuthorization
{
    public interface IAccountCreator
    {
        Player CreateAccount(string login, string password);
    }
}
