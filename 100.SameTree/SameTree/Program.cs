/*
 Given the roots of two binary trees p and q, write a function to check if they are the same or not.

Two binary trees are considered the same if they are structurally identical, and the nodes have the same value.

 

Example 1:


Input: p = [1,2,3], q = [1,2,3]
Output: true
Example 2:


Input: p = [1,2], q = [1,null,2]
Output: false
Example 3:


Input: p = [1,2,1], q = [1,1,2]
Output: false
 

Constraints:

The number of nodes in both trees is in the range [0, 100].
-104 <= Node.val <= 104
 */
using SameTree;
TreeNode p = new TreeNode(1);
p.left = new TreeNode(2);
p.right = new TreeNode(4);
p.right.left = new TreeNode(5);

TreeNode q = new TreeNode(1);
q.left = new TreeNode(2);
q.right = new TreeNode(3);

Console.WriteLine(IsSameTree(p, q));

static bool IsSameTree(TreeNode p, TreeNode q)
{
    Console.WriteLine($"{p?.val} , {q?.val}");

    if ((p == null && q == null))
        return true;

    if ((q == null && p != null) || (p?.val != q?.val) || (p?.val != q?.val) )
        return false;

    return  true && IsSameTree(p?.left, q?.left) && IsSameTree(p?.right, q?.right);


}