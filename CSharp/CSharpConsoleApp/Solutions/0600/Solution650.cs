using System;
namespace CSharpConsoleApp.Solutions
{
    /*
         * @lc app=leetcode.cn id=650 lang=csharp
         *
         * [650] 只有两个键的键盘
         *
         * https://leetcode-cn.com/problems/2-keys-keyboard/description/
         *
         
         * Category	Difficulty	Likes	Dislikes
         * algorithms	Medium (52.93%)	295	-
         * Tags
         * dynamic-programming
         * 
         * Companies
         * microsoft
         * Total Accepted:    23.7K
         * Total Submissions: 44.7K
         * Testcase Example:  '3'
         *
         * 最初在一个记事本上只有一个字符 'A'。你每次可以对这个记事本进行两种操作：
         * 
         * 
         * Copy All (复制全部) : 你可以复制这个记事本中的所有字符(部分的复制是不允许的)。
         * Paste (粘贴) : 你可以粘贴你上一次复制的字符。
         * 
         * 给定一个数字 n 。你需要使用最少的操作次数，在记事本中打印出恰好 n 个 'A'。输出能够打印出 n 个 'A' 的最少操作次数。
         * 
         * 示例 1:
         * 输入: 3
         * 输出: 3
         * 解释:
         * 最初, 我们只有一个字符 'A'。
         * 第 1 步, 我们使用 Copy All 操作。
         * 第 2 步, 我们使用 Paste 操作来获得 'AA'。
         * 第 3 步, 我们使用 Paste 操作来获得 'AAA'。
         * 
         * 
         * 说明:
         * n 的取值范围是 [1, 1000] 。
         */

    // @lc code=start
    public class Solution650 : SolutionBase
    {
        /// <summary>
        /// 难度
        /// </summary>
        public override Difficulity GetDifficulity() { return Difficulity.Medium; }
        /// <summary>
        /// 关键字:
        /// </summary>
        public override string[] GetKeyWords() { return new string[] { "素数分解问题" }; }
        /// <summary>
        /// 标签：
        /// </summary>
        public override Tag[] GetTags() { return new Tag[] { Tag.Math, Tag.DynamicProgramming }; }

        public override bool Test(System.Diagnostics.Stopwatch sw)
        {
            bool isSuccess = true;
            int result, checkResult;
            int n;

            n = 13;
            checkResult = 13;
            result = MinSteps(n);
            isSuccess &= IsSame(result, checkResult);
            PrintResult(isSuccess, result, checkResult);

            n = 14;          //14 = 7*2
            checkResult = 9; //9= 7+2
            result = MinSteps(n);
            isSuccess &= IsSame(result, checkResult);
            PrintResult(isSuccess, result, checkResult);

            return isSuccess;
        }

        /// <summary>
        /// 作者：LeetCode
        /// 链接：https://leetcode-cn.com/problems/2-keys-keyboard/solution/zhi-you-liang-ge-jian-de-jian-pan-by-leetcode/
        /// 126/126 cases passed (32 ms)
        /// Your runtime beats 100 % of csharp submissions
        /// Your memory usage beats 92.16 % of csharp submissions(14.8 MB)
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public int MinSteps(int n)
        {
            int ans = 0, d = 2;
            while (n > 1)
            {
                while (n % d == 0)
                {
                    ans += d;
                    n /= d;
                }
                d++;
            }
            return ans;
        }
    }
    // @lc code=end


}
