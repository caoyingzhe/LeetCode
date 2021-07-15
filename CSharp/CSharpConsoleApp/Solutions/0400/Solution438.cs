using System;
using System.Collections.Generic;
namespace CSharpConsoleApp.Solutions
{
    /*
 * @lc app=leetcode.cn id=438 lang=csharp
 *
 * [438] 找到字符串中所有字母异位词
 *
 * https://leetcode-cn.com/problems/find-all-anagrams-in-a-string/description/
 *
 * Category	Difficulty	Likes	Dislikes
 * algorithms	Medium (50.91%)	546	-
 * Tags
 * hash-table
 * 
 * Companies
 * amazon
 * 
 * Total Accepted:    72.7K
 * Total Submissions: 142.8K
 * Testcase Example:  '"cbaebabacd"\n"abc"'
 *
 * 给定一个字符串 s 和一个非空字符串 p，找到 s 中所有是 p 的字母异位词的子串，返回这些子串的起始索引。
 * 
 * 字符串只包含小写英文字母，并且字符串 s 和 p 的长度都不超过 20100。
 * 
 * 说明：
 * 
 * 
 * 字母异位词指字母相同，但排列不同的字符串。
 * 不考虑答案输出的顺序。
 * 
 * 
 * 示例 1:
 * 
 * 
 * 输入:
 * s: "cbaebabacd" p: "abc"
 * 
 * 输出:
 * [0, 6]
 * 
 * 解释:
 * 起始索引等于 0 的子串是 "cba", 它是 "abc" 的字母异位词。
 * 起始索引等于 6 的子串是 "bac", 它是 "abc" 的字母异位词。
 * 
 * 
 * 示例 2:
 * 
 * 
 * 输入:
 * s: "abab" p: "ab"
 * 
 * 输出:
 * [0, 1, 2]
 * 
 * 解释:
 * 起始索引等于 0 的子串是 "ab", 它是 "ab" 的字母异位词。
 * 起始索引等于 1 的子串是 "ba", 它是 "ab" 的字母异位词。
 * 起始索引等于 2 的子串是 "ab", 它是 "ab" 的字母异位词。
 * 
 * 
 */

    // @lc code=start
    public class Solution438 : SolutionBase
    {
        /// <summary>
        /// 难度
        /// </summary>
        public override Difficulity GetDifficulity() { return Difficulity.Medium; }
        /// <summary>
        /// 关键字:
        /// </summary>
        public override string[] GetKeyWords() { return new string[] { }; }
        /// <summary>
        /// 标签：
        /// </summary>
        public override Tag[] GetTags() { return new Tag[] { Tag.HashTable }; }

        /// <summary>
        /// </summary>
        /// <param name="sw"></param>
        /// <returns></returns>
        public override bool Test(System.Diagnostics.Stopwatch sw)
        {
            bool isSuccess = true;
            string s, p;
            IList<int> result, checkResult;

            s = "cbaebabacd"; p = "abc";
            checkResult = new[] { 0, 6 };
            result = FindAnagrams(s, p);
            isSuccess &= IsListSame(result, checkResult);
            PrintResult(isSuccess, GetArrayStr(result), GetArrayStr(checkResult));
            return isSuccess;
        }

        //作者：bestblade
        //链接：https://leetcode-cn.com/problems/find-all-anagrams-in-a-string/solution/hua-dong-chuang-kou-shu-zu-ha-xi-biao-by-r2k2/
        /// <summary>
        /// 60/60 cases passed (276 ms)
        /// Your runtime beats 97.37 % of csharp submissions
        /// Your memory usage beats 65.79 % of csharp submissions(35.2 MB)
        /// </summary>
        /// <param name="s"></param>
        /// <param name="p"></param>
        /// <returns></returns>
        public IList<int> FindAnagrams(string s, string p)
        {
            List<int> res = new List<int>();
            if (p.Length > s.Length)
            {
                return res;
            }
            //采用数组代替哈希表，速度更快，但是要自己写判断函数
            int[] s_cnt = new int[26];
            int[] p_cnt = new int[26];
            for (int i = 0; i < p.Length; ++i)
            {
                s_cnt[s[i] - 'a']++;
                p_cnt[p[i] - 'a']++;
            }
            if (Check(s_cnt, p_cnt))
            {
                res.Add(0);
            }

            int l = 0;
            int r = p.Length - 1;

            while (r < s.Length - 1)
            {
                s_cnt[s[l++] - 'a']--;
                s_cnt[s[++r] - 'a']++;
                if (Check(s_cnt, p_cnt))
                {
                    res.Add(l);
                }
            }
            return res;
        }

        //判断两个单词是否相同
        bool Check(int [] s, int [] p)
        {
            for (int i = 0; i < 26; i++)
            {
                if (s[i] != p[i])
                {
                    return false;
                }
            }
            return true;
        }
    }
    // @lc code=end


}
