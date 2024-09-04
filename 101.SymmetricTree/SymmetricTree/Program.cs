/*
 Given the root of a binary tree, check whether it is a mirror of itself (i.e., symmetric around its center).

 

Example 1:


Input: root = [1,2,2,3,4,4,3]
Output: true
Example 2:


Input: root = [1,2,2,null,3,null,3]
Output: false
 

Constraints:

The number of nodes in the tree is in the range [1, 1000].
-100 <= Node.val <= 100
 

Follow up: Could you solve it both recursively and iteratively?
 
*/

//TreeNode t = new TreeNode(1);
//t.left = new TreeNode(2);
//t.right = new TreeNode(2);

//t.left.left = new TreeNode(3);
//t.left.right = new TreeNode(4);

//t.right.left = new TreeNode(4);
//t.right.right = new TreeNode(3);
//t.right.right.left = new TreeNode(10);


TreeNode t = new TreeNode(9);
t.left = new TreeNode(-42);
t.right = new TreeNode(-42);
t.left.right = new TreeNode(76);
t.right.left = new TreeNode(76);
t.left.right.right = new TreeNode(13);
t.right.left.right = new TreeNode(13);

Console.WriteLine(IsSymmetric(t));

static bool IsSymmetric(TreeNode root)
{
    return Compare(root.left, root.right);
}

static bool Compare(TreeNode p, TreeNode q)
{
    if (p == null && q == null)
        return true; 
    
    if (p == null || q == null)
        return false;
    
    if (p?.val != q?.val)
    
        return false;
    
    if ((p.left?.val != q.right?.val) || (p.right?.val != q.left?.val))
        return false;
    
    return true && Compare(p.left, q.right) && Compare(p.right,q.left);

}
