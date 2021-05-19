using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace CSharpConsoleApp.Solutions
{
    /// <summary>
    /// 另一个树的子树
    /// 一个题涵盖KMP DFS HASH 埃氏筛选法
    /// https://leetcode-cn.com/problems/subtree-of-another-tree/solution/ling-yi-ge-shu-de-zi-shu-by-leetcode-solution/
    /// </summary>
    class Solution572 : SolutionBase
    {
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

        /// <summary>
        /// 难度
        /// </summary>
        public override Difficulity GetDifficulity() { return Difficulity.Easy; }
        /// <summary>
        /// 关键字:
        /// </summary>
        public override string[] GetKeyWords() { return new string[] { "Rabin-Karp 算法" }; }
        /// <summary>
        /// 标签： 
        /// </summary>
        public override Tag[] GetTags() { return new Tag[] { Tag.Tree }; }
        public override bool Test(System.Diagnostics.Stopwatch sw)
        {
            return false;
        }

        #region 

        /// <summary>
        /// 暴力搜索法           时间代价为 O(∣s∣×∣t∣)
        /// 深度优先搜索         时间代价是 O(|s| + |t|)
        /// Rabin-Karp进行串匹配 时间代价是 O(|s| + |t|)
        /// 树哈希
        /// </summary>
        /// <param name="s"></param>
        /// <param name="t"></param>
        /// <returns></returns>
        public bool IsSubtree(TreeNode s, TreeNode t)
        {
            return dfs(s, t);
        }

        public bool dfs(TreeNode s, TreeNode t)
        {
            if (s == null)
            {
                return false;
            }
            return check(s, t) || dfs(s.left, t) || dfs(s.right, t);
        }

        public bool check(TreeNode s, TreeNode t)
        {
            if (s == null && t == null)
            {
                return true;
            }
            if (s == null || t == null || s.val != t.val)
            {
                return false;
            }
            return check(s.left, t.left) && check(s.right, t.right);
        }
        #endregion

    }
}
