using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace _365.Calculator.Test
{
    public class DelimiterTest
    {        
        [Test]
        public void ShouldSplitInputBasedOnDelimiters()
        {
            var input = "3,4,Ashish,1";
            var expectedResult = new string[] {"3","4","Ashish","1"};
            var delimiters = new Delimiter(new string[] { "," });
            var actualResult = delimiters.Split(input);

            Assert.AreEqual(expectedResult, actualResult);
            Assert.That(actualResult.Length == 4);
        }

        [Test]
        [TestCase("%")]
        [TestCase("~")]
        public void ShouldAllowAddingNewSingleCharacterDelimiter(string input)
        {
            var delimiters = new Delimiter(new string[] { });
            var isSuccess = delimiters.TryAdd(input);
            Assert.AreEqual(isSuccess, true);
        }

        [Test]
        [TestCase("%%")]
        [TestCase("-~")]
        [TestCase("")]
        public void ShouldNotAllowAddingEmptyOrNewMultiCharacterDelimiter(string input)
        {
            var delimiters = new Delimiter(new string[] { });
            var isSuccess = delimiters.TryAdd(input);
            Assert.AreEqual(isSuccess, false);
        }
        
    }
}
