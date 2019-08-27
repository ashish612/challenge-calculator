using System;
using System.Collections.Generic;

namespace _365.Calculator
{
    public class Delimiter
    {
        private List<string> _delimiters;
        public IEnumerable<string> Values
        {
            get
            {
                return _delimiters;
            }
        }
        public Delimiter(string[] delimiters)
        {
            _delimiters = new List<string>();
            foreach (var delimiter in delimiters)            
                _delimiters.Add(delimiter);            
        }

        public string[] Split(string input)        
            => input.Split(_delimiters.ToArray(), StringSplitOptions.RemoveEmptyEntries);

        public bool TryAdd(string newCharacter)
        {
            if (newCharacter.Length == 1)
            {
                _delimiters.Add(newCharacter);
                return true;
            }
            return false;
        }

    }

}
