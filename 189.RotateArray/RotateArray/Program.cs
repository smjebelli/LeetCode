// See https://aka.ms/new-console-template for more information

/*
 Given an integer array nums, rotate the array to the right by k steps, where k is non-negative.

 

Example 1:

Input: nums = [1,2,3,4,5,6,7], k = 3
Output: [5,6,7,1,2,3,4]
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

Console.WriteLine("Hello, World!");



void Rotate(int[] nums, int k)
{
    int st = 0;
    int en = nums.Length - 1 - k;
    
    int tmpS = nums[en];
    nums[0] = tmpS;
    int tmpD = nums[0];

   
    tmpS = nums[1];
    nums[1] = tmpD;


    for (int i = 0; i < nums.Length; i++)
    {

        Console.WriteLine(string.Join(" ", nums));
    }
}

void Swap(int[] nums, int i, int j)
{
    int tmp = nums[j];
    nums[j] = nums[i];
    nums[i] = tmp;
}

