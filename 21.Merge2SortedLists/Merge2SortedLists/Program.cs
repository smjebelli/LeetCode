// See https://aka.ms/new-console-template for more information
/*
 You are given the heads of two sorted linked lists list1 and list2.

Merge the two lists into one sorted list. The list should be made by splicing together the nodes of the first two lists.

Return the head of the merged linked list.

 

Example 1:


Input: list1 = [1,2,4], list2 = [1,3,4]
Output: [1,1,2,3,4,4]
Example 2:

Input: list1 = [], list2 = []
Output: []
Example 3:

Input: list1 = [], list2 = [0]
Output: [0]
 

Constraints:

The number of nodes in both lists is in the range [0, 50].
 */

using System.Net.WebSockets;
using System.Xml;

Console.WriteLine("Hello, World!");
ListNode list11 = new ListNode(1);
ListNode list12 = new ListNode(2);
ListNode list13 = new ListNode(4);
list11.next = list12;
list12.next = list13;


ListNode list21 = new ListNode(1);
ListNode list22 = new ListNode(3);
ListNode list23 = new ListNode(4);
list21.next = list22;
//list22.next = list23;

Print(list11);
Print(list21);

var list3 = MergeTwoLists(list11, list21);
//var list3 = MergeTwoLists(list11, list21);
Print(list3);



static ListNode MergeTwoLists_(ListNode list1, ListNode list2)
{
    var list = new ListNode();
    if (list1.next == null && list2.next == null)
    {
        return list;
    }
    else if (list1.next == null && list2.next != null)
    {
        return list2;
    }
    else if (list1.next != null && list2.next == null)
    {
        return list1;
    }

    //int val1 = Math.Min(list1.val, list2.val);
    //int val2 = Math.Max(list1.val, list2.val);
    //list.val = val1;
    //var ll  = new ListNode(val2);
    //list.next = ll;

    // Console.WriteLine(list1.val + " " + list2.val);

    //list1 = list1.next;
    //list2 = list2.next;

    //ListNode l;
    //var l1 = new ListNode(Math.Min(list1.val, list2.val));
    //var l12 = new ListNode(Math.Max(list1.val, list2.val));
    //l1.next = l12;
    ////l = l12;

    //list1 = list1.next;
    //list2 = list2.next;

    //var l2 = new ListNode(Math.Min(list1.val, list2.val));
    //var l22 = new ListNode(Math.Max(list1.val, list2.val));
    //l2.next = l22;
    //l12.next = l22;

    //list1 = list1.next;
    //list2 = list2.next;


    //ll.next = l1;

    int min, max;

    ListNode lMin;
    ListNode lMax;

    min = Math.Min(list1.val, list2.val);
    max = Math.Max(list1.val, list2.val);

    list.val = min;
    list.next = new ListNode(max);

    list = list.next;
    while (true)
    {
        Console.WriteLine(list1.val + " " + list2.val);
        min = Math.Min(list1.val, list2.val);
        max = Math.Max(list1.val, list2.val);

        lMin = new ListNode(min);
        lMax = new ListNode(max);

        lMin.next = lMax;

        //condition to break loop
        if (list1.next is null && list2.next is null)
        {
            break;
        }

        list1 = list1.next;
        list2 = list2.next;


    }

    return list;
}

static ListNode MergeTwoLists__(ListNode list1, ListNode list2)
{
    ListNode list = null;
    if (list1 == null)
        return list2;

    if (list2 == null)
        return list1;

    Stack<int> stack = new Stack<int>();

    bool l1IsLong = false;
    bool l2IsLong = false;

    while ((l1IsLong = list1 is not null) && (l2IsLong = list2 is not null))
    {
        stack.Push(Math.Min(list1.val, list2.val));
        stack.Push(Math.Max(list1.val, list2.val));

        list1 = list1.next;
        list2 = list2.next;
    }
    if (!l1IsLong && l2IsLong)
    {
        while (list2.next is not null)
        {
            stack.Push(list2.val);
            list2 = list2.next;
        }
        stack.Push(list2.val);
    }
    else if (!l2IsLong && l1IsLong)
    {
        while (list1.next is not null)
        {
            stack.Push(list1.val);
            list1 = list1.next;
        }
        stack.Push(list1.val);
    }

    ListNode tmp0 = new ListNode(stack.Pop());
    tmp0.next = null;


    while (stack.TryPop(out int val))
    {
        list = new ListNode(val);
        list.next = tmp0;

        tmp0 = list;
    }

    return list;
}





static void Print(ListNode list)
{
    if (list == null)
    {
        Console.WriteLine("[]");
        return;
    }
    Console.Write(list.val + " ");
    while (list.next is not null)
    {
        Console.Write(list.next.val + " ");
        list = list.next;
    }
    Console.WriteLine();

}

//leet code solution
static ListNode MergeTwoLists(ListNode list1, ListNode list2)
{
    if (list1 == null) return list2;
    if (list2 == null) return list1;

    ListNode someNode = new ListNode();
    ListNode current = someNode;

    while (list1 != null && list2 != null)
    {
        int val = 0;
        if (list1.val <= list2.val)
        {
            val = list1.val;
            list1 = list1.next;
        }
        else
        {
            val = list2.val;
            list2 = list2.next;
        }
        ListNode tmp = new ListNode(val);
        current.next = tmp;
        current = current.next;
    }

    if (list1 == null) current.next = list2;
    else if (list2 == null) current.next = list1;

    return someNode.next;
}


public class ListNode
{
    public int val;
    public ListNode next;
    public ListNode(int val = 0, ListNode next = null)
    {
        this.val = val;
        this.next = next;
    }

}





