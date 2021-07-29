using System;
using System.Collections.Generic;
namespace CSharpConsoleApp.Solutions
{
    /*
 * @lc app=leetcode.cn id=496 lang=csharp
 *
 * [496] 下一个更大元素 I
 *
 * https://leetcode-cn.com/problems/next-greater-element-i/description/
 *
 * algorithms
 * Easy (68.33%)
 * Likes:    452
 * Dislikes: 0
 * Total Accepted:    88K
 * Total Submissions: 128.6K
 * Testcase Example:  '[4,1,2]\n[1,3,4,2]'
 *
 * 给你两个 没有重复元素 的数组 nums1 和 nums2 ，其中nums1 是 nums2 的子集。
 * 
 * 请你找出 nums1 中每个元素在 nums2 中的下一个比其大的值。
 * 
 * nums1 中数字 x 的下一个更大元素是指 x 在 nums2 中对应位置的右边的第一个比 x 大的元素。如果不存在，对应位置输出 -1 。
 * 
 * 
 * 
 * 示例 1:
 * 
 * 
 * 输入: nums1 = [4,1,2], nums2 = [1,3,4,2].
 * 输出: [-1,3,-1]
 * 解释:
 * ⁠   对于 num1 中的数字 4 ，你无法在第二个数组中找到下一个更大的数字，因此输出 -1 。
 * ⁠   对于 num1 中的数字 1 ，第二个数组中数字1右边的下一个较大数字是 3 。
 * ⁠   对于 num1 中的数字 2 ，第二个数组中没有下一个更大的数字，因此输出 -1 。
 * 
 * 示例 2:
 * 
 * 
 * 输入: nums1 = [2,4], nums2 = [1,2,3,4].
 * 输出: [3,-1]
 * 解释:
 * 对于 num1 中的数字 2 ，第二个数组中的下一个较大数字是 3 。
 * ⁠   对于 num1 中的数字 4 ，第二个数组中没有下一个更大的数字，因此输出 -1 。
 * 
 * 
 * 
 * 
 * 提示：
 * 
 * 
 * 1 
 * 0 
 * nums1和nums2中所有整数 互不相同
 * nums1 中的所有整数同样出现在 nums2 中
 * 
 * 
 * 
 * 
 * 进阶：你可以设计一个时间复杂度为 O(nums1.length + nums2.length) 的解决方案吗？
 * 
 */

    // @lc code=start
    public class Solution496 : SolutionBase
    {
        /// <summary>
        /// 难度
        /// </summary>
        public override Difficulity GetDifficulity() { return Difficulity.Easy; }
        /// <summary>
        /// 关键字:
        /// </summary>
        public override string[] GetKeyWords() { return new string[] {  }; }
        /// <summary>
        /// 标签：
        /// </summary>
        public override Tag[] GetTags() { return new Tag[] { Tag.Unknown }; }

        
        public override bool Test(System.Diagnostics.Stopwatch sw)
        {
            bool isSuccess = true;
            int[] nums1, nums2;
            int[] result, checkResult;

            nums1 = new int[] { 4, 1, 2 };
            nums2 = new int[] { 1,3,4,2 };
            checkResult = new int[] { -1, 3, -1 };
            result = NextGreaterElement(nums1, nums2);
            isSuccess &= IsSame(result, checkResult);
            PrintResult(isSuccess, GetArrayStr(result), GetArrayStr(checkResult));


            nums1 = new int[] { 2, 4 };
            nums2 = new int[] { 1, 2,3,4 };
            checkResult = new int[] { 3, -1 };
            result = NextGreaterElement(nums1, nums2);
            isSuccess &= IsSame(result, checkResult);
            PrintResult(isSuccess, GetArrayStr(result), GetArrayStr(checkResult));


            return isSuccess;
        }

        /// <summary>
        /// 作者：ironmarmot
        /// 链接：https://leetcode-cn.com/problems/next-greater-element-i/solution/xia-yi-ge-geng-da-yuan-su-by-ironmarmot-pyuc/
        /// 15/15 cases passed (228 ms)
        /// Your runtime beats 100 % of csharp submissions
        /// Your memory usage beats 54.2 % of csharp submissions(31.1 MB)
        /// </summary>
        /// <param name="nums1"></param>
        /// <param name="nums2"></param>
        /// <returns></returns>
        public int[] NextGreaterElement(int[] nums1, int[] nums2)
        {
            Stack<int> stack = new Stack<int>();
            Dictionary<int, int> dics = new Dictionary<int, int>();

            stack.Push(nums2[0]);
            for (int i = 1; i < nums2.Length; i++)
            {
                stack.Peek();
                while (stack.Count > 0 && nums2[i] > stack.Peek())
                {
                    dics.Add(stack.Pop(), nums2[i]);
                }
                stack.Push(nums2[i]);
            }

            //遍历完成后，注意要清空stack
            while (stack.Count > 0)
                dics.Add(stack.Pop(), -1);
            //经过以上步骤，nums2中所有元素的更大元素已存储在dics中
            for (int i = 0; i < nums1.Length; i++)
                nums1[i] = dics[nums1[i]];

            return nums1;
        }
    }
    // @lc code=end


}
