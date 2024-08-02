// See https://aka.ms/new-console-template for more information

/*
     Given an absolute path for a Unix-style file system, which begins with a slash '/', transform this path into its simplified canonical path.

    In Unix-style file system context, a single period '.' signifies the current directory, a double period ".." denotes moving up one directory level, and multiple slashes such as "//" are interpreted as a single slash. In this problem, treat sequences of periods not covered by the previous rules (like "...") as valid names for files or directories.

    The simplified canonical path should adhere to the following rules:

    It must start with a single slash '/'.
    Directories within the path should be separated by only one slash '/'.
    It should not end with a slash '/', unless it's the root directory.
    It should exclude any single or double periods used to denote current or parent directories.
    Return the new path.

 

    Example 1:

    Input: path = "/home/"

    Output: "/home"

    Explanation:

    The trailing slash should be removed.

 
    Example 2:

    Input: path = "/home//foo/"

    Output: "/home/foo"

    Explanation:

    Multiple consecutive slashes are replaced by a single one.

    Example 3:

    Input: path = "/home/user/Documents/../Pictures"

    Output: "/home/user/Pictures"

    Explanation:

    A double period ".." refers to the directory up a level.

    Example 4:

    Input: path = "/../"

    Output: "/"

    Explanation:

    Going one level up from the root directory is not possible.

    Example 5:

    Input: path = "/.../a/../b/c/../d/./"

    Output: "/.../b/d"

    Explanation:

    "..." is a valid name for a directory in this problem.
 */
using System.Data;
using System.IO;
using System.Text;

Console.WriteLine("Hello, World!");
string p = "//home/";
Console.WriteLine(p + "\t==>\t" + SimplifyPath_MemSafe(p));
p = "/.../a/../b/c/../d/./"; // =>  "/.../b/d"
p = "/home/"; Console.WriteLine(p + "\t==>\t" + SimplifyPath_MemSafe(p));
p = "/home//foo/"; Console.WriteLine(p + "\t==>\t" + SimplifyPath_MemSafe(p)); //=> "/home/foo" 
p = "/home/user/Documents/../Pictures"; Console.WriteLine(p + "\t==>\t" + SimplifyPath_MemSafe(p)); //=> "/home/user/Pictures"
p = "/../"; Console.WriteLine(p + "\t==>\t" + SimplifyPath_MemSafe(p)); // ==> "/"
p = "/a/./b/../../c/"; Console.WriteLine(p + "\t==>\t" + SimplifyPath_MemSafe(p)); // ==> "/c"

static string SimplifyPath_MemSafe(string path)
{
    var arr = path.Split('/');
    Stack<string> stack = new Stack<string>();
    string p = "";
    string val = null;
    foreach (var item in arr)
    {
        if (item == "" || item == ".")
            continue;

        if (item == "..")
            stack.TryPop(out _);

        else
            stack.Push(item);
    }

    StringBuilder sb = new StringBuilder();
    
    while (stack.Count > 0)
    {
        sb.Insert(0, stack.Pop());
        sb.Insert(0, "/");
    }
    return sb.Length == 0 ? "/" : sb.ToString();

}


static string SimplifyPath_faster(string path)
{
    var arr = path.Split('/');
    Stack<string> stack = new Stack<string>();
    string p = "";
    string val = null;
    foreach (var item in arr)
    {
        if (item == "" || item == ".")
            continue;

        if (item == "..")
            stack.TryPop(out _);

        else
            stack.Push(item);
    }
    while (stack.TryPop(out val))
        p = val + "/" + p;

    if (p.Length > 0)
        return "/" + p.Remove(p.Length - 1);
    else
        return "/";
}


//while (stack.TryPop(out val))
//    p = val + "/" + p;

//if (p.Length > 0)
//    return "/" + p.Remove(p.Length - 1);
//else
//    return "/";
