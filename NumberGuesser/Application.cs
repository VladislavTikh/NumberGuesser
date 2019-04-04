using NumberGuesser.Model;
using System;
using DataAccess.Models;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Repository;

namespace NumberGuesser
{
    class Application
    {
        static void Main(string[] args)
        {
            Player player;
            var auto = new Authorization();
            player = auto.Authorize();
            var game = new GameModel(player);
            var view = new GameView(game);
            game.PlayGame();
            Console.ReadKey();
        }
    }
}
