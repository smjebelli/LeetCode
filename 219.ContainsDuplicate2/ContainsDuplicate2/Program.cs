// See https://aka.ms/new-console-template for more information
/*
 Given an integer array nums and an integer k, return true if there are two distinct indices i and j in the array such that nums[i] == nums[j] and abs(i - j) <= k.

 

Example 1:

Input: nums = [1,2,3,1], k = 3
Output: true
Example 2:

Input: nums = [1,0,1,1], k = 1
Output: true
Example 3:

Input: nums = [1,2,3,1,2,3], k = 2
Output: false
 

Constraints:

1 <= nums.length <= 105
-109 <= nums[i] <= 109
0 <= k <= 105
 */

Console.WriteLine("Hello, World!");
int[] nums = [1, 2, 3, 1, 2, 3]; int k = 2;
//ums = [99, 100]; k = 2;
Console.WriteLine(_ContainsNearbyDuplicate(nums, k));

static bool ContainsNearbyDuplicate(int[] nums, int k)
{
    for (int i = 0; i < nums.Length; i++)
    {
        for (int j = 1; j <= k && i+j<nums.Length; j++)
        {
            if (nums[i] == nums[i + j])
                return true;

        }
    }
    return false;
}

//some other people's accepted solution
static bool _ContainsNearbyDuplicate(int[] nums, int k)
{
    HashSet<int> numIndices = new HashSet<int>();

    for (int i = 0; i < nums.Length; i++)
    {
        if (numIndices.Contains(nums[i]))
        {
            return true;
        }

        numIndices.Add(nums[i]);

        if (numIndices.Count > k)
        {
            numIndices.Remove(nums[i - k]);
        }
    }

    return false;
}
