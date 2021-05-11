using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpConsoleApp.Solutions._0300
{
    /*
     * @lc app=leetcode.cn id=316 lang=csharp
     *
     * [316] 去除重复字母
     *
     * https://leetcode-cn.com/problems/remove-duplicate-letters/description/
     *
     * Category	Difficulty	Likes	Dislikes
     * algorithms	Medium (47.63%)	527	-
     * Tags
     * stack | greedy
     * 
     * Companies
     * google
     * 
     * Total Accepted:    55K
     * Total Submissions: 115.5K
     * Testcase Example:  '"bcabc"'
     *
     * 给你一个字符串 s ，请你去除字符串中重复的字母，使得每个字母只出现一次。需保证 返回结果的字典序最小（要求不能打乱其他字符的相对位置）。
     * 
     * 注意：该题与 1081 相同
     * https://leetcode-cn.com/problems/smallest-subsequence-of-distinct-characters 
     * 
     * 示例 1：
     * 输入：s = "bcabc"
     * 输出："abc"
     * 
     * 示例 2：
     * 输入：s = "cbacdcbc"
     * 输出："acdb"
     * 
     * 提示：
     * 1 <= s.length <= 10^4
     * s 由小写英文字母组成
     * 
     */

    /*
     问题1 : 什么是字符串字典序？
     答案1 : 又称 字母序（alphabetical order），原意是表示英文单词在字典中的先后顺序，
             在计算机领域中扩展成两个任意字符串的大小关系。
     理解1 : 字典序最小，就是得出结果尽量在字典排序中的前几页，而不是后几页。
             比如 "abc","bca", "acb"，"cba"之中， "abc"的字典序最小,"cba"最大。
     */
    class Solution316 : SolutionBase
    {
        /// <summary>
        /// 难度
        /// </summary>
        public override Difficulity GetDifficulity() { return Difficulity.Medium; }
        /// <summary>
        /// 关键字:
        /// </summary>
        public override string[] GetKeyWords() { return new string[] { "字符串字典序" }; }
        /// <summary>
        /// 标签： 
        /// </summary>
        public override Tag[] GetTags() { return new Tag[] { Tag.Stack, Tag.Greedy }; }

        public override bool Test(System.Diagnostics.Stopwatch sw)
        {
            bool isSuccess = true;

            isSuccess &= RemoveDuplicateLetters("cbacdcbc") == "acdb";
            return isSuccess;
        }
        
        /// <summary>
        /// 作者：LeetCode-Solution
        /// 链接：https://leetcode-cn.com/problems/remove-duplicate-letters/solution/qu-chu-zhong-fu-zi-mu-by-leetcode-soluti-vuso/
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public string RemoveDuplicateLetters(string s)
        {
            //记录是否出现对应索引的字母
            bool[] vis = new bool[26];

            //计算每个字母出现的次数
            int[] num = new int[26];
            for (int i = 0; i < s.Length; i++)
            {
                num[s[i] - 'a']++;
            }
            Print("num = {0} . vis = {1}", GetArrayStr(num), GetArrayStr(vis));

            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < s.Length; i++)
            {
                char ch = s[i];
                int cIndex = ch - 'a';

                if (!vis[cIndex]) //如果第一次出现该字母，进行处理环节，否则无视
                {
                    while (sb.Length > 0 && sb[sb.Length - 1] > ch) //比较当前字母和 sb的最后一个字母，当前字母小的话（趋于a),进入处理
                    {
                        int lastIndex = sb[sb.Length - 1] - 'a'; //算出sb的最后一个字母的索引

                        if (num[lastIndex] > 0) //最后一个字母出现次数 > 0
                        {
                            Print("" + i + "" + ch + "| sb = {0} . Remove {1} in sb last = ", sb.ToString() , num[lastIndex]);
                            vis[lastIndex] = false;
                            sb.Remove(sb.Length - 1, 1);//sb.deleteCharAt(sb.Length - 1);
                            
                        }
                        else
                        {
                            break;
                        }
                    }
                    vis[cIndex] = true; //设置为true代表已经出现该字母了

                    sb.Append(ch);
                    Print("" + i + "" + ch +  "| sb = {0} . Add {1} to sb last = ", sb.ToString(), ch);
                }
                num[cIndex] -= 1; //没处理一次，对对应字母的Count减一; 该Count决定着是否要从sb中删除字母。
            }
            Print("num = {0} . vis = {1}", GetArrayStr(num), GetArrayStr(vis));
            return sb.ToString();
        }
    }
}
