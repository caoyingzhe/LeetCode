using System;
namespace CSharpConsoleApp.Solutions
{
    /*
     * @lc app=leetcode.cn id=53 lang=csharp
     *
     * [53] 最大子序和
     *
     * https://leetcode-cn.com/problems/maximum-subarray/description/
     *
     * Category	Difficulty	Likes	Dislikes
     * algorithms	Easy (54.12%)	3234	-
     * Tags
     * array | divide-and-conquer | dynamic-programming
     * 
     * Companies
     * bloomberg | linkedin | microsoft
     * 
     * Total Accepted:    512.1K
     * Total Submissions: 945.5K
     * Testcase Example:  '[-2,1,-3,4,-1,2,1,-5,4]'
     *
     * 给定一个整数数组 nums ，找到一个具有最大和的连续子数组（子数组最少包含一个元素），返回其最大和。
     * 
     * 示例 1：
     * 输入：nums = [-2,1,-3,4,-1,2,1,-5,4]
     * 输出：6
     * 解释：连续子数组 [4,-1,2,1] 的和最大，为 6 。
     * 
     * 示例 2：
     * 输入：nums = [1]
     * 输出：1
     * 
     * 示例 3：
     * 输入：nums = [0]
     * 输出：0
     * 
     * 示例 4：
     * 输入：nums = [-1]
     * 输出：-1
     * 
     * 示例 5：
     * 输入：nums = [-100000]
     * 输出：-100000
     * 
     * 提示：
     * 1 <= nums.length <= 3 * 10^4
     * -10^5 <= nums[i] <= 10^5 
     * 
     * 进阶：如果你已经实现复杂度为 O(n) 的解法，尝试使用更为精妙的 分治法 求解。
     */
    public class Solution53
    {
        /// <summary>
        /// 203/203 cases passed (108 ms)
        /// Your runtime beats 88.17 % of csharp submissions
        /// Your memory usage beats 96.67 % of csharp submissions(25 MB)
        /// 作者：LeetCode-Solution
        /// 链接：https://leetcode-cn.com/problems/maximum-subarray/solution/zui-da-zi-xu-he-by-leetcode-solution/
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int MaxSubArray(int[] nums)
        {
            int pre = 0;
            int maxSum = nums[0];
            foreach (int x in nums)
            {
                pre = Math.Max(pre + x, x);     //更新前一个值的最大值（只要前一个为正，即取前一个值+自己）
                maxSum = Math.Max(maxSum, pre);
            }
            return maxSum;
        }
    }
}
