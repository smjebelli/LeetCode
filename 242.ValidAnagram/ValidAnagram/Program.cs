/*
 Given two strings s and t, return true if t is an anagram of s, and false otherwise.

An Anagram is a word or phrase formed by rearranging the letters of a different word or phrase, typically using all the original letters exactly once.

 

Example 1:

Input: s = "anagram", t = "nagaram"
Output: true
Example 2:

Input: s = "rat", t = "car"
Output: false
 

Constraints:

1 <= s.length, t.length <= 5 * 104
s and t consist of lowercase English letters.
 

Follow up: What if the inputs contain Unicode characters? How would you adapt your solution to such a case?
 */

string s, t;
s = "ab";
t = "a";
Console.WriteLine(s);
Console.WriteLine(t);
Console.WriteLine(IsAnagram(s, t));

bool IsAnagram(string s, string t)
{
    Dictionary<char, int> sDic = new Dictionary<char, int>();
    Dictionary<char, int> tDic = new Dictionary<char, int>();
    if (s.Length != t.Length)
        return false;

    for (int i = 0; i < s.Length; i++)
    {
        if (sDic.ContainsKey(s[i]))
            sDic[s[i]]++;
        else
            sDic.Add(s[i], 1);

        if (tDic.ContainsKey(t[i]))
            tDic[t[i]]++;
        else
            tDic.Add(t[i], 1);

    }

    foreach (var key in tDic.Keys)
    {
        if (!sDic.ContainsKey(key) || tDic[key] != sDic[key])
            return false;
    }

    return true;
}