using _365.Calculator.Builders;
using System;
using System.Text;

namespace _365.Calculator
{

    
    class Program
    {
        static void Main(string[] args)
        {            
            try
            {
                var delimiters = GetDelimiters();
                var input = GetInput();

                var sum = CalculatorBuilder                            
                            .With(input)
                            .And(delimiters)
                            .ValidNumbers()
                            .FilterOutNegative()
                            .FilterGreaterThan(1000)
                            .Sum();                

                Console.WriteLine(string.Format("Sum : {0}", sum));
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            Console.ReadLine();
        }

        private static Delimiter GetDelimiters()
        =>new Delimiter(new string[] { ",", "\n" });                        
        

        private static string GetInput()
        {
            Console.WriteLine("Provide an input. Press S to stop. ");
            var rawInput = new StringBuilder();
            
            while (true)
            {
                var input = Console.ReadLine();
                if (string.Compare(input, "S", true) == 0)
                    break;

                rawInput.AppendLine(input);
            }

            return rawInput.ToString();
        }
        
    }
}
