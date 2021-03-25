using StringGenerator.BLL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StringGenerator.BLL.Services
{
    public class StringGeneratorService: IGeneratorService
    {

        public IEnumerable<string> GenerateSetOfStrings(string alphabet, int lenght, int count, IStringGenerator stringGenerator)
        {
            if (count <= 0)
                throw new ArgumentException("Count can not be less or equal to 0!");

            var setOfStrings = new List<string>();

            for (int i = 0; i < count; i++)
                setOfStrings.Add(stringGenerator.GenerateString(alphabet, lenght));

            return setOfStrings;
        }

        public IEnumerable<KeyValuePair<char, int>> CountOcurrencesInSet(string alphabet, IEnumerable<string> setOfStrings)
        {
            return alphabet.ToCharArray().Select(chr => new KeyValuePair<char, int>(chr, 
                setOfStrings.Sum(str => str.Count(strChar => strChar == chr))));
        }
    }
}
