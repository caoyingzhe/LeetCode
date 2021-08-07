using System;
namespace CSharpConsoleApp.Solutions
{
    /*
     * @lc app=leetcode.cn id=33 lang=csharp
     *
     * [33] 搜索旋转排序数组
     *
     * https://leetcode-cn.com/problems/search-in-rotated-sorted-array/description/
     * 
     * Category	Difficulty	Likes	Dislikes
     * algorithms	Medium (42.03%)	1422	-
     * Tags
     * array | binary-search
     * 
     * Companies
     * bloomberg | facebook | linkedin | microsoft | uber
     * 
     * Total Accepted:    278.5K
     * Total Submissions: 668.1K
     * Testcase Example:  '[4,5,6,7,0,1,2]\n0'
     *
     * 整数数组 nums 按升序排列，数组中的值 互不相同 。
     * 
     * 在传递给函数之前，nums 在预先未知的某个下标 k（0 ）上进行了 旋转，使数组变为 [nums[k], nums[k+1], ...,
     * nums[n-1], nums[0], nums[1], ..., nums[k-1]]（下标 从 0 开始 计数）。例如，
     * [0,1,2,4,5,6,7] 在下标 3 处经旋转后可能变为 [4,5,6,7,0,1,2] 。
     * 
     * 给你 旋转后 的数组 nums 和一个整数 target ，如果 nums 中存在这个目标值 target ，则返回它的下标，否则返回 -1 。
     * 
     * 示例 1：
     * 输入：nums = [4,5,6,7,0,1,2], target = 0
     * 输出：4
     * 
     * 示例 2：
     * 输入：nums = [4,5,6,7,0,1,2], target = 3
     * 输出：-1
     * 
     * 示例 3：
     * 输入：nums = [1], target = 0
     * 输出：-1
     * 
     * 提示：
     * 1 <= nums.length <= 5000
     * -10^4 <= nums[i] <= 10^4
     * nums 中的每个值都 独一无二
     * 题目数据保证 nums 在预先未知的某个下标上进行了旋转
     * -10^4 <= target <= 10^4
     * 
     * 进阶：你可以设计一个时间复杂度为 O(log n) 的解决方案吗？
     * 
     */
    public class Solution33 : SolutionBase
    {
        /// <summary>
        /// 难易度:
        /// </summary>
        public override Difficulity GetDifficulity() { return Difficulity.Medium; }
        /// <summary>
        /// 关键字:
        /// </summary>
        public override string[] GetKeyWords() { return new string[] { "哈希表", "双指针", "字符串" }; }
        /// <summary>
        /// 标签： 图
        /// </summary>
        public override Tag[] GetTags() { return new Tag[] { Tag.HashTable, Tag.TwoPointers, Tag.String }; }

        /// <summary>
        /// 195/195 cases passed (104 ms)
        /// Your runtime beats 89.9 % of csharp submissions
        /// Your memory usage beats 95.45 % of csharp submissions(24.5 MB)
        /// </summary>
        /// <param name="sw"></param>
        /// <returns></returns>
        public override bool Test(System.Diagnostics.Stopwatch sw)
        {
            bool isSuccess = true;
            int[] nums;
            int target;
            int result, checkResult;

            nums = new int[] { 1, 3, 5 };
            target = 0;
            result = Search(nums, target);
            checkResult = -1;

            isSuccess &= result == checkResult;
            Print("isSuccess = {0} result = {1} | checkResult = {2}", isSuccess, (result), (checkResult));

            nums = new int[] { 3, 5, 1 };
            target = 5;
            result = Search(nums, target);
            checkResult = 1;

            isSuccess &= result == checkResult;
            Print("isSuccess = {0} result = {1} | checkResult = {2}", isSuccess, (result), (checkResult));


            nums = new int[] { 4, 5, 6, 7, 0, 1, 2 };
            target = 0;
            result = Search(nums, target);
            checkResult = 4;

            isSuccess &= result == checkResult;
            Print("isSuccess = {0} result = {1} | checkResult = {2}", isSuccess, (result), (checkResult));

            nums = new int[] { 4, 5, 6, 7, 0, 1, 2 };
            target = 3;
            result = Search(nums, target);
            checkResult = -1;

            isSuccess &= result == checkResult;
            Print("isSuccess = {0} result = {1} | checkResult = {2}", isSuccess, (result), (checkResult));

            nums = new int[] { 4, 5, 6, 7, 0, 1, 2 };
            target = 6;
            result = Search(nums, target);
            checkResult = 2;

            isSuccess &= result == checkResult;
            Print("isSuccess = {0} result = {1} | checkResult = {2}", isSuccess, (result), (checkResult));

            nums = new int[] { 4, 5, 6, 7, 0, 1, 2 };
            target = 1;
            result = Search(nums, target);
            checkResult = 5;

            isSuccess &= result == checkResult;
            Print("isSuccess = {0} result = {1} | checkResult = {2}", isSuccess, (result), (checkResult));


            nums = new int[] { 1 };
            target = 0;
            result = Search(nums, target);
            checkResult = -1;

            isSuccess &= result == checkResult;
            Print("isSuccess = {0} result = {1} | checkResult = {2}", isSuccess, (result), (checkResult));

            return isSuccess;
        }

        /// 作者：LeetCode-Solution
        /// 链接：https://leetcode-cn.com/problems/search-in-rotated-sorted-array/solution/sou-suo-xuan-zhuan-pai-xu-shu-zu-by-leetcode-solut/

        public int Search(int[] nums, int target)
        {
            int n = nums.Length;
            if (n == 0)
                return -1;
            if (n == 1)
                return nums[0] == target ? 0 : -1;
            if (n == 2)
                return nums[0] == target ? 0 : (nums[1] == target ? 1 : -1);

            int half = n / 2;
            int mid = n / 2;

            int first = nums[0];
            int k = -1;
            while (true)
            {
                int m = nums[mid];
                if (m > first) //右移动
                {
                    if (mid == n - 1)
                    {
                        k = 0; break;
                    }
                    if (m > nums[mid + 1]) //找到K
                    {
                        k = n - mid - 1;  //[4,5,1,2,3] [1]<[2] mid = 1, k = n -(mid+1) = 3;
                                          //[3,4,5,1,2] [2]>[3] mid = 2, k = n -(mid+1) = 2
                        break;
                    }
                    else
                    {
                        half /= 2;
                        mid += (half == 0 ? 1 : half);
                    }
                }
                else //if (m < first)//左移
                {
                    if (mid == 0)
                    {
                        k = 0; break;
                    }
                    if (nums[mid - 1] > m) //找到K
                    {
                        k = n - mid;  //[4,5,1,2,3] [1]<[2] mid = 2, k = n -(mid) = 3;
                        break;
                    }
                    else
                    {
                        half /= 2;
                        mid -= (half == 0 ? 1 : half);
                    }
                }
            }

            if (k == 0)
            {
                return Array.IndexOf(nums, target);
            }
            else if (target < nums[0])
            {
                //search in 0,k
                return Array.IndexOf(nums, target, n - k, k);
            }
            else
            {
                return Array.IndexOf(nums, target, 0, n - k);
            }
        }
    }
}
