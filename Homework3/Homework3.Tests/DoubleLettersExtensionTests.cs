using System;
using NUnit.Framework;

namespace Homework3.Tests
{
    [TestFixture]
    public class DoubleLettersExtensionTests
    {
        [Test]
        [TestCase(null, "aa")]
        [TestCase(null, null)]
        [TestCase("aaa", null)]
        public void DoubleLetters_StringsAreNull_ThrownNullReferenceException(string to, string from)
        {
            Assert.That(() => to.DoubleLetters(from), Throws.Exception.TypeOf<NullReferenceException>());
        }

        [Test]
        [TestCase("omg i love shrek", "o kek", "oomg i loovee shreekk")]
        [TestCase("test string", "test", "tteesstt ssttring")]
        public void DoubleLetters_CorrectInput_ReturnedDoubleLetteredString(string to, string from, string expected)
        {
            var actual = to.DoubleLetters(from);
            
            Assert.AreEqual(expected, actual);
        }

        [Test]
        [TestCase("", "sasdasf")]
        [TestCase("asdasf", "")]
        [TestCase("hi","yo")]
        public void DoubleLetters_NoSameLetters_ReturnedStringTo(string to, string from)
        {
            var actual = to.DoubleLetters(from);
            var expected = to;
            
            Assert.AreEqual(expected, actual);
        }
    }   
}