using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Threading.Tasks;

namespace StringGenerator.WEB.Filters
{
    public class StringGenerationExceptionFilterAttribute : ExceptionFilterAttribute, IAsyncExceptionFilter
    {
        public override Task OnExceptionAsync(ExceptionContext context)
        {
            var exceptionMessage = context.Exception.Message;

            if (context.Exception is ArgumentException)
                context.Result = new BadRequestObjectResult("Invalid parameters. " + exceptionMessage);
            else
                context.Result = new BadRequestObjectResult("Unexpected error occured." + exceptionMessage);

            return Task.CompletedTask;
        }
    }
}
