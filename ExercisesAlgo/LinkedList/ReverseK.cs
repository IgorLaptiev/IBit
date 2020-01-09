using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleDump;

namespace ExercisesAlgo.LinkedList
{
    public class ReverseK
    {
        public void Execute()
        {
            var la = new ListNode(1)
            {
                next = new ListNode(2)
                {
                    next = new ListNode(3)
                    {
                        next = new ListNode(4)
                        {
                            next = new ListNode(5)
                            {
                                next = new ListNode(6)
                                {
                                    //next = new ListNode(7)
                                }
                            }
                        }

                    }
                }
            };

            var result = reverseList(la, 3);
            while (result != null)
            {
                result.val.Dump();
                result = result.next;
            }
        }

        public ListNode reverseList(ListNode A, int B)
        {
            if (B == 1) return A;
            ListNode head = null;
            ListNode prevtail = null;
            var current = A;
            var currentchain = A;
            var previouschain = A;
            var cnt = 1;
            while (current != null)
            {
                if (cnt == B)
                {
                    if (head == null)
                    {
                        head = currentchain;
                    }
                    cnt = 1;
                    prevtail = current;
                    current = current.next;
                    currentchain = current;
                    previouschain = current;
                }
                else
                {
                    currentchain = current.next;
                    var chainNext = currentchain.next;
                    currentchain.next = previouschain;
                    previouschain = currentchain;
                    current.next = chainNext;
                    if (prevtail != null)
                    {
                        prevtail.next = previouschain;
                    }
                    cnt++;
                }
            }

            return head;
        }
    }
}
