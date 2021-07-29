using System;
namespace CSharpConsoleApp.Solutions
{
    /*
     * @lc app=leetcode.cn id=209 lang=csharp
     *
     * [209] 长度最小的子数组
     *
     * https://leetcode-cn.com/problems/minimum-size-subarray-sum/description/
     *
     * Category	Difficulty	Likes	Dislikes
     * algorithms	Medium (46.33%)	689	-
     * Tags
     * array | two-pointers | binary-search
     * 
     * Companies
     * facebook
     * Total Accepted:    158.4K
     * Total Submissions: 341.3K
     * Testcase Example:  '7\n[2,3,1,2,4,3]'
     *
     * 给定一个含有 n 个正整数的数组和一个正整数 target 。
     * 
     * 找出该数组中满足其和 ≥ target 的长度最小的 连续子数组 [numsl, numsl+1, ..., numsr-1, numsr]
     * ，并返回其长度。如果不存在符合条件的子数组，返回 0 。
     *
     * 
     * 示例 1：
     * 输入：target = 7, nums = [2,3,1,2,4,3]
     * 输出：2
     * 解释：子数组 [4,3] 是该条件下的长度最小的子数组。
     * 
     * 
     * 示例 2：
     * 输入：target = 4, nums = [1,4,4]
     * 输出：1
     * 
     * 
     * 示例 3：
     * 输入：target = 11, nums = [1,1,1,1,1,1,1,1]
     * 输出：0
     * 
     * 
     * 提示：
     * 1 <= target <= 109
     * 1 <= nums.length <= 105
     * 1 <= nums[i] <= 105
     * 
     * 
     * 进阶：
     * 如果你已经实现 O(n) 时间复杂度的解法, 请尝试设计一个 O(n log(n)) 时间复杂度的解法。
     */

    // @lc code=start
    public class Solution209 : SolutionBase
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
        public override Tag[] GetTags() { return new Tag[] { Tag.Array, Tag.TwoPointers, Tag.BinarySearch }; }

        
        public override bool Test(System.Diagnostics.Stopwatch sw)
        {
            bool isSuccess = true;
            int target; int[] nums;
            int result, checkResult;

            target = 7; nums = new int[] { 2, 3, 1, 2, 4, 3 };
            checkResult = 2;
            result = MinSubArrayLen(target, nums);
            isSuccess &= IsSame(result, checkResult);
            PrintResult(isSuccess, (result), (checkResult));


            target = 11; nums = new int[] { 1, 1, 1, 1, 1, 1, 1, 1 };
            checkResult = 0;
            result = MinSubArrayLen(target, nums);
            isSuccess &= IsSame(result, checkResult);
            PrintResult(isSuccess, (result), (checkResult));


            return isSuccess;
        }

        //作者：LeetCode - Solution
        //链接：https://leetcode-cn.com/problems/minimum-size-subarray-sum/solution/chang-du-zui-xiao-de-zi-shu-zu-by-leetcode-solutio/
        /// <summary>
        /// 19/19 cases passed (80 ms)
        /// Your runtime beats 100 % of csharp submissions
        /// Your memory usage beats 14.1 % of csharp submissions(25.8 MB)
        /// </summary>
        /// <param name="target"></param>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int MinSubArrayLen(int target, int[] nums)
        {
            int n = nums.Length;
            if (n == 0)
            {
                return 0;
            }

            int ans = int.MaxValue;
            int start = 0, end = 0;
            int sum = 0;
            while (end < n)
            {
                sum += nums[end];
                while (sum >= target)
                {
                    ans = Math.Min(ans, end - start + 1);
                    sum -= nums[start];
                    ++start;
                }
                ++end;
            }
            return ans == int.MaxValue ? 0 : ans;
        }
    }
    // @lc code=end


}
