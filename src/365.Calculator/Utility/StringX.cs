using System;
using System.Collections.Generic;
using System.Text;

namespace _365.Calculator.Utility
{
    public static class StringX
    {
        public static List<int> ValidNumbers(this string[] input)
        {
            var validNumbers = new List<int>();
            foreach (var val in input)
            {
                if (int.TryParse(val, out int validNumber))
                    validNumbers.Add(validNumber);                    
            }

            return validNumbers;
        }
    }
}
