using System;
namespace CSharpConsoleApp.Solutions
{
    /*
 * @lc app=leetcode.cn id=383 lang=csharp
 *
 * [383] 赎金信
 *
 * https://leetcode-cn.com/problems/ransom-note/description/
 *
 * Category Difficulty  Likes Dislikes
 * algorithms Easy(57.97%)   158	-
 * Tags
 * string
 * 
 * Companies
 * apple
 * 
 * Total Accepted:    50.4K
 * Total Submissions: 86.8K
 * Testcase Example:  '"a"\n"b"'
 *
 * 给定一个赎金信 (ransom) 字符串和一个杂志(magazine)字符串，判断第一个字符串 ransom 能不能由第二个字符串 magazines
 * 里面的字符构成。如果可以构成，返回 true ；否则返回 false。
 * 
 * (题目说明：为了不暴露赎金信字迹，要从杂志上搜索各个需要的字母，组成单词来表达意思。杂志字符串中的每个字符只能在赎金信字符串中使用一次。)
 * 
 * 
 * 示例 1：
 * 输入：ransomNote = "a", magazine = "b"
 * 输出：false
 * 
 * 
 * 示例 2：
 * 输入：ransomNote = "aa", magazine = "ab"
 * 输出：false
 * 
 * 
 * 示例 3：
 * 输入：ransomNote = "aa", magazine = "aab"
 * 输出：true
 * 
 * 
 * 提示：
 * 你可以假设两个字符串均只含有小写字母。
 */

    // @lc code=start
    public class Solution383 : SolutionBase
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
        public override Tag[] GetTags() { return new Tag[] { Tag.Math, Tag.BinarySearch }; }

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

            ransomNote = "a"; magazine = "b";
            checkResult = false;
            result = CanConstruct(ransomNote, magazine);
            isSuccess &= IsSame(result, checkResult);
            PrintResult(isSuccess, (result), (checkResult));

            ransomNote = "aa"; magazine = "ab";
            checkResult = false;
            result = CanConstruct(ransomNote, magazine);
            isSuccess &= IsSame(result, checkResult);
            PrintResult(isSuccess, (result), (checkResult));


            ransomNote = "aa"; magazine = "aab";
            checkResult = true;
            result = CanConstruct(ransomNote, magazine);
            isSuccess &= IsSame(result, checkResult);
            PrintResult(isSuccess, (result), (checkResult));

            ransomNote = "abea"; magazine = "aacbe";
            checkResult = true;
            result = CanConstruct(ransomNote, magazine);
            isSuccess &= IsSame(result, checkResult);
            PrintResult(isSuccess, (result), (checkResult));


            return isSuccess;
        }
        /// <summary>
        /// 126/126 cases passed (116 ms)
        /// Your runtime beats 60.94 % of csharp submissions
        /// Your memory usage beats 92.19 % of csharp submissions(27.1 MB)
        /// </summary>
        /// <param name="ransomNote"></param>
        /// <param name="magazine"></param>
        /// <returns></returns>
        public bool CanConstruct(string ransomNote, string magazine)
        {
            if (magazine.Length < ransomNote.Length)
                return false;

            int[] arr = new int[52];
            int n = magazine.Length; int m = ransomNote.Length;
            for (int i = 0; i < n; i++)
            { 
                arr[magazine[i] - 'a']++;
                if(i < m) arr[ransomNote[i] - 'a' + 26]++;
            }
            for (int i=0;i<26;i++){
                if(arr[i]<arr[i+26]) return false;
            }
            return true;
        }
    }
// @lc code=end
}
