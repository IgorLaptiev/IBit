using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ConsoleDump;

namespace ExercisesAlgo.LinkedList
{
    public class RotateList
    {
        public void Execute()
        {
            var la = new ListNode(1)
            {
                next = new ListNode(2)
                {
                    next = new ListNode(3)
                    {
                        next = new ListNode(5)
                        {
                            next = new ListNode(6)
                            {
                                next = new ListNode(9)
                                {
                                    next = new ListNode(10)
                                }
                            }
                        }

                    }
                }
            };

            var result = rotateRight(la,0);
            while (result != null)
            {
                result.val.Dump();
                result = result.next;
            }
        }

        public ListNode rotateRight(ListNode A, int B)
        {
            var shift = 0;
            var firstnode = A;
            var head = A;
            var length = Length(A);
            B = B % length;
            if (B==0) return A;
            while (A.next != null)
            {
                shift++;
                var prev = A;
                A = A.next;
                if (shift <= length - B)
                {
                    head = A;
                    if (shift == length - B)
                    {
                        prev.next = null;
                    }
                }
            }

            A.next = firstnode;
            return head;
        }

        public int Length(ListNode A)
        {
            var cnt = 0;
            while (A != null)
            {
                cnt++;
                A = A.next;
            }

            return cnt;
        }
    }
}
