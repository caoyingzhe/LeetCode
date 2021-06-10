using System;
namespace CSharpConsoleApp.Solutions
{
    /*
     * @lc app=leetcode.cn id=1862 lang=csharp
     *
     * [1862] 向下取整数对和
     *
     * https://leetcode-cn.com/problems/sum-of-floored-pairs/description/
     *
     * Category	Difficulty	Likes	Dislikes
     * algorithms	Hard (30.32%)	16	-
     * Tags
     * Unknown
     * 
     * Companies
     * Unknown
     * Total Accepted:    1.9K
     * Total Submissions: 6.2K
     * Testcase Example:  '[2,5,9]'
     *
     * 给你一个整数数组 nums ，请你返回所有下标对 0 <= i, j < nums.length 的 floor(nums[i] / nums[j])
     * 结果之和。由于答案可能会很大，请你返回答案对10^9 + 7 取余 的结果。
     * 函数 floor() 返回输入数字的整数部分。
     * 
     * 
     * 示例 1：
     * 输入：nums = [2,5,9]
     * 输出：10
     * 解释：
     * floor(2 / 5) = floor(2 / 9) = floor(5 / 9) = 0
     * floor(2 / 2) = floor(5 / 5) = floor(9 / 9) = 1
     * floor(5 / 2) = 2
     * floor(9 / 2) = 4
     * floor(9 / 5) = 1
     * 我们计算每一个数对商向下取整的结果并求和得到 10 。
     * 
     * 
     * 示例 2：
     * 输入：nums = [7,7,7,7,7,7,7]
     * 输出：49
     *
     * 
     * 提示：
     * 1 <= nums.length <= 10^5
     * 1 <= nums[i] <= 10^5
     */
    public class Solution1862 : SolutionBase
    {
        /// <summary>
        /// 难度
        /// </summary>
        public override Difficulity GetDifficulity() { return Difficulity.Hard; }
        /// <summary>
        /// 关键字:
        /// </summary>
        public override string[] GetKeyWords() { return new string[] { "前缀和" }; }
        /// <summary>
        /// 标签：
        /// </summary>
        public override Tag[] GetTags() { return new Tag[] { Tag.DynamicProgramming, }; }

        public override bool Test(System.Diagnostics.Stopwatch sw)
        {
            bool isSuccess = true;
            return isSuccess;
        }

        //作者：feng - sheng - he - li
        //链接：https://leetcode-cn.com/problems/sum-of-floored-pairs/solution/di-5212ti-ti-jie-qian-zhui-he-suan-fa-by-rrzz/

        /// <summary>
        /// 前缀和
        /// 51/51 cases passed (1896 ms)
        /// Your runtime beats 33.33 % of csharp submissions
        /// Your memory usage beats 33.33 % of csharp submissions(45.5 MB)
        /// </summary>
        const int N = 100010;
        const long MOD = (long) 1e9 + 7;
        public int SumOfFlooredPairs(int[] nums)
        {
            long [] s = new long[N];//求前缀和
            foreach (int x in nums)
                s[x]++;//存元素个数
            for (int i = 1; i < N; i++)
                s[i] += s[i - 1];//求前缀和

            long res = 0;//最后的结果
            for (int i = 1; i < N; i++)
            {
                for (int j = 1; j * i < N; j++)// j是倍数
                {
                    int l = j * i, r = Math.Min(N - 1, (j + 1) * i - 1); // 每个区间[l,r]
                    long sum = (long)(s[r] - s[l - 1]) * j % MOD; //每一段区间的函数值，如[9,17]是1,[18,26]是2
                    res = (res + (s[i] - s[i - 1]) * sum) % MOD;//看看这个区间内有多少个元素，进行区间累加求和
                }
            }
            return (int) res;
        }
    }
}
