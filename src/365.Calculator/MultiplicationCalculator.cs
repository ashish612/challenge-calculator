﻿using System.Collections.Generic;
using System.Linq;

namespace _365.Calculator
{
    public class MultiplicationCalculator : ICalculator
    {
        private List<int> validNumbers;

        public MultiplicationCalculator(List<int> validNumbers)
        {
            this.validNumbers = validNumbers;
        }

        public long Calculate()
        {
            
            var result = validNumbers[0];
            for (int i = 1; i < validNumbers.Count; i++)
            {
                if (validNumbers[i] != 0)
                {
                    result *= validNumbers[i];
                }
            }

            return result;
        }

        public string Formula() => string.Format("{0}={1}", string.Join("*", validNumbers), Calculate());
    }
}