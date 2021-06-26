using System;
namespace CSharpConsoleApp.Solutions
{
    /*
     * @lc app=leetcode.cn id=479 lang=csharp
     *
     * [479] 最大回文数乘积
     *
     * https://leetcode-cn.com/problems/largest-palindrome-product/description/
     *
     * Category	Difficulty	Likes	Dislikes
     * algorithms	Hard (40.65%)	37	-
     * Tags
     * Unknown
     * 
     * Companies
     * yahoo
     * 
     * Total Accepted:    2.8K
     * Total Submissions: 6.8K
     * Testcase Example:  '2'
     *
     * 你需要找到由两个 n 位数的乘积组成的最大回文数。
     * 
     * 由于结果会很大，你只需返回最大回文数 mod 1337得到的结果。
     * 
     * 示例:
     * 输入: 2
     * 输出: 987
     * 解释: 99 x 91 = 9009, 9009 % 1337 = 987
     * 
     * 说明:
     * n 的取值范围为 [1,8]。
     * 
     */

    // @lc code=start
    public class Solution479 : SolutionBase
    {
        /// <summary>
        /// 难度
        /// </summary>
        public override Difficulity GetDifficulity() { return Difficulity.Hard; }
        /// <summary>
        /// 关键字:
        /// </summary>
        public override string[] GetKeyWords() { return new string[] { }; }
        /// <summary>
        /// 标签：
        /// </summary>
        public override Tag[] GetTags() { return new Tag[] { Tag.Unknown }; }

        /// <summary>
        /// 入度：每个课程节点的入度数量等于其先修课程的数量；
        /// 出度：每个课程节点的出度数量等于其指向的后续课程数量；
        /// 所以只有当一个课程节点的入度为零时，其才是一个可以学习的自由课程。
        ///
        /// 拓扑排序即是将一个无环有向图转换为线性排序的过程。
        /// </summary>
        /// <param name="sw"></param>
        /// <returns></returns>
        public override bool Test(System.Diagnostics.Stopwatch sw)
        {
            bool isSuccess = true;
            //TODO
            return isSuccess;
        }

        /// <summary>
        /// 8/8 cases passed (348 ms)
        /// Your runtime beats 66.67 % of csharp submissions
        /// Your memory usage beats 33.33 % of csharp submissions(18.1 MB)
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public int LargestPalindrome(int n)
        {
            if (n == 1) return 9;
            //计算给定位数的最大值
            long max = (long)Math.Pow(10, n) - 1;
            //从max - 1开始循环，原因见上文
            for (long i = max - 1; i > max / 10; i--)
            {
                //1. 构造回文数
                string s1 = i.ToString();
                char[] s1Reverse = s1.ToCharArray();
                Array.Reverse(s1Reverse);
                long rev = long.Parse(s1 + new string(s1Reverse));

                //2. 检验该回文数能否由给定的数相乘得到
                for (long x = max; x * x >= rev; x--)
                {
                    if (rev % x == 0) return (int)(rev % 1337);
                }
            }
            return -1;
        }

        /// <summary>
        /// 8/8 cases passed (44 ms)
        /// Your runtime beats 100 % of csharp submissions
        /// Your memory usage beats 100 % of csharp submissions(14.7 MB)
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public int LargestPalindrome_fast(int n)
        {
            long [] ans = new long[] { 9, 9009, 906609, 99000099, 9966006699L, 999000000999L, 99956644665999L, 9999000000009999L };
            return (int)(ans[n - 1] % 1337);
        }
    }
    // @lc code=end


}
