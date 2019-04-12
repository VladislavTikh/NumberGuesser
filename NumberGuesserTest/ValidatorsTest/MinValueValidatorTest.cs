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
        private int minValue;

        [SetUp]
        public void Setup()
        {
            minValue = 15;
            minValueValidator = new MinValueValidator(minValue);
        }

        [Test]
        #region Test Cases
        [TestCase(200)]
        [TestCase(10000)]
        [TestCase(16)]
        [TestCase(15)]
        #endregion
        public void BiggerNumberCorrectInputTest(int value)
        {
            //arrange
            //act
            var isRighNumber= minValueValidator.Validate(value);
            //assert
            Assert.IsTrue(isRighNumber);            
        }
        [Test]
        #region Test Cases
        [TestCase(12)]
        [TestCase(-200)]
        [TestCase(0)]
        [TestCase(9)]
        #endregion
        public void BiggerNumberIncorrectInputTest(int value)
        {
            //arrange
            //act
            var isWrongNumber = minValueValidator.Validate(value);
            //assert
            Assert.IsFalse(isWrongNumber);
        }

    }
}