using System;
namespace CSharpConsoleApp.Solutions
{
    /*
     * @lc app=leetcode.cn id=513 lang=csharp
     *
     * [513] 找树左下角的值
     *
     * https://leetcode-cn.com/problems/find-bottom-left-tree-value/description/
     *
     * Category	Difficulty	Likes	Dislikes
     * algorithms	Medium (73.00%)	185	-
     * Tags
     * tree | depth-first-search | breadth-first-search
     * 
     * Companies
     * microsoft
     * 
     * Total Accepted:    40.8K
     * Total Submissions: 55.9K
     * Testcase Example:  '[2,1,3]'
     *
     * 给定一个二叉树，在树的最后一行找到最左边的值。
     * 
     * 示例 1:
     * 输入:
     * 
     * ⁠   2
     * ⁠  / \
     * ⁠ 1   3
     * 
     * 输出:
     * 1
     *
     * 
     * 示例 2: 
     * 输入:
     * ⁠       1
     * ⁠      / \
     * ⁠     2   3
     * ⁠    /   / \
     * ⁠   4   5   6
     * ⁠      /
     * ⁠     7
     * 
     * 输出:
     * 7
     * 
     * 
     * 注意: 您可以假设树（即给定的根节点）不为 NULL。
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
    public class Solution513 : SolutionBase
    {
        /// <summary>
        /// 难度
        /// </summary>
        public override Difficulity GetDifficulity() { return Difficulity.Medium; }
        /// <summary>
        /// 关键字:
        /// </summary>
        public override string[] GetKeyWords() { return new string[] { "" }; }
        /// <summary>
        /// 标签：
        /// </summary>
        public override Tag[] GetTags() { return new Tag[] { Tag.Tree, Tag.DepthFirstSearch, Tag.BreadthFirstSearch }; }

        public override bool Test(System.Diagnostics.Stopwatch sw)
        {
            bool isSuccess = true;
            int result, checkResult;
            TreeNode root;

            root = TreeNode.Create(new int[] { 2, 1 ,3 }, NULL);
            checkResult = 1 ;
            result = FindBottomLeftValue(root);
            isSuccess &= IsSame(result, checkResult);
            PrintResult(isSuccess, result, checkResult);

            root = TreeNode.Create(new int[] { 1, 2, 3, 4, 5, 6, NULL, NULL, 7 }, NULL);
            checkResult = 7;
            result = FindBottomLeftValue(root);
            isSuccess &= IsSame(result, checkResult);
            PrintResult(isSuccess, result, checkResult);

            return isSuccess;
        }

        int depthMax = 0;
        int val = -1;

        /// <summary>
        /// 76/76 cases passed (92 ms)
        /// Your runtime beats 94.74 % of csharp submissions
        /// Your memory usage beats 89.47 % of csharp submissions(26 MB)
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public int FindBottomLeftValue(TreeNode root)
        {
            DFS(root, 0, true);
            return val;
        }

        public void DFS(TreeNode root, int depth, bool isLeftOrRoot)
        {
            if (root == null)
                return;

            if(depthMax < depth +1)
            {
                depthMax = depth + 1;
                val = root.val;
            }

            DFS(root.left, depth + 1, false);
            DFS(root.right, depth + 1, false);
        }
    }
    // @lc code=end


}
