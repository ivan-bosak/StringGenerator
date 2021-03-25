using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using Moq;
using StringGenerator.BLL.Interfaces;
using System.Linq;
using StringGenerator.BLL.Services;

namespace StringGenerator.Test
{
    [TestFixture]
    class StringGeneratorServiceTest
    {
        private IGeneratorService stringGenratorService = new StringGeneratorService();

        [Test]
        [TestCase("abc", 10, 10)]
        [TestCase("1234ant%7", 5, 9)]
        public void GenerateSetOfStrings_ValidParameters_ReturnsValidSet(string alphabet, int length, int count)
        {
            var stringFactoryMoq = new Mock<IStringGenerator>();
            stringFactoryMoq.Setup(m => m.GenerateString(alphabet, length)).Returns(() => new string(alphabet.First(), length));

            var setOfStrings = stringGenratorService.GenerateSetOfStrings(alphabet, length, count, stringFactoryMoq.Object);

            Assert.AreEqual(count, setOfStrings.Count(), "Incorrect size of set!");
            foreach (var set in setOfStrings)
                Assert.AreEqual(length, set.Length, "Incorrect length of generated string!");
        }

        [Test]
        public void CountOcurrencesInSet_SetWithThreeStingsConsistFromFourCharacters_ReturnsCorrectCount()
        {
            var alphabet = "abcd";
            var setOfStrings = new List<string>() { "abcd", "aabb", "cccd" };

            var setOccurences = stringGenratorService.CountOcurrencesInSet(alphabet, setOfStrings);

            Assert.AreEqual(alphabet.Length, setOccurences.Count());
            foreach (var str in setOccurences)
                Assert.AreEqual(setOfStrings.Sum(s => s.Count(ch => ch == str.Key)), str.Value);
        }

        [Test]
        public void CountOcurrencesInSet_SetDoesntContainCharsFromAlphabet_ReturnsStatWithZeros()
        {
            var alphabet = "abcd";
            var setOfStrings = new List<string>() { "qwer", "mkjl"};

            var setOccurences = stringGenratorService.CountOcurrencesInSet(alphabet, setOfStrings);

            foreach (var str in setOccurences)
                Assert.AreEqual(0, str.Value);

        }

        [Test]
        public void CountOcurrencesInSet_SetIsEmpty_ReturnsStatWithZeros()
        {
            var alphabet = "abce";
            var setOfStrings = new List<string>();

            var setOccurences = stringGenratorService.CountOcurrencesInSet(alphabet, setOfStrings);

            foreach (var str in setOccurences)
                Assert.AreEqual(0, str.Value);

        }

        [Test]
        [TestCase(0)]
        [TestCase(-5)]
        public void GenerateSetOfStrings_CountIsOutORange_ThrowsException(int count)
        {
            var exceptionMessaage = "Count can not be less or equal to 0!";

            var exception = Assert.Throws<ArgumentException>(() => stringGenratorService.GenerateSetOfStrings("ab", 7, count, null));

            Assert.That(exception.Message, Is.EqualTo(exceptionMessaage));
        }
    }
}
