using NUnit.Framework;
using System.Collections.Generic;

namespace _365.Calculator.Test
{
    public class DelimitersTest
    {        
        [Test]
        public void ShouldSplitInputBasedOnDelimiters()
        {
            var input = "3,4,Ashish,1";
            var expectedResult = new string[] {"3","4","Ashish","1"};
            var delimiters = new Delimiters(new List<Delimiter> { new Delimiter(',', false)});
            var actualResult = delimiters.Split(input);

            Assert.AreEqual(expectedResult, actualResult);
            Assert.That(actualResult.Length == 4);
        }

        [Test]
        [TestCase('%')]
        [TestCase('~')]
        public void ShouldAllowAddingNewSingleCharacterDelimiter(char input)
        {
            var delimiters = new Delimiters(new List<Delimiter>());
            delimiters.Add(new Delimiter(input, false));
            Assert.AreEqual(delimiters.NumOfDelimiters(), 1);
        }        
    }

    public class DelimiterTest
    {
        [Test]
        [TestCase("1,2,,,,,,,,,,,3","1,2,3")]
        [TestCase("1,,,,,,,,,,2,,,,,,,,,,,3", "1,2,3")]
        public void ShouldCollapseDelimiterToSingleOccurance(string input, string expectedResult)
        {
            var delimiter = new Delimiter(',', true);

            var actualResult = delimiter.Collapse(input);

            Assert.AreEqual(actualResult, expectedResult);

        }
    }
}
