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

        [SetUp]
        public void Setup()
        {
            MockDataKeeper = new Mock<IDataAccessKeeper>();
            AccountCreator = new AccountCreator(MockDataKeeper.Object);
        }
        [Test]
        [TestCaseSource("ID")]
        public void PlayersCountIncreased(int id)
        {
            //arrange
            var login = "admin";
            var password = "1111";
            MockDataKeeper.Setup(x => x.GetPlayersCount()).Returns(id);
            //act
            var newUniquePlayer = AccountCreator.CreateAccount(login, password);
            //assert
            Assert.AreEqual(newUniquePlayer.ID, ++id);
        }
        static int[] ID = { 1, 2, 3, 4, 33, -10, 12 };
    }
}