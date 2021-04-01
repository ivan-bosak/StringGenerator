using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StringGenerator.WEB.Models
{
    public class StringGenerationRequest: IRequest<StringSet>
    {
        public string Alphabet { get; set; }
        public int Length { get; set; }
        public int Count { get; set; }
        public bool ReturnSet { get; set; }
    }
}
