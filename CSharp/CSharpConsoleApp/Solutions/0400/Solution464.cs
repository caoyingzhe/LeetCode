using System;
namespace CSharpConsoleApp.Solutions
{
    /*
     * @lc app=leetcode.cn id=464 lang=csharp
     *
     * [464] 我能赢吗
     *
     * https://leetcode-cn.com/problems/can-i-win/description/
     *
     * Category	Difficulty	Likes	Dislikes
     * algorithms	Medium (35.33%)	238	-
     * Tags
     * dynamic-programming | minimax
     * 
     * Companies
     * linkedin
     * 
     * Total Accepted:    9.8K
     * Total Submissions: 27.8K
     * Testcase Example:  '10\n11'
     *
     * 在 "100 game" 这个游戏中，两名玩家轮流选择从 1 到 10 的任意整数，累计整数和，先使得累计整数和达到或超过 100 的玩家，即为胜者。
     * 
     * 如果我们将游戏规则改为 “玩家不能重复使用整数” 呢？
     * 
     * 例如，两个玩家可以轮流从公共整数池中抽取从 1 到 15 的整数（不放回），直到累计整数和 >= 100。
     * 
     * 给定一个整数 maxChoosableInteger （整数池中可选择的最大数）和另一个整数
     * desiredTotal（累计和），判断先出手的玩家是否能稳赢（假设两位玩家游戏时都表现最佳）？
     * 
     * 你可以假设 maxChoosableInteger 不会大于 20， desiredTotal 不会大于 300。
     * 
     * 示例：
     * 
     * 输入：
     * maxChoosableInteger = 10
     * desiredTotal = 11
     * 
     * 输出：
     * false
     * 
     * 解释：
     * 无论第一个玩家选择哪个整数，他都会失败。
     * 第一个玩家可以选择从 1 到 10 的整数。
     * 如果第一个玩家选择 1，那么第二个玩家只能选择从 2 到 10 的整数。
     * 第二个玩家可以通过选择整数 10（那么累积和为 11 >= desiredTotal），从而取得胜利.
     * 同样地，第一个玩家选择任意其他整数，第二个玩家都会赢。
     */

    // @lc code=start
    public class Solution464 : SolutionBase
    {
        /// <summary>
        /// 难度
        /// </summary>
        public override Difficulity GetDifficulity() { return Difficulity.Medium; }
        /// <summary>
        /// 关键字:
        /// </summary>
        public override string[] GetKeyWords() { return new string[] { "状态压缩动态规划入门题" }; }
        /// <summary>
        /// 标签：
        /// </summary>
        public override Tag[] GetTags() { return new Tag[] { Tag.DynamicProgramming, Tag.Minimax }; }

        public override bool Test(System.Diagnostics.Stopwatch sw)
        {
            bool isSuccess = true;
            //TODO
            return isSuccess;
        }


        //作者：wzliang
        //链接：https://leetcode-cn.com/problems/can-i-win/solution/0ms100tou-ji-qu-qiao-zhi-zhao-gui-lu-da-biao-by-ri/
        public bool CanIWin_Fast(int maxChoosableInteger, int desiredTotal)
        {
            //sn为等差数列求和
            int sn = maxChoosableInteger + maxChoosableInteger * (maxChoosableInteger - 1) / 2;
            //如果目标大于sn那不可能赢
            if (desiredTotal > sn) return false;
            //打表数据如下
            if (maxChoosableInteger == 10 && (desiredTotal == 40 || desiredTotal == 54)) return false;
            if (maxChoosableInteger == 20 && (desiredTotal == 210 || desiredTotal == 209)) return false;
            if (maxChoosableInteger == 18 && (desiredTotal == 171 || desiredTotal == 172)) return false;
            if (maxChoosableInteger == 12 && desiredTotal == 49) return true;

            //规律如下：desiredTotal == 1必胜，如果累计值模上最大值余1那必输，否则必胜。（但不一定成立，反例如上打表数据）
            return desiredTotal == 1 || desiredTotal % maxChoosableInteger != 1;
        }

        //作者：nullptr1
        //链接：https://leetcode-cn.com/problems/can-i-win/solution/zhuang-tai-ya-suo-dong-tai-gui-hua-ru-men-ti-by-re/
        /// <summary>
        /// 57/57 cases passed (128 ms)
        /// Your runtime beats 100 % of csharp submissions
        /// Your memory usage beats 75 % of csharp submissions(23.6 MB)
        /// </summary>
        private bool[] dp;
        private bool[] visited;
        public bool CanIWin(int maxChoosableInteger, int desiredTotal)
        {
            if (desiredTotal > (maxChoosableInteger + 1) * maxChoosableInteger / 2)
            {
                return false;
            }
            dp = new bool[1 << maxChoosableInteger];
            visited = new bool[dp.Length];
            return CanIWinHelper(maxChoosableInteger, desiredTotal, (1 << maxChoosableInteger) - 1);
        }
        private bool CanIWinHelper(int maxChoosableInteger, int scoreLeft, int state)
        {
            if (visited[state] != false)
            {
                return dp[state];
            }
            for (int i = maxChoosableInteger; i > 0; --i)
            {
                if ((state & (1 << (i - 1))) != 0)
                {
                    if (scoreLeft <= i || !CanIWinHelper(maxChoosableInteger, scoreLeft - i, state ^ (1 << (i - 1))))
                    {
                        visited[state] = true;
                        return dp[state] = true;
                    }
                }
            }
            dp[state] = false;
            visited[state] = true;
            return dp[state];
        }
    }
    // @lc code=end


}
