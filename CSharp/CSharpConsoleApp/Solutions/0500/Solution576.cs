using System;
namespace CSharpConsoleApp.Solutions
{
    /*
     * @lc app=leetcode.cn id=576 lang=csharp
     *
     * [576] 出界的路径数
     *
     * https://leetcode-cn.com/problems/out-of-boundary-paths/description/
     *
     * algorithms
     * Medium (38.65%)
     * Likes:    121
     * Dislikes: 0
     * Total Accepted:    7.9K
     * Total Submissions: 20.4K
     * Testcase Example:  '2\n2\n2\n0\n0'
     *
     * 给定一个 m × n 的网格和一个球。球的起始坐标为 (i,j)
     * ，你可以将球移到相邻的单元格内，或者往上、下、左、右四个方向上移动使球穿过网格边界。但是，你最多可以移动 N
     * 次。找出可以将球移出边界的路径数量。答案可能非常大，返回 结果 mod 10^9 + 7 的值。
     * 
     * 示例 1：
     * 输入: m = 2, n = 2, N = 2, i = 0, j = 0
     * 输出: 6
     * 解释: 
     * 
     * 示例 2：
     * 输入: m = 1, n = 3, N = 3, i = 0, j = 1
     * 输出: 12
     * 解释:
     * 
     * 说明:
     * 球一旦出界，就不能再被移动回网格内。
     * 网格的长度和高度在 [1,50] 的范围内。
     * N 在 [0,50] 的范围内。
     * 
     */
    public class Solution576 : SolutionBase
    {
        public override bool Test(System.Diagnostics.Stopwatch sw)
        {
            bool isSuccess = true;
            int m, n, N, i, j;
            int result;
            int checkResult;

            m = 2; n = 2; N = 2; i = 0; j = 0;
            checkResult = 6;
            result = FindPaths(m,n,N,i,j);
            isSuccess &= result == checkResult;
            Print("isSuccess = {0} | result = {1} | anticipated = {2}", isSuccess, (result), (checkResult));

            return isSuccess;
        }
        long[,,] dp;
        int m, n, limit;
        const int mod = 1000000007;
        /// <summary>
        /// 94/94 cases passed (196 ms)
        /// Your runtime beats 16.67 % of csharp submissions
        /// Your memory usage beats 16.67 % of csharp submissions(32.4 MB)
        /// 
        /// 作者：dreamy-dd
        /// 链接：https://leetcode-cn.com/problems/out-of-boundary-paths/solution/dfs-8ms-by-dreamy-dd-xt9w/
        /// </summary>
        /// <param name="_m"></param>
        /// <param name="_n"></param>
        /// <param name="N"></param>
        /// <param name="i"></param>
        /// <param name="j"></param>
        /// <returns></returns>
        //int findPaths(int _m, int _n, int N, int i, int j)
        public int FindPaths(int pm, int pn, int maxMove, int startRow, int startColumn)
        {
            dp = new long[55, 55, 55];
            for (int i = 0; i < 55; i++)
                for (int j = 0; j < 55; j++)
                    for (int k = 0; k < 55; k++)
                        dp[i, j, k] = -1;
            m = pm;
            n = pn;
            limit = maxMove;
            return (int) DFS(startRow, startColumn, 0);
        }
        long DFS(int x, int y, int s)
        {
            if (s > limit)   // 大于移动次数，方案不可行
                return 0;
            if (x < 0 || y < 0 || x >= m || y >= n) // 超出边界范围，达成目标条件
                return 1;
            if (dp[x,y,s] != -1) // 状态已经计算过了，不需要重复计算
                return dp[x,y,s];
            // 计算上、下、左、右各个方向寻找出界道路的次数，并保存状态
            return dp[x,y,s] = (DFS(x + 1, y, s + 1) + DFS(x - 1, y, s + 1) + DFS(x, y + 1, s + 1) + DFS(x, y - 1, s + 1)) % mod;
        }
    }
}
