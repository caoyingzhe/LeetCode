using System;
namespace CSharpConsoleApp.Solutions
{
    /*
     * @lc app=leetcode.cn id=43 lang=csharp
     *
     * [43] 字符串相乘
     *
     * https://leetcode-cn.com/problems/multiply-strings/description/
     *
     * Category	Difficulty	Likes	Dislikes
     * algorithms	Medium (44.69%)	637	-
     * Tags
     * math | string
     * 
     * Companies
     * facebook | twitter
     * Total Accepted:    141.2K
     * Total Submissions: 315.8K
     * Testcase Example:  '"2"\n"3"'
     *
     * 给定两个以字符串形式表示的非负整数 num1 和 num2，返回 num1 和 num2 的乘积，它们的乘积也表示为字符串形式。
     * 
     * 示例 1:
     * 
     * 输入: num1 = "2", num2 = "3"
     * 输出: "6"
     * 
     * 示例 2:
     * 
     * 输入: num1 = "123", num2 = "456"
     * 输出: "56088"
     * 
     * 说明：
     * num1 和 num2 的长度小于110。
     * num1 和 num2 只包含数字 0-9。
     * num1 和 num2 均不以零开头，除非是数字 0 本身。
     * 不能使用任何标准库的大数类型（比如 BigInteger）或直接将输入转换为整数来处理。
     */
    public class Solution43 : SolutionBase
    {
        /// <summary>
        /// 难易度:
        /// </summary>
        public override Difficulity GetDifficulity() { return Difficulity.Medium; }
        /// <summary>
        /// 关键字:
        /// </summary>
        public override string[] GetKeyWords() { return new string[] {  "字符串" }; }
        /// <summary>
        /// 标签： 图
        /// </summary>
        public override Tag[] GetTags() { return new Tag[] { Tag.Math, Tag.String }; }

        public override bool Test(System.Diagnostics.Stopwatch sw)
        {
            bool isSuccess = true;
            string num1; string num2;
            string result; string checkResult;

            num1 = "2"; num2 = "3";
            result = Multiply(num1, num2);
            checkResult = "6";
            isSuccess &= result == checkResult;
            Print("isSuccess = {0} result = {1} | checkResult = {2}", isSuccess, (result), (checkResult));

            num1 = "123"; num2 = "456";
            result = Multiply(num1, num2);
            checkResult = "56088";
            isSuccess &= result == checkResult;
            Print("isSuccess = {0} result = {1} | checkResult = {2}", isSuccess, (result), (checkResult));

            return isSuccess;
        }

        /// <summary>
        /// 运行效率一般，内存还不错。
        /// 311/311 cases passed (124 ms)
        /// Your runtime beats 47.44 % of csharp submissions
        /// Your memory usage beats 96.15 % of csharp submissions(24.8 MB)
        ///  作者：LeetCode-Solution
        ///  链接：https://leetcode-cn.com/problems/multiply-strings/solution/zi-fu-chuan-xiang-cheng-by-leetcode-solution/
        /// </summary>
        /// <param name="num1"></param>
        /// <param name="num2"></param>
        /// <returns></returns>
        public string Multiply(string num1, string num2)
        {
            if (num1.Equals("0") || num2.Equals("0"))
            {
                return "0";
            }
            int m = num1.Length, n = num2.Length;
            int[] ansArr = new int[m + n];
            for (int i = m - 1; i >= 0; i--)
            {
                int x = num1[i] - '0';
                for (int j = n - 1; j >= 0; j--)
                {
                    int y = num2[j] - '0';
                    ansArr[i + j + 1] += x * y;
                }
            }
            for (int i = m + n - 1; i > 0; i--)
            {
                ansArr[i - 1] += ansArr[i] / 10;
                ansArr[i] %= 10;
            }
            int index = ansArr[0] == 0 ? 1 : 0;
            System.Text.StringBuilder ans = new System.Text.StringBuilder();
            while (index < m + n)
            {
                ans.Append(ansArr[index]);
                index++;
            }
            return ans.ToString();
        }

    }
}
