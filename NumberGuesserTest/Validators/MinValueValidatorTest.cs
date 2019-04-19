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
    public class MinValueValidatorTest
    {
        private MinValueValidator minValueValidator { get; set; }

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        #region Test Cases
        [TestCase(200, 100, true)]
        [TestCase(16, -16, true)]
        [TestCase(15, 15, true)]
        [TestCase(12, int.MinValue, true)]

        [TestCase(10000, int.MaxValue, false)]
        [TestCase(10000, 20000, false)]
        [TestCase(0, 10, false)]
        [TestCase(9, 99, false)]
        #endregion
        public void BiggerNumberCorrectInput(int value, int minValue, bool awaitedResult)
        {
            //arrange
            minValueValidator = new MinValueValidator(minValue);
            //act
            var result = minValueValidator.Validate(value);
            //assert
            Assert.AreEqual(result, awaitedResult);
        }
    }
}