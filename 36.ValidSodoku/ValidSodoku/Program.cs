// See https://aka.ms/new-console-template for more information
using System.ComponentModel.DataAnnotations;
using System.Security.AccessControl;

Console.WriteLine("Hello, World!");
char[][] board =         [['5' , '3' , '.' ,    '.' , '7' , '.',    '.' , '.' , '.']
                         ,['6' , '.' , '.' ,    '1' , '9' , '5' ,   '.' , '.' , '.']
                         ,['.' , '9' , '8' ,    '.' , '.' , '.' ,   '.' , '6' , '.']

                         ,['8' , '.' , '.' ,    '.' , '6' , '.' ,   '.' , '.' , '3']
                         ,['4' , '.' , '.' ,    '8' , '.' , '3' ,   '.' , '.' , '1']
                         ,['7' , '.' , '.' ,    '.' , '2' , '.' ,   '.' , '.' , '6']

                         ,['.' , '6' , '.' ,    '.' , '.' , '.' ,   '2' , '8' , '.']
                         ,['.' , '.' , '.' ,    '4' , '1' , '9' ,   '.' , '.' , '5']
                         ,['.' , '.' , '.' ,    '.' , '8' , '.' ,   '.' , '7' , '9']];

Console.WriteLine(IsValidSudoku(board));

// slow solution
static bool _IsValidSudoku(char[][] board)
{
    bool rowsValid = false;
    bool colsValid = false;
    bool boxValid = false;

    for (int i = 0; i < 9; i++)
    {
        //check rows
        Dictionary<char, bool> row = new Dictionary<char, bool>();
        Dictionary<char, bool> col = new Dictionary<char, bool>();
        Dictionary<char, bool> box = new Dictionary<char, bool>();
        List<int> boxIdx = [1, 4, 7];


        for (int j = 0; j < 9; j++)
        {
            char cr = board[i][j];
            char cc = board[j][i];
            if (cr != '.')
            {
                if (row.ContainsKey(cr))
                { Console.WriteLine($"row {i} is not valid -{cr}"); return false; }

                row.Add(cr, true);
            }

            if (cc != '.')
            {
                if (col.ContainsKey(cc))
                { Console.WriteLine($"col {i} is not valid -{cc}"); return false; }

                col.Add(cc, true);
            }

            if (boxIdx.Contains(i) && boxIdx.Contains(j))
            {
                box = new Dictionary<char, bool>();
                for (int r = -1; r < 2; r++)
                {
                    for (int c = -1; c < 2; c++)
                    {
                        char ccr = board[i + r][j + c];
                        if (ccr != '.')
                        {
                            if (box.ContainsKey(ccr))
                            {
                                Console.WriteLine($"box is not valid -{i},{j}");
                                return false;
                            }
                            box.Add(ccr, true);
                        }
                    }
                }
            }

        }
    }
    return true;
}

static bool IsValidSudoku(char[][] board)
{
    HashSet<string> set = new HashSet<string>();

    for (int i = 0; i < 9; i++)
    {
        for (int j = 0; j < 9; j++)
        {
            char c = board[i][j];
            if (c == '.')
                continue;
            if ( !set.Add($"{c}row{i}") || !set.Add($"{c}col{j}") || !set.Add($"{c}box{i/3},{j/3}"))
            {
                Console.WriteLine($"{i}, {j}");
                return false;
            }

        }
    }


    return true;
}

static (int, int) boxIds(int i, int j)
{

    return (0, 0);
}