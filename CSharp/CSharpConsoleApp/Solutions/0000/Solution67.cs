using System;
using System.Collections.Generic;
namespace CSharpConsoleApp.Solutions
{
    /*
     * @lc app=leetcode.cn id=67 lang=csharp
     *
     * [67] 二进制求和
     *
     * https://leetcode-cn.com/problems/add-binary/description/
     *
     * Category	Difficulty	Likes	Dislikes
     * algorithms	Easy (54.43%)	612	-
     * Tags
     * math | string
     * 
     * Companies
     * facebook
     * 
     * Total Accepted:    167.5K
     * Total Submissions: 307.7K
     * Testcase Example:  '"11"\n"1"'
     *
     * 给你两个二进制字符串，返回它们的和（用二进制表示）。
     * 
     * 输入为 非空 字符串且只包含数字 1 和 0。
     * 
     * 
     * 
     * 示例 1:
     * 
     * 输入: a = "11", b = "1"
     * 输出: "100"
     * 
     * 示例 2:
     * 
     * 输入: a = "1010", b = "1011"
     * 输出: "10101"
     * 
     * 
     * 
     * 提示：
     * 
     * 
     * 每个字符串仅由字符 '0' 或 '1' 组成。
     * 1 <= a.length, b.length <= 10^4
     * 字符串如果不是 "0" ，就都不含前导零。
     * 
     * 
     */

    public class Solution67 : SolutionBase
    {
        /// <summary>
        /// 难易度:
        /// </summary>
        public override Difficulity GetDifficulity() { return Difficulity.Easy; }
        /// <summary>
        /// 关键字:
        /// </summary>
        public override string[] GetKeyWords() { return new string[] { "BinarySearch" }; }
        /// <summary>
        /// 标签： 图
        /// </summary>
        public override Tag[] GetTags() { return new Tag[] { Tag.BinarySearch }; }
        public override bool Test(System.Diagnostics.Stopwatch sw)
        {
            Print(AddBinary("11", "1"));
            return true;
        }


        public string AddStringNumbers(string a, string b)
        {
            int alen = a.Length, blen = b.Length;
            int maxLen = Math.Max(alen, blen);

            int next = 0;

            //System.Text.StringBuilder sb = new System.Text.StringBuilder();
            List<char> list = new List<char>();
            for (int i = 0; i < maxLen; i++)
            {
                int v1 = i + 1 > alen ? 0 : a[alen - 1 - i] - '0';
                int v2 = i + 1 > blen ? 0 : b[blen - 1 - i] - '0';

                int sum = v1 + v2 + next;
                next = sum >= 10 ? 1 : 0;
                v1 = (sum) % 10;

                list.Insert(0, (char)(v1 + '0'));
            }
            if (next != 0)
                list.Insert(0, (char)(next + '0'));

            return new string(list.ToArray());
        }

        /// <summary>
        /// 重点知识： 字符串要倒序处理；合成字符串要翻转处理；
        /// 
        /// 294/294 cases passed (104 ms)
        /// Your runtime beats 60.33 % of csharp submissions
        /// Your memory usage beats 85.95 % of csharp submissions(24.7 MB)
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public string AddBinary(string a, string b)
        {
            int alen = a.Length, blen = b.Length;
            int maxLen = Math.Max(alen, blen);

            int next = 0;

            //System.Text.StringBuilder sb = new System.Text.StringBuilder();
            List<char> list = new List<char>();
            for(int i= 0; i< maxLen; i++)
            {
                int v1 = i + 1 > alen ? 0 : a[alen -1 -i] - '0';
                int v2 = i + 1 > blen ? 0 : b[blen -1 -i] - '0';

                int sum = v1 + v2 + next;
                next = sum >= 2 ? 1 : 0;
                v1 = (sum) % 2;

                list.Insert(0, (char)(v1 + '0'));
            }
            if (next != 0)
                list.Insert(0, (char)(next + '0'));

            return new string(list.ToArray());
        }
    }
}
