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
    public class StringValidatorTest
    {
        private StringValidator StringValidator;

        [SetUp]
        public void Setup()
        {
            StringValidator = new StringValidator();
        }

        [Test]
        [TestCase("0")]
        [TestCase("177")]
        [TestCase("999")]
        public void StringToNumberCorrectInputTest(string numberAsString)
        {
            //arrange

            //act
            var isRightInput= StringValidator.Validate(numberAsString);
            //assert
            Assert.IsTrue(isRightInput);            
        }
        [Test]
        [TestCase("0sa")]
        [TestCase("asf")]
        [TestCase("219asf")]
        [TestCase("*.,saf")]
        public void StringToNumberInCorrectInputTest(string numberAsString)
        {
            //arrange

            //act
            var isWrongInput = StringValidator.Validate(numberAsString);
            //assert
            Assert.IsFalse(isWrongInput);
        }

    }
}