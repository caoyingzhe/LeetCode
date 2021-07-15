using System;
using System.Collections.Generic;
namespace CSharpConsoleApp.Solutions
{
    /*
     * @lc app=leetcode.cn id=201 lang=csharp
     *
     * [201] 数字范围按位与
     *
     * https://leetcode-cn.com/problems/bitwise-and-of-numbers-range/description/
     *
     * Category	Difficulty	Likes	Dislikes
     * algorithms	Medium (51.92%)	303	-
     * Tags
     * bit-manipulation
     * 
     * Companies
     * Unknown
     * 
     * Total Accepted:    45.6K
     * Total Submissions: 87.9K
     * Testcase Example:  '5\n7'
     *
     * 给你两个整数 left 和 right ，表示区间 [left, right] ，返回此区间内所有数字 按位与 的结果（包含 left 、right
     * 端点）。
     * 
     * 
     * 
     * 示例 1：
     * 
     * 
     * 输入：left = 5, right = 7
     * 输出：4
     * 
     * 
     * 示例 2：
     * 
     * 
     * 输入：left = 0, right = 0
     * 输出：0
     * 
     * 
     * 示例 3：
     * 
     * 
     * 输入：left = 1, right = 2147483647
     * 输出：0
     * 
     * 
     * 
     * 
     * 提示：
     * 
     * 
     * 0 
     * 
     * 
     */

    // @lc code=start
    public class Solution201 : SolutionBase
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
        public override Tag[] GetTags() { return new Tag[] { Tag.HashTable, Tag.BitManipulation }; }

        public int NULL = -1;
        public override bool Test(System.Diagnostics.Stopwatch sw)
        {
            bool isSuccess = true;
            int left, right;
            int result, checkResult;

            left = 5; right = 7;
            checkResult = 4;
            result = RangeBitwiseAnd(left, right);
            isSuccess &= IsSame(result, checkResult);
            PrintResult(isSuccess, (result), (checkResult));

            left = 1; right = 2147483647;
            checkResult = 0;
            result = RangeBitwiseAnd(left, right);
            isSuccess &= IsSame(result, checkResult);
            PrintResult(isSuccess, (result), (checkResult));

            left = 0; right = 0;
            checkResult = 0;
            result = RangeBitwiseAnd(left, right);
            isSuccess &= IsSame(result, checkResult);
            PrintResult(isSuccess, (result), (checkResult));

            return isSuccess;
        }

        /// <summary>
        /// 作者：LeetCode-Solution
        /// 链接：https://leetcode-cn.com/problems/bitwise-and-of-numbers-range/solution/shu-zi-fan-wei-an-wei-yu-by-leetcode-solution/
        /// 8268/8268 cases passed (52 ms)
        /// Your runtime beats 100 % of csharp submissions
        /// Your memory usage beats 54.54 % of csharp submissions(15.8 MB)
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public int RangeBitwiseAnd(int left, int right)
        {
            int shift = 0;
            // 找到公共前缀
            while (left < right)
            {
                left >>= 1;
                right >>= 1;
                ++shift;
            }
            return left << shift;
        }
    }
    // @lc code=end


}
