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
        private LoginValidator LoginValidator { get; set; }

        [SetUp]
        public void Setup()
        {
            LoginValidator = new LoginValidator();
        }
        [Test]
        #region Test Cases
        [TestCase("log", true)]
        [TestCase("correctLogin", true)]
        [TestCase("vlad11", true)]

        [TestCase("log,", false)]
        [TestCase("   ", false)]
        [TestCase("", false)]
        [TestCase("*.,saf", false)]
        #endregion
        public void LoginCorrectInput(string loginString, bool awaitedResult)
        {
            //arrange
            //act
            var result = LoginValidator.Validate(loginString);
            //assert
            Assert.AreEqual(awaitedResult, result);
        }
    }
}