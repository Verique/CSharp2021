using System;
using NUnit.Framework;

namespace Homework3.Tests
{
    [TestFixture]
    public class StringAverageWordLengthExtensionTests
    {
        [Test]
        public void AverageWordLength_StringIsNull_ThrownNullReferenceException()
        {
            string str = null;
            
            Assert.That(() => str.AverageWordLength(), Throws.Exception.TypeOf<NullReferenceException>());
        }

        [Test]
        [TestCase("")]
        [TestCase("245 -- =14 <")]
        [TestCase("         ")]
        public void AverageWordLength_ZeroWordsInString_ThrownArgumentException(string str)
        {
            Assert.That(str.AverageWordLength, Throws.ArgumentException);
        }
        
        [Test]
        [TestCase("aa bbb cccc", 3)]
        [TestCase("aaa bbbb", 3.5)]
        [TestCase("a a a a a", 1)]
        [TestCase("aaaaa", 5)]
        public void AverageWordLength_AverageIsKnown_ReturnedCorrectLength(string str, double expected)
        {
            var actual = str.AverageWordLength();
            
            Assert.AreEqual(actual, expected);
        }
    }
}