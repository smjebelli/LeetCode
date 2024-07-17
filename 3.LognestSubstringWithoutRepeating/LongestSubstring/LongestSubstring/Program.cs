using System.Runtime.InteropServices;

namespace LongestSubstring
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string str = "abcabcbb";
            Console.WriteLine(str);
            LengthOfLongestSubstring(str);


            str = "bbbbb";
            Console.WriteLine(str);
            LengthOfLongestSubstring(str);


            str = "pwwkew";
            Console.WriteLine(str);
            LengthOfLongestSubstring(str);
        }

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
        static int LengthOfLongestSubstring(string s)
        {
            int maxLen = 0;

            var sp = s.AsSpan();

            for (int i = 1; i <= sp.Length; i++)
            {
                for (int j = 0; j <= sp.Length - i; j++)
                {
                    char[] chars = new char[i];                    
                    for (int k = 0; k < i; k++)
                    {
                        chars[k] = sp[j+k];
                    }
                    //check if array has duplicate
                    int unqLength = chars.Distinct().ToArray().Length;
                    //Console.WriteLine($"i:{i}\tj:{j}\tchars: {new string(chars)} unqLength : {unqLength}" );

                    if (chars.Distinct().ToArray().Length == chars.Length && maxLen<chars.Length)
                    {
                        maxLen = chars.Length;
                        Console.WriteLine($"max length updated to : {maxLen} for: {new string(chars)}");
                    }
                }


            }
            return maxLen;
        }
    }
}
