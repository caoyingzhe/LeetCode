using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpConsoleApp.Solutions
{
    /*
     * @lc app=leetcode.cn id=313 lang=csharp
     *
     * [313] 超级丑数
     *
     * https://leetcode-cn.com/problems/super-ugly-number/description/
     *
     * algorithms
     * Medium (64.44%)
     * Likes:    159
     * Dislikes: 0
     * Total Accepted:    16.5K
     * Total Submissions: 25.6K
     * Testcase Example:  '12\n[2,7,13,19]'
     *
     * 编写一段程序来查找第 n 个超级丑数。
     * 
     * 超级丑数是指其所有质因数都是长度为 k 的质数列表 primes 中的正整数。
     * 
     * 示例:
     * 输入: n = 12, primes = [2,7,13,19]
     * 输出: 32 
     * 解释: 给定长度为 4 的质数列表 primes = [2,7,13,19]，前 12
     * 个超级丑数序列为：[1,2,4,7,8,13,14,16,19,26,28,32] 。
     * 
     * 说明:
     * 1 是任何给定 primes 的超级丑数。
     * 给定 primes 中的数字以升序排列。
     * 0 < k ≤ 100, 0 < n ≤ 10^6, 0 < primes[i] < 1000 。
     * 第 n 个超级丑数确保在 32 位有符整数范围内。
     * 
     */
    class Solution313 : SolutionBase
    {
        /// <summary>
        /// 难度
        /// </summary>
        public override Difficulity GetDifficulity() { return Difficulity.Medium; }
        /// <summary>
        /// 关键字:
        /// </summary>
        public override string[] GetKeyWords() { return new string[] { "丑数" }; }
        /// <summary>
        /// 标签： 
        /// </summary>
        public override Tag[] GetTags() { return new Tag[] { Tag.DynamicProgramming, Tag.HashTable }; }

        public override bool Test(System.Diagnostics.Stopwatch sw)
        {
            bool isSuccess = true;
            int max = NthSuperUglyNumber(8, new int[] { 2, 3, 4, 5 });
            Print("max = " + max);
            return isSuccess;
        }

        /// <summary>
        /// 通过了，但是效率太低。浪费过多。
        /// </summary>
        /// <param name="n"></param>
        /// <param name="primes"></param>
        /// <returns></returns>
        public int NthSuperUglyNumber2(int n, int[] primes)
        {
            PriorityQueue<long> q = new PriorityQueue<long>(n, new ComparerLongAsc());
            q.Push(1); // 放入第一个数据

            HashSet<long> s = new HashSet<long>();
            int k = primes.Length;
            s.Add(1); // 用hash table存放已经计算过的数据
            for (int i = 1; i < n; ++i)
            {
                long cur = q.Top();
                q.Pop();
                for (int j = 0; j < k; ++j)
                {
                    long num = 1 * cur *primes[j];
                    if (!s.Contains(num))
                    {
                        s.Add(num);

                        q.Push(num);
                        //Print("Add {0} | {1}", num, GetArrayStr<long>(q.ToArray()));
                    }
                }
            }
            //Print(GetArrayStr<long>(q.ToArray()));
            return (int)q.Top();
        }

        public int NthSuperUglyNumber(int n, int[] primes)
        {
            //用于防止添加重复的丑数，比如8 = 2*2*2 = 4*2, 会发生重复。
            HashSet<int> set = new HashSet<int>();

            PriorityQueue<long> queue = new PriorityQueue<long>(n, new ComparerLongDesc());
            int value = 1;
            for(int i=0; i<n; i++)
            {
                value = 1;
                for (int j=0; j<primes.Length; j++)
                {
                    value *= primes[j];
                    if (value < 0)
                        break;
                    if (!set.Contains(value))
                    {
                        set.Add(value);
                        Print("Add {0} | set.Count = {1}",value, set.Count);
                        if (set.Count == n)
                        {
                            if(queue.Top() > value)
                            {
                                Print("Top = {0} | new Value = {1}", queue.Top(), value);
                                queue.Pop();
                                queue.Push(value);
                                Print("Update Value = {0} | Queue = {1}", value, GetArrayStr<long>(queue.ToArray()));
                            }
                        }
                        else
                        { 
                            //if(value > 0)
                            {
                                queue.Push(value);
                                Print("Add {0} | Queue = {1}", value, GetArrayStr<long>(queue.ToArray()));
                            }
                        }
                    }
                }
            }

            Print(GetArrayStr<long>(queue.ToArray()));
            return (int)queue.Top();
        }
    }
}
