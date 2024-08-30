/*
 You are given an integer array height of length n. There are n vertical lines drawn such that the two endpoints of the ith line are (i, 0) and (i, height[i]).

Find two lines that together with the x-axis form a container, such that the container contains the most water.

Return the maximum amount of water a container can store.

Notice that you may not slant the container.

 

Example 1:


Input: height = [1,8,6,2,5,4,8,3,7]
Output: 49
Explanation: The above vertical lines are represented by array [1,8,6,2,5,4,8,3,7]. In this case, the max area of water (blue section) the container can contain is 49.
Example 2:

Input: height = [1,1]
Output: 1


Constraints:

n == height.length
2 <= n <= 105
0 <= height[i] <= 104
 */

using System.Diagnostics;
using System.Text.Json.Nodes;

int[] height = [1, 8, 6, 2, 5, 4, 8, 3, 7];
height = [1, 1];
DirectoryInfo dinf = new DirectoryInfo(Environment.CurrentDirectory);
var proj = dinf.Parent.Parent.Parent;

var height2 = System.Text.Json.JsonSerializer.Deserialize<int[]>(File.ReadAllText(Path.Combine(proj.FullName, "TextFile1.txt")));

DateTime st = DateTime.Now;
int max = MaxArea(height2);
Console.WriteLine((DateTime.Now - st).TotalMilliseconds);
Console.WriteLine(max);


//other people solution
static int MaxArea(int[] height)
{
    int st = 0, en = height.Length - 1;
    int max = 0;
    int area = 0;

    while (st < en)
    {
        if (height[st] < height[en])
        {
            area = (en - st) * height[st];
            st++;
        }
        else 
        {
            area = (en - st) * height[en];
            en--;
        }
        if(area>max)
            max= area;

    }
    return max;
}


static int MaxArea_usingDictionary(int[] height)
{
    int area = 0;
    int maxArea = 0;
    int maxH = height.Max();

    Dictionary<string, int> dict = new Dictionary<string, int>();

    for (int i = 0; i < height.Length; i++)
    {
        dict.Add($"{height[i]},{i}", i);
    }

    for (int i = maxH; i > 0; i--)
    {
        var keys = dict.Keys.Where(k => int.Parse(k.Split(',')[0]) >= i);
        if (keys.Count() > 1)
        {
            int first = dict[keys.First()];
            int last = dict[keys.Last()];

            area = (last - first) * i;
            if (area > maxArea)
                maxArea = area;

            //if (i % 100 == 0) Console.WriteLine($"i:{i}\t\t maxArea:{maxArea}");

        }
        double maxDistToAchieveArea = (double)maxArea / (double)i;
        if (maxDistToAchieveArea > height.Length - 1)
            return maxArea;
    }

    return maxArea;

}

static int MaxArea_slow(int[] height)
{
    int area = 0;
    int max = 0;
    long count = 0;
    for (int i = 0; i < height.Length; i++)
    {
        for (int j = i + 1; j < height.Length; j++)
        {
            area = Math.Min(height[i], height[j]) * (j - i);
            count++;
            if (area > max)
                max = area;

            //Console.WriteLine($"count:{count}\ti:{i} j:{j}->\t{height[i]}  {height[j]}->\tmin:{Math.Min(height[i], height[j])}\tdist:{j - i} area:{area}");

        }
    }
    Console.WriteLine("iterations:" + count.ToString());
    return max;
}