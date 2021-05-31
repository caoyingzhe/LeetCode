using System;
using System.Collections.Generic;
namespace CSharpConsoleApp.Solutions
{
    /*
     * @lc app=leetcode.cn id=446 lang=csharp
     *
     * [446] 等差数列划分 II - 子序列
     *
     * https://leetcode-cn.com/problems/arithmetic-slices-ii-subsequence/description/
     *
     * Category	Difficulty	Likes	Dislikes
     * algorithms	Hard (37.05%)	115	-
     * Tags
     * dynamic-programming
     * 
     * Companies
     * baidu
     * 
     * Total Accepted:    3.6K
     * Total Submissions: 9.7K
     * Testcase Example:  '[2,4,6,8,10]'
     *
     * 如果一个数列至少有三个元素，并且任意两个相邻元素之差相同，则称该数列为等差数列。
     * 
     * 例如，以下数列为等差数列:
     * 
     * 
     * 1, 3, 5, 7, 9
     * 7, 7, 7, 7
     * 3, -1, -5, -9
     * 
     * 以下数列不是等差数列。
     * 1, 1, 2, 5, 7
     * 数组 A 包含 N 个数，且索引从 0 开始。该数组子序列将划分为整数序列 (P0, P1, ..., Pk)，满足 0 ≤ P0 < P1 < ...
     * < Pk < N。
     * 
     * 如果序列 A[P0]，A[P1]，...，A[Pk-1]，A[Pk] 是等差的，那么数组 A 的子序列 (P0，P1，…，PK)
     * 称为等差序列。值得注意的是，这意味着 k ≥ 2。
     * 
     * 函数要返回数组 A 中所有等差子序列的个数。
     * 输入包含 N 个整数。每个整数都在 -2^31 和 2^31-1 之间，另外 0 ≤ N ≤ 1000。保证输出小于 2^31-1。
     * 
     * 示例：
     * 输入：[2, 4, 6, 8, 10]
     * 输出：7
     * 
     * 解释：
     * 所有的等差子序列为：
     * [2,4,6]
     * [4,6,8]
     * [6,8,10]
     * [2,4,6,8]
     * [4,6,8,10]
     * [2,4,6,8,10]
     * [2,6,10]
     */
    public class Solution446 : SolutionBase
    {
        /// <summary>
        /// 难度
        /// </summary>
        public override Difficulity GetDifficulity() { return Difficulity.Hard; }
        /// <summary>
        /// 关键字:
        /// </summary>
        public override string[] GetKeyWords() { return new string[] { "算法没搞懂", "需反复看", "存在线形时间复杂度解法", "等差数列" }; }
        /// <summary>
        /// 标签：
        /// </summary>
        public override Tag[] GetTags() { return new Tag[] { Tag.Math, Tag.DynamicProgramming, }; }

        public override bool Test(System.Diagnostics.Stopwatch sw)
        {
            bool isSuccess = true;
            int[] nums;
            int result, checkResult;

            nums = new int[] { 1, 2, 3, 4, 5 };
            checkResult = 7;
            result = NumberOfArithmeticSlices(nums);
            isSuccess &= checkResult == result;
            Print("isSuccess = {0} | result = {1} | anticipated = {2}", isSuccess, (result), (checkResult));

            nums = new int[] { 1, 2, 3 };
            checkResult = 1;
            result = NumberOfArithmeticSlices(nums);
            isSuccess &= checkResult == result;
            Print("isSuccess = {0} | result = {1} | anticipated = {2}", isSuccess, (result), (checkResult));

            return isSuccess;
        }

        /// <summary>
        /// 作者：LeetCode
        /// 链接：https://leetcode-cn.com/problems/arithmetic-slices-ii-subsequence/solution/deng-chai-shu-lie-hua-fen-ii-zi-xu-lie-by-leetcode/
        /// 101/101 cases passed (396 ms)
        /// Your runtime beats 33.33 % of csharp submissions
        /// Your memory usage beats 33.33 % of csharp submissions(64.9 MB)
        /// </summary>
        /// <param name="A"></param>
        /// <returns></returns>
        public int NumberOfArithmeticSlices(int[] A)
        {
            int n = A.Length;
            long ans = 0;
            Dictionary<int, int>[] cnt = new Dictionary<int, int>[n];
            for (int i = 0; i < n; i++)
            {
                cnt[i] = new Dictionary<int, int>(i);
                for (int j = 0; j < i; j++)
                {
                    long delta = (long)A[i] - (long)A[j];
                    if (delta < int.MinValue || delta > int.MaxValue)
                    {
                        continue;
                    }
                    int diff = (int)delta;
                    int sum = GetOrDefault(cnt[j], diff, 0);
                    int origin = GetOrDefault(cnt[i], diff, 0);
                    cnt[i][diff] = origin + sum + 1;
                    ans += sum;
                }
            }
            return (int)ans;
        }
    }
}
