using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace CSharpConsoleApp.Solutions
{
    class Solution268 : SolutionBase
    {
        public override bool Test(System.Diagnostics.Stopwatch sw)
        {
            int[] nums = {  7, 0, 9, 6, 4, 2, 3, 5, 1 };
            int resultCheck = 8;
            int result = MissingNumber(nums);

            return result == resultCheck;
        }
        public int MissingNumber(int[] nums)
        {
            List<int> list = new List<int>(nums);
            list.Sort();
            

            for (int i = 0; i < list.Count; i++)
            {
                if (list[i] != i)
                    return i;
            }
            return nums.Length;
        }
    }
}
