using System;
using System.Collections.Generic;
using System.Linq;
namespace CSharpConsoleApp.Solutions
{
    public class Solution658 : SolutionBase
    {
        public override bool Test(System.Diagnostics.Stopwatch sw)
        {
            bool isSuccess = true;
            int[] nums; int k, x;
            IList<int> result;
            int[] checkResult;

            nums = new int[] { 0, 2, 2, 3, 4, 5, 5, 6, 6, 6, 7, 8, 9, 11, 11, 15, 16, 19, 20, 21, 22, 22, 22, 23, 25, 26, 27, 28, 28, 28, 29, 29, 29, 31, 31, 31, 32, 34, 34, 34, 35, 35, 35, 38, 40, 41, 42, 45, 45, 45, 46, 49, 53, 53, 54, 58, 61, 62, 63, 63, 65, 66, 66, 67, 69, 70, 71, 72, 73, 74, 74, 74, 74, 75, 76, 76, 77, 77, 79, 80, 82, 82, 83, 86, 86, 86, 87, 89, 90, 90, 91, 92, 95, 96, 96, 97, 98, 98, 98, 99 };
            k = 28; x = 57;
            checkResult = new int[] { 40, 41, 42, 45, 45, 45, 46, 49, 53, 53, 54, 58, 61, 62, 63, 63, 65, 66, 66, 67, 69, 70, 71, 72, 73, 74, 74, 74 };
            result = FindClosestElements(nums, k, x);
            isSuccess &= IsArraySame(result.ToArray(), checkResult);
            Print("isSuccess = {0}  \n result = \n{1} \n anticipated = \n{2}", isSuccess, GetArrayStr<int>(result), GetArrayStr<int>(checkResult));
            
            return isSuccess;
        }

        //作者：LeetCode
        //链接：https://leetcode-cn.com/problems/find-k-closest-elements/solution/zhao-dao-kge-zui-jie-jin-de-yuan-su-by-leetcode/
        /// 62/62 cases passed (380 ms)
        /// Your runtime beats 39.39 % of csharp submissions
        /// Your memory usage beats 42.42 % of csharp submissions(41.6 MB)
        public IList<int> FindClosestElements(int[] arr, int k, int x)
        {
            List<int> list = new List<int>(arr);
            list.Sort((a, b) => {
                if (a == b) return 0;
                int absA = Math.Abs(a - x);
                int absB = Math.Abs(b - x);
                if (absA == absB)
                    return a - b;
                else
                    return absA - absB;
            });

            Print(GetArrayStr(list));
            List<int> ret = list.GetRange(0, k);
            ret.Sort();
            return ret;
        }
    }
}
