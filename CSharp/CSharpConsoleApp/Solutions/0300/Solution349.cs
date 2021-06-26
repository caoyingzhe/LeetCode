using System;
using System.Collections.Generic;
namespace CSharpConsoleApp.Solutions
{
    /*
     * @lc app=leetcode.cn id=349 lang=csharp
     *
     * [349] 两个数组的交集
     *
     * https://leetcode-cn.com/problems/intersection-of-two-arrays/description/
     *
     * Category	Difficulty	Likes	Dislikes
     * algorithms	Easy (73.69%)	378	-
     * Tags
     * hash-table | two-pointers | binary-search | sort
     * 
     * Companies
     * twosigma
     * 
     * Total Accepted:    187.9K
     * Total Submissions: 254.9K
     * Testcase Example:  '[1,2,2,1]\n[2,2]'
     *
     * 给定两个数组，编写一个函数来计算它们的交集。
     *
     * 
     * 示例 1：
     * 输入：nums1 = [1,2,2,1], nums2 = [2,2]
     * 输出：[2]
     * 
     * 
     * 示例 2：
     * 输入：nums1 = [4,9,5], nums2 = [9,4,9,8,4]
     * 输出：[9,4]
     * 
     * 
     * 说明：
     * 输出结果中的每个元素一定是唯一的。
     * 我们可以不考虑输出结果的顺序。
     */

    // @lc code=start
    public class Solution349 : SolutionBase
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
        public override Tag[] GetTags() { return new Tag[] { Tag.HashTable, Tag.TwoPointers, Tag.BinarySearch, Tag.Sort }; }

        public override bool Test(System.Diagnostics.Stopwatch sw)
        {
            bool isSuccess = true;
            //TODO
            return isSuccess;
        }

        //55/55 cases passed (268 ms)
        //Your runtime beats 98.9 % of csharp submissions
        //Your memory usage beats 30.22 % of csharp submissions(31.1 MB)
        public int[] Intersection(int[] nums1, int[] nums2)
        {
            Array.Sort(nums1);
            Array.Sort(nums2);
            int posi = 0, len1 = 0, len2 = 0;
            HashSet<int> result = new HashSet<int>();
            while (len1 < nums1.Length && len2 < nums2.Length)
            {
                if (nums1[len1] == nums2[len2])
                {
                    result.Add(nums1[len1]);
                    len1++;
                    len2++;
                }
                else if (nums1[len1] > nums2[len2])
                    len2++;
                else len1++;
            }
            int[] ans = new int[result.Count];
            posi = 0;
            foreach (int num in result)
                ans[posi++] = num;
            return ans;
        }
    }
    // @lc code=end


}
