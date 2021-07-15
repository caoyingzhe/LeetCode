using System;
namespace CSharpConsoleApp.Solutions
{
    /*
     * @lc app=leetcode.cn id=367 lang=csharp
     *
     * [367] 有效的完全平方数
     *
     * https://leetcode-cn.com/problems/valid-perfect-square/description/
     *
     * Category	Difficulty	Likes	Dislikes
     * algorithms	Easy (43.83%)	229	-
     * Tags
     * math | binary-search
     * 
     * Companies
     * linkedin
     * 
     * Total Accepted:    67.6K
     * Total Submissions: 154.2K
     * Testcase Example:  '16'
     *
     * 给定一个 正整数 num ，编写一个函数，如果 num 是一个完全平方数，则返回 true ，否则返回 false 。
     * 进阶：不要 使用任何内置的库函数，如  sqrt 。
     * 
     * 
     * 示例 1：
     * 输入：num = 16
     * 输出：true
     * 
     * 
     * 示例 2：
     * 输入：num = 14
     * 输出：false
     * 
     * 
     * 提示：
     * 1 <= num <= 2^31 - 1
     */

    // @lc code=start
    public class Solution367 : SolutionBase
    {
        /// <summary>
        /// 难度
        /// </summary>
        public override Difficulity GetDifficulity() { return Difficulity.Easy; }
        /// <summary>
        /// 关键字:
        /// </summary>
        public override string[] GetKeyWords() { return new string[] { }; }
        /// <summary>
        /// 标签：hash-table | two-pointers | binary-search | sort
        /// </summary>
        public override Tag[] GetTags() { return new Tag[] { Tag.HashTable, Tag.TwoPointers, Tag.BinarySearch, Tag.Sort }; }

        public override bool Test(System.Diagnostics.Stopwatch sw)
        {
            bool isSuccess = true;
            int num;
            bool result, checkResult;

            num = 16;
            checkResult = true;
            result = IsPerfectSquare(num);
            isSuccess &= IsSame(result, checkResult);
            Print("isSuccess = {0} result = {1} | checkResult = {2}", isSuccess, (result), (checkResult));

            num = 120;
            checkResult = false;
            result = IsPerfectSquare(num);
            isSuccess &= IsSame(result, checkResult);
            Print("isSuccess = {0} result = {1} | checkResult = {2}", isSuccess, (result), (checkResult));


            return isSuccess;
        }
        /// <summary>
        /// 牛顿迭代法
        /// 作者：LeetCode
        /// 链接：https://leetcode-cn.com/problems/valid-perfect-square/solution/you-xiao-de-wan-quan-ping-fang-shu-by-leetcode/
        /// 70/70 cases passed (48 ms)
        /// Your runtime beats 63.01 % of csharp submissions
        /// Your memory usage beats 100 % of csharp submissions(14.6 MB)
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        public bool IsPerfectSquare_N(int num)
        {
            if (num < 2) return true;

            long x = num / 2;
            while (x * x > num)
            {
                x = (x + num / x) / 2;
            }
            return (x * x == num);
        }

        /// <summary>
        /// 二分法
        /// 70/70 cases passed (48 ms)
        /// 7Your runtime beats 63.01 % of csharp submissions
        /// 7Your memory usage beats 27.4 % of csharp submissions(14.9 MB)
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        public bool IsPerfectSquare(int num)
        {
            if (num < 2)
            {
                return true;
            }

            long left = 2, right = num / 2, x, guessSquared;
            while (left <= right)
            {
                x = left + (right - left) / 2;
                guessSquared = x * x;
                if (guessSquared == num)
                {
                    return true;
                }
                if (guessSquared > num)
                {
                    right = x - 1;
                }
                else
                {
                    left = x + 1;
                }
            }
            return false;
        }
    }
    // @lc code=end


}
