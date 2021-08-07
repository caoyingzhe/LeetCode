using System;
using System.Collections.Generic;
namespace CSharpConsoleApp.Solutions
{
    /*
 * @lc app=leetcode.cn id=205 lang=csharp
 *
 * [205] 同构字符串
 *
 * https://leetcode-cn.com/problems/isomorphic-strings/description/
 *
 * Category	Difficulty	Likes	Dislikes
 * algorithms	Easy (50.04%)	364	-
 * Tags
 * hash-table
 * 
 * Companies
 * linkedin
 * 
 * Total Accepted:    102.6K
 * Total Submissions: 205K
 * Testcase Example:  '"egg"\n"add"'
 *
 * 给定两个字符串 s 和 t，判断它们是否是同构的。
 * 
 * 如果 s 中的字符可以按某种映射关系替换得到 t ，那么这两个字符串是同构的。
 * 
 * 
 * 每个出现的字符都应当映射到另一个字符，同时不改变字符的顺序。不同字符不能映射到同一个字符上，相同字符只能映射到同一个字符上，字符可以映射到自己本身。
 * 
 * 
 * 
 * 示例 1:
 * 输入：s = "egg", t = "add"
 * 输出：true
 * 
 * 
 * 示例 2：
 * 输入：s = "foo", t = "bar"
 * 输出：false
 * 
 * 示例 3：
 * 输入：s = "paper", t = "title"
 * 输出：true
 * 
 * 
 * 提示：
 * 可以假设 s 和 t 长度相同。
 */

    // @lc code=start
    public class Solution205 : SolutionBase
    {
        /// <summary>
        /// 难度
        /// </summary>
        public override Difficulity GetDifficulity() { return Difficulity.Easy; }
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
            bool result, checkResult;
            string s, t;

            s = "egg"; t = "add";
            checkResult = true;
            result = IsIsomorphic(s, t);
            isSuccess &= IsSame(result, checkResult);
            PrintResult(isSuccess, (result), (checkResult));

            s = "foo"; t = "bar";
            checkResult = false;
            result = IsIsomorphic(s, t);
            isSuccess &= IsSame(result, checkResult);
            PrintResult(isSuccess, (result), (checkResult));

            s = "paper"; t = "title";
            checkResult = true;
            result = IsIsomorphic(s, t);
            isSuccess &= IsSame(result, checkResult);
            PrintResult(isSuccess, (result), (checkResult));

            s = "badc"; t = "baba";
            checkResult = false;
            result = IsIsomorphic(s, t);
            isSuccess &= IsSame(result, checkResult);
            PrintResult(isSuccess, (result), (checkResult));

            s = "qwertyuiop[]asdfghjkl;'\\\\zxcvbnm,./";
            t = "',.pyfgcrl/=aoeuidhtns-\\\\;qjkxbmwvz";
            checkResult = true;
            result = IsIsomorphic(s, t);
            isSuccess &= IsSame(result, checkResult);
            PrintResult(isSuccess, (result), (checkResult));
            return isSuccess;
        }
        //该方案只适合只有字母的情况，不适合不包含字母的情况
        //public bool IsIsomorphic(string s, string t)
        //{
        //    if (s == null || t == null) return false;
        //    if (s.Length != t.Length) return false;

        //    int n = s.Length;

        //    //A=80，Z=105, a=112, z=137
        //    char[] map = new char[104];
        //    for (int i=0; i<n; i++)
        //    {
        //        int i1 = s[i] >= 'a' ? s[i] - 'a' : s[i] - 'A' + 26;
        //        int i2 = t[i] >= 'a' ? t[i] - 'a' : t[i] - 'A' + 26;
        //        if (map[i1] != 0 && map[i1] != t[i] || map[52+i2] != 0 && map[52 + i2] != s[i])
        //            return false;
        //        else
        //        {
        //            map[i1] = t[i];
        //            map[52 + i2] = s[i];
        //        }
        //    }
        //    return true;
        //}

        /// <summary>
        /// 双哈希表
        /// 39/39 cases passed (88 ms)
        /// Your runtime beats 89.71 % of csharp submissions
        /// Your memory usage beats 51.47 % of csharp submissions(23.6 MB)
        /// </summary>
        /// <param name="s"></param>
        /// <param name="t"></param>
        /// <returns></returns>
        public bool IsIsomorphic(string s, string t)
        {
            if (s == null || t == null) return false;
            if (s.Length != t.Length) return false;

            int n = s.Length;

            //A=80，Z=105, a=112, z=137
            Dictionary<int, int> map1 = new Dictionary<int, int>();
            Dictionary<int, int> map2 = new Dictionary<int, int>();
            for (int i = 0; i < n; i++)
            {
                if (map1.ContainsKey(s[i]))
                {
                    if (map1[s[i]] != t[i])
                        return false;
                }
                else
                {
                    map1.Add(s[i], t[i]);
                }

                if (map2.ContainsKey(t[i]))
                {
                    if (map2[t[i]] != s[i])
                        return false;
                }
                else
                {
                    map2.Add(t[i], s[i]);
                }
            }
            return true;
        }
    }
    // @lc code=end


}
