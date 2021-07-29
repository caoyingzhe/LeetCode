using System;
namespace CSharpConsoleApp.Solutions
{
    /*
     * @lc app=leetcode.cn id=371 lang=csharp
     *
     * [371] 两整数之和
     *
     * https://leetcode-cn.com/problems/sum-of-two-integers/description/
     *
     * Category	Difficulty	Likes	Dislikes
     * algorithms	Medium (57.88%)	412	-
     * Tags
     * bit-manipulation
     * 
     * Companies
     * Unknown
     * 
     * Total Accepted:    51.9K
     * Total Submissions: 89.6K
     * Testcase Example:  '1\n2'
     *
     * 不使用运算符 + 和 - ​​​​​​​，计算两整数 ​​​​​​​a 、b ​​​​​​​之和。
     * 
     * 示例 1:
     * 输入: a = 1, b = 2
     * 输出: 3
     * 
     * 
     * 示例 2:
     * 输入: a = -2, b = 3
     * 输出: 1
     * 
     */

    // @lc code=start
    public class Solution371 : SolutionBase
    {
        /// <summary>
        /// 难度
        /// </summary>
        public override Difficulity GetDifficulity() { return Difficulity.Medium; }
        /// <summary>
        /// 关键字:
        /// </summary>
        public override string[] GetKeyWords() { return new string[] { }; }
        /// <summary>
        /// 标签：
        /// </summary>
        public override Tag[] GetTags() { return new Tag[] { Tag.BitManipulation }; }

        
        public override bool Test(System.Diagnostics.Stopwatch sw)
        {
            bool isSuccess = true;

            int a, b;
            int result, checkResult;

            a = 1; b = 2;
            checkResult = 3;
            result = GetSum(a,b);
            isSuccess &= IsSame(result, checkResult);
            PrintResult(isSuccess, (result).ToString(), (checkResult).ToString());

            a = -2; b = 3;
            checkResult = 1;
            result = GetSum(a, b);
            isSuccess &= IsSame(result, checkResult);
            PrintResult(isSuccess, (result).ToString(), (checkResult).ToString());

            return isSuccess;
        }

        //https://leetcode-cn.com/problems/sum-of-two-integers/solution/371-liang-zheng-shu-zhi-he-yi-huo-an-wei-yu-by-xma/
        public int GetSum(int a, int b)
        {
            return GetSum1(a,b);
            //return GetSum2(a, b);
        }

        /// <summary>
        /// 1. 异或得到不进位加法的和，
        /// 2. 按位与并左移一位得到进位的和，
        /// 3. 两者相加即为两数之和。
        /// 
        /// 13/13 cases passed (32 ms)
        /// Your runtime beats 100 % of csharp submissions
        /// Your memory usage beats 68.75 % of csharp submissions(14.8 MB)
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public int GetSum1(int a, int b)
        {
            int aa = a, bb = b, c;
            do
            {
                c = aa & bb;
                aa ^= bb;
                bb = c << 1;
            } while (c != 0);
            return aa;
        }

        /// <summary>
        /// 可用迭代或递归。
        /// 13/13 cases passed (40 ms)
        /// Your runtime beats 93.75 % of csharp submissions
        /// Your memory usage beats 87.5 % of csharp submissions(14.8 MB)
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public int GetSum2(int a, int b)
        {
            if (b == 0) return a;
            return GetSum(a ^ b, (a & b) << 1);
        }
    }
    // @lc code=end


}
