using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpConsoleApp.Solutions._0000
{

    /*
     * @lc app=leetcode.cn id=28 lang=csharp
     *
     * [28] 实现 strStr()
     *
     * https://leetcode-cn.com/problems/implement-strstr/description/
     *
     * algorithms
     * Easy (39.72%)
     * Likes:    771
     * Dislikes: 0
     * Total Accepted:    326K
     * Total Submissions: 820.8K
     * Testcase Example:  '"hello"\n"ll"'
     *
     * 实现 strStr() 函数。
     * 
     * 给定一个 haystack 字符串和一个 needle 字符串，在 haystack 字符串中找出 needle 字符串出现的第一个位置
     * (从0开始)。如果不存在，则返回  -1。
     * 
     * 示例 1:
     * 
     * 输入: haystack = "hello", needle = "ll"
     * 输出: 2
     * 
     * 
     * 示例 2:
     * 
     * 输入: haystack = "aaaaa", needle = "bba"
     * 输出: -1
     * 
     * 
     * 说明:
     * 
     * 当 needle 是空字符串时，我们应当返回什么值呢？这是一个在面试中很好的问题。
     * 
     * 对于本题而言，当 needle 是空字符串时我们应当返回 0 。这与C语言的 strstr() 以及 Java的 indexOf() 定义相符。
     * 
     */
    class Solution28 : SolutionBase
    {
        public override bool Test(System.Diagnostics.Stopwatch sw)
        {
            bool isSuccess = true;
            string haystack;
            string needle;
            int result;
            int checkResult;

            haystack = "hello"; needle = "ll";
            checkResult = 2;
            result = StrStr(haystack, needle);
            isSuccess &= result == checkResult;
            Print("isSuccess = {0} | result = {1} | anticipated = {2}", isSuccess, result, checkResult);

            haystack = "mississippi"; needle = "issip";
            checkResult = 4;
            result = StrStr(haystack,needle);
            isSuccess &= result == checkResult;
            Print("isSuccess = {0} | result = {1} | anticipated = {2}", isSuccess,result, checkResult);
        
            return isSuccess;
        }
        public int StrStr(string haystack, string needle)
        {
            if (string.IsNullOrEmpty(needle))
                return 0;
            if (string.IsNullOrEmpty(haystack))
                return -1;

            int hn = haystack.Length;
            int nn = needle.Length;

            int hi = 0;
            int ni = 0;

            int hiStart = 0;
            while(hi < hn)
            {
                if(haystack[hi] == needle[ni])
                {
                    if (ni == 0)
                        hiStart = hi;

                    if (ni == nn - 1)
                        return hi-ni;
                    else
                    {
                        hi++;
                        ni++;
                    }
                }
                else
                {
                    
                    if (ni > 0)
                        hi = hiStart+1;
                    else
                        hi++;

                    ni = 0;
                }
            }
            return -1;
        }
    }
}
