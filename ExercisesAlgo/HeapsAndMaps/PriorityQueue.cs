using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace ExercisesAlgo.HeapsAndMaps
{

    public class PriorityQueue<T> : IEnumerable<T>
      where T : IComparable
    {
        List<T> data = new List<T>();

        public void Enqueue(T value)
        {
            data.Add(value);
            MoveUp(data.Count - 1);
        }

        public T Peek()
        {
            return data.FirstOrDefault();
        }

        public T Tail()
        {
            return data.Last();
        }

        public T Dequeue()
        {
            var res = data.FirstOrDefault();
            data[0] = data.Last();
            data.RemoveAt(data.Count - 1);
            MoveDown(0);
            return res;
        }

        public void RemoveTail()
        {
            data.RemoveAt(data.Count - 1);
        }

        private void MoveDown(int ind)
        {
            var last = data.Count - 1;
            var left = (ind * 2) + 1;
            var right = (ind * 2) + 2;
            if (right > last)
            {
                if (left <= last && data[left].CompareTo(data[ind]) > 0)
                {
                    Swap(left, ind);
                }
            }
            else if (data[left].CompareTo(data[right]) > 0 && data[left].CompareTo(data[ind])> 0)
            {
                Swap(left, ind);
                MoveDown(left);
            }
            else if (data[right].CompareTo(data[left]) > 0  && data[right].CompareTo(data[ind]) > 0)
            {
                Swap(right, ind);
                MoveDown(right);
            }
        }

        private void MoveUp(int ind)
        {
            var parentInd = (ind - 1) / 2;
            if (parentInd < 0) return;
            if (data[parentInd].CompareTo(data[ind]) < 0)
            {
                Swap(ind, parentInd);
                MoveUp(parentInd);
            }
        }

        private void Swap(int ind, int ind2)
        {
            var temp = data[ind];
            data[ind] = data[ind2];
            data[ind2] = temp;
        }

        public IEnumerator<T> GetEnumerator()
        {
            return data.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return data.GetEnumerator();
        }
    }

    public class PriorityList<T> : IEnumerable<T>
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