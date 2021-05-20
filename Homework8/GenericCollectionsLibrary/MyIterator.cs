using System;

namespace GenericCollectionsLibrary
{
    public class MyIterator<T> : IMyIterator<T>
    {
        private Node<T> node;

        public bool MoveNext()
        {
            if (node is null)
            {
                return false;
            }

            node = node.Next;
            return (!(node is null));
        }

        public T Current => node.Data;

        public MyIterator(Node<T> node)
        {
            this.node = node;
        }
    }
}