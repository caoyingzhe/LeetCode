using System;
using System.Collections.Generic;
namespace CSharpConsoleApp.Solutions
{
    /*
 * @lc app=leetcode.cn id=131 lang=csharp
 *
 * [131] 分割回文串
 *
 * https://leetcode-cn.com/problems/palindrome-partitioning/description/
 *
 * Category	Difficulty	Likes	Dislikes
 * algorithms	Medium (72.44%)	769	-
 * Tags
 * backtracking
 * 
 * Companies
 * bloomberg
 * 
 * Total Accepted:    116.1K
 * Total Submissions: 160.2K
 * Testcase Example:  '"aab"'
 *
 * 给你一个字符串 s，请你将 s 分割成一些子串，使每个子串都是 回文串 。返回 s 所有可能的分割方案。
 * 回文串 是正着读和反着读都一样的字符串。
 * 
 * 
 * 示例 1：
 * 输入：s = "aab"
 * 输出：[["a","a","b"],["aa","b"]]
 * 
 * 示例 2：
 * 输入：s = "a"
 * 输出：[["a"]]
 * 
 * 提示：
 * 1 <= s.length <= 16
 * s 仅由小写英文字母组成
 */

    // @lc code=start
    public class Solution131 : SolutionBase
    {
        /// <summary>
        /// 难度
        /// </summary>
        public override Difficulity GetDifficulity() { return Difficulity.Medium; }
        /// <summary>
        /// 关键字:
        /// </summary>
        public override string[] GetKeyWords() { return new string[] { "回文串" }; }
        /// <summary>
        /// 标签：
        /// </summary>
        public override Tag[] GetTags() { return new Tag[] { Tag.Backtracking }; }

        
        /// <summary>
        /// </summary>
        /// <param name="sw"></param>
        /// <returns></returns>
        public override bool Test(System.Diagnostics.Stopwatch sw)
        {
            bool isSuccess = true;

            string s;
            IList<IList<string>> result, checkResult;

            s = "aab";
            result = Partition(s);
            checkResult = new string[][]
            {
                new string[] { "a", "a" , "b"},
                new string[] { "aa", "b" },
            };
            isSuccess &= IsArray2DSame(result, checkResult, true);
            PrintResult(isSuccess, GetArray2DStr(result), GetArray2DStr(checkResult));

            s = "a";
            result = Partition(s);
            checkResult = new string[][]
            {
                new string[] { "a"},
            };
            isSuccess &= IsArray2DSame(result, checkResult);
            PrintResult(isSuccess, GetArray2DStr(result), GetArray2DStr(checkResult));

            return isSuccess;
        }

        //作者：LeetCode - Solution
        //链接：https://leetcode-cn.com/problems/palindrome-partitioning/solution/fen-ge-hui-wen-chuan-by-leetcode-solutio-6jkv/

        bool[][] f;
        List<IList<String>> ret = new List<IList<String>>();
        List<String> ans = new List<String>();
        int n;

        /// <summary>
        /// 32/32 cases passed (812 ms)
        /// Your runtime beats 85.87 % of csharp submissions
        /// Your memory usage beats 32.61 % of csharp submissions(52.6 MB)
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public IList<IList<string>> Partition(string s)
        {
            ret = new List<IList<String>>();
            ans = new List<String>();

            n = s.Length;
            if(n == 1)
            {
                ret.Add(new string[] { s });
                return ret;
            }
            f = new bool[n][];
            for (int i = 0; i < n; ++i)
            {
                f[i] = new bool[n];
                for (int j = 0; j < n; j++)
                    f[i][j] = true;
            }

            for (int i = n - 1; i >= 0; --i)
            {
                for (int j = i + 1; j < n; ++j)
                {
                    f[i][j] = (s[i] == s[j]) && f[i + 1][j - 1];
                }
            }

            DFS(s, 0);
            return ret;
        }

        public void DFS(String s, int i)
        {
            if (i == n)
            {
                ret.Add(new List<String>(ans));
                return;
            }
            for (int j = i; j < n; ++j)
            {
                if (f[i][j])
                {
                    ans.Add(s.Substring(i, j + 1 - i));
                    DFS(s, j + 1);
                    ans.RemoveAt(ans.Count - 1);
                }
            }
        }


    }
    // @lc code=end


}
