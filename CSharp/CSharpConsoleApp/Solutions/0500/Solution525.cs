using System;
using System.Collections.Generic;
namespace CSharpConsoleApp.Solutions
{
    /*
     * @lc app=leetcode.cn id=525 lang=csharp
     *
     * [525] 连续数组
     *
     * https://leetcode-cn.com/problems/contiguous-array/description/
     *
     * algorithms
     * Medium (53.64%)
     * Likes:    438
     * Dislikes: 0
     * Total Accepted:    42.2K
     * Total Submissions: 78.6K
     * Testcase Example:  '[0,1]'
     *
     * 给定一个二进制数组 nums , 找到含有相同数量的 0 和 1 的最长连续子数组，并返回该子数组的长度。
     * 
     * 
     * 
     * 示例 1:
     * 输入: nums = [0,1]
     * 输出: 2
     * 说明: [0, 1] 是具有相同数量 0 和 1 的最长连续子数组。
     * 
     * 示例 2:
     * 输入: nums = [0,1,0]
     * 输出: 2
     * 说明: [0, 1] (或 [1, 0]) 是具有相同数量0和1的最长连续子数组。
     * 
     * 
     * 
     * 提示：
     * 1 <= nums.length <= 105
     * nums[i] 不是 0 就是 1
     */

    // @lc code=start
    public class Solution525 : SolutionBase
    {
        /// <summary>
        /// 难度
        /// </summary>
        public override Difficulity GetDifficulity() { return Difficulity.Medium; }
        /// <summary>
        /// 关键字:
        /// </summary>
        public override string[] GetKeyWords() { return new string[] { "待理解好题", }; }
        /// <summary>
        /// 标签：
        /// </summary>
        public override Tag[] GetTags() { return new Tag[] { Tag.Math, Tag.DynamicProgramming }; }


        public override bool Test(System.Diagnostics.Stopwatch sw)
        {
            bool isSuccess = true;
            isSuccess &= Test(nums: new int[] { 0, 1 },  2);
            isSuccess &= Test(nums: new int[] { 0, 1, 0 },  2);
            isSuccess &= Test(nums: new int[] { 23, 2, 6, 4, 7 },  1);
            //-2,0,-1
            return isSuccess;
        }
        public bool Test(int[] nums, int checkResult)
        {
            bool isSuccess = true;
            int result = FindMaxLength(nums);
            isSuccess = IsSame(result, checkResult);
            PrintResult(isSuccess, result, checkResult);
            return isSuccess;
        }

        //作者：LeetCode - Solution
        //链接：https://leetcode-cn.com/problems/contiguous-array/solution/lian-xu-shu-zu-by-leetcode-solution-mvnm/

        /// <summary>
        /// 564/564 cases passed (220 ms)
        /// Your runtime beats 99.65 % of csharp submissions
        /// Your memory usage beats 69.5 % of csharp submissions(43.2 MB)
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int FindMaxLength(int[] nums)
        {
            int max = 0;
            Dictionary<int, int> dict = new Dictionary<int, int>();

            int counter = 0;
            dict.Add(counter, -1);

            int n = nums.Length;
            for (int i = 0; i < n; i++)
            {
                int num = nums[i];
                if (num == 1)
                {
                    counter++;
                }
                else // i==0
                {
                    counter--;
                }
                if (dict.ContainsKey(counter)) 
                {
                    int prevIndex = dict[counter];
                    //此处算法最精妙，直接使用索引减法得出结果。
                    max = Math.Max(max, i - prevIndex);
                }
                else
                {
                    dict.Add(counter, i);
                }
            }
            return max;
        }
    }
    // @lc code=end


}
