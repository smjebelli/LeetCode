/*
According to Wikipedia's article: "The Game of Life, also known simply as Life, is a cellular automaton devised by the British mathematician John Horton Conway in 1970."

The board is made up of an m x n grid of cells, where each cell has an initial state: live (represented by a 1) or dead (represented by a 0). Each cell interacts with its eight neighbors (horizontal, vertical, diagonal) using the following four rules (taken from the above Wikipedia article):

Any live cell with fewer than two live neighbors dies as if caused by under-population.
Any live cell with two or three live neighbors lives on to the next generation.
Any live cell with more than three live neighbors dies, as if by over-population.
Any dead cell with exactly three live neighbors becomes a live cell, as if by reproduction.
The next state is created by applying the above rules simultaneously to every cell in the current state, where births and deaths occur simultaneously. Given the current state of the m x n grid board, return the next state.

 

Example 1:


Input: board = [[0,1,0],[0,0,1],[1,1,1],[0,0,0]]
Output: [[0,0,0],[1,0,1],[0,1,1],[0,1,0]]
Example 2:


Input: board = [[1,1],[1,0]]
Output: [[1,1],[1,1]]
 

Constraints:

m == board.length
n == board[i].length
1 <= m, n <= 25
board[i][j] is 0 or 1.
 

Follow up:

Could you solve it in-place? Remember that the board needs to be updated simultaneously: You cannot update some cells first and then use their updated values to update other cells.
In this question, we represent the board using a 2D array. In principle, the board is infinite, which would cause problems when the active area encroaches upon the border of the array (i.e., live cells reach the border). How would you address these problems?
 */

int[][] board = [[0, 1, 0], [0, 0, 1], [1, 1, 1], [0, 0, 0]];
//board = [[1]];
Print(board);
GameOfLife(board);
Print(board);


static void GameOfLife(int[][] board)
{
    int left = 0;
    int right = board.Length - 1;
    int bottom = 0;
    int top = 0;
    Dictionary<string, int> map = new Dictionary<string, int>();

    for (int i = 0; i < board.Length; i++)
    {
        for (int j = 0; j < board[0].Length; j++)
        {
            //Console.WriteLine($"i , j : {i},{j}");
            left = i - 1;
            right = i + 1;
            bottom = j + 1;
            top = j - 1;

            if (i == 0)
                left = i;
            if (i == board.Length - 1)
                right = i;
            if (j == 0)
                top = j;
            if (j == board[0].Length - 1)
                bottom = j;

            int liveNeighbors = 0;
            

            //Console.WriteLine($"left , right , top , bottom : {left},{right},{top},{bottom}");

            for (int m = left; m <= right; m++)
            {
                for (int n = top; n <= bottom; n++)
                {
                    if (m == i && n == j)
                        continue;
                    //Console.WriteLine($"m , n : {m},{n}");

                    liveNeighbors += board[m][n] == 0 ? 0 : 1;
                }
            }
            //Console.WriteLine($"lives : {liveNeighbors}");
            //Console.WriteLine($"deads : {deadNeighbors}");
            
            if (board[i][j] == 0 && liveNeighbors == 3)
                map.Add($"{i},{j}", 1);
            
            else if (board[i][j] == 1)
            {
                if (liveNeighbors < 2)
                    map.Add($"{i},{j}", 0);
                else if (liveNeighbors == 2 || liveNeighbors == 3)
                    map.Add($"{i},{j}", 1);
                else if (liveNeighbors > 3)
                    map.Add($"{i},{j}", 0);

            }

        }
    }
    foreach (var item in map)
    {
        var arr = item.Key.Split(",");
        board[int.Parse(arr[0])][int.Parse(arr[1])] = item.Value;
        
    }
}

static void Print(int[][] matrix)
{
    for (int i = 0; i < matrix.Length; i++)
    {
        Console.WriteLine(string.Join(" ", matrix[i]));
    }
    Console.WriteLine();
}

