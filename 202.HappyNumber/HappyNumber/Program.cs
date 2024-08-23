// See https://aka.ms/new-console-template for more information
/*
 Write an algorithm to determine if a number n is happy.

A happy number is a number defined by the following process:

Starting with any positive integer, replace the number by the sum of the squares of its digits.
Repeat the process until the number equals 1 (where it will stay), or it loops endlessly in a cycle which does not include 1.
Those numbers for which this process ends in 1 are happy.
Return true if n is a happy number, and false if not.

 

Example 1:

Input: n = 19
Output: true
Explanation:
12 + 92 = 82
82 + 22 = 68
62 + 82 = 100
12 + 02 + 02 = 1
Example 2:

Input: n = 2
Output: false
 

Constraints:

1 <= n <= 2^31 - 1
 */

using System.Reflection.Metadata.Ecma335;

Console.WriteLine("Hello, World!");

int num = 19;
Console.WriteLine($"n={num}-> isHappy:{IsHappy_Recursive(num)}");
//Console.WriteLine($"n={num}-> isHappy:{IsHappy(num)}");
//for (int num = 1000000; num < 1010000; num++)
//{
//    Console.WriteLine($"n={num}-> isHappy:{IsHappy_Recursive(num)}");
//}

//var n = fact(5);
//Console.WriteLine(n);

static bool IsHappy(int n)
{
    int count = 1;
    int res = SumSquareDigits(n);
    Console.WriteLine(res);
    while (count < 100 && (res > 3 && res != 1) && res != 4)
    {
        res = SumSquareDigits(res);
        Console.WriteLine(res);
        count++;
    }
    return res == 1;
}

static int fact(int n)
{
    if (n == 1)
        return n;
    return n * fact(n - 1);

}
static bool IsHappy_Recursive(int n)
{
    if (n < 4)
        return n == 1;
    else if (n == 5 || n == 4)
        return false;
    else
    {
        int res = SumSquareDigits(n);
        return false || IsHappy_Recursive(res);
    }

}

//static int _SumSquareDigits(int n)
//{
//    string str = n.ToString();
//    double sum = 0;
//    foreach (char c in str)
//    {
//        sum += Math.Pow(double.Parse(c.ToString()), 2);
//    }
//    return (int)sum;
//}

static int SumSquareDigits(int n)
{
    int sum = 0;
    while (n != 0)
    {
        sum += (int)Math.Pow((n % 10),2);
        n /= 10;
    }
    return sum;
}
