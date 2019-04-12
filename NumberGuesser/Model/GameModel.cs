using DataAccess.IRepository;
using DataAccess.Models;
using DataAccess.Repository;
using NumberGuesser.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
[assembly: InternalsVisibleTo("NumberGuesserTest")]
namespace NumberGuesser.Model
{
    public class GameModel
    {
        #region Constructor
        public GameModel(Player player1, GameData data, IPlayerRepository repo)
        {
            this.player1 = player1;
            info = data;
            PlayerRepository = repo;
        }
        #endregion
        private IPlayerRepository PlayerRepository;
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
            StageChanged();
        }
        #region GameStages
        /// <summary>
        /// EndStage stage updates statistics
        /// </summary>
        internal void EndStage()
        {
            player1.Score += info.Attempts - attempts;
            player1.Level = player1.Score / 10;
            if (win)
                player1.Wins++;
            else
                player1.Loses++;
            PlayerRepository.Save(player1);
        }

        private void InitialStage()
        {
           StageChanged();
           info.Initialize();
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
