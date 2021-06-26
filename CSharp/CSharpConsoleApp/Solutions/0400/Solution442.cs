using System;
using System.Collections.Generic;
namespace CSharpConsoleApp.Solutions
{
    /*
 * @lc app=leetcode.cn id=442 lang=csharp
 *
 * [442] 数组中重复的数据
 *
 * https://leetcode-cn.com/problems/find-all-duplicates-in-an-array/description/
 *
 * algorithms
 * Medium (69.11%)
 * Likes:    394
 * Dislikes: 0
 * Total Accepted:    37.2K
 * Total Submissions: 53.8K
 * Testcase Example:  '[4,3,2,7,8,2,3,1]'
 *
 * 给定一个整数数组 a，其中1 ≤ a[i] ≤ n （n为数组长度）, 其中有些元素出现两次而其他元素出现一次。
 * 
 * 找到所有出现两次的元素。
 * 
 * 你可以不用到任何额外空间并在O(n)时间复杂度内解决这个问题吗？
 * 
 * 示例：
 * 
 * 
 * 输入:
 * [4,3,2,7,8,2,3,1]
 * 
 * 输出:
 * [2,3]
 * 
 * 
 */

    // @lc code=start
    public class Solution442 : SolutionBase
    {
        /// <summary>
        /// 难度
        /// </summary>
        public override Difficulity GetDifficulity() { return Difficulity.Medium; }
        /// <summary>
        /// 关键字:
        /// </summary>
        public override string[] GetKeyWords() { return new string[] { "" }; }
        /// <summary>
        /// 标签：
        /// </summary>
        public override Tag[] GetTags() { return new Tag[] { Tag.Array }; }

        public override bool Test(System.Diagnostics.Stopwatch sw)
        {
            bool isSuccess = true;
            IList<int> result, checkResult;

            int[] nums;

            nums = new int[] { 4, 3, 2, 7, 8, 2, 3, 1 };
            checkResult = new int[] { 2, 3 };
            result = FindDuplicates(nums);
            isSuccess &= IsListSame(result, checkResult);
            PrintResult(isSuccess, (result), (checkResult));

            return isSuccess;
        }

        /// <summary>
        /// 28/28 cases passed (360 ms)
        /// Your runtime beats 78.13 % of csharp submissions
        /// Your memory usage beats 62.5 % of csharp submissions(43 MB)
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        // 作者：strange-williamsonvze
        // 链接：https://leetcode-cn.com/problems/find-all-duplicates-in-an-array/solution/442li-yong-chu-li-by-strange-williamsonv-7cey/
        public IList<int> FindDuplicates(int[] nums)
        {
            //同448解法相似，是每一位增加n，如果一个位置的数大于2n，说明其增加了两次，即为重复两次，之后遍历取出即可。
            int n = nums.Length;
            List<int> ans = new List<int>();
            foreach (int i in nums)
            {
                nums[(i - 1) % n] = nums[(i - 1) % n] + n;
            }
            for (int i = 0; i < n; i++)
            {
                if (nums[i] < 3 * n + 1 && nums[i] > 2 * n)
                {
                    ans.Add(i + 1);
                }
            }
            return ans;

            //同448解法相似，是每一位增加n，如果一个位置的数大于2n，说明其增加了两次，即为重复两次，之后遍历取出即可。
        }
    }
    // @lc code=end


}
