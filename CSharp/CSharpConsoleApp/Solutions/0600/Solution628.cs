using System;
namespace CSharpConsoleApp.Solutions
{
    public class Solution628 : SolutionBase
    {
        /// <summary>
        /// 难度
        /// </summary>
        public override Difficulity GetDifficulity() { return Difficulity.Easy; }
        /// <summary>
        /// 关键字:
        /// </summary>
        public override string[] GetKeyWords() { return new string[] { "抄作业" }; }
        /// <summary>
        /// 标签：
        /// </summary>
        public override Tag[] GetTags() { return new Tag[] { Tag.Unknown }; }

        /// <summary>
        /// </summary>
        /// <param name="sw"></param>
        /// <returns></returns>
        public override bool Test(System.Diagnostics.Stopwatch sw)
        {
            bool isSuccess = true;
            //TODO
            return isSuccess;
        }

        /// <summary>
        /// 92/92 cases passed (188 ms)
        /// Your runtime beats 52.08 % of csharp submissions
        /// Your memory usage beats 54.17 % of csharp submissions(34.2 MB)
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int MaximumProduct(int[] nums)
        {
            Array.Sort(nums);
            int n = nums.Length;
            return Math.Max(nums[0] * nums[1] * nums[n - 1], nums[n - 3] * nums[n - 2] * nums[n - 1]);
        }
    }
}