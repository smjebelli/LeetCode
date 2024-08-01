// See https://aka.ms/new-console-template for more information


/*
 Given two strings ransomNote and magazine, return true if ransomNote can be constructed by using the letters from magazine and false otherwise.

Each letter in magazine can only be used once in ransomNote.

 

Example 1:

Input: ransomNote = "a", magazine = "b"
Output: false
Example 2:

Input: ransomNote = "aa", magazine = "ab"
Output: false
Example 3:

Input: ransomNote = "aa", magazine = "aab"
Output: true
 */

using System.Runtime.InteropServices;
using System.Security.AccessControl;

Console.WriteLine("Hello, World!");
//Console.WriteLine(CanConstruct("aab", "baa"));
//Console.WriteLine(CanConstruct("bg", "efjbdfbdgfjhhaiigfhbaejahgfbbgbjagbddfgdiaigdadhcfcj"));

Console.WriteLine(CanConstruct("az", "ab"));
Console.WriteLine(CanConstruct("a", "b"));
Console.WriteLine(CanConstruct("aa", "ab"));
Console.WriteLine(CanConstruct("aa", "aab"));


static bool CanConstruct(string ransomNote, string magazine)
{
    var dicMag = StringToDictionary(magazine);
    var dicRan = StringToDictionary(ransomNote);

    bool can = false;
    bool first = true;
    foreach (var key in dicRan.Keys)
    {
        if (dicMag.ContainsKey(key))
           can = first ? (dicMag[key] >= dicRan[key]) : can & (dicMag[key] >= dicRan[key]);
        else
            return can = false;

        first = false;
    }
    return can;
}

static Dictionary<char, int> StringToDictionary(string magazine)
{
    Dictionary<char, int> mapMag = new Dictionary<char, int>();

    for (int i = 0; i < magazine.Length; i++)
    {
        if (mapMag.ContainsKey(magazine[i]))
            mapMag[magazine[i]]++;
        else
            mapMag.Add(magazine[i], 1);
    }
    return mapMag;
}
