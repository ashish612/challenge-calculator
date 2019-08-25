using _365.Calculator.Utility;
using NUnit.Framework;
using System.Collections.Generic;

namespace _365.Calculator.Test
{
    class StringXTest
    {

        [Test]        
        public void ShouldReturnValidNumbersOnly()
        {
            var input = new string[] { "1", "Ash", "2", "\r\n", "Ar", "3" };
            var actualResult = input.ValidNumbers();
            var expectedResult = new List<int> { 1, 2, 3 };
            Assert.AreEqual(actualResult, expectedResult);
        }
    }
}
