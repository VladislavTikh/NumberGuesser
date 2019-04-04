using DataAccess.Models;
using DataAccess.Repository;
using NumberGuesser.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumberGuesser.Model
{
    class GameModel
    {
        #region Constructor
        public GameModel(Player player1)
        {
            this.player1 = player1;
        }
        #endregion
        #region Public Properties
        public Player player1 {get;private set;}
        public delegate void UI();
        public event UI StageChanged;
        public GameData info { get; private set; }
        public bool win { get; private set; } = false;
        public int attempts { get; private set; }
        #endregion
        public void PlayGame()
        {
            InitialStage();
            GuessStage();
            EndStage();
        }
        #region GameStages
        /// <summary>
        /// EndStage stage updates statistics
        /// </summary>
        private void EndStage()
        {
            var repo = new PlayerRepository();
            player1.Score += info.Attempts - attempts;
            player1.Level = player1.Score / 10;
            if (win)
                player1.Wins++;
            else
                player1.Loses++;
            repo.Save(player1);
            StageChanged();
        }

        private void InitialStage()
        {
            StageChanged();
           info = new GameData();
        }
        /// <summary>
        /// Guess the number
        /// </summary>
        private void GuessStage()
        {
            StageChanged();         
            attempts = 0;
            int number;
            do
            {
                Console.WriteLine($"Attempt {++attempts} / {info.Attempts}. Min :{info.MinNumber} Max :{info.MaxNumber}");
                number = InputHandler.GetCorrectNumber(new MinMaxValueValidator(info.MinNumber, info.MaxNumber));
                if (number > info.GuessedNumber)
                {
                    Console.WriteLine($"{number} > guessed number");
                    info.MaxNumber = number;
                }
                if (number < info.GuessedNumber)
                {
                    Console.WriteLine($"{number} < guessed number");
                    info.MinNumber = number;
                }
                if (number == info.GuessedNumber)
                {
                    win = true;
                }
            } while (!win && attempts < info.Attempts);
        }
        #endregion
    }
}
