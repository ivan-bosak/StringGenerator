using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using MediatR;
using StringGenerator.WEB.Models;
using StringGenerator.WEB.Filters;

namespace StringGenerator.WEB.Controllers
{

    [Route("api/strings")]
    [ApiController]
    [StringGenerationExceptionFilter]
    public class StringGeneratorController : ControllerBase
    {
        private readonly IMediator mediator;

        public StringGeneratorController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpPost]
        public async Task<StringSet> GenerateString([FromBody] StringGenerationRequest request)
        {
            return await mediator.Send(request);
        }
    }
}
