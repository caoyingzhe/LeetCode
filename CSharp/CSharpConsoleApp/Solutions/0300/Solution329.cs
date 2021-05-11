using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpConsoleApp.Solutions._0300
{
    /*
     * @lc app=leetcode.cn id=329 lang=csharp
     *
     * [329] 矩阵中的最长递增路径
     *
     * https://leetcode-cn.com/problems/longest-increasing-path-in-a-matrix/description/
     *
     * Category	Difficulty	Likes	Dislikes
     * algorithms	Hard (46.97%)	454	-
     * Tags
     * depth-first-search | topological-sort | memoization
     * 
     * Companies
     * google
     * 
     * Total Accepted:    44.5K
     * Total Submissions: 94.3K
     * Testcase Example:  '[[9,9,4],[6,6,8],[2,1,1]]'
     *
     * 给定一个 m x n 整数矩阵 matrix ，找出其中 最长递增路径 的长度。
     * 
     * 对于每个单元格，你可以往上，下，左，右四个方向移动。 你 不能 在 对角线 方向上移动或移动到 边界外（即不允许环绕）。
     * 
     * 
     * 示例 1：
     * 输入：matrix = [[9,9,4],[6,6,8],[2,1,1]]
     * 输出：4 
     * 解释：最长递增路径为 [1, 2, 6, 9]。
     * 
     * 示例 2：
     * 输入：matrix = [[3,4,5],[3,2,6],[2,2,1]]
     * 输出：4 
     * 解释：最长递增路径是 [3, 4, 5, 6]。注意不允许在对角线方向上移动。
     * 
     * 
     * 示例 3：
     * 输入：matrix = [[1]]
     * 输出：1
     * 
     * 
     * 提示：
     * m == matrix.Length
     * n == matrix[i].Length
     * 1 <= m, n <= 200
     * 0 <= matrix[i][j] <= 231 - 1
     * 
     */

    class Solution329 : SolutionBase
    {
        /// <summary>
        /// 难易度:
        /// </summary>
        public override Difficulity GetDifficulity() { return Difficulity.Hard; }
        /// <summary>
        /// 关键字:
        /// </summary>
        public override string[] GetKeyWords() { return new string[] { "深度优先搜索", "拓扑逻辑排序", "记忆化", "" }; }
        /// <summary>
        /// 标签： binary-search | divide-and-conquer | sort | binary-indexed-tree | segment-tree
        /// </summary>
        public override Tag[] GetTags() { return new Tag[] { Tag.DepthFirstSearch, Tag.TopologicalSort, Tag.Memoization, }; }

        public override bool Test(System.Diagnostics.Stopwatch sw)
        {
            bool isSuccess = true;
            int[][] matrix;
            int result;
            int checkresult;

            matrix = new int[][] { 
               new int[] { 9, 9, 4 },
               new int[] { 6, 6, 8 },
               new int[] { 2, 1, 1 }
            };
            checkresult = 3;
            result = LongestIncreasingPath(matrix);
            isSuccess &= (result == checkresult);
            Print("isSuccess = " + isSuccess + " | Anticipated = " + checkresult + " | Result = " + result);

            return isSuccess;
        }

        ///上下左右的区域的偏移量
        public int[][] dirs = new int[][]{ new int[]{ -1, 0 }, new int[] { 1, 0 }, new int[] { 0, -1 }, new int[] { 0, 1 } };
        public int m, n;

        /// <summary>
        /// 138/138 cases passed (156 ms)
        ///  Your runtime beats 58.33 % of csharp submissions
        ///  Your memory usage beats 91.67 % of csharp submissions(28.2 MB)
        ///  
        ///  作者：LeetCode-Solution
        ///  链接：https://leetcode-cn.com/problems/longest-increasing-path-in-a-matrix/solution/ju-zhen-zhong-de-zui-chang-di-zeng-lu-jing-by-le-2/
        /// </summary>
        /// <param name="matrix"></param>
        /// <returns></returns>
        public int LongestIncreasingPath(int[][] matrix)
        {
            if (matrix == null || matrix.Length == 0 || matrix[0].Length == 0)
            {
                return 0;
            }
            m = matrix.Length;
            n = matrix[0].Length;

            //用于存储节点的计算结果的矩阵
            int[][] memo = new int[m][];
            for (int i = 0; i < m; i++)
                memo[i] = new int[n];

            //广度优先搜索法
            int ans = 0;
            for (int i = 0; i < m; ++i)
            {
                for (int j = 0; j < n; ++j)
                {
                    ans = Math.Max(ans, DFS(matrix, i, j, memo));
                }
            }
            return ans;
        }

        //广度优先搜索法
        public int DFS(int[][] matrix, int row, int column, int[][] memo)
        {
            //记忆化计算结果
            if (memo[row][column] != 0)
            {
                return memo[row][column];
            }
            ++memo[row][column]; //自身节点 +1

            //搜索周围的最大路径， 其中[dirs]为在上下左右的区域，
            foreach (int[] dir in dirs)
            {
                int newRow = row + dir[0], newColumn = column + dir[1];
                if (newRow >= 0 && newRow < m && newColumn >= 0 && newColumn < n  //判断是否超界
                    && matrix[newRow][newColumn] > matrix[row][column])           //判断周围节点值是否大于自己
                {
                    //如果周围节点路径大于自己，取(自身节点的最大路径)和(周围节点路径+1)中大者, +1原因是到周围结点路径增加了1.
                    memo[row][column] = Math.Max(memo[row][column], DFS(matrix, newRow, newColumn, memo) + 1);
                }
            }
            return memo[row][column];
        }
    }
}
