using System;
using System.Collections.Generic;
namespace CSharpConsoleApp.Solutions
{
    /*
     * @lc app=leetcode.cn id=368 lang=csharp
     *
     * [368] 最大整除子集
     *
     * https://leetcode-cn.com/problems/largest-divisible-subset/description/
     *
     * Category	Difficulty	Likes	Dislikes
     * algorithms	Medium (45.67%)	347	-
     * Tags
     * math | dynamic-programming
     * 
     * Companies
     * google
     * 
     * Total Accepted:    37.5K
     * Total Submissions: 82.1K
     * Testcase Example:  '[1,2,3]'
     *
     * 给你一个由 无重复 正整数组成的集合 nums ，请你找出并返回其中最大的整除子集 answer ，子集中每一元素对 (answer[i],
     * answer[j]) 都应当满足：
     * 
     * answer[i] % answer[j] == 0 ，或
     * answer[j] % answer[i] == 0
     * 
     * 
     * 如果存在多个有效解子集，返回其中任何一个均可。
     * 
     * 
     * 示例 1：
     * 输入：nums = [1,2,3]
     * 输出：[1,2]
     * 解释：[1,3] 也会被视为正确答案。
     * 
     * 
     * 示例 2：
     * 输入：nums = [1,2,4,8]
     * 输出：[1,2,4,8]
     * 
     * 
     * 提示：
     * 1 <= nums.length <= 1000
     * 1 <= nums[i] <= 2 * 109
     * nums 中的所有整数 互不相同
     * 
     */
    public class Solution368 
    {
        /// <summary>
        /// 48/48 cases passed (300 ms)
        /// Your runtime beats 84.48 % of csharp submissions
        /// Your memory usage beats 66.09 % of csharp submissions(30.5 MB)
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public IList<int> LargestDivisibleSubset(int[] nums)
        {
            //Dp[Max] >= Dp[n-1] * Dp[2]; (Dp[0] = 1;
            //Dp[Max] >= Dp[n-1] * Dp[1]; (Dp[0] != 1;

            //HashSet<int> set = new HashSet<int>();
            //for(int i=0; i<nums.Length; i++)
            //{
            //    if (nums[i] == 1)
            //        isExist1 = true;
            //
            //    max = Math.Max(max, nums[i]);
            //
            //    set.Add(nums[i]);
            //}

            Array.Sort(nums);

            int len = nums.Length;
            int[] dp = new int[len];
            for (int i = 0; i < len; i++) dp[i] = 1;

            int maxSize = 1;
            int maxVal = dp[0];
            for (int i = 1; i < len; i++)
            {
                for (int j = 0; j < i; j++)  //先计算dp的较小值， 关键循环判定
                {
                    // 题目中说「没有重复元素」很重要
                    if (nums[i] % nums[j] == 0)
                    {
                        dp[i] = Math.Max(dp[i], dp[j] + 1);  // 关键处理
                    }
                }

                if (dp[i] > maxSize)
                {
                    maxSize = dp[i];
                    maxVal = nums[i];  //得到最大dp值对应的maxVlue
                }
            }

            List<int> res = new List<int>();
            if(maxSize == 1)
            {
                res.Add(nums[0]);
                return res;
            }

            for(int i=len-1; i>=0 && maxSize > 0; i--)
            {
                if(dp[i] == maxSize && maxVal % nums[i] == 0)
                {
                    res.Add(nums[i]);
                    maxVal = nums[i];
                    maxSize--;
                }
            }
            return res;

        }
    }
}
