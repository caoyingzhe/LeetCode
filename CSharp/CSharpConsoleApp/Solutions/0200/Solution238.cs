using System;
namespace CSharpConsoleApp.Solutions
{
    /*
     * @lc app=leetcode.cn id=238 lang=csharp
     *
     * [238] 除自身以外数组的乘积
     *
     * https://leetcode-cn.com/problems/product-of-array-except-self/description/
     *
     * Category	Difficulty	Likes	Dislikes
     * algorithms	Medium (71.94%)	852	-
     * Tags
     * array
     * 
     * Companies
     * amazon | apple | facebook | linkedin | microsoft
     * 
     * Total Accepted:    119.4K
     * Total Submissions: 165.9K
     * Testcase Example:  '[1,2,3,4]'
     *
     * 给你一个长度为 n 的整数数组 nums，其中 n > 1，返回输出数组 output ，其中 output[i] 等于 nums 中除 nums[i]
     * 之外其余各元素的乘积。
     * 
     * 示例:
     * 输入: [1,2,3,4]
     * 输出: [24,12,8,6]
     * 
     * 提示：题目数据保证数组之中任意元素的全部前缀元素和后缀（甚至是整个数组）的乘积都在 32 位整数范围内。
     * 说明: 请不要使用除法，且在 O(n) 时间复杂度内完成此题。
     * 
     * 进阶：
     * 你可以在常数空间复杂度内完成这个题目吗？（ 出于对空间复杂度分析的目的，输出数组不被视为额外空间。）
     */

    // @lc code=start
    public class Solution238 : SolutionBase
    {
        /// <summary>
        /// 难度
        /// </summary>
        public override Difficulity GetDifficulity() { return Difficulity.Medium; }
        /// <summary>
        /// 关键字:
        /// </summary>
        public override string[] GetKeyWords() { return new string[] { "常数空间复杂度", }; }
        /// <summary>
        /// 标签：
        /// </summary>
        public override Tag[] GetTags() { return new Tag[] { Tag.Array }; }

        /// <summary>
        /// 入度：每个课程节点的入度数量等于其先修课程的数量；
        /// 出度：每个课程节点的出度数量等于其指向的后续课程数量；
        /// 所以只有当一个课程节点的入度为零时，其才是一个可以学习的自由课程。
        ///
        /// 拓扑排序即是将一个无环有向图转换为线性排序的过程。
        /// </summary>
        /// <param name="sw"></param>
        /// <returns></returns>
        public override bool Test(System.Diagnostics.Stopwatch sw)
        {
            bool isSuccess = true;
            return isSuccess;
        }
        /// <summary>
        //作者：LeetCode - Solution
        //链接：https://leetcode-cn.com/problems/product-of-array-except-self/solution/chu-zi-shen-yi-wai-shu-zu-de-cheng-ji-by-leetcode-/
        /// 空间复杂度 O(1) 的方法: 由于输出数组不算在空间复杂度内，那么我们可以将 L 或 R 数组用输出数组来计算。
        ///
        /// Step1 : 使用正向遍历计算出 L[i] 到输出数组；
        /// Step2 : 使用反向遍历计算出 R[i] * 当前数组（即 L[i]） 到输出数组，此结果即为最终结果。
        ///
        /// 20/20 cases passed (312 ms)
        /// Your runtime beats 100 % of csharp submissions
        /// Your memory usage beats 85.39 % of csharp submissions(38.4 MB)
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int[] ProductExceptSelf(int[] nums)
        {
            int n = nums.Length;
            int[] answer = new int[n];

            // answer[i] 表示索引 i 左侧所有元素的乘积
            // 因为索引为 '0' 的元素左侧没有元素， 所以 answer[0] = 1
            answer[0] = 1;
            for (int i = 1; i < n; i++)
            {
                answer[i] = nums[i - 1] * answer[i - 1];
            }

            // R 为右侧所有元素的乘积
            // 刚开始右边没有元素，所以 R = 1
            int R = 1;
            for (int i = n - 1; i >= 0; i--)
            {
                // 对于索引 i，左边的乘积为 answer[i]，右边的乘积为 R
                answer[i] = answer[i] * R;
                // R 需要包含右边所有的乘积，所以计算下一个结果时需要将当前值乘到 R 上
                R *= nums[i];
            }
            return answer;
        }
    }
    // @lc code=end


}
