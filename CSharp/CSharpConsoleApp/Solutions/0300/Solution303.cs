using System;
namespace CSharpConsoleApp.Solutions
{
    /*
     * @lc app=leetcode.cn id=303 lang=csharp
     *
     * [303] 区域和检索 - 数组不可变
     *
     * https://leetcode-cn.com/problems/range-sum-query-immutable/description/
     *
     * Category	Difficulty	Likes	Dislikes
     * algorithms	Easy (71.91%)	344	-
     * Tags
     * dynamic-programming
     * 
     * Companies
     * palantir
     * 
     * Total Accepted:    120.8K
     * Total Submissions: 167.9K
     * Testcase Example:  '["NumArray","sumRange","sumRange","sumRange"]\n' +
      '[[[-2,0,3,-5,2,-1]],[0,2],[2,5],[0,5]]'
     *
     * 给定一个整数数组  nums，求出数组从索引 i 到 j（i ≤ j）范围内元素的总和，包含 i、j 两点。
     * 
     * 实现 NumArray 类：
     * NumArray(int[] nums) 使用数组 nums 初始化对象
     * int sumRange(int i, int j) 返回数组 nums 从索引 i 到 j（i ≤ j）范围内元素的总和，包含 i、j 两点（也就是
     * sum(nums[i], nums[i + 1], ... , nums[j])）
     * 
     * 
     * 示例：
     * 
     * 输入：
     * ["NumArray", "suåmRange", "sumRange", "sumRange"]
     * [[[-2, 0, 3, -5, 2, -1]], [0, 2], [2, 5], [0, 5]]
     * 输出：
     * [null, 1, -1, -3]
     * 
     * 解释：
     * NumArray numArray = new NumArray([-2, 0, 3, -5, 2, -1]);
     * numArray.sumRange(0, 2); // return 1 ((-2) + 0 + 3)
     * numArray.sumRange(2, 5); // return -1 (3 + (-5) + 2 + (-1)) 
     * numArray.sumRange(0, 5); // return -3 ((-2) + 0 + 3 + (-5) + 2 + (-1))
     * 
     * 
     * 提示：
     * 0 
     * -10^5 
     * 0 
     * 最多调用 10^4 次 sumRange 方法
     */
    public class Solution303 : SolutionBase
    {
        /// <summary>
        /// 难度
        /// </summary>
        public override Difficulity GetDifficulity() { return Difficulity.Easy; }
        /// <summary>
        /// 关键字:
        /// </summary>
        public override string[] GetKeyWords() { return new string[] { "" }; }
        /// <summary>
        /// 标签：
        /// </summary>
        public override Tag[] GetTags() { return new Tag[] { Tag.String }; }

        public override bool Test(System.Diagnostics.Stopwatch sw)
        {
            bool isSuccess = true;

            NumArray na = new NumArray(new int[] { -2, 0, 3, -5, 2, -1});
            Print("" + na.SumRange(0,2));
            Print("" + na.SumRange(2,5));
            Print("" + na.SumRange(0,5));

            return isSuccess;
        }
    }

    //15/15 cases passed (164 ms)
    //Your runtime beats 92.44 % of csharp submissions
    //Your memory usage beats 65.55 % of csharp submissions(35.3 MB)
    // @lc code=start
    public class NumArray
    {
        private int[] nums;
        private int[] dp;
        public NumArray(int[] nums)
        {
            int n = nums.Length;

            if (n == 0) return;

            this.dp = new int[n];

            dp[0] = nums[0];
            for(int i=1; i<n;i++)
            {
                dp[i] += dp[i - 1] + nums[i];
            }
        }

        public int SumRange(int left, int right)
        {
            if (dp == null) return 0;
            if (left == 0) return dp[right];
            return dp[right] - dp[left-1];
        }
    }

    /**
     * Your NumArray object will be instantiated and called as such:
     * NumArray obj = new NumArray(nums);
     * int param_1 = obj.SumRange(left,right);
     */
    // @lc code=end


}
