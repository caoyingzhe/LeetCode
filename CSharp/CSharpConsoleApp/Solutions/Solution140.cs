
#define NOUSE_LinkedList
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
    /// 输入: s = "pineapplepenapple" wordDict = ["apple", "pen", "applepen", "pine", "pineapple""]
    /// 输出: [ ["pine apple pen apple"], 
    ///         ["pineapple pen apple"],
    ///         ["pine applepen apple"]
    ///       ]
    /// 输入: s = "catsandog" wordDict =  ["cats", "dog", "sand", "and", "cat"]
    /// 输出: []
    /// 
    /// 作者：LeetCode-Solution
    /// 链接：https://leetcode-cn.com/problems/word-break-ii/solution/dan-ci-chai-fen-ii-by-leetcode-solution/
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
        public override string[] GetKeyWords() { return new string[] { "dynamic-programming", "Backtracking", "记忆化搜索剪枝" }; }
        /// <summary>
        /// 标签：
        /// </summary>
        public override Tag[] GetTags() { return new Tag[] { Tag.DynamicProgramming, Tag.Backtracking }; }

        public override bool Test(System.Diagnostics.Stopwatch sw)
        {
            List<string> wordDict = null;
            string s = null;
            List<string> result = null;
            List<string> resultChecked = new List<string>();
            bool isSuccess = true;

            s = "catsanddog";
            wordDict = new List<string>( new string[]{ "cat", "cats", "and", "sand", "dog" });
            result = WordBreak(s, wordDict).ToList<string>();
            resultChecked = new List<string>( new string[] { "cats and dog", "cat sand dog" });

            isSuccess &= IsListSame(result, resultChecked);

            Print("isSuccess = {0} | result= {1} | resultChecked = {2}", isSuccess, GetArrayStr(result),GetArrayStr(resultChecked));
            return false;
        }

#if NOUSE_LinkedList
        public IList<string> WordBreak(string s, IList<string> wordDict)
        {
            //用于记忆法剪枝的字典（Java中使用Map接口的HashMap类）
            Dictionary<int, List<List<String>>> map = new Dictionary<int, List<List<String>>>();
            
            //问题的解决方案
            List<List<String>> wordBreaks = Backtrack(s, s.Length, new HashSet<String>(wordDict), 0, map);

            List<String> breakList = new List<String>();
            foreach (List<String> wordBreak in wordBreaks)
            {
                breakList.Add(String.Join(" ", wordBreak));
            }
            return breakList;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="s">匹配字串，定值</param>
        /// <param name="length">匹配字串的长度，定值</param>
        /// <param name="wordSet"></param>
        /// <param name="index">当前处理的匹配字串s的索引，每次回溯时发生变化</param>
        /// <param name="map">用于记忆法剪枝的字典（适用于解决方案的递归处理期间）</param>
        /// <returns></returns>
        public List<List<String>> Backtrack(String s, int length, HashSet<String> wordSet, int index, Dictionary<int, List<List<String>>> map)
        {
            Print(">>> s = {0} | length ={1} | index = {2}", s, length, index);
            if (!map.ContainsKey(index))
            {
                List<List<String>> wordBreaks = new List<List<String>>();
                if (index == length)
                {
                    wordBreaks.Add(new List<String>());
                }
                for (int i = index + 1; i <= length; i++)
                {
                    //String word = s.substring(index, i);
                    String word = s.Substring(index, i-index);

                    Print("======>>>Check : Substring ({0},{1}) | index = {0} wordSet.Contains({2}) = {3}", index, i, word, wordSet.Contains(word));
                    if (wordSet.Contains(word))
                    {
                        List<List<String>> nextWordBreaks = Backtrack(s, length, wordSet, i, map);
                        Print("======>>> index = {0} Get nextWordBreaks = {1}", index, GetArrayStr(nextWordBreaks, "，", ";"));
                        for (int j=0; j<nextWordBreaks.Count; j++)
                        //foreach (List<String> nextWordBreak in nextWordBreaks)
                        {
                            List<String> nextWordBreak = nextWordBreaks[j];
                            List<String> wordBreak = new List<String>(nextWordBreak);
                            //wordBreak.offerFirst(word);  //Java LinkedList offserFirst :  inserts the specified element at the front of this list.
                            wordBreak.Insert(0, word);
                            //wordBreaks.add(wordBreak);
                            wordBreaks.Add(wordBreak);
                            Print("=========>>> loop : index = {0} j ={1}/{2} Add word [{3}] at wordBreak[0] | {4} => {5} ", index, j, nextWordBreaks.Count, word, GetArrayStr(nextWordBreak), GetArrayStr(nextWordBreak));
                        }
                    }
                }
                map.Add(index, wordBreaks);
                Print("===>>> Add Dictionary Data : index ={0} wordBreaks = {1} ", index, GetArrayStr(wordBreaks,",", ";"));

            }
            Print("<<< map[{0}] = {1}", index, GetArrayStr(map[index], "，", "|"));
            return map[index];
        }
#else
        public IList<String> WordBreak(String s, IList<String> wordDict)
        {
            //Map<Integer, List<List<String>>> map = new HashMap<Integer, List<List<String>>>();
            Dictionary <int, LinkedList<List<String>>> map = new Dictionary<int, LinkedList<List<String>>>();

            //List<List<String>> wordBreaks = backtrack(s, s.length(), new HashSet<String>(wordDict), 0, map);
            List<List<String>> wordBreaks = Backtrack(s, s.Length, new HashSet<String>(wordDict), 0, map);

            //List<String> breakList = new LinkedList<String>();
            List<String> breakList = new List<String>();
            foreach (List<String> wordBreak in wordBreaks)
            {
                breakList.Add(String.Join(" ", wordBreak));
            }
            return breakList;
        }
        //public List<List<String>> Backtrack(String s, int length, Set<String> wordSet, int index, Map<Integer, List<List<String>>> map)
        public List<List<String>> Backtrack(String s, int length, HashSet<String> wordSet, int index, Dictionary<int, LinkedList<List<String>>> map)
        {
            if (!map.ContainsKey(index))
            {
                //List<List<String>> wordBreaks = new LinkedList<List<String>>();
                LinkedList<List<String>> wordBreaks = new LinkedList<List<String>>();
                if (index == length)
                {
                    //wordBreaks.Add(new List<String>());
                    wordBreaks.AddLast(new List<String>());
                }
                for (int i = index + 1; i <= length; i++)
                {
                    //String word = s.substring(index, i);
                    String word = s.Substring(index, i-index);
                    if (wordSet.Contains(word))
                    {
                        List<List<String>> nextWordBreaks = Backtrack(s, length, wordSet, i, map);
                        foreach (List<String> nextWordBreak in nextWordBreaks)
                        {
                            //LinkedList<String> wordBreak = new LinkedList<String>(nextWordBreak);
                            List<String> wordBreak = new List<String>(nextWordBreak);
                            //wordBreak.offerFirst(word);  //Java LinkedList offserFirst :  inserts the specified element at the front of this list.
                            wordBreak.Insert(0, word);
                            //wordBreaks.add(wordBreak);
                            wordBreaks.AddLast(wordBreak);
                        }
                    }
                }
                //map.put(index, wordBreaks);
                map.Add(index, wordBreaks);
            }
            //return map.get(index);
            return map[index].ToList<List<string>>();
        }
#endif
    }
}
