using System;
namespace CSharpConsoleApp.Solutions
{
    /*
     * @lc app=leetcode.cn id=415 lang=csharp
     *
     * [415] 字符串相加
     *
     * https://leetcode-cn.com/problems/add-strings/description/
     *
     * Category	Difficulty	Likes	Dislikes
     * algorithms	Easy (52.85%)	381	-
     * Tags
     * string
     * 
     * Companies
     * airbnb | google
     * 
     * Total Accepted:    120.5K
     * Total Submissions: 228K
     * Testcase Example:  '"11"\n"123"'
     *
     * 给定两个字符串形式的非负整数 num1 和num2 ，计算它们的和。
     * 
     * 提示：
     * num1 和num2 的长度都小于 5100
     * num1 和num2 都只包含数字 0-9
     * num1 和num2 都不包含任何前导零
     * 你不能使用任何內建 BigInteger 库， 也不能直接将输入的字符串转换为整数形式
     * 
     * 
     */
    public class Solution415
    {
        /// <summary>
        /// 317/317 cases passed (108 ms)
        /// Your runtime beats 77.06 % of csharp submissions
        /// Your memory usage beats 83.49 % of csharp submissions(25.6 MB)
        /// </summary>
        /// <param name="num1"></param>
        /// <param name="num2"></param>
        /// <returns></returns>
        public string AddStrings(string num1, string num2)
        {
            int i = num1.Length - 1, j = num2.Length - 1;
            int add = 0; //进位，1代表进位，0代表无进位

            System.Text.StringBuilder ans = new System.Text.StringBuilder();

            while (i >= 0 || j >= 0 || add != 0)
            {
                int x = i >= 0 ? num1[i] - '0' : 0;
                int y = j >= 0 ? num2[j] - '0' : 0;
                int result = x + y + add;
                ans.Insert(0, result % 10); //使用Insert(0, val)，免除后面的翻转处理。
                add = result / 10;
                i--;
                j--;
            }
            return ans.ToString();
        }
    }
}
