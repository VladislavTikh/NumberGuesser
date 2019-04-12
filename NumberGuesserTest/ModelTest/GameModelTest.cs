using DataAccess.IRepository;
using DataAccess.Models;
using DataAccess.Repository;
using Moq;
using NUnit.Framework;
using System.IO;
using NumberGuesser.Model;
using NumberGuesser;

namespace Tests
{
    public class GameModelTest
    {
       private Mock<IPlayerRepository> MockRepo { get; set; }
       private GameModel Game;
       private GameData Info;

        [SetUp]
        public void Setup()
        {
            MockRepo = new Mock<IPlayerRepository>();
            Info = new GameData { MinNumber = 10, MaxNumber = 100, GuessedNumber = 55, Attempts = 5 };
        }

        [Test]
        public void PlayerStatsUpdateAfterGame()
        {
            //arrange
            var playerBeforeGame = new Player();
            var score = playerBeforeGame.Score;
            var loses = playerBeforeGame.Loses;
            Game = new GameModel(playerBeforeGame, Info,MockRepo.Object);
            //act
            Game.EndStage();
            //assert
            Assert.AreNotEqual(score,Game.player1.Score);
            Assert.AreNotEqual(loses, Game.player1.Loses);
            Assert.IsNotNull(Game.player1);
            
        }
 
    }
}