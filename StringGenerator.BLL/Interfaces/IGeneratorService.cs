using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace StringGenerator.BLL.Interfaces
{
    public interface IGeneratorService
    {
        Task<IEnumerable<string>> GenerateSetOfStrings(string alphabet, int lenght, int count, IStringGenerator stringGenerator);
        IEnumerable<KeyValuePair<char, int>> CountOcurrencesInSet(string alphabet, IEnumerable<string> setOfStrings);

    }
}
