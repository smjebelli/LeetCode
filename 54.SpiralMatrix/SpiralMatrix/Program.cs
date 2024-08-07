

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
IList<int> list = SpiralOrder([[1, 2, 3, 4], [5, 6, 7, 8], [9, 10, 11, 12]]);
Console.WriteLine();
Console.WriteLine(SpiralOrder([[1]]));


static IList<int> SpiralOrder(int[][] matrix)
{
    int i = 0; int j = 0;
    int lastRow = matrix.Length - 1;
    int lastCol = matrix[0].Length - 1;

    int count = 0;
    int[] ys = [1, 0, -1, 0];
    int[] xs = [0, 1, 0, -1];
    int rotCount = 0;

    int totalCount = matrix.Length * matrix[0].Length;
    int[] li = new int[totalCount];

    HashSet<string> visited = new HashSet<string>();

    int xInc = xs[0];
    int yInc = ys[0];

    int val = 0;
    

    while (count < totalCount)
    {
        val = matrix[i][j];
        visited.Add($"{i},{j}");
        //list.Add(val);
        li[count] = val;

        //next indices
        j = j + yInc;
        i = i + xInc;

        //check if next is valid
        if (!visited.Add($"{i},{j}")|| j > lastCol || i > lastRow || j < 0 || i < 0)
        {
            //move back
            j = j - yInc;
            i = i - xInc;

            //rotate
            rotCount++;
            
            xInc = xs[rotCount % 4];
            yInc = ys[rotCount % 4];

            j = j + yInc;
            i = i + xInc;
        }
      
        count++;
    }

    return li.ToList();
}
