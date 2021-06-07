using System;
using System.Collections.Generic;
namespace CSharpConsoleApp.Solutions
{
    /*
     * @lc app=leetcode.cn id=77 lang=csharp
     *
     * [77] 组合
     *
     * https://leetcode-cn.com/problems/combinations/description/
     *
     * Category	Difficulty	Likes	Dislikes
     * algorithms	Medium (76.82%)	595	-
     * Tags
     * backtracking
     * 
     * Companies
     * Unknown
     * Total Accepted:    169.8K
     * Total Submissions: 221K
     * Testcase Example:  '4\n2'
     *
     * 给定两个整数 n 和 k，返回 1 ... n 中所有可能的 k 个数的组合。
     * 
     * 示例:
     * 输入: n = 4, k = 2
     * 输出:
     * [
     * ⁠ [2,4],
     * ⁠ [3,4],
     * ⁠ [2,3],
     * ⁠ [1,2],
     * ⁠ [1,3],
     * ⁠ [1,4],
     * ]
     * 
     */

    public class Solution77 : SolutionBase
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
        public override Tag[] GetTags() { return new Tag[] { Tag.Backtracking }; }

        public override bool Test(System.Diagnostics.Stopwatch sw)
        {
            bool isSuccess = true;
            return isSuccess;
        }

        /// <summary>
        /// 27/27 cases passed (304 ms)
        /// Your runtime beats 28.97 % of csharp submissions
        /// Your memory usage beats 6.54 % of csharp submissions(30.2 MB)
        /// </summary>
        /// <param name="n"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public IList<IList<int>> Combine(int n, int k)
        {
            List<IList<int>> res = new List<IList<int>>();
            if (k <= 0 || n < k)
            {
                return res;
            }
            // 从 1 开始是题目的设定
            LinkedList<int> path = new LinkedList<int>();
            DFS(n, k, 1, path, res);
            return res;
        }

        private void DFS(int n, int k, int begin, LinkedList<int> path, List<IList<int>> res)
        {
            // 递归终止条件是：path 的长度等于 k
            if (path.Count == k)
            {
                res.Add(new List<int>(path));
                return;
            }

            // 遍历可能的搜索起点
            for (int i = begin; i <= n; i++)
            {
                // 向路径变量里添加一个数
                path.AddLast(i);
                // 下一轮搜索，设置的搜索起点要加 1，因为组合数理不允许出现重复的元素
                DFS(n, k, i + 1, path, res);
                // 重点理解这里：深度优先遍历有回头的过程，因此递归之前做了什么，递归之后需要做相同操作的逆向操作
                path.RemoveLast();
            }
        }
    }
}
