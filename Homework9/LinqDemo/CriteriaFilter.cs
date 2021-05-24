using System;
using System.Collections.Generic;

namespace LinqDemo
{
    public class CriteriaFilter
    {
        public string Criteria { get; }
        public int ParamCount { get; }
        public Func<string, IEnumerable<TestResult>, IEnumerable<TestResult>> Action { get; }

        public CriteriaFilter(string criteria, int paramCount, Func<string, IEnumerable<TestResult>, IEnumerable<TestResult>> action)
        {
            Criteria = criteria;
            ParamCount = paramCount;
            Action = action;
        }
    }
}