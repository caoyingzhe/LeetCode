using System;
using System.Collections.Generic;
namespace CSharpConsoleApp.Solutions
{
    /*
     * @lc app=leetcode.cn id=398 lang=csharp
     *
     * [398] 随机数索引
     *
     * https://leetcode-cn.com/problems/random-pick-index/description/
     *
     * Category	Difficulty	Likes	Dislikes
     * algorithms	Medium (64.88%)	113	-
     * Tags
     * reservoir-sampling
     * 
     * Companies
     * facebook
     * 
     * Total Accepted:    12.9K
     * Total Submissions: 19.9K
     * Testcase Example:  '["Solution","pick","pick","pick"]\n[[[1,2,3,3,3]],[3],[1],[3]]'
     *
     * 给定一个可能含有重复元素的整数数组，要求随机输出给定的数字的索引。 您可以假设给定的数字一定存在于数组中。
     * 
     * 注意：
     * 数组大小可能非常大。 使用太多额外空间的解决方案将不会通过测试。
     * 
     * 示例:
     * 
     * 
     * int[] nums = new int[] {1,2,3,3,3};
     * Solution solution = new Solution(nums);
     * 
     * // pick(3) 应该返回索引 2,3 或者 4。每个索引的返回概率应该相等。
     * solution.pick(3);
     * 
     * // pick(1) 应该返回 0。因为只有nums[0]等于1。
     * solution.pick(1);
     */

    // @lc code=start
    public class Solution398 : SolutionBase
    {
        /// <summary>
        /// 难度
        /// </summary>
        public override Difficulity GetDifficulity() { return Difficulity.Medium; }
        /// <summary>
        /// 关键字:
        /// </summary>
        public override string[] GetKeyWords() { return new string[] { "蓄水池抽样算法", "链表随机节点/随机数索引" }; }
        /// <summary>
        /// 标签：
        /// </summary>
        public override Tag[] GetTags() { return new Tag[] { Tag.ReservoirSampling }; }

        
        public override bool Test(System.Diagnostics.Stopwatch sw)
        {
            bool isSuccess = true;
            int result; List<int> checkResult;

            int[] nums = new int[] { 1, 2, 3, 3, 3 };
            Solution solution = new Solution(nums);

            // pick(3) 应该返回索引 2,3 或者 4。每个索引的返回概率应该相等。
            result = solution.Pick(3);
            checkResult = new List<int>(new int[] {2,3,4});
            isSuccess &= checkResult.Contains(result);
            PrintResult(isSuccess, result, GetArrayStr(checkResult));

            // pick(1) 应该返回 0。因为只有nums[0]等于1。
            result = solution.Pick(1);
            checkResult = new List<int>(new int[] { 0 });
            isSuccess &= checkResult.Contains(result);
            PrintResult(isSuccess, result, GetArrayStr(checkResult));

            return isSuccess;
        }

        /// <summary>
        /// 作者：Rubin96
        /// 链接：https://leetcode-cn.com/problems/random-pick-index/solution/jian-dan-javadai-ma-shui-tang-chou-yang-h76d0/
        /// 14/14 cases passed (280 ms)
        /// Your runtime beats 100 % of csharp submissions
        /// Your memory usage beats 90.91 % of csharp submissions(47.9 MB)
        /// </summary>
        public class Solution
        {
            private int[] nums;
            public Solution(int[] nums)
            {
                this.nums = nums;
            }

            public int Pick(int target)
            {
                Random r = new Random();
                int n = 0;
                int index = 0;
                for (int i = 0; i < nums.Length; i++)
                { 
                    if (nums[i] == target)
                    {
                        //计算同一个target的个数
                        n++;
                        //我们以同一个数字的频数1/n的概率选出其中一个索引
                        if (r.Next(n) == 0) index = i;
                    }
                }
                return index;
            }
        }
    }
    

    /**
     * Your Solution object will be instantiated and called as such:
     * Solution obj = new Solution(nums);
     * int param_1 = obj.Pick(target);
     */
    // @lc code=end


}
