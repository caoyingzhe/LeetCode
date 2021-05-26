using System;
using System.Collections.Generic;
namespace CSharpConsoleApp.Solutions
{
    /*
     * @lc app=leetcode.cn id=689 lang=csharp
     *
     * [689] 三个无重叠子数组的最大和
     *
     * https://leetcode-cn.com/problems/maximum-sum-of-3-non-overlapping-subarrays/description/
     *
     * Category	Difficulty	Likes	Dislikes
     * algorithms	Hard (47.89%)	116	-
     * Tags
     * array | dynamic-programming
     * 
     * Companies
     * facebook | google
     * 
     * Total Accepted:    2.7K
     * Total Submissions: 5.6K
     * Testcase Example:  '[1,2,1,2,6,7,5,1]\n2'
     *
     * 给定数组 nums 由正整数组成，找到三个互不重叠的子数组的最大和。
     * 
     * 每个子数组的长度为k，我们要使这3*k个项的和最大化。
     * 
     * 返回每个区间起始索引的列表（索引从 0 开始）。如果有多个结果，返回字典序最小的一个。
     * 
     * 示例:
     * 输入: [1,2,1,2,6,7,5,1], 2
     * 输出: [0, 3, 5]
     * 解释: 子数组 [1, 2], [2, 6], [7, 5] 对应的起始索引为 [0, 3, 5]。
     * 我们也可以取 [2, 1], 但是结果 [1, 3, 5] 在字典序上更大。
     * 
     * 注意:
     * nums.length的范围在[1, 20000]之间。
     * nums[i]的范围在[1, 65535]之间。
     * k的范围在[1, floor(nums.length / 3)]之间。
     */
    public class Solution689
    {
        /// <summary>
        /// 43/43 cases passed (320 ms)
        /// Your runtime beats 100 % of csharp submissions
        /// Your memory usage beats 100 % of csharp submissions(38.6 MB)
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public int[] MaxSumOfThreeSubarrays(int[] nums, int k)
        {
            List<int> sum = new List<int>() ;
            int cur = 0;
            for (int i = 0; i < k; ++i)
            {
                cur += nums[i];
            }
            sum.Add(cur);
            for (int i = k; i < nums.Length; ++i)
            {
                cur += nums[i] - nums[i - k];
                sum.Add(cur);
            }
            int n = sum.Count;
            int[] left = new int[n];
            int[] right = new int[n];
            for (int i = 0; i < n; i++) right[i] = n - 1;

            for (int i = 1; i < n; ++i)
            {
                if (sum[i] > sum[left[i - 1]]) left[i] = i;
                else left[i] = left[i - 1];
            }
            for (int i = n - 2; i >= 0; --i)
            {
                if (sum[i] >= sum[right[i + 1]]) right[i] = i;
                else right[i] = right[i + 1];
            }
            int mx = 0;
            int[] ans = new int[3];
            for (int i = k; i < n - k; ++i)
            {
                if (mx < sum[i] + sum[left[i - k]] + sum[right[i + k]])
                {
                    mx = sum[i] + sum[left[i - k]] + sum[right[i + k]];
                    ans = new int[] { left[i - k], i, right[i + k]};
                }
            }
            return ans;

            //作者：Monologue - S
            //链接：https://leetcode-cn.com/problems/maximum-sum-of-3-non-overlapping-subarrays/solution/condong-tai-gui-hua-by-monologue-s-dnyc/

        }
    }
}
