using StringGenerator.BLL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StringGenerator.BLL.Services
{
    public class StringFactory : IStringGenerator
    {
        public virtual string GenerateString(string alphabet, int lenght)
        {
            if (String.IsNullOrWhiteSpace(alphabet))
                throw new ArgumentException("Alphabet string can not be empty!");

            if (lenght <= 0)
                throw new ArgumentException("Length can not be less or equal to 0!");

            var random = new Random();

            return new string(Enumerable.Repeat(alphabet, lenght)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }
    }
}
