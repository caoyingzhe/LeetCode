using System;
using System.Collections.Generic;
namespace CSharpConsoleApp.Solutions
{
    /*
     * @lc app=leetcode.cn id=95 lang=csharp
     *
     * [95] 不同的二叉搜索树 II
     *
     * https://leetcode-cn.com/problems/unique-binary-search-trees-ii/description/
     *
     * algorithms
     * Medium (69.22%)
     * Likes:    912
     * Dislikes: 0
     * Total Accepted:    89K
     * Total Submissions: 128.5K
     * Testcase Example:  '3'
     *
     * 给你一个整数 n ，请你生成并返回所有由 n 个节点组成且节点值从 1 到 n 互不相同的不同 二叉搜索树 。可以按 任意顺序 返回答案。
     * 
     * 
     * 示例 1：
     * 输入：n = 3
     * 输出：[[1,null,2,null,3],[1,null,3,2],[2,1,3],[3,1,null,null,2],[3,2,null,1]]
     * 
     * 
     * 示例 2：
     * 输入：n = 1
     * 输出：[[1]]
     * 
     * 
     * 提示：
     * 1 
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
    public class Solution95 : SolutionBase
    {
        /// <summary>
        /// 难易度:
        /// </summary>
        public override Difficulity GetDifficulity() { return Difficulity.Medium; }
        /// <summary>
        /// 关键字:
        /// </summary>
        public override string[] GetKeyWords() { return new string[] { "二叉搜索树", "IP地址" }; }
        /// <summary>
        /// 标签：
        /// </summary>
        public override Tag[] GetTags() { return new Tag[] { Tag.Tree, Tag.DynamicProgramming }; }

        /// <summary>
        /// 195/195 cases passed (104 ms)
        /// Your runtime beats 89.9 % of csharp submissions
        /// Your memory usage beats 95.45 % of csharp submissions(24.5 MB)
        /// </summary>
        /// <param name="sw"></param>
        /// <returns></returns>
        public override bool Test(System.Diagnostics.Stopwatch sw)
        {
            bool isSuccess = true;
            //TODO
            return isSuccess;
        }

        /// <summary>
        /// TODO 有点复杂，待理解
        /// 
        /// 二叉搜索树关键的性质是
        /// 1.  根节点的值大于左子树所有节点的值，
        /// 2.  小于右子树所有节点的值，
        /// 3.  且左子树和右子树也同样为二叉搜索树。
        ///
        /// 作者：LeetCode - Solution
        /// 链接：https://leetcode-cn.com/problems/unique-binary-search-trees-ii/solution/bu-tong-de-er-cha-sou-suo-shu-ii-by-leetcode-solut/
        /// 8/8 cases passed (236 ms)
        /// Your runtime beats 84.62 % of csharp submissions
        /// Your memory usage beats 51.28 % of csharp submissions(29.1 MB)
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public IList<TreeNode> GenerateTrees(int n)
        {
            if (n == 0)
            {
                return new List<TreeNode>();
            }
            return GenerateTrees(1, n);
        }

        public List<TreeNode> GenerateTrees(int start, int end)
        {
            List<TreeNode> allTrees = new List<TreeNode>();
            if (start > end)
            {
                allTrees.Add(null);
                return allTrees;
            }

            // 枚举可行根节点
            for (int i = start; i <= end; i++)
            {
                // 获得所有可行的左子树集合
                List<TreeNode> leftTrees = GenerateTrees(start, i - 1);

                // 获得所有可行的右子树集合
                List<TreeNode> rightTrees = GenerateTrees(i + 1, end);

                // 从左子树集合中选出一棵左子树，从右子树集合中选出一棵右子树，拼接到根节点上
                foreach (TreeNode left in leftTrees)
                {
                    foreach (TreeNode right in rightTrees)
                    {
                        TreeNode currTree = new TreeNode(i);
                        currTree.left = left;
                        currTree.right = right;
                        allTrees.Add(currTree);
                    }
                }
            }
            return allTrees;
        }
    }
    // @lc code=end
}
