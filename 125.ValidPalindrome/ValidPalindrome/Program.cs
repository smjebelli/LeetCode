// See https://aka.ms/new-console-template for more information
/*
 A phrase is a palindrome if, after converting all uppercase letters into lowercase letters and removing all non-alphanumeric characters, it reads the same forward and backward. Alphanumeric characters include letters and numbers.

Given a string s, return true if it is a palindrome, or false otherwise.

 

Example 1:

Input: s = "A man, a plan, a canal: Panama"
Output: true
Explanation: "amanaplanacanalpanama" is a palindrome.
Example 2:

Input: s = "race a car"
Output: false
Explanation: "raceacar" is not a palindrome.
Example 3:

Input: s = " "
Output: true
Explanation: s is an empty string "" after removing non-alphanumeric characters.
Since an empty string reads the same forward and backward, it is a palindrome.
 

Constraints:

1 <= s.length <= 2 * 105
s consists only of printable ASCII characters.
 */

using System.Text;
using System.Text.RegularExpressions;

Console.WriteLine("Hello, World!");
Console.WriteLine((int)'a');
Console.WriteLine((int)'b');
Console.WriteLine((int)'z');
Console.WriteLine((int)'A');
Console.WriteLine((int)'B');
Console.WriteLine((int)'Z');
Console.WriteLine((int)'1');
Console.WriteLine((int)'2');
Console.WriteLine((int)'3');
Console.WriteLine((int)'9');
Console.WriteLine((int)'0');

string str = "";
str = "A man, a plan, a canal: Panama";
Console.WriteLine(IsPalindrome(str));

static bool IsPalindrome(string s)
{
    s = RemoveNonAlphanumericPlusSpace(s).ToLower();
    
    int len = s.Length;
    if (string.IsNullOrEmpty(s))
        return true;

    int st = 0;
    int end = s.Length - 1;
    for (int i = 0; i < len/2; i++)
    {
        st = i;
        end = len - i - 1;
        var a = s[st];
        var b = s[end];
        if (s[st] != s[end])
            return false;
    }
    return true;
}

static string RemoveNonAlphanumericPlusSpace(string input)
{
    StringBuilder result = new StringBuilder();

    foreach (char c in input)
    {
        if (char.IsLetterOrDigit(c) &&(int)c != 32)
        {
            result.Append(c);
        }
    }

    return result.ToString();
}