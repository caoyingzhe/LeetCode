using System;
namespace CSharpConsoleApp.Solutions
{
    /*
     * @lc app=leetcode.cn id=62 lang=csharp
     *
     * [62] 不同路径
     *
     * https://leetcode-cn.com/problems/unique-paths/description/
     *
     * Category	Difficulty	Likes	Dislikes
     * algorithms	Medium (65.21%)	1010	-
     * Tags
     * array | dynamic-programming
     * 
     * Companies
     * bloomberg
     * 
     * Total Accepted:    258K
     * Total Submissions: 395.5K
     * Testcase Example:  '3\n7'
     *
     * 一个机器人位于一个 m x n 网格的左上角 （起始点在下图中标记为 “Start” ）。
     * 
     * 机器人每次只能向下或者向右移动一步。机器人试图达到网格的右下角（在下图中标记为 “Finish” ）。
     * 
     * 问总共有多少条不同的路径？
     * 
     * 
     * 
     * 示例 1：
     * 输入：m = 3, n = 7
     * 输出：28
     * 
     * 示例 2：
     * 输入：m = 3, n = 2
     * 输出：3
     * 解释：
     * 从左上角开始，总共有 3 条路径可以到达右下角。
     * 1. 向右 -> 向下 -> 向下
     * 2. 向下 -> 向下 -> 向右
     * 3. 向下 -> 向右 -> 向下
     * 
     * 
     * 示例 3：
     * 输入：m = 7, n = 3
     * 输出：28
     * 
     * 
     * 示例 4：
     * 输入：m = 3, n = 3
     * 输出：6
     * 
     * 
     * 提示：
     * 1 <= m, n <= 100
     * 题目数据保证答案小于等于 2 * 10^9
     */
    public class Solution62 : SolutionBase
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

            int m, n, result, checkResult;

            m= 3; n = 2; checkResult = 3;
            result = UniquePaths(m,n);
            isSuccess &= checkResult == result;
            Print("isSuccess = {0} | result = {1} | anticipated = {2}", isSuccess, (result), (checkResult));

            m = 7; n = 3; checkResult = 28;
            result = UniquePaths(m, n);
            isSuccess &= checkResult == result;
            Print("isSuccess = {0} | result = {1} | anticipated = {2}", isSuccess, (result), (checkResult));

            m = 3; n = 3; checkResult = 6;
            result = UniquePaths(m, n);
            isSuccess &= checkResult == result;
            Print("isSuccess = {0} | result = {1} | anticipated = {2}", isSuccess, (result), (checkResult));

            return isSuccess;
        }

        //62/62 cases passed (56 ms)
        //Your runtime beats 10.31 % of csharp submissions
        //Your memory usage beats 26.91 % of csharp submissions(14.9 MB)
        public int UniquePaths(int m, int n)
        {
            int[,] dp = new int[m, n];

            int i, j;
            for (i = 0; i < m; i++)
                dp[i, 0] = 1;
            for (j = 0; j < n; j++)
                dp[0, j] = 1;

            for(i = 1; i < m; i++)
            {
                for (j = 1; j < n; j++)
                {
                    dp[i, j] = dp[i - 1, j] + dp[i, j - 1];
                }
            }

            return dp[m - 1, n - 1];
        }
    }
}
