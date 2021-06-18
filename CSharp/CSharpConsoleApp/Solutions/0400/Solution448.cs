using System;
using System.Collections.Generic;
namespace CSharpConsoleApp.Solutions
{
    public class Solution448
    {
        /// <summary>
        /// 33/33 cases passed (372 ms)
        /// Your runtime beats 57.14 % of csharp submissions
        /// Your memory usage beats 81.51 % of csharp submissions(42.9 MB)
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public IList<int> FindDisappearedNumbers(int[] nums)
        {
            int n = nums.Length;
            foreach (int num in nums)
            {
                int x = (num - 1) % n;
                nums[x] += n;
            }
            List<int> ret = new List<int>();
            for (int i = 0; i < n; i++)
            {
                if (nums[i] <= n)
                {
                    ret.Add(i + 1);
                }
            }
            return ret;
        }
    }
}
