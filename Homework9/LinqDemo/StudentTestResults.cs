using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;

namespace LinqDemo
{
    public class StudentTestResults
    {
        public IEnumerable<TestResult> Collection { get; private set; }
        private const string SortOptionName = "name";
        private const string SortOptionDate = "date";
        private const string SortOptionMark = "mark";
        private const string SortOptionTest = "test";

        private static readonly CriteriaFilter[] Filters = new[]
        {
            new CriteriaFilter("-name", 1,
                (value, collection) => collection.Where(result => (result.Name.Contains(value)))),
            new CriteriaFilter("-test", 1,
                (value, collection) => collection.Where(result => (result.TestName.Contains(value)))),
            new CriteriaFilter("-maxmark", 1,
                (value, collection) => collection.Where(result => (result.Mark <= int.Parse(value)))),
            new CriteriaFilter("-minmark", 1,
                (value, collection) => collection.Where(result => (result.Mark >= int.Parse(value)))),
            new CriteriaFilter("-datefrom", 1,
                (value, collection) => collection.Where(result => (result.Date >= (DateTime.Parse(value))))),
            new CriteriaFilter("-dateto", 1,
                (value, collection) => collection.Where(result => (result.Date <= (DateTime.Parse(value))))),
            new CriteriaFilter("-sort", 2, Sort)
        };

        public StudentTestResults(IEnumerable<TestResult> results)
        {
            Collection = results ?? throw new ArgumentNullException();
        }

        public StudentTestResults() : this(new TestResult[] { })
        { }

        public void LoadFromJsonFile(string path)
        {
            var jsonText = File.ReadAllText(path);
            Collection = (JsonSerializer.Deserialize<IEnumerable<TestResult>>(jsonText) ??
                          throw new InvalidOperationException());
        }

        public IEnumerable<TestResult> Search(string input)
        {
            if (input is null)
            {
                throw new ArgumentException();
            }

            var returnCollection = Collection;
            var criterias = input.Split(" ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);

            for (var i = 0; i < criterias.Length; i++)
            {
                criterias[i] = criterias[i].ToLower();
                
                if (!criterias[i].StartsWith("-")) throw new ArgumentException("Wrong format");

                var currentCriteria = Filters.Where((filter => (filter.Criteria == criterias[i]))).FirstOrDefault();

                if (currentCriteria is null)
                {
                    throw new ArgumentException($"There is no {criterias[i]} criteria");
                }

                var currentValue = new StringBuilder("");

                for (var j = 0; j < currentCriteria.ParamCount; j++)
                {
                    try
                    {
                        currentValue.Append(criterias[i + 1 + j]);
                    }
                    catch (IndexOutOfRangeException)
                    {
                        throw new ArgumentException("Wrong Format");
                    }

                    if (currentCriteria.ParamCount > 1)
                    {
                        currentValue.Append(" ");
                    }
                }

                returnCollection = SearchByCriteria(returnCollection, currentCriteria, currentValue.ToString());

                i += currentCriteria.ParamCount;
            }

            return returnCollection;
        }

        private static IEnumerable<TestResult> SearchByCriteria(IEnumerable<TestResult> collection,
            CriteriaFilter criteria, string value)
        {
            return criteria.Action(value, collection);
        }

        private static IEnumerable<TestResult> Sort(string value, IEnumerable<TestResult> collection)
        {
            var parameters = value.Split(" ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
            IEnumerable<TestResult> returnCollection;

            switch (parameters[0].ToLower())
            {
                case SortOptionName:
                    returnCollection = collection.OrderBy(result => result.Name);
                    break;
                case SortOptionDate:
                    returnCollection = collection.OrderBy(result => result.Date);
                    break;
                case SortOptionMark:
                    returnCollection = collection.OrderBy(result => result.Mark);
                    break;
                case SortOptionTest:
                    returnCollection = collection.OrderBy(result => result.TestName);
                    break;
                default:
                    throw new ArgumentException($"There is no {parameters[0].ToLower()} field");
            }

            if (string.CompareOrdinal(parameters[1], "desc") == 0)
            {
                returnCollection = returnCollection.Reverse();
            }

            return returnCollection;
        }
    }
}