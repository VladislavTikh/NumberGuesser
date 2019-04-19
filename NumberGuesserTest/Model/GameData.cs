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
    public class GameDataTest
    {
        private GameData GameData;

        [SetUp]
        public void Setup()
        {
            GameData = new GameData();
        }
        [Test]
        #region Test Cases
        [TestCase(0, 0, 1)]
        [TestCase(20, 10, 4)]
        [TestCase(1000, 0, 10)]
        [TestCase(1000, -1000, 11)]
        [TestCase(0, -10, 4)]
        [TestCase(-100, -10, 1)]
        #endregion
        public void AttemptsCountCorrectly(int maxNumber, int minNumber, int awaitedAttempts)
        {
            //arrange
            //act
            var attempts = GameData.CountAttempts(maxNumber, minNumber);
            //assert
            Assert.AreEqual(attempts, awaitedAttempts);
        }
    }
}