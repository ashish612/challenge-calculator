﻿using System;

namespace _365.Calculator
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Provide an input: ");

            var input = Console.ReadLine();

            try
            {
                var adder = new Adder(new char[] { ',' });
                var sum = adder.TryAdd(input);
                Console.WriteLine(string.Format("Total value of numbers : {0}", sum));
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }


            input = Console.ReadLine();

        }
    }
}