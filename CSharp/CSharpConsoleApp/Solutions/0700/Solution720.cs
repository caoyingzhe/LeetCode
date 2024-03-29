﻿using System;
using System.Collections.Generic;
namespace CSharpConsoleApp.Solutions
{
    /*
         * @lc app=leetcode.cn id=720 lang=csharp
         *
         * [720] 词典中最长的单词
         *
         * https://leetcode-cn.com/problems/longest-word-in-dictionary/description/
         *
         * algorithms
         * Easy (48.59%)
         * Likes:    151
         * Dislikes: 0
         * Total Accepted:    19K
         * Total Submissions: 39K
         * Testcase Example:  '["w","wo","wor","worl","world"]'
         *
         * 
         * 给出一个字符串数组words组成的一本英语词典。从中找出最长的一个单词，该单词是由words词典中其他单词逐步添加一个字母组成。若其中有多个可行的答案，则返回答案中字典序最小的单词。
         * 
         * 若无答案，则返回空字符串。
         * 
         * 
         * 
         * 示例 1：
         * 
         * 输入：
         * words = ["w","wo","wor","worl", "world"]
         * 输出："world"
         * 解释： 
         * 单词"world"可由"w", "wo", "wor", 和 "worl"添加一个字母组成。
         * 
         * 
         * 示例 2：
         * 
         * 输入：
         * words = ["a", "banana", "app", "appl", "ap", "apply", "apple"]
         * 输出："apple"
         * 解释：
         * "apply"和"apple"都能由词典中的单词组成。但是"apple"的字典序小于"apply"。
         * 
         * 
         * 
         * 
         * 提示：
         * 
         * 
         * 所有输入的字符串都只包含小写字母。
         * words数组长度范围为[1,1000]。
         * words[i]的长度范围为[1,30]。
         * 
         * 
         */

    // @lc code=start
    public class Solution720 : SolutionBase
    {
        /// <summary>
        /// 难度
        /// </summary>
        public override Difficulity GetDifficulity() { return Difficulity.Easy; }
        /// <summary>
        /// 关键字:
        /// </summary>
        public override string[] GetKeyWords() { return new string[] {}; }
        /// <summary>
        /// 标签：
        /// </summary>
        public override Tag[] GetTags() { return new Tag[] { Tag.Sort }; }

        /// <summary>
        /// </summary>
        /// <param name="sw"></param>
        /// <returns></returns>
        public override bool Test(System.Diagnostics.Stopwatch sw)
        {
            bool isSuccess = true;
            //TODO
            //PrintDatas(PoorPigs(new int[] { 0, 0 }, new int[] { 1, 1 }, new int[] { 1, 0 }, new int[] { 0, 1 }));
            return isSuccess;
        }

        public string LongestWord(string[] words)
        {
            //sort(words.begin(), words.end());//从小到大排序
            HashSet<string> mySet = new HashSet<string>();
            //unordered_set<string> mySet;
            Array.Sort(words, (a, b) => { return a.CompareTo(b); });
            string ans = "";  //从空开始记录
            mySet.Add(ans);

            foreach (string word in words)
            {
                //if (mySet.find(string(word.begin(), word.end() - 1)) != mySet.end())
                if(mySet.Contains(word.Substring(0,word.Length - 1)))
                {
                    if (word.Length > ans.Length)
                        ans = word; //如果长度更长，更新答案
                    mySet.Add(word);  //记录这个单词
                }
            }
            return ans;
        }
    }
    // @lc code=end
}
