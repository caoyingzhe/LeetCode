using System;
namespace CSharpConsoleApp.Solutions
{
    /*
 * @lc app=leetcode.cn id=344 lang=csharp
 *
 * [344] 反转字符串
 *
 * https://leetcode-cn.com/problems/reverse-string/description/
 *
 * Category	Difficulty	Likes	Dislikes
 * algorithms	Easy (75.54%)	421	-
 * Tags
 * two-pointers | string
 * 
 * Companies
 * Unknown
 * 
 * Total Accepted:    305.8K
 * Total Submissions: 404.8K
 * Testcase Example:  '["h","e","l","l","o"]'
 *
 * 编写一个函数，其作用是将输入的字符串反转过来。输入字符串以字符数组 char[] 的形式给出。
 * 
 * 不要给另外的数组分配额外的空间，你必须原地修改输入数组、使用 O(1) 的额外空间解决这一问题。
 * 
 * 你可以假设数组中的所有字符都是 ASCII 码表中的可打印字符。
 * 
 * 
 * 
 * 示例 1：
 * 
 * 输入：["h","e","l","l","o"]
 * 输出：["o","l","l","e","h"]
 * 
 * 
 * 示例 2：
 * 
 * 输入：["H","a","n","n","a","h"]
 * 输出：["h","a","n","n","a","H"]
 * 
 */

    public class Solution344
    {
        //无聊题目

        public void ReverseString(char[] s)
        {
            int n = s.Length;
            for (int L = 0, R = n - 1; L < R; ++L, --R)
            {
                char tmp = s[L];
                s[L] = s[R];
                s[R] = tmp;
            }
        }
    }
}
