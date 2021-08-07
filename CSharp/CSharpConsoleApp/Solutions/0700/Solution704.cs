using System;
namespace CSharpConsoleApp.Solutions
{
    public class Solution704 : SolutionBase
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
        /// 46/46 cases passed (140 ms)
        /// Your runtime beats 46.53 % of csharp submissions
        /// Your memory usage beats 31.75 % of csharp submissions(35.2 MB)
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public int search(int[] nums, int target)
        {
            int mid, L = 0, R = nums.Length - 1;
            while (L <= R)
            {
                mid = L + (R - L) / 2;
                if (nums[mid] == target)
                    return mid;
                if (target < nums[mid])
                    R = mid - 1;
                else
                    L = mid + 1;
            }
            return -1;
        }

//        作者：LeetCode
//        链接：https://leetcode-cn.com/problems/binary-search/solution/er-fen-cha-zhao-by-leetcode/
//来源：力扣（LeetCode）
//著作权归作者所有。商业转载请联系作者获得授权，非商业转载请注明出处。
    }
}
