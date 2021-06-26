using System;
using System.Collections.Generic;
namespace CSharpConsoleApp.Solutions
{
    /*
 * @lc app=leetcode.cn id=347 lang=csharp
 *
 * [347] 前 K 个高频元素
 *
 * https://leetcode-cn.com/problems/top-k-frequent-elements/description/
 *
 * algorithms
 * Medium (62.11%)
 * Likes:    779
 * Dislikes: 0
 * Total Accepted:    169.6K
 * Total Submissions: 273.1K
 * Testcase Example:  '[1,1,1,2,2,3]\n2'
 *
 * 给你一个整数数组 nums 和一个整数 k ，请你返回其中出现频率前 k 高的元素。你可以按 任意顺序 返回答案。
 * 
 * 
 * 
 * 示例 1:
 * 
 * 
 * 输入: nums = [1,1,1,2,2,3], k = 2
 * 输出: [1,2]
 * 
 * 
 * 示例 2:
 * 
 * 
 * 输入: nums = [1], k = 1
 * 输出: [1]
 * 
 * 
 * 
 * 提示：
 * 
 * 
 * 1 
 * k 的取值范围是 [1, 数组中不相同的元素的个数]
 * 题目数据保证答案唯一，换句话说，数组中前 k 个高频元素的集合是唯一的
 * 
 * 
 * 
 * 
 * 进阶：你所设计算法的时间复杂度 必须 优于 O(n log n) ，其中 n 是数组大小。
 * 
 */

    // @lc code=start
    public class Solution347 : SolutionBase
    {
        /// <summary>
        /// 难度
        /// </summary>
        public override Difficulity GetDifficulity() { return Difficulity.Medium; }
        /// <summary>
        /// 关键字:
        /// </summary>
        public override string[] GetKeyWords() { return new string[] { "类似692",}; }
        /// <summary>
        /// 标签：
        /// </summary>
        public override Tag[] GetTags() { return new Tag[] { Tag.HashTable, Tag.Heap }; }

        /// <summary>
        /// 入度：每个课程节点的入度数量等于其先修课程的数量；
        /// 出度：每个课程节点的出度数量等于其指向的后续课程数量；
        /// 所以只有当一个课程节点的入度为零时，其才是一个可以学习的自由课程。
        ///
        /// 拓扑排序即是将一个无环有向图转换为线性排序的过程。
        /// </summary>
        /// <param name="sw"></param>
        /// <returns></returns>
        public override bool Test(System.Diagnostics.Stopwatch sw)
        {
            bool isSuccess = true;
            int[] nums; int k;

            IList<int> result, checkResult;

            nums = new int[] { 1, 1, 1, 3, 3, 2, 2, 2, 4, 5, 6 }; k = 2;
            checkResult = new int[] { 1, 2 };
            result = TopKFrequent(nums, k);
            isSuccess &= IsListSame(result, checkResult);
            Print("isSuccess = {0} | result= {1} | checkResult= {2} | ", isSuccess, GetArrayStr(result), GetArrayStr(checkResult));

            return isSuccess;
        }

        /// <summary>
        /// https://leetcode-cn.com/problems/top-k-frequent-elements/solution/qian-k-ge-gao-pin-yuan-su-by-leetcode-solution/
        /// 21/21 cases passed (280 ms)
        /// Your runtime beats 100 % of csharp submissions
        /// Your memory usage beats 38.05 % of csharp submissions(33.1 MB)
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public int[] TopKFrequent(int[] nums, int k)
        {
            Dictionary<int, int> occurrences = new Dictionary<int, int>();
            foreach (int num in nums)
            {
                if (!occurrences.ContainsKey(num))
                    occurrences.Add(num, 0);
                occurrences[num] += 1;
            }

            // int[] 的第一个元素代表数组的值，第二个元素代表了该值出现的次数
            PriorityQueue<int[]> queue = new PriorityQueue<int[]>(new ComparerSolution347());

            foreach (int num in occurrences.Keys)
            {
                int count = occurrences[num];
                if (queue.Count == k)
                {
                    if (queue.Peek()[1] < count)
                    {
                        queue.Poll();
                        queue.Offer(new int[]{num, count
                });
                    }
                }
                else
                {
                    queue.Offer(new int[] { num, count });
                }
            }
            int[] ret = new int[k];
            for (int i = 0; i < k; ++i)
            {
                ret[i] = queue.Poll()[0];
            }
            return ret;
        }

        public class ComparerSolution347 : IComparer<int[]>
        {
            public int Compare(int[] pair1, int[] pair2)
            {
                return pair2[1] - pair1[1];
            }
        }
        // @lc code=end
    }
}