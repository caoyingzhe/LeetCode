using System;
namespace CSharpConsoleApp.Solutions
{
    /*
     * @lc app=leetcode.cn id=396 lang=csharp
     *
     * [396] 旋转函数
     *
     * https://leetcode-cn.com/problems/rotate-function/description/
     *
     * Category	Difficulty	Likes	Dislikes
     * algorithms	Medium (41.08%)	78	-
     * Tags
     * math
     * 
     * Companies
     * amazon
     * 
     * Total Accepted:    7.7K
     * Total Submissions: 18.7K
     * Testcase Example:  '[4,3,2,6]'
     *
     * 给定一个长度为 n 的整数数组 A 。
     * 
     * 假设 Bk 是数组 A 顺时针旋转 k 个位置后的数组，我们定义 A 的“旋转函数” F 为：
     * 
     * F(k) = 0 * Bk[0] + 1 * Bk[1] + ... + (n-1) * Bk[n-1]。
     * 
     * 计算F(0), F(1), ..., F(n-1)中的最大值。
     * 
     * 注意:
     * 可以认为 n 的值小于 10^5。
     * 
     * 示例:
     * 
     * 
     * A = [4, 3, 2, 6]
     * 
     * F(0) = (0 * 4) + (1 * 3) + (2 * 2) + (3 * 6) = 0 + 3 + 4 + 18 = 25
     * F(1) = (0 * 6) + (1 * 4) + (2 * 3) + (3 * 2) = 0 + 4 + 6 + 6 = 16
     * F(2) = (0 * 2) + (1 * 6) + (2 * 4) + (3 * 3) = 0 + 6 + 8 + 9 = 23
     * F(3) = (0 * 3) + (1 * 2) + (2 * 6) + (3 * 4) = 0 + 2 + 12 + 12 = 26
     * 
     * 所以 F(0), F(1), F(2), F(3) 中的最大值是 F(3) = 26 。
     * 
     * 
     */

    // @lc code=start
    public class Solution
    {
        //作者：alexampe
        //链接：https://leetcode-cn.com/problems/rotate-function/solution/qiu-jie-wen-ti-dai-gong-shi-tui-dao-jian-q97i/
        //pos代表最后一项的数组下标
        //F(n)=F(n-1)+sum-n*nums[pos];
        //循环往复n次后，答案就有了；
        /// <summary>
        /// 57/57 cases passed (380 ms)
        /// Your runtime beats 14.29 % of csharp submissions
        /// Your memory usage beats 14.29 % of csharp submissions(43.8 MB)
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int MaxRotateFunction_slow(int[] nums)
        {
            long sum = 0, n = nums.Length;
            long pos = n - 1, fn = 0;
            for (int i = 0; i < n; i++)
            {
                sum += nums[i];
                fn += i * nums[i]; //算出f[0]
            }
            long zqmax = fn;
            for (int i = 0; i < n; i++) 
            {
                fn = fn - n * nums[pos] + sum;  //算出f[1]～f[n-1]
                pos--;
                zqmax = Math.Max(zqmax, fn);
            }
            return (int) zqmax;
        }

        //作者：meng-li-ye-tian-xing
        //链接：https://leetcode-cn.com/problems/rotate-function/solution/c-0ms-ji-zhun-chai-by-meng-li-ye-tian-xi-a7zi/
        /// <summary>
        /// 数组旋转一位后，前面 n−1 个数字都多加了一次，而最后一个数字少了 n−1 次。
        /// 每次旋转都相对上一次变换了 sum − num.last ∗ n
        /// 维护一个最大值即为所求。
        ///
        /// 本解法跟上一解法本质相同
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int MaxRotateFunction(int[] nums)
        {
            long sum = 0; //nums累计和
            long ans = 0; //最大变化值
            long obv = 0; //临时变化值 （f[0]～f[n-1]计算期间)
            int n = nums.Length;

            foreach (int x in nums)
            {
                sum += x;
            }
            // ans = 最大变化值
            for (int i = 0; i < n; i++)
            {
                obv += sum - (long)n * nums[n - i - 1];
                //obv += sum - A[n - i - 1] - (n - 1) * A[n - i - 1]; 合并前的写法
                ans = Math.Max(ans, obv);
            }
            // ans = 最大变化值 + 即为求f[0]
            for (int i = 0; i < n; i++)
            {
                ans += nums[i] * i;  //+= nums[i] * i 
            }
            return (int) ans;
        }
    }
    // @lc code=end
}
