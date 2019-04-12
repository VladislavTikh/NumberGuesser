using NumberGuesser.Model;
using System;
using DataAccess.Models;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Repository;
using NumberGuesser.Authorizations;

namespace NumberGuesser
{
    class Application
    {
        static void Main(string[] args)
        {
            var dac = new DataAccessKeeper();
            var auto = new Authorization(new AccountCreator(dac),new LoginHandler(dac));
            var player = auto.Authorize();
            var gameInfo = new GameData();
            var game = new GameModel(player,gameInfo,new PlayerRepository());
            var view = new GameView(game);
            game.PlayGame();
            Console.ReadKey();
        }
    }
}
