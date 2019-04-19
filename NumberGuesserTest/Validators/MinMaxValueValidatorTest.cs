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

        }

        [Test]
        [TestCase(999, -1000, 1000, true)]
        [TestCase(16, 0, 1000, true)]
        [TestCase(-200, -300, 1000, true)]
        [TestCase(14, 0, 20, true)]

        [TestCase(1000, 1200, 1400, false)]
        [TestCase(-1000, 0, 1000, false)]
        [TestCase(15, 0, 10, false)]
        [TestCase(600, -1000, 300, false)]
        public void NumberCorrectInRangeInputTest(int value, int minValue, int maxValue, bool awaitedResult)
        {
            //arrange
            minMaxValueValidator = new MinMaxValueValidator(minValue, maxValue);
            //act
            var result = minMaxValueValidator.Validate(value);
            //assert
            Assert.AreEqual(result, awaitedResult);
        }
    }
}