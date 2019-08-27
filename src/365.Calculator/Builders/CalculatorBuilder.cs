using System;
using System.Collections.Generic;
using System.Linq;

namespace _365.Calculator.Builders
{

    public class CalculatorBuilder : IDelimiter, IValidNumber, IFilterNegatives, IFilterNumbers
    {
        private Delimiters _delimiter;
        private static string rawInput;
        private string[] inputArray;
        private List<int> validNumbers;

        private CalculatorBuilder()
        {
        }
        
        public static IDelimiter With(string input)
        {
            rawInput = input;
            return new CalculatorBuilder();
        }

        public IValidNumber And(Delimiters delimiter)
        {
            _delimiter = delimiter;
            inputArray = _delimiter.Split(rawInput);
            return this;
        }

        public Calculator FilterGreaterThan(int number)
        {
            validNumbers = validNumbers.Where(n => n < number).ToList();
            return new Calculator(validNumbers);
        }

        public IFilterNumbers FilterOutNegative()
        {
            var negatives = validNumbers.Where(n => n < 0);
            if (negatives.Any())
                throw new ArgumentException(string.Format("Negatives not allowed. {0}", string.Join(",", negatives)));

            validNumbers = validNumbers.Where(n => n > 0).ToList();
            return this;
        }

        public IFilterNegatives ValidNumbers()
        {
            validNumbers = new List<int>();
            foreach (var val in inputArray)
            {
                if (int.TryParse(val, out int validNumber))
                    validNumbers.Add(validNumber);
            }            
            return this;
        }
        
    }


}
