using System;
namespace CSharpConsoleApp.Solutions
{
    public class Solution213 : SolutionBase
    {
        /// <summary>
        /// 难度
        /// </summary>
        public override Difficulity GetDifficulity() { return Difficulity.Medium; }
        /// <summary>
        /// 关键字:
        /// </summary>
        public override string[] GetKeyWords() { return new string[] { "" }; }
        /// <summary>
        /// 标签：
        /// </summary>
        public override Tag[] GetTags() { return new Tag[] { Tag.DynamicProgramming, }; }

        public override bool Test(System.Diagnostics.Stopwatch sw)
        {
            bool isSuccess = true;
            int[] nums;
            int result, checkResult;

            nums = new int[] { 2, 3, 2 };
            checkResult = 3;
            result = Rob(nums);
            isSuccess &= IsSame(result, checkResult);
            PrintResult(isSuccess, (result), (checkResult));

            nums = new int[] { 1, 2, 3, 1 };
            checkResult = 4;
            result = Rob(nums);
            isSuccess &= IsSame(result, checkResult);
            PrintResult(isSuccess, (result), (checkResult));

            nums = new int[] { 0 };
            checkResult = 0;
            result = Rob(nums);
            isSuccess &= IsSame(result, checkResult);
            PrintResult(isSuccess, (result), (checkResult));
            return isSuccess;
        }


        //作者：LeetCode-Solution
        //链接：https://leetcode-cn.com/problems/house-robber-ii/solution/da-jia-jie-she-ii-by-leetcode-solution-bwja/
        public int Rob198(int[] nums)
        {
            if (nums == null || nums.Length == 0) return 0;

            int n = nums.Length;
            if (n == 1) return nums[0];

            int[] dp = new int[n];

            dp[0] = nums[0];
            dp[1] = Math.Max(nums[0], nums[1]);
            for (int i = 2; i < n; i++)
            {
                dp[i] = Math.Max(dp[i - 2] + nums[i], dp[i - 1]);
            }
            return dp[n - 1];
        }

        /// <summary>
        /// 74/74 cases passed (92 ms)
        /// Your runtime beats 99.33 % of csharp submissions
        /// Your memory usage beats 13.33 % of csharp submissions(24.2 MB)
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int Rob(int[] nums)
        {
            if (nums == null || nums.Length == 0) return 0;

            int n = nums.Length;
            if (n == 1) return nums[0];
            if (n == 2) return Math.Max(nums[0], nums[1]);
            return Math.Max(RobRange(nums, 0, n - 2), RobRange(nums, 1, n - 1));
        }

        public int RobRange(int[] nums, int start, int end)
        {
            int first = nums[start];
            int second = Math.Max(nums[start], nums[start + 1]);
            for (int i = start + 2; i <= end; i++)
            {
                int temp = second;
                second = Math.Max(first + nums[i], second);
                first = temp;
            }
            return second;
        }
    }
}
