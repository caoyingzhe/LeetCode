using System;
namespace CSharpConsoleApp.Solutions
{
    /*
     * @lc app=leetcode.cn id=125 lang=csharp
     *
     * [125] 验证回文串
     *
     * https://leetcode-cn.com/problems/valid-palindrome/description/
     *
     * algorithms
     * Easy (47.25%)
     * Likes:    390
     * Dislikes: 0
     * Total Accepted:    243.2K
     * Total Submissions: 514.4K
     * Testcase Example:  '"A man, a plan, a canal: Panama"'
     *
     * 给定一个字符串，验证它是否是回文串，只考虑字母和数字字符，可以忽略字母的大小写。
     * 
     * 说明：本题中，我们将空字符串定义为有效的回文串。
     * 
     * 示例 1:
     * 
     * 输入: "A man, a plan, a canal: Panama"
     * 输出: true
     * 
     * 
     * 示例 2:
     * 
     * 输入: "race a car"
     * 输出: false
     * 
     * 
     */

    // @lc code=start
    public class Solution125 : SolutionBase
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
        public override Tag[] GetTags() { return new Tag[] { Tag.String,  Tag.TwoPointers }; }

        public override bool Test(System.Diagnostics.Stopwatch sw)
        {
            bool isSuccess = true;

            //Print(IsPalindrome(null).ToString());
            //Print(IsPalindrome("").ToString());
            //Print(IsPalindrome("A").ToString());
            Print(IsPalindrome("A man, a plan, a canal: Panama").ToString());
            //Print(IsPalindrome("race a car").ToString());
            return isSuccess;
        }

        //480/480 cases passed(92 ms)
        //Your runtime beats 81.53 % of csharp submissions
        //Your memory usage beats 73.49 % of csharp submissions(24.3 MB)
        public bool IsPalindrome(string s)
        {
            if (s == null) return false;
            if (s == "") return true;
            int n = s.Length;
            int left = 0, right = n - 1;
            while (left < right)
            {
                if (char.IsLetterOrDigit(s[left]) && char.IsLetterOrDigit(s[right]))
                {
                    //Print("{0} : {1} | {2} : {3} ", s[left],char.ToLower(s[left]), s[right], char.ToLower(s[right]));
                    if (char.ToLower(s[left]) != char.ToLower(s[right]))
                    {
                        return false;
                    }
                    ++left;
                    --right;
                }
                else
                {
                    if (!char.IsLetterOrDigit(s[left])) left++;
                    if (!char.IsLetterOrDigit(s[right])) right--;
                }
            }
            return true;
        }
    }
    // @lc code=end


}
