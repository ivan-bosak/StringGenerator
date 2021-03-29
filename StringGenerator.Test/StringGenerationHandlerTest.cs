using Moq;
using NUnit.Framework;
using StringGenerator.BLL.Interfaces;
using StringGenerator.WEB.Handlers;
using StringGenerator.WEB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringGenerator.Test
{
    
    [TestFixture]
    class StringGenerationHandlerTest
    {
        private readonly StringGenerationRequest request;
        private readonly StringGenerationHandler handler;

        public StringGenerationHandlerTest()
        {
            var alphabet = "abc";
            var length = 1;
            var count = 1;
            var stringFactoryMoq = new Mock<IStringGenerator>();
            stringFactoryMoq.Setup(m => m.GenerateString(alphabet, length)).Returns(() => new string(alphabet.First(), length));

            var stringGenerServiceMoq = new Mock<IGeneratorService>();
            stringGenerServiceMoq.Setup(m => m.GenerateSetOfStrings(alphabet, length, count, stringFactoryMoq.Object)).Returns(() => new string[] { "a" });

            request = new StringGenerationRequest();
            handler = new StringGenerationHandler(stringGenerServiceMoq.Object, stringFactoryMoq.Object);
            request.Alphabet = alphabet;
            request.Count = count;
            request.Length = length;
        }

        [Test]
        public async Task HandleGenRequest_ReturnOccurencesIsFalse_AlphabetOcurrencesIsNull()
        {
            request.ReturnOcurrences = false;

            var result = await handler.Handle(request,  default);

            Assert.IsNotNull(result);
            Assert.NotZero(result.SetOfStrings.Count());
            Assert.IsNull(result.AlphabetOcurrences);
        }
        [Test]
        public async Task HandleGenRequest_ReturnOccurencesIsTrue_ReturnsAlphabetOcurrences()
        {
            request.ReturnOcurrences = true;

            var result = await handler.Handle(request, default);

            Assert.IsNotNull(result);
            Assert.NotZero(result.SetOfStrings.Count());
            Assert.IsNotNull(result.AlphabetOcurrences);
        }
    }
}
