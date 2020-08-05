using ConsoleDump;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExercisesAlgo.LinkedList
{
    public class MergeSort
    {
        public void Execute()
        {
            //            A: [5, 66, 68, 42, 73, 25, 84, 63, 72, 20, 77, 38, 8, 99, 92, 49, 74, 45, 30, 51, 50, 95, 56, 19, 31, 26, 98, 67, 100, 2, 24, 6, 37, 69, 11, 16, 61, 23, 78, 27, 64, 87, 3, 85, 55, 22, 33, 62]

            var la = new ListNode(new[] { 5, 66,
                68,
                42, 73,
                25, 84, 63, 72, 20
                , 77, 38, 8, 99, 92, 49, 74, 45, 30, 51, 50, 95, 56, 19, 31, 26, 98, 67, 100, 2, 24, 6, 37, 69, 11, 16, 61, 23, 78, 27, 64, 87, 3, 85, 55, 22, 33, 62
            });
            var result = sortList(la);
            while (result != null)
            {
                result.val.Dump();
                result = result.next;
            }
        }

        public ListNode sortList(ListNode A)
        {
            var length = count(A);
            if (length == 1)
            {
                return A;
            }
            var head = A;
            var tail = split(head, length);
            head = sortList(head);
            tail = sortList(tail);
            return merge(head, tail);
        }

        public ListNode merge(ListNode first, ListNode second)
        {
            var sorted = new ListNode(Int32.MinValue);
            var sortedCurrent = sorted;
            var current1 = first;
            var current2 = second;
            while (current1 != null && current2 != null)
            {
                if (current1.val <= current2.val)
                {
                    var next = current1.next;
                    sortedCurrent = addToSorted(sortedCurrent, current1);
                    current1 = next;
                }
                else
                {
                    var next = current2.next;
                    sortedCurrent = addToSorted(sortedCurrent, current2);
                    current2 = next;
                }
            }
            if (current1 == null)
            {
                sortedCurrent.next = current2;
            }
            else
            {
                sortedCurrent.next = current1;
            }
            return sorted.next;
        }

        public ListNode addToSorted(ListNode sorted, ListNode insert)
        {
            sorted.next = insert;
            insert.next = null;
            return insert;
        }

        public int count(ListNode list)
        {
            var cnt = 0;
            while (list != null)
            {
                cnt++;
                list = list.next;
            }
            return cnt;
        }

        public ListNode split(ListNode list, int length)
        {
            var cnt = 0;
            ListNode tail = null;
            while (list != null && cnt < (length / 2 - 1))
            {
                cnt++;
                list = list.next;
            }
            if (list != null)
            {
                tail = list.next;
                list.next = null;
            }
            return tail;
        }
    }
}
