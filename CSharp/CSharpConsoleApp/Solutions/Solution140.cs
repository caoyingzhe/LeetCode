using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpConsoleApp.Solutions
{
    /// <summary>
    /// 单词拆分 II 
    /// 
    /// 给定一个非空字符串 s 和一个包含非空单词列表的字典 wordDict，在字符串中增加空格来构建一个句子，使得句子中所有的单词都在词典中。返回所有这些可能的句子。
    /// 说明：
    ///     分隔时可以重复使用字典中的单词。
    ///     你可以假设字典中没有重复的单词。
    ///
    /// 输入: s = "catsanddog" wordDict = ["cat", "cats", "and", "sand", "dog"]
    /// 输出: [ "cats and dog",  "cat sand dog" ]
    /// 
    /// 输入: s = "catsandog" wordDict =  ["cats", "dog", "sand", "and", "cat"]
    /// 输出: []
    /// </summary>
    class Solution140 : SolutionBase
    {
        /// <summary>
        /// 难易度:
        /// </summary>
        public override Difficulity GetDifficulity() { return Difficulity.Medium; }
        /// <summary>
        /// 关键字:
        /// </summary>
        public override string[] GetKeyWords() { return new string[] { "dynamic-programming", "Backtracking" }; }
        /// <summary>
        /// 标签：
        /// </summary>
        public override Tag[] GetTags() { return new Tag[] { Tag.DynamicProgramming, Tag.Backtracking }; }

        public override bool Test(System.Diagnostics.Stopwatch sw)
        {
            return false;
        }

        public IList<string> WordBreak(string s, IList<string> wordDict)
        {
            return null;
        }
    }
}
