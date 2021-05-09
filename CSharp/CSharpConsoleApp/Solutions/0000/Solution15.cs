using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpConsoleApp.Solutions._0000
{
    /*
     * @lc app=leetcode.cn id=15 lang=csharp
     *
     * [15] 三数之和
     *
     * https://leetcode-cn.com/problems/3sum/description/
     *
     * 
     * Category	Difficulty	Likes	Dislikes
     * algorithms	Medium (31.53%)	3170	-
     * Tags
     * array | two-pointers
     * 
     * Companies
     * adobe | amazon | bloomberg | facebook | microsoft
     * 
     * Total Accepted:    465.9K
     * Total Submissions: 1.5M
     * Testcase Example:  '[-1,0,1,2,-1,-4]'
     *
     * 给你一个包含 n 个整数的数组 nums，判断 nums 中是否存在三个元素 a，b，c ，使得 a + b + c = 0 ？请你找出所有和为 0
     * 且不重复的三元组。
     * 
     * 注意：答案中不可以包含重复的三元组。
     * 
     * 示例 1：
     * 输入：nums = [-1,0,1,2,-1,-4]
     * 输出：[[-1,-1,2],[-1,0,1]]
     * 
     * 示例 2：
     * 输入：nums = []
     * 输出：[]
     * 
     * 示例 3：
     * 输入：nums = [0]
     * 输出：[]
     * 
     * 提示：
     * 
     * 0 <= nums.length <= 3000
     * -105 <= nums[i] <= 10^5
     */
    class Solution15
    {
        /*
         * 时间复杂度：O(n2)
         * 数组排序    O(NlogN)，
         * 遍历数组    O(n)
         * 双指针遍历  O(n)
         * 总体        O(n2) + O(NlogN) + O(n) + O(n)
         * 
         * 空间复杂度：O(1)
         * 
         算法流程：
            1. 特判，对于数组长度 n，如果数组为 null 或者数组长度小于 3，返回 []。
            2. 对数组进行排序。
            3. 遍历排序后数组：
               3.1 若 nums[i]>0nums[i]>0：因为已经排序好，所以后面不可能有三个数加和等于 00，直接返回结果。
               3.2 对于重复元素：跳过，避免出现重复解
               3.3 令左指针 L=i+1，右指针 R=n−1，当 L<R 时，执行循环：
                   3.3.1 当 nums[i]+nums[L]+nums[R]==0，执行循环，判断左界和右界是否和下一位置重复，去除重复解。并同时将 L,R 移到下一位置，寻找新的解
                   3.3.2 若和大于 0，说明 nums[R] 太大，R 左移
                   3.3.3 若和小于 0，说明 nums[L] 太小，L 右移

            作者：wu_yan_zu
            链接：https://leetcode-cn.com/problems/3sum/solution/pai-xu-shuang-zhi-zhen-zhu-xing-jie-shi-python3-by/
         
         */


        /// <summary>
        /// 
        /// 作者：LeetCode-Solution
        /// 链接：https://leetcode-cn.com/problems/3sum/solution/san-shu-zhi-he-by-leetcode-solution/
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public IList<IList<int>> ThreeSum(int[] nums)
        {
            int n = nums.Length;
            Array.Sort(nums);
            List<IList<int>> ans = new List<IList<int>>();
            // 枚举 a
            for (int first = 0; first < n; ++first)
            {
                // 需要和上一次枚举的数不相同
                if (first > 0 && nums[first] == nums[first - 1])
                {
                    continue;
                }
                // c 对应的指针初始指向数组的最右端
                int third = n - 1;
                int target = -nums[first];
                // 枚举 b
                for (int second = first + 1; second < n; ++second)
                {
                    // 需要和上一次枚举的数不相同
                    if (second > first + 1 && nums[second] == nums[second - 1])
                    {
                        continue;
                    }
                    // 需要保证 b 的指针在 c 的指针的左侧
                    while (second < third && nums[second] + nums[third] > target)
                    {
                        --third;
                    }
                    // 如果指针重合，随着 b 后续的增加
                    // 就不会有满足 a+b+c=0 并且 b<c 的 c 了，可以退出循环
                    if (second == third)
                    {
                        break;
                    }
                    if (nums[second] + nums[third] == target)
                    {
                        List<int> list = new List<int>();
                        list.Add(nums[first]);
                        list.Add(nums[second]);
                        list.Add(nums[third]);
                        ans.Add(list);
                    }
                }
            }
            return ans;
        }
    }
}
