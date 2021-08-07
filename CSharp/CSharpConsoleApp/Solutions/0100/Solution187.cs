using System;
using System.Collections.Generic;
namespace CSharpConsoleApp.Solutions
{
    /*
     * @lc app=leetcode.cn id=187 lang=csharp
     *
     * [187] 重复的DNA序列
     *
     * https://leetcode-cn.com/problems/repeated-dna-sequences/description/
     *
     * Category	Difficulty	Likes	Dislikes
     * algorithms	Medium (47.71%)	176	-
     * Tags
     * hash-table | bit-manipulation
     * 
     * Companies
     * linkedin
     * 
     * Total Accepted:    35.9K
     * Total Submissions: 75.3K
     * Testcase Example:  '"AAAAACCCCCAAAAACCCCCCAAAAAGGGTTT"'
     *
     * 所有 DNA 都由一系列缩写为 'A'，'C'，'G' 和 'T' 的核苷酸组成，例如："ACGAATTCCG"。在研究 DNA 时，识别 DNA
     * 中的重复序列有时会对研究非常有帮助。
     * 编写一个函数来找出所有目标子串，目标子串的长度为 10，且在 DNA 字符串 s 中出现次数超过一次。
     * 
     * 
     * 示例 1：
     * 输入：s = "AAAAACCCCCAAAAACCCCCCAAAAAGGGTTT"
     * 输出：["AAAAACCCCC","CCCCCAAAAA"]
     * 
     * 
     * 示例 2：
     * 输入：s = "AAAAAAAAAAAAA"
     * 输出：["AAAAAAAAAA"]
     * 
     * 
     * 提示：
     * 0 <= s.length <= 10^5
     * s[i] 为 'A'、'C'、'G' 或 'T'
     * 
     * 
     */

    // @lc code=start
    public class Solution187 : SolutionBase
    {
        /// <summary>
        /// 难度
        /// </summary>
        public override Difficulity GetDifficulity() { return Difficulity.Medium; }
        /// <summary>
        /// 关键字:
        /// </summary>
        public override string[] GetKeyWords() { return new string[] { "", }; }
        /// <summary>
        /// 标签：
        /// </summary>
        public override Tag[] GetTags() { return new Tag[] { Tag.HashTable, Tag.BitManipulation }; }


        public override bool Test(System.Diagnostics.Stopwatch sw)
        {
            bool isSuccess = true;
            string s;
            IList<string> result, checkResult;

            s = "AAAAACCCCCAAAAACCCCCCAAAAAGGGTTT";
            checkResult = new string[] { "AAAAACCCCC", "CCCCCAAAAA" };
            result = FindRepeatedDnaSequences(s);
            isSuccess &= IsListSame(result, checkResult);
            PrintResult(isSuccess, GetArrayStr(result), GetArrayStr(checkResult));

            s = "AAAAAAAAAAAAA";
            checkResult = new string[] { "AAAAAAAAAA" };
            result = FindRepeatedDnaSequences(s);
            isSuccess &= IsListSame(result, checkResult);
            PrintResult(isSuccess, GetArrayStr(result), GetArrayStr(checkResult));

            return isSuccess;
        }

        //作者：lchaok
        //链接：https://leetcode-cn.com/problems/repeated-dna-sequences/solution/c-mao-mao-chong-hua-dong-chuang-kou-ha-x-3kea/
        public IList<string> FindRepeatedDnaSequences2(string s)
        {
            HashSet<string> once = new HashSet<string>();
            HashSet<string> second = new HashSet<string>();
            int size = s.Length;

            IList<string> res = new List<string>();
            if (size <= 10) return res;

            string temp = s.Substring(0, 10);
            once.Add(temp);
            for (int i = 10; i < size; ++i)
            {
                temp = temp.Substring(1, 9) + s[i];
                if (once.Contains(temp))
                {
                    if (!second.Contains(temp))
                        second.Add(temp);
                }
                else
                {
                    once.Contains(temp);
                }
            }

            foreach (string val in second)
            {
                res.Add(val);
            }
            return res;
        }

        //作者：CZp3DHvEnw
        //链接：https://leetcode-cn.com/problems/repeated-dna-sequences/solution/czi-dian-by-czp3dhvenw-z38q/
        /// <summary>
        /// 31/31 cases passed (264 ms)
        /// Your runtime beats 100 % of csharp submissions
        /// Your memory usage beats 23.08 % of csharp submissions(44.2 MB)
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public IList<string> FindRepeatedDnaSequences(string s)
        {
            IList<string> res = new List<string>();
            int size = 10;
            Dictionary<string, int> dic = new Dictionary<string, int>();

            for (int i = 0; i < s.Length - (size - 1); i++)
            {
                string temp = s.Substring(i, size);
                if (dic.ContainsKey(temp)) dic[temp] += 1;
                else
                {
                    dic.Add(temp, 1);
                }
            }
            foreach (KeyValuePair<string, int> a in dic)
            {
                if (a.Value > 1) res.Add(a.Key);
            }
            return res;
        }
    }
    // @lc code=end


}
