/*
 Given an m x n integer matrix matrix, if an element is 0, set its entire row and column to 0's.

You must do it in place.

 

Example 1:


Input: matrix = [[1,1,1],[1,0,1],[1,1,1]]
Output: [[1,0,1],[0,0,0],[1,0,1]]
Example 2:


Input: matrix = [[0,1,2,0],[3,4,5,2],[1,3,1,5]]
Output: [[0,0,0,0],[0,4,5,0],[0,3,1,0]]
 

Constraints:

m == matrix.length
n == matrix[0].length
1 <= m, n <= 200
-231 <= matrix[i][j] <= 231 - 1
 

Follow up:

A straightforward solution using O(mn) space is probably a bad idea.
A simple improvement uses O(m + n) space, but still not the best solution.
Could you devise a constant space solution?
 */

using System.Numerics;

int[][] matrix = [[0, 1, 2, 0], [3, 4, 5, 2], [1, 3, 1, 5]];
matrix = [[1, 2, 3, 4], [5, 0, 7, 8], [0, 10, 11, 12], [13, 14, 15, 0]];
//expected : [[0,0,3,0],[0,0,0,0],[0,0,0,0],[0,0,0,0]]
Print(matrix);
SetZeroes(matrix);
Console.WriteLine();
Print(matrix);


static void SetZeroes(int[][] matrix)
{
    HashSet<int> rows = new HashSet<int>();
    HashSet<int> cols = new HashSet<int>();


    for (int i = 0; i < matrix.Length; i++)
    {
        for (int j = 0; j < matrix[0].Length; j++)
        {
            Console.WriteLine($"i , j:\t{i} , {j}");
            if (matrix[i][j] == 0)
            {
                rows.Add(i);
                cols.Add(j);

                Print(matrix);
            }
        }
    }

    foreach (int i in rows)
    {
        for (int j = 0; j < matrix[0].Length; j++)
        {
            matrix[i][j] = 0;
        }
    }
    foreach (int j in cols)
    {
        for (int i = 0; i < matrix.Length; i++)
        {
            matrix[i][j] = 0;
        }
    }

}
static void SetZeroes_(int[][] matrix)
{
    HashSet<string> zeros = new HashSet<string>();
    HashSet<string> processed = new HashSet<string>();


    for (int i = 0; i < matrix.Length; i++)
    {
        for (int j = 0; j < matrix[0].Length; j++)
        {
            Console.WriteLine($"i , j:\t{i} , {j}");
            if (matrix[i][j] == 0 && !processed.Contains($"{i},{j}"))
            {
                Console.WriteLine($"settings rows & cols to zero for {i},{j}");
                //SetZeroByRowCol(i, j, matrix, zeros, processed);



                Print(matrix);
            }
            else
            {
                //processed.Add($"{i},{j}");
            }

        }

    }
}

static void SetZeroByRowCol(int r, int c, int[][] matrix, HashSet<string> zeros, HashSet<string> processed)
{

    for (int j = 0; j < matrix[0].Length; j++)
    {
        if (matrix[r][j] == 0 && !zeros.Contains($"{r},{j}"))
        {
            zeros.Add($"{r},{j}");
        }
        else
        {
            matrix[r][j] = 0;
        }
        processed.Add($"{r},{j}");

    }

    for (int i = 0; i < matrix.Length; i++)
    {
        if (matrix[i][c] == 0 && !zeros.Contains($"{i},{c}"))
        {
            zeros.Add($"{i},{c}");
        }
        else
        {
            matrix[i][c] = 0;
        }
        processed.Add($"{i},{c}");
    }

}

static void Print(int[][] matrix)
{
    for (int i = 0; i < matrix.Length; i++)
    {
        Console.WriteLine(string.Join("\t", matrix[i]));
    }
    Console.WriteLine();
}