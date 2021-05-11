using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpConsoleApp.Solutions._0300
{
    /*
     * @lc app=leetcode.cn id=318 lang=csharp
     *
     * [318] 最大单词长度乘积
     *
     * https://leetcode-cn.com/problems/maximum-product-of-word-lengths/description/
     *
     * Category	Difficulty	Likes	Dislikes
     * algorithms	Medium (66.80%)	164	-
     * Tags
     * bit-manipulation
     * 
     * Companies
     * google
     * 
     * Total Accepted:    15.1K
     * Total Submissions: 22.6K
     * Testcase Example:  '["abcw","baz","foo","bar","xtfn","abcdef"]'
     *
     * 给定一个字符串数组 words，找到 length(word[i]) * length(word[j])
     * 的最大值，并且这两个单词不含有公共字母。你可以认为每个单词只包含小写字母。如果不存在这样的两个单词，返回 0。
     * 
     * 示例 1:
     * 
     * 输入: ["abcw","baz","foo","bar","xtfn","abcdef"]
     * 输出: 16 
     * 解释: 这两个单词为 "abcw", "xtfn"。
     * 
     * 示例 2:
     * 
     * 输入: ["a","ab","abc","d","cd","bcd","abcd"]
     * 输出: 4 
     * 解释: 这两个单词为 "ab", "cd"。
     * 
     * 示例 3:
     * 
     * 输入: ["a","aa","aaa","aaaa"]
     * 输出: 0 
     * 解释: 不存在这样的两个单词。
     * 
     */

    class Solution318 : SolutionBase
    {
        public override Difficulity GetDifficulity() { return Difficulity.Medium; }
        /// <summary>
        /// 关键字:
        /// </summary>
        public override string[] GetKeyWords() { return new string[] { "int类型位操作判断26个字母是否有重复" }; }
        /// <summary>
        /// 标签：
        /// </summary>
        public override Tag[] GetTags() { return new Tag[] { Tag.BitManipulation, }; }
        public override bool Test(System.Diagnostics.Stopwatch sw)
        {
            bool isSuccess = true;
            int result = MaxProduct(new string[] { "abcw", "baz", "foo", "bar", "xtfn", "abcdef" });

            isSuccess &= (result == 16);
            Print("isSuccess = {0}, result = {1}", isSuccess, result);
            return isSuccess;
        }

        /// <summary>
        /// Your runtime beats 55.56 % of csharp submissions
        /// Your memory usage beats 100 % of csharp submissions(28 MB)
        /// 作者：LeetCode
        /// 链接：https://leetcode-cn.com/problems/maximum-product-of-word-lengths/solution/zui-da-dan-ci-chang-du-cheng-ji-by-leetcode/
        /// </summary>
        /// <param name="words"></param>
        /// <returns></returns>
        public int MaxProduct(string[] words)
        {
            int n = words.Length;

            ///保存个单词中，字母是否存在信息的列表
            List<int> bitMaskList = new List<int>();
            for (int i = 0; i < n; ++i)
            {
                int bitMask = 0;
                foreach (char ch in words[i])
                    bitMask |= 1 << bitNumber(ch);
                bitMaskList.Add(bitMask);
            }
            
            int maxProd = 0;
            for (int i = 0; i < n; ++i)
                for (int j = i + 1; j < n; ++j)
                    //if (noCommonLetters(words[i], words[j])
                    if ((bitMaskList[i] & bitMaskList[j]) == 0)  //等同上述判断简化后的处理。直接判断 bit与运算判断是否有字母重复
                        maxProd = Math.Max(maxProd, words[i].Length * words[j].Length);

            return maxProd;
        }

        ///作者：LeetCode
        ///链接：https://leetcode-cn.com/problems/maximum-product-of-word-lengths/solution/zui-da-dan-ci-chang-du-cheng-ji-by-leetcode/
        public int bitNumber(char ch)
        {
            return (int)ch - (int)'a';
        }

        //public bool noCommonLetters(String s1, String s2, int bitmask1, int bitmask2)
        //{
        //    return (bitmask1 & bitmask2) == 0;  //位运算判断两单词是否有重复字母
        //}
        //
        //public bool noCommonLetters(String s1, String s2)
        //{
        //    int bitmask1 = 0, bitmask2 = 0;
        //    foreach (char ch in s1)
        //        bitmask1 |= 1 << bitNumber(ch);  //设置字母对应bit位为1
        //    foreach (char ch in s2)
        //        bitmask2 |= 1 << bitNumber(ch);  //设置字母对应bit位为1
        //
        //    return (bitmask1 & bitmask2) == 0;  //位运算判断两单词是否有重复字母
        //}
    }
}
