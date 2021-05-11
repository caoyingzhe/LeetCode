using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpConsoleApp.Solutions._0500
{
    /*
     * @lc app=leetcode.cn id=543 lang=csharp
     *
     * [543] 二叉树的直径
     *
     * https://leetcode-cn.com/problems/diameter-of-binary-tree/description/
     *
     * Category	Difficulty	Likes	Dislikes
     * algorithms	Easy (53.25%)	699	-
     * Tags
     * tree
     * 
     * Companies
     * facebook | google
     * 
     * Total Accepted:    114K
     * Total Submissions: 213.6K
     * Testcase Example:  '[1,2,3,4,5]'
     *
     * 给定一棵二叉树，你需要计算它的直径长度。一棵二叉树的直径长度是任意两个结点路径长度中的最大值。这条路径可能穿过也可能不穿过根结点。
     * 
     * 
     * 
     * 示例 :
     * 给定二叉树
     * 
     * ⁠         1
     * ⁠        / \
     * ⁠       2   3
     * ⁠      / \     
     * ⁠     4   5    
     * 
     * ⁠          1
     * ⁠        /   \
     * ⁠       2     3
     * ⁠      / \     \ 
     * ⁠     4   5     7
     *     /
     *    8 
     *    
     * 返回 3, 它的长度是路径 [4,2,1,3] 或者 [5,2,1,3]。
     * 
     * 
     * 
     * 注意：两结点之间的路径长度是以它们之间边的数目表示。
     * 
     */

    // @lc code=start
    /**
     * Definition for a binary tree node.
     * public class TreeNode {
     *     public int val;
     *     public TreeNode left;
     *     public TreeNode right;
     *     public TreeNode(int val=0, TreeNode left=null, TreeNode right=null) {
     *         this.val = val;
     *         this.left = left;
     *         this.right = right;
     *     }
     * }
     */
    class Solution543 : SolutionBase
    {
        public override bool Test(System.Diagnostics.Stopwatch sw)
        {
            bool isSuccess = true;

            TreeNode root;
            int result, checkResult;

            root = TreeNode.Create(new string[] { "1", "2", "3", "4", "5", null, "7", "8" });
            result = DiameterOfBinaryTree(root);
            checkResult = 5;
            isSuccess &= result == checkResult;
            Print("isSuccess ={0} | result = {1} | checkResult = {2}", isSuccess, result, checkResult);
            return isSuccess;
        }

        int diameter = 1;
        public int DiameterOfBinaryTree(TreeNode root)
        {
            MaxRoot(root);
            return diameter - 1;
        }

        public int MaxRoot(TreeNode root)
        {
            if (root == null)
                return 0;

            int lmax = MaxRoot(root.left);
            int rmax = MaxRoot(root.right);

            //Print(" This[{0}] ={1}, L={2} R={3}", root.val, lmax + rmax + 1, lmax, rmax);

            diameter = Math.Max(diameter, lmax + rmax + 1); // 计算d_node即L+R+1 并更新ans
            return Math.Max(lmax, rmax) + 1; // 返回该节点为根的子树的深度
        }
    }
}
