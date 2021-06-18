using System;
namespace CSharpConsoleApp.Solutions
{
    /*
     * @lc app=leetcode.cn id=483 lang=csharp
     *
     * [483] 最小好进制
     *
     * https://leetcode-cn.com/problems/smallest-good-base/description/
     *
     * Category	Difficulty	Likes	Dislikes
     * algorithms	Hard (43.63%)	54	-
     * Tags
     * math | binary-search
     * 
     * Companies
     * google
     * Total Accepted:    2.2K
     * Total Submissions: 5.2K
     * Testcase Example:  '"13"'
     *
     * 对于给定的整数 n, 如果n的k（k>=2）进制数的所有数位全为1，则称 k（k>=2）是 n 的一个好进制。
     * 以字符串的形式给出 n, 以字符串的形式返回 n 的最小好进制。
     * 
     * 示例 1：
     * 输入："13"
     * 输出："3"
     * 解释：13 的 3 进制是 111。
     * 
     * 示例 2：
     * 输入："4681"
     * 输出："8"
     * 解释：4681 的 8 进制是 11111。
     * 
     * 示例 3：
     * 输入："1000000000000000000"
     * 输出："999999999999999999"
     * 解释：1000000000000000000 的 999999999999999999 进制是 11。
     * 
     * 提示：
     * n的取值范围是 [3, 10^18]。
     * 输入总是有效且没有前导 0。
     */
    public class Solution483 : SolutionBase
    {
        /// <summary>
        /// 难度
        /// </summary>
        public override Difficulity GetDifficulity() { return Difficulity.Hard; }
        /// <summary>
        /// 关键字:
        /// </summary>
        public override string[] GetKeyWords() { return new string[] { "" }; }
        /// <summary>
        /// 标签：
        /// </summary>
        public override Tag[] GetTags() { return new Tag[] { Tag.String, }; }

        public override bool Test(System.Diagnostics.Stopwatch sw)
        {
            bool isSuccess = true;
            string n;
            string result, checkResult;

            //houses = new int[] { 1, 3, -1, -3, 5, 3, 6, 7 }; k = 3;
            //checkResult = new double[] { 1, -1, -1, 3, 5, 6 };
            //result = MedianSlidingWindow(houses, k);

            //isSuccess &= IsArraySame(result, checkResult);
            //Print("isSuccess = {0} | result = {1} | anticipated = {2}", isSuccess, GetArrayStr(result), GetArrayStr(checkResult));

            //n = "1000000000000000000";
            //checkResult = "999999999999999999";
            //result = SmallestGoodBase(n);

            //isSuccess &= IsSame(result, checkResult);
            //PrintResult(isSuccess, (result), (checkResult));


            n = "727004545306745403";
            checkResult = "727004545306745402";
            result = SmallestGoodBase(n);

            isSuccess &= IsSame(result, checkResult);
            PrintResult(isSuccess, (result), (checkResult));
            return isSuccess;
        }

        /// <summary>
        /// 作者：nks5117
        /// 链接：https://leetcode-cn.com/problems/smallest-good-base/solution/cpp-by-nks5117/   
        /// </summary>
        /// <param name="n">n的取值范围是 [3, 10^18]</param>
        /// <returns></returns>
        //public string SmallestGoodBase1(string n)
        //{
        //    //long.MaxValue = 9223372036854775807L
        //    //                727004545306745403
        //    //                288230376151711744
        //    //                1152921504606846975
        //    //m = 59

        //    long num = long.Parse(n);
        //    Print("{0} | {1} | {2} ", Power(2, 59), num, LogFloor(2, num));

        //    for (int m = (int) Math.Log(num, 2) + 2; m >= 1; m--)
        //    {
        //        long l = 2, r = (long) Math.Pow(num, 1.0 / m) + 1, mid, sum;
        //        while (l < r)
        //        {
        //            mid = (l + r) / 2;
        //            sum = 1;
        //            for (int j = 0; j < m; ++j)
        //            {
        //                sum = sum * mid + 1;
        //            }
        //            Print("l: {0}, r: {1} | m = {2} mid= {3} sum = {4}", l, r, m, mid, sum);
        //            if (sum == num)
        //            {
        //                return ((long) mid).Tostring();
        //            }
        //            else if (sum < num)
        //            {
        //                l = mid + 1;
        //            }
        //            else
        //            {
        //                r = mid;
        //            }
        //        }
        //    }
        //    return "";
        //}
        //long Power(int baseNum, int n)
        //{
        //    long rtn = baseNum;
        //    for (int i = 1; i < n - 1; i++)
        //    {
        //        rtn *= baseNum;
        //    }
        //    return rtn;
        //}
        //long LogFloor(int baseNum, long num)
        //{
        //    long rtn = baseNum;

        //    int i = 1;
        //    while(rtn < num)
        //    {
        //        rtn *= baseNum;
        //        i++;
        //    }
        //    return i;
        //}

        //作者：jerring
        //链接：https://leetcode-cn.com/problems/smallest-good-base/solution/er-fen-cha-zhao-by-jerring-2/
        /// 106/106 cases passed(116 ms)
        /// Your runtime beats 28.57 % of csharp submissions
        /// Your memory usage beats 71.43 % of csharp submissions(23 MB)
        public string SmallestGoodBase(string n)
        {
            long num = long.Parse(n);
            for (int len = 63; len >= 2; --len)
            {
                long radix = getRadix(len, num);
                if (radix != -1)
                {
                    return(radix).ToString();
                }
            }
            return (num - 1).ToString();
        }

        private long getRadix(int len, long num)
        {
            long l = 2, r = num - 1;
            while (l < r)
            {
                ///>>>    :     无符号右移，忽略符号位，空位都以0补齐
                long mid = RightMove(l + r, 1); //long mid = l + r >>> 1;
                if (calc(mid, len) >= num) r = mid;
                else l = mid + 1;
            }
            return calc(r, len) == num ? r : -1;
        }

        /// <summary>
        /// 无符号右移, 相当于java里的 value>>>pos
        /// </summary>
        /// <param name="value"></param>
        /// <param name="pos"></param>
        /// <returns></returns>
        public int RightMove(int value, int pos)
        {
            //移动 0 位时直接返回原值
            if (pos != 0)
            {
                // int.MaxValue = 0x7FFFFFFF 整数最大值
                int mask = int.MaxValue;
                //无符号整数最高位不表示正负但操作数还是有符号的，有符号数右移1位，正数时高位补0，负数时高位补1
                value = value >> 1;
                //和整数最大值进行逻辑与运算，运算后的结果为忽略表示正负值的最高位
                value = value & mask;
                //逻辑运算后的值无符号，对无符号的值直接做右移运算，计算剩下的位
                value = value >> pos - 1;
            }

            return value;
        }

        public long RightMove(long value, int pos)
        {
            //移动 0 位时直接返回原值
            if (pos != 0)
            {
                // long.MaxValue = 0x7FFFFFFFFFFFFFFF 整数最大值
                long mask = long.MaxValue;
                //无符号整数最高位不表示正负但操作数还是有符号的，有符号数右移1位，正数时高位补0，负数时高位补1
                value = value >> 1;
                //和整数最大值进行逻辑与运算，运算后的结果为忽略表示正负值的最高位
                value = value & mask;
                //逻辑运算后的值无符号，对无符号的值直接做右移运算，计算剩下的位
                value = value >> pos - 1;
            }
            return value;
        }

        private long calc(long radix, int len)
        {
            long p = 1;
            long sum = 0;
            for (int i = 0; i < len; ++i)
            {
                if (long.MaxValue - sum < p)
                {     // 防止溢出
                    return long.MaxValue;
                }
                sum += p;
                if (long.MaxValue / p < radix)
                {   // 防止溢出
                    p = long.MaxValue;
                }
                else
                {
                    p *= radix;
                }
            }
            return sum;
        }
    }
    
}
