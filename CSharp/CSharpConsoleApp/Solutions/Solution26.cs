using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpConsoleApp.Solutions
{
    class Solution26 : SolutionBase
    {
        public override bool Test(Stopwatch sw)
        {
            int[] nums = null;
            int removeCount = 0;
            int numsCountCheck = 0;
            int[] numsCheck = null;
            bool isSuccess = true;

            nums = new int[] {1, 1, 2};
            numsCheck = new int[] { 1, 2,};
            numsCountCheck = 2;
            Print(string.Join(",", nums));
            removeCount = RemoveDuplicates(nums);
            isSuccess &= (removeCount == numsCountCheck) && (IsArraySame(nums, numsCheck, true));
            Print("isSuccess = " + isSuccess + " | removeCount = " + removeCount + " | result = " + string.Join(", ", nums));
            return isSuccess;
        }

        public int RemoveDuplicates(int[] nums)
        {
            if (nums.Length == 0) return 0;
            int i = 0;
            for (int j = 1; j < nums.Length; j++)
            {
                if (nums[i] != nums[j])
                {
                    nums[i+1] = nums[j];
                    i++;
                }
            }
            return i + 1;
        }
    }
}
