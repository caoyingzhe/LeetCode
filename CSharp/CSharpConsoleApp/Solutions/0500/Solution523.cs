using System;
using System.Collections.Generic;
namespace CSharpConsoleApp.Solutions
{
    /*
     * @lc app=leetcode.cn id=523 lang=csharp
     *
     * [523] 连续的子数组和
     *
     * https://leetcode-cn.com/problems/continuous-subarray-sum/description/
     *
     * Category	Difficulty	Likes	Dislikes
     * algorithms	Medium (27.35%)	358	-
     * Tags
     * math | dynamic-programming
     * 
     * Companies
     * facebook
     * 
     * Total Accepted:    65.1K
     * Total Submissions: 237.9K
     * Testcase Example:  '[23,2,4,6,7]\n6'
     *
     * 给你一个整数数组 nums 和一个整数 k ，编写一个函数来判断该数组是否含有同时满足下述条件的连续子数组：
     * 子数组大小 至少为 2 ，且子数组元素总和为 k 的倍数。
     * 如果存在，返回 true ；否则，返回 false 。
     * 
     * 如果存在一个整数 n ，令整数 x 符合 x = n * k ，则称 x 是 k 的一个倍数。0 始终视为 k 的一个倍数。
     * 
     * 示例 1：
     * 输入：nums = [23,2,4,6,7], k = 6
     * 输出：true
     * 解释：[2,4] 是一个大小为 2 的子数组，并且和为 6 。
     * 
     * 示例 2：
     * 输入：nums = [23,2,6,4,7], k = 6
     * 输出：true
     * 解释：[23, 2, 6, 4, 7] 是大小为 5 的子数组，并且和为 42 。 
     * 42 是 6 的倍数，因为 42 = 7 * 6 且 7 是一个整数。
     * 
     * 
     * 示例 3：
     * 输入：nums = [23,2,6,4,7], k = 13
     * 输出：false
     * 
     * 
     * 提示：
     * 1 <= nums.length <= 10^5
     * 0 <= nums[i] <= 10^9
     * 0 <= sum(nums[i]) <= 2^31 - 1
     * 1 <= k <= 2^31 - 1
     */

    // @lc code=start
    public class Solution523 : SolutionBase
    {
        /// <summary>
        /// 难度
        /// </summary>
        public override Difficulity GetDifficulity() { return Difficulity.Medium; }
        /// <summary>
        /// 关键字:
        /// </summary>
        public override string[] GetKeyWords() { return new string[] { "", }; }
        /// <summary>
        /// 标签：
        /// </summary>
        public override Tag[] GetTags() { return new Tag[] { Tag.Math, Tag.DynamicProgramming }; }


        public override bool Test(System.Diagnostics.Stopwatch sw)
        {
            bool isSuccess = true;
            isSuccess &= Test(nums: new int[] { 23, 2, 4, 6, 7 }, k: 6, true);
            isSuccess &= Test(nums: new int[] { 23, 2, 6, 4, 7 }, k: 6, true);
            isSuccess &= Test(nums: new int[] { 23, 2, 6, 4, 7 }, k: 13, false);


            //-2,0,-1
            return isSuccess;
        }
        public bool Test(int[] nums, int k, bool checkResult)
        {
            bool isSuccess = true;
            bool result = CheckSubarraySum(nums, k);
            isSuccess = IsSame(result, checkResult);
            PrintResult(isSuccess, result, checkResult);
            return isSuccess;
        }

        /// <summary>
        /// 时间复杂度 O(N)
        /// 空间复杂度：O(min(n,k))
        /// 
        /// 94/94 cases passed (256 ms)
        /// Your runtime beats 99.7 % of csharp submissions
        /// Your memory usage beats 86.53 % of csharp submissions(45 MB)
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public bool CheckSubarraySum(int[] nums, int k)
        {
            int m = nums.Length;
            if (m < 2) return false;

            Dictionary<int, int> map = new Dictionary<int, int>();
            map.Add(0, -1);

            int mod = 0; //mod为累计和对k的模
            for (int i = 0; i < m; i++)
            {
                mod = (mod + nums[i]) % k;
                if (map.ContainsKey(mod))
                {
                    int prevIndex = map[mod]; // 获取前一个相同mod的索引
                    if (i - prevIndex >= 2)
                    {
                        return true;
                    }
                }
                else
                {
                    map.Add(mod, i); //添加mod的索引
                }
            }
            return false;
        }
        //Time Limit Exceeded  93/94 cases passed (N/A)
        /// <summary>
        /// 时间复杂度 O(N^2)
        /// 空间复杂度：O(1)
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public bool CheckSubarraySum_TLE(int[] nums, int k)
        {
            int n = nums.Length;

            int mod;
            for (int i = 0; i < n - 1; i++)
            {
                mod = nums[i] % k;
                for (int j = i + 1; j < n; j++)
                {
                    mod = (mod + nums[j]) % k;
                    if (mod == 0)
                        return true;
                }
            }
            return false;
        }
    }
    // @lc code=end


}
