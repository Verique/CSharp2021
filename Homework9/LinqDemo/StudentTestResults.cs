using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LinqDemo
{
    public static class StudentTestResults
    {
        private static readonly CriteriaFilter[] Filters = new []
        {
            new CriteriaFilter("-name", 1, (value, collection) => collection.Where(result => (result.Name.Contains(value)))),
            new CriteriaFilter("-test", 1, (value, collection) => collection.Where(result => (result.TestName.Contains(value)))),
            new CriteriaFilter("-maxmark", 1, (value, collection) => collection.Where(result => (result.Mark <= int.Parse(value)))),
            new CriteriaFilter("-minmark", 1, (value, collection) => collection.Where(result => (result.Mark >= int.Parse(value)))),
            new CriteriaFilter("-datefrom", 1, (value, collection) => collection.Where(result => (result.Date >= (DateTime.Parse(value))))),
            new CriteriaFilter("-dateto", 1, (value, collection) => collection.Where(result => (result.Date <= (DateTime.Parse(value))))),
            new CriteriaFilter("-sort", 2, Sort)
        };


        private static IEnumerable<TestResult> Sort(string value, IEnumerable<TestResult> collection)
        {
            var parameters = value.Split(" ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);

            switch (parameters[0].ToLower())
            {
                case "name":
                    collection = collection.OrderBy(result => result.Name);
                    break;
                case "date":
                    collection = collection.OrderBy(result => result.Date);
                    break;
                case "mark":
                    collection = collection.OrderBy(result => result.Mark);
                    break;
                case "test":
                    collection = collection.OrderBy(result => result.TestName);
                    break;
                default:
                    throw new ArgumentException($"There is no {parameters[0].ToLower()} field");
            }

            if (string.CompareOrdinal(parameters[1], "desc") == 0)
            {
                collection = collection.Reverse();
            }

            return collection;
        }
        
        public static void WriteCollection(IEnumerable<TestResult> col, string colName = "")
        {
            if (col is null)
            {
                throw new ArgumentNullException(nameof(col));
            }
            
            Console.WriteLine(colName);
            Console.WriteLine("Name | TestName | Date | Mark");
            Console.WriteLine("-------------------------------");
            
            foreach (var testResult in col)
            {
                Console.WriteLine(testResult.ToString());
            }
        }

        private static IEnumerable<TestResult> SearchByCriteria(IEnumerable<TestResult> collection, CriteriaFilter criteria, string value)
        {
            if (criteria is null)
            {
                throw new ArgumentNullException(nameof(criteria));
            }

            return criteria.Action(value, collection);
        }

        public static IEnumerable<TestResult> Search(IEnumerable<TestResult> collection, string input)
        {
            if (string.IsNullOrWhiteSpace(input))
            {
                throw new ArgumentException();
            }
            
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
                    catch (IndexOutOfRangeException e)
                    {
                        throw new ArgumentException("Wrong Format");
                    }

                    if (currentCriteria.ParamCount > 1)
                    {
                        currentValue.Append(" ");
                    }
                }

                collection = SearchByCriteria(collection, currentCriteria, currentValue.ToString());

                i += currentCriteria.ParamCount;
            }

            return collection;
        } 
    }
}