// See https://aka.ms/new-console-template for more information

/*
 Write a function to find the longest common prefix string amongst an array of strings.

If there is no common prefix, return an empty string "".

 

Example 1:

Input: strs = ["flower","flow","flight"]
Output: "fl"

Example 2:

Input: strs = ["dog","racecar","car"]
Output: ""
Explanation: There is no common prefix among the input strings.

 */


string[] strs = ["flower", "flow", "flight"];
//strs =  ["dog","racecar","car"];
//strs = ["ab","a"];

Console.WriteLine(LongestCommonPrefix(strs));

static string LongestCommonPrefix(string[] strs)
{
    List<char> chars = new List<char>();
    char val;

    bool tf = true;

    int min = strs.ToList().Min(x => x.Length);
    if (strs.Length == 1) { return strs[0]; }

    for (int k = 0; k < min; k++)
    {
        val = strs[0][k];
        tf = true;

        for (int i = 1; i < strs.Length; i++)
        {
            tf &= strs[i][k] == val;
        }

        if (tf)
            chars.Add(val);

        else
            return new string(chars.ToArray());
    }
    return new string(chars.ToArray());
}