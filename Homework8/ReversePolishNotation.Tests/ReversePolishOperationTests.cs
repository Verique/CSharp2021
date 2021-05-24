using NUnit.Framework;

namespace ReversePolishNotation.Tests
{
    [TestFixture]
    public class ReversePolishOperationTests
    {
        [Test]
        [TestCase("2 3 + ", 5)]
        [TestCase("-7,5 2 *", -15)]
        [TestCase("5 -9 -", 14)]
        [TestCase("   ", 0)]
        [TestCase(" 5  1 2    + 4   * + 3 -  ", 14)]
        public void Calculate_InputInRPN_ReturnedExpected(string input, double expected)
        {
            Assert.That(ReversePolishOperation.Calculate(input), Is.EqualTo(expected));
        }

        [Test]
        [TestCase("saf")]
        [TestCase("5 - 6")]
        [TestCase("7 - *")]
        public void Calculate_InputWrongFormat_ThrownArgumentException(string input)
        {
            Assert.That(() => ReversePolishOperation.Calculate(input), Throws.ArgumentException);
        }
    }
}