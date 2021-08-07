using System;
namespace CSharpConsoleApp.Solutions
{
    /*
     * @lc app=leetcode.cn id=263 lang=csharp
     *
     * [263] 丑数
     *
     * https://leetcode-cn.com/problems/ugly-number/description/
     *
     * algorithms
     * Easy (51.48%)
     * Likes:    263
     * Dislikes: 0
     * Total Accepted:    98.4K
     * Total Submissions: 191.1K
     * Testcase Example:  '6'
     *
     * 给你一个整数 n ，请你判断 n 是否为 丑数 。如果是，返回 true ；否则，返回 false 。
     * 丑数 就是只包含质因数 2、3 和/或 5 的正整数。
     * 
     * 
     * 示例 1：
     * 输入：n = 6
     * 输出：true
     * 解释：6 = 2 × 3
     * 
     * 示例 2：
     * 输入：n = 8
     * 输出：true
     * 解释：8 = 2 × 2 × 2
     * 
     * 
     * 示例 3：
     * 输入：n = 14
     * 输出：false
     * 解释：14 不是丑数，因为它包含了另外一个质因数 7 。
     * 
     * 
     * 示例 4：
     * 输入：n = 1
     * 输出：true
     * 解释：1 通常被视为丑数。
     * 
     * 
     * 提示：
     * -2^31 <= n <= 2^31 - 1
     */

    // @lc code=start
    public class Solution263 : SolutionBase
    {
        /// <summary>
        /// 难度
        /// </summary>
        public override Difficulity GetDifficulity() { return Difficulity.Easy; }
        /// <summary>
        /// 关键字:
        /// </summary>
        public override string[] GetKeyWords() { return new string[] { "" }; }
        /// <summary>
        /// 标签：
        /// </summary>
        public override Tag[] GetTags() { return new Tag[] { Tag.Tree, }; }

        public override bool Test(System.Diagnostics.Stopwatch sw)
        {
            bool isSuccess = true;
            bool result, checkResult;
            int root;

            root = 1; checkResult = true;
            result = IsUgly(root);
            isSuccess &= IsSame(result, checkResult);
            PrintResult(isSuccess, (result), (checkResult));

            root = 8; checkResult = true;
            result = IsUgly(root);
            isSuccess &= IsSame(result, checkResult);
            PrintResult(isSuccess, (result), (checkResult));

            root = 14; checkResult = false;
            result = IsUgly(root);
            isSuccess &= IsSame(result, checkResult);
            PrintResult(isSuccess, (result), (checkResult));

            root = 16; checkResult = true;
            result = IsUgly(root);
            isSuccess &= IsSame(result, checkResult);
            PrintResult(isSuccess, (result), (checkResult));

            root = 400; checkResult = true;
            result = IsUgly(root);
            isSuccess &= IsSame(result, checkResult);
            PrintResult(isSuccess, (result), (checkResult));

            root = 2700; checkResult = true;
            result = IsUgly(root);
            isSuccess &= IsSame(result, checkResult);
            PrintResult(isSuccess, (result), (checkResult));

            root = int.MinValue; checkResult = false;
            result = IsUgly(root);
            isSuccess &= IsSame(result, checkResult);
            PrintResult(isSuccess, (result), (checkResult));

            return isSuccess;
        }

        /// <summary>
        ///  丑数 就是只包含质因数 2、3 和/或 5 的正整数。
        ///  1013/1013 cases passed (36 ms)
        ///  Your runtime beats 100 % of csharp submissions
        ///  Your memory usage beats 6.58 % of csharp submissions(15.1 MB)
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        int val = 0;
        public bool IsUgly(int n)
        {
            if (n <= 0) return false;
            if (n == 1) return true;

            val = n;
            while (val > 1)
            {
                if (val % 2 == 0)
                    val = val >> 1;
                else if (val % 3 == 0)
                    val /= 3;
                else if (val % 5 == 0)
                    val /= 5;
                else
                    return false;
            }
            return true;
        }

        /// <summary>
        /// 1013/1013 cases passed (48 ms)
        /// Your runtime beats 64.14 % of csharp submissions
        /// Your memory usage beats 5.92 % of csharp submissions(15.1 MB)
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public bool IsUgly2(int n)
        {
            if (n <= 0) return false;
            if (n == 1) return true;

            while (n > 1)
            {
                if (n % 2 == 0)
                    n = n >> 1;
                else if (n % 3 == 0)
                    n /= 3;
                else if (n % 5 == 0)
                    n /= 5;
                else
                    return false;
            }
            return true;
        }
    }
    // @lc code=end


}
