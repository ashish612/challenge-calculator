using _365.Calculator.Builders;
using System;
using System.Collections.Generic;
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
        }
        
        private static void ShowBanner()
        {
            Console.WriteLine("Restaurant365 Code Challenge - String Calculator");
            Console.WriteLine("================================================");
            Console.WriteLine();
        }

        private static Delimiters GetDelimiters()
        {
            var defaultDelimiters = new List<Delimiter>()
            {
                new Delimiter(',',true),
                new Delimiter('\n', true)
            };

            var delimiters = new Delimiters(defaultDelimiters);

            AllowAddingCustomDelimiter(delimiters);

            return delimiters;
        }

        private static void AllowAddingCustomDelimiter(Delimiters delimiters)
        {
            Console.WriteLine("Press Y to add a custom delimiter or any character to skip.");

            if (char.TryParse(Console.ReadLine(), out char prompt) && (prompt == 'Y' || prompt == 'y'))
            {
                TryGetDelimiterInput(delimiters);                

                while (true)
                {
                    Console.WriteLine("Press M to add another delimiter or any character to skip.");

                    if (char.TryParse(Console.ReadLine(), out char moreDelimiterPrompt))
                    {
                        if (moreDelimiterPrompt == 'M' || moreDelimiterPrompt == 'm')
                            TryGetDelimiterInput(delimiters);
                        else
                            break;                        
                    }
                    else                        
                    {
                        Console.WriteLine("Invalid Input.");
                    }
                }
            }            
        }

        private static void TryGetDelimiterInput(Delimiters delimiters)
        {
            Console.WriteLine("Enter a single character custom delimiter: ");

            if (char.TryParse(Console.ReadLine(), out char input))
            {
                var customDelimiter = new Delimiter(input, true);
                delimiters.Add(customDelimiter);
            }
            else
            {
                Console.WriteLine("Invalid Input.");
                TryGetDelimiterInput(delimiters);
            }
        }

        private static string GetInput()
        {
            Console.WriteLine("Provide an input. Press S to show the sum.");
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
