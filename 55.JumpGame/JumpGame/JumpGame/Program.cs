using System.Runtime.InteropServices;

namespace JumpGame
{
    internal class Program
    {
        /*
         You are given an integer array nums. You are initially positioned at the array's first index, and each element in the array represents your maximum jump length at that position.

        Return true if you can reach the last index, or false otherwise.

        Example 1:

        Input: nums = [2,3,1,1,4]
        Output: true
        Explanation: Jump 1 step from index 0 to 1, then 3 steps to the last index.
        Example 2:

        Input: nums = [3,2,1,0,4]
        Output: false
        Explanation: You will always arrive at index 3 no matter what. Its maximum jump length is 0, which makes it impossible to reach the last index.
 

        Constraints:

        1 <= nums.length <= 104
        0 <= nums[i] <= 105
         */
        static void Main(string[] args)
        {
            int[] nums = { 2, 0 };
            int[] nums2 = { 2, 3, 1, 1, 4 };
            Console.WriteLine(string.Join(",", nums));
            Console.WriteLine(CanJump(nums));
            Console.WriteLine(string.Join(",", nums2));
            Console.WriteLine(CanJump(nums2));

            int[] nums3 = { 3, 2, 1, 0, 4 };
            Console.WriteLine(string.Join(",", nums3));
            Console.WriteLine(CanJump(nums3));
 
        }
      

        public static bool CanJump(int[] nums)
        {
            int maxReach = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                if (i > maxReach)
                {
                    return false;
                }
                maxReach = Math.Max(maxReach, i + nums[i]);
            }
            return maxReach >= nums.Length - 1;
        }

        
    }
}
