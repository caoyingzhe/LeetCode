using System;
using System.Collections.Generic;
namespace CSharpConsoleApp.Solutions
{
    /*
     * @lc app=leetcode.cn id=667 lang=csharp
     *
     * [667] 优美的排列 II
     *
     * https://leetcode-cn.com/problems/beautiful-arrangement-ii/description/
     *
     * algorithms
     * Medium (61.99%)
     * Likes:    89
     * Dislikes: 0
     * Total Accepted:    7K
     * Total Submissions: 11.2K
     * Testcase Example:  '3\n1'
     *
     * 给你两个整数 n 和 k ，请你构造一个答案列表 answer ，该列表应当包含从 1 到 n 的 n 个不同正整数，并同时满足下述条件：
     * 
     * 假设该列表是 answer = [a1, a2, a3, ... , an] ，那么列表 [|a1 - a2|, |a2 - a3|, |a3 -
     * a4|, ... , |an-1 - an|] 中应该有且仅有 k 个不同整数。
     * 
     * 返回列表 answer 。如果存在多种答案，只需返回其中 任意一种 。
     * 
     * 示例 1：
     * 输入：n = 3, k = 1
     * 输出：[1, 2, 3]
     * 解释：[1, 2, 3] 包含 3 个范围在 1-3 的不同整数，并且 [1, 1] 中有且仅有 1 个不同整数：1
     * 
     * 
     * 示例 2：
     * 输入：n = 3, k = 2
     * 输出：[1, 3, 2]
     * 解释：[1, 3, 2] 包含 3 个范围在 1-3 的不同整数，并且 [2, 1] 中有且仅有 2 个不同整数：1 和 2
     * 
     * 
     * 提示：
     */
    public class Solution667
    {
        /// <summary>
        /// 该方法效率不佳
        /// 70/70 cases passed (312 ms)
        /// Your runtime beats 20 % of csharp submissions
        /// Your memory usage beats 20 % of csharp submissions(28.9 MB)
        /// 
        /// 在前k+1个数构造k个差值的数组，
        /// 从k+1之后直接全部为递增的序列；
        /// k个差值的数组为 1、k+1、2、k、3、k-1……
        /// </summary>
        /// <param name="n"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public int[] ConstructArray(int n, int k)
        {
            int[] v = new int[n];
            v[0] = 1;

            //前k+1个数构造k个差值的数组，(索引范围0~k)
            for (int i = 1, interval = k; i <= k; i++, interval--)
            {
                if(i % 2 == 1)
                    v[i] = v[i - 1] + interval;  //索引为奇数，排序为偶 
                else
                    v[i] = v[i - 1] - interval;
            }

            //从k+1之后直接全部为递增的序列；
            for (int i = k + 1; i < n; i++)
            {
                v[i] = i + 1;
            }
            return v;
        }
        //作者：leviswar
        //链接：https://leetcode-cn.com/problems/beautiful-arrangement-ii/solution/du-shi-100de-ji-bai-by-leviswar/

    }
}