using System.Collections.Specialized;
using System.Data.SqlTypes;
using System.Runtime.InteropServices;
using System.Security;

namespace AddTwoNumbers
{
    /*
     You are given two non-empty linked lists representing two non-negative integers. The digits are stored in reverse order, and each of their nodes contains a single digit. Add the two numbers and return the sum as a linked list.

    You may assume the two numbers do not contain any leading zero, except the number 0 itself.

 

    Example 1:


    Input: l1 = [2,4,3], l2 = [5,6,4]
    Output: [7,0,8]
    Explanation: 342 + 465 = 807.
    Example 2:

    Input: l1 = [0], l2 = [0]
    Output: [0]
    Example 3:

    Input: l1 = [9,9,9,9,9,9,9], l2 = [9,9,9,9]
Output: [8,9,9,9,0,0,0,1]
     */
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");

            ListNode n = new ListNode(2);
            ListNode n2 = new ListNode(4);
            n.next = n2;
            ListNode n3 = new ListNode(3);
            n2.next = n3;
            n3.next = null;

            ListNode n4 = new ListNode(5);
            ListNode n5 = new ListNode(6);
            ListNode n6 = new ListNode(4);
            n4.next = n5;
            n5.next = n6;
            n6.next = null;


            ListNode n10 = new ListNode(9);
            ListNode n11 = new ListNode(9);
            n10.next = n11;
            ListNode n12 = new ListNode(9);
            n11.next = n12;
            ListNode n13 = new ListNode(9);
            n12.next = n13;
            ListNode n14 = new ListNode(9);
            n13.next = n14;
            ListNode n15 = new ListNode(9);
            n14.next = n15;
            ListNode n16 = new ListNode(9);



            ListNode n17 = new ListNode(9);
            ListNode n18 = new ListNode(9);
            n17.next = n18;
            ListNode n19 = new ListNode(9);
            n18.next = n19;
            ListNode n20 = new ListNode(9);
            n19.next = n20;



            var listnode = AddTwoNumbers(n10, n17);
            var q = ListNodeToQueue(listnode);
            Console.WriteLine(System.Text.Json.JsonSerializer.Serialize(q));
        }


        //using Queues
        public static ListNode AddTwoNumbers(ListNode l1, ListNode l2)
        {
            ListNode result = new ListNode();

            var q1 = ListNodeToQueue(l1);
            var q2 = ListNodeToQueue(l2);
            Queue<int> largeQ;
            Queue<int> smallQ;
            ListNode largeNode;

            if (q1.Count >= q2.Count)
            {
                largeQ = q1;
                smallQ = q2;
                largeNode = l1;
            }
            else
            {
                largeQ = q2;
                smallQ = q1;
                largeNode = l2;
            }

            bool hasRem = false;

            if (smallQ.Count == 0)
                return largeNode;

            if (largeQ.Count == 0)
                return result;

            int sum = largeQ.Dequeue() + smallQ.Dequeue();
            hasRem = sum > 9;
            if (!hasRem)
                result.val = sum;

            else
                result.val = sum % 10;

            ListNode prev = result;

            while (largeQ.TryPeek(out _))
            {
                ListNode tempNode = new ListNode();

                sum = largeQ.Dequeue() + (smallQ.Count == 0 ? 0 : smallQ.Dequeue()) + (hasRem ? 1 : 0);

                hasRem = sum > 9;
                if (!hasRem)                
                    tempNode.val = sum;
                
                else                
                    tempNode.val = sum % 10;
                
                prev.next = tempNode;
                prev = tempNode;
            }

            if (hasRem)
                prev.next = new ListNode(1);

            return result;
        }

        //implement without queues later

        private static Queue<int> ListNodeToQueue(ListNode l)
        {
            Queue<int> q = new Queue<int>();
            var current = l;
            while (current != null)
            {
                var currentVal = current.val;
                q.Enqueue(currentVal);
                current = current.next;
            }
            return q;
        }







    }
}
