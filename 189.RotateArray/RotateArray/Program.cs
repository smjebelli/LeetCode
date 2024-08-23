// See https://aka.ms/new-console-template for more information

/*
 Given an integer array nums, rotate the array to the right by k steps, where k is non-negative.

 

Example 1:

Input: nums =   [1,2,3,4,5,6,7], k = 3
Output:         [5,6,7,1,2,3,4]
Input: nums =   [1,2,3,4,5,6,7], k = 2
Output:         [6,7,1,2,3,4,5]
Explanation:
rotate 1 steps to the right: [7,1,2,3,4,5,6]
rotate 2 steps to the right: [6,7,1,2,3,4,5]
rotate 3 steps to the right: [5,6,7,1,2,3,4]

Example 2:

Input: nums = [-1,-100,3,99], k = 2
Output: [3,99,-1,-100]
Explanation: 
rotate 1 steps to the right: [99,-1,-100,3]
rotate 2 steps to the right: [3,99,-1,-100]

 
 
 */


using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Reflection;
using System.Runtime.InteropServices;

int[] nums = [1, 2, 3, 4, 5, 6]; int k = 2; 
//nums = [-1, -100, 3, 99]; k = 2;  //[3,99,-1,-100]

Rotate(nums, k);
Console.WriteLine(string.Join(" ", nums));


static void Rotate(int[] nums, int k)
{
    int tmpS; int tmpD;
    tmpS = nums[0];
    int idx = 0;
    int count = 0;
    HashSet<int> visited = new HashSet<int>();

    while (count < nums.Length)
    {
        idx = (idx + k) % nums.Length;
        if (visited.Contains(idx))
        {
            while (visited.Contains(idx))            
                idx++;
            
            tmpS= nums[idx];
            continue;
        }

        tmpD = nums[idx];
        nums[idx] = tmpS; 
        tmpS= tmpD;

        visited.Add(idx);
        count++;
    }
}

