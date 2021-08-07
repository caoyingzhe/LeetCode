using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpConsoleApp.Solutions._0300
{
    /*
     * @lc app=leetcode.cn id=324 lang=csharp
     *
     * [324] 摆动排序 II
     *
     * https://leetcode-cn.com/problems/wiggle-sort-ii/description/
     *
     * Category	Difficulty	Likes	Dislikes
     * algorithms	Medium (37.33%)	251	-
     * Tags
     * sort
     * 
     * Companies
     * google
     * Total Accepted:    20.9K
     * Total Submissions: 56K
     * Testcase Example:  '[1,5,1,1,6,4]'
     *
     * 给你一个整数数组 nums，将它重新排列成 nums[0] < nums[1] > nums[2] < nums[3]... 的顺序。
     * 
     * 你可以假设所有输入数组都可以得到满足题目要求的结果。
     * 
     * 示例 1：
     * 输入：nums = [1,5,1,1,6,4]
     * 输出：[1,6,1,5,1,4]
     * 解释：[1,4,1,5,1,6] 同样是符合题目要求的结果，可以被判题程序接受。
     * 
     * 示例 2：
     * 输入：nums = [1,3,2,2,3,1]
     * 输出：[2,3,1,3,1,2]
     * 
     * 提示：
     * 1 <= nums.length <= 5 * 10^4
     * 0 <= nums[i] <= 5000
     * 题目数据保证，对于给定的输入 nums ，总能产生满足题目要求的结果
     * 
     * 进阶：你能用 O(n) 时间复杂度和 / 或原地 O(1) 额外空间来实现吗？
     * 
     */
    class Solution324 : SolutionBase
    {
        /// <summary>
        /// 难易度:
        /// </summary>
        public override Difficulity GetDifficulity() { return Difficulity.Medium; }
        /// <summary>
        /// 关键字:
        /// </summary>
        public override string[] GetKeyWords() { return new string[] { "三分法" }; }
        /// <summary>
        /// 标签： 图
        /// </summary>
        public override Tag[] GetTags() { return new Tag[] { Tag.Array }; }

        public override bool Test(System.Diagnostics.Stopwatch sw)
        {
            bool isSuccess = true;

            int[] nums;
            int[] checkresult;
            //nums = new int[] { 0, 1, 2, 3, 4, 5, 6, 7 };
            //checkresult = new int[] { 0, 4, 1, 5, 2, 6, 3, 7 };
            //WiggleSort(nums);
            //isSuccess &= IsArraySame(nums, checkresult);
            //Print("isSuccess = " + isSuccess + " | Anticipated = " + GetArrayStr(checkresult) + " | Result = " + GetArrayStr(nums));
            //
            //
            //nums = new int[] { 0, 1, 2, 3, 4, 5, 6 };
            //checkresult = new int[] { 0, 4, 1, 5, 2, 6, 3 };
            //WiggleSort(nums);
            //isSuccess &= IsArraySame(nums, checkresult);
            //Print("isSuccess = " + isSuccess + " | Anticipated = " + GetArrayStr(checkresult) + " | Result = " + GetArrayStr(nums));
            //
            //nums = new int[] { 1, 5, 1, 1, 6, 4 };
            //checkresult = new int[] { 1, 4, 1, 5, 1, 6 };
            //WiggleSort(nums);
            //isSuccess &= IsArraySame(nums, checkresult);
            //Print("isSuccess = " + isSuccess + " | Anticipated = " + GetArrayStr(checkresult) + " | Result = " + GetArrayStr(nums));

            //nums = new int[] { 4, 5, 5, 6 };
            //checkresult = new int[] { 5, 6, 4, 5 };
            //WiggleSort(nums);
            //isSuccess &= IsArraySame(nums, checkresult);
            //Print("isSuccess = " + isSuccess + " | Anticipated = " + GetArrayStr(checkresult) + " | Result = " + GetArrayStr(nums));
            //
            ////[1,1,2,1,2,2,1]
            //nums = new int[] { 4, 5, 5, 6 };
            //checkresult = new int[] { 5, 6, 4, 5 };
            //WiggleSort(nums);
            //isSuccess &= IsArraySame(nums, checkresult);
            //Print("isSuccess = " + isSuccess + " | Anticipated = " + GetArrayStr(checkresult) + " | Result = " + GetArrayStr(nums));

            nums = new int[] { 1, 1, 2, 1, 2, 2, 1 };
            checkresult = new int[] { 1, 2, 1, 2, 1, 2, 1 };
            WiggleSort(nums);
            isSuccess &= IsArraySame(nums, checkresult);
            Print("isSuccess = " + isSuccess + " | Anticipated = " + GetArrayStr(checkresult) + " | Result = " + GetArrayStr(nums));

            return isSuccess;
        }
        /// <summary>
        /// 穿插法（自己的代码）
        /// 问题：无法通过{ 4, 5, 5, 6 }的Test
        /// 原因：{4,5}和 {5,6} 的序列首位的5发生了相连。
        /// 解决办法： 对{4,5}和 {5,6}反序
        /// https://leetcode-cn.com/problems/wiggle-sort-ii/solution/yi-bu-yi-bu-jiang-shi-jian-fu-za-du-cong-onlognjia/
        /// </summary>
        /// <param name="nums"></param>
        public void WiggleSort(int[] nums)
        {
            Array.Sort(nums);
            int n = nums.Length;
            if (n <= 2)
                return;

            int mid = (n) / 2;
            int midValue = nums[mid];

            List<int> list = new List<int>(nums);
            List<int> llist = new List<int>();
            List<int> rlist = new List<int>();

            bool isEven = n % 2 == 0;
            if (isEven)
            {
                for (int i = 0; i < n; i++)
                {
                    if (i >= mid)
                        rlist.Add(nums[i]);
                    else
                        llist.Add(nums[i]);
                }
            }
            else
            {
                for (int i = 0; i < n; i++)
                {
                    if (i > mid)
                        rlist.Add(nums[i]);
                    else
                        llist.Add(nums[i]);
                }
            }

            llist.Reverse();
            rlist.Reverse();

            for (int i = 0; i < mid; i++)
            {
                nums[i * 2] = llist[i];
                if (i < rlist.Count)
                {
                    nums[i * 2 + 1] = rlist[i];
                }


                //n=8, mid=4,  add[0], add[n-mid+i=8-4+0]  add[3], add[n-mid+i=8-4+3=7] 0,1,2,3,4,5,6,7  => 0,4,1,5,2,6,3,7
                //[0],[4] i=0, n-mid+i=4+0=4
                //[1],[5] i=1, n-mid+i=4+1=5
                //[2],[6] i=2, n-mid+i=4+2=6
                //[3],[7] i=3, n-mid+i=4+3=7

                //n=7, mid=3,
                //[0],[4] i=0, n-mid+i=4+0=4
                //[1],[5] i=1, n-mid+i=4+1=5
                //[2],[6] i=2, n-mid+i=4+2=6
                //[3],[6] i=2, n-mid+i=4+2=7 
            }
            if (!isEven)
                nums[n - 1] = llist[mid];
        }
    }
}
