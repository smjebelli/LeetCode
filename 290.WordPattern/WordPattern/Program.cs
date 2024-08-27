/*
 Given a pattern and a string s, find if s follows the same pattern.

Here follow means a full match, such that there is a bijection between a letter in pattern and a non-empty word in s.

 

Example 1:

Input: pattern = "abba", s = "dog cat cat dog"
Output: true

Example 2:

Input: pattern = "abba", s = "dog cat cat fish"
Output: false

Example 3:

Input: pattern = "aaaa", s = "dog cat cat dog"
Output: false

 

Constraints:

    1 <= pattern.length <= 300
    pattern contains only lower-case English letters.
    1 <= s.length <= 3000
    s contains only lowercase English letters and spaces ' '.
    s does not contain any leading or trailing spaces.
    All the words in s are separated by a single space.




 */

Console.WriteLine(WordPattern("axba", "dog cat cat dog"));

static bool WordPattern(string pattern, string s)
{
    var arr = s.Split(' ');
    if (pattern.Length != arr.Length)
        return false;

    Dictionary<char, string> map = new Dictionary<char, string>();
    HashSet<string> visited = new HashSet<string>();

    for (int i = 0; i < pattern.Length; i++)
    {
        if (map.ContainsKey(pattern[i]))
        {
            if (arr[i] != map[pattern[i]])
                return false;
        }
        
        else
        {
            map.Add(pattern[i], arr[i]);
            visited.Add(arr[i]);
        }

    }
    if (visited.Count != map.Count)
        return false;
    return true;


}