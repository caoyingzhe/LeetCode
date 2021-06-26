using System;
namespace CSharpConsoleApp.Solutions
{
    /*
     * @lc app=leetcode.cn id=547 lang=csharp
     *
     * [547] 省份数量
     *
     * https://leetcode-cn.com/problems/number-of-provinces/description/
     *
     * Category	Difficulty	Likes	Dislikes
     * algorithms	Medium (61.59%)	565	-
     * Tags
     * depth-first-search | union-find
     * 
     * Companies
     * bloomberg | twosigma
     * 
     * Total Accepted:    137.9K
     * Total Submissions: 223.8K
     * Testcase Example:  '[[1,1,0],[1,1,0],[0,0,1]]'
     *
     * 有 n 个城市，其中一些彼此相连，另一些没有相连。如果城市 a 与城市 b 直接相连，且城市 b 与城市 c 直接相连，那么城市 a 与城市 c
     * 间接相连。
     * 省份 是一组直接或间接相连的城市，组内不含其他没有相连的城市。
     * 
     * 给你一个 n x n 的矩阵 isConnected ，其中 isConnected[i][j] = 1 表示第 i 个城市和第 j 个城市直接相连，而
     * isConnected[i][j] = 0 表示二者不直接相连。
     * 
     * 返回矩阵中 省份 的数量。
     * 
     * 
     * 示例 1：     * 输入：isConnected = [[1,1,0],[1,1,0],[0,0,1]]
     * 输出：2
     * 
     * 
     * 示例 2：
     * 输入：isConnected = [[1,0,0],[0,1,0],[0,0,1]]
     * 输出：3
     * 
     * 提示：
     * 1 <= n <= 200
     * n == isConnected.length
     * n == isConnected[i].length
     * isConnected[i][j] 为 1 或 0
     * isConnected[i][i] == 1
     * isConnected[i][j] == isConnected[j][i]
     */

    // @lc code=start
    public class Solution547 : SolutionBase
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
        public override Tag[] GetTags() { return new Tag[] { Tag.DepthFirstSearch , Tag.UnionFind }; }

        public override bool Test(System.Diagnostics.Stopwatch sw)
        {
            bool isSuccess = true;
            //TODO
            return isSuccess;
        }

        //作者：LeetCode-Solution
        //链接：https://leetcode-cn.com/problems/number-of-provinces/solution/sheng-fen-shu-liang-by-leetcode-solution-eyk0/

        /// <summary>
        /// 113/113 cases passed (124 ms)
        /// Your runtime beats 100 % of csharp submissions
        /// Your memory usage beats 45.07 % of csharp submissions(28.4 MB)
        /// </summary>
        /// <param name="isConnected"></param>
        /// <returns></returns>
        public int FindCircleNum(int[][] isConnected)
        {
            int n = isConnected.Length;

            //按列记忆访问列表
            bool[] visited = new bool[n];
            int circles = 0;
            for (int row = 0; row < n; row++)
            {
                if (!visited[row])
                {
                    DFS(isConnected, visited, n, row);
                    circles++;
                }
            }
            return circles;
        }

        public void DFS(int[][] isConnected, bool[] visited, int n, int row)
        {
            for (int col = 0; col < n; col++)
            {
                if (isConnected[row][col] == 1 && !visited[col])
                {
                    visited[col] = true;
                    DFS(isConnected, visited, n, col);
                }
            }
        }

        
    }
    // @lc code=end


}
