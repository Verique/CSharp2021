using System;

namespace Performance
{
    public readonly struct S : IComparable<S>
    {
        private readonly int _i;

        public S(int i)
        {
            this._i = i;
        }

        public int CompareTo(S other)
        {
            return _i.CompareTo(other._i);
        }
    }
}