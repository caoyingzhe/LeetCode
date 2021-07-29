using System;
namespace CSharpConsoleApp.Solutions
{
    /*
 * @lc app=leetcode.cn id=457 lang=csharp
 *
 * [457] 环形数组是否存在循环
 *
 * https://leetcode-cn.com/problems/circular-array-loop/description/
 *
 * Category	Difficulty	Likes	Dislikes
 * algorithms	Medium (36.89%)	88	-
 * Tags
 * array | two-pointers
 * 
 * Companies
 * Unknown
 * 
 * Total Accepted:    9.2K
 * Total Submissions: 24.8K
 * Testcase Example:  '[2,-1,1,2,2]'
 *
 * 存在一个不含 0 的 环形 数组 nums ，每个 nums[i] 都表示位于下标 i 的角色应该向前或向后移动的下标个数：
 * 
 * 如果 nums[i] 是正数，向前 移动 nums[i] 步
 * 如果 nums[i] 是负数，向后 移动 nums[i] 步
 * 
 * 因为数组是 环形 的，所以可以假设从最后一个元素向前移动一步会到达第一个元素，而第一个元素向后移动一步会到达最后一个元素。
 * 
 * 数组中的 循环 由长度为 k 的下标序列 seq ：
 * 
 * 
 * 遵循上述移动规则将导致重复下标序列 seq[0] -> seq[1] -> ... -> seq[k - 1] -> seq[0] -> ...
 * 所有 nums[seq[j]] 应当不是 全正 就是 全负
 * k > 1
 * 如果 nums 中存在循环，返回 true ；否则，返回 false 。
 * 
 * 
 * 示例 1：
 * 输入：nums = [2,-1,1,2,2]
 * 输出：true
 * 解释：存在循环，按下标 0 -> 2 -> 3 -> 0 。循环长度为 3 。
 * 
 * 
 * 示例 2：
 * 输入：nums = [-1,2]
 * 输出：false
 * 解释：按下标 1 -> 1 -> 1 ... 的运动无法构成循环，因为循环的长度为 1 。根据定义，循环的长度必须大于 1 。
 * 
 * 
 * 示例 3:
 * 输入：nums = [-2,1,-1,-2,-2]
 * 输出：false
 * 解释：按下标 1 -> 2 -> 1 -> ... 的运动无法构成循环，因为 nums[1] 是正数，而 nums[2] 是负数。
 * 所有 nums[seq[j]] 应当不是全正就是全负。
 *
 * 
 * 提示：
 * 1 <= nums.length <= 5000
 * -1000 <= nums[i] <= 1000
 * nums[i] != 0
 * 
 * 进阶：你能设计一个时间复杂度为 O(n) 且额外空间复杂度为 O(1) 的算法吗？
 */

    // @lc code=start
    public class Solution457 : SolutionBase
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
        public override Tag[] GetTags() { return new Tag[] { Tag.Stack }; }

        public override bool Test(System.Diagnostics.Stopwatch sw)
        {
            bool isSuccess = true;
            //TODO
            return isSuccess;
        }

        /// <summary>
        /// 作者：dong - gan - o
        /// 链接：https://leetcode-cn.com/problems/circular-array-loop/solution/shuang-bai-by-dong-gan-o/
        /// 41/41 cases passed (80 ms)
        /// Your runtime beats 100 % of csharp submissions
        /// Your memory usage beats 20 % of csharp submissions(24.1 MB)
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public bool CircularArrayLoop(int[] nums)
        {
            int n = nums.Length;
            //简单类型的判断，长度小于2，必错
            if (n == 1 || n == 0) return false;

            //简单类型判断，长度为2，一正一负必错 
            if (n == 2 && (nums[0] * nums[1] <= 0)) return false;

            bool hasCircle = false;
            //做数组的深拷贝，标记出现在循环链路中的数值
            //数值未构成循环，必然不会在最终循环结果出现
            int[] nums2 = new int[n];
            Array.Copy(nums, nums2, n);

            //遍历数组，进行本次循环判断
            for (int b = 0; b < n; b++)
            {
                if (nums2[b] == 0) continue;
                
                int nownum = nums[b];
                int nowIndex = b;
                nums2[b] = 0;
                int circleLength = 0;
                while (true)
                {
                    //获取下一个元素索引及值
                    int nextIndex = (nowIndex + nownum);
                    if (nextIndex >= 0)
                    {
                        nextIndex = nextIndex % n;
                    }
                    else
                    {
                        nextIndex = n - ((0 - nextIndex) % n);
                    }
                    int nextNum = nums[nextIndex];
                    //下个元素和当前元素相同，循环长度为1
                    //下个元素和当前元素一正一负，循环方向不一致
                    if (nextIndex == nowIndex || nownum * nextNum < 0)
                    {
                        break;
                    }
                    //完成一轮循环
                    if (circleLength > n)
                    {
                        return true;
                    }
                    circleLength++;
                    nums2[nextIndex] = 0;
                    nownum = nextNum;
                    nowIndex = nextIndex;
                }
            }
            return hasCircle;
        }
    }
    // @lc code=end


}
