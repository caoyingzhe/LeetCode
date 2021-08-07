using System;
using System.Collections.Generic;
namespace CSharpConsoleApp.Solutions
{
    /*
     * @lc app=leetcode.cn id=120 lang=csharp
     *
     * [120] 三角形最小路径和
     *
     * https://leetcode-cn.com/problems/triangle/description/
     *
     * Category	Difficulty	Likes	Dislikes
     * algorithms	Medium (67.56%)	788	-
     * Tags
     * array | dynamic-programming
     * 
     * Companies
     * Unknown
     * 
     * Total Accepted:    155.1K
     * Total Submissions: 229.5K
     * Testcase Example:  '[[2],[3,4],[6,5,7],[4,1,8,3]]'
     *
     * 给定一个三角形 triangle ，找出自顶向下的最小路径和。
     * 
     * 每一步只能移动到下一行中相邻的结点上。相邻的结点 在这里指的是 下标 与 上一层结点下标 相同或者等于 上一层结点下标 + 1
     * 的两个结点。也就是说，如果正位于当前行的下标 i ，那么下一步可以移动到下一行的下标 i 或 i + 1 。
     * 
     * 
     * 示例 1：
     * 输入：triangle = [[2],[3,4],[6,5,7],[4,1,8,3]]
     * 输出：11
     * 解释：如下面简图所示：
     * ⁠  2
     * ⁠ 3 4
     * ⁠6 5 7
     * 4 1 8 3
     * 自顶向下的最小路径和为 11（即，2 + 3 + 5 + 1 = 11）。
     * 
     * 
     * 示例 2：
     * 输入：triangle = [[-10]]
     * 输出：-10
     * 
     * 
     * 提示：
     * 1 <= triangle.length <= 200
     * triangle[0].length == 1
     * triangle[i].length == triangle[i - 1].length + 1
     * -10^4 <= triangle[i][j] <= 10^4
     *
     * 
     * 进阶：
     * 你可以只使用 O(n) 的额外空间（n 为三角形的总行数）来解决这个问题吗？
     */

    // @lc code=start
    public class Solution120 : SolutionBase
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
        public override Tag[] GetTags() { return new Tag[] { Tag.Array, Tag.DynamicProgramming }; }


        /// <summary>
        /// </summary>
        /// <param name="sw"></param>
        /// <returns></returns>
        public override bool Test(System.Diagnostics.Stopwatch sw)
        {
            bool isSuccess = true;

            IList<IList<int>> triangle;
            int result, checkResult;

            triangle = new int[][] {
                new int[] { 2 },
                new int[] { 3,4},
                new int[] { 6,5,7},
                new int[] { 4,1,8,3},
            };
            checkResult = 11;
            result = MinimumTotal(triangle);
            isSuccess &= IsSame(result, checkResult);
            PrintResult(isSuccess, (result), (checkResult));

            //[-2,null,-3]
            return isSuccess;
        }

        /// <summary>
        /// 时间复杂度：O(n^2)
        /// 空间复杂度：O(n^2)
        /// </summary>
        /// <param name="triangle"></param>
        /// <returns></returns>
        public int MinimumTotal_DP(IList<IList<int>> triangle)
        {
            int n = triangle.Count;

            int[][] f = new int[n][];
            for (int i = 0; i < n; i++) f[i] = new int[n];

            f[0][0] = triangle[0][0];
            for (int i = 1; i < n; ++i)
            {
                //最左侧，i=0的动态方程
                f[i][0] = f[i - 1][0] + triangle[i][0];
                //中间项的动态方程
                for (int j = 1; j < i; ++j)
                {
                    f[i][j] = Math.Min(f[i - 1][j - 1], f[i - 1][j]) + triangle[i][j];
                }
                //最右侧的动态方程
                f[i][i] = f[i - 1][i - 1] + triangle[i][i];
            }
            //求dp的最小值
            int minTotal = f[n - 1][0];
            for (int i = 1; i < n; ++i)
            {
                minTotal = Math.Min(minTotal, f[n - 1][i]);
            }
            return minTotal;
        }

        /// <summary>
        /// 43/43 cases passed (128 ms)
        /// Your runtime beats 14.63 % of csharp submissions
        /// Your memory usage beats 93.9 % of csharp submissions(24.4 MB)
        /// 作者：LeetCode-Solution
        /// 链接：https://leetcode-cn.com/problems/triangle/solution/san-jiao-xing-zui-xiao-lu-jing-he-by-leetcode-solu/
        /// 动态方程优化
        /// f[i][j] 只与 f[i-1][..] 有关，而与 f[i-2][..] 及之前的状态无关，
        /// 我们不必存储这些无关的状态。
        /// 我们使用两个长度为 nn 的一维数组进行转移，
        /// 将 i 根据奇偶性映射到其中一个一维数组，那么 i−1 就映射到了另一个一维数组。
        /// 这样我们使用这两个一维数组，交替地进行状态转移。
        /// </summary>
        /// <param name="triangle"></param>
        /// <returns></returns>
        public int MinimumTotal(IList<IList<int>> triangle)
        {
            int n = triangle.Count;

            int[][] f = new int[2][];
            for (int i = 0; i < 2; i++) f[i] = new int[n];

            f[0][0] = triangle[0][0];
            for (int i = 1; i < n; ++i)
            {
                int curr = i % 2;
                int prev = 1 - curr;
                //最左侧，i=0的动态方程
                f[curr][0] = f[prev][0] + triangle[i][0];
                //中间项的动态方程
                for (int j = 1; j < i; ++j)
                {
                    f[curr][j] = Math.Min(f[prev][j - 1], f[prev][j]) + triangle[i][j];
                }
                //最右侧的动态方程
                f[curr][i] = f[prev][i - 1] + triangle[i][i];
            }
            //求dp的最小值
            int minTotal = f[(n - 1) % 2][0];
            for (int i = 1; i < n; ++i)
            {
                //minTotal = Math.Min(minTotal, f[n - 1][i]);
                minTotal = Math.Min(minTotal, f[(n - 1) % 2][i]);
            }
            return minTotal;
        }
    }
    // @lc code=end
}
