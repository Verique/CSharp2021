﻿using System;

namespace GenericCollectionsLibrary
{
    public class GenericQueue<T>
    {
        private Node<T> head;

        public bool IsEmpty => (head is null);

        public GenericQueue()
        {
            head = null;
        }

        public T Peek()
        {
            if (head is null)
            {
                throw new InvalidOperationException("Queue is empty");
            }

            return head.Data;
        }

        public T Pop()
        {
            if (head is null)
            {
                throw new InvalidOperationException("Queue is empty");
            }

            var returnData = head.Data;
            head = head.Next;
            return returnData;
        }

        public void Push(T data)
        {
            var newNode = new Node<T>(data, null);

            if (head == null)
            {
                head = newNode;
            }
            else
            {
                var tmp = head;

                while (tmp.Next != null)
                {
                    tmp = tmp.Next;
                }

                tmp.Next = newNode;
            }
        }

        public IMyIterator<T> GetIterator()
        {
            return new MyIterator<T>(head);
        }
    }
}