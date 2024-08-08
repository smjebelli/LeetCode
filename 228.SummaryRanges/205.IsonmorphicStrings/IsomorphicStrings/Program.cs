// See https://aka.ms/new-console-template for more information
using System.Collections.Generic;
using System.Diagnostics;
using System.Transactions;

Console.WriteLine("Hello, World!");

/*
 Given two strings s and t, determine if they are isomorphic.

Two strings s and t are isomorphic if the characters in s can be replaced to get t.

All occurrences of a character must be replaced with another character while preserving the order of characters. No two characters may map to the same character, but a character may map to itself.

 

Example 1:

Input: s = "egg", t = "add"
Output: true
Example 2:

Input: s = "foo", t = "bar"
Output: false
Example 3:

Input: s = "paper", t = "title"
Output: true
 */
bool res = false;
res = IsIsomorphic("foo", "bar");
Console.WriteLine(res);
res = IsIsomorphic("title", "paper");
Console.WriteLine(res);

res = IsIsomorphic("bbbaaaba", "aaabbbba"); //expect false

Console.WriteLine(res);
res = IsIsomorphic("badc", "baba"); //expect false
Console.WriteLine(res);

res = IsIsomorphic("abcdefghijklmnopqrstuvwxyzva", "abcdefghijklmnopqrstuvwxyzck"); //expect false
Console.WriteLine(res);
static bool _IsIsomorphic(string s, string t)
{
    Dictionary<char, int> ds = new Dictionary<char, int>();
    Dictionary<char, int> dt = new Dictionary<char, int>();

    if (s.Length != t.Length)
        return false;

    char lastS = '\n';
    char lastT = '\n';
   
    for (int i = 0; i < s.Length; i++)
    {
        

        if (ds.ContainsKey(s[i]) && s[i] == lastS)
            ds[s[i]]++;
        else
            ds[s[i]] = 1;


        if (dt.ContainsKey(t[i]) && t[i] == lastT)
            dt[t[i]]++;
        else
            dt[t[i]] = 1;

        if (ds[s[i]] != dt[t[i]])
            return false;

        lastS = s[i];
        lastT = t[i];
    }
    return true;

}

static bool IsIsomorphic(string s, string t)
{
    if (s.Length != t.Length)
        return false;
    HashSet<char> sSet = new HashSet<char>();
    HashSet<char> tSet = new HashSet<char>();

    for (int i = 0;i< s.Length; i++)
    {
        sSet.Add(s[i]);
        tSet.Add(t[i]);
    }
    if (sSet.Count !=tSet.Count)    
        return false;
    
    var sList = SummaryRanges(s);
    var tList = SummaryRanges(t);
    if (sList.Count !=tList.Count)    
        return false;

    for (int i = 0; i < sList.Count; i++)
    {
        if (sList[i] != tList[i])
            return false;
    }

    return true;
}

static bool IsIsomorphic__(string s, string t)
{

    if (s.Length != t.Length)
        return false;

    int start;
    int end;
    bool diffS,diffT;
    int i = 0;
    IList<string> list = new List<string>();

    while (i < s.Length - 1)
    {
        diffS = s[i + 1] != s[i];
        diffT = t[i + 1] != t[i];

        if (diffS)
        {
            list.Add($"{i}");
            i++;
        }
        else
        {
            start = i;
            while (!diffS)
            {
                i++;
                if (i < s.Length - 1)
                    diffS = s[i + 1] != s[i];
                else
                    break;
            }
            end = i;

            list.Add($"{start}->{end}");
            i++;
        }
    }
    if (i < s.Length)
        list.Add($"{i}");


    return true;
}


static IList<string> SummaryRanges(string s)
{
    IList<string> list = new List<string>();
    if (s.Length == 0)
        return list;

    if (s.Length == 1)
    {
        list.Add(s[0].ToString());
        return list;
    }
    int start;
    int end;
    bool diff;
    int i = 0;

    while (i < s.Length - 1)
    {
        diff = s[i + 1] != s[i];

        if (diff)
        {
            list.Add($"{i}");
            i++;
        }
        else
        {
            start = i;
            while (!diff)
            {
                i++;
                if (i < s.Length - 1)
                    diff = s[i + 1] != s[i];
                else
                    break;
            }
            end = i;

            list.Add($"{start}->{end}");
            i++;
        }
    }
    if (i < s.Length)
        list.Add($"{i}");

    return list;
}