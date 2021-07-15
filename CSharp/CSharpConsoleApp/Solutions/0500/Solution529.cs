using System;
namespace CSharpConsoleApp.Solutions
{
    /*
 * @lc app=leetcode.cn id=529 lang=csharp
 *
 * [529] 扫雷游戏
 *
 * https://leetcode-cn.com/problems/minesweeper/description/
 *
 * Category	Difficulty	Likes	Dislikes
 * algorithms	Medium (65.04%)	235	-
 * Tags
 * depth-first-search | breadth-first-search
 * 
 * Companies
 * amazon
 * Total Accepted:    36.5K
 * Total Submissions: 56.1K
 * Testcase Example:  '[["E","E","E","E","E"],["E","E","M","E","E"],["E","E","E","E","E"],["E","E","E","E","E"]]\n' +
  '[3,0]'
 *
 * 让我们一起来玩扫雷游戏！
 * 
 * 给定一个代表游戏板的二维字符矩阵。 'M' 代表一个未挖出的地雷，'E' 代表一个未挖出的空方块，'B'
 * 代表没有相邻（上，下，左，右，和所有4个对角线）地雷的已挖出的空白方块，数字（'1' 到 '8'）表示有多少地雷与这块已挖出的方块相邻，'X'
 * 则表示一个已挖出的地雷。
 * 现在给出在所有未挖出的方块中（'M'或者'E'）的下一个点击位置（行和列索引），根据以下规则，返回相应位置被点击后对应的面板：
 * 
 * 如果一个地雷（'M'）被挖出，游戏就结束了- 把它改为 'X'。
 * 如果一个没有相邻地雷的空方块（'E'）被挖出，修改它为（'B'），并且所有和其相邻的未挖出方块都应该被递归地揭露。
 * 如果一个至少与一个地雷相邻的空方块（'E'）被挖出，修改它为数字（'1'到'8'），表示相邻地雷的数量。
 * 如果在此次点击中，若无更多方块可被揭露，则返回面板。
 * 
 * 示例 1：
 * 输入: 
 * [['E', 'E', 'E', 'E', 'E'],
 * ⁠['E', 'E', 'M', 'E', 'E'],
 * ⁠['E', 'E', 'E', 'E', 'E'],
 * ⁠['E', 'E', 'E', 'E', 'E']]
 * Click : [3,0]
 * 
 * 输出: 
 * [['B', '1', 'E', '1', 'B'],
 * ⁠['B', '1', 'M', '1', 'B'],
 * ⁠['B', '1', '1', '1', 'B'],
 * ⁠['B', 'B', 'B', 'B', 'B']]
 * 解释:
 * 
 * 示例 2：
 * 输入: 
 * [['B', '1', 'E', '1', 'B'],
 * ⁠['B', '1', 'M', '1', 'B'],
 * ⁠['B', '1', '1', '1', 'B'],
 * ⁠['B', 'B', 'B', 'B', 'B']]
 * Click : [1,2]
 * 
 * 输出: 
 * [['B', '1', 'E', '1', 'B'],
 * ⁠['B', '1', 'X', '1', 'B'],
 * ⁠['B', '1', '1', '1', 'B'],
 * ⁠['B', 'B', 'B', 'B', 'B']]
 * 解释:
 * 
 * 
 * 注意：
 * 输入矩阵的宽和高的范围为 [1,50]。
 * 点击的位置只能是未被挖出的方块 ('M' 或者 'E')，这也意味着面板至少包含一个可点击的方块。
 * 输入面板不会是游戏结束的状态（即有地雷已被挖出）。
 * 简单起见，未提及的规则在这个问题中可被忽略。例如，当游戏结束时你不需要挖出所有地雷，考虑所有你可能赢得游戏或标记方块的情况。
 */

    // @lc code=start
    public class Solution529 : SolutionBase
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
        public override Tag[] GetTags() { return new Tag[] { Tag.BreadthFirstSearch, Tag.DepthFirstSearch }; }

        /// <summary>
        /// </summary>
        /// <param name="sw"></param>
        /// <returns></returns>
        public override bool Test(System.Diagnostics.Stopwatch sw)
        {
            bool isSuccess = true;
            return isSuccess;
        }

        //周围的xy偏移量
        private int[] X = { 0, 0, 1, -1, -1, -1, 1, 1 };
        private int[] Y = { -1, 1, 0, 0, -1, 1, -1, 1 };

        private char[][] b;//目标数组
        private int m, n;

        public char[][] UpdateBoard(char[][] board, int[] click)
        {
            int x = click[0], y = click[1];
            n = board.Length; m = board[0].Length;
            this.b = board;

            if (b[x][y] == 'E') //无雷
            {
                DFS(x, y);
            }
            else if (b[x][y] == 'M') //有雷
            {
                b[x][y] = 'X';
            }
            return b;
        }

        public void DFS(int x, int y)
        {
            if (!(x >= 0 && y >= 0 && x < n && y < m)) return; //越界检查，理论不会被执行

            if (b[x][y] == 'E') //无雷的情况，更新周围的无雷区
            {
                int count = Count(x, y);
                if (count == 0) //周围无雷，全部更新为无雷区 B
                {
                    b[x][y] = 'B';
                    for (int i = 0; i < 8; i++)
                    {
                        DFS(x + X[i], y + Y[i]);
                    }
                }
                else //周围有雷
                {
                    b[x][y] = (char)(count + '0'); //更新周围雷的数量
                }
            }
        }

        //周围有雷的数量
        public int Count(int x, int y)
        {
            int res = 0;
            for (int i = 0; i < 8; i++)
            {
                if ((x + X[i] >= 0 && y + Y[i] >= 0 && x + X[i] < n && y + Y[i] < m) && b[x + X[i]][y + Y[i]] == 'M')
                {
                    res++;
                }
            }
            return res;
        }

        //作者：huan-shi-ai-chi
        //链接：https://leetcode-cn.com/problems/minesweeper/solution/li-lun-shang-shi-dfsshi-ji-shang-geng-xi-8r87/

    }
    // @lc code=end


}
