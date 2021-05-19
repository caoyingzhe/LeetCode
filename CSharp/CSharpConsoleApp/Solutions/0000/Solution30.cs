using System;
using System.Collections.Generic;

namespace CSharpConsoleApp.Solutions
{
    /*
     * @lc app=leetcode.cn id=30 lang=csharp
     *
     * [30] 串联所有单词的子串
     *
     * https://leetcode-cn.com/problems/substring-with-concatenation-of-all-words/description/
     *
     * Category	Difficulty	Likes	Dislikes
     * algorithms	Hard (34.61%)	471	-
     * Tags
     * hash-table | two-pointers | string
     * 
     * Companies
     * Unknown
     * Total Accepted:    64.8K
     * Total Submissions: 187.2K
     * Testcase Example:  '"barfoothefoobarman"\n["foo","bar"]'
     *
     * 给定一个字符串 s 和一些长度相同的单词 words。找出 s 中恰好可以由 words 中所有单词串联形成的子串的起始位置。
     * 
     * 注意子串要与 words 中的单词完全匹配，中间不能有其他字符，但不需要考虑 words 中单词串联的顺序。
     * 
     * 示例 1：
     * 输入：
     * ⁠ s = "barfoothefoobarman",
     * ⁠ words = ["foo","bar"]
     * 输出：[0,9]
     * 解释：
     * 从索引 0 和 9 开始的子串分别是 "barfoo" 和 "foobar" 。
     * 输出的顺序不重要, [9,0] 也是有效答案。
     * 
     * 
     * 示例 2：
     * 输入：
     * ⁠ s = "wordgoodgoodgoodbestword",
     * ⁠ words = ["word","good","best","word"]
     * 输出：[]
     * 
     * 
     */
    public class Solution30 : SolutionBase
    {
        /// <summary>
        /// 难易度:
        /// </summary>
        public override Difficulity GetDifficulity() { return Difficulity.Hard; }
        /// <summary>
        /// 关键字:
        /// </summary>
        public override string[] GetKeyWords() { return new string[] { "哈希表", "双指针", "字符串"}; }
        /// <summary>
        /// 标签： 图
        /// </summary>
        public override Tag[] GetTags() { return new Tag[] { Tag.HashTable, Tag.TwoPointers, Tag.String }; }

        public override bool Test(System.Diagnostics.Stopwatch sw)
        {
            bool isSuccess = true;
            string s = "barfoothefoobarman";
            string[] words = new string[] { "foo", "bar"};
            IList<int> result = FindSubstring(s, words);
            IList<int> checkResult = new List<int> (new int[] { 9, 0 });

            isSuccess &= IsListSame(result, checkResult);
            Print("isSuccess = {0} result = {1} | checkResult = {2}", isSuccess, GetArrayStr(result), GetArrayStr(checkResult));

            return isSuccess;
        }
        /// <summary>
        /// Time Limit Exceeded 176/176 cases passed(N/A)
        /// 作者：powcai
        /// 链接：https://leetcode-cn.com/problems/substring-with-concatenation-of-all-words/solution/chuan-lian-suo-you-dan-ci-de-zi-chuan-by-powcai/
        /// </summary>
        /// <param name="s"></param>
        /// <param name="words"></param>
        /// <returns></returns>
        public IList<int> FindSubstring_TLE(string s, string[] words)
        {
            List<int> res = new List<int>();
            if (s == null || s.Length == 0 || words == null || words.Length == 0)
                return res;

            //保存单词出现数量的字典
            Dictionary<string, int> map = new Dictionary<string, int>();


            //所有单词匹配的长度 = 单个单词长度 x 单词数。（题目中说单词长度都相同，所以用乘法，否则需要循环。）
            int one_word = words[0].Length;
            int word_num = words.Length;
            int allLen = one_word * word_num;

            //把单词加入字典。
            foreach (string word in words)
            {
                if (map.ContainsKey(word))
                    map[word] += 1;
                else
                    map.Add(word, 1);
            }

            //全部单词可能匹配的首字母位置的最大位置= s.Length - allLen
            for (int i = 0; i <= s.Length - allLen; i++)
            {
                //截取长度为 allLen 的字符串
                string tmp = s.Substring(i, allLen);

                //测试是否匹配字典中的单词
                Dictionary<string, int> tmp_map = new Dictionary<string, int>();
                for (int j = 0; j < allLen; j += one_word)
                {
                    string w = tmp.Substring(j, one_word);
                    if (tmp_map.ContainsKey(w))
                    { 
                        tmp_map[w] += 1;
                    }
                    else
                    { 
                        tmp_map.Add(w, 1);
                    }
                }
                //判断字典是否完全一样，一样的话，就加入该首字母的索引。
                if (IsSameDictionary(map,tmp_map)) //IsSameDictionary方法效率过低。
                    res.Add(i);
            }
            return res;
        }

        /// <summary>
        /// 该算法是LTE的改进，勉强通过
        ///
        /// 176/176 cases passed (1728 ms)
        /// Your runtime beats 7.27 % of csharp submissions
        /// Your memory usage beats 5.45 % of csharp submissions(51.6 MB)
        /// </summary>
        /// <param name="s"></param>
        /// <param name="words"></param>
        /// <returns></returns>
        public IList<int> FindSubstring(string s, string[] words)
        {
            List<int> res = new List<int>();
            if (s == null || s.Length == 0 || words == null || words.Length == 0)
                return res;

            //保存单词出现数量的字典
            Dictionary<string, List<int>> map = new Dictionary<string, List<int>>();

            //所有单词匹配的长度 = 单个单词长度 x 单词数。（题目中说单词长度都相同，所以用乘法，否则需要循环。）
            int oneWord = words[0].Length;
            int word_num = words.Length;
            int allLen = oneWord * word_num;


            //单词顺序号的总和，累加的时候不能从0开始计算，从1开始。从0开始无法区分第一个存在不存在（比如无法区分[0,1,2]和[1,2]）
            int matchIndexSum = 0;

            //把单词加入字典。
            for (int i=0; i<words.Length; i++)
            {
                string word = words[i];

                if (!map.ContainsKey(word))
                {
                    map.Add(word, new List<int>()); //添加到字典 key=word
                }
                map[word].Add(i); //添加到单词索引到字典值[列表] value[list].Add(当前索引)
                matchIndexSum += (i + 1); ; //+1代表的第几
            }

            //全部单词可能匹配的首字母位置的最大位置= s.Length - allLen
            for (int i = 0; i <= s.Length - allLen; i++)
            {
                //截取长度为 allLen 的字符串
                string tmp = s.Substring(i, allLen);
                //是否存在重复单词标志
                bool isDuplicate = false;
                //发现不存在的单词
                bool findOtherWord = false;

                int matchIndexSumTmp = 0;
                //测试是否匹配字典中的单词
                Dictionary<string,int> tmp_map = new Dictionary<string,int>();
                for (int j = 0; j < allLen; j += oneWord)
                {
                    string w = tmp.Substring(j, oneWord);

                    if(!map.ContainsKey(w)) 
                    {
                        findOtherWord = true;
                        break; //发现不存在的其他单词，立即中断，不再判断后续单词匹配。
                    }
                    else
                    { 
                        if (tmp_map.ContainsKey(w))
                        {
                            if(tmp_map[w] == map[w].Count)
                            {
                                isDuplicate = true;
                                break; //超出字典中单词个数，立即中断，不再判断后续单词匹配。
                            }

                            tmp_map[w] += 1;

                            matchIndexSumTmp += map[w][tmp_map[w]-1]+1; //+1代表的第几

                        }
                        else
                        {
                            tmp_map.Add(w,1);
                            matchIndexSumTmp += map[w][0]+1; //+1代表的第几
                        }
                    }
                }
                //【无重复单词 + 判断字典数量完全一样】的情况下，添加当前字母索引到结果中。
                if (!findOtherWord && !isDuplicate && matchIndexSumTmp == matchIndexSum) { 
                    res.Add(i);
                }
                //Print("findOtherWord = {0} Duplicate = {1} | {2} | {3}", findOtherWord, isDuplicate, matchIndexSumTmp, matchIndexSum);
            }
            return res;
        }
    }
}
