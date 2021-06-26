using System;
namespace CSharpConsoleApp.Solutions
{
    /*
 * @lc app=leetcode.cn id=493 lang=csharp
 *
 * [493] 翻转对
 *
 * https://leetcode-cn.com/problems/reverse-pairs/description/
 *
 * Category	Difficulty	Likes	Dislikes
 * algorithms	Hard (34.20%)	287	-
 * Tags
 * binary-search | divide-and-conquer | sort | binary-indexed-tree | segment-tree
 * 
 * Companies
 * google
 * 
 * Total Accepted:    25K
 * Total Submissions: 73K
 * Testcase Example:  '[1,3,2,3,1]'
 *
 * 给定一个数组 nums ，如果 i < j 且 nums[i] > 2*nums[j] 我们就将 (i, j) 称作一个重要翻转对。
 * 
 * 你需要返回给定数组中的重要翻转对的数量。
 * 
 * 示例 1:
 * 
 * 
 * 输入: [1,3,2,3,1]
 * 输出: 2
 * 
 * 
 * 示例 2:
 * 
 * 
 * 输入: [2,4,3,5,1]
 * 输出: 3
 * 
 * 
 * 注意:
 * 
 * 
 * 给定数组的长度不会超过50000。
 * 输入数组中的所有数字都在32位整数的表示范围内。
 * 
 * 
 */

    // @lc code=start
    public class Solution493 : SolutionBase
    {
        /// <summary>
        /// 难易度:
        /// </summary>
        public override Difficulity GetDifficulity() { return Difficulity.Hard; }
        /// <summary>
        /// 关键字:
        /// </summary>
        public override string[] GetKeyWords() { return new string[] { "归并排序" }; }
        /// <summary>
        /// 标签： 
        /// </summary>
        public override Tag[] GetTags() { return new Tag[] { Tag.BinarySearch, Tag.DivideAndConquer, Tag.Sort, Tag.BinaryIndexedTree, Tag.SegmentTree }; }

        public override bool Test(System.Diagnostics.Stopwatch sw)
        {
            bool isSuccess = false;


            return isSuccess;
        }
        /// <summary>
        /// 136/136 cases passed (280 ms)
        /// Your runtime beats 100 % of csharp submissions
        /// Your memory usage beats 100 % of csharp submissions(41.3 MB)
        /// 归并排序
        /// 作者：MiloMusiala
        /// 链接：https://leetcode-cn.com/problems/reverse-pairs/solution/cjavapython3-gui-bing-pai-xu-by-yanghk/
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int ReversePairs(int[] nums)
        {
            int n = nums.Length;
            if (n == 0) return 0;
            int[] numsSorted = new int[n];
            return MergeSort(nums, numsSorted, 0, n - 1);
        }

        /// <summary>
        /// 跨越A1和A2的答案
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        private int FindReversedPairs(int[] nums, int left, int right)
        {
            int res = 0, mid = left + (right - left) / 2;
            int i = left, j = mid + 1;
            for (; i <= mid; i++)
            {
                while (j <= right && (long)nums[i] > 2 * (long)nums[j])
                {
                    res += mid - i + 1;
                    j++;
                }
            }
            return res;
        }

        /// <summary>
        /// 归并答案
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="numsSorted"></param>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        private int MergeSort(int[] nums, int[] numsSorted, int left, int right)
        {
            if (left == right) return 0;

            int mid = left + (right - left) / 2;
            //对于数组A，假如把它分割成子数组A1和A2
            //A的答案 = A1的答案 + A2的答案 + 跨越A1和A2的答案
            int res = MergeSort(nums, numsSorted, left, mid) +
                      MergeSort(nums, numsSorted, mid + 1, right) +
                      FindReversedPairs(nums, left, right);
            int i = left, j = mid + 1;
            int k = left;

            while (i <= mid && j <= right)
            {
                if (nums[i] <= nums[j])
                    numsSorted[k++] = nums[i++];
                else
                    numsSorted[k++] = nums[j++];
            }
            while (i <= mid)
                numsSorted[k++] = nums[i++];
            while (j <= right)
                numsSorted[k++] = nums[j++];

            for (int ind = left; ind <= right; ind++)
                nums[ind] = numsSorted[ind];

            return res;
        }
    }
    // @lc code=end


}
