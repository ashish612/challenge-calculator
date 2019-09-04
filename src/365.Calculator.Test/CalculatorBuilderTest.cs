using _365.Calculator.Builders;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace _365.Calculator.Test
{
    public class CalculatorBuilderTest
    {
        private Delimiters delimiter;

        [SetUp]
        public void BeforeAdderTests()
        {
            var delimiters = new List<Delimiter> { new Delimiter(',',false), new Delimiter('\n',false) };
            delimiter = new Delimiters(delimiters);
        }


        [Test]
        [TestCase("3,4", 7,"3+4=7")]
        [TestCase("10,9", 19,"10+9=19")]
        [TestCase("1,2,3,test,mock,4", 10,"1+2+3+0+0+4=10")]        
        public void ShouldReturnCorrectSumAndFormulaForCommaSeparatedNumbers(string input, int expectedSum, string expectedFormula)
        {
            var actualResult = CalculatorBuilder
                                .With(input)
                                .And(delimiter)
                                .ValidNumbers()
                                .FilterOutNegative()
                                .FilterGreaterThan(1000);            

            Assert.AreEqual(expectedSum, actualResult.Sum());
            Assert.AreEqual(expectedFormula, actualResult.Formula());
        }

        [Test]
        [TestCase("7,", 7,"7+0=7")]
        [TestCase("", 0,"0=0")]
        [TestCase("6,Ashish", 6,"6+0=6")]
        public void ShouldIgnoreTextOrEmptyValueAndReturnCorrectSumAndFormula(string input, int expectedSum, string expectedFormula)
        {
            var actualResult = CalculatorBuilder
                                .With(input)
                                .And(delimiter)
                                .ValidNumbers()
                                .FilterOutNegative()
                                .FilterGreaterThan(1000);

            Assert.AreEqual(expectedSum, actualResult.Sum());
            Assert.AreEqual(expectedFormula, actualResult.Formula());
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
