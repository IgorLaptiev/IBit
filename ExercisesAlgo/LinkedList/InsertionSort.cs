using ConsoleDump;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExercisesAlgo.LinkedList
{
    public class InsertionSort
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
            var result = insertionSortList(la);
            while (result != null)
            {
                result.val.Dump();
                result = result.next;
            }
        }

        public ListNode insertionSortList(ListNode A)
        {
            var head = A;
            var previous = A;
            var currentNode = previous.next;
            while (currentNode != null)
            {
                if(previous.val > currentNode.val)
                {
                    if (currentNode.val < head.val)
                    {
                        head = setBefore(head, currentNode, previous);
                    }
                    else
                    {
                        var place = findPlace(head, currentNode);
                        if (place != null)
                        {
                            place.next = setBefore(place.next, currentNode, previous);
                        }
                    }
                    currentNode = previous.next;
                }
                else
                {
                    previous = currentNode;
                    currentNode = currentNode.next;
                }
            }
            return head;
        }

        public ListNode findPlace(ListNode first, ListNode toFind)
        {
            var current = first;
            while(current.next != null && toFind.val > current.next.val)
            {
                current = current.next;
            }
            return current;
        }

        public ListNode setBefore(ListNode next, ListNode node, ListNode prev)
        {
            prev.next = node.next;
            node.next = next;
            return node;
        }

        public void insertAfter(ListNode first, ListNode second, ListNode prev)
        {
            var tmp = first.next;
            first.next = second;
            if (prev != null)
            {
                prev.next = second.next;
            }
            second.next = tmp;
        }
    }
}
