﻿using _365.Calculator.Builders;
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
            
            try
            {
                var operation = GetOperation();
                var delimiters = GetDelimiters();
                var input = GetInput();

                

                var calculator = CalculatorBuilder
                            .With(input)
                            .And(delimiters)
                            .ValidNumbers()
                            .FilterNegative(allowNegatives)
                            .FilterGreaterThan(upperBound)
                            .For(operation);


                var result = calculator.Calculate();
                var formula = calculator.Formula();

                Console.WriteLine(string.Format("Result : {0}", result));
                Console.WriteLine(string.Format("Formula : {0}", formula));                
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            Console.Read();
        }

        private static char GetOperation()
        {
            var validOperations = new Dictionary<char, string> {
                { '+', "Addition" },
                { '-', "Subtraction" },
                { '*', "Multiplication" },
                { '/', "Division" }
            };
            Console.WriteLine("Enter the operation you want to perform: ");
            foreach (var key in validOperations.Keys)            
                Console.WriteLine(string.Format("{0} for {1}",key,validOperations[key]));
                                
            char prompt = '+';
            while (true)
            {
                if (char.TryParse(Console.ReadLine(), out prompt) && validOperations.ContainsKey(prompt))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid Input.");
                }
            }

            return prompt;
        }

        private static void SetOptions(string[] args)
        {
            ShowBanner();
            var options = new OptionSet()
            {
                { "u|ubound=","Enter an upperbound",
                    v => { int.TryParse(v,out upperBound); } },
                {"n|neg=","Enter true to allow negative and false to filter out negatives",
                    v =>  bool.TryParse(v,out allowNegatives)},
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
            Console.WriteLine("Provide an input. Press S to show the result.");
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
