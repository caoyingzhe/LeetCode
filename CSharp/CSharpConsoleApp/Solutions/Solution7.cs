
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpConsoleApp.Solutions
{
    /*
    * @lc app=leetcode.cn id=7 lang=csharp
    * 
    * [7] 整数反转
    * 
    * https://leetcode-cn.com/problems/reverse-integer/description/
    *
    * Category	Difficulty	Likes	Dislikes
    * algorithms	Easy (35.00%)	2648	-
    * Tags
    * math
    * 
    * Companies
    * apple | bloomberg
    * 
    * Total Accepted:    631.6K
    * Total Submissions: 1.8M
    * Testcase Example:  '123'
    * 给你一个 32 位的有符号整数 x ，返回将 x 中的数字部分反转后的结果。
    * 
    * 如果反转后整数超过 32 位的有符号整数的范围 [−2^31,  2^31 − 1] ，就返回 0。
    * 假设环境不允许存储 64 位整数（有符号或无符号）。
    * 
    * 
    * 示例 1：
    * 输入：x = 123
    * 输出：321
    * 
    * 示例 2：
    * 输入：x = -123
    * 输出：-321
    * 
    * 示例 3：
    * 输入：x = 120
    * 输出：21
    * 
    * 示例 4：
    * 输入：x = 0
    * 输出：0
    * 
    * 提示：
    * -2^31 <= x <= 2^31 - 1
    */
    class Solution7
    {
        public int Reverse(int x)
        {
            string s = new string(x.ToString().Reverse<char>().ToArray());
            if (x < 0)
                s = "-" +  s.Substring(0, s.Length - 1);

            int result;
            if(int.TryParse(s, out result))
            {
                return result;
            }
            return 0;
        }
    }
}
