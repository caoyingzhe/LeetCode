using System;
using System.Collections.Generic;
namespace CSharpConsoleApp.Solutions
{
    /*
     * @lc app=leetcode.cn id=508 lang=csharp
     *
     * [508] 出现次数最多的子树元素和
     *
     * https://leetcode-cn.com/problems/most-frequent-subtree-sum/description/
     *
     * Category	Difficulty	Likes	Dislikes
     * algorithms	Medium (67.19%)	116	-
     * Tags
     * hash-table | tree
     * 
     * Companies
     * amazon
     * 
     * Total Accepted:    13.2K
     * Total Submissions: 19.6K
     * Testcase Example:  '[5,2,-3]'
     *
     * 给你一个二叉树的根结点，请你找出出现次数最多的子树元素和。一个结点的「子树元素和」定义为以该结点为根的二叉树上所有结点的元素之和（包括结点本身）。
     * 
     * 你需要返回出现次数最多的子树元素和。如果有多个元素出现的次数相同，返回所有出现次数最多的子树元素和（不限顺序）。
     * 
     * 
     * 示例 1：
     * 输入:
     * 
     * ⁠ 5
     * ⁠/  \
     * 2   -3
     * 
     * 返回 [2, -3, 4]，所有的值均只出现一次，以任意顺序返回所有值。
     * 
     * 示例 2：
     * 输入：
     * 
     * ⁠ 5
     * ⁠/  \
     * 2   -5
     * 
     * 返回 [2]，只有 2 出现两次，-5 只出现 1 次。
     * 
     * 提示： 假设任意子树元素和均可以用 32 位有符号整数表示。
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
    public class Solution508 : SolutionBase
    {
        /// <summary>
        /// 难度
        /// </summary>
        public override Difficulity GetDifficulity() { return Difficulity.Medium; }
        /// <summary>
        /// 关键字:
        /// </summary>
        public override string[] GetKeyWords() { return new string[] { }; }
        /// <summary>
        /// 标签：
        /// </summary>
        public override Tag[] GetTags() { return new Tag[] { Tag.HashTable, Tag.Tree }; }

        public const int NULL = int.MinValue;
        /// <summary>
        /// </summary>
        /// <param name="sw"></param>
        /// <returns></returns>
        public override bool Test(System.Diagnostics.Stopwatch sw)
        {
            bool isSuccess = true;
            TreeNode root;
            int[] result, checkResult;

            root = TreeNode.Create(new int[] { 5, 2, -3}, NULL);
            checkResult = new[] { 2, -3, 4 };
            result = FindFrequentTreeSum(root);
            isSuccess &= IsArraySame(result, checkResult, true);
            PrintResult(isSuccess, GetArrayStr(result), GetArrayStr(checkResult));
            return isSuccess;
        }


        int maxCount = 0;
        /// <summary>
        /// 58/58 cases passed (280 ms)
        /// Your runtime beats 83.33 % of csharp submissions
        /// Your memory usage beats 83.33 % of csharp submissions(32.8 MB)
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public int[] FindFrequentTreeSum(TreeNode root)
        {
            maxCount = 0;

            Dictionary<int, int> map = new Dictionary<int, int>();
            getSum(root, map);
            List<int> list = new List<int>();
            foreach(int  key in map.Keys)
            {
                if (map[key] == maxCount) list.Add(key);
            }
            int[] res = new int[list.Count];
            int index = 0;
            foreach (int val in list)
            {
                res[index++] = val;
            }
            return res;
        }

        private int getSum(TreeNode root, Dictionary<int, int> map)
        {
            if (root == null) return 0;
            int sum = root.val + getSum(root.left, map) + getSum(root.right, map);
            if (!map.ContainsKey(sum))
                map.Add(sum, 0);
            map[sum] += 1;
            maxCount = Math.Max(maxCount, map[sum]);
            return sum;
        }
    }
    // @lc code=end


}
