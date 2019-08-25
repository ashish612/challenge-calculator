using System;
using System.Text;

namespace _365.Calculator
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Provide an input separating either by a comma(,) or a new line. Press S to stop. ");

            try
            {
                var input = GetInputValues();
                var adder = new Adder(new string[] { "," ,"\n"});
                var sum = adder.TryAdd(input);
                Console.WriteLine(string.Format("Sum : {0}", sum));
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            Console.ReadLine();
        }

        private static string GetInputValues()
        {
            
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
