using System;
using System.Collections.Generic;
namespace CSharpConsoleApp.Solutions
{
    /*
 * @lc app=leetcode.cn id=229 lang=csharp
 *
 * [229] 求众数 II
 *
 * https://leetcode-cn.com/problems/majority-element-ii/description/
 *
 * Category	Difficulty	Likes	Dislikes
 * algorithms	Medium (45.85%)	376	-
 * Tags
 * array
 * 
 * Companies
 * zenefits
 * 
 * Total Accepted:    31.5K
 * Total Submissions: 68.7K
 * Testcase Example:  '[3,2,3]'
 *
 * 给定一个大小为 n 的整数数组，找出其中所有出现超过 ⌊ n/3 ⌋ 次的元素。
 * 进阶：尝试设计时间复杂度为 O(n)、空间复杂度为 O(1)的算法解决此问题。
 *
 * 
 * 示例 1：
 * 输入：[3,2,3]
 * 输出：[3]
 * 
 * 示例 2：
 * 输入：nums = [1]
 * 输出：[1]
 * 
 * 
 * 示例 3：
 * 输入：[1,1,1,3,3,2,2,2]
 * 输出：[1,2]
 *
 * 
 * 提示：
 * 1 <= nums.length <= 5 * 10^4
 * -10^9 <= nums[i] <= 10^9
 */

    // @lc code=start
    public class Solution229 : SolutionBase
    {
        /// <summary>
        /// 难度
        /// </summary>
        public override Difficulity GetDifficulity() { return Difficulity.Medium; }
        /// <summary>
        /// 关键字:
        /// </summary>
        public override string[] GetKeyWords() { return new string[] { "摩尔投票法" }; }
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
            int[] nums;

            IList<int> result, checkResult;

            nums = new int[] { 1, 1, 1, 3, 3, 2, 2, 2 };
            checkResult = new int[] { 0, 2 };
            result = MajorityElement(nums);
            isSuccess &= IsListSame(result, checkResult);
            Print("isSuccess = {0} | result= {1} | checkResult= {2} | ", isSuccess, (result), (checkResult));

            return isSuccess;
        }

        //作者：wotxdx
        //链接：https://leetcode-cn.com/problems/majority-element-ii/solution/liang-fu-dong-hua-yan-shi-mo-er-tou-piao-fa-zui-zh/
        /// <summary>
        /// 82/82 cases passed (280 ms)
        /// Your runtime beats 100 % of csharp submissions
        /// Your memory usage beats 18.75 % of csharp submissions(33.2 MB)
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public IList<int> MajorityElement(int[] nums)
        {
            // 创建返回值
            List<int> res = new List<int>();
            if (nums == null || nums.Length == 0) return res;
            // 初始化两个候选人candidate，和他们的计票
            int cand1 = nums[0], count1 = 0;
            int cand2 = nums[0], count2 = 0;

            // 摩尔投票法，分为两个阶段：配对阶段和计数阶段
            // 配对阶段
            foreach (int num in nums)
            {
                // 投票
                if (cand1 == num)
                {
                    count1++;
                    continue;
                }
                if (cand2 == num)
                {
                    count2++;
                    continue;
                }

                // 第1个候选人配对
                if (count1 == 0)
                {
                    cand1 = num;
                    count1++;
                    continue;
                }
                // 第2个候选人配对
                if (count2 == 0)
                {
                    cand2 = num;
                    count2++;
                    continue;
                }

                count1--;
                count2--;
            }

            // 计数阶段
            // 找到了两个候选人之后，需要确定票数是否满足大于 N/3
            count1 = 0;
            count2 = 0;
            foreach (int num in nums)
            {
                if (cand1 == num) count1++;
                else if (cand2 == num) count2++;
            }

            if (count1 > nums.Length / 3) res.Add(cand1);
            if (count2 > nums.Length / 3) res.Add(cand2);

            return res;
        }
    }
    // @lc code=end


}
