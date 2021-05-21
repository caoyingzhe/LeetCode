using System;
namespace CSharpConsoleApp.Solutions
{
    /*
     * @lc app=leetcode.cn id=110 lang=csharp
     *
     * [110] 平衡二叉树
     *
     * https://leetcode-cn.com/problems/balanced-binary-tree/description/
     *
     * Category	Difficulty	Likes	Dislikes
     * algorithms	Easy (55.72%)	684	-
     * Tags
     * tree | depth-first-search
     * 
     * Companies
     * bloomberg
     * Total Accepted:    209.5K
     * Total Submissions: 376K
     * Testcase Example:  '[3,9,20,null,null,15,7]'
     *
     * 给定一个二叉树，判断它是否是高度平衡的二叉树。
     * 
     * 本题中，一棵高度平衡二叉树定义为：
     * 一个二叉树每个节点 的左右两个子树的高度差的绝对值不超过 1 。
     * 
     * 示例 1：
     * 输入：root = [3,9,20,null,null,15,7]
     * 输出：true
     * 
     * 示例 2：
     * 输入：root = [1,2,2,3,3,null,null,4,4]
     * 输出：false
     * 
     * 示例 3：
     * 输入：root = []
     * 输出：true
     * 
     * 提示：
     * 树中的节点数在范围 [0, 5000] 内
     * -10^4 
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
    public class Solution110 : SolutionBase
    {
        /// <summary>
        /// 难易度:
        /// </summary>
        public override Difficulity GetDifficulity() { return Difficulity.Easy; }
        /// <summary>
        /// 关键字:
        /// </summary>
        public override string[] GetKeyWords() { return new string[] { "dynamic-programming", "高度平衡的二叉树"}; }
        /// <summary>
        /// 标签：
        /// </summary>
        public override Tag[] GetTags() { return new Tag[] { Tag.DynamicProgramming, Tag.Tree }; }


        //一棵高度平衡二叉树定义为：
        //一个二叉树每个节点 的左右两个子树的高度差的绝对值不超过 1 。
        public override bool Test(System.Diagnostics.Stopwatch sw)
        {
            TreeNode node;  bool result;

            //node = TreeNode.Create(new string[] { "3", "9", "20", null,null,"15","7" });
            //result = IsBalanced(node);
            //Print("Depth = {0} | anticipated = {1}", result, true);

            //node = TreeNode.Create(new string[] { "1", "2", "2", "3", "3", null,null,"4", "4" });
            //result = IsBalanced(node);
            //Print("Depth = {0} | anticipated = {1}", result, false);

            node = TreeNode.Create(new string[] { "1",null, "2", null, null, null, "3" });
            result = IsBalanced(node);
            Print("Depth = {0} | anticipated = {1}", result, false);

            return true;
        }
        public bool IsBalanced(TreeNode root)
        {
            GetMaxDepth(root);
            return isBalanced;
        }

        bool isBalanced = true;

        //深度计算结果正确，处理较慢
        public int GetMaxDepthCorrect(TreeNode root)
        {
            if (root == null)
                return 0;

            //if (isBalanced == false)
            //    return 0;

            int l = GetMaxDepth(root.left);
            int r = GetMaxDepth(root.right);

            if (Math.Abs(l - r) > 1)
            {
                isBalanced = false;
                //return 0;
            }

            return Math.Max(l, r) + 1;
        }

        //深度计算结果不正确，处理较快
        public int GetMaxDepth(TreeNode root)
        {
            if (isBalanced == false) //不再计算深度，因为已经得到结果
                return 0;

            if (root == null)
                return 0;

            int l = GetMaxDepth(root.left);
            int r = GetMaxDepth(root.right);

            if (Math.Abs(l - r) > 1)
            {
                isBalanced = false;
                return 0;
            }

            return Math.Max(l, r) + 1;
        }
    }
}
