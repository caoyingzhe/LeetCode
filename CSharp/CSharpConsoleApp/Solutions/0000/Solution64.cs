using System;
namespace CSharpConsoleApp.Solutions
{
    /*
     * @lc app=leetcode.cn id=64 lang=csharp
     *
     * [64] 最小路径和
     *
     * https://leetcode-cn.com/problems/minimum-path-sum/description/
     *
     * Category	Difficulty	Likes	Dislikes
     * algorithms	Medium (68.54%)	890	-
     * Tags
     * array | dynamic-programming
     * 
     * Companies
     * Unknown
     * 
     * Total Accepted:    223.6K
     * Total Submissions: 326.2K
     * Testcase Example:  '[[1,3,1],[1,5,1],[4,2,1]]'
     * 给定一个包含非负整数的 m x n 网格 grid ，请找出一条从左上角到右下角的路径，使得路径上的数字总和为最小。
     * 说明：每次只能向下或者向右移动一步。
     * 
     * 示例 1：
     * 输入：grid = [[1,3,1],[1,5,1],[4,2,1]]
     * 输出：7
     * 解释：因为路径 1→3→1→1→1 的总和最小。
     * 
     * 示例 2：
     * 输入：grid = [[1,2,3],[4,5,6]]
     * 输出：12
     * 
     * 提示：
     * m == grid.length
     * n == grid[i].length
     * 1 <= m, n <= 200
     * 0 <= grid[i][j] <= 100
     */
    public class Solution64 : SolutionBase
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
        public override Tag[] GetTags() { return new Tag[] { Tag.DynamicProgramming, Tag.Array }; }

        public override bool Test(System.Diagnostics.Stopwatch sw)
        {
            bool isSuccess = true;

            int[][] grid;
            int result, checkResult;

            grid = new int[][]
            {
                new int[] { 1,3,1},
                new int[] { 1,5,1},
                new int[] { 4,2,1},
            };
            checkResult = 7;
            result = MinPathSum(grid);
            isSuccess &= checkResult == result;
            Print("isSuccess = {0} | result = {1} | anticipated = {2}", isSuccess, (result), (checkResult));

            return isSuccess;
        }

        /// <summary>
        /// 61/61 cases passed (120 ms)
        /// Your runtime beats 53.8 % of csharp submissions
        /// Your memory usage beats 97.08 % of csharp submissions(25.8 MB)
        /// </summary>
        /// <param name="grid"></param>
        /// <returns></returns>
        public int MinPathSum(int[][] grid)
        {
            int m = grid.Length;
            int n = grid[0].Length;
            int[,] dp = new int[m, n];

            int sumMin = int.MaxValue;

            int i, j;
            dp[0,0] = grid[0][0];
            for (i = 1; i < m; i++)
                dp[i, 0] = grid[i][0] + dp[i - 1, 0];
            for (j = 1; j < n; j++)
                dp[0, j] = grid[0][j] + dp[0,j-1];
            //Print(GetArray2DStr<int>(dp, m, n));

            for (i = 1; i < m; i++)
            {
                for (j = 1; j < n; j++)
                {
                    dp[i, j] = Math.Min(dp[i - 1, j],dp[i, j - 1]) + grid[i][j];
                    sumMin = Math.Min(sumMin, dp[i, j]);
                }
            }
            //Print(GetArray2DStr<int>(dp, m, n));
            return dp[m - 1, n - 1];
        }
    }
}
