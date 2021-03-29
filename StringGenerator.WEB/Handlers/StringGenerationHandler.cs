using MediatR;
using MediatR.Pipeline;
using Microsoft.AspNetCore.Http;
using StringGenerator.BLL.Interfaces;
using StringGenerator.WEB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace StringGenerator.WEB.Handlers
{
    public class StringGenerationHandler : IRequestHandler<StringGenerationRequest, StringSet>
    {
        private readonly IGeneratorService generatorService;
        private readonly IStringGenerator stringGenerator;

        public StringGenerationHandler(IGeneratorService generatorService, IStringGenerator stringGenerator)
        {
            this.generatorService = generatorService;
            this.stringGenerator = stringGenerator;
        }

        public Task<StringSet> Handle(StringGenerationRequest request, CancellationToken cancellationToken)
        {
                return Task<StringSet>.Run(() =>
                {
                    try
                    {
                        var stringQuery = request;
                        var result = new StringSet();

                        result.SetOfStrings = generatorService.GenerateSetOfStrings(stringQuery.Alphabet, stringQuery.Length, stringQuery.Count, stringGenerator);

                        if (stringQuery.ReturnOcurrences)
                            result.AlphabetOcurrences = generatorService.CountOcurrencesInSet(stringQuery.Alphabet, result.SetOfStrings);

                        return result;
                    }
                    catch (Exception)
                    {
                        throw;
                    }
                });
        }
    }
}
