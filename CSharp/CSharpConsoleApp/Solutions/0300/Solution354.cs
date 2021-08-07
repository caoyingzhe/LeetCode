using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpConsoleApp.Solutions._0300
{
    /*
     * @lc app=leetcode.cn id=354 lang=csharp
     *
     * [354] 俄罗斯套娃信封问题
     *
     * https://leetcode-cn.com/problems/russian-doll-envelopes/description/
     *
     * Category	Difficulty	Likes	Dislikes
     * algorithms	Hard (43.85%)	519	-
     * Tags
     * binary-search | dynamic-programming
     * 
     * Companies
     * google
     * 
     * Total Accepted:    57.1K
     * Total Submissions: 130K
     * Testcase Example:  '[[5,4],[6,4],[6,7],[2,3]]'
     *
     * 给你一个二维整数数组 envelopes ，其中 envelopes[i] = [wi, hi] ，表示第 i 个信封的宽度和高度。
     * 
     * 当另一个信封的宽度和高度都比这个信封大的时候，这个信封就可以放进另一个信封里，如同俄罗斯套娃一样。
     * 
     * 请计算 最多能有多少个 信封能组成一组“俄罗斯套娃”信封（即可以把一个信封放到另一个信封里面）。
     * 
     * 注意：不允许旋转信封。
     * 
     * 
     * 示例 1：
     * 输入：envelopes = [[5,4],[6,4],[6,7],[2,3]]
     * 输出：3
     * 解释：最多信封的个数为 3, 组合为: [2,3] => [5,4] => [6,7]。
     * 
     * 示例 2：
     * 输入：envelopes = [[1,1],[1,1],[1,1]]
     * 输出：1
     * 
     * 提示：
     * 1 <= envelopes.length <= 5000
     * envelopes[i].length == 2
     * 1 <= wi, hi <= 10^4
     * 
     */
    class Solution354 : SolutionBase
    {
        /// <summary>
        /// 难度
        /// </summary>
        public override Difficulity GetDifficulity() { return Difficulity.Hard; }
        /// <summary>
        /// 关键字:
        /// </summary>
        public override string[] GetKeyWords() { return new string[] { "" }; }
        /// <summary>
        /// 标签： 
        /// </summary>
        public override Tag[] GetTags() { return new Tag[] { Tag.BinarySearch, Tag.DynamicProgramming }; }

        public override bool Test(System.Diagnostics.Stopwatch sw)
        {
            bool isSuccess = true;

            int[][] envelopses = new int[][]
            {
                new int[] { 5,4},
                new int[] { 6,4},
                new int[] { 6, 7},
                new int[] { 2, 3},
            };
            int checkResult = 3;
            int result = MaxEnvelopes(envelopses);

            Print("isSuccess ={0} result= {1} checkResult={2}", isSuccess, result, checkResult);
            isSuccess &= result == checkResult;

            return isSuccess;
        }
        /// <summary>
        /// 动态编程法
        /// 
        /// 84/84 cases passed (488 ms)
        /// Your runtime beats 68.28 % of csharp submissions
        /// Your memory usage beats 98.39 % of csharp submissions(29.3 MB)
        /// 
        /// 时间复杂度：O(n^2) 
        ///     其中 n 是数组 envelopes的长度，
        ///     排序需要的时间复杂度为 O(nlogn)，动态规划需要的时间复杂度为 O(n^2)
        ///     前者在渐近意义下小于后者，可以忽略
        /// 
        /// 空间复杂度：O(n)，
        ///     n为数组 f 需要的空间
        ///     
        /// 作者：LeetCode-Solution
        /// 链接：https://leetcode-cn.com/problems/russian-doll-envelopes/solution/e-luo-si-tao-wa-xin-feng-wen-ti-by-leetc-wj68/
        /// </summary>
        /// <param name="envelopes"></param>
        /// <returns></returns>
        public int MaxEnvelopes_DP(int[][] envelopes)
        {
            if (envelopes.Length == 0)
            {
                return 0;
            }
            int ans = 1;

            int n = envelopes.Length;
            Array.Sort(envelopes, new ComparerSolution354());

            int[] dp = new int[n];
            for (int i = 0; i < n; i++) dp[i] = 1;

            for (int i = 1; i < n; ++i)
            {
                for (int j = 0; j < i; ++j)
                {
                    //已经拍过序了，不比较左边，只比较右边即可。
                    //循环顺序为从左到右，从0开始，

                    //只比较右边,比较顺序如下：
                    //dp[0] < dp [1]  更新 dp[1]，最大值=dp[1] 
                    //dp[0] < dp [2]  更新 dp[2]，最大值 
                    //dp[1] < dp [2]  更新 dp[2]，最大值=dp[2] 
                    //dp[0] < dp [2]  更新 dp[3]，最大值 
                    //dp[1] < dp [3]  更新 dp[3]，最大值 
                    //dp[2] < dp [3]  更新 dp[3]，最大值=dp[3]
                    //dp[0] < dp [4]  更新 dp[4]，最大值=dp[4]
                    //...
                    //以此类推        更新 dp[n-1],最大值
                    if (envelopes[j][1] < envelopes[i][1])
                    {
                        dp[i] = Math.Max(dp[i], dp[j] + 1);
                        Print("i={0},j={1} dp[{0}]= {2} dp[{1}] + 1 = {3}", i, j, dp[i], dp[j] + 1);
                    }
                }
                ans = Math.Max(ans, dp[i]);
            }
            return ans;
        }
        //


        /// <summary>
        /// 基于二分查找的动态规划, 不是很懂 
        /// 真的很快
        /// 84/84 cases passed (152 ms)
        /// Your runtime beats 96.77 % of csharp submissions
        /// Your memory usage beats 96.77 % of csharp submissions(29.4 MB)
        /// 
        /// 时间复杂度：O(nlogn)，
        ///     n 是数组 envelopes 的长度，
        ///     排序需要的时间复杂度为 O(nlogn)，
        ///     动态规划需要的时间复杂度同样为 O(nlogn)。
        /// 空间复杂度：O(n)，
        ///     n为数组 f 需要的空间   
        /// </summary>
        /// <param name="envelopes"></param>
        /// <returns></returns>
        public int MaxEnvelopes(int[][] envelopes)
        {
            if (envelopes.Length == 0)
            {
                return 0;
            }

            int n = envelopes.Length;
            Array.Sort(envelopes, new ComparerSolution354());

            List<int> f = new List<int>(); //f中保存着 范围的右边界值。
            f.Add(envelopes[0][1]);

            for (int i = 1; i < n; ++i)
            {
                int num = envelopes[i][1];
                if (num > f[f.Count - 1])
                {  //当前范围的右边界值大于 列表中保存的最后一个右边界，添加到列表。
                    f.Add(num);
                }
                else
                {
                    //否则我们找出 f 中比 hi 严格小的最大的元素 f|j0|
                    int index = binarySearch(f, num); //否则，二进制搜索？？？ 不是很懂。 找最小右边界，然后更新f中的右边界？？。
                    f[index] = num;
                }
            }
            return f.Count;
        }

        public int binarySearch(List<int> f, int target)
        {
            int low = 0, high = f.Count - 1;
            while (low < high)
            {
                int mid = (high - low) / 2 + low;
                if (f[mid] < target)
                {
                    low = mid + 1;
                }
                else
                {
                    high = mid;
                }
            }
            return low;
        }
    }

    /// <summary>
    /// 按照左边小靠前，右边大靠前，优先处理左边的原则，排序。
    /// 
    /// 测试结果：[[5,4],[6,4],[6,7],[2,3]] =》  [[2,3],[5,4],[6,7],[6,4],]
    /// </summary>
    public class ComparerSolution354 : IComparer<int[]>
    {
        public int Compare(int[] e1, int[] e2)
        {
            if (e1[0] != e2[0])
            {
                return e1[0] - e2[0]; //左边小靠前原则
            }
            else
            {
                return e2[1] - e1[1]; //右边大靠前原则
            }
        }
    }
}
