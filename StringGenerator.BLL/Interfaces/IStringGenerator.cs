using System;
using System.Collections.Generic;
using System.Text;

namespace StringGenerator.BLL.Interfaces
{
    public interface IStringGenerator
    {
        string GenerateString(string alphabet, int lenght);
    }
}
