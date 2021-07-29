using System;
using System.Collections.Generic;
namespace CSharpConsoleApp.Solutions
{
    /*
     * @lc app=leetcode.cn id=454 lang=csharp
     *
     * [454] 四数相加 II
     *
     * https://leetcode-cn.com/problems/4sum-ii/description/
     *
     * Category	Difficulty	Likes	Dislikes
     * algorithms	Medium (59.64%)	388	-
     * Tags
     * hash-table | binary-search
     * 
     * Companies
     * Unknown
     * 
     * Total Accepted:    72K
     * Total Submissions: 120.7K
     * Testcase Example:  '[1,2]\n[-2,-1]\n[-1,2]\n[0,2]'
     *
     * 给定四个包含整数的数组列表 A , B , C , D ,计算有多少个元组 (i, j, k, l) ，使得 A[i] + B[j] + C[k] +
     * D[l] = 0。
     * 
     * 为了使问题简单化，所有的 A, B, C, D 具有相同的长度 N，且 0 ≤ N ≤ 500 。所有整数的范围在 -2^28 到 2^28 - 1
     * 之间，最终结果不会超过 2^31 - 1 。
     * 
     * 例如:
     * 
     * 
     * 输入:
     * A = [ 1, 2]
     * B = [-2,-1]
     * C = [-1, 2]
     * D = [ 0, 2]
     * 
     * 输出:
     * 2
     * 
     * 解释:
     * 两个元组如下:
     * 1. (0, 0, 0, 1) -> A[0] + B[0] + C[0] + D[1] = 1 + (-2) + (-1) + 2 = 0
     * 2. (1, 1, 0, 0) -> A[1] + B[1] + C[0] + D[0] = 2 + (-1) + (-1) + 0 = 0
     */

    // @lc code=start
    public class Solution454 : SolutionBase
    {
        /// <summary>
        /// 难度
        /// </summary>
        public override Difficulity GetDifficulity() { return Difficulity.Medium; }
        /// <summary>
        /// 关键字:
        /// </summary>
        public override string[] GetKeyWords() { return new string[] { }; }
        /// <summary>
        /// 标签：
        /// </summary>
        public override Tag[] GetTags() { return new Tag[] { Tag.HashTable, Tag.BinarySearch }; }

        public override bool Test(System.Diagnostics.Stopwatch sw)
        {
            bool isSuccess = true;
            //TODO
            return isSuccess;
        }

        /// <summary>
        /// 作者：LeetCode - Solution
        ///  链接：https://leetcode-cn.com/problems/4sum-ii/solution/si-shu-xiang-jia-ii-by-leetcode-solution/
        ///  
        ///  132/132 cases passed (324 ms)
        ///  Your runtime beats 89.19 % of csharp submissions
        ///  Your memory usage beats 24.32 % of csharp submissions(27.9 MB)
        /// </summary>
        /// <param name="A"></param>
        /// <param name="B"></param>
        /// <param name="C"></param>
        /// <param name="D"></param>
        /// <returns></returns>
        public int FourSumCount(int[] A, int[] B, int[] C, int[] D)
        {
            Dictionary<int, int> countAB = new Dictionary<int, int>();
            foreach (int u in A)
            {
                foreach (int v in B)
                {
                    if(!countAB.ContainsKey(u + v))
                    {
                        countAB.Add(u + v, 0);
                    }
                    countAB[u + v] += 1;
                }
            }
            int ans = 0;
            foreach (int u in C)
            {
                foreach (int v in D)
                {
                    if (countAB.ContainsKey(-u-v))
                    {
                        ans += countAB[-u-v];
                    }
                }
            }
            return ans;
        }
    }
    // @lc code=end


}
