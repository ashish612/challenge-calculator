using System.Collections.Generic;
using System.Linq;

namespace _365.Calculator
{
    public class Calculator
    {
        private List<int> _numbers;
        public Calculator(List<int> numbers)
        {
            _numbers = numbers;
        }

        public int Sum() =>_numbers.Sum();

        public string Formula() => string.Format("{0}={1}", string.Join("+", _numbers), Sum());
    }
}
