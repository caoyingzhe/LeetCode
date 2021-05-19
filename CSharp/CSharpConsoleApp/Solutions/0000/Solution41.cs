using System;
namespace CSharpConsoleApp.Solutions
{
    /*
     * @lc app=leetcode.cn id=41 lang=csharp
     *
     * [41] 缺失的第一个正数
     *
     * https://leetcode-cn.com/problems/first-missing-positive/description/
     *
     * algorithms
     * Hard (40.97%)
     * Likes:    1078
     * Dislikes: 0
     * Total Accepted:    131.1K
     * Total Submissions: 319.7K
     * Testcase Example:  '[1,2,0]'
     *
     * 给你一个未排序的整数数组 nums ，请你找出其中没有出现的最小的正整数。
     * 
     * 进阶：你可以实现时间复杂度为 O(n) 并且只使用常数级别额外空间的解决方案吗？
     * 
     * 
     * 示例 1：
     * 输入：nums = [1,2,0]
     * 输出：3
     * 
     * 
     * 示例 2：
     * 输入：nums = [3,4,-1,1]
     * 输出：2
     * 
     * 
     * 示例 3：
     * 输入：nums = [7,8,9,11,12]
     * 输出：1
     * 
     * 提示：
     * 0 <= nums.length <= 300
     * -2^31 <= nums[i] <= 2^31 - 1
     * 
     */
    public class Solution41
    {
        /// <summary>
		/// 时间复杂度 O(N) + O(nlogN)
		/// </summary>
		/// <param name="nums"></param>
		/// <returns></returns>
        public int FirstMissingPositive_VerySlow(int[] nums)
        {
            Array.Sort(nums);

            int result = 1;
            for (int i = 0; i < nums.Length; i++)
            {
                if (result == nums[i])
                {
                    result++;
                }
            }
            return result;
        }

        /// <summary>
        /// 时间复杂度 O(3N)
		/// 方法1: 设置存在值为负数。
		/// 
		/// 该方法依旧很慢
        /// 170/170 cases passed (232 ms)
        /// Your runtime beats 6.56 % of csharp submissions
        /// Your memory usage beats 5.74 % of csharp submissions(44.4 MB)
        /// 
        ///作者：LeetCode-Solution
        ///链接：https://leetcode-cn.com/problems/first-missing-positive/solution/que-shi-de-di-yi-ge-zheng-shu-by-leetcode-solution/
        ///170/170 cases passed (312 ms)
        ///Your runtime beats 6.56 % of csharp submissions
        ///Your memory usage beats 5.74 % of csharp submissions(44.3 MB)
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int FirstMissingPositive_MinusFlag(int[] nums)
        {
            int n = nums.Length;

            //小于等于0的，均设置为N。处理结果，所有值变为正；
            //因为最大返回值也就是N+1。如果存在负数，结果还要小于N+1；
            for (int i = 0; i < n; ++i)
            {
                if (nums[i] <= 0)
                {
                    nums[i] = n + 1;
                }
            }
            //绝对值小于n的，直接设置对应位置的绝对值的负值。
            //num = -5; N=8, nums[4] = -5;
            //num = -3; N=8, nums[3] = -3;
            //num = 0;  N=8, nums[0] = 0;
            //num = 8,  N=8, nums[7] = 8;
            //num = 9, 不处理。（或许之前或之后的处理中被覆盖掉）

            //均设置为绝对值的负数。处理结果，所有值变为负；
            for (int i = 0; i < n; ++i)
            {
                int num = Math.Abs(nums[i]);
                if (num <= n)
                {
                    nums[num - 1] = -Math.Abs(nums[num - 1]);
                }
            }

            //当对应i的数值为正值时，就是没有被处理过，对应索引+1就是我们想要的结果
            for (int i = 0; i < n; ++i)
            {
                if (nums[i] > 0)
                {
                    return i + 1;
                }
            }
            //没有找到就返回 n+1
            return n + 1;
        }


        /// <summary>
        /// 方法2。置换
        /// 时间复杂度 O(2N)
        /// 比方法只1快了一点，排名比例依然一样。效率还是不佳
        /// 170/170 cases passed (264 ms)
        /// Your runtime beats 6.56 % of csharp submissions
        /// Your memory usage beats 5.74 % of csharp submissions(43.9 MB)
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int FirstMissingPositive_NotGood2(int[] nums)
        {
            int n = nums.Length;
            for (int i = 0; i < n; ++i)
            {
                //寻找 1～n之间的数，并交换位置
                //比如 num[0] = 6,  n=8, 如果 nums[6-1]=num[5] != 6， 交换让 num[0] = nums[5]的旧值。nums[5] = 6
                //假定 nums[5]的旧值在1～n之间，比如 奴nums[5] = 3; 那就要继续交换位置，直至num[i]变为 1～n 范围外为止。
                while (nums[i] > 0 && nums[i] <= n && nums[nums[i] - 1] != nums[i])
                {
                    int temp = nums[nums[i] - 1];
                    nums[nums[i] - 1] = nums[i];
                    nums[i] = temp;
                }
            }

            //只要对应i位置的值 不等于i+1（可能小于等于0，可能大于n），i+1就是我们要的结果。
            for (int i = 0; i < n; ++i)
            {
                if (nums[i] != i + 1)
                {
                    return i + 1;
                }
            }
            return n + 1;
        }

        /// <summary>
        /// 该方法无法通过LeetCode，原因是Leetcode修改了条件，但是题目的说明却没有更新。
        /// LeetCode官方修改了nums的长度，竟然出现了 500001 的答案。
        ///
        /// Wrong Answer
        /// 169/170 cases passed(N/A)
        /// Answer 301
        /// Expected Answer 500001
        ///
        /// 0 <= nums.length <= 300
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        //作者：liao-jia-long
        //链接：https://leetcode-cn.com/problems/first-missing-positive/solution/yi-ge-xun-huan-su-du-ji-bai-100-by-liao-b7q2j/
        public int FirstMissingPositive(int[] nums)
        {
            int di = 0;
            //定义300个连续正数标识位
            int[] dp = new int[300];
            for (int i = 0; i < nums.Length; i++)
            {
                // 小于1，大于300的排除
                if (nums[i] <= 0 || nums[i] > 300)
                {
                    continue;
                }
                else
                {
                    // 1到300之间的存入数组
                    dp[nums[i] - 1] = 1;

                    // 每加入一个数字后，就找从1开始的最大连续正数
                    while (dp[di] > 0)
                    {
                        di++;
                    }
                }
            }

            // 最大连续正数的下一个数就是第一个缺失的正数
            return ++di;
        }
    }
}
