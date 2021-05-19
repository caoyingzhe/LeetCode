using System;
using System.Collections.Generic;

namespace CSharpConsoleApp.Solutions
{
    /*
     * @lc app=leetcode.cn id=373 lang=csharp
     *
     * [373] 查找和最小的K对数字
     *
     * https://leetcode-cn.com/problems/find-k-pairs-with-smallest-sums/description/
     *
     * Category	Difficulty	Likes	Dislikes
     * algorithms	Medium (44.04%)	184	-
     * Tags
     * heap
     * 
     * Companies
     * google | uber
     * 
     * Total Accepted:    15.2K
     * Total Submissions: 34.5K
     * Testcase Example:  '[1,7,11]\n[2,4,6]\n3'
     *
     * 给定两个以升序排列的整形数组 nums1 和 nums2, 以及一个整数 k。
     * 
     * 定义一对值 (u,v)，其中第一个元素来自 nums1，第二个元素来自 nums2。
     * 
     * 找到和最小的 k 对数字 (u1,v1), (u2,v2) ... (uk,vk)。
     * 
     * 示例 1:
     * 
     * 输入: nums1 = [1,7,11], nums2 = [2,4,6], k = 3
     * 输出: [1,2],[1,4],[1,6]
     * 解释: 返回序列中的前 3 对数：
     * ⁠    [1,2],[1,4],[1,6],[7,2],[7,4],[11,2],[7,6],[11,4],[11,6]
     * 
     * 
     * 示例 2:
     * 
     * 输入: nums1 = [1,1,2], nums2 = [1,2,3], k = 2
     * 输出: [1,1],[1,1]
     * 解释: 返回序列中的前 2 对数：
     * [1,1],[1,1],[1,2],[2,1],[1,2],[2,2],[1,3],[1,3],[2,3]
     * 
     * 
     * 示例 3:
     * 
     * 输入: nums1 = [1,2], nums2 = [3], k = 3 
     * 输出: [1,3],[2,3]
     * 解释: 也可能序列中所有的数对都被返回:[1,3],[2,3]
     * 
     * 
     */
    public class Solution373 : SolutionBase
    {
        public override bool Test(System.Diagnostics.Stopwatch sw)
        {
            var result = KSmallestPairs(
                new int[] { 1, 2 },
                new int[] { 3 },
                3
            );

            Print(GetArray2DStr(result));


            return true;
        }

        /// <summary>
        /// 最笨最简单的方法，效率也最低。
        /// 25/25 cases passed (384 ms)
        /// Your runtime beats 12.5 % of csharp submissions
        /// Your memory usage beats 12.5 % of csharp submissions(59.2 MB)
        /// </summary>
        /// <param name="nums1"></param>
        /// <param name="nums2"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public IList<IList<int>> KSmallestPairs(int[] nums1, int[] nums2, int k)
        {
            List<IList<int>> res = new List<IList<int>>();

            //int i1 = 0;
            //int i2 = 0;
            //int i1Pre = -1;
            //int i2Pre = -1;
            int n1 = nums1.Length;
            int n2 = nums2.Length;
            //int count = 0;
            //
            //while (true)
            //{
            //    Print("i={0} j={1} Add [{2},{3} ]", i1, i2, nums1[i1], nums2[i2]);
            //    for (int i = i1Pre+1; i <= i1; i++)
            //        for (int j = i2Pre+1; j <= i2; j++)
            //            res.Add(new List<int>(new int[] { nums1[i], nums2[j] }));
            //
            //    count++;
            //
            //    if (count == k)
            //        break;
            //
            //    bool isEnd1 = i1 + 1 == n1;
            //    bool isEnd2 = i2 + 1 == n2;
            //    if (isEnd1 && isEnd2) break;
            //
            //    if (isEnd1)
            //    { i2Pre = i2; i2++; }
            //    else if (isEnd2)
            //    { i1Pre = i1; i1++; }
            //    else
            //    {
            //        int sum1 = nums1[i1 + 1] + nums2[i2];
            //        int sum2 = nums1[i1] + nums1[i2 + 1];
            //
            //        Print("                sum1 ={0} = {1} + {2} | sum2 ={3} = {4} + {5}", sum1, nums1[i1 + 1], nums2[i2], sum2, nums1[i1], nums1[i2 + 1]);
            //        if (sum1 > sum2)
            //        { i2Pre = i2;  i2++;}
            //        else if (sum1 > sum2)
            //        { i1Pre = i1; i1++;}
            //        else
            //        {
            //            if (nums1[i1 + 1] <= nums2[i2 + 1])
            //            { i1Pre = i1;  i1++;}
            //            else
            //            { i2Pre = i2;  i2++;}
            //        }
            //    }
            //}

            PriorityQueue<int[]> queue = new PriorityQueue<int[]>(new ComparerSolution373());
            foreach (int num1 in nums1)
            {
                foreach (int num2 in nums2)
                {
                    queue.Push(new int[] { num1, num2 });
                }
            }

            for(int i=0; i<k; i++)
            {
                if(queue.Count > 0)
                { 
                    int[] arr = queue.Pop();
                    Print(GetArrayStr(arr));
                    res.Add(new List<int>(arr));
                }
                else
                {
                    break;
                }
            }
            return res;
        }
    }
    public class ComparerSolution373 : IComparer<int[]>
    {
        public int Compare(int[] pair1, int[] pair2)
        {
            //在[239] 滑动窗口最大值中，[0]代表值，[1]代表数组中的索引
            //重大疑惑：官方提供的Java代码的比较方法是相反的。
            if(pair1[0] + pair1[1] < pair2[0] + pair2[1])
            {
                return 1;
            }
            else if (pair1[0] + pair1[1] > pair2[0] + pair2[1])
            {
                return -1;
            }
            else if(pair1[0] <= pair2[0])
            {
                return 1;
            }
            return -1;
        }
    }
}
