using NUnit.Framework;
using System;

namespace _365.Calculator.Tests
{
    public class AdderTest
    {
        private string[] delimiters;
        private Adder adder;

        [SetUp]
        public void BeforeAdderTests()
        {
            delimiters = new string[] { ",", "\r\n" };
            adder = new Adder(delimiters);
        }

        [Test]
        [TestCase("3,4", 7)]
        [TestCase("10,9", 19)]
        [TestCase("1,2,3,test,mock,4",10)]
        public void ShouldReturnSumOfCommaSeparatedNumbers(string input, int expectedResult)
        {
            var actualResult = adder.TryAdd(input);
            Assert.AreEqual(actualResult, expectedResult);
        }

        [Test]
        [TestCase("7,", 7)]
        [TestCase("", 0)]
        [TestCase("6,Ashish", 6)]
        public void ShouldIgnoreTextOrEmptyValueAndSumNumbers(string input, int expectedResult)
        {
            var actualResult = adder.TryAdd(input);
            Assert.AreEqual(actualResult, expectedResult);
        }

        //feature - allow more than 2 number sum.
        [Ignore("Feature - allow 2 number invalidates the test case.")]
        [Test]
        [TestCase("7,4,2")]
        [TestCase("6,Ashish,4,1")]
        public void ShouldAllowSumOfMaximumTwoNumbers(string input)
        {
            Assert.Throws<Exception>(() => adder.TryAdd(input));
        }

        [Test]
        [TestCase("1\r\n2,3",6)]
        [TestCase("4\r\n2\r\n11,3", 20)]
        public void ShouldGiveCorrectSumWithAltNewLineDelimiter(string input, int expectedResult)
        {
            var actualResult = adder.TryAdd(input);
            Assert.AreEqual(actualResult, expectedResult);
        }

        [Test]
        [TestCase("3\r\n2,-1")]
        [TestCase("-5")]
        public void ShouldThrowExceptionWhenInputHasNegativeNumbers(string input)
        {
            Assert.Throws<Exception>(() => adder.TryAdd(input));
        }

        [Test]
        [TestCase("-3\r\n2,-1")]        
        public void ShouldReturnNegativeNumbersWithExceptionWhenInputHasNegativeNumbers(string input)
        {
            Assert.That(() => adder.TryAdd(input),
            Throws.TypeOf<Exception>().With.Message
            .EqualTo("Negative numbers denied. -3,-1"));
        }        
    }
}