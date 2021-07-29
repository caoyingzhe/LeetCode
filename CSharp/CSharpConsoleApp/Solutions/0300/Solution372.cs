using System;
using System.Collections.Generic;
namespace CSharpConsoleApp.Solutions
{
    /*
     * @lc app=leetcode.cn id=372 lang=csharp
     *
     * [372] 超级次方
     *
     * https://leetcode-cn.com/problems/super-pow/description/
     *
     * Category	Difficulty	Likes	Dislikes
     * algorithms	Medium (50.11%)	119	-
     * Tags
     * math
     * 
     * Companies
     * Unknown
     * 
     * Total Accepted:    12.7K
     * Total Submissions: 25.3K
     * Testcase Example:  '2\n[3]'
     *
     * 你的任务是计算 a^b 对 1337 取模，a 是一个正整数，b 是一个非常大的正整数且会以数组形式给出。
     * 
     * 
     * 示例 1：
     * 输入：a = 2, b = [3]
     * 输出：8
     * 
     * 
     * 示例 2：
     * 输入：a = 2, b = [1,0]
     * 输出：1024
     * 
     * 
     * 示例 3：
     * 输入：a = 1, b = [4,3,3,8,5,2]
     * 输出：1
     * 
     * 
     * 示例 4：
     * 输入：a = 2147483647, b = [2,0,0]
     * 输出：1198
     * 
     * 
     * 提示：
     * 1 <= a <= 231 - 1
     * 1 <= b.length <= 2000
     * 0 <= b[i] <= 9
     * b 不含前导 0
     */

    // @lc code=start
    public class Solution372 : SolutionBase
    {
        /// <summary>
        /// 难度
        /// </summary>
        public override Difficulity GetDifficulity() { return Difficulity.Medium; }
        /// <summary>
        /// 关键字:
        /// </summary>
        public override string[] GetKeyWords() { return new string[] { "离散数学的模幂算法", "模运算的技巧" }; }
        /// <summary>
        /// 标签：
        /// </summary>
        public override Tag[] GetTags() { return new Tag[] { Tag.Math }; }

        
        public override bool Test(System.Diagnostics.Stopwatch sw)
        {
            bool isSuccess = true;

            int a; int[] b;
            int result, checkResult;

            a = 2; b = new int[] { 3 };
            checkResult = 8;
            result = SuperPow(a, b);
            isSuccess &= IsSame(result, checkResult);
            PrintResult(isSuccess, (result).ToString(), (checkResult).ToString());

            a = 2; b = new int[] { 1, 0 };
            checkResult = 1024;
            result = SuperPow(a, b);
            isSuccess &= IsSame(result, checkResult);
            PrintResult(isSuccess, (result).ToString(), (checkResult).ToString());

            a = 1; b = new int[] { 4, 3, 3, 8, 5, 2 };
            checkResult = 1;
            result = SuperPow(a, b);
            isSuccess &= IsSame(result, checkResult);
            PrintResult(isSuccess, (result).ToString(), (checkResult).ToString());

            a = 2147483647; b = new int[] { 2, 0, 0 };
            checkResult = 1198;
            result = SuperPow(a, b);
            isSuccess &= IsSame(result, checkResult);
            PrintResult(isSuccess, (result).ToString(), (checkResult).ToString());


            return isSuccess;
        }

        /// <summary>
        /// 三个难点：
        ///     1. 一是如何处理用数组表示的指数，
        ///     2. 二是如何得到求模之后的结果?
        ///             避免溢出的同时得到正确结果的方法:
        ///             (a * b) % k = (a % k)(b % k) % k
        ///     3. 三是如何高效进行幂运算
        ///     b ={  a×a^(b−1), b 为奇数
        ///     b =(a^(b/2))^2  ,b 为偶数​
        ///     这个思想肯定比直接用 for 循环求幂要高效，

        int baseN = 1337;
        //int depth = 0;
        /// </summary>
        /// 54/54 cases passed (96 ms)
        /// Your runtime beats 100 % of csharp submissions
        /// Your memory usage beats 60 % of csharp submissions(26.1 MB)
        /// 作者：labuladong
        /// 链接：https://leetcode-cn.com/problems/super-pow/solution/you-qian-ru-shen-kuai-su-mi-suan-fa-xiang-jie-by-l/
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public int SuperPow(int a, int[] b)
        {
            return SuperPow1(a, b, 0);
            //return SuperPow2(a, new List<int>(b));
        }

        public int SuperPow2(int a, List<int> b)
        {
            if (b.Count == 0) return 1;
            int last = b[b.Count - 1];
            //b.pop_back();
            b.RemoveAt(b.Count -1);

            int part1 = Mypow(a, last);
            int part2 = Mypow(SuperPow2(a, b), 10);
            // 每次乘法都要求模
            return (part1 * part2) % baseN;
        }

        public int SuperPow1(int a, int[] b, int depth)
        {
            if (b.Length - 1 - depth < 0) return 1;
            int last = b[b.Length - 1 - depth];
            //b.pop_back();

            int part1 = Mypow(a, last);
            int part2 = Mypow(SuperPow1(a, b, depth + 1), 10);
            // 每次乘法都要求模
            return (part1 * part2) % baseN;
        }

        int Mypow(int a, int k)
        {
            if (k == 0) return 1;
            a %= baseN;

            if (k % 2 == 1)
            {
                // k 是奇数
                return (a * Mypow(a, k - 1)) % baseN;
            }
            else
            {
                // k 是偶数
                int sub = Mypow(a, k / 2);
                return (sub * sub) % baseN;
            }
        }
    }
    // @lc code=end


}
