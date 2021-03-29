using NUnit.Framework;
using StringGenerator.BLL.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace StringGenerat
{
    [TestFixture]
    class StringFactoryTest
    {
        private StringFactory _stringFactory;
        [SetUp]
        public void Setup()
        {
            _stringFactory = new StringFactory();
        }
        [Test]
        [TestCase(null)]
        [TestCase("")]
        [TestCase(" ")]
        public void GenerateString_AlpahbetIsEmpty_ThrowsException(string alphabet)
        {
            const int length = 10;
            var exceptionMessaage = "Alphabet string can not be empty!";

            var exception = Assert.Throws<ArgumentException>(() => _stringFactory.GenerateString(alphabet, length));

            Assert.That(exception.Message, Is.EqualTo(exceptionMessaage));
        }

        [Test]
        [TestCase(0)]
        [TestCase(-5)]
        public void GenerateString_LengthIsOutORange_ThrowsException(int length)
        {
            const string alphabet = "A";
            var exceptionMessaage = "Length can not be less or equal to 0!";

            var exception = Assert.Throws<ArgumentException>(() => _stringFactory.GenerateString(alphabet, length));

            Assert.That(exception.Message, Is.EqualTo(exceptionMessaage));
        }

        [Test]
        [TestCase("abc", 5)]
        [TestCase("abcd", 1)]
        [TestCase("jfhdk", 10)]
        [TestCase("ABaBFkl", 10)]
        [TestCase("!123Absc786K&", 100)]
        public void GenerateString_ValidArguments_GeneratesValidString(string alphabet, int length)
        {
            var result = _stringFactory.GenerateString(alphabet, length);

            Assert.IsFalse(String.IsNullOrEmpty(result));
            foreach (var character in result.ToCharArray()) 
                Assert.IsTrue(alphabet.Contains(character), $"Character {character} is not present in generated string!");

            Assert.AreEqual(length, result.Length, "Invalid length of generated string!");
        }
    }
}
