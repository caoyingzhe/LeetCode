using System;
namespace CSharpConsoleApp.Solutions
{
    /*
     * @lc app=leetcode.cn id=405 lang=csharp
     *
     * [405] 数字转换为十六进制数
     *
     * https://leetcode-cn.com/problems/convert-a-number-to-hexadecimal/description/
     *
     * algorithms
     * Easy (52.32%)
     * Likes:    140
     * Dislikes: 0
     * Total Accepted:    24.3K
     * Total Submissions: 46.3K
     * Testcase Example:  '26'
     *
     * 给定一个整数，编写一个算法将这个数转换为十六进制数。对于负整数，我们通常使用 补码运算 方法。
     * 
     * 注意: 十六进制中所有字母(a-f)都必须是小写。
     * 
     * 十六进制字符串中不能包含多余的前导零。如果要转化的数为0，那么以单个字符'0'来表示；对于其他情况，十六进制字符串中的第一个字符将不会是0字符。 
     * 给定的数确保在32位有符号整数范围内。
     * 不能使用任何由库提供的将数字直接转换或格式化为十六进制的方法。
     * 
     * 
     * 示例 1：
     * 输入: 26
     * 输出:"1a"
     * 
     * 
     * 示例 2：
     * 输入:-1
     * 输出:"ffffffff"
     */

    // @lc code=start
    public class Solution405 : SolutionBase
    {
        /// <summary>
        /// 难度
        /// </summary>
        public override Difficulity GetDifficulity() { return Difficulity.Medium; }
        /// <summary>
        /// 关键字:
        /// </summary>
        public override string[] GetKeyWords() { return new string[] { "补码运算" }; }
        /// <summary>
        /// 标签：
        /// </summary>
        public override Tag[] GetTags() { return new Tag[] { Tag.BitManipulation }; }

        public int NULL = -1;
        /// <summary>
        /// </summary>
        /// <param name="sw"></param>
        /// <returns></returns>
        public override bool Test(System.Diagnostics.Stopwatch sw)
        {
            bool isSuccess = true;

            int num;
            string result, checkResult;

            num = 26;
            checkResult = "1a";
            result = ToHex(num);
            isSuccess &= IsSame(result, checkResult);
            PrintResult(isSuccess, (result), (checkResult));

            num = -1;
            checkResult = "ffffffff"; //-1 : ffffffff : 1111 1111 1111 1111 1111 1111 1111 1111
            result = ToHex(num);
            isSuccess &= IsSame(result, checkResult);
            PrintResult(isSuccess, (result), (checkResult));

            num = int.MinValue; //80000000 : MinValue : 0100 0000 0000 0000 0000 0000 0000 0000
            checkResult = "1a";
            result = ToHex(num);
            isSuccess &= IsSame(result, checkResult);
            PrintResult(isSuccess, (result), (checkResult));

            num = int.MaxValue; //7fffffff : MaxValue  : 0111 1111 1111 1111 1111 1111 1111 1111
            checkResult = "ffffffff";
            result = ToHex(num);
            isSuccess &= IsSame(result, checkResult);
            PrintResult(isSuccess, (result), (checkResult));


            return isSuccess;
        }

        void swap(char[] arr, int a, int b) { char t = arr[a]; arr[a] = arr[b]; arr[b] = t; }

        /// <summary>
        /// 作者：jiang - chun - hua
        /// 链接：https://leetcode-cn.com/problems/convert-a-number-to-hexadecimal/solution/cyu-yan-ji-bai-100-100-by-jiang-chun-hua/
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        public string ToHex2(int num)
        {
            char[] g_stack = new char[17];
            int top = -1;
            int n = num;
            char[] index = "0123456789abcdef".ToCharArray();
            // 这里用do...while()而不是while()，能直接覆盖num为0的情况
            do
            {
                g_stack[++top] = index[(n % 16 + 16) % 16];
                n /= 16;
            } while (n != 0);
            g_stack[top + 1] = '\0';

            int lo = 0, hi = top;
            while (lo < hi)
            {
                swap(g_stack, ++lo, --hi);
            }
            return new string(g_stack);
        }

        public static char[] hexChars = "0123456789abcdef".ToCharArray();
        /// <summary>
        /// 作者：cuteleon
        /// 链接：https://leetcode-cn.com/problems/convert-a-number-to-hexadecimal/solution/c-shu-zu-chong-dang-zi-dian-shi-yong-bu-ma-suan-fa/
        ///
        /// 补码运算 ：value = (uint)(~-num + 1);
        /// 使用补码算法，把负数转换为无符号整型
        /// 不转换的话，负数在>>时将以1在左侧补位，导致无限循环
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        public string ToHex(int num)
        {
            uint value = 0;
            if (num > 0)
            {
                value = (uint)num;
            }
            else if (num < 0)
            {
                // 使用补码算法，把负数转换为无符号整型
                // 不转换的话，负数在>>时将以1在左侧补位，导致无限循环
                value = (uint)(~-num + 1);
            }
            else
            {
                return "0";
            }

            System.Text.StringBuilder builder = new System.Text.StringBuilder();
            while (value != 0)
            {
                var last4Bits = value & 15;
                builder.Insert(0, hexChars[last4Bits]);
                value >>= 4;
            }
            return builder.ToString();
        }
        // @lc code=end
    }
}
