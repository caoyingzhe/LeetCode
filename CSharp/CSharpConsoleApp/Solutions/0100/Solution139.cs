using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpConsoleApp.Solutions
{
    /// <summary>
    /// 给定一个非空字符串 s 和一个包含非空单词的列表 wordDict，判定 s 是否可以被空格拆分为一个或多个在字典中出现的单词。
    /// 说明：
    /// 
    /// 拆分时可以重复使用字典中的单词。
    /// 你可以假设字典中没有重复的单词。
    /// 
    /// Companies:
    /// amazon | bloomberg | facebook | google | pocketgems | uber | yahoo
    /// ---------------------------------------------------------------------------
    /// 输入: s = "leetcode", wordDict = ["leet", "code"]
    /// 输出: true
    /// 解释: 返回 true 因为 "leetcode" 可以被拆分成 "leet code"。
    /// ---------------------------------------------------------------------------
    /// 输入: s = "applepenapple", wordDict = ["apple", "pen"]
    /// 输出: true
    /// 解释: 返回 true 因为 "applepenapple" 可以被拆分成 "apple pen apple"。
    ///      注意你可以重复使用字典中的单词。
    /// ---------------------------------------------------------------------------
    /// 输入: s = "catsandog", wordDict = ["cats", "dog", "sand", "and", "cat"]
    /// 输出: false
    /// ---------------------------------------------------------------------------
    /// 输入: s = "cars", wordDict = ["car","ca","rs"]
    /// 输出: true
    /// </summary>
    class Solution139 : SolutionBase
    {
        /// <summary>
        /// 难易度:
        /// </summary>
        public override Difficulity GetDifficulity() { return Difficulity.Medium; }
        /// <summary>
        /// 关键字:
        /// </summary>
        public override string[] GetKeyWords() { return new string[] { "dynamic-programming" }; }
        /// <summary>
        /// 标签：
        /// </summary>
        public override Tag[] GetTags() { return new Tag[] { Tag.DynamicProgramming }; }

        public override bool Test(System.Diagnostics.Stopwatch sw)
        {
            return false;
        }

        public bool WordBreak(string s, IList<string> wordDict)
        {
            HashSet<string> hashSet = new HashSet<string>(wordDict);
            bool[] dp = new bool[s.Length + 1];

            dp[0] = true;
            for (int i = 1; i <= s.Length; ++i)
            {
                for (int j = 0; j < i; ++j)
                {
                    if (dp[j] && wordDict.Contains(s.Substring(j, i - j)))
                    {
                        dp[i] = true;
                        break;
                    }
                }
            }
            return dp[s.Length];
        }

        /// <summary>
        /// 字符串全体换方法
        /// 此方法对于  s = "cars", wordDict = ["car","ca","rs"]， 不能通过。 
        /// 原因是字符串全体换方法，没有考虑字典中可能有其他单词组合，或者包含其他单词的特例。
        /// </summary>
        /// <param name="s"></param>
        /// <param name="wordDict"></param>
        /// <returns></returns>
        public bool WordBreak_MySelf(string s, IList<string> wordDict)
        {
            if (string.IsNullOrEmpty(s) || wordDict.Count == 0)
                return false;

            string result = s;
            foreach (string word in wordDict)
            {
                result = result.Replace(word, "");
            }

            if (result == "")
                return true;
            else
            {

            }
            return false;
        }
    }
}
