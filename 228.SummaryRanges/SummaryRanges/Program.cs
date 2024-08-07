// See https://aka.ms/new-console-template for more information

/*
 You are given a sorted unique integer array nums.

A range [a,b] is the set of all integers from a to b (inclusive).

Return the smallest sorted list of ranges that cover all the numbers in the array exactly. That is, each element of nums is covered by exactly one of the ranges, and there is no integer x such that x is in one of the ranges but not in nums.

Each range [a,b] in the list should be output as:

"a->b" if a != b
"a" if a == b
 

Example 1:

Input: nums = [0,1,2,4,5,7]
Output: ["0->2","4->5","7"]
Explanation: The ranges are:
[0,2] --> "0->2"
[4,5] --> "4->5"
[7,7] --> "7"
Example 2:

Input: nums = [0,2,3,4,6,8,9]
Output: ["0","2->4","6","8->9"]
Explanation: The ranges are:
[0,0] --> "0"
[2,4] --> "2->4"
[6,6] --> "6"
[8,9] --> "8->9"
 */

using System.Reflection;

Console.WriteLine("Hello, World!");
int[] nums = [0, 2, 3, 4, 6, 8, 9];
Console.WriteLine(string.Join(',', SummaryRanges(nums)));

nums = [0, 1, 2, 4, 5, 7];
Console.WriteLine(string.Join(',',SummaryRanges(nums)));


static IList<string> SummaryRanges(int[] nums)
{
    IList<string> list = new List<string>();
    if (nums.Length == 0)
        return list;

    if (nums.Length == 1)
    {
        list.Add(nums[0].ToString());
        return list;
    }
    int start ;
    int end ;
    int diff;
    int i = 0;

    while (i < nums.Length - 1)
    {
        diff = nums[i + 1] - nums[i];

        if (diff > 1)
        {
            list.Add($"{nums[i]}");
            i++;
        }
        else
        {
            start = i;
            while (diff == 1)
            {
                i++;
                if (i < nums.Length - 1)
                    diff = nums[i + 1] - nums[i];
                else
                    break;
            }
            end = i;

            list.Add($"{nums[start]}->{nums[end]}");
            i++;
        }
    }
    if(i<nums.Length )
        list.Add($"{nums[i]}");

    return list;
}
