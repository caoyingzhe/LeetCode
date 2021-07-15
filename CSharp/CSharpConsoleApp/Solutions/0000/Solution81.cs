using System;
namespace CSharpConsoleApp.Solutions
{
    /*
 * @lc app=leetcode.cn id=81 lang=csharp
 *
 * [81] 搜索旋转排序数组 II
 *
 * https://leetcode-cn.com/problems/search-in-rotated-sorted-array-ii/description/
 *
 * Category	Difficulty	Likes	Dislikes
 * algorithms	Medium (41.60%)	443	-
 * Tags
 * array | binary-search
 * 
 * Companies
 * Unknown
 * 
 * Total Accepted:    109.3K
 * Total Submissions: 262.9K
 * Testcase Example:  '[2,5,6,0,0,1,2]\n0'
 *
 * 已知存在一个按非降序排列的整数数组 nums ，数组中的值不必互不相同。
 * 
 * 在传递给函数之前，nums 在预先未知的某个下标 k（0 ）上进行了 旋转 ，使数组变为 [nums[k], nums[k+1], ...,
 * nums[n-1], nums[0], nums[1], ..., nums[k-1]]（下标 从 0 开始 计数）。例如，
 * [0,1,2,4,4,4,5,6,6,7] 在下标 5 处经旋转后可能变为 [4,5,6,6,7,0,1,2,4,4] 。
 * 
 * 给你 旋转后 的数组 nums 和一个整数 target ，请你编写一个函数来判断给定的目标值是否存在于数组中。如果 nums 中存在这个目标值
 * target ，则返回 true ，否则返回 false 。
 * 
 * 
 * 
 * 示例 1：
 * 输入：nums = [2,5,6,0,0,1,2], target = 0
 * 输出：true
 * 
 * 
 * 示例 2：
 * 输入：nums = [2,5,6,0,0,1,2], target = 3
 * 输出：false
 * 
 * 
 * 
 * 提示：
 * 1 <= nums.length <= 5000
 * -10^4 <= nums[i] <= 10^4
 * 题目数据保证 nums 在预先未知的某个下标上进行了旋转
 * -10^4 <= target <= -10^4 
 * 
 * 
 * 进阶：
 * 这是 搜索旋转排序数组 的延伸题目，本题中的 nums 可能包含重复元素。
 * 这会影响到程序的时间复杂度吗？会有怎样的影响，为什么？
 */

    // @lc code=start
    public class Solution81 : SolutionBase
    {/// <summary>
     /// 难度
     /// </summary>
        public override Difficulity GetDifficulity() { return Difficulity.Easy; }
        /// <summary>
        /// 关键字:
        /// </summary>
        public override string[] GetKeyWords() { return new string[] { "Solution33", "旋转后的数组" }; }
        /// <summary>
        /// 标签：
        /// </summary>
        public override Tag[] GetTags() { return new Tag[] { Tag.Tree, }; }

        public override bool Test(System.Diagnostics.Stopwatch sw)
        {
            bool isSuccess = true;
            int[] nums;
            int target;
            bool result, checkResult;

            nums = new int[] { 1, 3, 5 }; target = 0;
            result = Search(nums, target);
            checkResult = true;

            isSuccess &= result == checkResult;
            Print("isSuccess = {0} result = {1} | checkResult = {2}", isSuccess, (result), (checkResult));

            return isSuccess;
        }

        //旋转后 的数组
        /// <summary>
        /// 整数数组 nums 为旋转后的的数组，旋转前为按升序排列；
        /// TODO 待理解
        /// 279/279 cases passed (116 ms)
        /// Your runtime beats 47.09 % of csharp submissions
        /// Your memory usage beats 8.99 % of csharp submissions(25.7 MB)
        /// 作者：LeetCode - Solution
        /// 链接：https://leetcode-cn.com/problems/search-in-rotated-sorted-array-ii/solution/sou-suo-xuan-zhuan-pai-xu-shu-zu-ii-by-l-0nmp/
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public bool Search(int[] nums, int target)
        {
            int n = nums.Length;
            if (n == 0) return false;
            if (n == 1) return nums[0] == target;

            int L = 0, R = n - 1;
            while (L <= R)
            {
                int mid = (L + R) / 2;
                if (nums[mid] == target) return true;

                if (nums[L] == nums[mid] && nums[mid] == nums[R]) // [L] =[mid] = [R]
                {
                    //此时无法判断区间 [l,mid] 和区间 [mid+1,r] 哪个是有序的。
                    //只能将当前二分区间的左边界加一，右边界减一，然后在新区间上继续二分查找。
                    ++L; --R;
                }
                else if (nums[L] <= nums[mid])
                {
                    if (nums[L] <= target && target < nums[mid]) // target in [L, mid]
                    {
                        R = mid - 1; // 发现 target在 [L, mid] 区间，缩小范围为 [L，mid-1], R = mid -1;
                    }
                    else
                    {
                        L = mid + 1; // 发现 target 不在 [L, mid] 区间，直接移动 L 为 mid右侧，即 L = mid + 1
                    }
                }
                else
                {
                    if (nums[mid] < target && target <= nums[n - 1]) // target in [mid, Last]
                    {
                        L = mid + 1; // 发现 target在 [mid, Last] 区间，缩小范围为 [mid+1, Last], L = mid + 1;
                    }
                    else
                    {
                        R = mid - 1; // 发现 target 不在[mid, Last] 区间，直接移动 R 为 mid右侧，即 L = mid - 1
                    }
                }
            }
            return false;
        }
    }
    // @lc code=end
}
