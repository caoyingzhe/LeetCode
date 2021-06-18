using System;
using System.Collections.Generic;
namespace CSharpConsoleApp.Solutions
{
    /*
     * @lc app=leetcode.cn id=451 lang=csharp
     *
     * [451] 根据字符出现频率排序
     *
     * https://leetcode-cn.com/problems/sort-characters-by-frequency/description/
     *
     * Category	Difficulty	Likes	Dislikes
     * algorithms	Medium (67.46%)	255	-
     * Tags
     * hash-table | heap
     * 
     * Companies
     * amazon | google
     * 
     * Total Accepted:    48.4K
     * Total Submissions: 71.7K
     * Testcase Example:  '"tree"'
     *
     * 给定一个字符串，请将字符串里的字符按照出现的频率降序排列。
     * 
     * 示例 1:
     * 
     * 
     * 输入:
     * "tree"
     * 
     * 输出:
     * "eert"
     * 
     * 解释:
     * 'e'出现两次，'r'和't'都只出现一次。
     * 因此'e'必须出现在'r'和't'之前。此外，"eetr"也是一个有效的答案。
     * 
     * 
     * 示例 2:
     * 输入:
     * "cccaaa"
     * 输出:
     * "cccaaa"
     * 
     * 解释:
     * 'c'和'a'都出现三次。此外，"aaaccc"也是有效的答案。
     * 注意"cacaca"是不正确的，因为相同的字母必须放在一起。
     * 
     * 
     * 示例 3:
     * 输入:
     * "Aabb"
     * 
     * 输出:
     * "bbAa"
     * 
     * 解释:
     * 此外，"bbaA"也是一个有效的答案，但"Aabb"是不正确的。
     * 注意'A'和'a'被认为是两种不同的字符。
     * 
     * 
     */
    public class Solution451 : SolutionBase
    {
        /// <summary>
        /// 难易度:
        /// </summary>
        public override Difficulity GetDifficulity() { return Difficulity.Medium; }
        /// <summary>
        /// 关键字:
        /// </summary>
        public override string[] GetKeyWords() { return new string[] { }; }
        /// <summary>
        /// 标签： 图
        /// </summary>
        public override Tag[] GetTags() { return new Tag[] { Tag.Array }; }

        public override bool Test(System.Diagnostics.Stopwatch sw)
        {
            bool isSuccess = true;
            string result, checkResult;

            checkResult = "bbaA";
            result = FrequencySort("Aabb");
            isSuccess = result == checkResult;
            Print(" isSuccess = {0}, | result = {1} | checkResult ={2}", isSuccess, result, checkResult);
            return isSuccess;
        }
        /// <summary>
        /// 32/32 cases passed (124 ms)
        /// Your runtime beats 41.3 % of csharp submissions
        /// Your memory usage beats 82.61 % of csharp submissions(26.1 MB)
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public string FrequencySort(string s)
        {
            Dictionary<char, int> dic = new Dictionary<char, int>();
            foreach (var c in s)
            {
                if (dic.ContainsKey(c))
                {
                    dic[c]++;
                }
                else
                {
                    dic.Add(c, 1);
                }
            }//全部加到字典中储存。
            List<int[]> list = new List<int[]>();
            foreach (var kvp in dic)
            {
                int[] temp = new int[] { 0, 0};
                temp[0] = kvp.Key - 'a';
                temp[1] = kvp.Value;
                list.Add(temp);
            }//将字典里储存的数据变成CharAndTimes类然后转移到链表里

            list.Sort((p1, p2) => p2[1] -p1[1]);//自定义排序顺序，按照每个元素的Times从大到小排
            System.Text.StringBuilder sb = new System.Text.StringBuilder();//打印成字符串输出。
            foreach (var i in list)
            {
                for (int j = 0; j < i[1]; j++)
                {
                    sb.Append((char)(i[0] + 'a'));
                }
            }
            return sb.ToString();
        }
    }
}
