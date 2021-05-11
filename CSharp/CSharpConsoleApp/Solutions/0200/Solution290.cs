using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpConsoleApp.Solutions._0200
{
    /*
     * @lc app=leetcode.cn id=290 lang=csharp
     *
     * [290] 单词规律
     *
     * https://leetcode-cn.com/problems/word-pattern/description/
     *
     * Category	Difficulty	Likes	Dislikes
     * algorithms	Easy (45.76%)	334	-
     * Tags
     * hash-table
     * 
     * Companies
     * dropbox | uber
     * 
     * Total Accepted:    71.6K
     * Total Submissions: 156.4K
     * Testcase Example:  '"abba"\n"dog cat cat dog"'
     *
     * 给定一种规律 pattern 和一个字符串 str ，判断 str 是否遵循相同的规律。
     * 
     * 这里的 遵循 指完全匹配，例如， pattern 里的每个字母和字符串 str 中的每个非空单词之间存在着双向连接的对应规律。
     * 
     * 示例1:
     * 
     * 输入: pattern = "abba", str = "dog cat cat dog"
     * 输出: true
     * 
     * 示例 2:
     * 
     * 输入:pattern = "abba", str = "dog cat cat fish"
     * 输出: false
     * 
     * 示例 3:
     * 
     * 输入: pattern = "aaaa", str = "dog cat cat dog"
     * 输出: false
     * 
     * 示例 4:
     * 
     * 输入: pattern = "abba", str = "dog dog dog dog"
     * 输出: false
     * 
     * 说明:
     * 你可以假设 pattern 只包含小写字母， str 包含了由单个空格分隔的小写字母。    
     * 
     */
    class Solution290 : SolutionBase
    {/// <summary>
     /// 难度
     /// </summary>
        public override Difficulity GetDifficulity() { return Difficulity.Easy; }
        /// <summary>
        /// 关键字:
        /// </summary>
        public override string[] GetKeyWords() { return new string[] { "" }; }
        /// <summary>
        /// 标签：
        /// </summary>
        public override Tag[] GetTags() { return new Tag[] { Tag.HashTable, }; }
        public override bool Test(System.Diagnostics.Stopwatch sw)
        {
            bool isSuccess = true;

            isSuccess &=  WordPattern("abba", "dog cat cat dog") == true;
            isSuccess &= WordPattern("abba", "dog dog dog dog") == true;
            isSuccess &= WordPattern("abba", "dog cat cat fish") == false;
            
            return isSuccess;
        }

        public bool WordPattern(string pattern, string s)
        {
            if (string.IsNullOrEmpty(pattern) || string.IsNullOrEmpty(s))
                return false;

            string[] words = s.Split(' ');
            int n = pattern.Length;
            if (words.Length != n)
                return false;

            HashSet<string> set = new HashSet<string>();
            Dictionary<char, string> map = new Dictionary<char, string>();
            for (int i = 0; i < n; i++)
            {
                if (!map.ContainsKey(pattern[i]))
                {
                    if (set.Contains(words[i]))
                        return false;

                    map.Add(pattern[i], words[i]);
                    set.Add(words[i]); //Words的索引
                }
                else
                {
                    if (!map[pattern[i]].Equals(words[i]))
                    {
                        return false;
                    }
                }
            }
            return true;
        }
    }
}
