using System;
namespace CSharpConsoleApp.Solutions
{
    /*
     * @lc app=leetcode.cn id=668 lang=csharp
     *
     * [668] 乘法表中第k小的数
     *
     * https://leetcode-cn.com/problems/kth-smallest-number-in-multiplication-table/description/
     *
     * Category	Difficulty	Likes	Dislikes
     * algorithms	Hard (49.94%)	138	-
     * Tags
     * binary-search
     * 
     * Companies
     * google
     * 
     * Total Accepted:    5.8K
     * Total Submissions: 11.7K
     * Testcase Example:  '3\n3\n5'
     *
     * 几乎每一个人都用 乘法表。但是你能在乘法表中快速找到第k小的数字吗？
     * 给定高度m 、宽度n 的一张 m * n的乘法表，以及正整数k，你需要返回表中第k 小的数字。
     * 
     * 例 1：
     * 输入: m = 3, n = 3, k = 5
     * 输出: 3
     * 解释: 
     * 乘法表:
     * 1    2    3
     * 2    4    6
     * 3    6    9
     * 第5小的数字是 3 (1, 2, 2, 3, 3).
     * 
     * 
     * 例 2：
     * 输入: m = 2, n = 3, k = 6
     * 输出: 6
     * 解释: 
     * 乘法表:
     * 1    2    3
     * 2    4    6
     * 第6小的数字是 6 (1, 2, 2, 3, 4, 6).
     * 
     * 
     * 注意：
     * m 和 n 的范围在 [1, 30000] 之间。
     * k 的范围在 [1, m * n] 之间。
     */
    public class Solution668
    {
        /// 作者：wohenidej
        /// 链接：https://leetcode-cn.com/problems/kth-smallest-number-in-multiplication-table/solution/can-kao-liao-ping-lun-qu-da-lao-de-fang-fa-zhong-x/
        /// 70/70 cases passed(76 ms)
        /// Your runtime beats 50 % of csharp submissions
        /// Your memory usage beats 50 % of csharp submissions(14.8 MB)
        public int FindKthNumber(int m, int n, int k)
        {
            if (k == 1) return 1;
            if (k == m * n) return m * n;
            int left = 1, right = m * n, mid;//值来当作边界，乘法表（m*n）最小是1，最大是m*n
            while (left < right)
            {
                mid = (left + right) >> 1;
                int temp = Fun(m, n, mid);//得到在乘法表中 值 <= mid 的数量
                if (temp < k)
                {
                    left = mid + 1;
                    //如果temp < k, 说明当前mid这个值在目标值的左边（比目标值小），
                    //所以可以缩小边界
                }
                else
                    right = mid;
                //temp >= k， 在temp>k时，为什么不取 right = mid-1，
                //而是right = mid。因为我们的目标值可能存在重复，
                //比如 123334，如果我选择要找第3小的数，
                //而mid当前恰好=3，那么temp得到的结果会是5（<=mid）。
                //如果我们选择right = mid-1=2。那么将会运行错误导致结果错误。
                //在temp = k时，为什么不能立马返回结果呢，而是继续运行缩小边界？
                //因为我们当前的mid可能是一个不在乘法表中的值，
                //毕竟mid=(left+right) >> 1; 所以立即返回可能返回错误答案。
                //所以一定收缩范围 直到left=right。最终返回的一定是正确值
                //（若答案t的temp = k， 而某一非表值x的temp也=k， 那么t一定比x小，
                //最终x也会被right缩小导致出局）。
            }
            return left;
        }

        /// <summary>
        /// 函数功能：
        ///     获得在m*n的乘法表中，找出有多少个值 <= num。
        ///     返回满足条件的值的数量
        /// 说明：
        ///     跟普通二分不一样 普通二分把下标来当作边界，而这里的二分则是把值来当作边界
        /// </summary>
        /// <param name="m"></param>
        /// <param name="n"></param>
        /// <param name="num"></param>
        /// <returns></returns>
        private int Fun(int m, int n, int num)
        {
            int count = 0;
            for (int i = 1; i <= m; ++i) //行从第一行开始
            {
                //此表达式的含义：num这个值在当前第i行，有多少个值不比它大（<=num的个数）
                count += Math.Min(num / i, n);
            }
            return count;
        }
    }
}
