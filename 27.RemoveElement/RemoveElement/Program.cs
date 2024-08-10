// See https://aka.ms/new-console-template for more information
/*
 public int RemoveElement(int[] nums, int val) {
        
    }

Given an integer array nums and an integer val, remove all occurrences of val in nums in-place. The order of the elements may be changed. Then return the number of elements in nums which are not equal to val.

Consider the number of elements in nums which are not equal to val be k, to get accepted, you need to do the following things:

    Change the array nums such that the first k elements of nums contain the elements which are not equal to val. The remaining elements of nums are not important as well as the size of nums.
    Return k.

Custom Judge:

The judge will test your solution with the following code:

int[] nums = [...]; // Input array
int val = ...; // Value to remove
int[] expectedNums = [...]; // The expected answer with correct length.
                            // It is sorted with no values equaling val.

int k = removeElement(nums, val); // Calls your implementation

assert k == expectedNums.length;
sort(nums, 0, k); // Sort the first k elements of nums
for (int i = 0; i < actualLength; i++) {
    assert nums[i] == expectedNums[i];
}

If all assertions pass, then your solution will be accepted.

 

Example 1:

Input: nums = [3,2,2,3], val = 3
Output: 2, nums = [2,2,_,_]
Explanation: Your function should return k = 2, with the first two elements of nums being 2.
It does not matter what you leave beyond the returned k (hence they are underscores).

Example 2:

Input: nums = [0,1,2,2,3,0,4,2], val = 2
Output: 5, nums = [0,1,4,0,3,_,_,_]
Explanation: Your function should return k = 5, with the first five elements of nums containing 0, 0, 1, 3, and 4.
Note that the five elements can be returned in any order.
It does not matter what you leave beyond the returned k (hence they are underscores).

 

Constraints:

    0 <= nums.length <= 100
    0 <= nums[i] <= 50
    0 <= val <= 100


 */

using System.ComponentModel;
using System.Reflection;

Console.WriteLine("Hello, World!");
int[] nums = [3, 2, 2, 3]; int val = 3; // [2,2,_,_], 2
nums = [0, 1, 2, 2, 3, 0, 4]; val = 2; 

Console.WriteLine(string.Join(", ", nums));
var res = RemoveElement(nums, val);
Console.WriteLine("k= " + res);
Console.WriteLine(string.Join(", ", nums));

//good solution from answers not mine
static int RemoveElement(int[] nums, int val)
{
    int result = 0;
    foreach (var item in nums)
    {
        if (item != val)
        {
            nums[result] = item;
            result++;
        }
    }

    return result;
}


static int MyRemoveElement(int[] nums, int val)
{
    int lastIdx = nums.Length - 1;
    int firstIdx = 0;
    int k = 0;
    int j = 0;
    while (firstIdx <= lastIdx)
    {
        j = 0;
        if (nums[firstIdx + j] == val)
        {
            k++;
            while (firstIdx + j + 1 < nums.Length)
            {
                swap(nums, firstIdx + j, firstIdx + j + 1);
                j++;

                if (firstIdx + j == lastIdx )
                {
                    lastIdx--;
                    firstIdx--;
                    break;
                }
            }
        }
        firstIdx++;
    }

    return nums.Length - k;
}



static void swap(int[] nums, int i, int j)
{
    int tmp = nums[i];
    nums[i] = nums[j];
    nums[j] = tmp;
}


