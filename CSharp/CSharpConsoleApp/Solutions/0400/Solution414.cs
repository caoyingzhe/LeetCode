using System;
using System.Collections.Generic;
using System.Linq;
namespace CSharpConsoleApp.Solutions
{
    /*
     * @lc app=leetcode.cn id=414 lang=csharp
     *
     * [414] 第三大的数
     *
     * https://leetcode-cn.com/problems/third-maximum-number/description/
     *
     * algorithms
     * Easy (36.17%)
     * Likes:    230
     * Dislikes: 0
     * Total Accepted:    54.1K
     * Total Submissions: 149.7K
     * Testcase Example:  '[3,2,1]'
     *
     * 给你一个非空数组，返回此数组中 第三大的数 。如果不存在，则返回数组中最大的数。
     * 
     * 
     * 
     * 示例 1：
     * 
     * 
     * 输入：[3, 2, 1]
     * 输出：1
     * 解释：第三大的数是 1 。
     * 
     * 示例 2：
     * 输入：[1, 2]
     * 输出：2
     * 解释：第三大的数不存在, 所以返回最大的数 2 。
     * 
     * 
     * 示例 3：
     * 输入：[2, 2, 3, 1]
     * 输出：1
     * 解释：注意，要求返回第三大的数，是指在所有不同数字中排第三大的数。
     * 此例中存在两个值为 2 的数，它们都排第二。在所有不同数字中排第三大的数为 1 。
     * 
     * 
     * 
     * 提示：
     * 1 <= nums.length <= 10^4
     * -2^31 <= nums[i] <= 23^1 - 1
     * 
     * 进阶：你能设计一个时间复杂度 O(n) 的解决方案吗？
     */

    // @lc code=start
    public class Solution414
    {
        // 作者：PYHao
        // 链接：https://leetcode-cn.com/problems/third-maximum-number/solution/c-2chong-fang-fa-lie-biao-shu-zu-you-xu-zi-dian-by/
        // 29/29 cases passed (104 ms)
        //Your runtime beats 98.21 % of csharp submissions
        //Your memory usage beats 41.07 % of csharp submissions (25.3 MB)
        public int ThirdMax(int[] nums)
        {
            var numList = new List<int>(3);
            foreach (var numItem in nums)
            {
                if (numList.Contains(numItem)) continue;

                if (numList.Count < 3)
                {
                    numList.Add(numItem);
                    numList.Sort();
                }
                else if (numList.Count == 3 && numList.First() < numItem)
                {
                    numList[0] = numItem;
                    numList.Sort();
                }
            }
            return numList.Count < 3 ? numList.Last() : numList.First();
        }
    }
    // @lc code=end


}
