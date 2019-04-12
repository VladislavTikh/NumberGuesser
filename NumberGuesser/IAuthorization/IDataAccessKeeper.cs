using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumberGuesser.IAuthorization
{
    public interface IDataAccessKeeper
    {
        Player GetAccount(string login, string password);
        int GetPlayersCount();
        void UpdatePlayersCount(int count);
    }
}
