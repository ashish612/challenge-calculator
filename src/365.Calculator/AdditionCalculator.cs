using System.Collections.Generic;
using System.Linq;

namespace _365.Calculator
{
    public class AdditionCalculator:ICalculator
    {
        private List<int> _numbers;
        public AdditionCalculator(List<int> numbers)
        {
            _numbers = numbers;
        }

        public long Calculate() =>_numbers.Sum();

        public string Formula() => string.Format("{0}={1}", string.Join("+", _numbers), Calculate());        
    }
}
