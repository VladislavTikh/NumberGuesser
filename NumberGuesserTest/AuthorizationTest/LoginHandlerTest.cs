using DataAccess.Models;
using Moq;
using NumberGuesser;
using NumberGuesser.Authorizations;
using NumberGuesser.IAuthorization;
using NUnit.Framework;
using System.Linq;
using System.Collections.Generic;

namespace Tests
{
    public class LoginHandlerTest
    {
        private Mock<IDataAccessKeeper> MockDataKeeper { get; set; }
        private LoginHandler LoginHandler { get; set; }
        private List<Player> players;

        [SetUp]
        public void Setup()
        {
            MockDataKeeper = new Mock<IDataAccessKeeper>();
            LoginHandler = new LoginHandler(MockDataKeeper.Object);
            players = new List<Player>{ new Player { Login = "John", Password = "1111" },
                new Player { Login = "Doe", Password = "1212" },
            new Player { Login = "Manderly", Password = "0000" } };
        }

        [Test]
        [TestCase("John", "1111")]
        [TestCase("Doe", "1212")]
        public void LogInAccountSuccessTest(string login, string password)
        {
            //arrange
            MockDataKeeper.Setup(x => x.GetAccount(login, password)).
                Returns(players.SingleOrDefault(x => x.Login == login && x.Password == password));
            var emptyPlayer = new Player();
            //act
            var existingPlayer = LoginHandler.LogIn(login, password);
            //assert
            Assert.IsNotNull(existingPlayer);
            Assert.AreNotEqual(emptyPlayer, existingPlayer);
        }
        [Test]
        [TestCase("NotExist", "11211")]
        [TestCase("404", "1212")]
        [TestCase("NotFound", "1212")]
        public void LogInAccountFailTest(string login, string password)
        {
            //arrange
            MockDataKeeper.Setup(x => x.GetAccount(login, password)).
                Returns(players.SingleOrDefault(x => x.Login == login && x.Password == password));
            var emptyPlayer = new Player();
            //act
            var notExistingPlayer = LoginHandler.LogIn(login, password);
            //assert
            Assert.IsNull(notExistingPlayer);
            Assert.AreNotEqual(emptyPlayer, notExistingPlayer);
        }
        [Test]
        [TestCaseSource("somePlayers")]
        public void UserExistStatusSuccess(Player player)
        {
            //arrange
            var playerToCheck = player;
            var awaitedStatus = AccessStatus.Success;
            //act
            var status = LoginHandler.CheckAccessStatus(playerToCheck);
            //assert
            Assert.AreEqual(awaitedStatus,status);            
        }
        static Player[] somePlayers = {
            new Player{ Login="George", Password="1111" },
            new Player{ Login="Tommy", Password="1212" },
            new Player{ Login="Sam", Password="0000" }
        };
    }
}