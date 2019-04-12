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
    public class AccountCreatorTest
    {
        private Mock<IDataAccessKeeper> MockDataKeeper { get; set; }
        private AccountCreator AccountCreator { get; set; }
        private List<Player> players;

        [SetUp]
        public void Setup()
        {
            MockDataKeeper = new Mock<IDataAccessKeeper>();
            AccountCreator = new AccountCreator(MockDataKeeper.Object);
            players= new List<Player>{ new Player { Login = "John", Password = "1111" },
                new Player { Login = "Doe", Password = "1212" },
            new Player { Login = "Manderly", Password = "0000" } };
        }

        [Test]
        [TestCaseSource ("someExistingPlayers")]
        public void CreateAccountFailUserExistTest(string login, string password)
        {
            //arrange
            MockDataKeeper.Setup(x => x.GetAccount(login, password)).
                 Returns(players.SingleOrDefault(x => x.Login == login && x.Password == password));
            //act
            var existingPlayer = AccountCreator.CreateAccount(login, password);
            //assert
            Assert.IsNull(existingPlayer);           
        }
        static object[] someExistingPlayers = {
            new object[]{ "John", "1111" },
            new object[]{ "Doe", "1212" },
            new object[]{ "Manderly", "0000" }
        };
        [Test]
        [TestCaseSource("someNotExistingPlayers")]
        public void CreateAccountSuccessNoSuchUser(string login, string password)
        {
            //arrange
            MockDataKeeper.Setup(x => x.GetAccount(login, password)).
                 Returns(players.SingleOrDefault(x => x.Login == login && x.Password == password));
            var emptyPlayer = new Player();
            var newUniquePlayer = emptyPlayer;
            //act
            newUniquePlayer = AccountCreator.CreateAccount(login, password);
            //assert
            Assert.IsNotNull(newUniquePlayer);
            Assert.AreNotSame(newUniquePlayer, emptyPlayer);
        }
        static object[] someNotExistingPlayers = {
            new object[]{ "George", "1111" },
            new object[]{ "Tommy", "1212" },
            new object[]{ "Sam", "0000" }
        };
        [Test]
        [TestCaseSource("someNotExistingPlayers")]
        public void IsNewPlayerHasLegitLoginPassword(string login, string password)
        {
            //arrange
            MockDataKeeper.Setup(x => x.GetAccount(login, password)).
                 Returns(players.SingleOrDefault(x => x.Login == login && x.Password == password));
            var emptyPlayer = new Player();
            var newUniquePlayer = emptyPlayer;
            //act
            newUniquePlayer = AccountCreator.CreateAccount(login, password);
            //assert
            Assert.AreSame(newUniquePlayer.Login, login);
            Assert.AreSame(newUniquePlayer.Password, password);
        }
        [Test]
        [TestCaseSource("ID")]
        public void PlayersCountIncreased(int id)
        {
            //arrange
            var login = "admin";
            var password = "1111";
            Player nullPlayer = null;
            MockDataKeeper.Setup(x => x.GetAccount(login, password)).
                 Returns(nullPlayer);
            MockDataKeeper.Setup(x => x.GetPlayersCount()).Returns(id);
            //act
            var newUniquePlayer = AccountCreator.CreateAccount(login, password);
            //assert
            Assert.Greater(newUniquePlayer.ID, id);
        }
        static int[] ID = {1,2,3,4,33,-10,12};
    }
}