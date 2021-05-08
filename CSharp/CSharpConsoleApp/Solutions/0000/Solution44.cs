using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpConsoleApp.Solutions
{
    /// <summary>
    /// 通配符匹配
    /// '?' 可以匹配任何单个字符。
    /// '*' 可以匹配任意字符串（包括空字符串）。
    /// 
    /// 关联问题：[10] 正则表达式匹配
    /// </summary>
    class Solution44 : SolutionBase
    {
        /// <summary>
        /// 难度 
        /// </summary>
        public override Difficulity GetDifficulity() { return Difficulity.Hard; }
        /// <summary>
        /// 关键字:
        /// </summary>
        public override string[] GetKeyWords() { return new string[] { "DynamicProgramming", "Backtracking", "Greedy" }; }
        /// <summary>
        /// 标签： 
        /// </summary>
        public override Tag[] GetTags() { return new Tag[] { Tag.String, Tag.DynamicProgramming, Tag.Backtracking, Tag.Greedy }; }
        public override bool Test(System.Diagnostics.Stopwatch sw)
        {
            bool isSuccess = true;

            string s, p;
            bool checkresult;
            bool result;
            s = "aa";
            p = "a";
            checkresult = false;
            result = IsMatch(s, p);
            isSuccess &= (checkresult == result);
            Print("Anticipated = " + checkresult + " | Result = " + result);
            //
            s = "aa";
            p = "*";
            checkresult = true;
            result = IsMatch(s, p);
            isSuccess &= (checkresult == result);
            Print("Anticipated = " + checkresult + " | Result = " + result);
            //
            s = "cb";
            p = "?a";
            checkresult = false;
            result = IsMatch(s, p);
            isSuccess &= (checkresult == result);
            Print("Anticipated = " + checkresult + " | Result = " + result);

            s = "adceb";
            p = "*a*b";
            checkresult = true;
            result = IsMatch(s, p);
            isSuccess &= (checkresult == result);
            Print("Anticipated = " + checkresult + " | Result = " + result);
            
            s = "aab";
            p = "c*a*b";
            checkresult = false;
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
            for (int i = 0; i < cs.Length + 1; i++)
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
                    //For Solution [10]
                    //dp[0][j] = dp[0][j - 2];

                    //For Solution [44]
                    dp[0][j] = true;
                }
                //For Solution [44] only
                //Test case : "aab"  "c*a*b"  false
                else
                {
                    break;
                }
            }

            // 填格子
            for (int i = 1; i <= cs.Length; i++)
            {
                for (int j = 1; j <= cp.Length; j++)
                {
                    // 文本串和模式串末位字符能匹配上
                    if (cs[i - 1] == cp[j - 1] || cp[j - 1] == '?')
                    {
                        dp[i][j] = dp[i - 1][j - 1];
                    }
                    else if (cp[j - 1] == '*')
                    { // 模式串末位是*
                      // 模式串*的前一个字符能够跟文本串的末位匹配上

                        //For Solution [10]
                        //if (cs[i - 1] == cp[j - 2] || cp[j - 2] == '?')
                        //{
                        //    dp[i][j] = dp[i][j - 2]      // *匹配0次的情况
                        //            || dp[i - 1][j];     // *匹配1次或多次的情况
                        //}
                        //else
                        //{ // 模式串*的前一个字符不能够跟文本串的末位匹配
                        //    dp[i][j] = dp[i][j - 2];     // *只能匹配0次
                        //}

                        //For Solution [44]
                        dp[i][j] = dp[i][j - 1] || dp[i - 1][j];
                    }
                }
            }
            return dp[cs.Length][cp.Length];
        }
    }
}
