using System;
namespace CSharpConsoleApp.Solutions
{
    /*
     * @lc app=leetcode.cn id=221 lang=csharp
     *
     * [221] 最大正方形
     *
     * https://leetcode-cn.com/problems/maximal-square/description/
     *
     * Category	Difficulty	Likes	Dislikes
     * algorithms	Medium (46.13%)	791	-
     * Tags
     * dynamic-programming
     * 
     * Companies
     * airbnb | apple | facebook
     * 
     * Total Accepted:    113.5K
     * Total Submissions: 245.9K
     * Testcase Example:  '[["1","0","1","0","0"],["1","0","1","1","1"],["1","1","1","1","1"],["1","0","0","1","0"]]'
     * 在一个由 '0' 和 '1' 组成的二维矩阵内，找到只包含 '1' 的最大正方形，并返回其面积。
     * 
     * 示例 1：
     * 输入：matrix =
     * [["1","0","1","0","0"],["1","0","1","1","1"],["1","1","1","1","1"],["1","0","0","1","0"]]
     * 输出：4
     * 
     * 
     * 示例 2：
     * 输入：matrix = [["0","1"],["1","0"]]
     * 输出：1
     * 
     * 
     * 示例 3：
     * 输入：matrix = [["0"]]
     * 输出：0
     *
     * 
     * 提示：
     * m == matrix.Length
     * n == matrix[i].Length
     * 1 <= m, n <= 300
     * matrix[i][j] 为 '0' 或 '1'
     */

    // @lc code=start
    public class Solution221 : SolutionBase
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
        public override Tag[] GetTags() { return new Tag[] { Tag.DynamicProgramming }; }

        public override bool Test(System.Diagnostics.Stopwatch sw)
        {
            bool isSuccess = true;
            int result, checkResult;
            char[][] nums;

            nums = new char[][] {
                new char[] {'1','0','1','0','0'},
                new char[] {'1','0','1','1','1'},
                new char[] {'1','1','1','1','1'},
                new char[] {'1','0','0','1','0'}
            };
            checkResult = 4;
            result = MaximalSquare(nums);
            isSuccess &= IsSame(result, checkResult);
            PrintResult(isSuccess, (result), (checkResult));

            return isSuccess;
        }

        /// <summary>
        /// 73/73 cases passed (128 ms)
        /// Your runtime beats 92.16 % of csharp submissions
        /// Your memory usage beats 72.55 % of csharp submissions(29 MB)
        /// 作者：LeetCode-Solution
        /// 链接：https://leetcode-cn.com/problems/maximal-square/solution/zui-da-zheng-fang-xing-by-leetcode-solution/
        /// </summary>
        /// <param name="matrix"></param>
        /// <returns></returns>
        public int MaximalSquare(char[][] matrix)
        {
            int maxSide = 0;
            if (matrix == null || matrix.Length == 0 || matrix[0].Length == 0) {
                return maxSide;
            }
            int rows = matrix.Length, columns = matrix[0].Length;

            //我们用 dp(i,j) 表示以 (i, j)(i,j) 为右下角，且只包含 1 的正方形的边长最大值。
            int[][] dp = new int[rows][];
            for (int i = 0; i < rows; i++)
            {
                dp[i] = new int[columns];
            }
            for (int i = 0; i < rows; i++) {
                for (int j = 0; j < columns; j++) {
                    if (matrix[i][j] == '1') {
                        if (i == 0 || j == 0) {
                            dp[i][j] = 1;
                        } else {
                            dp[i][j] = Math.Min(Math.Min(dp[i - 1][j], dp[i][j - 1]), dp[i - 1][j - 1]) + 1;
                        }
                        maxSide = Math.Max(maxSide, dp[i][j]);
                    }
                }
            }
            int maxSquare = maxSide * maxSide;
            return maxSquare;
        }
    }
    // @lc code=end


}
