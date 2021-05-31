using System;
using System.Collections.Generic;
namespace CSharpConsoleApp.Solutions
{
    /*
     * @lc app=leetcode.cn id=524 lang=csharp
     *
     * [524] 通过删除字母匹配到字典里最长单词
     *
     * https://leetcode-cn.com/problems/longest-word-in-dictionary-through-deleting/description/
     *
     * Category	Difficulty	Likes	Dislikes
     * algorithms	Medium (47.36%)	148	-
     * Tags
     * two-pointers | sort
     * 
     * Companies
     * google
     * 
     * Total Accepted:    33.2K
     * Total Submissions: 70K
     * Testcase Example:  '"abpcplea"\n["ale","apple","monkey","plea"]'
     *
     * 给你一个字符串 s 和一个字符串数组 dictionary 作为字典，找出并返回字典中最长的字符串，该字符串可以通过删除 s 中的某些字符得到。
     * 如果答案不止一个，返回长度最长且字典序最小的字符串。如果答案不存在，则返回空字符串。
     * 
     * 
     * 示例 1：
     * 输入：s = "abpcplea", dictionary = ["ale","apple","monkey","plea"]
     * 输出："apple"
     * 
     * 
     * 示例 2：
     * 输入：s = "abpcplea", dictionary = ["a","b","c"]
     * 输出："a"
     * 
     * 
     * 提示：
     * 1 <= s.length <= 1000
     * 1 <= dictionary.length <= 1000
     * 1 <= dictionary[i].length <= 1000
     * s 和 dictionary[i] 仅由小写英文字母组成
     */
    public class Solution524 : SolutionBase
    {
        /// <summary>
        /// 难易度:
        /// </summary>
        public override Difficulity GetDifficulity() { return Difficulity.Medium; }
        /// <summary>
        /// 关键字:
        /// </summary>
        public override string[] GetKeyWords() { return new string[] { "寻找最长字符串", "C#比Java慢（相同的代码）" }; }
        /// <summary>
        /// 标签： 
        /// </summary>
        public override Tag[] GetTags() { return new Tag[] { Tag.TwoPointers, Tag.Sort }; }

        public override bool Test(System.Diagnostics.Stopwatch sw)
        {
            bool isSuccess = true;
            List<string> dict;
            string s;
            string result, checkResult;

            s = "abpcplea";
            dict = new List<string>(new string[] { "ale", "apple", "monke", "monkey", "plea" });
            checkResult = "apple";
            result = FindLongestWord(s, dict);

            isSuccess &= result == checkResult;
            Print("isSuccess = {0} | result = {1} | anticipated = {2}", isSuccess, (result), (checkResult));
            return isSuccess;
        }

        //31/31 cases passed (168 ms)
        //Your runtime beats 25 % of csharp submissions
        //Your memory usage beats 57.14 % of csharp submissions(35.7 MB)
        public string FindLongestWord(string s, IList<string> dictionary)
        {
            int n = s.Length;

            List<string> list = new List<string>(dictionary);
            list.Sort((a, b) => {
                if(a.Length == b.Length)
                {
                    return string.Compare(a, b);
                }
                else
                {
                    return b.Length - a.Length;
                }
            }) ;

            //Print(GetArrayStr(list));
            for (int i=0;i< list.Count;  i++)
            {
                string word = list[i];
                if (n < word.Length) continue;

                int L = 0; int R = 0;
                int c = 0; //匹配字符串
                while(L<n && R< word.Length)
                {
                    if(s[L] == word[R])
                    { 
                        L++; R++; c++;
                    }
                    else
                    { 
                        L++;
                    }
                    if (c == word.Length)
                        return word;
                }
            }
            
            return "";
        }
    }
}
