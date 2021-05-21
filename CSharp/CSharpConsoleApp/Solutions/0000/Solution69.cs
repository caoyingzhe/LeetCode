using System;
namespace CSharpConsoleApp.Solutions
{
    /*
     * @lc app=leetcode.cn id=69 lang=csharp
     *
     * [69] x 的平方根
     *
     * https://leetcode-cn.com/problems/sqrtx/description/
     *
     * algorithms
     * Easy (39.24%)
     * Likes:    680
     * Dislikes: 0
     * Total Accepted:    311K
     * Total Submissions: 792.7K
     * Testcase Example:  '4'
     *
     * 实现 int sqrt(int x) 函数。
     * 
     * 计算并返回 x 的平方根，其中 x 是非负整数。
     * 
     * 由于返回类型是整数，结果只保留整数的部分，小数部分将被舍去。
     * 
     * 示例 1:
     * 输入: 4
     * 输出: 2
     * 
     * 
     * 示例 2:
     * 输入: 8
     * 输出: 2
     * 
     * 说明: 8 的平方根是 2.82842..., 
     * 由于返回类型是整数，小数部分将被舍去。
     */


    public class Solution69
    {
        //作者：LeetCode-Solution
        //链接：https://leetcode-cn.com/problems/sqrtx/solution/x-de-ping-fang-gen-by-leetcode-solution/
        public int MySqrt_2(int x)
        {
            if (x == 0)
            {
                return 0;
            }
            int ans = (int)Math.Exp(0.5 * Math.Log(x));
            return (long)(ans + 1) * (ans + 1) <= x ? ans + 1 : ans;
        }

        /// <summary>
        /// 14/1017 cases passed (N/A)
        /// 
        /// Testcase : 2147395599
        /// Expected Answer : 46339
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        //作者：heroding
        //链接：https://leetcode-cn.com/problems/sqrtx/solution/cer-fen-fa-by-heroding-309l/
        int MySqrt_TLE(int x)
        {
            int low = 0, high = x;
            if (x == 0 || x == 1) return x;
            while (low < high)
            {
                int mid = (low + high) / 2;

                long powerM = mid * mid;
                if (x == powerM)
                    return mid;
                if (x > powerM)
                    low = mid + 1;  //+1 效率太低，是超时的根本原因。 C++虽然快，但是Java，C#不过。
                else
                    high = mid;
            }
            return high - 1;
        }

        /// <summary>
        /// 1017/1017 cases passed (52 ms)
        /// Your runtime beats 52.08 % of csharp submissions
        /// Your memory usage beats 77.38 % of csharp submissions(14.9 MB)
        /// 作者：LeetCode-Solution
        /// 链接：https://leetcode-cn.com/problems/sqrtx/solution/x-de-ping-fang-gen-by-leetcode-solution/
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public int MySqrt(int x)
        {
            int l = 0, r = x;
            int ans = -1;
            while (l <= r)
            {
                int mid = l + (r - l) / 2;

                if ((long)mid * mid <= x)
                {
                    ans = mid;
                    l = mid + 1;
                }
                else
                {
                    r = mid - 1;
                }
            }
            return ans;
        }
    }
}
