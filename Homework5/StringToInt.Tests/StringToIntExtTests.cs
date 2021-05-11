using System;
using System.Collections.Generic;
using Moq;
using NUnit.Framework;
using NUnit.Framework.Internal;
using ILogger = Microsoft.Extensions.Logging.ILogger;

namespace StringToInt.Tests
{
    [TestFixture]
    public class StringToIntExtTests
    {
        private static List<string> wrongStringList =
            new List<string>()
            {
                "asd", "--gag", "-+0", "52 0 2", "52a", "222222222222222222222222222222222"
            };

        private static List<TestCaseData> correctStringTestCases =
            new List<TestCaseData>(new[]
            {
                new TestCaseData("-56971", -56971),
                new TestCaseData("-0", 0),
                new TestCaseData("5202", 5202),
                new TestCaseData(int.MaxValue.ToString(), int.MaxValue),
                new TestCaseData(int.MinValue.ToString(), int.MinValue),
            });

        ILogger loggerMock = Mock.Of<ILogger>();
        
        [Test]
        public void StringToInt_LoggerIsNull_ThrownNullArgumentException()
        {
            const string str = "test string";

            Assert.That(() => str.ToInt(null), Throws.ArgumentNullException);
        }
        
        [Test]
        public void StringToInt_WrongString_ThrownArgumentException([ValueSource(nameof(wrongStringList))] string str)
        {
            Assert.That(() => str.ToInt(loggerMock), Throws.ArgumentException);
        }
        
        [Test]
        public void StringToInt_NullString_ThrownArgumentNullException()
        {
            string str = null;
            Assert.That(() => str.ToInt(loggerMock), Throws.ArgumentNullException);
        }
        
        [Test]
        [TestCaseSource(nameof(correctStringTestCases))]
        public void StringToInt_CorrectString_ReturnedExpectedInt(string str, int expected)
        {
            var actual = str.ToInt(loggerMock);
            Assert.AreEqual(expected, actual);
        }

    }
}