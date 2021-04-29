using System;

namespace Performance
{
    public class C : IComparable<C>
    {
        private readonly int i;

        public C(int i)
        {
            this.i = i;
        }

        public int CompareTo(C other)
        {
            return this.i.CompareTo(other.i);
        }
    }
}