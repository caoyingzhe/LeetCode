using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpConsoleApp.Solutions._0300
{
    class Solution375
    {
        
        ///
        ///作者：LeetCode
        ///链接：https://leetcode-cn.com/problems/guess-number-higher-or-lower-ii/solution/cai-shu-zi-da-xiao-ii-by-leetcode/
        public int GetMoneyAmount_TLE(int n)
        {
            return Calculate(1, n);
        }

        public int Calculate(int low, int high)
        {
            if (low >= high)
                return 0;
            int minres = int.MaxValue;
            for (int i = (low + high) / 2; i <= high; i++)
            {
                int res = i + Math.Max(Calculate(i + 1, high), Calculate(low, i - 1));
                minres = Math.Min(res, minres);
            }
            return minres;
        }

        /// <summary>
        /// 方法 4：优化的 DP
        /// 27/27 cases passed (68 ms)
        /// Your runtime beats 75 % of csharp submissions
        /// Your memory usage beats 25 % of csharp submissions(16.2 MB)
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public int GetMoneyAmount(int n)
        {
            int[][] dp = new int[n + 1][];
            for (int i = 0; i < n + 1; i++) dp[i] = new int[n + 1];

            for (int len = 2; len <= n; len++)
            {
                for (int start = 1; start <= n - len + 1; start++)
                {
                    int minres = int.MaxValue;
                    for (int piv = start + (len - 1) / 2; piv < start + len - 1; piv++)
                    {
                        int res = piv + Math.Max(dp[start][piv - 1], dp[piv + 1][start + len - 1]);
                        minres = Math.Min(res, minres);
                    }
                    dp[start][start + len - 1] = minres;
                }

            }
            return dp[1][n];
        }

    }
}
