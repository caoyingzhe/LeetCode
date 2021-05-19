using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpConsoleApp.Solutions
{
    class Solution260 : SolutionBase
    {
        /// <summary>
        /// 使用异或运算找出两位10000以下的不重复num，属于特殊场景使用方法。
        /// </summary>
        /// <param name="sw"></param>
        /// <returns></returns>
        public override bool Test(System.Diagnostics.Stopwatch sw)
        {
            int[] nums = null;
            int[] result = null;
            int[] resultCheck = null;
            bool isSuccess = true;

            nums = new int[] { 1, 2, 3, 4, 5, 1, 2, 4 };
            resultCheck = new int[] { 3, 5, };
            Print(string.Join(",", nums));

            result = SingleNumber(nums);
            isSuccess &=  IsArraySame(result, resultCheck, true);
            Print("isSuccess = " + isSuccess + " | result = " + string.Join(", ", result));
            return isSuccess;
        }

        public int[] SingleNumber(int[] nums)
        {
            int eor = 0;
            foreach (int num in nums)
            {
                eor ^= num;
            }
            int rightOne = eor & (-eor);
            int res = 0;
            foreach (int num in nums)
            {
                if ((num & rightOne) != 0)
                {
                    res ^= num;
                }
            }
            return new int[] { res, res ^ eor };
        }
    }
}
