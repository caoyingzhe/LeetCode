using System;
namespace CSharpConsoleApp.Solutions
{
    /*
     * @lc app=leetcode.cn id=485 lang=csharp
     *
     * [485] 最大连续 1 的个数
     *
     * https://leetcode-cn.com/problems/max-consecutive-ones/description/
     *
     * algorithms
     * Easy (60.27%)
     * Likes:    247
     * Dislikes: 0
     * Total Accepted:    109.7K
     * Total Submissions: 182K
     * Testcase Example:  '[1,1,0,1,1,1]'
     *
     * 给定一个二进制数组， 计算其中最大连续 1 的个数。
     * 
     * 
     * 示例：
     * 输入：[1,1,0,1,1,1]
     * 输出：3
     * 解释：开头的两位和最后的三位都是连续 1 ，所以最大连续 1 的个数是 3.
     *
     * 
     * 提示：
     * 输入的数组只包含 0 和 1 。
     * 输入数组的长度是正整数，且不超过 10,000。
     */

    // @lc code=start
    public class Solution485 : SolutionBase
    {
        /// <summary>
        /// 难度
        /// </summary>
        public override Difficulity GetDifficulity() { return Difficulity.Easy; }
        /// <summary>
        /// 关键字:
        /// </summary>
        public override string[] GetKeyWords() { return new string[] { "" }; }
        /// <summary>
        /// 标签：
        /// </summary>
        public override Tag[] GetTags() { return new Tag[] { Tag.Array, }; }

        public override bool Test(System.Diagnostics.Stopwatch sw)
        {
            bool isSuccess = true;
            int[] nums;
            int result, checkResult;

            nums = new int[] { 1, 5, 2 };
            checkResult = 1;
            result = FindMaxConsecutiveOnes(nums);

            isSuccess &= IsSame(result, checkResult);
            PrintResult(isSuccess, (result), (checkResult));

            nums = new int[] { 1, 5, 233, 7 };
            checkResult = 1;
            result = FindMaxConsecutiveOnes(nums);

            isSuccess &= IsSame(result, checkResult);
            PrintResult(isSuccess, (result), (checkResult));
            return isSuccess;
        }

        public int FindMaxConsecutiveOnes(int[] nums)
        {
            
            int maxCount = 0, count = 0;
            int n = nums.Length;
            for (int i = 0; i < n; i++)
            {
                if (nums[i] == 1)
                {
                    count++;
                }
                else
                {
                    maxCount = Math.Max(maxCount, count);
                    count = 0;
                }
            }
            maxCount = Math.Max(maxCount, count);
            return maxCount;
        }
    }
    // @lc code=end
}
