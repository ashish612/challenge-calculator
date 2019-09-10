using System;
using System.Collections.Generic;
using System.Text;

namespace _365.Calculator.Builders
{
    public interface IOperation
    {
        ICalculator For(char operation);
    }
}
