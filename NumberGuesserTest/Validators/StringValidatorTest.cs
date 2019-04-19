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
        [TestCase("0", true)]
        [TestCase("177", true)]
        [TestCase("999", true)]

        [TestCase("0sa", false)]
        [TestCase("asf", false)]
        [TestCase("219asf", false)]
        [TestCase("*.,saf", false)]
        public void StringToNumberCorrectInput(string numberAsString, bool awaitedResult)
        {
            //arrange

            //act
            var result = StringValidator.Validate(numberAsString);
            //assert
            Assert.AreEqual(result, awaitedResult);
        }
    }
}