// See https://aka.ms/new-console-template for more information
/*
 Given a string s consisting of words and spaces, return the length of the last word in the string.

    A word is a maximal substring consisting of non-space characters only.

 

    Example 1:

    Input: s = "Hello World"
    Output: 5
    Explanation: The last word is "World" with length 5.

    Example 2:

    Input: s = "   fly me   to   the moon  "
    Output: 4
    Explanation: The last word is "moon" with length 4.

 */

Console.WriteLine(LengthOfLastWord("   fly me   to   the moon  "));
Console.WriteLine(LengthOfLastWord("   fly me   to   themoon"));

//good runtime speed
static int LengthOfLastWord(string s)
{
    var arr = s.Split(' ').ToList();
    var last = arr.LastOrDefault(x => x != "");
    return last is null?0:last.Length;
}

// good memory 
static int _LengthOfLastWord(string s)
{
    int len = 0;
    for (int i = s.Length - 1; i >= 0; i--)
    {
        if (len == 0 && s[i] == ' ')
            continue;

        else if (len > 0)
        {
            if (s[i] == ' ')
                return len;
            len++;
        }
        else
            len++;
    }
    return len;
}


