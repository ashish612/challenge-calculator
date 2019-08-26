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
            var calculator = new Calculator(new List<int> { 1, 2, 3 });
            var actualResult = calculator.Sum();
            Assert.AreEqual(actualResult, 6);

            calculator = new Calculator(new List<int> { 7, 11, 24,7 });
            actualResult = calculator.Sum();
            Assert.AreEqual(actualResult, 49);
        }
    }
}