using System;
namespace CSharpConsoleApp.Solutions
{
    /*
 * @lc app=leetcode.cn id=283 lang=csharp
 *
 * [283] 移动零
 *
 * https://leetcode-cn.com/problems/move-zeroes/description/
 *
 * Category	Difficulty	Likes	Dislikes
 * algorithms	Easy (63.82%)	1105	-
 * Tags
 * array | two-pointers
 * 
 * Companies
 * bloomberg | facebook
 * 
 * Total Accepted:    396.4K
 * Total Submissions: 621.1K
 * Testcase Example:  '[0,1,0,3,12]'
 *
 * 给定一个数组 nums，编写一个函数将所有 0 移动到数组的末尾，同时保持非零元素的相对顺序。
 * 
 * 示例:
 * 
 * 输入: [0,1,0,3,12]
 * 输出: [1,3,12,0,0]
 * 
 * 说明:
 * 
 * 
 * 必须在原数组上操作，不能拷贝额外的数组。
 * 尽量减少操作次数。
 * 
 * 
 */

    // @lc code=start
    public class Solution283 : SolutionBase
    {
        /// <summary>
        /// 难度
        /// </summary>
        public override Difficulity GetDifficulity() { return Difficulity.Easy; }
        /// <summary>
        /// 关键字:
        /// </summary>
        public override string[] GetKeyWords() { return new string[] { "" }; }
        /// <summary>
        /// 标签：
        /// </summary>
        public override Tag[] GetTags() { return new Tag[] { Tag.Array, Tag.TwoPointers, }; }

        public override bool Test(System.Diagnostics.Stopwatch sw)
        {
            bool isSuccess = true;
            int[] checkResult;
            int[] nums;

            //nums = new int[] { 0, 1, 0, 3, 12 };
            //checkResult = new int[] { 1, 3, 12, 0, 0 };
            //MoveZeroes(nums);
            //isSuccess &= IsSame(nums, checkResult);
            //PrintResult(isSuccess, GetArrayStr(nums), GetArrayStr(checkResult));

            //nums = new int[] { 0, 1, 0, 3, 0, 12 };
            //checkResult = new int[] { 1, 3, 12, 0, 0, 0 };
            //MoveZeroes(nums);
            //isSuccess &= IsSame(nums, checkResult);
            //PrintResult(isSuccess, GetArrayStr(nums), GetArrayStr(checkResult));

            //nums = new int[] { 0, 1 };
            //checkResult = new int[] { 1, 0 };
            //MoveZeroes(nums);
            //isSuccess &= IsSame(nums, checkResult);
            //PrintResult(isSuccess, GetArrayStr(nums), GetArrayStr(checkResult));

            //nums = new int[] { 1 };
            //checkResult = new int[] { 1 };
            //MoveZeroes(nums);
            //isSuccess &= IsSame(nums, checkResult);
            //PrintResult(isSuccess, GetArrayStr(nums), GetArrayStr(checkResult));

            //nums = new int[] { 0 };
            //checkResult = new int[] { 0 };
            //MoveZeroes(nums);
            //isSuccess &= IsSame(nums, checkResult);
            //PrintResult(isSuccess, GetArrayStr(nums), GetArrayStr(checkResult));

            nums = new int[] { 0, 1, 0 };
            checkResult = new int[] { 1, 0, 0 };
            MoveZeroes(nums);
            isSuccess &= IsSame(nums, checkResult);
            PrintResult(isSuccess, GetArrayStr(nums), GetArrayStr(checkResult));

            return isSuccess;
        }

        /// <summary>
        /// 21/21 cases passed (292 ms)
        /// Your runtime beats 42.25 % of csharp submissions
        /// Your memory usage beats 26.38 % of csharp submissions(31.8 MB)
        /// </summary>
        /// <param name="nums"></param>
        public void MoveZeroes(int[] nums)
        {
            if (nums == null || nums.Length == 0) return;

            int n = nums.Length;
            int L = 0, R = n -1;
            while(L < R)
            {
                if(nums[L] == 0)
                {
                    for (int j = L; j < R; j++)
                    {
                        nums[j] = nums[j + 1];
                    }
                    nums[R] = 0;
                    R--;
                }
                else { 
                    L++;
                }
            }
        }
    }
    // @lc code=end


}
