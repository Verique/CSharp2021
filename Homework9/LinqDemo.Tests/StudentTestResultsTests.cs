using System;
using FluentAssertions;
using NUnit.Framework;

namespace LinqDemo.Tests
{
    
    [TestFixture]
    public class StudentTestResultsTests
    {
        [Test]
        public void Search_MinMarkMaxMarkSortAreSet_ReturnedExpected()
        {
            var collection = new[]
            {
                new TestResult("Alex Black", "Chemistry", new DateTime(2021, 12, 7), 2),
                new TestResult("Alex Black", "Math", new DateTime(2021, 12, 7), 3),
                new TestResult("Alex Black", "Literature", new DateTime(2021, 12, 7), 4),
                new TestResult("Alex Black", "Math", new DateTime(2021, 12, 15), 5)
            };

            var target = new StudentTestResults(collection);

            var expected = new[]
            {
                new TestResult("Alex Black", "Literature", new DateTime(2021, 12, 7), 4),
                new TestResult("Alex Black", "Math", new DateTime(2021, 12, 7), 3)
            };

            const string criteria = "-maxMark 4 -minMark 3 -sort test asc";

            var actual = target.Search(criteria);

            actual.Should().BeEquivalentTo<TestResult>(expected);
        }

        [Test]
        public void Search_NameSortAreSet_ReturnedExpected()
        {
            var collection = new[]
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

            var target = new StudentTestResults(collection);
            const string criteria = "-name John -sort mark desc";

            var actual = target.Search(criteria);

            actual.Should().BeEquivalentTo<TestResult>(expected);
        }


        [Test]
        public void Search_TestNameDateToAreSet_ReturnedExpected()
        {
            var collection = new[]
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

            const string criteria = "  -test   Math -dateTo  07.12.2021  ";
            var target = new StudentTestResults(collection);

            var actual = target.Search(criteria);

            actual.Should().BeEquivalentTo<TestResult>(expected);

        }

        [Test]
        [TestCase("-te st")]
        [TestCase("test d")]
        [TestCase("-test math math")]
        [TestCase("-test -sort math")]
        [TestCase("-test Math -sort test")]
        [TestCase("-test")]
        [TestCase("Math")]
        [TestCase(null)]
        public void Search_WrongCriteria_ThrownArgumentException(string criteria)
        {
            var collection = new[]
            {
                new TestResult("Alex Black", "Chemistry", new DateTime(2021, 12, 7), 2),
                new TestResult("Alex Black", "Math", new DateTime(2021, 12, 7), 3),
                new TestResult("John Black", "Literature", new DateTime(2021, 12, 7), 4),
                new TestResult("John Black", "Math", new DateTime(2021, 12, 15), 5)
            };

            var target = new StudentTestResults(collection);
            Action act = () => target.Search(criteria);

            act.Should().Throw<ArgumentException>();
        }
    }
}