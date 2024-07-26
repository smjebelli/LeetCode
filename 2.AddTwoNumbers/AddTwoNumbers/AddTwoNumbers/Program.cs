using System.Data.SqlTypes;

namespace AddTwoNumbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            


            ListNode n = new ListNode(3);
            ListNode n2 = new ListNode(2);
            ListNode n3 = new ListNode(6);
            n.next = n2;
            n2.next = n3;
            n3.next = null;

            var a = IntToListNode(708);

            AddTwoNumbers(n, n);
        }
        public static ListNode AddTwoNumbers(ListNode l1, ListNode l2)
        {
            int n1 = reverseListNode(l1);
            int n2 = reverseListNode(l2);


            int n3 = n1 + n2;


            return l1;

        }

        public static int reverseListNode(ListNode l1)
        {
            int n1 = 0;
            Stack<int> s1 = new Stack<int>();
            var current = l1;
            while (current != null)
            {
                var currentVal = current.val;
                s1.Push(currentVal);
                current = current.next;
            }

            int count = s1.Count;
            for (int i = 0; i < count; i++)
            {
                int q = (int)Math.Pow(10, i);
                n1 += s1.Pop() * q;
            }
            return n1;
        }

        public static ListNode IntToListNode(int n)
        {
            string ns = n.ToString();
            ListNode l = new ListNode();
            
            for (int i = ns.Length-1; i >=0; i--)
            {
                l.val =int.Parse(ns[i].ToString());
                
                l.next = new ListNode();
                l = l.next;


            }
            return l;
        }
    }
}
