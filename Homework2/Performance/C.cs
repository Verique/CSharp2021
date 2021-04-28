using System;

namespace Performance
{
    public class C : IComparable<C>
    {
        private readonly int _i;

        public C(int i)
        {
            _i = i;
        }

        public int CompareTo(C other)
        {
            return _i.CompareTo(other._i);
        }
    }
}