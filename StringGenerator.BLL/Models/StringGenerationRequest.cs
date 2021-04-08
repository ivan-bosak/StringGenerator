using MediatR;

namespace StringGenerator.BLL.Models
{
    public class StringGenerationRequest: IRequest<StringSet>
    {
        public string Alphabet { get; set; }
        public int Length { get; set; }
        public int Count { get; set; }
        public bool ReturnSet { get; set; }
    }
}
