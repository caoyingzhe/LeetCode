using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpConsoleApp.Solutions
{
    /// <summary>
    ///  [231] 2的幂
    /// </summary>
    class Solution231 : SolutionBase
    {
        public override bool Test(System.Diagnostics.Stopwatch sw)
        {
            bool isSuccess = true;

            //System.Diagnostics.Debug.Assert(IsPowerOfTwo(1) == true);
            //System.Diagnostics.Debug.Assert(IsPowerOfTwo(2) == true);
            //System.Diagnostics.Debug.Assert(IsPowerOfTwo(3) == false);
            //System.Diagnostics.Debug.Assert(IsPowerOfTwo(4096) == true);
            System.Diagnostics.Debug.Assert(IsPowerOfTwo(8192) == true);
            //System.Diagnostics.Debug.Assert(IsPowerOfTwo((int)Math.Pow(2, 30) + 1) == false);
            //System.Diagnostics.Debug.Assert(IsPowerOfTwo((int)Math.Pow(2,30) + 2) == false);
            //System.Diagnostics.Debug.Assert(IsPowerOfTwo((int)Math.Pow(2, 32)) == true);
            //System.Diagnostics.Debug.Assert(IsPowerOfTwo(int.MaxValue) == false);

            return isSuccess;
        }

        /// <summary>
        ///  2的幂次意味着只有一个数位为1，另外考虑到是有符号整数，需要去掉一位符号位。
        ///  一共只有31种情况
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public bool isPowerOfTwoSimple(int n)
        {
            int tmp = 1;
            for (int i = 0; i < 31; i++)
            {
                if (tmp == n)
                {
                    return true;
                }
                tmp <<= 1;
            }
            return false;
        }

        /// <summary>
        /// 快速幂运算 
        /// 时间复杂度为 O(logN)
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public bool IsPowerOfTwo(int n)
        {
            if (n == 0) return false;
            while (n % 2 == 0)
                n /= 2;
            return n == 1;

        }

        /// <summary>
        /// 位运算解决
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public bool IsPowerOfTwoQuick(int n)
        {
            if (n == 0) return false;
            long x = (long)n;
            return (x & (-x)) == x;
        }
        /// <summary>
        /// 位运算解决2
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public bool IsPowerOfTwoQuick2(int n)
        {
            if (n == 0) return false;
            long x = (long)n;
            return (x & (x - 1)) == 0;
        }
    }
}
