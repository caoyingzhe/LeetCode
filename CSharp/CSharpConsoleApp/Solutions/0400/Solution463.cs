using System;
namespace CSharpConsoleApp.Solutions
{
    /*
     * @lc app=leetcode.cn id=463 lang=csharp
     *
     * [463] 岛屿的周长
     *
     * https://leetcode-cn.com/problems/island-perimeter/description/
     *
     * algorithms
     * Easy (71.47%)
     * Likes:    412
     * Dislikes: 0
     * Total Accepted:    69K
     * Total Submissions: 96.5K
     * Testcase Example:  '[[0,1,0,0],[1,1,1,0],[0,1,0,0],[1,1,0,0]]'
     *
     * 给定一个 row x col 的二维网格地图 grid ，其中：grid[i][j] = 1 表示陆地， grid[i][j] = 0 表示水域。
     * 
     * 网格中的格子 水平和垂直 方向相连（对角线方向不相连）。整个网格被水完全包围，但其中恰好有一个岛屿（或者说，一个或多个表示陆地的格子相连组成的岛屿）。
     * 
     * 岛屿中没有“湖”（“湖” 指水域在岛屿内部且不和岛屿周围的水相连）。格子是边长为 1 的正方形。网格为长方形，且宽度和高度均不超过 100
     * 。计算这个岛屿的周长。
     *
     * 
     * 示例 1：
     * 输入：grid = [[0,1,0,0],[1,1,1,0],[0,1,0,0],[1,1,0,0]]
     * 输出：16
     * 解释：它的周长是上面图片中的 16 个黄色的边
     * 
     * 示例 2：
     * 输入：grid = [[1]]
     * 输出：4
     * 
     * 
     * 示例 3：
     * 输入：grid = [[1,0]]
     * 输出：4
     * 
     * 
     * 提示：
     * row == grid.length
     * col == grid[i].length
     * 1 <= row, col <= 100
     * grid[i][j] 为 0 或 1
     */

    // @lc code=start
    public class Solution463 : SolutionBase
    {
        /// <summary>
        /// 难度
        /// </summary>
        public override Difficulity GetDifficulity() { return Difficulity.Easy; }
        /// <summary>
        /// 关键字:
        /// </summary>
        public override string[] GetKeyWords() { return new string[] { }; }
        /// <summary>
        /// 标签：
        /// </summary>
        public override Tag[] GetTags() { return new Tag[] { Tag.HashTable}; }

        public override bool Test(System.Diagnostics.Stopwatch sw)
        {
            bool isSuccess = true;
            int[][] grid;
            int result, checkResult;

            checkResult = 16;
            grid = new int[][]
            {
                new int[] { 0, 1, 0, 0},
                new int[] { 1, 1, 1, 0},
                new int[] { 0, 1, 0, 0},
                new int[] { 1, 1, 0, 0},
            };
            result = IslandPerimeter(grid);
            isSuccess &= result == checkResult;
            Print("isSuccess = {0} | result = {1} | anticipated = {2}", isSuccess, (result), (checkResult));
            //

            checkResult = 4;
            grid = new int[][]
            {
                new int[] { 1,  0}
            };
            result = IslandPerimeter(grid);
            isSuccess &= result == checkResult;
            Print("isSuccess = {0} | result = {1} | anticipated = {2}", isSuccess, (result), (checkResult));
            //
            checkResult = 4;
            grid = new int[][]
            {
                new int[] { 1,  0}
            };
            result = IslandPerimeter(grid);
            isSuccess &= result == checkResult;
            Print("isSuccess = {0} | result = {1} | anticipated = {2}", isSuccess, (result), (checkResult));
            //  
            return isSuccess;
        }
        /// <summary>
        /// 5833/5833 cases passed (224 ms)
        /// Your runtime beats 87.5 % of csharp submissions
        /// Your memory usage beats 6.25 % of csharp submissions(29.5 MB)
        /// </summary>
        /// <param name="grid"></param>
        /// <returns></returns>
        public int IslandPerimeter(int[][] grid)
        {
            int len = 0;
            int m = grid.Length;
            int n = grid[0].Length;
            for(int i=0; i<m; i++)
            {
                for(int j=0;j<n;j++)
                {
                    if (grid[i][j] == 1)
                    {
                        int L = (j == 0)     ? 0 : -grid[i][j-1];
                        int R = (j == n - 1) ? 0 : -grid[i][j+1];
                        int U = (i == 0)     ? 0 : -grid[i-1][j];
                        int D = (i == m - 1) ? 0 : -grid[i+1][j];
                    
                        len += 4 + L + R + U + D;
                    }
                }
            }
            return len;
        }
    }
    // @lc code=end


}
