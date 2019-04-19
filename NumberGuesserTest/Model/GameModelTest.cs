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
        private Mock<IGameData> MockGameData;
        private Mock<IPlayer> MockPlayer;


        [SetUp]
        public void Setup()
        {
            MockRepo = new Mock<IPlayerRepository>();
            MockGameData = new Mock<IGameData>();
            MockPlayer = new Mock<IPlayer>();
            Game = new GameModel(MockPlayer.Object, MockRepo.Object, MockGameData.Object);
        }

        [Test]
        [TestCase(10, 8, 0, 2)]
        [TestCase(10, 8, 12, 14)]
        [TestCase(0, 5, 5, 0)]
        [TestCase(10, 5, -3, 2)]
        public void PlayerStatsUpdateAfterGame(int attempts, int usedAttempts, int playerScore, int updatedScore)
        {
            //arrange
            Game.attempts = usedAttempts;
            MockPlayer.SetupProperty(x => x.Score);
            MockPlayer.Object.Score = playerScore;
            //act
            Game.EndStage(attempts);
            //assert
            Assert.AreEqual(Game.player1.Score, updatedScore);
        }
        [Test]
        [TestCase(10, 7, 10)]
        [TestCase(12, 8, 12)]
        [TestCase(100, 0, 100)]
        public void CorrectNumberAnalysisNumberBiggerThanGuessed(int number, int guessedNumber, int changedValue)
        {
            //arrange
            MockGameData.SetupAllProperties();
            MockGameData.Object.GuessedNumber = guessedNumber;
            //act
            Game.NumberAnalysis(number);
            //assert
            Assert.AreEqual(changedValue, MockGameData.Object.MaxNumber);
            Assert.IsFalse(Game.win);
        }

        [Test]
        [TestCase(6, 7, 6)]
        [TestCase(0, 8, 0)]
        [TestCase(13, 100, 13)]
        public void CorrectNumberAnalysisNumberLessThanGuessed(int number, int guessedNumber, int changedValue)
        {
            //arrange
            MockGameData.SetupAllProperties();
            MockGameData.Object.GuessedNumber = guessedNumber;
            //act
            Game.NumberAnalysis(number);
            //assert
            Assert.AreEqual(changedValue, MockGameData.Object.MinNumber);
            Assert.IsFalse(Game.win);
        }

        [Test]
        [TestCase(13, 5, false)]
        [TestCase(14, 14, true)]
        [TestCase(-20, -20, true)]
        public void CorrectNumberAnalysisNumberIsGuessed(int number, int guessedNumber, bool awaitedResult)
        {
            //arrange
            MockGameData.SetupAllProperties();
            MockGameData.Object.GuessedNumber = guessedNumber;
            //act
            Game.NumberAnalysis(number);
            //assert
            Assert.AreEqual(awaitedResult, Game.win);
        }
        [Test]
        [TestCase(false, 1, 1, 1, 2)]
        [TestCase(true, 1, 1, 2, 1)]
        public void WinsLosesUpdateCorrectly(bool isWin, int winsBefore, int losesBefore, int winsAfter, int losesAfter)
        {
            //arrange
            MockPlayer.SetupAllProperties();
            MockPlayer.Object.Loses = losesBefore;
            MockPlayer.Object.Wins = winsBefore;
            Game.win = isWin;
            //act
            Game.EndStage(It.IsAny<int>());
            //assert
            Assert.AreEqual(winsAfter, MockPlayer.Object.Wins);
            Assert.AreEqual(losesAfter, MockPlayer.Object.Loses);
        }
    }
}