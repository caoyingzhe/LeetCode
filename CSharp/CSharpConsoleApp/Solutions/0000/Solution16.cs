using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpConsoleApp.Solutions._0000
{
    /*
     * @lc app=leetcode.cn id=16 lang=csharp
     *
     * [16] 最接近的三数之和
     *
     * https://leetcode-cn.com/problems/3sum-closest/description/
     *
     * Category	Difficulty	Likes	Dislikes
     * algorithms	Medium (45.91%)	734	-
     * Tags
     * array | two-pointers
     * 
     * Companies
     * bloomberg
     * 
     * Total Accepted:    200.5K
     * Total Submissions: 436.6K
     * Testcase Example:  '[-1,2,1,-4]\n1'
     *
     * 给定一个包括 n 个整数的数组 nums 和 一个目标值 target。找出 nums 中的三个整数，使得它们的和与 target
     * 最接近。返回这三个数的和。假定每组输入只存在唯一答案。
     * 
     * 
     * 
     * 示例：
     * 
     * 输入：nums = [-1,2,1,-4], target = 1
     * 输出：2
     * 解释：与 target 最接近的和是 2 (-1 + 2 + 1 = 2) 。
     * 
     * 
     * 
     * 
     * 提示：
     * 
     * 
     * 3 <= nums.length <= 10^3
     * -10^3 <= nums[i] <= 10^3
     * -10^4 <= target <= 10^4
     * 
     * 
     */
    class Solution16 : SolutionBase
    {
        public override bool Test(System.Diagnostics.Stopwatch sw)
        {
            bool isSuccess = true;
            int[] nums;
            int target;
            int checkResult;
            int result;

            //nums = new int[] { -1, 2, 1, -4 }; target = 1;
            //checkResult = 2;
            //int result = ThreeSumClosest(nums, target);
            //isSuccess &= result == checkResult;

            nums = new int[] { 0, 2, 1, -3 }; target = 1;
            checkResult = 0;
            result = ThreeSumClosest(nums, target);
            isSuccess &= result == checkResult;
            return isSuccess;
        }

        /// <summary>
        /// 
        /// 双指针移动思路；
        /// 
        /// 如果 a+b+c ≥ target，那么就将 c ​ 向左移动一个位置；
        /// 如果 a+b+c ＜ target, 那么就将 b 向右移动一个位置。
        /// 作者：LeetCode - Solution
        /// 链接：https://leetcode-cn.com/problems/3sum-closest/solution/zui-jie-jin-de-san-shu-zhi-he-by-leetcode-solution/
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public int ThreeSumClosest(int[] nums, int target)
        {
            Array.Sort(nums);
            int n = nums.Length;
            int best = 10000000;

            // 枚举 a
            for (int i = 0; i < n; ++i)
            {
                // 保证和上一次枚举的元素不相等
                if (i > 0 && nums[i] == nums[i - 1])
                {
                    continue;
                }
                // 使用双指针枚举 b 和 c
                int j = i + 1, k = n - 1;
                while (j < k)
                {
                    int sum = nums[i] + nums[j] + nums[k];
                    // 如果和为 target 直接返回答案
                    if (sum == target)
                    {
                        return target;
                    }
                    // 根据差值的绝对值来更新答案
                    if (Math.Abs(sum - target) < Math.Abs(best - target))
                    {
                        best = sum;
                    }
                    if (sum > target)
                    {
                        // 如果和大于 target，移动 c 对应的指针
                        int k0 = k - 1;
                        // 移动到下一个不相等的元素
                        while (j < k0 && nums[k0] == nums[k])
                        {
                            --k0;
                        }
                        k = k0;
                    }
                    else
                    {
                        // 如果和小于 target，移动 b 对应的指针
                        int j0 = j + 1;
                        // 移动到下一个不相等的元素
                        while (j0 < k && nums[j0] == nums[j])
                        {
                            ++j0;
                        }
                        j = j0;
                    }
                }
            }
            return best;
        }
    }
}
