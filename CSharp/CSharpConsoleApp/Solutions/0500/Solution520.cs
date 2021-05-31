using System;
namespace CSharpConsoleApp.Solutions
{
    /*
     * @lc app=leetcode.cn id=520 lang=csharp
     *
     * [520] 检测大写字母
     *
     * https://leetcode-cn.com/problems/detect-capital/description/
     *
     * algorithms
     * Easy (56.11%)
     * Likes:    132
     * Dislikes: 0
     * Total Accepted:    35.8K
     * Total Submissions: 63.7K
     * Testcase Example:  '"USA"'
     *
     * 给定一个单词，你需要判断单词的大写使用是否正确。
     * 
     * 我们定义，在以下情况时，单词的大写用法是正确的：
     * 
     * 
     * 全部字母都是大写，比如"USA"。
     * 单词中所有字母都不是大写，比如"leetcode"。
     * 如果单词不只含有一个字母，只有首字母大写， 比如 "Google"。
     * 
     * 
     * 否则，我们定义这个单词没有正确使用大写字母。
     * 
     * 示例 1:
     * 输入: "USA"
     * 输出: True
     * 
     * 
     * 示例 2:
     * 输入: "FlaG"
     * 输出: False
     * 
     * 
     * 注意: 输入是由大写和小写拉丁字母组成的非空单词。
     * 
     */
    public class Solution520
    {
        /// <summary>
        /// 550/550 cases passed (84 ms)
        /// Your runtime beats 86.21 % of csharp submissions
        /// Your memory usage beats 51.72 % of csharp submissions(23.3 MB)
        /// </summary>
        /// <param name="word"></param>
        /// <returns></returns>
        public bool DetectCapitalUse(string word)
        {
            int n = word.Length;
            int upperCount = 0;
            bool fistUpper = false;
            for (int i = 0; i < n; i++)
            {
                char c = word[i];
                if (c - 'a' < 0)
                {
                    upperCount++;
                    if (i == 0) fistUpper = true;
                }
            }
            if (upperCount == 0) return true;
            if (upperCount == n) return true;
            if (fistUpper && upperCount == 1) return true;
            return false;
        }
    }
}
