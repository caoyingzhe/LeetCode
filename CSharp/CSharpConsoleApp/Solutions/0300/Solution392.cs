using System;
namespace CSharpConsoleApp.Solutions
{
    /*
 * @lc app=leetcode.cn id=392 lang=csharp
 *
 * [392] 判断子序列
 *
 * https://leetcode-cn.com/problems/is-subsequence/description/
 *
 * algorithms
 * Easy (51.21%)
 * Likes:    468
 * Dislikes: 0
 * Total Accepted:    130.2K
 * Total Submissions: 254.3K
 * Testcase Example:  '"abc"\n"ahbgdc"'
 *
 * 给定字符串 s 和 t ，判断 s 是否为 t 的子序列。
 * 
 * 
 * 字符串的一个子序列是原始字符串删除一些（也可以不删除）字符而不改变剩余字符相对位置形成的新字符串。（例如，"ace"是"abcde"的一个子序列，而"aec"不是）。
 * 
 * 进阶：
 * 
 * 如果有大量输入的 S，称作 S1, S2, ... , Sk 其中 k >= 10亿，你需要依次检查它们是否为 T
 * 的子序列。在这种情况下，你会怎样改变代码？
 * 
 * 致谢：
 * 
 * 特别感谢 @pbrother 添加此问题并且创建所有测试用例。
 * 
 * 
 * 
 * 示例 1：
 * 
 * 
 * 输入：s = "abc", t = "ahbgdc"
 * 输出：true
 * 
 * 
 * 示例 2：
 * 
 * 
 * 输入：s = "axc", t = "ahbgdc"
 * 输出：false
 * 
 * 
 * 
 * 
 * 提示：
 * 
 * 
 * 0 
 * 0 
 * 两个字符串都只由小写字符组成。
 * 
 * 
 */

    // @lc code=start
    public class Solution392 : SolutionBase
    {
        /// <summary>
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
        public override Tag[] GetTags() { return new Tag[] { Tag.DynamicProgramming, Tag.Greedy, Tag.BinarySearch }; }

        public int NULL = -1;
        /// <summary>
        /// </summary>
        /// <param name="sw"></param>
        /// <returns></returns>
        public override bool Test(System.Diagnostics.Stopwatch sw)
        {
            bool isSuccess = true;

            string ransomNote, magazine;
            bool result, checkResult;

            ransomNote = "abc"; magazine = "ahbgdc";
            checkResult = true;
            result = IsSubsequence(ransomNote, magazine);
            isSuccess &= IsSame(result, checkResult);
            PrintResult(isSuccess, (result), (checkResult));

            ransomNote = "axc"; magazine = "ahbgdc";
            checkResult = false;
            result = IsSubsequence(ransomNote, magazine);
            isSuccess &= IsSame(result, checkResult);
            PrintResult(isSuccess, (result), (checkResult));

            ransomNote = "agc"; magazine = "ahbgdccd";
            checkResult = true;
            result = IsSubsequence(ransomNote, magazine);
            isSuccess &= IsSame(result, checkResult);
            PrintResult(isSuccess, (result), (checkResult));

            return isSuccess;
        }

        /// <summary>
        /// 17/17 cases passed (96 ms)
        /// Your runtime beats 14.39 % of csharp submissions
        /// Your memory usage beats 79.55 % of csharp submissions(21.7 MB)
        /// </summary>
        /// <param name="s"></param>
        /// <param name="t"></param>
        /// <returns></returns>
        public bool IsSubsequence(string s, string t)
        {
            if (s.Length > t.Length) return false;
            int len = t.Length;
            int index = 0;
            for (int i = 0; i < len; i++)
            {
                if (t[i] == s[index])
                {
                    index++;
                    if (index == s.Length) return true;
                }
            }
            return false;
        }
    }
    // @lc code=end


}
