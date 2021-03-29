using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using MediatR;
using StringGenerator.WEB.Models;
using StringGenerator.WEB.Filters;

namespace StringGenerator.WEB.Controllers
{

    
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
        [Route("api/strings")]
        public async Task<StringSet> GenerateFromBody([FromBody] StringGenerationRequest request)
        {
            return await mediator.Send(request);
        }

        [HttpGet]
        [Route("api/strings/{alphabet}/{length}/{count}/{returnOcurrences}")]
        public async Task<StringSet> GenerateFromRoute([FromRoute] StringGenerationRequest request)
        {
            return await mediator.Send(request);
        }

        [HttpGet("{alphabet}/{length}/{count}/{returnOcurrences}")]
        [Route("api/strings")]
        public async Task<StringSet> GenerateFromQuery([FromQuery] StringGenerationRequest request)
        {
            return await mediator.Send(request);
        }
    }
}
