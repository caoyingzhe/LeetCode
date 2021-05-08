using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpConsoleApp.Solutions
{
    /// <summary>
    /// 汇总区间
    /// </summary>
    class Solution228 : SolutionBase
    {
        /// <summary>
        /// 难度
        /// </summary>
        public override Difficulity GetDifficulity() { return Difficulity.Easy; }
        /// <summary>
        /// 关键字:
        /// </summary>
        public override string[] GetKeyWords() { return new string[] { "" }; }
        /// <summary>
        /// 标签： 
        /// </summary>
        public override Tag[] GetTags() { return new Tag[] { Tag.String }; }

        public override bool Test(System.Diagnostics.Stopwatch sw)
        {
            bool isSuccess = true;
            int[] nums = new int[]{ 0, 1, 2, 4, 5, 7 };
            IList<string> result = SummaryRanges(nums);
            string[] checkResult = new string[]{ "0->2", "4->5", "7" };

            Print("result : " +  string.Join(",", result.ToArray()));
            isSuccess &= IsListSame(checkResult, result);

            nums = new int[] { 0, 2, 3, 4, 6, 8, 9 };
            result = SummaryRanges(nums);
            checkResult = new string[] {"0", "2->4", "6", "8->9"};
            Print("result : " + string.Join(",", result.ToArray()));
            isSuccess &= IsListSame(checkResult, result);

            return isSuccess;
        }

        public IList<string> SummaryRanges(int[] nums)
        {
            List<string> result = new List<string>();

            if (nums.Length > 0)
            {
                int start = nums[0];
                result.Add("" + nums[0]);
                int pre = nums[0];
                for (int i = 1; i < nums.Length; i++)
                {
                    if (nums[i] - pre == 1)
                    {
                        pre = nums[i];
                        if(i == nums.Length -1)
                        {
                            result[result.Count - 1] = "" + start + "->" + pre;
                        }
                    }
                    else
                    {
                        if(pre > start)
                            result[result.Count - 1] = "" + start + "->" + pre;
                        start = nums[i];
                        result.Add("" + nums[i]);
                        pre = nums[i];
                    }
                }
            }
            return result;
        }
    }
}
