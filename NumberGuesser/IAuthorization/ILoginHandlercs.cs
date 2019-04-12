using DataAccess.Models;
using NumberGuesser.Authorizations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumberGuesser.IAuthorization
{
    public interface ILoginHandler
    {
        Player LogIn(string login, string password);
        AccessStatus CheckAccessStatus(Player player);
    }
}
