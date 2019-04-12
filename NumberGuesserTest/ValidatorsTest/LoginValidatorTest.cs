using DataAccess.Models;
using Moq;
using NumberGuesser;
using NumberGuesser.Authorizations;
using NumberGuesser.IAuthorization;
using NUnit.Framework;
using System.Linq;
using System.Collections.Generic;
using NumberGuesser.Validators;

namespace Tests
{
    public class LoginValidatorTest
    {
        private Mock<IDataAccessKeeper> MockDataKeeper { get; set; }
        private LoginHandler LoginHandler { get; set; }
        private AccountCreator AccountCreator { get; set; }
        private LoginValidator LoginValidator { get; set; }
        private List<Player> players = new List<Player>{ new Player { Login = "John", Password = "1111" },
                new Player { Login = "Doe", Password = "1212" },
            new Player { Login = "Manderly", Password = "0000" } };

        [SetUp]
        public void Setup()
        {
            LoginValidator = new LoginValidator();
        }

        [Test]
        [TestCase("log")]
        [TestCase("correctLogin")]
        [TestCase("vlad11")]
        public void LoginCorrectInputTest(string loginString)
        {
            //arrange
            //act
            var isRightLogin=LoginValidator.Validate(loginString);
            //assert
            Assert.IsTrue(isRightLogin);            
        }
        [Test]
        [TestCase("log,")]
        [TestCase("   ")]
        [TestCase("")]
        [TestCase("*.,saf")]
        public void LoginInCorrectInputTest(string loginString)
        {
            //arrange
            //act
            var isWrongLogin = LoginValidator.Validate(loginString);
            //assert
            Assert.IsFalse(isWrongLogin);
        }

    }
}