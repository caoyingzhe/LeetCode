using System;
using System.Collections.Generic;
namespace CSharpConsoleApp.Solutions
{
    /*
     * @lc app=leetcode.cn id=522 lang=csharp
     *
     * [522] 最长特殊序列 II
     *
     * https://leetcode-cn.com/problems/longest-uncommon-subsequence-ii/description/
     *
     * Category	Difficulty	Likes	Dislikes
     * algorithms	Medium (35.37%)	62	-
     * Tags
     * string
     * 
     * Companies
     * google
     * 
     * Total Accepted:    5.8K
     * Total Submissions: 16.5K
     * Testcase Example:  '["aba","cdc","eae"]'
     *
     * 给定字符串列表，你需要从它们中找出最长的特殊序列。最长特殊序列定义如下：该序列为某字符串独有的最长子序列（即不能是其他字符串的子序列）。
     * 
     * 子序列可以通过删去字符串中的某些字符实现，但不能改变剩余字符的相对顺序。空序列为所有字符串的子序列，任何字符串为其自身的子序列。
     * 
     * 输入将是一个字符串列表，输出是最长特殊序列的长度。如果最长特殊序列不存在，返回 -1 。
     * 
     * 示例：
     * 输入: "aba", "cdc", "eae"
     * 输出: 3
     * 
     * 
     * 提示：
     * 所有给定的字符串长度不会超过 10 。
     * 给定字符串列表的长度将在 [2, 50 ] 之间。
     */
    public class Solution522 : SolutionBase
    {
        /// <summary>
        /// 难易度:
        /// </summary>
        public override Difficulity GetDifficulity() { return Difficulity.Medium; }
        /// <summary>
        /// 关键字:
        /// </summary>
        public override string[] GetKeyWords() { return new string[] { "最长特殊序列" }; }
        /// <summary>
        /// 标签： 
        /// </summary>
        public override Tag[] GetTags() { return new Tag[] { Tag.String,}; }

        public override bool Test(System.Diagnostics.Stopwatch sw)
        {
            bool isSuccess = true;
            string[] dict;
            int result, checkResult;

            dict = new string[] { "aabbcc", "aabbcc", "cb", "abc" };
            checkResult = 2;
            result = FindLUSlength(dict);

            isSuccess &= result == checkResult;
            Print("isSuccess = {0} | result = {1} | anticipated = {2}", isSuccess, (result), (checkResult));
            return isSuccess;
        }

        /// <summary>
        /// 98/98 cases passed (116 ms)
        /// Your runtime beats 66.67 % of csharp submissions
        /// Your memory usage beats 33.33 % of csharp submissions(24.5 MB)
        /// </summary>
        /// <param name="strs"></param>
        /// <returns></returns>
        public int FindLUSlength(string[] strs)
        {
            List<string> list = new List<string>(strs);
            list.Sort((a, b) => {
                if (a.Length == b.Length)
                {
                    return string.Compare(a, b);
                }
                else
                {
                    return b.Length - a.Length;
                }
            });

            for(int i=0; i<list.Count; i++)
            {
                bool isSub = false;
                for(int j=0; j<list.Count && list[i].Length <= list[j].Length; j++)
                {
                    if(i!=j && IsSubStr(list[i],list[j])) //判断i是否为j的子串
                    {
                        isSub = true;
                        break;
                    }
                }
                if (!isSub)
                    return list[i].Length;
            }
            return -1;
        }

        //判断a是否为b的子串
        //(根据题意，非直接包含关系，而是可以删去字符串后包含）
        //所以不可以使用 b.Contains(a) 判断。
        bool IsSubStr(string a, string b)
        {
            int i = 0;
            foreach (char c in b)
                if (i < a.Length && c == a[i]) i++;
            return i == a.Length;
        }
    }
}
