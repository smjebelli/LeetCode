/*
 Given an array of positive integers nums and a positive integer target, return the minimal length of a 
subarray
 whose sum is greater than or equal to target. If there is no such subarray, return 0 instead.

 

Example 1:

Input: target = 7, nums = [2,3,1,2,4,3]
Output: 2
Explanation: The subarray [4,3] has the minimal length under the problem constraint.
Example 2:

Input: target = 4, nums = [1,4,4]
Output: 1
Example 3:

Input: target = 11, nums = [1,1,1,1,1,1,1,1]
Output: 0
 

Constraints:

1 <= target <= 109
1 <= nums.length <= 105
1 <= nums[i] <= 104

Follow up: If you have figured out the O(n) solution, try coding another solution of which the time complexity is O(n log(n)).
 */

using System.Text.Json;

int target = 7; int[] nums = [2, 3, 1, 2, 4, 3]; // output 2
//nums = JsonSerializer.Deserialize<int[]>(File.ReadAllText(Path.Combine(new DirectoryInfo(Environment.CurrentDirectory).Parent.Parent.Parent.FullName, "TextFile1.txt"))); target = 396893380;

Console.WriteLine(MinSubArrayLen(target, nums));

static int MinSubArrayLen(int target, int[] nums)
{
    int left = 0;
    int sum = nums.Skip(left).Take(nums.Length).Sum();
    //left++;
    int lastLeft = -1;
    while (lastLeft != left)
    {
        sum = nums.Skip(left).Take(nums.Length - left).Sum();
        if (sum >= target)
        {
            left = left + (nums.Length - left) / 2;
        }
        else
        {
            left = left + (nums.Length - left) / 2;
        }
        lastLeft = left;
    }
    return nums.Length - left + 1;
}

//for (i = left; i <= Math.Min(i + minLen, nums.Length - 1); i++)
//{
//    sum += nums[i];
//    if (sum >= target)
//    {
//        len = i - left + 1;
//        break;
//    }
//}
//if (len < minLen)
//{
//    minLen = len;
//}
//left++;


static int _MinSubArrayLen(int target, int[] nums)
{
    int left = 0;
    int i = 0;
    int len = 0;
    int minLen = nums.Length;
    while (left < nums.Length)
    {
        int sum = 0;

        for (i = left; i <= Math.Min(i + minLen, nums.Length - 1); i++)
        {
            sum += nums[i];
            if (sum >= target)
            {
                len = i - left + 1;
                break;
            }
        }
        if (len < minLen)
        {
            minLen = len;
        }
        left++;
    }
    return minLen;
}

static int MinSubArrayLen_slow(int target, int[] nums)
{
    int minCount = int.MaxValue;
    int start = 0;
    while (true)
    {
        int sum = 0;
        int count = 0;
        for (int i = start; i < nums.Length; i++)
        {
            sum += nums[i];
            count++;
            if (sum >= target)
                break;
        }
        if (sum >= target)
        {
            if (minCount > count)
                minCount = count;

            start++;
        }
        else
        {
            if (start + minCount >= nums.Length)
                break;
            else
                start++;
        }
    }
    return minCount == int.MaxValue ? 0 : minCount;
}
