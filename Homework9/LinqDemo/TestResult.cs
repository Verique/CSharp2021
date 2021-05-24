using System;

namespace LinqDemo
{
    [Serializable]
    public class TestResult
    {
        public string Name { get; private set; }
        public string TestName { get; private set; }
        public DateTime Date { get; private set; }
        public int Mark { get; private set; }

        public TestResult(string name, string testName, DateTime date, int mark)
        {
            Name = name;
            TestName = testName;
            Date = date;
            Mark = mark;
        }

        public override string ToString()
        {
            return string.Concat(Name, " | ", TestName, " | ", Date.ToShortDateString(), " | ", Mark);
        }

        public override bool Equals(object obj)
        {
            return obj != null && ToString().Equals(obj.ToString());
        }

        public override int GetHashCode()
        {
            return ToString().GetHashCode();
        }
    }
}