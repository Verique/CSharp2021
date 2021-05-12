using System;
using System.Linq;
using NUnit.Framework;

namespace Homework3.Tests
{
    [TestFixture]
    public class ReverseWordsExtensionTests
    {
        [Test]
        public void ReverseWords_StringIsNull_ThrownNullReferenceException()
        {
            string str = null;
            
            Assert.That(() => str.ReverseWords(), Throws.Exception.TypeOf<NullReferenceException>());
        }

        [Test]
        public void ReverseWords_StringWithWords_ReturnedWordReversedString()
        {
            const string str = "The greatest victory is that which requires no battle";
            const string expected = "battle no requires which that is victory greatest The";

            var actual = str.ReverseWords();
            
            Assert.AreEqual(expected, actual);
        }
    }
}