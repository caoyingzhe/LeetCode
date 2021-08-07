using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpConsoleApp.Solutions
{
    /*
     * @lc app=leetcode.cn id=3 lang=csharp
     *
     * [3] 无重复字符的最长子串
     *
     * https://leetcode-cn.com/problems/longest-substring-without-repeating-characters/description/
     *
     * Category	Difficulty	Likes	Dislikes
     * algorithms	Medium (36.77%)	5222	-
     * Tags
     * hash-table | two-pointers | string | sliding-window
     * 
     * Companies
     * adobe | amazon | bloomberg | yelp
     * algorithms
     * 
     * Total Accepted:    912.1K
     * Total Submissions: 2.5M
     * Testcase Example:  '"abcabcbb"'
     *
     * 给定一个字符串，请你找出其中不含有重复字符的 最长子串 的长度。
     * 
     * 示例 1:
     * 输入: s = "abcabcbb"
     * 输出: 3 
     * 解释: 因为无重复字符的最长子串是 "abc"，所以其长度为 3。
     * 
     * 示例 2:
     * 输入: s = "bbbbb"
     * 输出: 1
     * 解释: 因为无重复字符的最长子串是 "b"，所以其长度为 1。
     * 
     * 示例 3:
     * 输入: s = "pwwkew"
     * 输出: 3
     * 解释: 因为无重复字符的最长子串是 "wke"，所以其长度为 3。
     * 请注意，你的答案必须是 子串 的长度，"pwke" 是一个子序列，不是子串。
     * 
     * 示例 4:
     * 输入: s = ""
     * 输出: 0
     * 
     * 提示：
     * 0 <= s.length <= 5 * 104
     * s 由英文字母、数字、符号和空格组成
     */
    class Solution3 : SolutionBase
    {
        /// <summary>
        /// 难度
        /// </summary>
        public override Difficulity GetDifficulity() { return Difficulity.Medium; }
        /// <summary>
        /// 关键字:
        /// </summary>
        public override string[] GetKeyWords() { return new string[] { "无重复字符的最长子串" }; }
        /// <summary>
        /// 标签： 
        /// </summary>
        public override Tag[] GetTags() { return new Tag[] { Tag.HashTable, Tag.TwoPointers, Tag.String, Tag.SlidingWindow }; }

        public override bool Test(System.Diagnostics.Stopwatch sw)
        {
            string s;
            int checkResult;
            bool isSuccess = true;

            s = "abcabcbb";
            checkResult = 3;
            isSuccess &= LengthOfLongestSubstring(s) == checkResult;

            s = "bbbbb";
            checkResult = 1;
            isSuccess &= LengthOfLongestSubstring(s) == checkResult;

            return isSuccess;
        }

        /// <summary>
        /// 常规算法，速度很慢
        /// Your runtime beats 23.25 % of csharp submissions
        /// Your memory usage beats 74.64 % of csharp submissions(25.4 MB)
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public int LengthOfLongestSubstring_My(string s)
        {
            if (string.IsNullOrEmpty(s))
                return 0;

            int n = s.Length;
            int max = 0;
            HashSet<char> set = new HashSet<char>();
            for (int i = 0; i < n; i++)
            {
                if (i != 0) set.Clear();
                set.Add(s[i]);

                int j = i;
                while (j < n - 1)
                {
                    if (set.Contains(s[j + 1]))
                        break;
                    set.Add(s[j + 1]);
                    j++;
                }
                //if (set.Count > max)
                //{
                //    max = set.Count;
                //}
                max = Math.Max(max, j - i + 1); //这个处理比上一段速度并没有明显增加;
            }

            return max;
        }

        /// <summary>
        /// 官方解法
        /// 
        /// Your runtime beats 93.88 % of csharp submissions
        /// Your memory usage beats 53.02 % of csharp submissions(25.7 MB)
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public int LengthOfLongestSubstring(string s)
        {
            // 哈希集合，记录每个字符是否出现过
            HashSet<char> occ = new HashSet<char>();
            int n = s.Length;
            // 右指针，初始值为 -1，相当于我们在字符串的左边界的左侧，还没有开始移动

            //重点: 定义j在循环外侧，不重置j=i;任其++递增； 配合occ.Remove(s[i - 1])实现处理速度和内存的优化。
            int j = -1; //为什么是-1，因为最初add的是 j+1 是第0个元素，所以j=-1;
            int max = 0;
            for (int i = 0; i < n; ++i)
            {
                if (i != 0)
                {
                    // 左指针向右移动一格，移除一个字符
                    occ.Remove(s[i - 1]);   //该处理避免了重复char的Add处理，并节省了大量内存
                }
                while (j + 1 < n && !occ.Contains(s[j + 1]))
                {
                    // 不断地移动右指针
                    occ.Add(s[j + 1]);
                    ++j;
                }
                // 第 i 到 rk 个字符是一个极长的无重复字符子串
                //max = Math.Max(max, j - i + 1);
                if (j - 1 + 1 > max)
                {
                    max = j - i + 1;
                }
            }
            return max;
        }
    }
}
