using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ConsoleDump;

namespace ExercisesAlgo.LinkedList
{
    public class PalindromeList
    {
        public void Execute()
        {
            var la = new ListNode(1)
                         {
                             next = new ListNode(2)
                                        {
                                            next = new ListNode(3)
                                                       {
                                                           next = new ListNode(3)
                                                                      {
                                                                          next = new ListNode(2)
                                                                                     {
                                                                                         next = new ListNode(1)
                                                                                     }
                                                                      }
                                                       }
                                        }
                         };

            lPalin(la).Dump();
        }

        public int lPalin(ListNode A)
        {
            if (A == null) return 0;
            var length = this.length(A);
            if (length == 1) return 1;
            if (testPalindrom(A, length, out var tail))
            {
                return 1;
            }

            return 0;
        }

        private bool testPalindrom(ListNode head, int length, out ListNode tail)
        {
            tail = null;
            if (length == 1)
            {
                tail = head.next;
                return true;
            }

            if (length == 2)
            {
                tail = head.next.next;
                return head.val == head.next.val;
            }
            
            var savehead = head;
            var isPalindrome = testPalindrom(head.next, length-2, out var innertail);

            if (innertail != null)
            {
                isPalindrome = isPalindrome && savehead.val == innertail.val;
                tail = innertail.next;
            }
            return isPalindrome;

        }
        private int length(ListNode list)
        {
            int length = 1;
            while (list.next != null)
            {
                length++;
                list = list.next;
            }

            return length;
        }
    }
}
