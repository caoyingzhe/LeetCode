using System;
using System.Collections.Generic;
namespace CSharpConsoleApp.Solutions
{
    /*
     * @lc app=leetcode.cn id=637 lang=csharp
     *
     * [637] 二叉树的层平均值
     *
     * https://leetcode-cn.com/problems/average-of-levels-in-binary-tree/description/
     *
     * algorithms
     * Easy (68.89%)
     * Likes:    274
     * Dislikes: 0
     * Total Accepted:    68.3K
     * Total Submissions: 99.1K
     * Testcase Example:  '[3,9,20,null,null,15,7]'
     *
     * 给定一个非空二叉树, 返回一个由每层节点平均值组成的数组。
     * 
     * 
     * 示例 1：
     * 输入：
     * ⁠   3
     * ⁠  / \
     * ⁠ 9  20
     * ⁠   /  \
     * ⁠  15   7
     * 输出：[3, 14.5, 11]
     * 解释：
     * 第 0 层的平均值是 3 ,  第1层是 14.5 , 第2层是 11 。因此返回 [3, 14.5, 11] 。
     * 
     * 
     * 提示：
     * 节点值的范围在32位有符号整数范围内。
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
    public class Solution637 : SolutionBase
    {
        /// <summary>
        /// 难度
        /// </summary>
        public override Difficulity GetDifficulity() { return Difficulity.Easy; }
        /// <summary>
        /// 关键字:
        /// </summary>
        public override string[] GetKeyWords() { return new string[] { }; }
        /// <summary>
        /// 标签：
        /// </summary>
        public override Tag[] GetTags() { return new Tag[] { Tag.Tree, Tag.BreadthFirstSearch }; }

        /// <summary>
        /// </summary>
        /// <param name="sw"></param>
        /// <returns></returns>
        public override bool Test(System.Diagnostics.Stopwatch sw)
        {
            bool isSuccess = true;

            TreeNode root;
            IList<double> result, checkResult;

            root = TreeNode.Create(new int[] { 3, 9, 20, -1, -1, 15, 7 }, -1);
            result = AverageOfLevels(root);
            checkResult = new double[] { 3, 14.5, 11 };
            isSuccess &= IsListSame(result, checkResult);
            PrintResult(isSuccess, GetArrayStr(result), GetArrayStr(checkResult));

            return isSuccess;
        }

        /// <summary>
        /// 66/66 cases passed (232 ms)
        /// Your runtime beats 95 % of csharp submissions
        /// Your memory usage beats 85 % of csharp submissions(33.1 MB)
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public IList<double> AverageOfLevels(TreeNode root)
        {
            //IList<IList<int>> result = new List<IList<int>>();
            IList<double> result = new List<double>();
            IList<int> counts = new List<int>();
            DFS(result, counts, root, 0);

            for(int i=0; i< result.Count; i++)
            {
                result[i] /= counts[i];
            }
            return result;
        }

        public void DFS(IList<double> result, IList<int> counts, TreeNode root, int depth)
        {
            if (root == null)
            {
                return;
            }
            if (depth > result.Count - 1)
            {
                result.Add(0);
                counts.Add(0);
            }
            result[depth] +=(root.val);
            counts[depth] ++;

            DFS(result, counts, root.left, depth + 1);
            DFS(result, counts, root.right, depth + 1);
        }
    }
    // @lc code=end


}
