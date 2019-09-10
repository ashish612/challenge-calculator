using _365.Calculator.Builders;
using NDesk.Options;
using System;
using System.Collections.Generic;
using System.Text;

namespace _365.Calculator
{
    class Program
    {
        static int upperBound=1000;
        static bool allowNegatives=false;
        static char? altDelimiter = null;

        static void Main(string[] args)
        {
            SetOptions(args);

            ShowBanner();
            try
            {
                var delimiters = GetDelimiters();

                var input = GetInput();

                var calculator = CalculatorBuilder
                            .With(input)
                            .And(delimiters)
                            .ValidNumbers()
                            .FilterNegative(allowNegatives)
                            .FilterGreaterThan(upperBound);


                var sum = calculator.Sum();
                var formula = calculator.Formula();

                Console.WriteLine(string.Format("Sum : {0}", sum));
                Console.WriteLine(string.Format("Formula : {0}", formula));                
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            Console.Read();
        }

        private static void SetOptions(string[] args)
        {
            
            var options = new OptionSet()
            {
                { "u|ubound=","Enter an upperbound",
                    v => { int.TryParse(v,out upperBound); } },
                {"n|neg=","Enter true to allow negative and false to filter out negatives",
                    v =>  allowNegatives = bool.TryParse(v,out allowNegatives)},
                {"d|altdel=","Enter an alternative character",
                    v => altDelimiter = char.Parse(v)}
            };

            options.Parse(args);
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

            if (altDelimiter != null)
                defaultDelimiters.Add(new Delimiter(altDelimiter.Value, true));

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
