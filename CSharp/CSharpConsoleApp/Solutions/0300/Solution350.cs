using System;
using System.Collections.Generic;
namespace CSharpConsoleApp.Solutions
{
    /*
 * @lc app=leetcode.cn id=350 lang=csharp
 *
 * [350] 两个数组的交集 II
 *
 * https://leetcode-cn.com/problems/intersection-of-two-arrays-ii/description/
 *
 * Category	Difficulty	Likes	Dislikes
 * algorithms	Easy (54.51%)	511	-
 * Tags
 * hash-table | two-pointers | binary-search | sort
 * 
 * Companies
 * Unknown
 * 
 * Total Accepted:    208.8K
 * Total Submissions: 382.9K
 * Testcase Example:  '[1,2,2,1]\n[2,2]'
 *
 * 给定两个数组，编写一个函数来计算它们的交集。
 * 
 * 
 * 
 * 示例 1：
 * 
 * 输入：nums1 = [1,2,2,1], nums2 = [2,2]
 * 输出：[2,2]
 * 
 * 
 * 示例 2:
 * 
 * 输入：nums1 = [4,9,5], nums2 = [9,4,9,8,4]
 * 输出：[4,9]
 * 
 * 
 * 
 * 说明：
 * 
 * 
 * 输出结果中每个元素出现的次数，应与元素在两个数组中出现次数的最小值一致。
 * 我们可以不考虑输出结果的顺序。
 * 
 * 
 * 进阶：
 * 
 * 
 * 如果给定的数组已经排好序呢？你将如何优化你的算法？
 * 如果 nums1 的大小比 nums2 小很多，哪种方法更优？
 * 如果 nums2 的元素存储在磁盘上，内存是有限的，并且你不能一次加载所有的元素到内存中，你该怎么办？
 * 
 * 
 */

    // @lc code=start
    public class Solution350 : SolutionBase
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
        /// 标签：hash-table | two-pointers | binary-search | sort
        /// </summary>
        public override Tag[] GetTags() { return new Tag[] { Tag.HashTable, Tag.TwoPointers, Tag.BinarySearch, Tag.Sort }; }

        public override bool Test(System.Diagnostics.Stopwatch sw)
        {
            bool isSuccess = true;
            int[] nums1, nums2;
            int[] result, checkResult;

            nums1 = new int[] { 1, 2, 2, 1 }; nums2 = new int[] { 2, 2 };
            checkResult = new int[] { 2, 2 };
            result = Intersect(nums1, nums2);
            isSuccess &= IsArraySame(result, checkResult, false);
            Print("isSuccess = {0} result = {1} | checkResult = {2}", isSuccess, GetArrayStr(result), GetArrayStr(checkResult));

            nums1 = new int[] { 4, 9, 5 }; nums2 = new int[] { 9, 4, 9, 8, 4 };
            checkResult = new int[] { 4, 9 };
            result = Intersect(nums1, nums2);
            isSuccess &= IsArraySame(result, checkResult, false);
            Print("isSuccess = {0} result = {1} | checkResult = {2}", isSuccess, GetArrayStr(result), GetArrayStr(checkResult));

            nums1 = new int[] { 1, 2, 2, 1 }; nums2 = new int[] { 2, 2 };
            checkResult = new int[] { 2, 2 };
            result = Intersect(nums1, nums2);
            isSuccess &= IsArraySame(result, checkResult, false);
            Print("isSuccess = {0} result = {1} | checkResult = {2}", isSuccess, GetArrayStr(result), GetArrayStr(checkResult));

            nums1 = new int[] { 1, 2 }; nums2 = new int[] { 1, 1 };
            checkResult = new int[] { 1 };
            result = Intersect(nums1, nums2);
            isSuccess &= IsListSame(result, checkResult, false);
            Print("isSuccess = {0} result = {1} | checkResult = {2}", isSuccess, GetArrayStr(result), GetArrayStr(checkResult));

            nums1 = new int[] { 3,1,2 }; nums2 = new int[] { 1 };
            checkResult = new int[] { 1 };
            result = Intersect(nums1, nums2);
            isSuccess &= IsListSame(result, checkResult, false);
            Print("isSuccess = {0} result = {1} | checkResult = {2}", isSuccess, GetArrayStr(result), GetArrayStr(checkResult));

            return isSuccess;
        }

        /// <summary>
        /// 55/55 cases passed (284 ms)
        /// Your runtime beats 58.51 % of csharp submissions
        /// Your memory usage beats 63.47 % of csharp submissions(30.8 MB)
        /// </summary>
        /// <param name="nums1"></param>
        /// <param name="nums2"></param>
        /// <returns></returns>
        public int[] Intersect(int[] nums1, int[] nums2)
        {
            Array.Sort(nums1);
            Array.Sort(nums2);

            List<int> list = new List<int>();

            int n1 = nums1.Length;
            int n2 = nums2.Length;

            int[] numsMin = n1 > n2 ? nums2 : nums1;
            int[] numsMax = n1 > n2 ? nums1 : nums2;
            n1 = numsMin.Length;
            n2 = numsMax.Length;

            int i = 0, j = 0;
            while(true)
            {
                if(numsMin[i] == numsMax[j])
                {
                    list.Add(numsMin[i]);
                    
                    if (i == n1-1 || j == n2-1) break;
                    if (i < n1-1) i++;
                    if (j < n2-1) j++;
                }
                else if (numsMin[i] < numsMax[j])
                {
                    if (i < n1-1) i++;
                    else break;
                }
                else //if (numsMin[i] < numsMax[j])
                {
                    if (j < n2-1) j++;
                    else break;
                }
            }
            return list.ToArray();
        }
    }
    // @lc code=end


}
