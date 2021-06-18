using System;
namespace CSharpConsoleApp.Solutions
{
    /*
     * @lc app=leetcode.cn id=204 lang=csharp
     *
     * [204] 计数质数
     *
     * https://leetcode-cn.com/problems/count-primes/description/
     *
     * algorithms
     * Easy (38.20%)
     * Likes:    702
     * Dislikes: 0
     * Total Accepted:    150.5K
     * Total Submissions: 394.2K
     * Testcase Example:  '10'
     *
     * 统计所有小于非负整数 n 的质数的数量。
     * 
     * 示例 1：≈
     * 输入：n = 10
     * 输出：4
     * 解释：小于 10 的质数一共有 4 个, 它们是 2, 3, 5, 7 。
     * 
     * 
     * 示例 2：≈
     * 输入：n = 0
     * 输出：0
     * 
     * 
     * 示例 3：≈
     * 输入：n = 1
     * 输出：0
     * 
     * 
     * 提示：
     * 0 <= n <= 5 * 10^6
     */

    // @lc code=start
    public class Solution204 
    {
        /// <summary>
        /// 21/21 cases passed (108 ms)
        /// Your runtime beats 70.13 % of csharp submissions
        /// Your memory usage beats 5.19 % of csharp submissions(45.1 MB)
        /// 希腊数学家厄拉多塞（\rm EratosthenesEratosthenes）提出，称为厄拉多塞筛法，简称埃氏筛。
        /// 如果 x 是质数，那么大于 x 的 x 的倍数 2x,3x,… 一定不是质数，
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public int CountPrimes(int n)
        {
            int[] isPrime = new int[n];
            int ans = 0;
            for (int i = 2; i < n; ++i)
            {
                if (isPrime[i] == 0)
                {
                    ans += 1;
                    if ((long)i * i < n)
                    {
                        for (int j = i * i; j < n; j += i)
                        {
                            isPrime[j] = 1;
                        }
                    }
                }
            }
            return ans;
        }

        /// <summary>
        /// 20/21 cases passed (N/A)
        /// Testcase : 5000000
        /// Expected Answer : 348513
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public int CountPrimes_TLE(int n)
        {
            int ans = 0;
            for (int i = 2; i < n; ++i)
            {
                ans += IsPrime(i) ? 1 : 0;
            }
            return ans;
        }

        //时间复杂度：O(n * sqrt{n}))
        //空间复杂度：O(1)
        public bool IsPrime(int x)
        {
            for (int i = 2; i * i <= x; ++i)
            {
                if (x % i == 0)
                {
                    return false;
                }
            }
            return true;
        }
    }
    // @lc code=end


}
