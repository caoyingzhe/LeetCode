using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpConsoleApp.Solutions._0000
{
    /*
     * @lc app=leetcode.cn id=29 lang=csharp
     *
     * [29] 两数相除
     *
     * https://leetcode-cn.com/problems/divide-two-integers/description/
     *
     * Category	Difficulty	Likes	Dislikes
     * algorithms	Medium (69.56%)	908	-
     * Tags
     * linked-list
     * 
     * Companies
     * bloomberg | microsoft | uber
     * 
     * Total Accepted:    89.6K
     * Total Submissions: 438K
     * Testcase Example:  '10\n3'
     *
     * 给定两个整数，被除数 dividend 和除数 divisor。将两数相除，要求不使用乘法、除法和 mod 运算符。
     * 
     * 返回被除数 dividend 除以除数 divisor 得到的商。
     * 
     * 整数除法的结果应当截去（truncate）其小数部分，例如：truncate(8.345) = 8 以及 truncate(-2.7335) =
     * -2
     * 
     * 示例 1:
     * 输入: dividend = 10, divisor = 3
     * 输出: 3
     * 解释: 10/3 = truncate(3.33333..) = truncate(3) = 3
     * 
     * 示例 2:
     * 输入: dividend = 7, divisor = -3
     * 输出: -2
     * 解释: 7/-3 = truncate(-2.33333..) = -2
     * 
     * 提示：
     * 被除数和除数均为 32 位有符号整数。
     * 除数不为 0。
     * 假设我们的环境只能存储 32 位有符号整数，其数值范围是 [−2^31,  2^31 − 1]。本题中，如果除法结果溢出，则返回 2^31 − 1。
     * 
     */

    class Solution29 : SolutionBase
    {
        /// <summary>
        /// 难易度:
        /// </summary>
        public override Difficulity GetDifficulity() { return Difficulity.Medium; }
        /// <summary>
        /// 关键字:
        /// </summary>
        public override string[] GetKeyWords() { return new string[] { "位运算乘法", "位运算除法" }; }
        /// <summary>
        /// 标签： 
        /// </summary>
        public override Tag[] GetTags() { return new Tag[] { Tag.Math, Tag.BinarySearch}; }

        /// <summary>
        /// 作者：AC_OIer
        /// 链接：https://leetcode-cn.com/problems/divide-two-integers/solution/shua-chuan-lc-er-fen-bei-zeng-cheng-fa-j-m73b/
        /// </summary>
        /// <param name="sw"></param>
        /// <returns></returns>
        public override bool Test(System.Diagnostics.Stopwatch sw)
        {
            bool isSuccess = true;
            int dividend;
            int divisor;
            int result;
            int checkResult;

            dividend = 162; divisor = 9;
            checkResult = 7;
            result = Divide(dividend, divisor);
            isSuccess &= result == checkResult;
            Print("isSuccess = {0} | result = {1} | anticipated = {2}", isSuccess, result, checkResult);
            return isSuccess;
        }

        /// <summary>
        /// 溢出的原因： 为了得到正确结果，需要在计算时使用long，结果可能超出int范围。
        /// </summary>
        /// <param name="dividend"></param>
        /// <param name="divisor"></param>
        /// <returns></returns>
        public int Divide(int dividend, int divisor)
        {
            long x = dividend, y = divisor;

            bool isNeg = false;
            if ((x > 0 && y < 0) || (x < 0 && y > 0)) isNeg = true;  //确定商是否为负

            if (x < 0) x = -x;
            if (y < 0) y = -y;

            //通过l,r逐渐缩小边界,确定商。
            long l = 0, r = x;
            while (l < r)
            {
                long mid = l + r + 1 >> 1; //这里的l + r + 1 >> 1 的处理 = （l + r + 1) >> 1  移位运算优先度低于+-号。
                //Print("mid = l + r + 1 >> 1 {0}|{1} ( l + r + 1 ) = {2}, {3}", l, r, (l + r + 1), mid);

               long m = Mul(mid, y);
                if (m <= x)
                {
                    l = mid;
                    //Print("l=mid   {0}|{1}| mid = {2} mul({2},{3}) = {4}", l, r, mid, y, m);
                }
                else
                {
                    r = mid - 1;
                    //Print("r=mid-1 {0}|{1}| mid = {2} mul({2},{3}) = {4}", l, r, mid, y, m);
                }
            }

            long ans = isNeg ? -l : l; 
            if (ans > int.MaxValue || ans < int.MinValue) return int.MaxValue; //溢出处理
            return (int)ans;
        }

        // 只使用位运算的整数乘法（高速）
        long Mul(long a, long k)
        {
            long ans = 0;
            while (k > 0)
            {
                if ((k & 1) == 1) ans += a;
                k >>= 1;
                a += a;
            }
            return ans;
        }
    }
}
