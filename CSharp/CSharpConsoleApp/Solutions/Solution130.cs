using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpConsoleApp.Solutions
{
    class Solution130: SolutionBase
    {
        /// <summary>
        /// 难易度:
        /// </summary>
        public override Difficulity GetDifficulity() { return Difficulity.Medium; }
        /// <summary>
        /// 关键字:
        ///     DFS => 广度优先搜索（算法导论 第六部分 图算法 22.1章节）
        ///     BFS => 深度优先搜索（算法导论 第六部分 图算法 22.2章节）
        /// </summary>
        public override string[] GetKeyWords() { return new string[] { "DFS", "BFS" }; }
        /// <summary>
        /// 标签： 图
        /// </summary>
        public override Tag[] GetTags() { return new Tag[] { Tag.Graph, Tag.BreadthFirstSearch }; }

        //深度优先搜索(DFS)和广度优先搜索(BFS).这两种算法对有向图与无向图均适用
        public override bool Test(Stopwatch sw)
        {
            bool isSuccess = true;
            char[][] board;
            char[][] checkResult;

            board = new char[][] {
                new char[] { 'X', 'X', 'X', 'X' },
                new char[] { 'X', 'O', 'O', 'X' },
                new char[] { 'X', 'X', 'O', 'X' },
                new char[] { 'X', 'O', 'X', 'X' } };
            checkResult = new char[][] {
                new char[] {'X','X','X','X'},
                new char[] {'X','X','X','X'},
                new char[] {'X','X','X','X'},
                new char[] {'X','O','X','X'}};
            isSuccess = Solve(board, checkResult);
            
            board = new char[][] {
                new char[] { 'X', 'O', 'X' },
                new char[] { 'X', 'O', 'X' },
                new char[] { 'X', 'O', 'X' } };
            checkResult = new char[][] {
                new char[] { 'X', 'O', 'X' },
                new char[] { 'X', 'O', 'X' },
                new char[] { 'X', 'O', 'X' } };
            isSuccess &= Solve(board, checkResult);

            board = new char[][]
            {
               new char[] { 'X','O','X','O','X','O'},
               new char[] { 'O','X','O','X','O','X'},
               new char[] { 'X','O','X','O','X','O'},
               new char[] { 'O','X','O','X','O','X'} };
            checkResult = new char[][] {
               new char[] { 'X','O','X','O','X','O'},
               new char[] { 'O','X','X','X','X','X'},
               new char[] { 'X','X','X','X','X','O'},
               new char[] { 'O','X','O','X','O','X'} };
            isSuccess &= Solve(board, checkResult);
            return isSuccess;
        }
        public bool Solve(char[][] board, char[][] checkResult)
        {
            char[][] result = Solve_20210405(board);

            //System.Diagnostics.Debug.Print("---- anticipated ----\n" + GetArrayStr(checkResult));
            bool isSuccess = IsArraySame(result, checkResult);
            //System.Diagnostics.Debug.Print(string.Format("isSuccess = {0} ", isSuccess));
           
            return isSuccess;
        }

        public void CloneArray(char[][] board, char[][] boardClone)
        {
            int m = board.Length;
            int n = board[0].Length;
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                    boardClone[i][j] = board[i][j];
            }
        }
        public char[][] Solve_20210405(char[][] board)
        {
            if (board == null || board.Length <= 1 || board[0].Length <= 1)
            {
                return board;
            }

            // 行数 列数
            int m = board.Length;
            int n = board[0].Length;

            char[][] boardClone = new char[m][];
            for (int i = 0; i < m; i++)
            {
                boardClone[i] = new char[n];
                for (int j = 0; j < n; j++)
                    boardClone[i][j] = board[i][j];
            }

            // 1、四条边上开始深度遍历，边上O及与边上O相连的全变为*
            for (int i = 0; i < m; i++)
            {
                // 第一列元素开始深度遍历
                dfs(board, i, 0);

                //if (!IsArraySame(board, boardClone))
                //{
                //    System.Diagnostics.Debug.Print("------ 第一列开始深度遍历  --i=[" + i + "]------\n" + GetArrayStr(board));
                //    CloneArray(board, boardClone);
                //}
                    
                // 最后一列元素开始深度遍历
                dfs(board, i, n - 1);
                //if (!IsArraySame(board, boardClone))
                //{
                //    System.Diagnostics.Debug.Print("------ 最后一列开始深度遍历--i=[" + i + "]------\n" + GetArrayStr(board));
                //    CloneArray(board, boardClone);
                //}
            }

            for (int j = 0; j < n; j++)
            {
                // 第一行元素开始深度遍历
                dfs(board, 0, j);
                //if (!IsArraySame(board, boardClone))
                //{
                //    System.Diagnostics.Debug.Print("------第一行元素开始深度遍历   j=[" + j + "]----\n" + GetArrayStr(board));
                //    CloneArray(board, boardClone);
                //}
                // 最后一行元素开始深度遍历
                dfs(board, m - 1, j);
                //if (!IsArraySame(board, boardClone))
                //{
                //    System.Diagnostics.Debug.Print("------最后一行元素开始深度遍历 j=[" + j + "]------\n" + GetArrayStr(board));
                //    CloneArray(board, boardClone);
                //}
            }

            // 2、其他为O的元素替换为X
            replaceAToB(board, m, n, 'O', 'X');
            //System.Diagnostics.Debug.Print("------其他为O的元素替换为X------\n" + GetArrayStr(board));

            // 3、为*的元素替换为O
            replaceAToB(board, m, n, '*', 'O');
            //System.Diagnostics.Debug.Print("------为*的元素替换为O------\n" + GetArrayStr(board));

            return board;
        }

        // 替换元素
        private void replaceAToB(char[][] board, int rowNum, int colNum, char a, char b)
        {
            for (int i = 0; i < rowNum; i++)
            {
                for (int j = 0; j < colNum; j++)
                {
                    if (board[i][j] == a)
                    {
                        board[i][j] = b;
                    }
                }
            }
        }// 深度遍历
        private void dfs(char[][] board, int row, int col)
        {
            // 非法判断
            if (row < 0 || row >= board.Length || col < 0 || col >= board[0].Length)
            {
                return;
            }
            if (board[row][col] == 'O')
            {
                // 替换为*
                board[row][col] = '*';
                // 深度遍历上下左右
                dfs(board, row - 1, col);
                dfs(board, row + 1, col);
                dfs(board, row, col - 1);
                dfs(board, row, col + 1);
            }
        }
    }
}
