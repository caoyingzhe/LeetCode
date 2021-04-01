using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpConsoleApp.Solutions
{
    class Solution1 : SolutionBase
    {
        #region Test1 : TwoSum Easy
        public override bool Test(System.Diagnostics.Stopwatch sw)
        {
            int[] nums = { 0, 4, 3, 0 };
            int target = 0;

            int[] result = TwoSum(nums, target);

            System.Diagnostics.Debug.Print("Result = " + string.Join(",", result));

            return true;
        }

        /// <summary>
        /// Problem
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public int[] TwoSum(int[] nums, int target)
        {
            Dictionary<int, int> dict = new Dictionary<int, int>();
            int[] result = new int[2];
            for (int i = 0; i < nums.Length; i++)
            {
                int num = nums[i];
                if (!dict.ContainsKey(num))
                    dict.Add(num, i);

                int diff = target - num;
                {
                    if (dict.ContainsKey(diff))
                    {
                        if (dict[diff] != i)
                        {
                            result[0] = dict[diff];
                            result[1] = i;
                            break;
                        }
                    }
                }

            }
            return result;
        }
        #endregion

    }
}
