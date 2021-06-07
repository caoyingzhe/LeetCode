using System;
namespace CSharpConsoleApp.Solutions
{
    /*
     * @lc app=leetcode.cn id=75 lang=csharp
     *
     * [75] 颜色分类
     *
     * https://leetcode-cn.com/problems/sort-colors/description/
     *
     * Category	Difficulty	Likes	Dislikes
     * algorithms	Medium (58.70%)	908	-
     * Tags
     * array | two-pointers | sort
     * 
     * Companies
     * facebook | microsoft | pocketgems
     * 
     * Total Accepted:    217.2K
     * Total Submissions: 370K
     * Testcase Example:  '[2,0,2,1,1,0]'
     *
     * 给定一个包含红色、白色和蓝色，一共 n 个元素的数组，原地对它们进行排序，使得相同颜色的元素相邻，并按照红色、白色、蓝色顺序排列。
     * 此题中，我们使用整数 0、 1 和 2 分别表示红色、白色和蓝色。
     * 
     * 示例 1：
     * 输入：nums = [2,0,2,1,1,0]
     * 输出：[0,0,1,1,2,2]
     * 
     * 示例 2：
     * 输入：nums = [2,0,1]
     * 输出：[0,1,2]
     * 
     * 示例 3：
     * 输入：nums = [0]
     * 输出：[0]
     * 
     * 示例 4：
     * 输入：nums = [1]
     * 输出：[1]
     * 
     * 提示：
     * n == nums.length
     * 1 <= n <= 300
     * nums[i] 为 0、1 或 2
     *
     * 
     * 进阶：
     * 你可以不使用代码库中的排序函数来解决这道题吗？
     * 你能想出一个仅使用常数空间的一趟扫描算法吗？
     */
    public class Solution75 : SolutionBase
    {
        /// <summary>
        /// 难度
        /// </summary>
        public override Difficulity GetDifficulity() { return Difficulity.Medium; }
        /// <summary>
        /// 关键字:
        /// </summary>
        public override string[] GetKeyWords() { return new string[] { }; }
        /// <summary>
        /// 标签：
        /// </summary>
        public override Tag[] GetTags() { return new Tag[] { Tag.Array, Tag.TwoPointers, Tag.Sort }; }

        public override bool Test(System.Diagnostics.Stopwatch sw)
        {
            bool isSuccess = true;
            return isSuccess;
        }

        /// <summary>
        /// https://leetcode-cn.com/problems/sort-colors/solution/yan-se-fen-lei-by-leetcode-solution/
        /// 87/87 cases passed (268 ms)
        /// Your runtime beats 93.15 % of csharp submissions
        /// Your memory usage beats 82.53 % of csharp submissions(29.8 MB)
        /// </summary>
        /// <param name="nums"></param>
        public void SortColors(int[] nums)
        {
            //设双指针left和right，遇到2与right交换，0与left交换
            int left = 0, right = nums.Length - 1;
            int i = 0;
            while (i >= left && i <= right)
            {
                if (nums[i] == 2)
                {
                    nums[i] = nums[right];
                    nums[right] = 2;
                    right--;
                }
                else if (nums[i] == 0)
                {
                    nums[i] = nums[left];
                    nums[left] = 0;
                    left++;
                    if (i <= left) i = left;
                }
                else
                {
                    i++;
                }
            }
        }
    }
}
