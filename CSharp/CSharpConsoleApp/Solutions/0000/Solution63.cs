using System;
namespace CSharpConsoleApp.Solutions
{
    /*
     * @lc app=leetcode.cn id=63 lang=csharp
     *
     * [63] 不同路径 II
     *
     * https://leetcode-cn.com/problems/unique-paths-ii/description/
     *
     * Category	Difficulty	Likes	Dislikes
     * algorithms	Medium (38.32%)	560	-
     * Tags
     * array | dynamic-programming
     * 
     * Companies
     * bloomberg
     * 
     * Total Accepted:    148.9K
     * Total Submissions: 388.6K
     * Testcase Example:  '[[0,0,0],[0,1,0],[0,0,0]]'
     *
     * 一个机器人位于一个 m x n 网格的左上角 （起始点在下图中标记为“Start” ）。
     * 机器人每次只能向下或者向右移动一步。机器人试图达到网格的右下角（在下图中标记为“Finish”）。
     * 现在考虑网格中有障碍物。那么从左上角到右下角将会有多少条不同的路径？
     * 网格中的障碍物和空位置分别用 1 和 0 来表示。
     * 
     * 示例 1：
     * 输入：obstacleGrid = [[0,0,0],[0,1,0],[0,0,0]]
     * 输出：2
     * 解释：
     * 3x3 网格的正中间有一个障碍物。
     * 从左上角到右下角一共有 2 条不同的路径：
     * 1. 向右 -> 向右 -> 向下 -> 向下
     * 2. 向下 -> 向下 -> 向右 -> 向右
     * 
     * 示例 2：
     * 输入：obstacleGrid = [[0,1],[0,0]]
     * 输出：1
     * 
     * 提示：
     * m == obstacleGrid.length
     * n == obstacleGrid[i].length
     * 1 <= m, n <= 100
     * obstacleGrid[i][j] 为 0 或 1
     */
    public class Solution63 : SolutionBase
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

            int[][] obstacleGrid;
            int result, checkResult;

            obstacleGrid = new int[][]
            {
                new int[] { 0, 1},
                new int[] { 0, 0},
            };
            checkResult = 1;
            result = UniquePathsWithObstacles(obstacleGrid);
            isSuccess &= checkResult == result;
            Print("isSuccess = {0} | result = {1} | anticipated = {2}", isSuccess, (result), (checkResult));


            obstacleGrid = new int[][]
            {
                new int[] { 0, 0, 0},
                new int[] { 0, 1, 0},
                new int[] { 0, 0, 0},
            };
            checkResult = 2;
            result = UniquePathsWithObstacles(obstacleGrid);
            isSuccess &= checkResult == result;
            Print("isSuccess = {0} | result = {1} | anticipated = {2}", isSuccess, (result), (checkResult));

            obstacleGrid = new int[][]
            {
                new int[] { 0, 0, 0, 0},
                new int[] { 0, 1, 0, 1},
                new int[] { 0, 0, 0, 0},
            };
            checkResult = 2;
            result = UniquePathsWithObstacles(obstacleGrid);
            isSuccess &= checkResult == result;
            Print("isSuccess = {0} | result = {1} | anticipated = {2}", isSuccess, (result), (checkResult));

            obstacleGrid = new int[][]
            {
                new int[] { 0, 0, 0, 0},
                new int[] { 0, 1, 0, 1},
                new int[] { 0, 0, 0, 0},
                new int[] { 0, 1, 0, 0},
            };
            checkResult = 4;
            result = UniquePathsWithObstacles(obstacleGrid);
            isSuccess &= checkResult == result;
            Print("isSuccess = {0} | result = {1} | anticipated = {2}", isSuccess, (result), (checkResult));

            obstacleGrid = new int[][]
            {
                new int[] { 0, 0},
                new int[] { 0, 1}
            };
            return isSuccess;
        }

        /// <summary>
        /// 速度真不咋地，待优化
        /// 41/41 cases passed (132 ms)
        /// Your runtime beats 5.19 % of csharp submissions
        /// Your memory usage beats 38.52 % of csharp submissions(24.5 MB)
        /// </summary>
        /// <param name="obstacleGrid"></param>
        /// <returns></returns>
        public int UniquePathsWithObstacles(int[][] obstacleGrid)
        {
            int m = obstacleGrid.Length;
            int n = obstacleGrid[0].Length;

            int[,] dp = new int[m, n];

            int i, j;

            bool obstacleInline = false;
            bool obstacleInCol = false;
            for (i = 0; i < m; i++)
            {
                if (obstacleGrid[i][0] == 1)
                    obstacleInline = true;
                dp[i, 0] = obstacleInline ? 0 : 1;
            }
                
            for (j = 0; j < n; j++)
            {
                if (obstacleGrid[0][j] == 1)
                    obstacleInCol = true;
                dp[0, j] = obstacleInCol ? 0 : 1;
            }

            for (i = 1; i < m; i++)
            {
                for (j = 1; j < n; j++)
                {
                    int U = obstacleGrid[i - 1][j] == 1 ? 0 : dp[i - 1,j];
                    int L = obstacleGrid[i][j-1] == 1 ? 0 : dp[i, j - 1];
                    int R = j+1 >=n || obstacleGrid[i][j+1] == 1 ? 0 : dp[i, j + 1];
                    int D = i + 1 >= m || obstacleGrid[i+1][j] == 1 ? 0 : dp[i + 1, j];
                    dp[i, j] = obstacleGrid[i][j] == 1 ? 0 : L + R + U + D;
                }
            }

            return dp[m - 1, n - 1];
        }
    }
}
