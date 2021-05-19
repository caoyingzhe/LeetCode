using System;
using System.Collections.Generic;
namespace CSharpConsoleApp.Solutions
{
    /*
     * @lc app=leetcode.cn id=52 lang=csharp
     *
     * [52] N皇后 II
     *
     * https://leetcode-cn.com/problems/n-queens-ii/description/
     *
     * algorithms
     * Hard (82.37%)
     * Likes:    258
     * Dislikes: 0
     * Total Accepted:    64.3K
     * Total Submissions: 78.1K
     * Testcase Example:  '4'
     *
     * n 皇后问题 研究的是如何将 n 个皇后放置在 n×n 的棋盘上，并且使皇后彼此之间不能相互攻击。
     * 
     * 给你一个整数 n ，返回 n 皇后问题 不同的解决方案的数量。
     * 
     * 示例 1：
     * 输入：n = 4
     * 输出：2
     * 解释：如上图所示，4 皇后问题存在两个不同的解法。
     * 
     * 示例 2：
     * 输入：n = 1
     * 输出：1
     * 
     * 提示：
     * 1 <= n <= 9
     * 皇后彼此不能相互攻击，也就是说：任何两个皇后都不能处于同一条横行、纵行或斜线上。
     * 
     */
    public class Solution52 : SolutionBase
    {
        /// <summary>
        /// 难度
        /// </summary>
        public override Difficulity GetDifficulity() { return Difficulity.Hard; }
        /// <summary>
        /// 关键字:
        /// </summary>
        public override string[] GetKeyWords() { return new string[] {  "回溯", "位运算"}; }
        /// <summary>
        /// 标签： 
        /// </summary>
        public override Tag[] GetTags() { return new Tag[] { Tag.Backtracking, Tag.BitManipulation }; }
        public override bool Test(System.Diagnostics.Stopwatch sw)
        {
            bool isSuccess = true;

            TotalNQueens(4);
            return isSuccess;
        }

        /// <summary>
        /// 9/9 cases passed (56 ms)
        /// Your runtime beats 44 % of csharp submissions
        /// Your memory usage beats 20 % of csharp submissions(16.8 MB)
        /// 
        /// 作者：LeetCode-Solution
        /// 链接：https://leetcode-cn.com/problems/n-queens-ii/solution/nhuang-hou-ii-by-leetcode-solution/
        /// </summary>
        /// <param name="n"></param>
        /// <param name="row"></param>
        /// <param name="columns"></param>
        /// <param name="diagonals1"></param>
        /// <param name="diagonals2"></param>
        /// <returns></returns>
        public int TotalNQueens(int n)
        {
            HashSet<int> columns = new HashSet<int>();
            HashSet<int> diagonals1 = new HashSet<int>();
            HashSet<int> diagonals2 = new HashSet<int>();
            return Backtrack(n, 0, columns, diagonals1, diagonals2);
        }


        /// <summary>
        ///
        /// diagonal : adj.斜线的;对角线的; n.对角线;斜线
        /// </summary>
        /// <param name="n">棋盘大小</param>
        /// <param name="row">当前处理的行</param>
        /// <param name="columns">保存皇后的列信息</param>
        /// <param name="diagonals1">保存皇后的斜方向1信息</param>
        /// <param name="diagonals2">保存皇后的斜方向2信息</param>
        /// <returns></returns>
        public int Backtrack(int n, int row, HashSet<int> columns, HashSet<int> diagonals1, HashSet<int> diagonals2)
        {
            //Print("Backtrack row={0}| {1} / {2} / {3}", row, GetArrayStr(columns), GetArrayStr(diagonals2), GetArrayStr(diagonals2));
            if (row == n)
            {
                return 1;  //行号与n相同，直接返回1  ？ （原理不懂）
            }
            else
            {
                int count = 0;
                for (int i = 0; i < n; i++) //i代表列索引
                {
                    if (columns.Contains(i))
                    {
                        continue;
                    }

                    int diagonal1 = row - i;            //第i列对应的斜线1。
                    if (diagonals1.Contains(diagonal1))
                    {
                        continue;
                    }

                    int diagonal2 = row + i;
                    if (diagonals2.Contains(diagonal2))//第i列对应的斜线2。
                    {
                        continue;
                    }

                    //回溯处理
                    columns.Add(i);
                    diagonals1.Add(diagonal1);
                    diagonals2.Add(diagonal2);

                    int tmpCount = Backtrack(n, row + 1, columns, diagonals1, diagonals2); //使用 行号+1 试错
                    //if (tmpCount == 1) Print("i=col= {0} row={1}| ", i, row);
                    count += tmpCount;

                    columns.Remove(i);
                    diagonals1.Remove(diagonal1);
                    diagonals2.Remove(diagonal2);
                }
                return count;
            }
        }
    }
}
