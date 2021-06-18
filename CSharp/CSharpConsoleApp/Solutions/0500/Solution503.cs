using System;
using System.Collections.Generic;
namespace CSharpConsoleApp.Solutions
{
    /*
 * @lc app=leetcode.cn id=503 lang=csharp
 *
 * [503] 下一个更大元素 II
 *
 * https://leetcode-cn.com/problems/next-greater-element-ii/description/
 *
 * Category	Difficulty	Likes	Dislikes
 * algorithms	Medium (62.78%)	440	-
 * Tags
 * stack
 * 
 * Companies
 * google
 * 
 * Total Accepted:    89K
 * Total Submissions: 141.8K
 * Testcase Example:  '[1,2,1]'
 *
 * 给定一个循环数组（最后一个元素的下一个元素是数组的第一个元素），输出每个元素的下一个更大元素。数字 x
 * 的下一个更大的元素是按数组遍历顺序，这个数字之后的第一个比它更大的数，这意味着你应该循环地搜索它的下一个更大的数。如果不存在，则输出 -1。
 * 
 * 示例 1:
 * 
 * 
 * 输入: [1,2,1]
 * 输出: [2,-1,2]
 * 解释: 第一个 1 的下一个更大的数是 2；
 * 数字 2 找不到下一个更大的数； 
 * 第二个 1 的下一个最大的数需要循环搜索，结果也是 2。
 * 
 * 
 * 注意: 输入数组的长度不会超过 10000。
 * 
 */

    // @lc code=start
    public class Solution503 : SolutionBase
    {
        /// <summary>
        /// 难度
        /// </summary>
        public override Difficulity GetDifficulity() { return Difficulity.Medium; }
        /// <summary>
        /// 关键字:
        /// </summary>
        public override string[] GetKeyWords() { return new string[] { "循环数组", "单调栈" }; }
        /// <summary>
        /// 标签：
        /// </summary>
        public override Tag[] GetTags() { return new Tag[] { Tag.Array, }; }

        public override bool Test(System.Diagnostics.Stopwatch sw)
        {
            bool isSuccess = true;
            int[] nums;
            int[] result, checkResult;

            nums = new int[] { 1, 2, 1 };
            checkResult = new int[] { 2, -1, 2 };
            result = NextGreaterElements(nums);

            isSuccess &= IsSame(result, checkResult);
            PrintResult(isSuccess, (result), (checkResult));

            nums = new int[] { 5, 3, 2, 1, 7 };
            checkResult = new int[] { 7,7,7,7,-1 };
            result = NextGreaterElements(nums);

            isSuccess &= IsSame(result, checkResult);
            PrintResult(isSuccess, (result), (checkResult));
            return isSuccess;
        }

        /// <summary>
        /// 223/223 cases passed (332 ms)
        /// Your runtime beats 72.5 % of csharp submissions
        /// Your memory usage beats 66.25 % of csharp submissions(38 MB)
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int[] NextGreaterElements(int[] nums)
        {
            int n = nums.Length;
            int[] ret = new int[n];
            for (int i = 0; i < n; i++) ret[i] = -1;

            //单调栈中保存的是下标
            //而单调栈的性质是：当一个元素A加入栈内时，会在栈内一路向下并碾碎途中比它小的元素。
            //在碾碎每一个元素时，A就是这个元素的下一个更大元素。这么做避免了需要重复扫描，只用扫描一次O(n)。
            //本题是循环数组，想要求得每个元素的nextMax需要遍历数组两次，所以将前n - 1个元素接到数组尾部，等价于取模
            //作者：AAlchemist
            //链接：https://leetcode-cn.com/problems/next-greater-element-ii/solution/dan-diao-zhan-jie-jue-xia-yi-ge-geng-da-3lkr9/

            Stack<int> stack = new Stack<int>();
            for (int i = 0; i < n * 2 - 1; i++)
            {
                while (stack.Count != 0 && nums[stack.Peek()] < nums[i % n])
                {
                    ret[stack.Pop()] = nums[i % n];
                }
                stack.Push(i % n);
            }
            return ret;
        }
    }
    // @lc code=end


}
