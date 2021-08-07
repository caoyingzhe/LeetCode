using System;
namespace CSharpConsoleApp.Solutions
{
    /*
     * @lc app=leetcode.cn id=79 lang=csharp
     *
     * [79] 单词搜索
     *
     * https://leetcode-cn.com/problems/word-search/description/
     *
     * Category	Difficulty	Likes	Dislikes
     * algorithms	Medium (45.03%)	923	-
     * Tags
     * array | backtracking
     * 
     * Companies
     * bloomberg | facebook | microsoft
     * 
     * Total Accepted:    178.7K
     * Total Submissions: 396.7K
     * Testcase Example:  '[["A","B","C","E"],["S","F","C","S"],["A","D","E","E"]]\n"ABCCED"'
     *
     * 给定一个 m x n 二维字符网格 board 和一个字符串单词 word 。如果 word 存在于网格中，返回 true ；否则，返回 false
     * 。
     * 
     * 单词必须按照字母顺序，通过相邻的单元格内的字母构成，其中“相邻”单元格是那些水平相邻或垂直相邻的单元格。同一个单元格内的字母不允许被重复使用。
     * 
     * 示例 1：
     * 输入：board = [["A","B","C","E"],["S","F","C","S"],["A","D","E","E"]], word =
     * "ABCCED"
     * 输出：true
     * 
     * 
     * 示例 2：
     * 输入：board = [["A","B","C","E"],["S","F","C","S"],["A","D","E","E"]], word =
     * "SEE"
     * 输出：true
     * 
     * 
     * 示例 3：
     * 输入：board = [["A","B","C","E"],["S","F","C","S"],["A","D","E","E"]], word =
     * "ABCB"
     * 输出：false
     * 
     * 
     * 提示：
     * m == board.length
     * n = board[i].length
     * 1 <= m, n <= 6
     * 1 <= word.length <= 15
     * board 和 word 仅由大小写英文字母组成
     * 
     * 进阶：你可以使用搜索剪枝的技术来优化解决方案，使其在 board 更大的情况下可以更快解决问题？
     */
    public class Solution79 : SolutionBase
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
        public override Tag[] GetTags() { return new Tag[] { Tag.Array, Tag.Backtracking }; }

        public override bool Test(System.Diagnostics.Stopwatch sw)
        {
            bool isSuccess = true;
            char[][] board; string word;
            bool result, checkResult;

            board = new char[][]
            {
                new char[] { 'A', 'B','C','F' },
                new char[] { 'A', 'C','D','E'},
                new char[] { 'A', 'C','E','E' },
            };
            word = "ABCCED";
            checkResult = true;
            result = Exist(board, word);
            isSuccess &= result == checkResult;
            Print("isSuccess = {0} | result = {1} | anticipated = {2}", isSuccess, (result), (checkResult));

            board = new char[][]
            {
                new char[] { 'A', 'B','C','F' },
                new char[] { 'A', 'C','D','E'},
                new char[] { 'A', 'C','E','E' },
            };
            word = "ABCCEEED";
            checkResult = true;
            result = Exist(board, word);
            isSuccess &= result == checkResult;
            Print("isSuccess = {0} | result = {1} | anticipated = {2}", isSuccess, (result), (checkResult));

            board = new char[][]
            {
                new char[] { 'A', 'B','C','F' },
                new char[] { 'A', 'C','D','E'},
                new char[] { 'A', 'C','E','E' },
            };
            word = "ABCCEED";
            checkResult = false;
            result = Exist(board, word);
            isSuccess &= result == checkResult;
            Print("isSuccess = {0} | result = {1} | anticipated = {2}", isSuccess, (result), (checkResult));


            return isSuccess;
        }

        /// <summary>
        /// 50/50 cases passed (304 ms)
        /// Your runtime beats 26.36 % of csharp submissions
        /// Your memory usage beats 69.77 % of csharp submissions(24.4 MB)
        /// </summary>
        /// <param name="board"></param>
        /// <param name="word"></param>
        /// <returns></returns>
        public bool Exist(char[][] board, string word)
        {
            int m = board.Length;
            int n = board[0].Length;
            bool[,] visited = new bool[m, n];

            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    bool flag = DFS(board, word, visited, i, j, 0);
                    if (flag)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        int[][] directions = {
            new int[] { 0, 1 },
            new int[] { 0, -1 },
            new int[] { 1, 0 },
            new int[] { -1, 0 } };

        public bool DFS(char[][] board, string word, bool[,] visited, int i, int j, int matchIndex)
        {
            if (board[i][j] != word[matchIndex])
            {
                return false;
            }
            else if (matchIndex == word.Length - 1)
            {
                return true;
            }
            visited[i, j] = true;

            foreach (int[] dir in directions)
            {
                int newi = i + dir[0], newj = j + dir[1];
                if (newi >= 0 && newi < board.Length && newj >= 0 && newj < board[0].Length)
                {
                    if (!visited[newi, newj]) //未搜索过
                    {
                        bool flag = DFS(board, word, visited, newi, newj, matchIndex + 1);
                        if (flag)
                        {
                            return true;
                        }
                    }
                }
            }
            visited[i, j] = false;
            return false;
        }
    }
}
