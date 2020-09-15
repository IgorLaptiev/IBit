using System;
using System.Collections;
using System.Collections.Generic;

namespace ExercisesAlgo.HeapsAndMaps
{
    public class PriorityQueue<T> : IEnumerable<T>
        where T : IComparable
    {
        private PTreeNode<T> head = new PTreeNode<T>();
        private PTreeNode<T> tail = null;

        public void Enqueue(T value)
        {
            var current = head;
            while (current.Next != null && current.Next.Data.CompareTo(value) > 0)
            {
                current = current.Next;
            }

            var node = new PTreeNode<T>
            {
                Data = value,
                Next = current.Next,
                Previous = current
            };

            if (current.Next == null)
            {
                tail = node;
            }
            else
            {
                current.Next.Previous = node;
            }

            current.Next = node;

        }

        public IEnumerator<T> GetEnumerator()
        {
            return new PQEnumerator<T>(head);
        }

        public T Peek()
        {
            if (head.Next != null)
            {
                return head.Next.Data;
            }
            return default(T);
        }

        public T Tail()
        {
            return tail.Data;
        }

        public T Pop()
        {
            if (head.Next != null)
            {
                var headData = head.Next.Data;

                head.Next = head.Next.Next;
                if (head.Next != null)
                {
                    head.Next.Previous = head;
                }
                return headData;
            }
            return default(T);
        }

        public void RemoveTail()
        {
            tail = tail.Previous;
            tail.Next = null;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }


    }

    public class PQEnumerator<T> : IEnumerator<T>
    {
        private readonly PTreeNode<T> head;

        private PTreeNode<T> current;

        public T Current { get { return current.Data; } }

        object IEnumerator.Current { get { return Current; } }

        public PQEnumerator(PTreeNode<T> head)
        {
            this.head = head;
            current = head;
        }

        public void Dispose()
        {
        }

        public bool MoveNext()
        {
            current = current.Next;
            return current != null;
        }

        public void Reset()
        {
            current = head;
        }
    }
}