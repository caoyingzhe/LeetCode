
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpConsoleApp.Solutions
{
    /*
     * @lc app=leetcode.cn id=9 lang=csharp
     *
     * [9] 回文数
     *
     * https://leetcode-cn.com/problems/palindrome-number/description/
     *
     * Category	Difficulty	Likes	Dislikes
     * algorithms	Easy (58.63%)	1491	-
     * Tags
     * math
     * 
     * Companies
     * Unknown
     * Total Accepted:    640.8K
     * Total Submissions: 1.1M
     * Testcase Example:  '121'
     *
     * 给你一个整数 x ，如果 x 是一个回文整数，返回 true ；否则，返回 false 。
     * 
     * 回文数是指正序（从左向右）和倒序（从右向左）读都是一样的整数。例如，121 是回文，而 123 不是。
     * 
     * 示例 1：
     * 输入：x = 121
     * 输出：true
     * 
     * 示例 2：
     * 输入：x = -121
     * 输出：false
     * 解释：从左向右读, 为 -121 。 从右向左读, 为 121- 。因此它不是一个回文数。
     * 
     * 示例 3：
     * 输入：x = 10
     * 输出：false
     * 解释：从右向左读, 为 01 。因此它不是一个回文数。
     * 
     * 示例 4：
     * 输入：x = -101
     * 输出：false
     * 
     * 提示：
     * -2^31 <= x <= 2^31  - 1
     * 
     * 进阶：你能不将整数转为字符串来解决这个问题吗？
     * 
     */
    class Solution9
    {
        /// <summary>
        /// 回文数  
        /// 
        /// 参考了自己写的Solution5的代码
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public bool IsPalindrome(int x)
        {
            if (x < 0)
                return false;

            string s = new string(x.ToString().Reverse<char>().ToArray());

            int n = s.Length; int hn = n / 2;
            bool isEven = n % 2 == 0;
            //从中间开始比较左右两侧
            for (int i = 1; i <= hn; i++)
            {
                int L = hn - i;
                int R = isEven ? hn + i - 1 : hn + i;  //根据奇偶获取右侧比较值的索引
                if (s[L] != s[R])  // n = 4, hn=2, hn-1 = 1; hn+1-1 = 2; i =0, s[1] == s[2] / i = 1, s[0] == s[3] 
                    return false;
            }
            return true;
        }

    }
}
