using System;
using System.Collections.Generic;
namespace CSharpConsoleApp.Solutions
{
    /*
     * @lc app=leetcode.cn id=88 lang=csharp
     *
     * [88] 合并两个有序数组
     *
     * https://leetcode-cn.com/problems/merge-sorted-array/description/
     *
     * Category	Difficulty	Likes	Dislikes
     * algorithms	Easy (50.92%)	956	-
     * Tags
     * array | two-pointers
     * 
     * Companies
     * bloomberg | facebook | microsoft
     * 
     * Total Accepted:    361.4K
     * Total Submissions: 709.8K
     * Testcase Example:  '[1,2,3,0,0,0]\n3\n[2,5,6]\n3'
     *
     * 给你两个有序整数数组 nums1 和 nums2，请你将 nums2 合并到 nums1 中，使 nums1 成为一个有序数组。
     * 
     * 初始化 nums1 和 nums2 的元素数量分别为 m 和 n 。你可以假设 nums1 的空间大小等于 m + n，这样它就有足够的空间保存来自
     * nums2 的元素。
     * 
     * 
     * 示例 1：
     * 输入：nums1 = [1,2,3,0,0,0], m = 3, nums2 = [2,5,6], n = 3
     * 输出：[1,2,2,3,5,6]
     * 
     * 
     * 示例 2：
     * 输入：nums1 = [1], m = 1, nums2 = [], n = 0
     * 输出：[1]
     *
     * 提示：
     * nums1.length == m + n
     * nums2.length == n
     * 0 <= m, n <= 200
     * 1 <= m + n <= 200
     * -10^9 <= nums1[i], nums2[i] <= 10^9
     */
    public class Solution88
    {
        /// <summary>
        /// 时间复杂度：O((m+n)\log(m+n))O((m+n)log(m+n))。
        /// 空间复杂度：O(\log(m+n))O(log(m+n))。
        /// </summary>
        /// <param name="nums1"></param>
        /// <param name="m"></param>
        /// <param name="nums2"></param>
        /// <param name="n"></param>
        public void Merge_Common(int[] nums1, int m, int[] nums2, int n)
        {
            for (int i = 0; i != n; ++i)
            {
                nums1[m + i] = nums2[i];
            }
            Array.Sort(nums1);
        }

        /// <summary>
        /// 双指针
        /// 时间复杂度：O(m+n)。
        /// 空间复杂度：O(m+n)
        /// </summary>
        /// <param name="nums1"></param>
        /// <param name="m"></param>
        /// <param name="nums2"></param>
        /// <param name="n"></param>
        public void Merge_DoublePointer(int[] nums1, int m, int[] nums2, int n)
        {
            for (int i = 0; i != n; ++i)
            {
                nums1[m + i] = nums2[i];
            }
            Array.Sort(nums1);
        }

        /// <summary>
        /// 逆向双指针
        ///
        /// 时间复杂度：O(m+n)。
        /// 空间复杂度：O(1)。
        /// 作者：LeetCode-Solution
        /// 链接：https://leetcode-cn.com/problems/merge-sorted-array/solution/he-bing-liang-ge-you-xu-shu-zu-by-leetco-rrb0/
        /// 
        /// </summary>
        /// <param name="nums1"></param>
        /// <param name="m"></param>
        /// <param name="nums2"></param>
        /// <param name="n"></param>
        public void Merge(int[] nums1, int m, int[] nums2, int n)
        {
            int p1 = m - 1, p2 = n - 1;
            int tail = m + n - 1;
            int cur;
            while (p1 >= 0 || p2 >= 0)
            {
                if (p1 == -1)
                {
                    cur = nums2[p2--];
                }
                else if (p2 == -1)
                {
                    cur = nums1[p1--];
                }
                else if (nums1[p1] > nums2[p2])
                {
                    cur = nums1[p1--];
                }
                else
                {
                    cur = nums2[p2--];
                }
                nums1[tail--] = cur;
            }
        }

    }
}
