/*
 
Given the root of a binary tree, invert the tree, and return its root.

 

Example 1:


Input: root = [4,2,7,1,3,6,9]
Output: [4,7,2,9,6,3,1]
Example 2:


Input: root = [2,1,3]
Output: [2,3,1]
Example 3:

Input: root = []
Output: []
 

Constraints:

The number of nodes in the tree is in the range [0, 100].
-100 <= Node.val <= 100

 */
using InvertBinaryTree;

TreeNode t = new TreeNode(4);
t.left = new TreeNode(2);
t.left.left = new TreeNode(1);
t.left.right = new TreeNode(3);
t.right = new TreeNode(7);
t.right.left = new TreeNode(6);
t.right.right = new TreeNode(9);
var res = InvertTree(t);
int i = 0;

static TreeNode InvertTree(TreeNode root)
{
    Console.WriteLine($"{root?.val}");
    if (root == null)
        return null;

    var tmp = root.left;
    root.left = root.right;
    root.right = tmp;

    InvertTree(root.left);

    InvertTree(root.right);

    return root;
}

