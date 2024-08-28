/*
 Given an array of integers citations where citations[i] is the number of citations a researcher received for their ith paper, return the researcher's h-index.

According to the definition of h-index on Wikipedia: The h-index is defined as the maximum value of h such that the given researcher has published at least h papers that have each been cited at least h times.

 

Example 1:

Input: citations = [3,0,6,1,5]
Output: 3
Explanation: [3,0,6,1,5] means the researcher has 5 papers in total and each of them had received 3, 0, 6, 1, 5 citations respectively.
Since the researcher has 3 papers with at least 3 citations each and the remaining two with no more than 3 citations each, their h-index is 3.

Example 2:

Input: citations = [1,3,1]
Output: 1

 */
Console.WriteLine("Hello, World!");

int[] citations = [0, 1, 3, 5, 6];
int h = HIndex(citations);
Console.WriteLine($"{string.Join(" ", citations)}\tH: {h}");
citations = [0, 1];
h = HIndex(citations);
Console.WriteLine($"{string.Join(" ", citations)}\tH: {h}");


static int HIndex(int[] citations)
{
    if (citations.Length == 1)
        if (citations[0] > 0)
            return 1;
        else
            return 0;
    Array.Sort(citations);
    int h = 0;
    int maxH = 0;
    for (int i = 0; i < citations.Length; i++)
    {
        int rem = citations.Length - i;
        int val = citations[i];
        
        h = Math.Min(rem , val);
        if (h >= maxH)
            maxH = h;
        else
            return maxH;
    }
    return h;
}