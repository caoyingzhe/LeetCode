using System;
namespace CSharpConsoleApp.Solutions
{
    public class Solution35
    {
        /// <summary>
        /// 62/62 cases passed (108 ms)
        /// Your runtime beats 77.01 % of csharp submissions
        /// Your memory usage beats 64.03 % of csharp submissions(24.6 MB)
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public int SearchInsert(int[] nums, int target)
        {
            int n = nums.Length;
            int L = 0, R = n - 1, result = n;
            while (L <= R)
            {
                int mid = (R - L) / 2 + L;  //C#中使用 ((R - L)>> 1) + L 算法反而更慢，为何？不解！
                if (target <= nums[mid])
                {
                    result = mid;
                    R = mid - 1;
                }
                else
                {
                    L = mid + 1;
                }
            }
            return result;
        }

        //作者：LeetCode-Solution
        //链接：https://leetcode-cn.com/problems/search-insert-position/solution/sou-suo-cha-ru-wei-zhi-by-leetcode-solution/

    }
}
