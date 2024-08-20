// See https://aka.ms/new-console-template for more information

/*
 
You are given an n x n 2D matrix representing an image, rotate the image by 90 degrees (clockwise).

You have to rotate the image in-place, which means you have to modify the input 2D matrix directly. DO NOT allocate another 2D matrix and do the rotation.

 

Example 1:

Input: matrix = [[1,2,3],[4,5,6],[7,8,9]]
Output: [[7,4,1],[8,5,2],[9,6,3]]

Example 2:

Input: matrix = [[5,1,9,11],[2,4,8,10],[13,3,6,7],[15,14,12,16]]
Output: [[15,13,2,5],[14,3,4,1],[12,6,8,9],[16,7,10,11]]

 

Constraints:

    n == matrix.length == matrix[i].length
    1 <= n <= 20
    -1000 <= matrix[i][j] <= 1000


 */


using System.ComponentModel.Design;
using System.IO.Compression;

Console.WriteLine("Hello, World!");
int[][] matrix = [[1, 2, 3], [4, 5, 6], [7, 8, 9]];
int[][] desired = [[7, 4, 1], [8, 5, 2], [9, 6, 3]];

//matrix = [[5, 1, 9, 11], [2, 4, 8, 10], [13, 3, 6, 7], [15, 14, 12, 16]];
//desired = [[15, 13, 2, 5], [14, 3, 4, 1], [12, 6, 8, 9], [16, 7, 10, 11]];
//matrix = [[1]];

Console.WriteLine("Raw---------------------------");
Print(matrix);
Console.WriteLine("Desired---------------------------");
Print(desired);
Console.WriteLine("Rotated---------------------------");
Rotate(matrix);
Print(matrix);



static void Rotate(int[][] matrix)
{
    int lastRow = matrix.Length - 1;
    int lastCol = matrix[0].Length - 1;

    if (lastRow == 0 && lastCol == 0)
        return;

    HashSet<string> keys = new HashSet<string>();
    HashSet<string> ks = new HashSet<string>();
    int i = 0; int j = 0;
    int count = 1;
    keys.Add($"{i},{j}");
    int tmpS = matrix[0][0];
    int tmpD = 0;

    int newR;
    int newC;
    for (int r = 0; r <= lastRow; r++)
    {
        for (int c = 0; c <= lastCol; c++)
        {
            ks.Add($"{r},{c}");
        }
    }


    while (ks.Any())
    {
        (newR, newC) = NewIdx(i, j, lastRow, lastCol);

        //if (keys.Contains($"{newR},{newC}"))
        if (!ks.Contains($"{newR},{newC}"))
        {
            matrix[newR][newC] = tmpD;
          

            //if (newR + 1 <= lastRow)
            //    newR++;
            //else if (newC + 1 < lastCol)
            //    newC++;
            newR = int.Parse(ks.First().Split(',')[0]);
            newC = int.Parse(ks.First().Split(',')[1]);

            tmpS = matrix[newR][newC];
            i = newR;
            j = newC;
            //keys.Add($"{i},{j}");
            ks.Remove($"{i},{j}");
            //count++;
            continue;
        }
        tmpD = matrix[newR][newC];
        matrix[newR][newC] = tmpS;

        //Print(matrix);

        tmpS = tmpD;

        //Console.WriteLine($"{i + 1},{j + 1} -> {newR + 1},{newC + 1}");

        i = newR;
        j = newC;

        //keys.Add($"{i},{j}");
        ks.Remove($"{i},{j}");

        //count++;
    }
    (newR, newC) = NewIdx(i, j, lastRow, lastCol);
    matrix[newR][newC] = tmpS;

}

static (int newR, int newC) NewIdx(int i, int j, int lastRow, int lastCod)
{
    int newC = lastCod - i;
    int newR = j;
    return (newR, newC);
}

static void Print(int[][] matrix)
{
    for (int i = 0; i < matrix.Length; i++)
    {
        string line = "";
        for (int j = 0; j < matrix[i].Length; j++)
        {
            line += "\t" + matrix[i][j].ToString();
        }
        Console.WriteLine(line);
    }
    Console.WriteLine();
}
static void Print2(int[][] matrix, int r, int c)
{
    for (int i = 0; i < matrix.Length; i++)
    {
        string line = "";
        for (int j = 0; j < matrix[i].Length; j++)
        {
            if (i == r && j == c)
                line += $"\t[{matrix[i][j]}]";
            else
                line += "\t" + matrix[i][j].ToString();
        }
        Console.WriteLine(line);
    }
}

