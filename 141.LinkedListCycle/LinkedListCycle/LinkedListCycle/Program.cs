using System.Diagnostics.CodeAnalysis;

namespace LinkedListCycle
{
    /*
     Given head, the head of a linked list, determine if the linked list has a cycle in it.

    There is a cycle in a linked list if there is some node in the list that can be reached again by continuously following the next pointer. Internally, pos is used to denote the index of the node that tail's next pointer is connected to. Note that pos is not passed as a parameter.

    Return true if there is a cycle in the linked list. Otherwise, return false.

 

    Example 1:


    Input: head = [3,2,0,-4], pos = 1
    Output: true
    Explanation: There is a cycle in the linked list, where the tail connects to the 1st node (0-indexed).
    Example 2:


    Input: head = [1,2], pos = 0
    Output: true
    Explanation: There is a cycle in the linked list, where the tail connects to the 0th node.
    Example 3:


    Input: head = [1], pos = -1
    Output: false
    Explanation: There is no cycle in the linked list.
 
     */
    public class Program
    {

        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            //[3,2,0,-4]
            ListNode n = new ListNode(3);
            ListNode n2 = new ListNode(2);
            ListNode n3 = new ListNode(2);
            ListNode n4 = new ListNode(2);
            n.next = n2;
            n2.next = n3;
            n3.next = n4;
            n4.next = n2;

            Console.WriteLine(HasCycle(n));
        }
        public static bool HasCycle(ListNode head)
        {
            HashSet<ListNode> list = new HashSet<ListNode>();
            ListNode current = head;
            while (current != null)
            {
                if (list.Contains(current))
                    return true;

                list.Add(current);
                current = current.next;
            }
            return false;
        }
    }






}
