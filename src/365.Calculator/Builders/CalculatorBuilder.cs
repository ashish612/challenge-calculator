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
            Func<int, int> filter = x => x < number ? x : 0;
            Func<List<int>, List<int>> greaterThanFilter = x => x.Select(filter).ToList();

            validNumbers = greaterThanFilter(validNumbers);

            return new Calculator(validNumbers);
        }

        public IFilterNumbers FilterNegative(bool allow)
        {        
            var negatives = validNumbers.Where(n => n < 0);
            if (negatives.Any() && !allow)
                throw new ArgumentException(string.Format("Negatives not allowed. {0}", string.Join(",", negatives)));
                        
            return this;
        }

        public IFilterNegatives ValidNumbers()
        {
            validNumbers = new List<int>();
            
            Func<string, int> filter = x => int.TryParse(x, out int valid) ? valid : 0;
            Func<List<string>, List<int>> validNumberFilter = x => x.Select(filter).ToList();

            validNumbers = validNumberFilter(inputArray.ToList());

            return this;
        }        
    }
}
