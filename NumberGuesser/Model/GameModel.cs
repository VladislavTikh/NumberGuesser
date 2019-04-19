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
        public GameModel(IPlayer player1, IPlayerRepository repo, IGameData data)
        {
            this.player1 = player1;
            PlayerRepository = repo;
            info = data;
        }
        #endregion
        private IPlayerRepository PlayerRepository;
        #region Public Properties
        public IPlayer player1 { get; private set; }
        public delegate void UI();
        public event UI StageChanged;
        public IGameData info { get; private set; }
        public bool win { get; internal set; } = false;
        public int attempts { get; internal set; }
        #endregion
        public void PlayGame()
        {
            InitialStage();
            StageChanged();
            GuessStage();
            EndStage(info.Attempts);
            StageChanged();
        }
        #region GameStages
        /// <summary>
        /// EndStage stage updates statistics
        /// </summary>
        internal void EndStage(int Attempts)
        {
            player1.Score += Attempts - attempts;
            player1.Level = player1.Score / 10;
            if (win)
                player1.Wins++;
            else
                player1.Loses++;
            PlayerRepository.Save(player1 as Player);
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
            attempts = 0;
            do
            {
                Console.WriteLine($"Attempt {++attempts} / {info.Attempts}. Min :{info.MinNumber} Max :{info.MaxNumber}");
                NumberAnalysis(
                    InputHandler.GetCorrectNumber
                    (new MinMaxValueValidator(info.MinNumber, info.MaxNumber)));

            } while (!win && attempts < info.Attempts);
        }
        #endregion
        internal void NumberAnalysis(int num)
        {
            if (num > info.GuessedNumber)
            {
                Console.WriteLine($"{num} > guessed number");
                info.MaxNumber = num;
            }
            if (num < info.GuessedNumber)
            {
                Console.WriteLine($"{num} < guessed number");
                info.MinNumber = num;
            }
            if (num == info.GuessedNumber)
            {
                win = true;
            }
        }
    }
}
