using System;
using NUnit.Framework;

namespace LinqDemo.Tests
{
    [TestFixture]
    public class StudentTestResultsTests
    {
        [Test]
        public void Search_MinMarkMaxMarkSortAreSet_ReturnedExpected()
        {
            var target = new[]
            {
                new TestResult("Alex Black", "Chemistry", new DateTime(2021, 12, 7), 2),
                new TestResult("Alex Black", "Math", new DateTime(2021, 12, 7), 3),
                new TestResult("Alex Black", "Literature", new DateTime(2021, 12, 7), 4),
                new TestResult("Alex Black", "Math", new DateTime(2021, 12, 15), 5)
            };

            var expected = new[]
            {
                new TestResult("Alex Black", "Literature", new DateTime(2021, 12, 7), 4),
                new TestResult("Alex Black", "Math", new DateTime(2021, 12, 7), 3)
            };

            var criteria = "-maxMark 4 -minMark 3 -sort test asc";

            var actual = StudentTestResults.Search(target, criteria);

            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void Search_NameSortAreSet_ReturnedExpected()
        {
            var target = new[]
            {
                new TestResult("Alex Black", "Chemistry", new DateTime(2021, 12, 7), 2),
                new TestResult("Alex Black", "Math", new DateTime(2021, 12, 7), 3),
                new TestResult("John Black", "Literature", new DateTime(2021, 12, 7), 4),
                new TestResult("John Black", "Math", new DateTime(2021, 12, 15), 5)
            };

            var expected = new[]
            {
                new TestResult("John Black", "Math", new DateTime(2021, 12, 15), 5),
                new TestResult("John Black", "Literature", new DateTime(2021, 12, 7), 4)
            };

            var criteria = "-name John -sort mark desc";

            var actual = StudentTestResults.Search(target, criteria);

            Assert.That(actual, Is.EqualTo(expected));
        }


        [Test]
        public void Search_TestNameDateToAreSet_ReturnedExpected()
        {
            var target = new[]
            {
                new TestResult("Alex Black", "Chemistry", new DateTime(2021, 12, 7), 2),
                new TestResult("Alex Black", "Math", new DateTime(2021, 12, 7), 3),
                new TestResult("John Black", "Literature", new DateTime(2021, 12, 7), 4),
                new TestResult("John Black", "Math", new DateTime(2021, 12, 15), 5)
            };

            var expected = new[]
            {
                new TestResult("Alex Black", "Math", new DateTime(2021, 12, 7), 3)
            };

            var criteria = "  -test   Math -dateTo  07.12.2021  ";

            var actual = StudentTestResults.Search(target, criteria);

            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        [TestCase("-te st")]
        [TestCase("test d")]
        [TestCase("-test math math")]
        [TestCase("-test -sort math")]
        [TestCase("-test Math -sort test")]
        [TestCase("-test")]
        [TestCase("Math")]
        [TestCase(" ")]
        [TestCase(null)]
        public void Search_WrongCriteria_ThrownArgumentException(string criteria)
        {
            var target = new[]
            {
                new TestResult("Alex Black", "Chemistry", new DateTime(2021, 12, 7), 2),
                new TestResult("Alex Black", "Math", new DateTime(2021, 12, 7), 3),
                new TestResult("John Black", "Literature", new DateTime(2021, 12, 7), 4),
                new TestResult("John Black", "Math", new DateTime(2021, 12, 15), 5)
            };

            Assert.That(() => StudentTestResults.Search(target, criteria), Throws.ArgumentException);
        }

        public void WriteCollection_IEnumerableIsNull_ThrownArgumentNullException()
        {
            Assert.That(() => StudentTestResults.WriteCollection(null), Throws.ArgumentNullException);
        }

        public void WriteCollection_IEnumerableIsNotNull_ThrownNothing()
        {
            Assert.That(() => StudentTestResults.WriteCollection(new TestResult[]{}), Throws.Nothing);
        }
    }
}