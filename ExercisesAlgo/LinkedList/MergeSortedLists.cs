using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ConsoleDump;

namespace ExercisesAlgo.LinkedList
{
    public class MergeSortedLists
    {
        public void Execute()
        {
            var la = new ListNode(12)
            {
                next = new ListNode(22)
                {
                    next = new ListNode(27)
                    {
                        next = new ListNode(29)
                    }
                }
            };
            var lb = new ListNode(7)
            {
                next = new ListNode(12)
                {
                    next = new ListNode(46)
                }
            };
            var result = mergeTwoLists(la, lb);
            while (result != null)
            {
                result.val.Dump();
                result = result.next;
            }
        }

        public ListNode mergeTwoLists(ListNode A, ListNode B)
        {
            if (B.val < A.val) return mergeTwoLists(B, A);
            var newList = A;
            while (A !=null)
            {
                while (B!=null && B.val >= A.val && (A.next == null || B.val < A.next.val))
                {
                    var oldnext = A.next;
                    
                    A.next = B;
                    B = B.next;
                    if (A.next != null)
                    {
                        A.next.next = oldnext;
                    }
                }

                A = A.next;
            }

            return newList;
        }
    }
}
