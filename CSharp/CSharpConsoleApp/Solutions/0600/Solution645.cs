using System;
namespace CSharpConsoleApp.Solutions
{
    /*
 * @lc app=leetcode.cn id=645 lang=csharp
 *
 * [645] 错误的集合
 *
 * https://leetcode-cn.com/problems/set-mismatch/description/
 *
 * algorithms
 * Easy (41.64%)
 * Likes:    173
 * Dislikes: 0
 * Total Accepted:    37.5K
 * Total Submissions: 90.1K
 * Testcase Example:  '[1,2,2,4]'
 *
 * 集合 s 包含从 1 到 n 的整数。不幸的是，因为数据错误，导致集合里面某一个数字复制了成了集合里面的另外一个数字的值，导致集合 丢失了一个数字 并且
 * 有一个数字重复 。
 * 
 * 给定一个数组 nums 代表了集合 S 发生错误后的结果。
 * 
 * 请你找出重复出现的整数，再找到丢失的整数，将它们以数组的形式返回。
 * 
 * 
 * 
 * 示例 1：
 * 
 * 
 * 输入：nums = [1,2,2,4]
 * 输出：[2,3]
 * 
 * 
 * 示例 2：
 * 
 * 
 * 输入：nums = [1,1]
 * 输出：[1,2]
 * 
 * 
 * 
 * 
 * 提示：
 * 
 * 
 * 2 
 * 1 
 * 
 * 
 */

    // @lc code=start
    public class Solution645
    {
        //作者：LeetCode
        //链接：https://leetcode-cn.com/problems/set-mismatch/solution/cuo-wu-de-ji-he-by-leetcode/

        /// <summary>
        /// 49/49 cases passed (300 ms)
        /// Your runtime beats 100 % of csharp submissions
        /// Your memory usage beats 51.11 % of csharp submissions(37.5 MB)
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int[] FindErrorNums(int[] nums)
        {
            int dup = -1, missing = 1;
            foreach(int n in nums)
            {
                if (nums[Math.Abs(n) - 1] < 0)
                    dup = Math.Abs(n);
                else
                    nums[Math.Abs(n) - 1] *= -1;
            }
            for (int i = 1; i < nums.Length; i++)
            {
                if (nums[i] > 0)
                    missing = i + 1;
            }
            return new int[] { dup, missing };
        }
    }
    // @lc code=end


}
