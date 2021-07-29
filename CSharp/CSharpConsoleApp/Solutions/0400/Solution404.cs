using System;
namespace CSharpConsoleApp.Solutions
{
    /*
     * @lc app=leetcode.cn id=404 lang=csharp
     *
     * [404] 左叶子之和
     *
     * https://leetcode-cn.com/problems/sum-of-left-leaves/description/
     *
     * Category	Difficulty	Likes	Dislikes
     * algorithms	Easy (52.32%)	140	-
     * Tags
     * bit-manipulation
     * 
     * Companies
     * Unknown
     * 
     * Total Accepted:    87K
     * Total Submissions: 150.7K
     * Testcase Example:  '[3,9,20,null,null,15,7]'
     *
     * 计算给定二叉树的所有左叶子之和。
     * 
     * 示例：
     * 
     * 
     * ⁠   3
     * ⁠  / \
     * ⁠ 9  20
     * ⁠   /  \
     * ⁠  15   7
     * 
     * 在这个二叉树中，有两个左叶子，分别是 9 和 15，所以返回 24
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
    public class Solution404 : SolutionBase
    {
        /// <summary>
        /// 难度
        /// </summary>
        public override Difficulity GetDifficulity() { return Difficulity.Easy; }
        /// <summary>
        /// 关键字:
        /// </summary>
        public override string[] GetKeyWords() { return new string[] { "叶子" }; }
        /// <summary>
        /// 标签：
        /// </summary>
        public override Tag[] GetTags() { return new Tag[] { Tag.Tree }; }

        
        /// <summary>
        /// </summary>
        /// <param name="sw"></param>
        /// <returns></returns>
        public override bool Test(System.Diagnostics.Stopwatch sw)
        {
            bool isSuccess = true;

            TreeNode root;
            int result, checkResult;

            root = TreeNode.Create(new int[] { 3, 9, 20, NULL, NULL, 15, 7}, NULL);
            checkResult = 24;
            result = SumOfLeftLeaves(root);
            isSuccess &= IsSame(result, checkResult);
            PrintResult(isSuccess, (result), (checkResult));

            root = TreeNode.Create(new int[] { 1,2,3,4,5, }, NULL);
            checkResult = 4;
            result = SumOfLeftLeaves(root);
            isSuccess &= IsSame(result, checkResult);
            PrintResult(isSuccess, (result), (checkResult));

            return isSuccess;
        }

        /// <summary>
        /// 叶子意思是没有左右子节点的节点
        /// 100/100 cases passed (88 ms)
        /// Your runtime beats 100 % of csharp submissions
        /// Your memory usage beats 67.31 % of csharp submissions(24.4 MB)
        /// </summary>
        int sum = 0;
        public int SumOfLeftLeaves(TreeNode root)
        {
            sum = 0;
            DFS(root);
            return sum;
        }

        void DFS(TreeNode root)
        {
            if (root == null) return;

            //叶子意思是没有左右子节点的节点
            if (root.left != null && root.left.left == null && root.left.right == null)
                sum += root.left.val;
            DFS(root.left);
            DFS(root.right);
        }
    }
    // @lc code=end


}
