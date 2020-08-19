using ConsoleDump;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExercisesAlgo.Queues
{
    public class SlidingMax
    {

        public void Execute()
        {
            //slidingMaximum(new List<int> { 1, 3, -1, -3, 5, 3, 6, 7 }, 3).Dump();
            slidingMaximum(new List<int> { 10, 9, 8, 7, 6, 5, 4, 3, 2, 1 }, 2).Dump();
        }

        public List<int> slidingMaximum(List<int> A, int B)
        {
            if (B == 1) return A;
            var result = new List<int>();
            var queue = new DQueue(B);
            int i = 0;
            while (i < B)
            {
                queue.Push(i, A[i]);
                i++;
            }
            result.Add(queue.Peek());
            for (; i < A.Count; i++)
            {
                queue.Push(i, A[i]);
                result.Add(queue.Peek());
            }
            return result;
        }


        public List<int> slidingMaximumQ(List<int> A, int B)
        {
            if (B == 1) return A;
            var result = new List<int>();
            var queue = new Queue();
            var i = 0;
            var j = 0;
            while(j < B)
            {
                queue.Push(j, A[j]);
                j++;
            }
            result.Add(queue.Peek());
            while (j < A.Count)
            {
                queue.Pop();
                queue.Push(j, A[j]);
                result.Add(queue.Peek());

                i++;
                j++;
            }
            return result;
        }

        public List<int> slidingMaximumDumb(List<int> A, int B)
        {
            var result = new List<int>();
            var i = 0;
            var j = i + B;
            do
            {
                var max = Int32.MinValue;
                for (var k = i; k < j && k < A.Count; k++)
                {
                    if (A[k] > max)
                    {
                        max = A[k];
                    }
                }
                result.Add(max);
                i++;
                j++;
            }
            while (j <= A.Count);
            return result;
        }
    }
    public class DNode
    {
        public int Position { get; set; }

        public int Value { get; set; }

        public DNode(int pos, int val)
        {
            Position = pos;
            Value = val;
        }
    }

    public class DQueue
    {
        private readonly int _capacity;
        List<DNode> _list = new List<DNode>();

        public DQueue(int capacity)
        {
            _capacity = capacity;
        }

        public void Push(int pos, int val)
        {
            for (int i = _list.Count -1 ; i >=0; i--)
            {
                if(_list[i].Value < val)
                {
                    _list.RemoveAt(i);
                }
                else
                {
                    break;
                }
            }
            if(_list.Count>0 && (pos - _list[0].Position +1 > _capacity))
            {
                _list.RemoveAt(0);
            }
            _list.Add(new DNode(pos, val));
        }

        public int Peek()
        {
            if (_list.Count == 0) return Int32.MinValue;
            return _list[0].Value;
        }
    }

    public class Node
    {
        public Node NextM { get; set; }

        public Node Next { get; set; }

        public Node Previous { get; set; }

        public Node PreviousM { get; set; }

        public int Position { get; set; }

        public int Value { get; set; }
    }

    public class Queue
    {
        Node headMax;
        Node headPos;
        Node lastM;
        Node lastP;
        public int Count { get; set; }

        public Queue()
        {
            Count = 0;
            headMax = new Node() { Position = -1, Value = Int32.MinValue };
            headPos = headMax;
            lastM = headMax;
            lastP = headPos;
        }

        public void Push(int pos, int value)
        {
            var currM = headMax;
            while (currM.NextM != null && currM.NextM.Value > value)
            {
                currM = currM.NextM;
            }
            var tmp = currM.NextM;
            currM.NextM = new Node() { Position = pos, Value = value, NextM = tmp, Previous = lastP, PreviousM = currM };
            if (tmp != null)
            {
                tmp.PreviousM = currM.NextM;
            }
            lastP.Next = currM.NextM;
            lastP = lastP.Next;
            Count++;
          //  Console.WriteLine($"Push {pos} {value}");
          //  Print();
        }

        private void Print()
        {
            var c = headPos.Next;
            while (c != null)
            {
                Console.Write(c.Value);
                Console.Write("->");
                c = c.Next;
            }
            Console.WriteLine();

            c = headMax.NextM;
            while (c != null)
            {
                Console.Write(c.Value);
                Console.Write("->");
                c = c.NextM;
            }
            Console.WriteLine();
        }

        public void Pop()
        {
            if (Count == 0) return;
            var node = headPos.Next;
            if (node !=null)
            {
                node.PreviousM.NextM = node.NextM;
                if (node.NextM != null)
                {
                    node.NextM.PreviousM = node.PreviousM;
                }
                node.Next.Previous = headPos;
                headPos.Next = node.Next;
                Count--;
            }
            //Console.WriteLine($"Pop {node.Value}");
            //Print();
        }

        public int Peek()
        {
            if (Count == 0) return Int32.MinValue;

            return headMax.NextM.Value;
        }
    }

}
