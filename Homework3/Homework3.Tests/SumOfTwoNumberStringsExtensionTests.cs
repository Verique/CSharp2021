using System;
using System.Collections.Generic;
using NUnit.Framework;
using System.Numerics;

namespace Homework3.Tests
{
    [TestFixture]
    public class SumOfTwoNumberStringsExtensionTests
    {
        private static List<TestCaseData> testCaseData = new List<TestCaseData>(
            new[]
            {
                new TestCaseData("9999", "1", "10000"),
                new TestCaseData("1000000000000000000", "-1", "999999999999999999"),
                new TestCaseData("-500", "1000", "500"),
                new TestCaseData("500", "-1000", "-500"),
                new TestCaseData(int.MinValue.ToString(), "-1", "-2147483649" )
            });
        
        [Test]
        [TestCase("++12","2")]
        [TestCase("dgv", "1")]
        [TestCase("12+42","0")]
        public void SumOfTwoNumberStrings_WrongFormatNumbers_ThrownArgumentException(string a, string b)
        {
            Assert.That(() => a.SumOfTwoNumberStrings(b), Throws.ArgumentException);
        }
        
        [Test]
        [TestCaseSource(nameof(testCaseData))]
        public void SumOfTwoNumberStrings_TwoNumbersGiven_ReturnedSum(string a, string b, string expected)
        {
            var result = a.SumOfTwoNumberStrings(b);

            Assert.That(result, Is.EqualTo(expected));
        }
    }
}