using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace CSharpConsoleApp.Solutions
{
    /// <summary>
    /// Your runtime beats 100 % of csharp submissions
    /// Your memory usage beats 100 % of csharp submissions(14.8 MB)
    /// </summary>
    class Solution793 : SolutionBase
    {
        /// <summary>
        /// 难易度:
        /// </summary>
        public override Difficulity GetDifficulity() { return Difficulity.Hard; }
        /// <summary>
        /// 关键字:
        /// </summary>
        public override string[] GetKeyWords() { return new string[] { "找规律", "二分法搜索" }; }
        /// <summary>
        /// 标签： 图
        /// </summary>
        public override Tag[] GetTags() { return new Tag[] { Tag.BinarySearch, Tag.Brainteaser }; }

        //深度优先搜索(DFS)和广度优先搜索(BFS).这两种算法对有向图与无向图均适用
        public override bool Test(System.Diagnostics.Stopwatch sw)
        {
            bool isSuccess = true;

            Print("Max K =" + zeta(long.MaxValue));

            int checkResult = 5;
            int result = PreimageSizeFZF(1000000000);
            //
            isSuccess &= result == checkResult;
            return isSuccess;
        }

        public int PreimageSizeFZF(int K)
        {
            long x = 0L;
            long minX = 0L;
            long maxX = zeta(long.MaxValue);
            int result = 0;

            if (K > maxX)
                return 0;

            long loop = int.MaxValue;

            long lastK = -1;
            while (loop >= 0)
            {
                loop--;

                long tmpK = zeta(x);

                //两次计算结果一样，没必要再比较，直接退出
                if (lastK == tmpK)
                    break;

                //使用2分法，逐次缩减搜索范围，减少TLE的概率。
                if (tmpK > K)
                {
                    lastK = tmpK;
                    result = 0;
                    if (maxX == x)
                    {
                        maxX -= 5;
                    }
                    else
                        maxX = x; 
                    x = (maxX + minX) / 10 * 5;
                    Print(string.Format("tmpK={0} x={1}[{2}~{3}] K={4}", tmpK, x, minX, maxX, K));
                }
                else if (tmpK < K)
                {
                    lastK = tmpK;
                    result = 0;
                    if (minX == x)
                    {
                        minX -= 5;
                    }
                    else
                        minX = x;
                    x = (maxX + minX) / 10 * 5;
                    Print(string.Format("tmpK={0} x={1}[{2}~{3}] K={4}", tmpK, x, minX, maxX, K));
                }
                else if (tmpK == K)
                {
                    x += 5;
                    result += 5;
                    break;
                }
            }

            return result;
        }

        //Time Limit Exceeded
        //Testcase : 80502705
        //Expected Answer : 0
        public int PreimageSizeFZF_TLE(int K)
        {
            int x = 0;
            long tmpK = 0;
            int result = 0;

            long maxK = zeta(long.MaxValue);
            if (K > maxK)
                return 0;

            while (true)
            {
                tmpK = zeta(x);
                Print(string.Format("tmpK={0} x={1}[{2}~{3}] K={4}", tmpK, x, x, x, K));
                if (tmpK < K)
                {
                    x += 5;
                }
                else if (tmpK == K)
                {
                    x += 5;
                    result += 5;
                }
                else
                {
                    break;
                }
            }

            return result;
        }

        public long zeta(long x)
        {
            if (x == 0)
                return 0;
            return x / 5 + zeta(x / 5);
        }
    }
}
