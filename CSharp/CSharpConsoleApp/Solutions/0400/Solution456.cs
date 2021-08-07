using System;
using System.Collections.Generic;
namespace CSharpConsoleApp.Solutions
{
    /*
 * @lc app=leetcode.cn id=456 lang=csharp
 *
 * [456] 132 模式
 *
 * https://leetcode-cn.com/problems/132-pattern/description/
 *
 * Category	Difficulty	Likes	Dislikes
 * algorithms	Medium (36.03%)	530	-
 * Tags
 * stack
 * 
 * Companies
 * Unknown
 * 
 * Total Accepted:    52.7K
 * Total Submissions: 146.1K
 * Testcase Example:  '[1,2,3,4]'
 *
 * 给你一个整数数组 nums ，数组中共有 n 个整数。132 模式的子序列 由三个整数 nums[i]、nums[j] 和 nums[k]
 * 组成，并同时满足：i < j < k 和 nums[i] < nums[k] < nums[j] 。
 * 
 * 如果 nums 中存在 132 模式的子序列 ，返回 true ；否则，返回 false 。
 * 
 * 
 * 
 * 示例 1：
 * 输入：nums = [1,2,3,4]
 * 输出：false
 * 解释：序列中不存在 132 模式的子序列。
 * 
 * 
 * 示例 2：
 * 输入：nums = [3,1,4,2]
 * 输出：true
 * 解释：序列中有 1 个 132 模式的子序列： [1, 4, 2] 。
 * 
 * 
 * 示例 3：
 * 输入：nums = [-1,3,2,0]
 * 输出：true
 * 解释：序列中有 3 个 132 模式的的子序列：[-1, 3, 2]、[-1, 3, 0] 和 [-1, 2, 0] 。
 * 
 * 
 * 提示：
 * n == nums.length
 * 1 <= n <= 2 * 10^5
 * -10^9 <= nums[i] <= 10^9
 */

    // @lc code=start
    public class Solution456 : SolutionBase
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
        public override Tag[] GetTags() { return new Tag[] { Tag.Stack }; }

        public override bool Test(System.Diagnostics.Stopwatch sw)
        {
            bool isSuccess = true;
            int[] nums;
            bool result, checkResult;

            nums = new int[] { 1, 2, 3, 4 };
            checkResult = false;
            result = Find132pattern(nums);
            isSuccess &= IsSame(result, checkResult);
            PrintResult(isSuccess, result, checkResult);

            //nums = new int[] { 3, 1, 4, 2 };
            //checkResult = true;
            //result = Find132pattern(nums);
            //isSuccess &= IsSame(result, checkResult);
            //PrintResult(isSuccess, result, checkResult);

            //nums = new int[] { -1, 3, 2, 0 };
            //checkResult = true;
            //result = Find132pattern(nums);
            //isSuccess &= IsSame(result, checkResult);
            //PrintResult(isSuccess, result, checkResult);

            ////1,0,1,-4,-3 false
            //nums = new int[] { 1, 0, 1, -4, -3 };
            //checkResult = false;
            //result = Find132pattern(nums);
            //isSuccess &= IsSame(result, checkResult);
            //PrintResult(isSuccess, result, checkResult);

            //nums = new int[] { 3, 5, 0, 3, 4 };
            //checkResult = true;
            //result = Find132pattern(nums);
            //isSuccess &= IsSame(result, checkResult);
            //PrintResult(isSuccess, result, checkResult);

            return isSuccess;
        }

        /// <summary>
        /// Time Limit Exceeded
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public bool Find132pattern_TLE(int[] nums)
        {
            int n = nums.Length;
            if (n <= 2)
                return false;
            int[] minNums = new int[n];
            int[] maxNums = new int[n];

            int min = int.MaxValue;
            int max = int.MinValue;
            for (int i = 0; i < n; i++)
            {
                min = Math.Min(min, nums[i]);
                minNums[i] = min;
            }

            for (int i = n - 1; i > 0; i--)
            {
                max = Math.Max(max, nums[i]);
                maxNums[i] = max;
            }

            for (int i = n - 1; i > 1; i--)
            {
                for (int j = i - 1; j > 0; j--)
                {
                    if (minNums[j - 1] < nums[i] && nums[j] > nums[i])
                    {
                        //Print("{0} | {1} | {2}", minNums[j-1], nums[j], nums[i]);
                        return true;
                    }
                }
            }
            return false;
        }

        /// <summary>
        /// 作者：AC_OIer
        /// 链接：https://leetcode-cn.com/problems/132-pattern/solution/xiang-xin-ke-xue-xi-lie-xiang-jie-wei-he-95gt/   
        /// 102/102 cases passed (144 ms)
        /// Your runtime beats 76.19 % of csharp submissions
        /// Your memory usage beats 9.52 % of csharp submissions(43.6 MB)
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public bool Find132pattern(int[] nums)
        {
            int n = nums.Length;
            LinkedList<int> deque = new LinkedList<int>();
            int k = int.MinValue;
            for (int i = n - 1; i >= 0; i--)
            {
                if (nums[i] < k) return true;

                while (deque.Count != 0 && deque.Last.Value < nums[i])  //while (d.Count != 0 && d.peekLast() < nums[i])
                {
                    // 事实上，k 的变化也具有单调性，直接使用 k = pollLast() 也是可以的
                    k = Math.Max(k, deque.Last.Value);  //k = Math.Max(k, d.pollLast());
                    deque.RemoveLast();
                }
                //d.addLast(nums[i]);
                deque.AddLast(nums[i]);
            }
            return false;
        }
    }
    // @lc code=end


}
