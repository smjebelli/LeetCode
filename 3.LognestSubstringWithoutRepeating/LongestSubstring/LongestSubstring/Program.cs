/*
         Given a string s, find the length of the longest substring without repeating characters.
         *
         *
         Example 1:

        Input: s = "abcabcbb"
        Output: 3
        Explanation: The answer is "abc", with the length of 3.
        Example 2:

        Input: s = "bbbbb"
        Output: 1
        Explanation: The answer is "b", with the length of 1.
        Example 3:

        Input: s = "pwwkew"
        Output: 3
        Explanation: The answer is "wke", with the length of 3.
        Notice that the answer must be a substring, "pwke" is a subsequence and not a substring.
         */

using System.Runtime.InteropServices;

namespace LongestSubstring
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string str = "abcabcbb";
            Console.WriteLine(str);
            Console.WriteLine(LengthOfLongestSubstring(str));

        }

        static int LengthOfLongestSubstring(string s)
        {
            int start = 0;
            int len = 2;
            int maxLen = 1;

            if (string.IsNullOrEmpty(s))
                return 0;

            while (len <= s.Length)
            {
                HashSet<char> chars = new HashSet<char>();
                bool canAdd = true;
                //end = start + len - 1;

                if (start + len - 1 >= s.Length)
                    break;

                for (int i = start; i <= start + len - 1; i++)
                {
                    if (!(canAdd = chars.Add(s[i])))
                        break;
                }

                if (canAdd && len > maxLen)
                {
                    maxLen = len;
                    len++;
                }
                else
                    start++;

            }
            return maxLen;
        }

    }
}
