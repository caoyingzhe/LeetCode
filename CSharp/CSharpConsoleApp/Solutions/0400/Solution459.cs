using System;
using System.Collections.Generic;
namespace CSharpConsoleApp.Solutions
{
    /*
     * @lc app=leetcode.cn id=459 lang=csharp
     *
     * [459] 重复的子字符串
     *
     * https://leetcode-cn.com/problems/repeated-substring-pattern/description/
     *
     * algorithms
     * Easy (51.10%)
     * Likes:    499
     * Dislikes: 0
     * Total Accepted:    70.6K
     * Total Submissions: 138K
     * Testcase Example:  '"abab"'
     *
     * 给定一个非空的字符串，判断它是否可以由它的一个子串重复多次构成。给定的字符串只含有小写英文字母，并且长度不超过10000。
     * 
     * 示例 1:
     * 
     * 
     * 输入: "abab"
     * 
     * 输出: True
     * 
     * 解释: 可由子字符串 "ab" 重复两次构成。
     * 
     * 
     * 示例 2:
     * 
     * 
     * 输入: "aba"
     * 
     * 输出: False
     * 
     * 
     * 示例 3:
     * 
     * 
     * 输入: "abcabcabcabc"
     * 
     * 输出: True
     * 
     * 解释: 可由子字符串 "abc" 重复四次构成。 (或者子字符串 "abcabc" 重复两次构成。)
     * 
     * 
     */
    public class Solution459 : SolutionBase
    {
        /// <summary>
        /// 难度
        /// </summary>
        public override Difficulity GetDifficulity() { return Difficulity.Easy; }
        /// <summary>
        /// 关键字:
        /// </summary>
        public override string[] GetKeyWords() { return new string[] { "KMP算法", "" }; }
        /// <summary>
        /// 标签：
        /// </summary>
        public override Tag[] GetTags() { return new Tag[] { Tag.String }; }

        public override bool Test(System.Diagnostics.Stopwatch sw)
        {
            bool isSuccess = true;
            string nums;
            bool result, checkResult;

            nums = "abcdabcabcdabc";
            checkResult = true;
            result = RepeatedSubstringPattern(nums);
            isSuccess &= checkResult == result;
            Print("isSuccess = {0} | result = {1} | anticipated = {2}", isSuccess, (result), (checkResult));
            //

            nums = "abac";
            checkResult = false;
            result = RepeatedSubstringPattern(nums);
            isSuccess &= checkResult == result;
            Print("isSuccess = {0} | result = {1} | anticipated = {2}", isSuccess, (result), (checkResult));
            //

            nums = "bb";
            checkResult = true;
            result = RepeatedSubstringPattern(nums);
            isSuccess &= checkResult == result;
            Print("isSuccess = {0} | result = {1} | anticipated = {2}", isSuccess, (result), (checkResult));
            //

            nums = "a";
            checkResult = false;
            result = RepeatedSubstringPattern(nums);
            isSuccess &= checkResult == result;
            Print("isSuccess = {0} | result = {1} | anticipated = {2}", isSuccess, (result), (checkResult));
            //

            nums = "aba";
            checkResult = false;
            result = RepeatedSubstringPattern(nums);
            isSuccess &= checkResult == result;
            Print("isSuccess = {0} | result = {1} | anticipated = {2}", isSuccess, (result), (checkResult));
            // 
            return isSuccess;
        }

        public bool RepeatedSubstringPattern(string s)
        {
            return RepeatedSubstringPattern_KMP(s);
            return RepeatedSubstringPattern_Factorization(s);
            return RepeatedSubstringPattern_DoubleString(s); //NG
        }

        /// <summary>
        /// 双倍字符法 TODO
        /// 86/128 cases passed (N/A)
        /// TestCase："aba"
        /// Expected Answer ：false
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public bool RepeatedSubstringPattern_DoubleString(string s)
        {
            return (s + s).Substring(1, s.Length * 2 - 1).Contains(s);
        }


        /// <summary>
        /// KMP 算法利用已匹配部分中的 前缀 和 后缀 来进行下一次的匹配
        /// 如果匹配不成功也不是从头重新开始，而是回到匹配过的 前缀 的下一位置开始
        /// 作者：hk27xing
        /// 链接：https://leetcode-cn.com/problems/repeated-substring-pattern/solution/java-kmp-jie-fa-by-hk27xing-mr0j/
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public bool RepeatedSubstringPattern_KMP(String s)
        {
            if (s.Equals("")) return false;

            int len = s.Length;
            // 原串加个空格，使下标从1开始
            s = " " + s;
            char[] chars = s.ToCharArray();
            int[] next = new int[len + 1];

            // 构造 next 数组过程，j 从0开始(空格)，i 从2开始
            for (int i = 2, j = 0; i <= len; i++)
            {
                // 匹配不成功，j 回到前一位置 next 数组所对应的值
                while (j > 0 && chars[i] != chars[j + 1])
                    j = next[j];
                // 匹配成功，j 往后移
                if (chars[i] == chars[j + 1])
                    j++;
                // 更新 next 数组的值
                next[i] = j;
                Print("i= {0} | next ={1}", GetArrayStr(next), len - next[len]);
            }
            // 最后判断是否是重复的子字符串
            if (next[len] > 0 && len % (len - next[len]) == 0)
            {
                Print("next ={0} | len - next[len] = {1} ", GetArrayStr(next), len - next[len]);
                return true;
            }
            return false;
        }

        /// <summary>
        /// 因式分解法
        /// 128/128 cases passed (204 ms)
        /// Your runtime beats 64.71 % of csharp submissions
        /// Your memory usage beats 38.23 % of csharp submissions(34.3 MB)
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public bool RepeatedSubstringPattern_Factorization(string s)
        {
            int n = s.Length;
            if (n == 1) return false;

            List<int> factors = new List<int>();
            if (IsPrime2(n, factors))
            {
                if (s[0] != s[1])
                    return false;
            }


            factors.Add(1);
            {
                Print(GetArrayStr(factors));

                for (int i = 0; i < factors.Count; i++)
                {
                    int wordLen = factors[i];
                    int count = n / wordLen;

                    bool allMatch = true;
                    string word = s.Substring(0, wordLen);
                    for (int j = wordLen; j < n; j += wordLen)
                    {
                        string tmpWord = s.Substring(j, wordLen);
                        if (!tmpWord.Equals(word))
                            allMatch = false;
                    }

                    if (allMatch)
                        return true;
                }
                return false;
            }
        }

        /// <summary>
        /// 判断是否是质数，不是更新所有因数列表（不含1）
        /// </summary>
        /// <param name="x"></param>
        /// <param name="factors"></param>
        /// <returns></returns>
        public bool IsPrime2(int x, List<int> factors)
        {
            if (factors == null) factors = new List<int>();

            for (int i = x / 2; i >= 2; --i)
            {
                if (x % i == 0)
                {
                    factors.Add(i);
                }
            }
            return factors.Count == 0;
        }
    }
}
