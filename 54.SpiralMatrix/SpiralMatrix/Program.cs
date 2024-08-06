

//using System.Reflection.Metadata.Ecma335;
//using System.Threading.Tasks;


//await DoSomeThing();

//static async Task DoSomeThing()
//{
//    Param.Number = Guid.NewGuid();

//    await DoSomeThingElse();

//    await Task.FromResult(1);
//}

//static Task DoSomeThingElse()
//{
//    Param.Number = Guid.NewGuid();
//    return Task.FromResult(1);
//}

//class Param
//{
//    public static Guid Number { get; set; }
//}


//// See https://aka.ms/new-console-template for more information

// 54.Spiral Matrix
//Given an m x n matrix, return all elements of the matrix in spiral order.



//Example 1:

//Input: matrix = [[1,2,3],[4,5,6],[7,8,9]]
//Output: [1,2,3,6,9,8,7,4,5]

//Example 2:

//Input: matrix = [[1,2,3,4],[5,6,7,8],[9,10,11,12]]
//Output: [1,2,3,4,8,12,11,10,9,5,6,7]

// */
//using System.Runtime.CompilerServices;

using System.Collections.Specialized;
using System.Runtime.CompilerServices;

///*
Console.WriteLine("Hello, World!");
Console.WriteLine(SpiralOrder([[1, 2, 3, 4], [5, 6, 7, 8], [9, 10, 11, 12]]));


static IList<int> SpiralOrder(int[][] matrix)
{
    IList<int> list = new List<int>();
    int i = 0; int j = 0;
    int lastRow = matrix.Length - 1;
    int lastCol = matrix[0].Length - 1;
    int firstRow = 0;
    int firstCol = 0;
    int count = 0;
    int[] ys = [1, 0, -1, 0];
    int[] xs = [0, 1, 0, -1];
    int rotCount = 0;

    int totalCount = matrix.Length * matrix[1].Length;
    bool borderArrived = false;
    HashSet<string> visited = new HashSet<string>();

    int xInc = xs[0];
    int yInc = ys[0];

    //int val = matrix[0][0];
    //visited.Add("0,0");
    //list.Add(val);

    while (count < totalCount)
    {
        int val = matrix[i][j];
        visited.Add($"{i},{j}");
        list.Add(val);

        j = j + yInc;
        i = i + xInc;

        bool t1 = (i == lastRow) && (j == 0 || j == lastCol);
        bool t2 = (j == lastCol) && (i == 0 || i == lastRow);
        bool t = !visited.Add($"{i},{j}");
        
        if (t1 || t2 || t)
        {
            rotCount++;
            
            xInc = xs[rotCount % 4];
            yInc = ys[rotCount % 4];

            borderArrived = false;

        }




        //if (IsBorderArrived(i,j,visited,matrix))
        //{
        //    if (rotCount % 4 == 0)
        //        firstRow++;
        //    else if (rotCount % 4 == 1)
        //        lastCol--;
        //    else if (rotCount % 4 == 2)
        //        lastRow--;
        //    else if (rotCount % 4 == 3)
        //        firstCol++;

        //    borderArrived = true;
        //}



        count++;
    }

    return list;
}

static bool IsBorderArrived(int i, int j, int rows, int cols, HashSet<string> visited)
{
    bool t1 = (i == rows - 1) && (j == 0 || j == cols - 1);
    bool t2 = (j == cols - 1) && (i == 0 || i == rows - 1);
    bool t = !visited.Add($"{i},{j}");
    return t || t1 || t2;
    

    // return (!visited.Add($"{i},{j}")) || (i == matrix.Length) || (j == matrix[0].Length) ;
}

static bool IsBorderArrived_(int i, int j, int lastRow, int lastCol, int firstRow, int firstCol)
{
    return (i == firstRow && j == firstCol) ||
                    (i == firstRow && j == lastCol) ||
                    (j == lastCol && i == lastCol) ||
                    (j == firstCol && i == lastRow);
}