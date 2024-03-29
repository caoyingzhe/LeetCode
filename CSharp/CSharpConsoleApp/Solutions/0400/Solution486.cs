﻿using System;
namespace CSharpConsoleApp.Solutions
{
    /*
 * @lc app=leetcode.cn id=486 lang=csharp
 *
 * [486] 预测赢家
 *
 * https://leetcode-cn.com/problems/predict-the-winner/description/
 *
 * Category	Difficulty	Likes	Dislikes
 * algorithms	Medium (58.91%)	455	-
 * Tags
 * dynamic-programming | minimax
 * 
 * Companies
 * google
 * 
 * Total Accepted:    42.4K
 * Total Submissions: 71.9K
 * Testcase Example:  '[1,5,2]'
 *
 * 给定一个表示分数的非负整数数组。 玩家 1 从数组任意一端拿取一个分数，随后玩家 2 继续从剩余数组任意一端拿取分数，然后玩家 1 拿，……
 * 。每次一个玩家只能拿取一个分数，分数被拿取之后不再可取。直到没有剩余分数可取时游戏结束。最终获得分数总和最多的玩家获胜。
 * 
 * 给定一个表示分数的数组，预测玩家1是否会成为赢家。你可以假设每个玩家的玩法都会使他的分数最大化。
 * 
 * 
 * 
 * 示例 1：
 * 输入：[1, 5, 2]
 * 输出：False
 * 解释：一开始，玩家1可以从1和2中进行选择。
 * 如果他选择 2（或者 1 ），那么玩家 2 可以从 1（或者 2 ）和 5 中进行选择。如果玩家 2 选择了 5 ，那么玩家 1 则只剩下 1（或者 2
 * ）可选。
 * 所以，玩家 1 的最终分数为 1 + 2 = 3，而玩家 2 为 5 。
 * 因此，玩家 1 永远不会成为赢家，返回 False 。
 * 
 * 
 * 示例 2：
 * 输入：[1, 5, 233, 7]
 * 输出：Trueå
 * 解释：玩家 1 一开始选择 1 。然后玩家 2 必须从 5 和 7 中进行选择。无论玩家 2 选择了哪个，玩家 1 都可以选择 233 。
 * ⁠    最终，玩家 1（234 分）比玩家 2（12 分）获得更多的分数，所以返回 True，表示玩家 1 可以成为赢家。
 * 
 * 提示：
 * 1 <= 给定的数组长度 <= 20.
 * 数组里所有分数都为非负数且不会大于 10000000 。
 * 如果最终两个玩家的分数相等，那么玩家 1 仍为赢家。
 * 
 * 
 */

    // @lc code=start
    public class Solution486 : SolutionBase
    {
        /// <summary>
        /// 难度
        /// </summary>
        public override Difficulity GetDifficulity() { return Difficulity.Easy; }
        /// <summary>
        /// 关键字:
        /// </summary>
        public override string[] GetKeyWords() { return new string[] { "" }; }
        /// <summary>
        /// 标签：
        /// </summary>
        public override Tag[] GetTags() { return new Tag[] { Tag.DynamicProgramming, }; }

        public override bool Test(System.Diagnostics.Stopwatch sw)
        {
            bool isSuccess = true;
            int[] nums;
            bool result, checkResult;

            nums = new int[] { 1, 5, 2 };
            checkResult = false;
            result = PredictTheWinner(nums);

            isSuccess &= IsSame(result, checkResult);
            PrintResult(isSuccess, (result), (checkResult));

            nums = new int[] { 1, 5, 233, 7 };
            checkResult = true;
            result = PredictTheWinner(nums);

            isSuccess &= IsSame(result, checkResult);
            PrintResult(isSuccess, (result), (checkResult));
            return isSuccess;
        }


        public bool PredictTheWinner_1(int[] nums)
        {
            return Total(nums, 0, nums.Length - 1, 1) >= 0;
        }

        /// <summary>
        /// 递归
        /// 62/62 cases passed (208 ms)
        /// Your runtime beats 5.13 % of csharp submissions
        /// Your memory usage beats 71.79 % of csharp submissions(23.9 MB)
        /// 作者：LeetCode-Solution
        /// 链接：https://leetcode-cn.com/problems/predict-the-winner/solution/yu-ce-ying-jia-by-leetcode-solution/
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <param name="turn"></param>
        /// <returns></returns>
        public int Total(int[] nums, int start, int end, int turn)
        {
            if (start == end)
            {
                return nums[start] * turn;
            }
            int scoreStart = nums[start] * turn + Total(nums, start + 1, end, -turn);
            int scoreEnd = nums[end] * turn + Total(nums, start, end - 1, -turn);
            return Math.Max(scoreStart * turn, scoreEnd * turn) * turn;
        }

        /// <summary>
        /// 动态规划
        /// 62/62 cases passed (104 ms)
        /// Your runtime beats 66.67 % of csharp submissions
        /// Your memory usage beats 61.54 % of csharp submissions(24 MB)
        /// dp[i][j] 表示当数组剩下的部分为下标 i 到下标 j 时，即在下标范围 [i, j] 中，
        /// 当前玩家与另一个玩家的分数之差的最大值，注意当前玩家不一定是先手
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public bool PredictTheWinner(int[] nums)
        {
            int n = nums.Length;
            int[][] dp = new int[n][];
            for (int i = 0; i < n; i++) dp[i] = new int[n];
            for (int i = 0; i < n; i++)
            {
                dp[i][i] = nums[i];
            }
            for (int i = n - 2; i >= 0; i--)
            {
                for (int j = i + 1; j < n; j++)
                {
                    dp[i][j] = Math.Max(nums[i] - dp[i + 1][j], nums[j] - dp[i][j - 1]);
                }
            }
            return dp[0][n - 1] >= 0;
        }
    }
    // @lc code=end
}
