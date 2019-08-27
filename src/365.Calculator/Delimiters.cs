using System.Collections.Generic;
using System.Linq;

namespace _365.Calculator
{
    public class Delimiters
    {
        private List<Delimiter> _delimiters;
        
        public Delimiters(List<Delimiter> delimiters)
        {
            _delimiters = delimiters;
        }

        public string[] Split(string input)
        {            
            foreach (var delimiter in _delimiters)                            
                input = delimiter.Collapse(input);                
            
            return input.Split(_delimiters.Select(d=>d.Character).ToArray());
        }

        public void Add(Delimiter newDelimiter)
        {                       
            _delimiters.Add(newDelimiter);
        }

        public int NumOfDelimiters() => _delimiters.Count();
    }

}
