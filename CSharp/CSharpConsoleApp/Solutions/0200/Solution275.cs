﻿using System;
namespace CSharpConsoleApp.Solutions
{
    /*
     * @lc app=leetcode.cn id=275 lang=csharp
     *
     * [275] H 指数 II
     *
     * https://leetcode-cn.com/problems/h-index-ii/description/
     *
     * Category	Difficulty	Likes	Dislikes
     * algorithms	Medium (41.23%)	109	-
     * Tags
     * binary-search
     * 
     * Companies
     * facebook
     * 
     * Total Accepted:    22.1K
     * Total Submissions: 53.5K
     * Testcase Example:  '[0,1,3,5,6]'
     *
     * 给定一位研究者论文被引用次数的数组（被引用次数是非负整数），数组已经按照 升序排列 。编写一个方法，计算出研究者的 h 指数。
     * 
     * h 指数的定义: “h 代表“高引用次数”（high citations），一名科研人员的 h 指数是指他（她）的 （N 篇论文中）总共有 h
     * 篇论文分别被引用了至少 h 次。（其余的 N - h 篇论文每篇被引用次数不多于 h 次。）"
     * 
     * 
     * 示例:
     * 输入: citations = [0,1,3,5,6]
     * 输出: 3 
     * 解释: 给定数组表示研究者总共有 5 篇论文，每篇论文相应的被引用了 0, 1, 3, 5, 6 次。
     * 由于研究者有 3 篇论文每篇至少被引用了 3 次，其余两篇论文每篇被引用不多于 3 次，所以她的 h 指数是 3。
     * 
     * 
     * 说明:
     * 如果 h 有多有种可能的值 ，h 指数是其中最大的那个。
     *
     * 
     * 进阶：
     * 这是 H 指数 的延伸题目，本题中的 citations 数组是保证有序的。
     * 你可以优化你的算法到对数时间复杂度吗？
     */

    // @lc code=start
    public class Solution275 : SolutionBase
    {
        /// <summary>
        /// 难度
        /// </summary>
        public override Difficulity GetDifficulity() { return Difficulity.Medium; }
        /// <summary>
        /// 关键字:
        /// </summary>
        public override string[] GetKeyWords() { return new string[] { "直方图" }; }
        /// <summary>
        /// 标签： 
        /// </summary>
        public override Tag[] GetTags() { return new Tag[] { Tag.HashTable, Tag.Sort }; }

        public override bool Test(System.Diagnostics.Stopwatch sw)
        {
            bool isSuccess = true;
            isSuccess &= (HIndex(new int[] { 0, 1, 3, 5, 6 }) == 3);
            //isSuccess &= (HIndex(new int[] { 1,3,1 }) == 1);
            return isSuccess;
        }

        /// <summary>
        /// 与Solution274的区别为：数组已经按照 升序排列
        ///
        /// 83/83 cases passed (100 ms)
        ///Your runtime beats 100 % of csharp submissions
        ///Your memory usage beats 66.67 % of csharp submissions(29.4 MB)
        /// </summary>
        /// <param name="citations"></param>
        /// <returns></returns>
        public int HIndex(int[] citations)
        {
            //citations为已经排过序的数字。
            int n = citations.Length;
            // 线性扫描找出最大的 i
            int i = 0;
            while (i < n && citations[n - 1 - i] > i) //citations[n - 1 - i] > i 代表 H指数
            {
                i++;
            }
            return i;
        }
    }
    // @lc code=end


}
