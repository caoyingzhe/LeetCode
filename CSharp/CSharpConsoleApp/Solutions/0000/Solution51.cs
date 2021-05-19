using System;
using System.Collections.Generic;

namespace CSharpConsoleApp.Solutions
{
    /*
     * @lc app=leetcode.cn id=51 lang=csharp
     *
     * [51] N 皇后
     *
     * https://leetcode-cn.com/problems/n-queens/description/
     *
     * algorithms
     * Hard (73.78%)
     * Likes:    879
     * Dislikes: 0
     * Total Accepted:    124.6K
     * Total Submissions: 168.8K
     * Testcase Example:  '4'
     *
     * n 皇后问题 研究的是如何将 n 个皇后放置在 n×n 的棋盘上，并且使皇后彼此之间不能相互攻击。
     * 
     * 给你一个整数 n ，返回所有不同的 n 皇后问题 的解决方案。
     * 每一种解法包含一个不同的 n 皇后问题 的棋子放置方案，该方案中 'Q' 和 '.' 分别代表了皇后和空位。
     * 
     * 示例 1：
     * 输入：n = 4
     * 输出：[[".Q..","...Q","Q...","..Q."],["..Q.","Q...","...Q",".Q.."]]
     * 解释：如上图所示，4 皇后问题存在两个不同的解法。
     * 
     * 
     * 示例 2：
     * 输入：n = 1
     * 输出：[["Q"]]
     * 
     * 提示：
     * 1 <= n <= 9
     * 皇后彼此不能相互攻击，也就是说：任何两个皇后都不能处于同一条横行、纵行或斜线上。
     * 
     */
    public class Solution51 : SolutionBase
    {
        /// <summary>
        /// 难度
        /// </summary>
        public override Difficulity GetDifficulity() { return Difficulity.Hard; }
        /// <summary>
        /// 关键字:
        /// </summary>
        public override string[] GetKeyWords() { return new string[] { "Back_Tracing" }; }
        /// <summary>
        /// 标签： 
        /// </summary>
        public override Tag[] GetTags() { return new Tag[] { Tag.Backtracking }; }
        public override bool Test(System.Diagnostics.Stopwatch sw)
        {
            bool isSuccess = true;
            var result = SolveNQueens(4);
            Print(GetArray2DStr(result));
            return isSuccess;
        }

        /// <summary>
        /// 9/9 cases passed (288 ms)
        /// Your runtime beats 63.24 % of csharp submissions
        /// Your memory usage beats 22.06 % of csharp submissions(33.2 MB)
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
        public IList<IList<string>> SolveNQueens(int n)
        {
            HashSet<int> columns = new HashSet<int>();
            HashSet<int> diagonals1 = new HashSet<int>();
            HashSet<int> diagonals2 = new HashSet<int>();
            List<IList<String>> result = new List<IList<String>>();
            int[] queens = new int[n];
            Backtrack(result, queens, n, 0, columns, diagonals1, diagonals2);
            
            return result;
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
        public int Backtrack(IList<IList<String>> result, int[] queens, int n, int row, HashSet<int> columns, HashSet<int> diagonals1, HashSet<int> diagonals2)
        {
            //Print("Backtrack row={0}| {1} / {2} / {3}", row, GetArrayStr(columns), GetArrayStr(diagonals2), GetArrayStr(diagonals2));
            if (row == n)
            {
                List<String> board = GenerateBoard(queens, n);  //52题中不存在的处理
                result.Add(board);                              //52题中不存在的处理
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
                    queens[row] = i;  //52题中不存在的处理
                    columns.Add(i);
                    diagonals1.Add(diagonal1);
                    diagonals2.Add(diagonal2);

                    int tmpCount = Backtrack(result, queens, n, row + 1, columns, diagonals1, diagonals2); //使用 行号+1 试错
                    //if (tmpCount == 1) Print("i=col= {0} row={1}| ", i, row);
                    count += tmpCount;

                    queens[row] = -1;  //52题中不存在的处理
                    columns.Remove(i);
                    diagonals1.Remove(diagonal1);
                    diagonals2.Remove(diagonal2);
                }
                return count;
            }
        }

        /// <summary>
        /// 计算出皇后位置，保存为字符串列表。
        /// 52题中不存在的处理
        /// </summary>
        /// <param name="queens"></param>
        /// <param name="n"></param>
        /// <returns></returns>
        public List<String> GenerateBoard(int[] queens, int n)
        {
            List<String> board = new List<String>();
            for (int i = 0; i < n; i++)
            {
                char[] row = new char[n];
                for (int j = 0; j < n; j++) row[j] = '.';
                row[queens[i]] = 'Q';
                board.Add(new String(row));
            }
            return board;
        }
    }
}
