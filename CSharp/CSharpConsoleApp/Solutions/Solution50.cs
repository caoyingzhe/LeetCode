using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpConsoleApp.Solutions
{
    class Solution50 : SolutionBase
    {
        /// <summary>
        /// 难度 
        /// </summary>
        public override Difficulity GetDifficulity() { return Difficulity.Hard; }
        /// <summary>
        /// 关键字:
        /// </summary>
        public override string[] GetKeyWords() { return new string[] { "DynamicProgramming", "Backtracking", "Greedy" }; }
        /// <summary>
        /// 标签： 
        /// </summary>
        public override Tag[] GetTags() { return new Tag[] { Tag.String, Tag.DynamicProgramming, Tag.Backtracking, Tag.Greedy }; }
        public override bool Test(System.Diagnostics.Stopwatch sw)
        {
            bool isSuccess = true;

            double x;
            int n;

            double checkresult;
            double result;

            x = 2.00000; n = 10; checkresult = 1024.00000;
            result = MyPow(x, n);
            isSuccess &= checkresult == result;

            return isSuccess;
        }

        /// <summary>
        /// 利用2进制特性分解各个幂的组合
        /// 77 = 1+4+8+64，恰好就对应了 77 的二进制表示(1001101)中的每个 1！
        /// </summary>
        /// <param name="x"></param>
        /// <param name="n"></param>
        /// <returns></returns>
        public double MyPow(double x, int n)
        {
            long N = n;
            return N >= 0 ? quickMul(x, N) : 1.0 / quickMul(x, -N);
        }

        public double quickMul(double x, long N)
        {
            double ans = 1.0;
            // 贡献的初始值为 x
            double x_contribute = x;
            // 在对 N 进行二进制拆分的同时计算答案
            while (N > 0)
            {
                if (N % 2 == 1)
                {
                    // 如果 N 二进制表示的最低位为 1，那么需要计入贡献
                    ans *= x_contribute;
                }
                // 将贡献不断地平方
                x_contribute *= x_contribute;
                // 舍弃 N 二进制表示的最低位，这样我们每次只要判断最低位即可
                N /= 2;
            }
            return ans;
        }
    }
}
