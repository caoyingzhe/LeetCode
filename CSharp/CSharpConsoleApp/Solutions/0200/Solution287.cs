using System;
namespace CSharpConsoleApp.Solutions
{
    /*
     * @lc app=leetcode.cn id=287 lang=csharp
     *
     * [287] 寻找重复数
     * 
     * https://leetcode-cn.com/problems/find-the-duplicate-number/description/
     * 
     * Category	Difficulty	Likes	Dislikes
     * algorithms	Medium (66.66%)	1276	-
     * Tags
     * array | two-pointers | binary-search
     * 
     * Companies
     * bloomberg
     * 
     * Total Accepted:    158.6K
     * Total Submissions: 238K
     * Testcase Example:  '[1,3,4,2,2]'
     *
     * 给定一个包含 n + 1 个整数的数组 nums ，其数字都在 1 到 n 之间（包括 1 和 n），可知至少存在一个重复的整数。
     * 假设 nums 只有 一个重复的整数 ，找出 这个重复的数 。
     * 你设计的解决方案必须不修改数组 nums 且只用常量级 O(1) 的额外空间。
     * 
     * 示例 1：
     * 输入：nums = [1,3,4,2,2]
     * 输出：2
     * 
     * 示例 2：
     * 输入：nums = [3,1,3,4,2]
     * 输出：3
     * 
     * 示例 3：
     * 输入：nums = [1,1]
     * 输出：1
     * 
     * 示例 4：
     * 输入：nums = [1,1,2]
     * 输出：1
     *
     * 提示：
     * 1 <= n <= 105
     * nums.length == n + 1
     * 1 <= nums[i] <= n
     * nums 中 只有一个整数 出现 两次或多次 ，其余整数均只出现 一次
     * 
     * 进阶：
     * 如何证明 nums 中至少存在一个重复的数字?
     * 你可以设计一个线性级时间复杂度 O(n) 的解决方案吗？
     */

    // @lc code=start
    public class Solution287 : SolutionBase
    {
        /// <summary>
        /// 难度
        /// </summary>
        public override Difficulity GetDifficulity() { return Difficulity.Medium; }
        /// <summary>
        /// 关键字:
        /// </summary>
        public override string[] GetKeyWords() { return new string[] { "查找重复的数", "Floyd 判圈算法", "141. 环形链表 I", "142. 环形链表 II", }; }
        /// <summary>
        /// 标签：
        /// </summary>
        public override Tag[] GetTags() { return new Tag[] { Tag.BitManipulation }; }


        /// <summary>
        /// </summary>
        /// <param name="sw"></param>
        /// <returns></returns>
        public override bool Test(System.Diagnostics.Stopwatch sw)
        {
            bool isSuccess = true;

            int[] nums;
            int result, checkResult;

            nums = new int[] { };
            checkResult = 16;
            result = FindDuplicate(nums);
            isSuccess &= IsSame(result, checkResult);
            PrintResult(isSuccess, (result), (checkResult));

            return isSuccess;
        }

        /// <summary>
        /// 方法未理解
        /// 
        /// 作者：LeetCode - Solution
        /// 链接：https://leetcode-cn.com/problems/find-the-duplicate-number/solution/xun-zhao-zhong-fu-shu-by-leetcode-solution/
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int FindDuplicate(int[] nums)
        {
            int n = nums.Length;
            int l = 1, r = n - 1, ans = -1;
            while (l <= r)
            {
                int mid = (l + r) >> 1; //右移，相当于除以2， 2/3 =>1;  0/1 =>0;
                int cnt = 0;

                for (int i = 0; i < n; ++i)
                {
                    if (nums[i] <= mid)
                    {
                        cnt++;
                    }
                }
                if (cnt <= mid)
                {
                    l = mid + 1;
                }
                else
                {
                    r = mid - 1;
                    ans = mid;
                }
            }
            return ans;
        }

        /// <summary>
        /// 快慢指针
        /// 58/58 cases passed (212 ms)
        /// Your runtime beats 68.97 % of csharp submissions
        /// Your memory usage beats 37.93 % of csharp submissions(43.2 MB)
        /// 
        /// 慢指针每次走一步，快指针每次走两步
        /// 根据「Floyd 判圈算法」两个指针在有环的情况下一定会相遇
        /// 此时我们再将 slow 放置起点 0，两个指针每次同时移动一步，相遇的点就是答案
        /// 
        /// 时间复杂度：O(n)O(n)。「Floyd 判圈算法」时间复杂度为线性的时间复杂度。
        /// 空间复杂度：O(1)O(1)。我们只需要常数空间存放若干变量。
        /// 
        /// 作者：LeetCode-Solution
        /// 链接：https://leetcode-cn.com/problems/find-the-duplicate-number/solution/xun-zhao-zhong-fu-shu-by-leetcode-solution/
        ///
        /// 相关解题思路
        /// https://leetcode-cn.com/problems/linked-list-cycle-lcci/solution/shuang-bai-kuai-man-zhi-zhen-jian-dan-yi-d9ps/
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int FindDuplicate2(int[] nums)
        {
            int slow = 0, fast = 0;
            do
            {
                slow = nums[slow];
                fast = nums[nums[fast]];
            } while (slow != fast);

            slow = 0;
            while (slow != fast)
            {
                slow = nums[slow];
                fast = nums[fast];
            }
            return slow;
        }
    }
    // @lc code=end
}
