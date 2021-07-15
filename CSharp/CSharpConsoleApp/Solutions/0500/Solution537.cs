using System;
namespace CSharpConsoleApp.Solutions
{
    /*
     * @lc app=leetcode.cn id = 537 lang=csharp
       *
       *[537] 复数乘法
     *
     * https://leetcode-cn.com/problems/complex-number-multiplication/description/
     *
     * Category	Difficulty	Likes	Dislikes
     * algorithms	Medium (70.93%)	57	-
     * Tags
     * math | string
     * 
     * Companies
     * amazon
     * 
     * Total Accepted:    10.7K
     * Total Submissions: 15.1K
     * Testcase Example:  '"1+1i"\n"1+1i"'
     *
     * 复数 可以用字符串表示，遵循 "实部+虚部i" 的形式，并满足下述条件：
     *
     *
     * 实部 是一个整数，取值范围是[-100, 100]
     * 虚部 也是一个整数，取值范围是[-100, 100]
     * i^2 == -1
     *
     *
     * 给你两个字符串表示的复数 num1 和 num2 ，请你遵循复数表示形式，返回表示它们乘积的字符串。
     *
     *
     *
     * 示例 1：
     *
     *
     * 输入：num1 = "1+1i", num2 = "1+1i"
     * 输出："0+2i"
     * 解释：(1 + i) * (1 + i) = 1 + i2 + 2 * i = 2i ，你需要将它转换为 0+2i 的形式。
     *
     *
     * 示例 2：
     *
     *
     * 输入：num1 = "1+-1i", num2 = "1+-1i"
     * 输出："0+-2i"
     * 解释：(1 - i) * (1 - i) = 1 + i2 - 2 * i = -2i ，你需要将它转换为 0+-2i 的形式。 
     *
     *
     *
     *
     * 提示：
     *
     *
     * num1 和 num2 都是有效的复数表示。
     *
     *
     */
    public class Solution537
    {
        public string ComplexNumberMultiply(string a, string b)
        {
            string[] x = a.Remove(a.Length - 1).Split('+');
            string[] y = b.Remove(b.Length - 1).Split('+');
            int a_real = int.Parse(x[0].ToString());
            int a_img = int.Parse(x[1].ToString());
            int b_real = int.Parse(y[0].ToString());
            int b_img = int.Parse(y[1].ToString());
            return (a_real * b_real - a_img * b_img) + "+" + (a_real * b_img + a_img * b_real) + "i";
        }
    }
}
