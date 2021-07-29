using System;
using System.Linq;
namespace CSharpConsoleApp.Solutions
{
    /*
     * @lc app=leetcode.cn id=164 lang=csharp
     *
     * [164] 最大间距
     *
     * https://leetcode-cn.com/problems/maximum-gap/description/
     *
     * Category	Difficulty	Likes	Dislikes
     * algorithms	Hard (61.10%)	390	-
     * Tags
     * sort
     * 
     * Companies
     * Unknown
     * 
     * Total Accepted:    54.6K
     * Total Submissions: 89.4K
     * Testcase Example:  '[3,6,9,1]'
     *
     * 给定一个无序的数组，找出数组在排序之后，相邻元素之间最大的差值。
     * 如果数组元素个数小于 2，则返回 0。
     * 
     * 示例 1:
     * 输入: [3,6,9,1]
     * 输出: 3
     * 解释: 排序后的数组是 [1,3,6,9], 其中相邻元素 (3,6) 和 (6,9) 之间都存在最大差值 3。
     * 
     * 示例 2:
     * 输入: [10]
     * 输出: 0
     * 解释: 数组元素个数小于 2，因此返回 0。
     * 
     * 说明:
     * 你可以假设数组中所有元素都是非负整数，且数值在 32 位有符号整数范围内。
     * 请尝试在线性时间复杂度和空间复杂度的条件下解决此问题。
     */

    // @lc code=start
    public class Solution164 : SolutionBase
    {
        /// <summary>
        /// 难度
        /// </summary>
        public override Difficulity GetDifficulity() { return Difficulity.Hard; }
        /// <summary>
        /// 关键字:
        /// </summary>
        public override string[] GetKeyWords() { return new string[] { "基数排序",  }; }
        /// <summary>
        /// 标签：
        /// </summary>
        public override Tag[] GetTags() { return new Tag[] { Tag.Array, Tag.BinarySearch }; }

        
        public override bool Test(System.Diagnostics.Stopwatch sw)
        {
            bool isSuccess = true;
            int[] s;
            int result, checkResult;

            s = new int[] { 3, 6, 9, 1 };
            checkResult = 3;
            result = MaximumGap(s);
            isSuccess &= IsSame(result, checkResult);
            PrintResult(isSuccess, result, checkResult);

            s = new int[] { 10 };
            checkResult = 0;
            result = MaximumGap(s);
            isSuccess &= IsSame(result, checkResult);
            PrintResult(isSuccess, result, checkResult);

            return isSuccess;
        }

        
        //不讲武德的code， 效率确实也不咋地
        //40/40 cases passed (336 ms)
        //Your runtime beats 32.14 % of csharp submissions
        //Your memory usage beats 17.86 % of csharp submissions (43.3 MB)

        public int MaximumGap_NotGood(int[] nums)
        {
            int n = nums.Length;
            if (n < 2) return 0;

            Array.Sort(nums);
            int max = int.MinValue;
            for (int i = 1; i < n; i++)
            {
                int t = nums[i] - nums[i - 1];
                max = Math.Max(max, t);
            }
            return max;
        }

        /// <summary>
        /// 方法一：基数排序
        ///
        /// 作者：LeetCode - Solution
        /// 链接：https://leetcode-cn.com/problems/maximum-gap/solution/zui-da-jian-ju-by-leetcode-solution/
        ///
        /// 40/40 cases passed (268 ms)
        /// Your runtime beats 42.86 % of csharp submissions
        /// Your memory usage beats 35.71 % of csharp submissions(43.1 MB)
        /// /summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int MaximumGap(int[] nums)
        {
            int n = nums.Length;
            if (n < 2)
            {
                return 0;
            }
            long exp = 1;
            int[] buf = new int[n];
            //int maxVal = Array.stream(nums).max().getAsInt(); //Java
            int maxVal = nums.Max<int>();

            while (maxVal >= exp)
            {
                int[] cnt = new int[10];
                for (int i = 0; i < n; i++)
                {
                    int digit = (nums[i] / (int)exp) % 10;
                    cnt[digit]++;
                }
                for (int i = 1; i < 10; i++)
                {
                    cnt[i] += cnt[i - 1];
                }
                for (int i = n - 1; i >= 0; i--)
                {
                    int digit = (nums[i] / (int)exp) % 10;
                    buf[cnt[digit] - 1] = nums[i];
                    cnt[digit]--;
                }
                //System.arraycopy(buf, 0, nums, 0, n);
                Array.Copy(buf, nums, n);
                exp *= 10;
            }

            int ret = 0;
            for (int i = 1; i < n; i++)
            {
                ret = Math.Max(ret, nums[i] - nums[i - 1]);
            }
            return ret;
        }
    }
    // @lc code=end
}
