using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using MediatR;
using StringGenerator.WEB.Models;
using StringGenerator.WEB.Filters;
using System;
using StringGenerator.WEB.Handlers;

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
            return await ServeRequest(request);
        }

        [HttpGet]
        [Route("api/strings/{alphabet}/{length}/{count}/{returnSet}")]
        public async Task<StringSet> GenerateFromRoute([FromRoute] StringGenerationRequest request)
        {
            return await ServeRequest(request);
        }

        [HttpGet("{alphabet}/{length}/{count}/{returnSet}")]
        [Route("api/strings")]
        public async Task<StringSet> GenerateFromQuery([FromQuery] StringGenerationRequest request)
        {
            return await ServeRequest(request);
        }

        private async Task<StringSet> ServeRequest(StringGenerationRequest request)
        {
            var strartTime = DateTime.Now;
            var result = await mediator.Send(request);
            var timediff = DateTime.Now - strartTime;
            result.RequestDurationInSeconds = timediff.TotalSeconds;
            return result;
        }
    }
}
