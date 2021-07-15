using System;
namespace CSharpConsoleApp.Solutions
{
    /*
 * @lc app=leetcode.cn id=532 lang=csharp
 *
 * [532] 数组中的 k-diff 数对
 *
 * https://leetcode-cn.com/problems/k-diff-pairs-in-an-array/description/
 *
 * Category	Difficulty	Likes	Dislikes
 * algorithms	Medium (36.85%)	132	-
 * Tags
 * array | two-pointers
 * 
 * Companies
 * amazon
 * 
 * Total Accepted:    24K
 * Total Submissions: 65.1K
 * Testcase Example:  '[3,1,4,1,5]\n2'
 *
 * 给定一个整数数组和一个整数 k，你需要在数组里找到 不同的 k-diff 数对，并返回不同的 k-diff 数对 的数目。
 * 这里将 k-diff 数对定义为一个整数对 (nums[i], nums[j])，并满足下述全部条件：
 * 
 * 
 * 0 <= i < j < nums.length
 * |nums[i] - nums[j]| == k
 * 注意，|val| 表示 val 的绝对值。
 *
 * 
 * 示例 1：
 * 输入：nums = [3, 1, 4, 1, 5], k = 2
 * 输出：2
 * 解释：数组中有两个 2-diff 数对, (1, 3) 和 (3, 5)。
 * 尽管数组中有两个1，但我们只应返回不同的数对的数量。
 * 
 * 
 * 示例 2：
 * 输入：nums = [1, 2, 3, 4, 5], k = 1
 * 输出：4
 * 解释：数组中有四个 1-diff 数对, (1, 2), (2, 3), (3, 4) 和 (4, 5)。
 * 
 * 
 * 示例 3：
 * 输入：nums = [1, 3, 1, 5, 4], k = 0
 * 输出：1
 * 解释：数组中只有一个 0-diff 数对，(1, 1)。
 * 
 * 
 * 示例 4：
 * 输入：nums = [1,2,4,4,3,3,0,9,2,3], k = 3
 * 输出：2
 * 
 * 
 * 示例 5：
 * 输入：nums = [-1,-2,-3], k = 1
 * 输出：2
 * 
 * 
 * 提示：
 * 1 <= nums.length <= 104
 * -107 <= nums[i] <= 107
 * 0 <= k <= 107
 */

    // @lc code=start
    public class Solution532 : SolutionBase
    {
        /// <summary>
        /// 难度
        /// </summary>
        public override Difficulity GetDifficulity() { return Difficulity.Medium; }
        /// <summary>
        /// 关键字:
        /// </summary>
        public override string[] GetKeyWords() { return new string[] { "快慢指针" }; }
        /// <summary>
        /// 标签：
        /// </summary>
        public override Tag[] GetTags() { return new Tag[] { Tag.Array, Tag.TwoPointers }; }

        /// <summary>
        /// </summary>
        /// <param name="sw"></param>
        /// <returns></returns>
        public override bool Test(System.Diagnostics.Stopwatch sw)
        {
            bool isSuccess = true;
            return isSuccess;
        }

        public int FindPairs(int[] arr, int k)
        {
            Array.Sort(arr);
            int res = 0;
            int R = 1, L = 0;
            while (R < arr.Length)
            {
                if (arr[R] == arr[R - 1] && R - 1 > L && arr[R - 1] - arr[L] == k) //Pre == k, Same R, R++
                {
                    R++;
                    continue;
                }

                if (arr[R] - arr[L] == k) //== K
                {
                    res++;
                    R++;
                }
                else if (arr[R] - arr[L] > k && L + 1 < R) // > K
                {
                    L++;
                }
                else  // < K
                {
                    R++;
                }
            }
            return res;
        }
    }
    // @lc code=end
}
