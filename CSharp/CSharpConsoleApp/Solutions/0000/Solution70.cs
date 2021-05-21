using System;
namespace CSharpConsoleApp.Solutions
{
    /*
     * @lc app=leetcode.cn id=70 lang=csharp
     *
     * [70] 爬楼梯
     *
     * https://leetcode-cn.com/problems/climbing-stairs/description/
     *
     * Category	Difficulty	Likes	Dislikes
     * algorithms	Easy (51.96%)	1653	-
     * Tags
     * dynamic-programming
     * 
     * Companies
     * adobe | apple
     * 
     * Total Accepted:    446.3K
     * Total Submissions: 858.7K
     * Testcase Example:  '2'
     *
     * 假设你正在爬楼梯。需要 n 阶你才能到达楼顶。
     * 
     * 每次你可以爬 1 或 2 个台阶。你有多少种不同的方法可以爬到楼顶呢？
     * 
     * 注意：给定 n 是一个正整数。
     * 
     * 示例 1：
     * 
     * 输入： 2
     * 输出： 2
     * 解释： 有两种方法可以爬到楼顶。
     * 1.  1 阶 + 1 阶
     * 2.  2 阶
     * 
     * 示例 2：
     * 输入： 3
     * 输出： 3
     * 解释： 有三种方法可以爬到楼顶。
     * 1.  1 阶 + 1 阶 + 1 阶
     * 2.  1 阶 + 2 阶
     * 3.  2 阶 + 1 阶
     * 
     */

    public class Solution70
    {
        public int ClimbStairs_Common(int n)
        {
            int[] dp = new int[n + 1];
            dp[0] = 1;
            dp[1] = 2;

            for(int i=2; i<= n; i++)
            {
                dp[i] = dp[i - 1] + dp[i - 2];
            }

            return dp[n];
        }

        //作者：LeetCode - Solution
        //链接：https://leetcode-cn.com/problems/climbing-stairs/solution/pa-lou-ti-by-leetcode-solution/
        public int ClimbStairs(int n)
        {
            int p, q = 0, r = 1;
            for (int i = 1; i <= n; ++i)
            {
                p = q;
                q = r;
                r = p + q;
            }
            return r;

        }
    }
}
