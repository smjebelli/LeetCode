// See https://aka.ms/new-console-template for more information
/*
 Given two strings needle and haystack, return the index of the first occurrence of needle in haystack, or -1 if needle is not part of haystack.

 

Example 1:

Input: haystack = "sadbutsad", needle = "sad"
Output: 0
Explanation: "sad" occurs at index 0 and 6.
The first occurrence is at index 0, so we return 0.
Example 2:

Input: haystack = "leetcode", needle = "leeto"
Output: -1
Explanation: "leeto" did not occur in "leetcode", so we return -1.
 

Constraints:

1 <= haystack.length, needle.length <= 104
haystack and needle consist of only lowercase English characters.
 */
using System.ComponentModel;

Console.WriteLine("Hello, World!");
int res;
//int res = StrStr("sadbutsad", "ts"); //expect 0;
//Console.WriteLine(res);
//res = StrStr("leetcode", "leeto");
//Console.WriteLine(res);
//res = StrStr("mississippi", "issip");
//Console.WriteLine(res);

res = StrStr("mississippi", "issipi");
Console.WriteLine(res);
static int StrStr(string haystack, string needle)
{
    if (needle.Length > haystack.Length)
        return -1;
    for (int i = 0; i < haystack.Length; i++)
    {
        if (needle[0] == haystack[i])
        {
            bool match = true;
            for (int j = 0; j < needle.Length; j++)
            {
                if ((i + j == haystack.Length) || (needle[j] != haystack[i + j]))
                {
                    match = false;
                    break;
                }
            }
            if (match)
                return i;
        }
    }
    return -1;
}