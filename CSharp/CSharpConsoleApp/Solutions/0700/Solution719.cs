using System;
namespace CSharpConsoleApp.Solutions
{
    /*
     * @lc app=leetcode.cn id=719 lang=csharp
     *
     * [719] 找出第 k 小的距离对
     *
     * https://leetcode-cn.com/problems/find-k-th-smallest-pair-distance/description/
     *
     * Category	Difficulty	Likes	Dislikes
     * algorithms	Hard (35.98%)	171	-
     * Tags
     * array | binary-search | heap
     * 
     * Companies
     * google
     * 
     * Total Accepted:    7.5K
     * Total Submissions: 20.7K
     * Testcase Example:  '[1,3,1]\n1'
     *
     * 给定一个整数数组，返回所有数对之间的第 k 个最小距离。一对 (A, B) 的距离被定义为 A 和 B 之间的绝对差值。
     * 
     * 示例 1:
     * 输入：
     * nums = [1,3,1]
     * k = 1
     * 输出：0 
     * 解释：
     * 所有数对如下：
     * (1,3) -> 2
     * (1,1) -> 0
     * (3,1) -> 2
     * 因此第 1 个最小距离的数对是 (1,1)，它们之间的距离为 0。
     * 
     * 
     * 提示:
     * 2 <= len(nums) <= 10000.
     * 0 <= nums[i] < 1000000.
     * 1 <= k <= len(nums) * (len(nums) - 1) / 2.
     */

    public class Solution719
    {
        /// <summary>
        /// 二分法 + 双指针
        /// 19/19 cases passed (124 ms)
        /// Your runtime beats 25 % of csharp submissions
        /// Your memory usage beats 25 % of csharp submissions(25.2 MB)
        //作者：edelweisskoko
        //链接：https://leetcode-cn.com/problems/find-k-th-smallest-pair-distance/solution/719-zhao-chu-di-k-xiao-de-ju-chi-dui-er-g1i76/
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public int SmallestDistancePair(int[] nums, int k)
        {
            Array.Sort(nums);
            int n = nums.Length;
            int left = 0, right = nums[n - 1] - nums[0];

            while (left <= right)
            {
                int mid = (left + right) / 2;
                if (GetCount(mid, nums) < k)
                {
                    left = mid + 1;
                }
                else
                {
                    right = mid - 1;
                }
            }
            return left;
        }

        private int GetCount(int dis, int[] nums)
        {
            int l = 0, cnt = 0;
            for (int r = 0; r < nums.Length; r++)
            {
                while (nums[r] - nums[l] > dis)
                {
                    l++;
                }
                cnt += r - l;
            }
            return cnt;
        }

        /// <summary>
        /// 作者：hxz1998
        /// 链接：https://leetcode-cn.com/problems/find-k-th-smallest-pair-distance/solution/java-er-fen-cha-zhao-fang-fa-zhu-xing-zh-oniz/
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public int SmallestDistancePair2(int[] nums, int k)
        {
            // 首先把数组进行排序，方便进行二分查找
            Array.Sort(nums);
            // 这里的 low，指的是数组中两个数相差的最小值，high 是数组中两个值可能相差的最大值
            int low = 0, high = nums[nums.Length - 1] - nums[0];
            while (low < high)
            {
                // 找到差值的中间值，并尝试以 mid 来看是不是差值小于等于 mid 的数对个数符合要求 k
                int mid = low + (high - low) / 2;
                // count 用来统计所有的符合要求的情况，left 指针用来标记循环遍历整个数组的左边界
                int count = 0, left = 0;
                for (int right = 0; right < nums.Length; ++right)
                {
                    // 在循环过程中，如果 nums[right] - nums[left] 大于了 mid，说明 left 太小了，
                    // 这时候增大 left就可以使得数量减少
                    while (nums[right] - nums[left] > mid) ++left;
                    // 左右指针之间的任意一个数都与 `nums[right]` 都符合 nums[right] - nums[left] <= mid的要求
                    count += right - left;
                }
                // 如果符合差值小于等于 mid 的数对个数太多了（count >= k） 那么就减小最高值
                if (count >= k) high = mid;
                // 否则说明数对个数太少了，需要加大阈值 mid
                else low = mid + 1;
            }
            // 到最后 low 就是最小的差值
            return low;
        }
    }

}
