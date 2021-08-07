using System;
namespace CSharpConsoleApp.Solutions
{
    /*
     * @lc app=leetcode.cn id=152 lang=csharp
     *
     * [152] 乘积最大子数组
     *
     * https://leetcode-cn.com/problems/maximum-product-subarray/description/
     *
     * Category	Difficulty	Likes	Dislikes
     * algorithms	Medium (41.72%)	1168	-
     * Tags
     * array | dynamic-programming
     * 
     * Companies
     * linkedin
     * 
     * Total Accepted:    155.4K
     * Total Submissions: 372.2K
     * Testcase Example:  '[2,3,-2,4]'
     *
     * 给你一个整数数组 nums ，请你找出数组中乘积最大的连续子数组（该子数组中至少包含一个数字），并返回该子数组所对应的乘积。
     * 
     * 
     * 示例 1:
     * 输入: [2,3,-2,4]
     * 输出: 6
     * 解释: 子数组 [2,3] 有最大乘积 6。
     * 
     * 
     * 示例 2:
     * 输入: [-2,0,-1]
     * 输出: 0
     * 解释: 结果不能为 2, 因为 [-2,-1] 不是子数组。
     * 
     */

    // @lc code=start
    public class Solution152 : SolutionBase
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
        public override Tag[] GetTags() { return new Tag[] { Tag.DynamicProgramming }; }


        public override bool Test(System.Diagnostics.Stopwatch sw)
        {
            bool isSuccess = true;
            int[] s;
            int result, checkResult;

            s = new int[] { 2, 3, -3, 4 };
            checkResult = 6;
            result = MaxProduct(s);
            isSuccess &= IsSame(result, checkResult);
            PrintResult(isSuccess, result, checkResult);


            s = new int[] { 2, 0, -1 };
            checkResult = 0;
            result = MaxProduct(s);
            isSuccess &= IsSame(result, checkResult);
            PrintResult(isSuccess, result, checkResult);

            s = new int[] { 1, 0, -1 };
            checkResult = 0;
            result = MaxProduct(s);
            isSuccess &= IsSame(result, checkResult);
            PrintResult(isSuccess, result, checkResult);

            //179/187 cases passed (N/A)
            //[2,-1,1,1]  asnwer = 2;

            s = new int[] { 2, -1, 1, 1 };
            checkResult = 2;
            result = MaxProduct(s);
            isSuccess &= IsSame(result, checkResult);
            PrintResult(isSuccess, result, checkResult);

            //-2,0,-1
            return isSuccess;
        }

        //作者：hardcore-albattani6bb
        //链接：https://leetcode-cn.com/problems/maximum-product-subarray/solution/dong-tai-gui-hua-152-cheng-ji-zui-da-zi-tg7up/
        public int MaxProduct_NG2(int[] nums)
        {
            if (nums.Length == 1)
                return nums[0];
            int n = nums.Length;
            int max = nums[0]; //  Math.Max(nums[0], nums[1]);
            int min = nums[0]; //  Math.Min(nums[0], nums[1]);
            int ans = nums[0] * nums[1];

            //最小的负数乘以负数等于最大的数，最大的数乘以负数等于最小的数
            for (int i = 2; i < n; i++)
            {
                int maxF = max; int minF = min;

                //比较当前值 ，当前值*上一组最大乘积，上一个最小的乘积*当前值比较出最大的
                max = Math.Max(nums[i] * maxF, Math.Max(nums[i], minF * nums[i]));
                //比较当前值 ，当前值*上一组最小乘积，上一个最大的乘积*当前值比较出最小的的
                min = Math.Min(nums[i] * minF, Math.Min(nums[i], maxF * nums[i]));

                //ans =   Math.Max(ans, max);
                if (ans <= max) ans = max;
            }

            return ans;
        }

        //作者：LeetCode - Solution
        //链接：https://leetcode-cn.com/problems/maximum-product-subarray/solution/cheng-ji-zui-da-zi-shu-zu-by-leetcode-solution/

        public int MaxProduct1(int[] nums)
        {
            int n = nums.Length;
            int[] maxF = new int[n];
            int[] minF = new int[n];
            Array.Copy(nums, maxF, n);
            Array.Copy(nums, minF, n);
            for (int i = 1; i < n; ++i)
            {
                maxF[i] = Math.Max(maxF[i - 1] * nums[i], Math.Max(nums[i], minF[i - 1] * nums[i]));
                minF[i] = Math.Min(minF[i - 1] * nums[i], Math.Min(nums[i], maxF[i - 1] * nums[i]));
            }
            int ans = maxF[0];
            for (int i = 1; i < n; ++i)
            {
                ans = Math.Max(ans, maxF[i]);
            }
            return ans;
        }

        public int MaxProduct2(int[] nums)
        {
            int maxF = nums[0], minF = nums[0], ans = nums[0];
            int n = nums.Length;
            for (int i = 1; i < n; ++i)
            {
                int mx = maxF, mn = minF;
                maxF = Math.Max(mx * nums[i], Math.Max(nums[i], mn * nums[i]));
                minF = Math.Min(mn * nums[i], Math.Min(nums[i], mx * nums[i]));
                ans = Math.Max(maxF, ans);
            }
            return ans;
        }

        public int MaxProduct(int[] nums)
        {
            int maxAll = nums[0], n = nums.Length;
            int first = 1, second = 1;
            bool flag = false; //是否遇到负数标志
            for (int i = 0; i < n; i++)
            {
                first *= nums[i];
                second *= nums[i];
                maxAll = maxAll > first ? maxAll : first;  //负数是奇数的第一个情况
                maxAll = maxAll > second ? maxAll : second;  //奇数的第二个情况
                if (nums[i] < 0 && !flag)
                {
                    //第一次遇到负数
                    second = 1;
                    flag = true;
                }
                if (nums[i] == 0)
                {
                    //遇到0的情况
                    maxAll = 0 > maxAll ? 0 : maxAll;
                    flag = false;
                    first = 1;
                    second = 1;
                }
            }
            return maxAll;
        }

        public int MaxProduct_NG(int[] nums)
        {
            //int n = nums.Length;
            //int[] maxF = new int[n];
            //int[] minF = new int[n];
            //Array.Copy(nums, maxF, n); ArrayFill(maxF, 0);
            //Array.Copy(nums, minF, n); ArrayFill(minF, 0);
            //for (int i = 1; i < n; ++i)
            //{
            //    maxF[i] =   Math.Max(maxF[i - 1] * nums[i],   Math.Max(nums[i], minF[i - 1] * nums[i]));
            //    minF[i] =   Math.Min(minF[i - 1] * nums[i],   Math.Min(nums[i], maxF[i - 1] * nums[i]));
            //}
            //int ans = maxF[0];
            //for (int i = 1; i < n; ++i)
            //{
            //    ans =   Math.Max(ans, maxF[i]);
            //}
            //return ans;

            int max = int.MinValue, imax = nums[0] * nums[1], imin = nums[0] * nums[1];
            for (int i = 1; i < nums.Length; i++)
            {
                //if (nums[i] < 0)
                //{
                //    int tmp = imax;
                //    imax = imin;
                //    imin = tmp;
                //}
                imax = Math.Max(imax * nums[i], nums[i]);
                imin = Math.Min(imin * nums[i], nums[i]);

                max = Math.Max(max, imax);
            }
            return max;

            //作者：guanpengchn
            //链接：https://leetcode-cn.com/problems/maximum-product-subarray/solution/hua-jie-suan-fa-152-cheng-ji-zui-da-zi-xu-lie-by-g/

        }

        //作者：LeetCode-Solution
        //链接：https://leetcode-cn.com/problems/maximum-product-subarray/solution/cheng-ji-zui-da-zi-shu-zu-by-leetcode-solution/
    }
    // @lc code=end


}
