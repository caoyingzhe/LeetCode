using System;
namespace CSharpConsoleApp.Solutions
{
    /*
     * @lc app=leetcode.cn id=174 lang=csharp
     *
     * [174] 地下城游戏
     *
     * https://leetcode-cn.com/problems/dungeon-game/description/
     *
     * algorithms
     * Hard (48.16%)
     * Likes:    470
     * Dislikes: 0
     * Total Accepted:    33.5K
     * Total Submissions: 69.6K
     * Testcase Example:  '[[-2,-3,3],[-5,-10,1],[10,30,-5]]'
     *
     * 
     * table.dungeon, .dungeon th, .dungeon td {
     * ⁠ border:3px solid black;
     * }
     * 
     * ⁠.dungeon th, .dungeon td {
     * ⁠   text-align: center;
     * ⁠   height: 70px;
     * ⁠   width: 70px;
     * }
     * 
     * 一些恶魔抓住了公主（P）并将她关在了地下城的右下角。地下城是由 M x N
     * 个房间组成的二维网格。我们英勇的骑士（K）最初被安置在左上角的房间里，他必须穿过地下城并通过对抗恶魔来拯救公主。
     * 骑士的初始健康点数为一个正整数。如果他的健康点数在某一时刻降至 0 或以下，他会立即死亡。
     * 有些房间由恶魔守卫，因此骑士在进入这些房间时会失去健康点数（若房间里的值为负整数，则表示骑士将损失健康点数）；其他房间要么是空的（房间里的值为
     * 0），要么包含增加骑士健康点数的魔法球（若房间里的值为正整数，则表示骑士将增加健康点数）。
     * 
     * 为了尽快到达公主，骑士决定每次只向右或向下移动一步。
     * 编写一个函数来计算确保骑士能够拯救到公主所需的最低初始健康点数。
     * 
     * 例如，考虑到如下布局的地下城，如果骑士遵循最佳路径 右 -> 右 -> 下 -> 下，则骑士的初始健康点数至少为 7。
     * 
     * -2 (K) | -3   | 3 
     * -5     | -10  | 1 
     * ⁠10     | 30   | -5 (P) 
     * ⁠
     * 
     * 说明:
     * 骑士的健康点数没有上限。
     * 任何房间都可能对骑士的健康点数造成威胁，也可能增加骑士的健康点数，包括骑士进入的左上角房间以及公主被监禁的右下角房间。
     * 
     */

    public class Solution174 : SolutionBase
    {
        /// <summary>
        /// 难度
        /// </summary>
        public override Difficulity GetDifficulity() { return Difficulity.Hard; }
        /// <summary>
        /// 关键字:
        /// </summary>
        public override string[] GetKeyWords() { return new string[] { "反向动态方程" }; }
        /// <summary>
        /// 标签：
        /// </summary>
        public override Tag[] GetTags() { return new Tag[] { Tag.DynamicProgramming, }; }

        public override bool Test(System.Diagnostics.Stopwatch sw)
        {
            bool isSuccess = true;
            int[][] dungeon;
            int result, checkResult;

            checkResult = 7;
            dungeon = new int[][]
            {
                new int[] { -2, -3, 3},
                new int[] { -5,-10, 1},
                new int[] { 10, 30, -5},
            };
            return isSuccess;
        }

        /// <summary>
        /// 45/45 cases passed (116 ms)
        /// Your runtime beats 52.63 % of csharp submissions
        /// Your memory usage beats 26.32 % of csharp submissions(25.3 MB)
        /// </summary>
        /// <param name="dungeon"></param>
        /// <returns></returns>
        public int CalculateMinimumHP(int[][] dungeon)
        {
            int n = dungeon.Length;
            int m = dungeon[0].Length;

            //dp[i][j] 表示从坐标 (i,j)(i,j) 到终点所需的最小初始值
            int[,] dp = new int[n+1, m+1];
            for (int row = 0; row <= m; row++)
                for (int col = 0; col <= n; col++)
                    dp[row, col] = int.MaxValue;
            
            dp[n,m - 1] = dp[n - 1, m] = 1;
            for (int i = n - 1; i >= 0; --i)
            {
                for (int j = m - 1; j >= 0; --j)
                {
                    dp[i,j] = Math.Max(Math.Min(dp[i + 1, j], dp[i, j + 1]) - dungeon[i][j], 1);
                }
            }
            return dp[0, 0];
        }
    }
}
