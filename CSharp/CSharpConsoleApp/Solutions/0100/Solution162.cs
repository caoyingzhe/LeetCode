using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpConsoleApp.Solutions
{
    /// <summary>
    /// 寻找峰值
    /// </summary>
    class Solution162 : SolutionBase
    {
        /// <summary>
        /// 难度
        /// </summary>
        public override Difficulity GetDifficulity() { return Difficulity.Medium; }
        /// <summary>
        /// 关键字:
        /// </summary>
        public override string[] GetKeyWords() { return new string[] { "二分法搜索" }; }
        /// <summary>
        /// 标签： 
        /// </summary>
        public override Tag[] GetTags() { return new Tag[] { Tag.Array, Tag.BinarySearch }; }

        public override bool Test(System.Diagnostics.Stopwatch sw)
        {
            Print("isSuccess = false , Not ready!"); return false;

            List<int> result = new List<int>();
            int[] checkResult = null;
            bool isSuccess = true;

            Print("isSuccess = {0} | result= {1} | resultChecked = {2}", isSuccess, string.Join(",", result), string.Join(",", checkResult));

            isSuccess &= IsArraySame(checkResult, result.ToArray());

            return isSuccess;
        }

        public int FindPeakElement(int[] nums)
        {
            for (int i = 0; i < nums.Length - 1; i++)
            {
                if (nums[i] > nums[i + 1])
                    return i;
            }
            return nums.Length - 1;
        }

        public int FindPeakElement_binarySearch(int[] nums)
        {
            return search(nums, 0, nums.Length - 1);
        }
        public int search(int[] nums, int l, int r)
        {
            if (l == r)
                return l;
            int mid = (l + r) / 2;
            if (nums[mid] > nums[mid + 1])
                return search(nums, l, mid);
            return search(nums, mid + 1, r);
        }
    }
}
