using _365.Calculator;
using NUnit.Framework;
using System;

namespace Tests
{
    public class AdderTest
    {
        [Test]
        [TestCase("3,4", 7)]
        [TestCase("10,9", 19)]
        public void ShouldReturnSumOfCommaSeparatedNumbers(string input, int actualResult)
        {
            var adder = new Adder(new char[] { ',' });
            var expectedResult = adder.TryAdd(input);
            Assert.AreEqual(actualResult, expectedResult);
        }

        [Test]
        [TestCase("7,", 7)]
        [TestCase("", 0)]
        [TestCase("6,Ashish", 6)]
        public void ShouldIgnoreTextOrEmptyValueAndSumNumbers(string input, int actualResult)
        {
            var adder = new Adder(new char[] { ',' });
            var expectedResult = adder.TryAdd(input);
            Assert.AreEqual(actualResult, expectedResult);
        }

        [Test]
        [TestCase("7,4,2")]
        [TestCase("6,Ashish,4,1")]
        public void ShouldAllowSumOfMaximumTwoNumbers(string input)
        {
            var adder = new Adder(new char[] { ',' });
            Assert.Throws<Exception>(() => adder.TryAdd(input));
        }

    }
}