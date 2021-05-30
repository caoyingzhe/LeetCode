using System;
namespace CSharpConsoleApp.Solutions
{
    /*
     * @lc app=leetcode.cn id=643 lang=csharp
     *
     * [643] 子数组最大平均数 I
     *
     * https://leetcode-cn.com/problems/maximum-average-subarray-i/description/
     *
     * algorithms
     * Easy (45.42%)
     * Likes:    185
     * Dislikes: 0
     * Total Accepted:    56.6K
     * Total Submissions: 124.7K
     * Testcase Example:  '[1,12,-5,-6,50,3]\n4'
     *
     * 给定 n 个整数，找出平均数最大且长度为 k 的连续子数组，并输出该最大平均数。
     * 
     * 
     * 示例：
     * 输入：[1,12,-5,-6,50,3], k = 4
     * 输出：12.75
     * 解释：最大平均数 (12-5-6+50)/4 = 51/4 = 12.75
     * 
     * 
     * 提示：
     * 1 k n 
     * 所给数据范围 [-10,000，10,000]。
     * 
     * 
     */
    public class Solution643
    {
        /// <summary>
        /// 滑动窗口法（非常简单）
        /// 127/127 cases passed (384 ms)
        /// Your runtime beats 14.71 % of csharp submissions
        /// Your memory usage beats 5.88 % of csharp submissions(44.8 MB)
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public double FindMaxAverage(int[] nums, int k)
        {
            int sum = 0;
            int n = nums.Length;
            for (int i = 0; i < k; i++)
            {
                sum += nums[i];
            }
            int maxSum = sum;
            for (int i = k; i < n; i++)
            {
                sum = sum - nums[i - k] + nums[i];
                maxSum = Math.Max(maxSum, sum);
            }
            return 1.0 * maxSum / k;
        }
    }
}
