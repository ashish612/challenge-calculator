using System.Collections.Generic;
using System.Linq;

namespace _365.Calculator
{
    public class DivisionCalculator : ICalculator
    {
        private List<int> validNumbers;

        public DivisionCalculator(List<int> validNumbers)
        {
            this.validNumbers = validNumbers;
        }

        public long Calculate()
        {
            double result = validNumbers.First();
            for (int i = 1; i < validNumbers.Count; i++)
            {
                if(validNumbers[i] != 0)
                {
                    result /= validNumbers[i];
                }
            }

            return (long)result;
        }

        public string Formula() => string.Format("{0}={1}", string.Join("/", validNumbers), Calculate());
    }
}