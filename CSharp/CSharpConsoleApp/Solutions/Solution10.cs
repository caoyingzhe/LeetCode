using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace CSharpConsoleApp.Solutions
{
    /// <summary>
    /// 给你一个字符串 s 和一个字符规律 p，请你来实现一个支持 '.' 和 '*' 的正则表达式匹配。
    /// '.' 匹配任意单个字符
    /// '*' 匹配零个或多个前面的那一个元素
    /// 所谓匹配，是要涵盖 整个 字符串 s的，而不是部分字符串。
    /// 
    /// 输入：s = "aa" p = "a"
    /// 输出：false
    /// 解释："a" 无法匹配 "aa" 整个字符串。
    /// 
    /// 输入：s = "aa" p = "a*"
    /// 输出：true
    /// 
    /// 输入：s = "ab" p = ".*"
    /// 输出：true
    /// 
    /// 输入：s = "aab" p = "c*a*b"
    /// 输出：true
    /// 
    /// 
    /// 特别声明 * 的意思
    ///     *可以代表0个， 如果出现c*, 可以代表是不存在c，或者是c,cc,ccc...的多个c的形式
    ///     题目要求完全匹配，意思就是，从头到尾，必须是一模一样的。 
    ///     所以自己的算法 (IsMatch_MySelf)只适合*代表的是一个或一个以上的前一个字符的意思。所以不能通过测试。
    ///     
    /// 视频图解   ： https://leetcode-cn.com/problems/regular-expression-matching/solution/liang-chong-shi-xian-xiang-xi-tu-jie-10-48bgj/
    /// 代码拷贝于 ： https://leetcode-cn.com/problems/regular-expression-matching/solution/shou-hui-tu-jie-wo-tai-nan-liao-by-hyj8/
    /// </summary>
    class Solution10 : SolutionBase
    {
        /// <summary>
        /// 难易度:
        /// </summary>
        public override Difficulity GetDifficulity() { return Difficulity.Hard; }
        /// <summary>
        /// 关键字:
        /// </summary>
        public override string[] GetKeyWords() { return new string[] { "" }; }
        /// <summary>
        /// 标签：
        /// </summary>
        public override Tag[] GetTags() { return new Tag[] { Tag.String, Tag.DynamicProgramming, Tag.Backtracking }; }

        public override bool Test(Stopwatch sw)
        {
            bool isSuccess = true;

            string s, p;
            bool checkresult;
            bool result;
            //s = "aa";
            //p = "a";
            //checkresult = false;
            //result = IsMatch(s, p);
            //isSuccess &= (checkresult == result);
            //Print("Anticipated = " + checkresult + " | Result = " + result);
            //
            //s = "aa";
            //p = "a*";
            //checkresult = true;
            //result = IsMatch(s, p);
            //isSuccess &= (checkresult == result);
            //Print("Anticipated = " + checkresult + " | Result = " + result);
            //
            //s = "ab";
            //p = ".*";
            //checkresult = true;
            //result = IsMatch(s, p);
            //isSuccess &= (checkresult == result);
            //Print("Anticipated = " + checkresult + " | Result = " + result);

            s = "ab";
            p = ".*c";
            checkresult = false;
            result = IsMatch(s, p);
            isSuccess &= (checkresult == result);
            Print("Anticipated = " + checkresult + " | Result = " + result);

            s = "abcd";
            p = "a.*de";
            checkresult = false;
            result = IsMatch(s, p);
            isSuccess &= (checkresult == result);
            Print("Anticipated = " + checkresult + " | Result = " + result);
            
            s = "abcde";
            p = "c*ab.de";
            checkresult = true;
            result = IsMatch(s, p);
            isSuccess &= (checkresult == result);
            Print("Anticipated = " + checkresult + " | Result = " + result);

            s = "aab";
            p = "c*a*b";
            checkresult = true;
            result = IsMatch(s, p);
            isSuccess &= (checkresult == result);
            Print("Anticipated = " + checkresult + " | Result = " + result);

            s = "mississippi";
            p = "mis*is*p*.";
            checkresult = false;
            result = IsMatch(s, p);
            isSuccess &= (checkresult == result);
            Print("Anticipated = " + checkresult + " | Result = " + result);

            s = "mississssipppppi";
            p = "mis*is*ip*.";
            checkresult = true;
            result = IsMatch(s, p);
            isSuccess &= (checkresult == result);
            Print("Anticipated = " + checkresult + " | Result = " + result);



            return isSuccess;
        }

        public bool IsMatch(String s, String p)
        {
            char[] cs = s.ToArray();
            char[] cp = p.ToArray();

            // dp[i][j]:表示s的前i个字符，p的前j个字符是否能够匹配
            bool[][] dp = new bool[cs.Length + 1][]; //cp.Length + 1
            for(int i=0; i<cs.Length+1; i++)
            {
                dp[i] = new bool[cp.Length + 1];
            }
            // 初期值
            // s为空，p为空，能匹配上
            dp[0][0] = true;
            // p为空，s不为空，必为false(bool数组默认值为false，无需处理)

            // s为空，p不为空，由于*可以匹配0个字符，所以有可能为true
            for (int j = 1; j <= cp.Length; j++)
            {
                if (cp[j - 1] == '*')
                {
                    dp[0][j] = dp[0][j - 2];
                }
            }

            // 填格子
            for (int i = 1; i <= cs.Length; i++)
            {
                for (int j = 1; j <= cp.Length; j++)
                {
                    // 文本串和模式串末位字符能匹配上
                    if (cs[i - 1] == cp[j - 1] || cp[j - 1] == '.')
                    {
                        dp[i][j] = dp[i - 1][j - 1];
                    }
                    else if (cp[j - 1] == '*')
                    { // 模式串末位是*
                      // 模式串*的前一个字符能够跟文本串的末位匹配上
                        if (cs[i - 1] == cp[j - 2] || cp[j - 2] == '.')
                        {
                            dp[i][j] = dp[i][j - 2]      // *匹配0次的情况
                                    || dp[i - 1][j];     // *匹配1次或多次的情况
                        }
                        else
                        { // 模式串*的前一个字符不能够跟文本串的末位匹配
                            dp[i][j] = dp[i][j - 2];     // *只能匹配0次
                        }
                    }
                }
            }
            return dp[cs.Length][cp.Length];
        }

        public bool IsMatch_MySelf(string s, string p)
        {
            bool result = false;
            char[] pArr = p.ToArray();

            int matchStartIndex = -1;
            int matchCount = 0;
            for(int i=0; i< pArr.Length; i++)
            {
                if(i> 0 && pArr[i] == '*')
                {
                    pArr[i] = pArr[i - 1];
                }
                if (matchStartIndex == -1 && (pArr[i] == s[0] || pArr[i] == '.'))
                {
                    matchStartIndex = i;
                    matchCount++;

                    while (matchCount < s.Length && s[matchCount - 1] == s[matchCount] && p[i] == '*')
                    {
                        matchCount++;
                    }
                }
                else if (matchStartIndex != -1)
                {
                    if((pArr[i] == s[matchCount] || pArr[i] == '.'))
                    {
                        matchCount++;

                        while (matchCount < s.Length && s[matchCount - 1] == s[matchCount] && p[i] == '*')
                        {
                            matchCount++;
                        }
                    }
                    else
                    {
                        matchStartIndex = -1;
                        matchCount = 0;
                    }
                }
                else
                {
                    matchStartIndex = -1;
                    matchCount = 0;
                }

                if (matchCount == s.Length)
                {
                    result = true;
                    Print("match start index = " + matchStartIndex);
                    break;
                }
            }
            return result;
        }
    }
}
