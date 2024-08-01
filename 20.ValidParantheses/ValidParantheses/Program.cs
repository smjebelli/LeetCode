// See https://aka.ms/new-console-template for more information
/*
 Given a string s containing just the characters '(', ')', '{', '}', '[' and ']', determine if the input string is valid.

An input string is valid if:

Open brackets must be closed by the same type of brackets.
Open brackets must be closed in the correct order.
Every close bracket has a corresponding open bracket of the same type.
 

Example 1:

Input: s = "()"
Output: true
Example 2:

Input: s = "()[]{}"
Output: true
Example 3:

Input: s = "(]"
Output: false
 */


Console.WriteLine("(()]" + '\n' + IsValid("(()]"));
Console.WriteLine("(]" + '\n' + IsValid("(]"));
Console.WriteLine("()[]{}" + '\n' + IsValid("()[]{}"));

static bool IsValid(string s)
{
    Stack<char> stack = new Stack<char>();

    foreach (char c in s)
    {
        char cur;
        if (c == '[' || c == '{' || c == '(')
            stack.Push(c);
        else if (c == ']')
        {
            if (!stack.TryPop(out cur) || cur != '[')
                return false;
        }
        else if (c == '}')
        {
            if (!stack.TryPop(out cur) || cur != '{')
                return false;
        }
        else if (c == ')')
        {
            if (!stack.TryPop(out cur) || cur != '(')
                return false;
        }


    }
    return stack.Count == 0;
}