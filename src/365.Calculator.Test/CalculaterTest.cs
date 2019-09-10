using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace _365.Calculator.Test
{
    public class CalculaterTest
    {

        [Test]    
        public void ShouldReturnCorrectSumOfNumbers()
        {
            var calculator = new AdditionCalculator(new List<int> { 1, 2, 3 });
            var actualResult = calculator.Calculate();
            Assert.AreEqual(actualResult, 6);

            calculator = new AdditionCalculator(new List<int> { 7, 11, 24,7 });
            actualResult = calculator.Calculate();
            Assert.AreEqual(actualResult, 49);
        }

        [Test]
        public void ShouldReturnCorrectDifferenceOfNumbers()
        {
            var calculator = new SubtractionCalculator(new List<int> { 1, 2, 3 });
            var actualResult = calculator.Calculate();
            Assert.AreEqual(actualResult, -6);

            calculator = new SubtractionCalculator(new List<int> { 7, 11, 24, 7 });
            actualResult = calculator.Calculate();
            Assert.AreEqual(actualResult, -49);
        }

        [Test]
        public void ShouldReturnCorrectProductOfNumbers()
        {
            var calculator = new MultiplicationCalculator(new List<int> { 1, 2, 3 });
            var actualResult = calculator.Calculate();
            Assert.AreEqual(actualResult, 6);

            calculator = new MultiplicationCalculator(new List<int> { 7, 11, 24});
            actualResult = calculator.Calculate();
            Assert.AreEqual(actualResult, 1848);
        }

        [Test]
        public void ShouldReturnCorrectDivisionOfNumbers()
        {
            var calculator = new DivisionCalculator(new List<int> { 10, 2, 2 });
            var actualResult = calculator.Calculate();
            Assert.AreEqual(actualResult, 2);

            calculator = new DivisionCalculator(new List<int> { 27, 3, 2 });
            actualResult = calculator.Calculate();
            Assert.AreEqual(actualResult, 4);
        }
    }
}