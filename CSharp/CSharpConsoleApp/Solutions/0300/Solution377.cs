using System;
namespace CSharpConsoleApp.Solutions
{
    /*
     * @lc app=leetcode.cn id=377 lang=csharp
     *
     * [377] 组合总和 Ⅳ
     *
     * https://leetcode-cn.com/problems/combination-sum-iv/description/
     *
     * Category	Difficulty	Likes	Dislikes
     * algorithms	Medium (50.04%)	430	-
     * Tags
     * dynamic-programming
     * 
     * Companies
     * facebook | google | snapchat
     * 
     * Total Accepted:    50.1K
     * Total Submissions: 100.2K
     * Testcase Example:  '[1,2,3]\n4'
     *
     * 给你一个由 不同 整数组成的数组 nums ，和一个目标整数 target 。请你从 nums 中找出并返回总和为 target 的元素组合的个数。
     * 
     * 题目数据保证答案符合 32 位整数范围。
     * 
     * 
     * 示例 1：
     * 输入：nums = [1,2,3], target = 4
     * 输出：7
     * 解释：
     * 所有可能的组合为：
     * (1, 1, 1, 1)
     * (1, 1, 2)
     * (1, 2, 1)
     * (1, 3)
     * (2, 1, 1)
     * (2, 2)
     * (3, 1)
     * 请注意，顺序不同的序列被视作不同的组合。
     * 
     * 
     * 示例 2：
     * 输入：nums = [9], target = 3
     * 输出：0
     * 
     * 
     * 提示：
     * 1 <= nums.length <= 200
     * 1 <= nums[i] <= 1000
     * nums 中的所有元素 互不相同
     * 1 <= target <= 1000
     * 
     * 进阶：如果给定的数组中含有负数会发生什么？问题会产生何种变化？如果允许负数出现，需要向题目中添加哪些限制条件？
     * 
     */
    public class Solution377 : SolutionBase
    {
        /// <summary>
        /// 难度
        /// </summary>
        public override Difficulity GetDifficulity() { return Difficulity.Medium; }
        /// <summary>
        /// 关键字:
        /// </summary>
        public override string[] GetKeyWords() { return new string[] { "" }; }
        /// <summary>
        /// 标签： 
        /// </summary>
        public override Tag[] GetTags() { return new Tag[] { Tag.DynamicProgramming }; }

        public override bool Test(System.Diagnostics.Stopwatch sw)
        {
            bool isSuccess = true;
            int[] num = new int[] { 1, 2, 3};
            int target = 4;

            int result;

            result = CombinationSum4(num, target);
            Print("result = {0}", target);
            isSuccess &= result == 7;
            return isSuccess;
        }

        /// <summary>
        /// https://leetcode-cn.com/problems/combination-sum-iv/solution/zu-he-zong-he-iv-by-leetcode-solution-q8zv/
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public int CombinationSum4(int[] nums, int target)
        {
            int[] dp = new int[target + 1];
            dp[0] = 1;
            for (int i = 1; i <= target; i++)
            {
                foreach (int num in nums)
                {
                    if (num <= i)
                    {
                        dp[i] += dp[i - num];  // 关键的动态方程
                    }
                } 
            }
            return dp[target];
        }
    }
}
