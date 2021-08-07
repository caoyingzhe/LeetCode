using System;
namespace CSharpConsoleApp.Solutions
{
    /*
     * @lc app=leetcode.cn id=376 lang=csharp
     *
     * [376] 摆动序列
     *
     * https://leetcode-cn.com/problems/wiggle-subsequence/description/
     *
     * Category	Difficulty	Likes	Dislikes
     * algorithms	Medium (45.47%)	446	-
     * Tags
     * dynamic-programming | greedy
     * 
     * Companies
     * Unknown
     * 
     * Total Accepted:    60.2K
     * Total Submissions: 132.4K
     * Testcase Example:  '[1,7,4,9,2,5]'
     *
     * 如果连续数字之间的差严格地在正数和负数之间交替，则数字序列称为 摆动序列
     * 。第一个差（如果存在的话）可能是正数或负数。仅有一个元素或者含两个不等元素的序列也视作摆动序列。
     * 
     * 例如， [1, 7, 4, 9, 2, 5] 是一个 摆动序列 ，因为差值 (6, -3, 5, -7, 3) 是正负交替出现的。
     * 
     * 相反，[1, 4, 7, 2, 5] 和 [1, 7, 4, 5, 5]
     * 不是摆动序列，第一个序列是因为它的前两个差值都是正数，第二个序列是因为它的最后一个差值为零。
     * 
     * 子序列 可以通过从原始序列中删除一些（也可以不删除）元素来获得，剩下的元素保持其原始顺序。
     * 
     * 给你一个整数数组 nums ，返回 nums 中作为 摆动序列 的 最长子序列的长度 。
     * 
     * 
     * 示例 1：
     * 输入：nums = [1,7,4,9,2,5]
     * 输出：6
     * 解释：整个序列均为摆动序列，各元素之间的差值为 (6, -3, 5, -7, 3) 。
     * 
     * 
     * 示例 2：
     * 输入：nums = [1,17,5,10,13,15,10,5,16,8]
     * 输出：7
     * 解释：这个序列包含几个长度为 7 摆动序列。
     * 其中一个是 [1, 17, 10, 13, 10, 16, 8] ，各元素之间的差值为 (16, -7, 3, -3, 6, -8) 。
     * 
     * 
     * 示例 3：
     * 输入：nums = [1,2,3,4,5,6,7,8,9]
     * 输出：2
     * 
     * 
     * 提示：
     * 1 
     * 0 
     * 
     * 进阶：你能否用 O(n) 时间复杂度完成此题?
     * 
     */
    public class Solution376 : SolutionBase
    {
        /// <summary>
        /// 难度
        /// </summary>
        public override Difficulity GetDifficulity() { return Difficulity.Medium; }
        /// <summary>
        /// 关键字:
        /// </summary>
        public override string[] GetKeyWords() { return new string[] { "多叉树", }; }
        /// <summary>
        /// 标签：
        /// </summary>
        public override Tag[] GetTags() { return new Tag[] { Tag.Graph, Tag.BreadthFirstSearch }; }

        public override bool Test(System.Diagnostics.Stopwatch sw)
        {
            bool isSuccess = true;
            int checkResult;
            int result;

            //result = WiggleMaxLength(new int[] { 1, 7, 4, 9, 2, 5 });
            //checkResult = 6;
            //isSuccess = (checkResult == result);
            //Print("isSuccess = {0} | result = {1} | anticipated = {2}", isSuccess, result, checkResult);

            result = WPiggleMaxLength(new int[] { 1, 17, 5, 10, 13, 15, 10, 5, 16, 8 });
            //                                      16,-12,5,  3,  2,  -5, -5,11,-8
            checkResult = 7;
            isSuccess = (checkResult == result);
            Print("isSuccess = {0} | result = {1} | anticipated = {2}", isSuccess, result, checkResult);

            //result = WiggleMaxLength(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 });
            //checkResult = 2;
            //isSuccess = (checkResult == result);
            //Print("isSuccess = {0} | result = {1} | anticipated = {2}", isSuccess, result, checkResult);

            //result = WiggleMaxLength(new int[] { 1, 2 });
            //checkResult = 2;
            //isSuccess = (checkResult == result);
            //Print("isSuccess = {0} | result = {1} | anticipated = {2}", isSuccess, result, checkResult);

            //result = WiggleMaxLength(new int[] { 1 });
            //checkResult = 1;
            //isSuccess = (checkResult == result);
            //Print("isSuccess = {0} | result = {1} | anticipated = {2}", isSuccess, result, checkResult);


            return isSuccess;
        }

        public int WiggleMaxLength_Wrong(int[] nums)
        {
            if (nums.Length == 0)
                return 0;
            if (nums.Length == 1)
                return 1;

            int n = nums.Length;

            int[] diffs = new int[n - 1];
            int[] dp = new int[n + 1];
            dp[0] = 1;

            for (int i = 1; i < n; i++)
            {
                diffs[i - 1] = nums[i] - nums[i - 1];
            }

            Print(GetArrayStr(diffs));

            int maxLength = int.MinValue;
            int tmpLen = 2;
            for (int j = 1; j < n - 1; j++)
            {
                if (diffs[j - 1] * diffs[j] < 0)
                {
                    tmpLen++;
                    maxLength = Math.Max(maxLength, tmpLen);
                }
                else
                {
                    tmpLen = (diffs[j] == 0) ? 1 : 2;
                }
            }

            return maxLength;
        }

        /// <summary>
        /// 26/26 cases passed (116 ms)
        /// Your runtime beats 26.67 % of csharp submissions
        /// Your memory usage beats 53.33 % of csharp submissions(23.9 MB)
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        //作者：LeetCode-Solution
        //链接：https://leetcode-cn.com/problems/wiggle-subsequence/solution/bai-dong-xu-lie-by-leetcode-solution-yh2m/
        //方法一：动态规划优化2
        public int WiggleMaxLength_DPOptimized(int[] nums)
        {
            int n = nums.Length;
            if (n < 2)
            {
                return n;
            }
            int up = 1, down = 1;
            for (int i = 1; i < n; i++)
            {
                if (nums[i] > nums[i - 1])
                {
                    up = down + 1;
                }
                else if (nums[i] < nums[i - 1])
                {
                    down = up + 1;
                }
            }
            return Math.Max(up, down);
        }

        /// <summary>
        /// 26/26 cases passed (100 ms)
        /// Your runtime beats 93.33 % of csharp submissions
        /// Your memory usage beats 63.33 % of csharp submissions(23.9 MB)
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        //作者：LeetCode-Solution
        //链接：https://leetcode-cn.com/problems/wiggle-subsequence/solution/bai-dong-xu-lie-by-leetcode-solution-yh2m/
        //方法一：动态规划
        public int WiggleMaxLength_DP(int[] nums)
        {
            int n = nums.Length;
            if (n < 2)
            {
                return n;
            }
            int[] up = new int[n];
            int[] down = new int[n];
            up[0] = down[0] = 1;
            for (int i = 1; i < n; i++)
            {
                if (nums[i] > nums[i - 1])
                {
                    up[i] = Math.Max(up[i - 1], down[i - 1] + 1);
                    down[i] = down[i - 1];
                }
                else if (nums[i] < nums[i - 1])
                {
                    up[i] = up[i - 1];
                    down[i] = Math.Max(up[i - 1] + 1, down[i - 1]);
                }
                else
                {
                    up[i] = up[i - 1];
                    down[i] = down[i - 1];
                }
            }
            return Math.Max(up[n - 1], down[n - 1]);
        }

        //作者：lgh18
        //链接：https://leetcode-cn.com/problems/wiggle-subsequence/solution/tan-xin-si-lu-qing-xi-er-zheng-que-de-ti-jie-by-lg/
        //贪心算法
        public int WPiggleMaxLength(int[] nums)
        {
            int down = 1, up = 1;
            for (int i = 1; i < nums.Length; i++)
            {
                if (nums[i] > nums[i - 1])
                    up = down + 1;
                else if (nums[i] < nums[i - 1])
                    down = up + 1;
            }
            return nums.Length == 0 ? 0 : Math.Max(down, up);
        }


    }
}
