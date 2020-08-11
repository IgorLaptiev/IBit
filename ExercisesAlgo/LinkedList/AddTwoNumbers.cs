using ConsoleDump;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExercisesAlgo.LinkedList
{
    public class AddTwoNumbers
    {
        public void Execute()
        {
            var a = new ListNode(9, 9, 1, 0);
            var b = new ListNode(1);
            var result = addTwoNumbers(a, b);
            while (result != null)
            {
                result.val.Dump();
                result = result.next;
            }
        }

        public ListNode addTwoNumbers(ListNode A, ListNode B)
        {
            var result = new ListNode(0);
            var curreResult = result;
            var currentA = A;
            var currentB = B;
            var shift = 0;
            while(currentA != null || currentB != null)
            {
                var dig = getNullable(currentA) + getNullable(currentB) + shift;
                shift = dig >= 10 ? 1 : 0;
                dig = dig % 10;
                curreResult.next = new ListNode(dig);
                curreResult = curreResult.next;
                currentA = currentA == null ? currentA : currentA.next;
                currentB = currentB == null ? currentB : currentB.next;
            }
            if (shift > 0)
            {
                curreResult.next = new ListNode(shift);
            }
            return result.next;
        }

        private Int32 getNullable(ListNode node)
        {
            if (node == null) return 0;
            return node.val;
        }

    }

    public class AddTwoNumbersSimple
    {
        public void Execute()
        {
            var a = new ListNode(9, 9, 1);
            var b = new ListNode(1);
            var result = addTwoNumbers(a, b);
            while (result != null)
            {
                result.val.Dump();
                result = result.next;
            }
        }

        public ListNode addTwoNumbers(ListNode A, ListNode B)
        {
            var a = getNumber(A);
            var b = getNumber(B);
            return toList(a + b);
        }

        private Int32 getNumber(ListNode root)
        {
            var current = root;
            var result = 0;
            var dec = 0;
            while (current != null)
            {
                result = result + Convert.ToInt32(current.val * Math.Pow(10, dec));
                dec++;
                current = current.next;
            }
            return result;
        }

        private ListNode toList(Int32 number)
        {
            var numb = number;
            var head = new ListNode(0);
            var current = head;
            while (numb > 0)
            {
                var dig = (numb % 10);
                current.next = new ListNode(dig);
                current = current.next;
                numb = Convert.ToInt32(numb / 10);
            }
            return head.next;
        }
    }
}
