using System;
using System.Collections;
using System.Collections.Generic;

namespace GenericCollectionsLibrary
{
    public class MyIterator<T> : IEnumerator<T>
    {
        private readonly Node<T> headNode;
        private Node<T> currentNode;

        public bool MoveNext()
        {
            if (currentNode is null)
            {
                return false;
            }

            currentNode = currentNode.Next;
            return (!(currentNode is null));
        }

        public void Reset()
        {
            currentNode = headNode;
        }

        object IEnumerator.Current => currentNode.Data;

        public T Current => currentNode.Data;

        public MyIterator(Node<T> currentNode)
        {
            this.currentNode = currentNode;
            headNode = currentNode;
        }
        public void Dispose() { }
    }
}