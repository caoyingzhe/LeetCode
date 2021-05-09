using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpConsoleApp.Solutions._0000
{
    /*
     * @lc app=leetcode.cn id=18 lang=csharp
     *
     * [18] 四数之和
     *
     * https://leetcode-cn.com/problems/4sum/description/
     *
     * Category	Difficulty	Likes	Dislikes
     * algorithms	Medium (40.11%)	794	-
     * Tags
     * array | hash-table | two-pointers
     * 
     * Companies
     * linkedin
     * 
     * Total Accepted:    167.2K
     * Total Submissions: 416.7K
     * Testcase Example:  '[1,0,-1,0,-2,2]\n0'
     *
     * 给定一个包含 n 个整数的数组 nums 和一个目标值 target，判断 nums 中是否存在四个元素 a，b，c 和 d ，使得 a + b + c
     * + d 的值与 target 相等？找出所有满足条件且不重复的四元组。
     * 
     * 注意：答案中不可以包含重复的四元组。
     * x
     * 示例 1：
     * 输入：nums = [1,0,-1,0,-2,2], target = 0
     * 输出：[[-2,-1,1,2],[-2,0,0,2],[-1,0,0,1]]
     * 
     * 示例 2：
     * 输入：nums = [], target = 0
     * 输出：[]
     * 
     * 提示：x
     * 0 <= nums.length <= 200
     * -109 <= nums[i] <= 109
     * -109 <= target <= 109 
     */
    class Solution18 : SolutionBase
    {
        public override bool Test(System.Diagnostics.Stopwatch sw)
        {
            return true;
        }
        /// <summary>
        /// 283/283 cases passed (288 ms)
        /// Your runtime beats 94.44 % of csharp submissions
        /// Your memory usage beats 22.92 % of csharp submissions(32.1 MB)
        /// 
        /// 作者：LeetCode-Solution
        /// 链接：https://leetcode-cn.com/problems/4sum/solution/si-shu-zhi-he-by-leetcode-solution/
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public IList<IList<int>> FourSum(int[] nums, int target)
        {
            List<IList<int>> quadruplets = new List<IList<int>>();
            if (nums == null || nums.Length < 4)
            {
                return quadruplets;
            }
            //升序排序
            Array.Sort(nums);
            int length = nums.Length;
            for (int i = 0; i < length - 3; i++)
            {
                //排除重复数值
                //同一重循环中，如果当前元素与上一个元素相同，则跳过当前元素
                if (i > 0 && nums[i] == nums[i - 1])
                {
                    continue;
                }
                //确定第一个数之后, 排除首部连续4个数的和 > target的 
                //由于是升序，说明此时剩下的三个数无论取什么值，四数之和一定大于 target，因此退出第一重循环；
                if (nums[i] + nums[i + 1] + nums[i + 2] + nums[i + 3] > target)
                {
                    break;
                }
                //确定第一个数之后, 排除首1尾3的和 < target的
                //说明此时剩下的三个数无论取什么值，四数之和一定小于 target，因此第一重循环直接进入下一轮
                if (nums[i] + nums[length - 3] + nums[length - 2] + nums[length - 1] < target)
                {
                    continue;
                }
                for (int j = i + 1; j < length - 2; j++)
                {
                    //排除重复数值
                    //同一重循环中，如果当前元素与上一个元素相同，则跳过当前元素
                    if (j > i + 1 && nums[j] == nums[j - 1])
                    {
                        continue;
                    }
                    //在确定前两个数之后，如果 nums[i] + nums[j] + nums[j+1] + nums[j+2] > target，
                    //说明此时剩下的两个数无论取什么值，四数之和一定大于 target，因此退出第二重循环；
                    if (nums[i] + nums[j] + nums[j + 1] + nums[j + 2] > target)
                    {
                        break;
                    }
                    //在确定前两个数之后，如果 nums[i]+nums[j]+nums[n−2]+nums[n−1]<target，
                    //说明此时剩下的两个数无论取什么值，四数之和一定小于 target，因此第二重循环直接进入下一轮
                    if (nums[i] + nums[j] + nums[length - 2] + nums[length - 1] < target)
                    {
                        continue;
                    }
                    int left = j + 1, right = length - 1;

                    //每一种循环枚举到的下标必须大于上一重循环枚举到的下标；
                    while (left < right)
                    {
                        int sum = nums[i] + nums[j] + nums[left] + nums[right];
                        if (sum == target)
                        {
                            //如果和等于target，则将枚举到的四个数加到答案中，
                            quadruplets.Add(new List<int>(new int[] { nums[i], nums[j], nums[left], nums[right]}));

                            //然后将左指针右移直到遇到不同的数，
                            while (left < right && nums[left] == nums[left + 1])
                            {
                                left++;
                            }
                            left++;
                            //将右指针左移直到遇到不同的数；
                            while (left < right && nums[right] == nums[right - 1])
                            {
                                right--;
                            }
                            right--;
                        }
                        //如果和小于 target，则将左指针右移一位；
                        else if (sum < target)
                        {
                            left++;
                        }
                        //如果和大于 target，则将右指针左移一位。
                        else
                        {
                            right--;
                        }
                    }
                }
            }
            return quadruplets;
        }
    }
}
