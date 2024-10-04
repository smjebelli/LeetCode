/*
 The string "PAYPALISHIRING" is written in a zigzag pattern on a given number of rows like this: (you may want to display this pattern in a fixed font for better legibility)

P   A   H   N
A P L S I I G
Y   I   R
And then read line by line: "PAHNAPLSIIGYIR"

Write the code that will take a string and make this conversion given a number of rows:

string convert(string s, int numRows);
 

Example 1:

Input: s = "PAYPALISHIRING", numRows = 3
Output: "PAHNAPLSIIGYIR"
Example 2:

Input: s = "PAYPALISHIRING", numRows = 4
Output: "PINALSIGYAHRPI"
Explanation:
P     I    N
A   L S  I G
Y A   H R
P     I
Example 3:

Input: s = "A", numRows = 1
Output: "A"
 

Constraints:

1 <= s.length <= 1000
s consists of English letters (lower-case and upper-case), ',' and '.'.
1 <= numRows <= 1000
 */

using System.Data;
using System.Text;

string s = "PAYPALISHIRING";
int numRows = 4;
s = "AB";
numRows = 1;
Console.WriteLine($"n={numRows} \t" + Convert(s, numRows));

static string Convert_(string s, int numRows)
{
    string[] strings = new string[numRows];
    int i = 0;
    int j = 0;
    int dir = -1;
    int inc = 1;
    while (i < s.Length)
    {
        if (i == 0 || i == numRows)
        {
            dir *= -1;
        }
        j = i;
        strings[j] += s[i];
        j = dir * inc + i;
        i++;
    }

    return "";
}

//n=5
//line 0 => +8  +8  +8 ....
//line 1 => +6  +2  +6 ....
//line 2 => +4  +4  +4 ....
//line 3 => +2  +6  +2 ....
//line 4 => +8  +8  +8 ....
static string Convert(string s, int numRows)
{
    if (numRows == 1)
        return s;

    StringBuilder[] stringBuilders = new StringBuilder[numRows];

    int r = 0;

    bool isDown = true;
    for (int i = 0; i < s.Length; i++)
    {
        if (stringBuilders[r] is null)
            stringBuilders[r] = new StringBuilder();

        stringBuilders[r].Append(s[i]);
        if (r == numRows - 1 && isDown)
            isDown = false;

        if (r == 0 && i > 0)
            isDown = true;

        r = r + (isDown ? 1 : -1);
    }

    StringBuilder sb = new StringBuilder();
    for (int i = 0; i < numRows; i++)
    {
        if (stringBuilders[i] is null)
            continue;
        sb.Append(stringBuilders[i].ToString());
    }
    return sb.ToString();

}