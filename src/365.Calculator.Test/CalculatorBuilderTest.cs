using _365.Calculator.Builders;
using NUnit.Framework;
using System;

namespace _365.Calculator.Test
{
    public class CalculatorBuilderTest
    {
        private Delimiter delimiter;

        [SetUp]
        public void BeforeAdderTests()
        {
            var delimiters = new string[] { ",", "\r\n" };
            delimiter = new Delimiter(delimiters);
        }


        [Test]
        [TestCase("3,4", 7)]
        [TestCase("10,9", 19)]
        [TestCase("1,2,3,test,mock,4", 10)]        
        public void ShouldReturnSumOfCommaSeparatedNumbers(string input, int expectedResult)
        {
            var actualResult = CalculatorBuilder
                                .With(input)
                                .And(delimiter)
                                .ValidNumbers()
                                .FilterOutNegative()
                                .FilterGreaterThan(1000)
                                .Sum();

            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        [TestCase("7,", 7)]
        [TestCase("", 0)]
        [TestCase("6,Ashish", 6)]
        public void ShouldIgnoreTextOrEmptyValueAndSumNumbers(string input, int expectedResult)
        {
            var actualResult = CalculatorBuilder
                                .With(input)
                                .And(delimiter)
                                .ValidNumbers()
                                .FilterOutNegative()
                                .FilterGreaterThan(1000)
                                .Sum();

            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        [TestCase("3\r\n2,-1")]
        [TestCase("-5")]
        public void ShouldThrowExceptionWhenInputHasNegativeNumbers(string input)
        {            
            Assert.Throws<ArgumentException>(() => 
                                CalculatorBuilder
                                    .With(input)
                                    .And(delimiter)
                                    .ValidNumbers()
                                    .FilterOutNegative()
                                    .FilterGreaterThan(1000)
                                    .Sum());
        }

        [Test]
        [TestCase("-3\r\n2,-1")]
        public void ShouldReturnNegativeNumbersWithExceptionWhenInputHasNegativeNumbers(string input)
        {
            Assert.That(() =>
                        CalculatorBuilder
                            .With(input)
                            .And(delimiter)
                            .ValidNumbers()
                            .FilterOutNegative()
                            .FilterGreaterThan(1000)
                            .Sum(),
            Throws.TypeOf<ArgumentException>().With.Message
            .EqualTo("Negatives not allowed. -3,-1"));
        }

    }
}
