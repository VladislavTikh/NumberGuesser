using NumberGuesser.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumberGuesser
{
    class GameView
    {
        private GameModel model;

        public GameView(GameModel model)
        {
            this.model = model;
            model.StageChanged += InitialStage;
        }
        public void InitialStage()
        {
            Console.Clear();
            Console.WriteLine($"Welcome in NumberGuesser game, {model.player1.Login}! Your should guess the number your opponent prepared for you!");
            Console.WriteLine("Press any key to start");
            Console.ReadKey();
            Console.Clear();
            model.StageChanged -= InitialStage;
            model.StageChanged += GuessingStage;
        }
        public void GuessingStage()
        {
            Console.Clear();
            Console.WriteLine("Press any key to start guessing");
            Console.ReadKey();
            Console.Clear();
            Console.WriteLine($"Your number is between {model.info.MinNumber} and {model.info.MaxNumber} you have {model.info.Attempts} attempts to guess it");
            model.StageChanged -= GuessingStage;
            model.StageChanged += FinalStage;
        }
        public void FinalStage()
        {
            Console.Clear();
            if (model.win)
            {
                Console.WriteLine($"Congrats, you won! {model.info.Attempts - model.attempts} unused attempts left");
            }
            else
                Console.WriteLine($"You spend all attempts, right number was {model.info.GuessedNumber}");
            Console.ReadKey();
            Console.Clear();
            Console.WriteLine("Your updated stats :");
            Console.WriteLine($"Scores: { model.player1.Score}");
            Console.WriteLine($"Level: { model.player1.Level}");
            Console.WriteLine($"Wins: { model.player1.Wins}");
            Console.WriteLine($"Loses: { model.player1.Loses}");
        }
    }
}
