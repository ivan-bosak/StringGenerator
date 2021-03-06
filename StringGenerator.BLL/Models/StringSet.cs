using System.Collections.Generic;

namespace StringGenerator.BLL.Models
{
    public class StringSet
    {
        public IEnumerable<string> SetOfStrings { get; set; }
        public IEnumerable<KeyValuePair<char, int>> AlphabetOcurrences { get; set; }
        public double RequestDurationInSeconds { get; set; }
    }
}
