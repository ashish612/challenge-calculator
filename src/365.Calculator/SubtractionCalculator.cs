using System.Collections.Generic;

namespace _365.Calculator
{
    public class SubtractionCalculator : ICalculator
    {
        private List<int> validNumbers;

        public SubtractionCalculator(List<int> validNumbers)
        {
            this.validNumbers = validNumbers;
        }

        public long Calculate()
        {
            var result = 0 - validNumbers[0];
            for (int i = 1; i < validNumbers.Count; i++)
            {
                if (validNumbers[i] != 0)
                {
                    result -= validNumbers[i];
                }
            }

            return result;
        }

        public string Formula() => string.Format("{0}={1}", string.Join("-", validNumbers), Calculate());
    }
}