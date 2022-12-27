// See https://aka.ms/new-console-template for more information
using System.Reflection.Metadata.Ecma335;

TreeNode root = new TreeNode(5);
root.left = new TreeNode(2);
root.right = new TreeNode(8);
root.left.left = new TreeNode(1);
root.left.right = new TreeNode(4);
root.left.right.left = new TreeNode(3);

//TreeNode root = new TreeNode(1);
//root.left = new TreeNode(0);
//root.right = new TreeNode(2);

int low = 1;
int high = 4;

Solution s = new Solution();
var answer = s.TrimBST(root, low, high);
Console.WriteLine(answer);  

public class TreeNode
{
  public int val;
  public TreeNode left;
  public TreeNode right;
  public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
  {
    this.val = val;
    this.left = left;
    this.right = right;
  }
}

public class Solution
{
  public TreeNode TrimBST(TreeNode root, int low, int high)
  {
    return Dfs(root, low, high);  
  }

  TreeNode Dfs(TreeNode root, int low, int high)
  {
    if (root == null) return null;
    // This is a BST, when a root is lower than low then left subtrees will be always lesser than root, no point to traverse to left
    if (root.val < low)
    {
      return Dfs(root.right, low, high);
    }
    // This is a BST, when a root is higher than high then right subtrees will be always greater than root, no point to traverse to right
    else if (root.val > high)
    {
      return Dfs(root.left, low, high);
    }
    // When we are here , root val is in the range of low and high and its a valid node
    // as its a valid node, we recursively check the left and right subtrees
    root.left = Dfs(root.left, low, high);
    root.right = Dfs(root.right, low, high);

    return root;
  }
}