using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpConsoleApp.Solutions._0300
{
    /*
     * @lc app=leetcode.cn id=327 lang=csharp
     *
     * [327] 区间和的个数
     *
     * https://leetcode-cn.com/problems/count-of-range-sum/description/
     *
     * Category	Difficulty	Likes	Dislikes
     * algorithms	Hard (43.08%)	321	-
     * Tags
     * binary-search | divide-and-conquer | sort | binary-indexed-tree | segment-tree
     * 
     * Companies
     * google
     * 
     * Total Accepted:    21.8K
     * Total Submissions: 50.5K
     * Testcase Example:  '[-2,5,-1]\n-2\n2'
     *
     * 给定一个整数数组 nums 。区间和 S(i, j) 表示在 nums 中，位置从 i 到 j 的元素之和，包含 i 和 j (i ≤ j)。
     * 
     * 请你以下标 i （0  ）为起点，元素个数逐次递增，计算子数组内的元素和。
     * 
     * 当元素和落在范围 [lower, upper] （包含 lower 和 upper）之内时，记录子数组当前最末元素下标 j ，记作 有效 区间和
     * S(i, j) 。
     * 
     * 求数组中，值位于范围 [lower, upper] （包含 lower 和 upper）之内的 有效 区间和的个数。
     * 
     * 注意：
     * 最直观的算法复杂度是 O(n^2) ，请在此基础上优化你的算法。
     * 
     * 
     * 示例：
     * 输入：nums = [-2,5,-1], lower = -2, upper = 2,
     * 输出：3 
     * 解释：
     * 下标 i = 0 时，子数组 [-2]、[-2,5]、[-2,5,-1]，对应元素和分别为 -2、3、2 ；其中 -2 和 2 落在范围 [lower
     * = -2, upper = 2] 之间，因此记录有效区间和 S(0,0)，S(0,2) 。
     * 下标 i = 1 时，子数组 [5]、[5,-1] ，元素和 5、4 ；没有满足题意的有效区间和。
     * 下标 i = 2 时，子数组 [-1] ，元素和 -1 ；记录有效区间和 S(2,2) 。
     * 故，共有 3 个有效区间和。
     * 
     * 提示：
     * 0 <= nums.Length<= 10^4
     * 
     */
    class Solution327 : SolutionBase
    {
        /// <summary>
        /// 难易度:
        /// </summary>
        public override Difficulity GetDifficulity() { return Difficulity.Hard; }
        /// <summary>
        /// 关键字:
        /// </summary>
        public override string[] GetKeyWords() { return new string[] { "前缀和", "归并排序", "滑动窗口", "常规方法必然超时" }; }
        /// <summary>
        /// 标签： binary-search | divide-and-conquer | sort | binary-indexed-tree | segment-tree
        /// </summary>
        public override Tag[] GetTags() { return new Tag[] { Tag.BinarySearch, Tag.DivideAndConquer, Tag.Sort, Tag.BinaryIndexedTree, Tag.SegmentTree }; }

        public override bool Test(System.Diagnostics.Stopwatch sw)
        {
            bool isSuccess = true;

            int[] nums;
            int lower, upper;
            int result;
            int checkresult;

            nums = new int[] { -2, 5, -1 };
            lower = -2; upper = 2;
            checkresult = 3;
            result = CountRangeSum(nums, lower, upper);
            isSuccess &= (result == checkresult);
            Print("isSuccess = " + isSuccess + " | Anticipated = " + checkresult + " | Result = " + result);

            //nums = new int[] { -2147483647, 0, -2147483647, 2147483647 };
            //lower = -2; upper = 2;
            //checkresult = 3;
            //result = CountRangeSum(nums, lower, upper);
            //isSuccess &= (result == checkresult);
            //Print("isSuccess = " + isSuccess + " | Anticipated = " + checkresult + " | Result = " + result);
            return isSuccess;
        }

        //TODO
        public int CountRangeSum_Normal(int[] nums, int lower, int upper)
        {
            int result = 0;

            int n = nums.Length;
            for (int i = 0; i < n; i++)
            { 
                long[] numsPrefixSum = new long[n-i];
                long sum = 0;
                for (int j=i; j< n; j++)
                {
                    sum += nums[j];
                    if (sum >= lower && sum <= upper)
                        result++;

                    numsPrefixSum[j-i] = sum;
                }
                Print(GetArrayStr(numsPrefixSum));
            }
            //TODO
            return result;
        }

        public int CountRangeSum(int[] nums, int lower, int upper)
        {
            long s = 0;
            long[] sum = new long[nums.Length+ 1]; //第一层前缀和 ([0]=0;
            for (int i = 0; i < nums.Length; ++i)
            {
                s += nums[i];
                sum[i + 1] = s;
            }
            
            return CountRangeSumRecursive(sum, lower, upper, 0, sum.Length- 1);
        }
        int count = 0;
        /// <summary>
        /// 速度有点惨
        /// 67/67 cases passed (580 ms)
        /// Your runtime beats 10 % of csharp submissions
        /// Your memory usage beats 10 % of csharp submissions(46.4 MB)
        ///
        /// 作者：LeetCode-Solution        
        /// 链接：https://leetcode-cn.com/problems/count-of-range-sum/solution/qu-jian-he-de-ge-shu-by-leetcode-solution/
        ///         
        /// </summary>
        /// <param name="sum"></param>
        /// <param name="lower"></param>
        /// <param name="upper"></param>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public int CountRangeSumRecursive(long[] sum, int lower, int upper, int left, int right, string info="")
        {
            count++; 
            Print("sum = {0} L={1} | R={2} | {3}", GetArrayStr(sum), left, right, " | count = " + count + info );
            if (left == right)
            {
                return 0;
            }
            else
            {
                int mid = (left + right) / 2;
                int n1 = CountRangeSumRecursive(sum, lower, upper, left, mid, " n1 mid=" + mid);
                int n2 = CountRangeSumRecursive(sum, lower, upper, mid + 1, right, " n2 mid=" + mid);
                int ret = n1 + n2;

                // 首先统计下标对的数量
                int i = left;
                int l = mid + 1;
                int r = mid + 1;
                while (i <= mid)
                {
                    while (l <= right && sum[l] - sum[i] < lower)
                    {
                        l++;
                    }
                    while (r <= right && sum[r] - sum[i] <= upper)
                    {
                        r++;
                    }
                    ret += r - l;
                    i++;
                }

                // 随后合并两个排序数组
                long[] sorted = new long[right - left + 1];
                int p1 = left, p2 = mid + 1;
                int p = 0;
                while (p1 <= mid || p2 <= right)
                {
                    if (p1 > mid)
                    {
                        sorted[p++] = sum[p2++];
                    }
                    else if (p2 > right)
                    {
                        sorted[p++] = sum[p1++];
                    }
                    else
                    {
                        if (sum[p1] < sum[p2])
                        {
                            sorted[p++] = sum[p1++];
                        }
                        else
                        {
                            sorted[p++] = sum[p2++];
                        }
                    }
                }
                for (int j = 0; j < sorted.Length; j++)
                {
                    sum[left + j] = sorted[j];
                }
                return ret;
            }
        }
    }
}
