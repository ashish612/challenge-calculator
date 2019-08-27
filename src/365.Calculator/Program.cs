using _365.Calculator.Builders;
using System;
using System.Text;

namespace _365.Calculator
{

    
    class Program
    {
        static void Main(string[] args)
        {
            ShowBanner();
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

        private static void ShowBanner()
        {
            Console.WriteLine("Restaurant365 Code Challenge - String Calculator");
            Console.WriteLine("================================================");
            Console.WriteLine();
        }

        private static Delimiter GetDelimiters()
        {
            var delimiters = new Delimiter(new string[] { ",", "\n" });

            Console.WriteLine("Press Y for to add a custom delimiter or N to skip.");
            var prompt = Console.ReadLine();
            if (string.Compare(prompt, "N", true) == 0 || string.Compare(prompt, "", true) == 0)
                return delimiters;

            var isAdded = false;
            while (!isAdded)
            {
                Console.WriteLine("Please enter a single character custom delimiter: ");
                var input = Console.ReadLine();
                isAdded = delimiters.TryAdd(input);
                if (!isAdded)
                    Console.WriteLine("Invalid Character.");
            }
            return delimiters;
        }

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
