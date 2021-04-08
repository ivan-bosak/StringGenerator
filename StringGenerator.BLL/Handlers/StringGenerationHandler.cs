using MediatR;
using MediatR.Pipeline;
using StringGenerator.BLL.Interfaces;
using StringGenerator.BLL.Models;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace StringGenerator.BLL.Handlers
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

        public async Task<StringSet> Handle(StringGenerationRequest request, CancellationToken cancellationToken)
        {
            var result = new StringSet();

            var generatedSet = await generatorService.GenerateSetOfStrings(request.Alphabet, request.Length, request.Count, stringGenerator);

            if (request.ReturnSet)
                result.SetOfStrings = generatedSet;

            result.AlphabetOcurrences = generatorService.CountOcurrencesInSet(request.Alphabet, generatedSet);

            return result;
        }
    }
}
