using System;
using System.Collections.Generic;
namespace CSharpConsoleApp.Solutions
{
    /*
     * @lc app=leetcode.cn id=698 lang=csharp
     *
     * [698] 划分为k个相等的子集
     *
     * https://leetcode-cn.com/problems/partition-to-k-equal-sum-subsets/description/
     *
     * Category	Difficulty	Likes	Dislikes
     * algorithms	Medium (43.62%)	388	-
     * Tags
     * dynamic-programming | recursion
     * 
     * Companies
     * linkedin
     * 
     * Total Accepted:    25.1K
     * Total Submissions: 57.4K
     * Testcase Example:  '[4,3,2,3,5,2,1]\n4'
     *
     * 给定一个整数数组  nums 和一个正整数 k，找出是否有可能把这个数组分成 k 个非空子集，其总和都相等。
     * 
     * 示例 1：
     * 输入： nums = [4, 3, 2, 3, 5, 2, 1], k = 4
     * 输出： True
     * 说明： 有可能将其分成 4 个子集（5），（1,4），（2,3），（2,3）等于总和。
     * 
     * 
     * 提示：
     * 1 <= k <= len(nums) <= 16
     * 0 < nums[i] < 10000
     */

    // @lc code=start
    public class Solution698 : SolutionBase
    {
        /// <summary>
        /// 难易度:
        /// </summary>
        public override Difficulity GetDifficulity() { return Difficulity.Medium; }
        /// <summary>
        /// 关键字:
        /// </summary>
        public override string[] GetKeyWords() { return new string[] { "关联：Solution473", "模仿通过" }; }
        /// <summary>
        /// 标签：
        /// </summary>
        public override Tag[] GetTags() { return new Tag[] { Tag.DynamicProgramming, Tag.Recursion }; }

        //TODO
        public override bool Test(System.Diagnostics.Stopwatch sw)
        {
            bool isSuccess = true;
            int[] nums; int k;
            bool result, checkResult;

            //nums = new int[] { 4, 3, 2, 3, 5, 2, 1 }; k = 4;
            //checkResult = true;
            //result = CanPartitionKSubsets(nums, k);
            //isSuccess &= IsSame(result, checkResult);
            //PrintResult(isSuccess, result, checkResult);

            //nums = new int[] { 4, 3, 2, 3, 5, 2, 1, 4 }; k = 4;
            //checkResult = true;
            //result = CanPartitionKSubsets(nums, k);
            //isSuccess &= IsSame(result, checkResult);
            //PrintResult(isSuccess, result, checkResult);

            //nums = new int[] { 4, 3, 2, 3, 5, 2, 1, 1, 7, 3, 5, 8, 6, 2 }; k = 4;
            //checkResult = true;
            //result = CanPartitionKSubsets(nums, k);
            //isSuccess &= IsSame(result, checkResult);
            //PrintResult(isSuccess, result, checkResult);

            //nums = new int[] { 4, 3, 2, 3, 5, 2, 1, 1, 3, 2, 2, 4, 4, }; k = 4;
            //checkResult = true;
            //result = CanPartitionKSubsets(nums, k);
            //isSuccess &= IsSame(result, checkResult);
            //PrintResult(isSuccess, result, checkResult);

            nums = new int[] { 4, 3, 2, 3, 5, 2, 1, 1, 7, 3, 5, 8, 6, 2, 13, 1, 1, 1 }; k = 4;
            checkResult = true;
            result = CanPartitionKSubsets(nums, k);
            isSuccess &= IsSame(result, checkResult);
            PrintResult(isSuccess, result, checkResult);

            nums = new int[] { 15, 13, 12, 14, 2, 2, 2 }; k = 3;
            checkResult = false;
            result = CanPartitionKSubsets(nums, k);
            isSuccess &= IsSame(result, checkResult);
            PrintResult(isSuccess, result, checkResult);

            nums = new int[] { 1, 1, 1, 1, 2, 2, 2, 2 }; k = 2;
            checkResult = true;
            result = CanPartitionKSubsets(nums, k);
            isSuccess &= IsSame(result, checkResult);
            PrintResult(isSuccess, result, checkResult);

            return isSuccess;
        }

        /// <summary>
        /// 142/142 cases passed (84 ms)
        /// Your runtime beats 100 % of csharp submissions
        /// Your memory usage beats 83.33 % of csharp submissions(24.2 MB)
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public bool CanPartitionKSubsets(int[] nums, int k)
        {
            int[] size = new int[k];

            int sum = 0;
            for (int i = 0; i < nums.Length; i++)
                sum += nums[i];

            if (sum == 0 || sum % k != 0) return false;

            //先排序
            Array.Sort(nums);
            return DFS(nums, nums.Length - 1, sum / k, size);
        }

        public bool DFS(int[] nums, int index, int target, int[] size)
        {
            if (index == -1)
            {
                //都访问完了，有一个不等，就返回false
                int pre = size[0];
                for (int i = 1; i < size.Length; i++)
                {
                    if (pre != size[i])
                        return false;
                }
                return true;
            }

            //到这一步说明值还没访问完
            for (int i = 0; i < size.Length; i++)
            {
                //如果把当前值放到size[i]这个边上，他的长度大于target，我们直接跳过。或者
                // size[i] == size[i - 1]即上一个分支的值和当前分支的一样，上一个分支没有成功，
                //说明这个分支也不会成功，直接跳过即可。
                if (size[i] + nums[index] > target ||
                    //(i > 0 && size[i] == size[i - 1]) ||
                    (index == nums.Length - 1 && i != 0))
                    continue;
                //如果当前值放到size[i]这个边上，长度不大于target，我们就放上面
                size[i] += nums[index];
                //然后在放下一个值，能平均分配，直接返回true
                if (DFS(nums, index - 1, target, size))
                    return true;
                //如果当前值放到size[i]这个边上，最终不能构成平均分配，我们就把他从
                //size[i]这个边上给移除，然后在试其他的边
                size[i] -= nums[index];
            }
            return false;
        }
    }
    // @lc code=end


}
