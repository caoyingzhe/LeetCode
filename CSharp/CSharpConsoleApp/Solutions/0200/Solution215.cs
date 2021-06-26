using System;
namespace CSharpConsoleApp.Solutions
{
    /*
     * @lc app=leetcode.cn id=215 lang=csharp
     *
     * [215] 数组中的第K个最大元素
     *
     * https://leetcode-cn.com/problems/kth-largest-element-in-an-array/description/
     *
     * Category	Difficulty	Likes	Dislikes
     * algorithms	Medium (64.65%)	1140	-
     * Tags
     * divide-and-conquer | heap
     * 
     * Companies
     * amazon | apple | bloomberg | facebook | microsoft | pocketgems
     * 
     * Total Accepted:    354.9K
     * Total Submissions: 549K
     * Testcase Example:  '[3,2,1,5,6,4]\n2'
     *
     * 在未排序的数组中找到第 k 个最大的元素。请注意，你需要找的是数组排序后的第 k 个最大的元素，而不是第 k 个不同的元素。
     * 
     * 示例 1:
     * 
     * 输入: [3,2,1,5,6,4] 和 k = 2
     * 输出: 5
     * 
     * 
     * 示例 2:
     * 
     * 输入: [3,2,3,1,2,4,5,5,6] 和 k = 4
     * 输出: 4
     * 
     * 说明: 
     * 
     * 你可以假设 k 总是有效的，且 1 ≤ k ≤ 数组的长度。
     * 
     */

    // @lc code=start
    public class Solution215 : SolutionBase
    {
        /// <summary>
        /// 难易度:
        /// </summary>
        public override Difficulity GetDifficulity() { return Difficulity.Medium; }
        /// <summary>
        /// 关键字:
        /// </summary>
        public override string[] GetKeyWords() { return new string[] { "大根堆", "算法导论" }; }
        /// <summary>
        /// 标签： 
        /// </summary>
        public override Tag[] GetTags() { return new Tag[] { Tag.DivideAndConquer, Tag.Heap }; }

        public override bool Test(System.Diagnostics.Stopwatch sw)
        {
            bool isSuccess = false;

            // 初始化一个空的集合。
            RandomizedSet randomSet = new RandomizedSet();

            // 向集合中插入 1 。返回 true 表示 1 被成功地插入。
            Print("{0}", randomSet.Insert(1));

            // 返回 false ，表示集合中不存在 2 。
            Print("{0}", randomSet.Remove(2));

            // 向集合中插入 2 。返回 true 。集合现在包含 [1,2] 。
            Print("{0}", randomSet.Insert(2));

            // getRandom 应随机返回 1 或 2 。
            Print("{0}", randomSet.GetRandom());

            // 从集合中移除 1 ，返回 true 。集合现在包含 [2] 。
            Print("{0}", randomSet.Remove(1));

            // 2 已在集合中，所以返回 false 。
            Print("{0}", randomSet.Insert(2));

            // 由于 2 是集合中唯一的数字，getRandom 总是返回 2 。
            Print("{0}", randomSet.GetRandom());

            return isSuccess;
        }

        //作者：LeetCode-Solution
        //链接：https://leetcode-cn.com/problems/kth-largest-element-in-an-array/solution/shu-zu-zhong-de-di-kge-zui-da-yuan-su-by-leetcode-/
        /// <summary>
        /// 32/32 cases passed (116 ms)
        /// Your runtime beats 85.67 % of csharp submissions
        /// Your memory usage beats 28.94 % of csharp submissions(25.6 MB)
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public int FindKthLargest(int[] nums, int k)
        {
            int heapSize = nums.Length;
            BuildMaxHeap(nums, heapSize);
            for (int i = nums.Length - 1; i >= nums.Length - k + 1; --i)
            {
                swap(nums, 0, i);
                --heapSize;
                DFS(nums, 0, heapSize);
            }
            return nums[0];
        }

        public void BuildMaxHeap(int[] a, int heapSize)
        {
            for (int i = heapSize / 2; i >= 0; --i)
            {
                DFS(a, i, heapSize);
            }
        }

        //maxHeapify
        public void DFS(int[] a, int i, int heapSize)
        {
            int l = i * 2 + 1, r = i * 2 + 2, largest = i;
            if (l < heapSize && a[l] > a[largest])
            {
                largest = l;
            }
            if (r < heapSize && a[r] > a[largest])
            {
                largest = r;
            }
            if (largest != i)
            {
                swap(a, i, largest);
                DFS(a, largest, heapSize);
            }
        }

        public void swap(int[] a, int i, int j)
        {
            int temp = a[i];
            a[i] = a[j];
            a[j] = temp;
        }
    }
    // @lc code=end


}
