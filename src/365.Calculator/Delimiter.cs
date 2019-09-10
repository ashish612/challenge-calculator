using System;
using System.Text.RegularExpressions;

namespace _365.Calculator
{
    public class Delimiter
    {
        public readonly char Character;
        public bool CanRepeat { get; private set; }

        public Delimiter(char character,bool canRepeat)
        {
            CanRepeat = canRepeat;
            Character = character;
        }

        public string Collapse(string input)
        {
            var r = new Regex(string.Format(@"\{0}{1}", Character, "+"));
            return r.Replace(input, Character.ToString());            
        }        
    }
}
