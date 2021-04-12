#define LeetCode

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpConsoleApp.Solutions
{
    /// <summary>
    /// [37] 解数独
    /// 给定的数独序列只包含数字 1-9 和字符 '.' 。
    /// 你可以假设给定的数独只有唯一解。
    /// 给定数独永远是 9x9 形式的。
    /// </summary>
    class Solution37 : SolutionBase
    {
        /// <summary>
        /// 难度
        /// </summary>
        public override Difficulity GetDifficulity() { return Difficulity.Hard; }
        /// <summary>
        /// 关键字:
        ///     DFS => 广度优先搜索（算法导论 第六部分 图算法 22.1章节）
        ///     五大常用算法之四：回溯法（试错思想法）
        /// </summary>
        public override string[] GetKeyWords() { return new string[] { "DFS", "Back_Tracing" }; }
        /// <summary>
        /// 标签： 
        /// </summary>
        public override Tag[] GetTags() { return new Tag[] { Tag.BreadthFirstSearch, Tag.Backtracking }; }

        public override bool Test(System.Diagnostics.Stopwatch sw)
        {
            bool isSuccess = true;
            char[][] board2 = new char[][] {
                new char[] {'.','.','9','7','4','8','.','.','.'},
                new char[] {'7','.','.','.','.','.','.','.','.'},
                new char[] {'.','2','.','1','.','9','.','.','.'},
                new char[] {'.','.','7','.','.','.','2','4','.'},
                new char[] {'.','6','4','.','1','.','5','9','.'},
                new char[] {'.','9','8','.','.','.','3','.','.'},
                new char[] {'.','.','.','8','.','3','.','2','.'},
                new char[] {'.','.','.','.','.','.','.','.','6'},
                new char[] {'.','.','.','2','7','5','9','.','.'}};

            char[][] checkResult2 = new char[][]
            {
                new char[]{'5', '1', '9', '7', '4', '8', '6', '3', '2'},
                new char[]{'7', '8', '3', '6', '5', '2', '4', '1', '9'},
                new char[]{'4', '2', '6', '1', '3', '9', '8', '7', '5'},
                new char[]{'3', '5', '7', '9', '8', '6', '2', '4', '1'},
                new char[]{'2', '6', '4', '3', '1', '7', '5', '9', '8'},
                new char[]{'1', '9', '8', '5', '2', '4', '3', '6', '7'},
                new char[]{'9', '7', '5', '8', '6', '3', '1', '2', '4'},
                new char[]{'8', '3', '2', '4', '9', '1', '7', '5', '6'},
                new char[]{'6', '4', '1', '2', '7', '5', '9', '8', '3'}
            };

            char[][] board1 = new char[][] {
                new char[] {'5','3','.','.','7','.','.','.','.'},
                new char[] {'6','.','.','1','9','5','.','.','.'},
                new char[] {'.','9','8','.','.','.','.','6','.'},
                new char[] {'8','.','.','.','6','.','.','.','3'},
                new char[] {'4','.','.','8','.','3','.','.','1'},
                new char[] {'7','.','.','.','2','.','.','.','6'},
                new char[] {'.','6','.','.','.','.','2','8','.'},
                new char[] {'.','.','.','4','1','9','.','.','5'},
                new char[] {'.','.','.','.','8','.','.','7','9'}};
            /*
            532678914
            672195348
            198542762
            851762493
            429853621
            753324816
            965931287
            287419635
            315284679 
             */
            SolveSudoku(board2);
            //SolveSudoku_MyNotComplete(board2);
            isSuccess &= IsArraySame(board2, checkResult2);
            System.Diagnostics.Debug.Print("---- isSuccess :{0} callCount :{1}\n {2}\n--------------------\n{3}", isSuccess, callCount, GetArrayStr(board2, " "),GetArrayStr(checkResult2, " "));
            return isSuccess;
        }


#if LeetCode
        #region  LeetCode Commit
    public static int callCount = 0;
    bool Fill(int i, int j, char[][] board)
    {
        callCount++;

        if (j == 9)
        {
            i++;
            j = 0;
            if (i == 9)
            {
                return true;
            }
        }

        if (board[i][j] != '.')
        {
            return Fill(i, j + 1, board);
        }

        for (int num = 1; num <= 9; num++)
        {
            char c = num.ToString()[0];
            if (HasConflict(i, j, c, board))
                continue;

            board[i][j] = c;
            if (Fill(i, j + 1, board))
            {
                return true;
            }
            else
            {
                board[i][j] = '.';
            }
        }
        return false;
    }
    bool HasConflict(int row, int col, char fillChar, char[][] board)
    {
        for (int i = 0; i < 9; i++)
        {
            if (board[row][i] == fillChar || board[i][col] == fillChar)
            {
                return true;
            }
        }

        int bi = (row / 3) * 3;
        int bj = (col / 3) * 3;
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                if (board[bi + i][bj + j] == fillChar)
                {
                    return true;
                }
            }
        }
        return false;
    }public void SolveSudoku(char[][] board)
    {
            Fill(0, 0, board);
    }
    int RemoveImpossibleChar(int i, int j, char removeChar, Dictionary<int, List<char>> dict, char[][] board)
    {
        int index = i * 9 + j;
        if (dict.ContainsKey(index))
        {
            dict[index].Remove(removeChar);
            if (dict[index].Count == 1)
            {
                board[i][j] = dict[index][0];
                dict.Remove(index);
            }
            return 1;
        }
        return 0;
    }
    
        #endregion
#elif FirstChanllenged
        #region First Chanllenged
        /// <summary>
        /// def backtrack(path, selected):
        /// 
        /// if 满足停止条件：
        ///     res.append(path)
        /// for 选择 in 选择列表：
        ///     做出选择
        ///     递归执行backtrack
        ///     撤销选择
        /// </summary>
        /// <param name="board"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        private bool backtrace(char[][] board, int count)
        {
            return false;
        }

        public static int callCount = 0;
        public void SolveSudoku(char[][] board)
        {
            fill(0, 0, board); // 从第一个格子开始填
        }

        public void SolveSudoku_MyNotComplete(char[][] board)
        {
            Dictionary<int, List<char>> dict = new Dictionary<int, List<char>>();
            for (int indexInit = 0; indexInit < 81; indexInit++)
            {
                int i = indexInit / 9;
                int j = indexInit % 9;

                if (board[i][j] == '.')
                    dict.Add(indexInit, (new List<char>(new char[] { '1', '2', '3', '4', '5', '6', '7', '8', '9' })));
            }

            int loop = 0;
            while (loop < 1000)
            {
                loop--;

                int removeCharCount = 0;
                if (dict.Keys.Count == 0)
                {

                    break;
                }
                //scan line
                for (int i = 0; i < 9; i++)
                {
                    for (int j = 0; j < 9; j++)
                    {
                        char c = board[i][j];
                        if (c != '.')
                        {
                            for (int jj = 0; jj < 9; jj++)
                            {
                                int index = i * 9 + jj;
                                if (RemoveImpossibleChar(i, jj, c, dict, board))
                                    removeCharCount++;
                            }
                        }
                    }
                }
                //Print("---- scan line result Loop = " + loop + "----\n" + GetArrayStr(board));
                //Scan Column
                for (int j = 0; j < 9; j++)
                {
                    for (int i = 0; i < 9; i++)
                    {
                        char c = board[i][j];
                        if (c != '.')
                        {
                            for (int ii = 0; ii < 9; ii++)
                            {
                                if (RemoveImpossibleChar(ii, j, c, dict, board))
                                    removeCharCount++;
                            }
                        }
                    }
                }
                //Print("---- Scan Column Result Loop = " + loop + "----\n" + GetArrayStr(board));
                //scan 3x3
                for (int g = 0; g < 9; g++)
                {
                    int gi = g / 3;
                    int gj = g % 3;
                    for (int no = 0; no < 9; no++)
                    {
                        int i = gi * 3 + no / 3;
                        int j = gj * 3 + no % 3;
                        int index = i * 9 + j;

                        char c = board[i][j];
                        if (c != '.')
                        {
                            string log = "";
                            Print("--------block[" + g + "] check[" + i + "][" + j + "]=" + c + "----------");
                            for (int m = 0; m < 9; m++)
                            {
                                int mi = gi * 3 + m / 3;
                                int mj = gj * 3 + m % 3;
                                log += string.Format("[{0}][{1}]={2}; ", mi, mj, board[mi][mj]);
                                if (m % 3 == 2)
                                {
                                    Print(log);
                                    log = "";
                                }
                            }

                            for (int m = 0; m < 9; m++)
                            {
                                int mi = gi * 3 + m / 3;
                                int mj = gj * 3 + m % 3;

                                if (RemoveImpossibleChar(mi, mj, c, dict, board))
                                    removeCharCount++;
                            }
                        }
                    }
                }
                System.Diagnostics.Debug.Print("---- scan 3x3 Result Loop = " + loop + "----\n" + GetArrayStr(board));

                //已经不能推测出结果了，此时必须使用回溯法试错
                if (removeCharCount == 0)
                {
                    break;

                }
            }

            string log2 = "";
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    int index = i * 9 + j;
                    char c = board[i][j];
                    if (c == '.')
                    {
                        log2 += string.Join("|", dict[index].ToArray());
                    }
                    else
                        log2 += c;
                    log2 += "\t";
                }
                log2 += "\n";
            }
            System.Diagnostics.Debug.Print("---- Result ----\n" + log2);

            fill(0, 0, board);
        }

        bool RemoveImpossibleChar(int i, int j, char removeChar, Dictionary<int, List<char>> dict, char[][] board)
        {
            int index = i * 9 + j;
            if (dict.ContainsKey(index))
            {
                if (dict[index].Contains(removeChar))
                {
                    dict[index].Remove(removeChar);

                    if (i == 0 && j == 3)
                    {
                        Print("[{0}][{1}] remove> {2}=> [{3}]\n", i, j, removeChar, string.Join(",", dict[index].ToArray()));
                    }

                    if (dict[index].Count == 1)
                    {
                        Print("[{0}][{1}] {2}=>{3}\n", i, j, board[i][j], dict[index][0]);
                        board[i][j] = dict[index][0];
                        dict.Remove(index);
                    }
                    return true;
                }
            }
            return false;
        }

        bool fill(int i, int j, char[][] board)
        {
            callCount++;

            if (j == 9)
            { // 列越界，说明填完了一行，填下一行的第一格
                i++;
                j = 0;
                if (i == 9) return true; // 都填完了，返回true
            }
            if (board[i][j] != '.') return fill(i, j + 1, board); // 不是空白格，递归填下一格

            for (int num = 1; num <= 9; num++)
            {           // 枚举出当前格的所有可填的选择
                if (hasConflit(i, j, num.ToString()[0], board)) continue; // 如果存在冲突，跳过这个选择
                board[i][j] = num.ToString()[0];                 // 作出一个选择
                if (fill(i, j + 1, board)) return true; // 如果基于它，填下一格，最后可以解出数独，直接返回true
                board[i][j] = '.';               // 如果基于它，填下一格，填1-9都不行，回溯，恢复为空白格
            }
            return false; // 尝试了1-9，每个都往下递归，都不能做完，返回false
        }

        // 判断是否有行列和框框的冲突
        bool hasConflit(int row, int col, char fillChar, char[][] board)
        {
            //测试行列冲突
            for (int i = 0; i < 9; i++)
            {
                if (board[i][col] == fillChar || board[row][i] == fillChar)
                {
                    return true;
                }
            }

            //测试3x3块冲突
            int subRowStart = (row / 3) * 3;
            int subColStart = (col / 3) * 3;

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (board[subRowStart + i][subColStart + j] == fillChar)
                    {
                        return true;
                    }
                }
            }
            return false;
        }
        #endregion
#endif
    }

}