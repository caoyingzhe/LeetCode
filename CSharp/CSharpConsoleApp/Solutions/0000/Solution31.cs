using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpConsoleApp.Solutions
{
    /// <summary>
    /// 下一个排列
    /// 实现获取 下一个排列 的函数，算法需要将给定数字序列重新排列成字典序中下一个更大的排列。
    /// 如果不存在下一个更大的排列，则将数字重新排列成最小的排列（即升序排列）。
    /// 必须 原地 修改，只允许使用额外常数空间。
    /// 
    /// 排列意思是 作为10进制数，更大意思是10进制的数的数值。比如1，2，3 代表 123， 1，3，2代表132, 1,10,9 代表1109
    /// 
    /// 1 <= nums.length <= 100
    /// 0 <= nums[i] <= 100
    /// 
    /// https://leetcode-cn.com/problems/next-permutation/solution/xia-yi-ge-pai-lie-by-leetcode-solution/
    /// 
    /// 思路： 从后到前扫描不是降序的数，找到后，再从后到前扫描比找到数大的数，替换位置，然后翻转所有找到位置之后的数
    /// 时间复杂度：O(N)O(N)
    /// 空间复杂度：O(1)O(1)
    /// 
    /// Your runtime beats 92.91 % of csharp submissions
    /// Your memory usage beats 29.92 % of csharp submissions(31.3 MB)
    /// </summary>
    class Solution31 : SolutionBase
    {
        /// <summary>
        /// 难度 
        /// </summary>
        public override Difficulity GetDifficulity() { return Difficulity.Medium; }
        /// <summary>
        /// 关键字:
        /// </summary>
        public override string[] GetKeyWords() { return new string[] { "从后向前排序", "翻转" }; }
        /// <summary>
        /// 标签： 
        /// </summary>
        public override Tag[] GetTags() { return new Tag[] { Tag.Array }; }
        public override bool Test(System.Diagnostics.Stopwatch sw)
        {
            bool isSuccess = true;
            int[] nums;
            int[] checkResult;

            nums = new int[] { 1, 2, 3 };
            Print("--- nums = " + string.Join(",", nums));

            checkResult = new int[] { 1, 3, 2 };
            NextPermutation(nums);
            isSuccess &= string.Join(",", nums) == string.Join(",", checkResult);
            Print(string.Format("isSuccss ={0}, result={1} checkResult={2}", isSuccess, string.Join(",", nums), string.Join(",", checkResult)));

            nums = new int[] { 3, 2, 1 };
            Print("--- nums = " + string.Join(",", nums));
            checkResult = new int[] { 1, 2, 3 };
            NextPermutation(nums);
            isSuccess &= string.Join(",", nums) == string.Join(",", checkResult);
            Print(string.Format("isSuccss ={0}, result={1} checkResult={2}", isSuccess, string.Join(",", nums), string.Join(",", checkResult)));


            nums = new int[] { 1, 1, 5 };
            Print("--- nums = " + string.Join(",", nums));
            checkResult = new int[] { 1, 5, 1 };
            NextPermutation(nums);
            isSuccess &= string.Join(",", nums) == string.Join(",", checkResult);
            Print(string.Format("isSuccss ={0}, result={1} checkResult={2}", isSuccess, string.Join(",", nums), string.Join(",", checkResult)));

            nums = new int[] { 1 };
            Print("--- nums = " + string.Join(",", nums));
            checkResult = new int[] { 1 };
            NextPermutation(nums);
            isSuccess &= string.Join(",", nums) == string.Join(",", checkResult);
            Print(string.Format("isSuccss ={0}, result={1} checkResult={2}", isSuccess, string.Join(",", nums), string.Join(",", checkResult)));

            nums = new int[] { 1, 5, 8, 4, 7, 6, 5, 3, 1 };
            Print("--- nums = " + string.Join(",", nums));
            checkResult = new int[] { 1, 5, 8, 5, 1, 3, 4, 6, 7 };
            NextPermutation(nums);
            isSuccess &= string.Join(",", nums) == string.Join(",", checkResult);
            Print(string.Format("isSuccss ={0}, result={1} checkResult={2}", isSuccess, string.Join(",", nums), string.Join(",", checkResult)));

            return isSuccess;
        }

        public void NextPermutation(int[] nums)
        {
            int i = nums.Length - 2;
            int j = nums.Length - 1;
            while (i >= 0 && nums[i] >= nums[i + 1])
            {
                i--;
            }
            if (i >= 0)
            {
                while (j >= 0 && nums[i] >= nums[j])
                {
                    j--;
                }

                int value = nums[j];
                nums[j] = nums[i];
                nums[i] = value;
            }

            //reverse(nums.begin() + i + 1, nums.end());
            //Print("i=" + i + " j = " + j);
            if (i < -1)
                return;

            for (int m = 0; m < nums.Length - i + 1; m++)
            {
                int l = m + i + 1;
                int r = nums.Length - 1 - m;
                if (l < r)
                {
                    int value = nums[r];
                    nums[r] = nums[l];
                    nums[l] = value;
                }
            }
        }
    }
}
