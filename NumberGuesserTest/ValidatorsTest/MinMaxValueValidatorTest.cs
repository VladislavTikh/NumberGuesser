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
    public class MinMaxValueValidatorTest
    {
        private MinMaxValueValidator minMaxValueValidator { get; set; }
        private int minValue;
        private int maxValue;

        [SetUp]
        public void Setup()
        {
            minValue = 15;
            maxValue = 999;
            minMaxValueValidator = new MinMaxValueValidator(minValue,maxValue);
        }

        [Test]
        [TestCase(15)]
        [TestCase(999)]
        [TestCase(600)]
        [TestCase(16)]
        public void NumberCorrectInRangeInputTest(int value)
        {
            //arrange
            //act
            var isRighNumber= minMaxValueValidator.Validate(value);
            //assert
            Assert.IsTrue(isRighNumber);            
        }
        [Test]
        [TestCase(1000)]
        [TestCase(-200)]
        [TestCase(-1000)]
        [TestCase(14)]
        public void NumberIncorrectInRangeInputTest(int value)
        {
            //arrange
            //act
            var isWrongNumber = minMaxValueValidator.Validate(value);
            //assert
            Assert.IsFalse(isWrongNumber);
        }

    }
}