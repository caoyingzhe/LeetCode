using System;
namespace CSharpConsoleApp.Solutions
{
    /*
 * @lc app=leetcode.cn id=137 lang=csharp
 *
 * [137] 只出现一次的数字 II
 *
 * https://leetcode-cn.com/problems/single-number-ii/description/
 *
 * Category	Difficulty	Likes	Dislikes
 * algorithms	Medium (71.90%)	686	-
 * Tags
 * bit-manipulation
 * 
 * Companies
 * Unknown
 * 
 * Total Accepted:    92.1K
 * Total Submissions: 128.1K
 * Testcase Example:  '[2,2,3,2]'
 *
 * 给你一个整数数组 nums ，除某个元素仅出现 一次 外，其余每个元素都恰出现 三次 。请你找出并返回那个只出现了一次的元素。
 * 
 * 
 * 示例 1：
 * 输入：nums = [2,2,3,2]
 * 输出：3
 * 
 * 
 * 示例 2：
 * 输入：nums = [0,1,0,1,0,1,99]
 * 输出：99
 * 
 * 
 * 提示：
 * 1 <= nums.length <= 3 * 10^4
 * 2^31  <= nums[i] <= 2^31 -1
 * nums 中，除某个元素仅出现 一次 外，其余每个元素都恰出现 三次
 * 
 * 进阶：你的算法应该具有线性时间复杂度。 你可以不使用额外空间来实现吗？
 */

    // @lc code=start
    public class Solution137 : SolutionBase
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
        public override Tag[] GetTags() { return new Tag[] { Tag.BitManipulation }; }

        public int NULL = -1;
        public override bool Test(System.Diagnostics.Stopwatch sw)
        {
            bool isSuccess = true;
            isSuccess &= SingleNumber(new int[] { 2, 2, 3, 2 }) == 2;
            return isSuccess;
        }

        /// <summary>
        /// 方法三 : 数字电路设计
        /// 作者：LeetCode-Solution
        /// 链接：https://leetcode-cn.com/problems/single-number-ii/solution/zhi-chu-xian-yi-ci-de-shu-zi-ii-by-leetc-23t6/
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int SingleNumber_Slow(int[] nums)
        {
            int a = 0, b = 0;
            foreach (int num in nums)
            {
                int aNext = (~a & b & num) | (a & ~b & ~num);
                int bNext = ~a & (b ^ num);
                a = aNext;
                b = bNext;
            }
            return b;
        }

        /// <summary>
        /// 方法四 : 数字电路设计优化
        /// 作者：LeetCode-Solution
        /// 链接：https://leetcode-cn.com/problems/single-number-ii/solution/zhi-chu-xian-yi-ci-de-shu-zi-ii-by-leetc-23t6/
        /// 14/14 cases passed (76 ms)
        /// Your runtime beats 100 % of csharp submissions
        /// Your memory usage beats 97.99 % of csharp submissions(24.7 MB)
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int SingleNumber(int[] nums)
        {
            int a = 0, b = 0;
            foreach (int num in nums)
            {
                b = ~a & (b ^ num);
                a = ~b & (a ^ num);
            }
            return b;
        }
    }
    // @lc code=end


}
