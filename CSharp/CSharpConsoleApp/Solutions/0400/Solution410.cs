using System;
namespace CSharpConsoleApp.Solutions
{
    /*
     * @lc app=leetcode.cn id=410 lang=csharp
     *
     * [410] 分割数组的最大值
     *
     * https://leetcode-cn.com/problems/split-array-largest-sum/description/
     *
     * Category	Difficulty	Likes	Dislikes
     * algorithms	Hard (55.29%)	483	-
     * Tags
     * binary-search | dynamic-programming
     * 
     * Companies
     * baidu | facebook
     * 
     * Total Accepted:    32.7K
     * Total Submissions: 59.2K
     * Testcase Example:  '[7,2,5,10,8]\n2'
     *
     * 给定一个非负整数数组 nums 和一个整数 m ，你需要将这个数组分成 m 个非空的连续子数组。
     * 设计一个算法使得这 m 个子数组各自和的最大值最小。
     * 
     * 示例 1：
     * 输入：nums = [7,2,5,10,8], m = 2
     * 输出：18
     * 解释：
     * 一共有四种方法将 nums 分割为 2 个子数组。 其中最好的方式是将其分为 [7,2,5] 和 [10,8] 。
     * 因为此时这两个子数组各自的和的最大值为18，在所有情况中最小。
     * 
     * 示例 2：
     * 输入：nums = [1,2,3,4,5], m = 2
     * 输出：9
     * 
     * 示例 3：
     * 输入：nums = [1,4,4], m = 3
     * 输出：4
     * 
     * 提示：
     * 1 <= nums.length <= 1000
     * 0 <= nums[i] <= 10^6
     * 1 <= m <= min(50, nums.length)
     */
    public class Solution410 : SolutionBase
    {
        /// <summary>
        /// 难度
        /// </summary>
        public override Difficulity GetDifficulity() { return Difficulity.Hard; }
        /// <summary>
        /// 关键字:
        /// </summary>
        public override string[] GetKeyWords() { return new string[] { "连续子数组", "数组和" }; }
        /// <summary>
        /// 标签：
        /// </summary>
        public override Tag[] GetTags() { return new Tag[] { Tag.BinarySearch, Tag.DynamicProgramming, }; }

        public override bool Test(System.Diagnostics.Stopwatch sw)
        {
            return true;
        }
        //作者：LeetCode-Solution
        //链接：https://leetcode-cn.com/problems/split-array-largest-sum/solution/fen-ge-shu-zu-de-zui-da-zhi-by-leetcode-solution/

        /// <summary>
        /// 30/30 cases passed (300 ms)
        /// Your runtime beats 11.11 % of csharp submissions
        /// Your memory usage beats 5.56 % of csharp submissions(24.7 MB)
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="m"></param>
        /// <returns></returns>
        public int SplitArray(int[] nums, int m)
        {
            int n = nums.Length;
            int[][] dp = new int[n + 1][];
            for (int k = 0; k < n + 1; k++) dp[k] = new int[m + 1];

            for (int i = 0; i <= n; i++)
            {
                ArrayFill(dp[i], int.MaxValue);
            }
            int[] sub = new int[n + 1];
            for (int i = 0; i < n; i++)
            {
                sub[i + 1] = sub[i] + nums[i];
            }
            dp[0][0] = 0;
            for (int i = 1; i <= n; i++)
            {
                for (int j = 1; j <= Math.Min(i, m); j++)
                {
                    for (int k = 0; k < i; k++)
                    {
                        dp[i][j] = Math.Min(dp[i][j], Math.Max(dp[k][j - 1], sub[i] - sub[k]));
                    }
                }
            }
            return dp[n][m];
        }
    }
}
