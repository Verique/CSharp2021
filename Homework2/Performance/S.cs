using System;

namespace Performance
{
    public readonly struct S : IComparable<S>
    {
        private readonly int i;

        public S(int i)
        {
            this.i = i;
        }

        public int CompareTo(S other)
        {
            return this.i.CompareTo(other.i);
        }
    }
}