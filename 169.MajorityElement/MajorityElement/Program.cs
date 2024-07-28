// See https://aka.ms/new-console-template for more information

/*
    Given an array nums of size n, return the majority element.

    The majority element is the element that appears more than ⌊n / 2⌋ times. You may assume that the majority element always exists in the array.

 

    Example 1:

    Input: nums = [3,2,3]
    Output: 3
    Example 2:

    Input: nums = [2,2,1,1,1,2,2]
    Output: 2
 */


Console.WriteLine("Hello, World!");

Console.WriteLine(MajorityElement([3, 2, 3]));

static int MajorityElement(int[] nums)
{
    int len = nums.Length;
    Dictionary<int, int> dic = new Dictionary<int, int>();

    foreach (int x in nums)
    {
        if (dic.ContainsKey(x))
            dic[x]++;
        
        else
            dic.Add(x, 1);
        
        if (dic[x] > (int)(len / 2))
            return x;

    }

    return 0;
}