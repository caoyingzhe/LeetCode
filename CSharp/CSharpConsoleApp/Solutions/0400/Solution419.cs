using System;
namespace CSharpConsoleApp.Solutions
{
    /*
     * @lc app=leetcode.cn id=419 lang=csharp
     *
     * [419] 甲板上的战舰
     *
     * https://leetcode-cn.com/problems/battleships-in-a-board/description/
     *
     * Category	Difficulty	Likes	Dislikes
     * algorithms	Medium (75.41%)	105	-
     * Tags
     * Unknown
     * 
     * Companies
     * microsoft
     * 
     * Total Accepted:    10.5K
     * Total Submissions: 13.9K
     * Testcase Example:  '[["X",".",".","X"],[".",".",".","X"],[".",".",".","X"]]'
     *
     * 给定一个二维的甲板， 请计算其中有多少艘战舰。 战舰用 'X'表示，空位用 '.'表示。 你需要遵守以下规则：
     * 
     * 
     * 给你一个有效的甲板，仅由战舰或者空位组成。
     * 战舰只能水平或者垂直放置。换句话说,战舰只能由 1xN (1 行, N 列)组成，或者 Nx1 (N 行, 1 列)组成，其中N可以是任意大小。
     * 两艘战舰之间至少有一个水平或垂直的空位分隔 - 即没有相邻的战舰。
     * 
     * 
     * 示例 :
     * X..X
     * ...X
     * ...X
     * 
     * 在上面的甲板中有2艘战舰。
     * 
     * 无效样例 :
     * ...X
     * XXXX
     * ...X
     * 
     * 你不会收到这样的无效甲板 - 因为战舰之间至少会有一个空位将它们分开。
     * 
     * 进阶:
     * 你可以用一次扫描算法，只使用O(1)额外空间，并且不修改甲板的值来解决这个问题吗？
     */

    // @lc code=start
    public class Solution419 : SolutionBase
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
        public override Tag[] GetTags() { return new Tag[] { Tag.Unknown }; }

        
        public override bool Test(System.Diagnostics.Stopwatch sw)
        {
            bool isSuccess = true;
            char[][] board;
            int result, checkResult;

            board = new char[][]
            {
                new char[] { 'X', '.', '.', 'X' },
                new char[] { '.', '.', '.', 'X' },
                new char[] { '.', '.', '.', 'X' },
            };
            checkResult = 2;
            result = CountBattleships(board);
            isSuccess &= IsSame(result, checkResult);
            PrintResult(isSuccess, (result).ToString(), (checkResult).ToString());


            board = new char[][]
            {
                new char[] { '.', '.', '.', 'X' },
                new char[] { 'X', 'X', 'X', 'X' },
                new char[] { '.', '.', '.', 'X' },
            };
            checkResult = 0;
            result = CountBattleships(board);
            isSuccess &= IsSame(result, checkResult);
            PrintResult(isSuccess, (result).ToString(), (checkResult).ToString());

            return isSuccess;
        }

        //作者：ccman
        //链接：https://leetcode-cn.com/problems/battleships-in-a-board/solution/javaban-ben-bu-gai-bian-shu-zu-zhi-bing-gz0n3/
        /// <summary>
        /// 27/27 cases passed (84 ms)
        /// Your runtime beats 100 % of csharp submissions
        /// Your memory usage beats 56.25 % of csharp submissions(25.8 MB)
        /// </summary>
        /// <param name="board"></param>
        /// <returns></returns>
        public int CountBattleships(char[][] board)
        {
            int x = board.Length;
            int y = board[0].Length;

            int count = 0;

            for (int i = 0; i < x; i++)
            {
                for (int j = 0; j < y; j++)
                {

                    if (board[i][j] == 'X')
                    {
                        // 横着放的情况
                        if (j + 1 < y && board[i][j + 1] == 'X')
                            continue;
                        // 竖着放的情况
                        if (i + 1 < x && board[i + 1][j] == 'X')
                            continue;
                        count++;
                    }
                }
            }
            return count;
        }
    }
    // @lc code=end


}
