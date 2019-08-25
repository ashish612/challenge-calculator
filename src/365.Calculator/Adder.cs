using System;
using System.Collections.Generic;
using System.Text;

namespace _365.Calculator
{
    public class Adder
    {
        private readonly char[] _delimiters;
        public Adder(char[] delimiters)
        {
            _delimiters = delimiters;
        }

        public int TryAdd(string input)
        {
            var operands = input.Split(_delimiters);

            //feature-allow summing more than 2 numbers.
            //if (operands.Length > 2)
                //  throw new Exception("Invalid Arguments. You can sum upto 2 numbers only.");

            var total = 0;
            foreach (var operand in operands)
            {
                if (int.TryParse(operand, out int validNumber))
                    total += validNumber;
            }

            return total;
        }
    }
}
