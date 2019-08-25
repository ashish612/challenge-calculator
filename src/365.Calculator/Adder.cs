using _365.Calculator.Utility;
using System;
using System.Collections.Generic;
using System.Linq;

namespace _365.Calculator
{
    public class Adder
    {
        private readonly string[] _delimiters;
        public Adder(string[] delimiters)
        {
            _delimiters = delimiters;
        }

        public int TryAdd(string input)
        {
            var operands = input.Split(_delimiters, StringSplitOptions.RemoveEmptyEntries);

            var negativeValues = FindNegativeValues(operands);

            if (negativeValues.Count > 0)
                throw new Exception(string.Format("Negative numbers denied. {0}", string.Join(",", negativeValues)));

            //feature-allow summing more than 2 numbers.
            //if (operands.Length > 2)
            //  throw new Exception("Invalid Arguments. You can sum upto 2 numbers only.");

            return operands
                    .ValidNumbers()
                    .Sum(o=>o);            
        }

        private List<int> FindNegativeValues(string[] operands)
        => operands
            .ValidNumbers()
            .Where(o=>o<0)
            .ToList();
    }
}
