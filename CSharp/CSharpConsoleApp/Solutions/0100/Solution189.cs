using System;
namespace CSharpConsoleApp.Solutions
{
    /*
     * @lc app=leetcode.cn id=189 lang=csharp
     *
     * [189] 旋转数组
     *
     * https://leetcode-cn.com/problems/rotate-array/description/
     *
     * Category	Difficulty	Likes	Dislikes
     * algorithms	Medium (45.49%)	991	-
     * Tags
     * array
     * 
     * Companies
     * amazon | bloomberg | microsoft
     * 
     * Total Accepted:    274.9K
     * Total Submissions: 604.2K
     * Testcase Example:  '[1,2,3,4,5,6,7]\n3'
     *
     * 给定一个数组，将数组中的元素向右移动 k 个位置，其中 k 是非负数。
     * 
     * 
     * 进阶：
     * 尽可能想出更多的解决方案，至少有三种不同的方法可以解决这个问题。
     * 你可以使用空间复杂度为 O(1) 的 原地 算法解决这个问题吗？
     * 
     * 示例 1:
     * 输入: nums = [1,2,3,4,5,6,7], k = 3
     * 输出: [5,6,7,1,2,3,4]
     * 解释:
     * 向右旋转 1 步: [7,1,2,3,4,5,6]
     * 向右旋转 2 步: [6,7,1,2,3,4,5]
     * 向右旋转 3 步: [5,6,7,1,2,3,4]
     * 
     * 
     * 示例 2:
     * 输入：nums = [-1,-100,3,99], k = 2
     * 输出：[3,99,-1,-100]
     * 解释: 
     * 向右旋转 1 步: [99,-1,-100,3]
     * 向右旋转 2 步: [3,99,-1,-100]
     * 
     * 
     * 提示：
     * 1 <= nums.length <= 2 * 104
     * -231 <= nums[i] <= 231 - 1
     * 0 <= k <= 105
     */

    // @lc code=start
    public class Solution189 : SolutionBase
    {
        /// <summary>
        /// 难度
        /// </summary>
        public override Difficulity GetDifficulity() { return Difficulity.Medium; }
        /// <summary>
        /// 关键字:
        /// </summary>
        public override string[] GetKeyWords() { return new string[] { "", }; }
        /// <summary>
        /// 标签：
        /// </summary>
        public override Tag[] GetTags() { return new Tag[] { Tag.Array, }; }

        const int NULL = int.MinValue;
        /// <summary>
        /// </summary>
        /// <param name="sw"></param>
        /// <returns></returns>
        public override bool Test(System.Diagnostics.Stopwatch sw)
        {
            bool isSuccess = true;
            //TODO
            return isSuccess;
        }

        public void Rotate(int[] nums, int k)
        {
            Rotate_1(nums, k);
            Rotate_2(nums, k);
            Rotate_3(nums, k);
        }
        /// <summary>
        /// 方法一：使用额外的数组
        /// 37/37 cases passed (328 ms)
        /// Your runtime beats 72.91 % of csharp submissions
        /// Your memory usage beats 8.18 % of csharp submissions(39.9 MB)
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="k"></param>
        public void Rotate_1(int[] nums, int k)
        {
            int n = nums.Length;
            int[] newArr = new int[n];
            for (int i = 0; i < n; ++i)
            {
                newArr[(i + k) % n] = nums[i];
            }
            Array.Copy(newArr, nums, n);
        }

        /// <summary>
        /// 方法二：环状替换
        /// 37/37 cases passed (328 ms)
        /// Your runtime beats 72.91 % of csharp submissions
        /// Your memory usage beats 37.09 % of csharp submissions(39.5 MB)
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="k"></param>
        public void Rotate_2(int[] nums, int k)
        {
            int n = nums.Length;
            k = k % n;
            int count = GCD(k, n);
            for (int start = 0; start < count; ++start)
            {
                int current = start;
                int prev = nums[start];

                //遍历移动最大公约数位置
                do
                {
                    int next = (current + k) % n;
                    int temp = nums[next];
                    nums[next] = prev;
                    prev = temp;
                    current = next;
                } while (start != current);
            }
        }
        //求最大公约数
        public int GCD(int x, int y)
        {
            return y > 0 ? GCD(y, x % y) : x;
        }

        /// <summary>
        /// 方法三：数组翻转
        /// 
        /// ex. [1 2 3 4 5 6 7], k = 3
        /// 1. 翻转所有元素                  [7 6 5 4 3 2 1]
        /// 2. 翻转 [0,kmodn−1] 区间的元素   [5 6 7 4 3 2 1]
        /// 3. 翻转 [kmodn,n−1] 区间的元素   [5 6 7 1 2 3 4]
        ///
        /// 37/37 cases passed (328 ms)
        /// Your runtime beats 72.91 % of csharp submissions
        /// Your memory usage beats 35.27 % of csharp submissions(39.5 MB)
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="k"></param>
        public void Rotate_3(int[] nums, int k)
        {
            k %= nums.Length;
            Reverse(nums, 0, nums.Length - 1);
            Reverse(nums, 0, k - 1);
            Reverse(nums, k, nums.Length - 1);
        }

        public void Reverse(int[] nums, int start, int end)
        {
            while (start < end)
            {
                int temp = nums[start];
                nums[start] = nums[end];
                nums[end] = temp;
                start += 1;
                end -= 1;
            }
        }
    }
    // @lc code=end


}
