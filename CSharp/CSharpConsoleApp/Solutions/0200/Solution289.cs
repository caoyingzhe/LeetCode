using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpConsoleApp.Solutions
{
    /*
     * @lc app=leetcode.cn id=289 lang=csharp
     *
     * [289] 生命游戏
     *
     * https://leetcode-cn.com/problems/game-of-life/description/
     *
     * Category	Difficulty	Likes	Dislikes
     * algorithms	Medium (74.97%)	338	-
     * Tags
     * array
     * 
     * Companies
     * dropbox | google | snapchat | twosigma
     * 
     * Total Accepted:    47.4K
     * Total Submissions: 63.3K
     * Testcase Example:  '[[0,1,0],[0,0,1],[1,1,1],[0,0,0]]'
     *
     * 根据 百度百科 ，生命游戏，简称为生命，是英国数学家约翰·何顿·康威在 1970 年发明的细胞自动机。
     * 
     * 给定一个包含 m × n 个格子的面板，每一个格子都可以看成是一个细胞。每个细胞都具有一个初始状态：1 即为活细胞（live），或 0
     * 即为死细胞（dead）。每个细胞与其八个相邻位置（水平，垂直，对角线）的细胞都遵循以下四条生存定律：
     * 
     * 如果活细胞周围八个位置的活细胞数少于两个，则该位置活细胞死亡；
     * 如果活细胞周围八个位置有两个或三个活细胞，则该位置活细胞仍然存活；
     * 如果活细胞周围八个位置有超过三个活细胞，则该位置活细胞死亡；
     * 如果死细胞周围正好有三个活细胞，则该位置死细胞复活；
     * 
     * 下一个状态是通过将上述规则同时应用于当前状态下的每个细胞所形成的，其中细胞的出生和死亡是同时发生的。给你 m x n 网格面板 board
     * 的当前状态，返回下一个状态。
     * 
     * 示例 1：
     * 输入：board = [[0,1,0],[0,0,1],[1,1,1],[0,0,0]]
     * 输出：        [[0,0,0],[1,0,1],[0,1,1],[0,1,0]]
     * 
     * [[0,0,0],
     *  [1,0,1],
     *  [0,1,1],
     *  [0,1,0]]
     * 
     * 示例 2：
     * 输入：board = [[1,1],[1,0]]
     * 输出：[[1,1],[1,1]]
     * 
     * 提示：
     * m == board.length
     * n == board[i].length
     * 1 
     * board[i][j] 为 0 或 1
     * 
     * 进阶：
     * 你可以使用原地算法解决本题吗？请注意，面板上所有格子需要同时被更新：你不能先更新某些格子，然后使用它们的更新后的值再更新其他格子。
     * 本题中，我们使用二维数组来表示面板。原则上，面板是无限的，但当活细胞侵占了面板边界时会造成问题。你将如何解决这些问题？
     * 
     * 本题关键在于使用位运算，充分利用int类型 32比特的空间。
     */
    class Solution289 : SolutionBase
    {
        /// <summary>
        /// 难度
        /// </summary>
        public override Difficulity GetDifficulity() { return Difficulity.Medium; }
        /// <summary>
        /// 关键字:
        /// </summary>
        public override string[] GetKeyWords() { return new string[] { "位运算", }; }
        /// <summary>
        /// 标签：
        /// </summary>
        public override Tag[] GetTags() { return new Tag[] { Tag.Array }; }

        public override bool Test(System.Diagnostics.Stopwatch sw)
        {
            int[][] board;
            bool isSuccess = true;

            Print("5 & 3 = " + (5 & 3));
            Print("11 | 1 = " + (11 | 1));
            Print("11 ^ 1 = " + (11 ^ 1));


            board = new int[][] {
                new int[] { 0,1,0 },
                new int[] { 0,0,1 },
                new int[] { 1,1,1 },
                new int[] { 0, 0, 0 }
            };
            Print(GetArray2DStr<int>(board));
            GameOfLife(board);
            Print(GetArray2DStr<int>(board));
            //isSuccess &= result == checkResult;
            //System.Diagnostics.Debug.Print("isSuccess = {3} | Convert {0} to {1} | anticipated : {2} | ", board, result, checkResult, isSuccess);
            return isSuccess;
        }

        public void GameOfLife(int[][] board)
        {
            int m = board.Length;
            int n = board[0].Length;
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    CheckChange(board, i, j, m, n); //更新board的值，更新值左移一位，保留源值在最后一位。
                }
            }
            Print(GetArray2DStr<int>(board));
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    board[i][j] = board[i][j] >> 1;  //位运算，恢复board的值为最右边一位的值。
                }
            }
        }

        //更新board的值，更新值左移一位，保留源值在最后一位。
        void CheckChange(int[][] board, int row, int col, int rowMax, int colMax)
        {
            int sum = 0;
            for (int i = -1; i <= 1; i++)
            {
                int r = row + i;
                if (r < 0 || r == rowMax)
                    continue;
                for (int j = -1; j <= 1; j++)
                {
                    if (i == 0 && j == 0)
                        continue;

                    int c = col + j;
                    if (c < 0 || c == colMax)
                        continue;
                    sum += board[r][c] & 1; //更新Sum, 判断标准为board的值最后一位。（无视倒数第二位）
                }
            }

            int org = board[row][col];
            if (board[row][col] == 1)
            {
                if (sum < 2)
                    board[row][col] = 1; // & org; // return 0;  (binary 01 | org=1)
                else if (sum <= 3)
                    board[row][col] = 3; // 2 & org; //return 1;  (binary 10 | org=1)
                else
                    board[row][col] = 1; // & org; // return 0;  (binary 01 | org=1)
            }
            else
            {
                if (sum == 3)
                    board[row][col] = 2; //return 1; (binary 10 | org=0)
                else
                    board[row][col] = org << 1;
            }
        }
    }
}
