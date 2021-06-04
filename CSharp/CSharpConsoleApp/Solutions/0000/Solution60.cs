using System;
using System.Collections.Generic;
using System.Text;
namespace CSharpConsoleApp.Solutions
{
    public class Solution60
    {

        //作者：LeetCode-Solution
        //链接：https://leetcode-cn.com/problems/permutation-sequence/solution/di-kge-pai-lie-by-leetcode-solution/

        /// <summary>
        /// 时间复杂度：O(n^2)
        /// 空间复杂度：O(n)
        /// 200/200 cases passed (92 ms)
        /// Your runtime beats 81.03 % of csharp submissions
        /// Your memory usage beats 56.9 % of csharp submissions(22.8 MB)
        /// </summary>
        /// <param name="n"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public string GetPermutation_Home(int n, int k)
        {
            int[] factorial = new int[n]; //# n 阶乘 映射集 0...n-1
            factorial[0] = 1;
            for (int i = 1; i < n; ++i)
            {
                factorial[i] = factorial[i - 1] * i;
            }
            //k 需要先自减一 原因：
            //不妨设分子为 k，那么得到的公式可能是这样的：
            //    ai =  ⌊k / (n - 1)!⌋ +1
            //尝试使用以上公式计算 a1:
            //   （1）当 k< (n-1)!时，a1 = ⌊k / (n - 1)!⌋ +1 = 1，正确
            //   （2）当 k = (n - 1)! 时，a1 = ⌊k / (n - 1)!⌋ +1 = 2，错误
            //而使用 ai =  ⌊(k - 1) / (n - 1)!⌋ +1 却能正确处理这种情况
            //即：只是简洁了数学公式的使用，如果不自减一的话，需要应对多种情况
            --k;

            //ans为结果集
            System.Text.StringBuilder ans = new System.Text.StringBuilder();
            //0，1...n 排列标志集，标识在一整次寻找中哪个数已进排列中
            int[] valid = new int[n + 1];
            for (int i = 0; i < n + 1; i++) valid[i] = 1;

            for (int i = 1; i <= n; ++i) //排列中 依次取得的排列的数的个数 1个...n个
            {
                //此公式可算出上面的数对应的从 1...n 中哪个数 order | n - i 为了对应 factorial 下标,
                //获取剩余个数排列种类总数
                int order = k / factorial[n - i] + 1;
                for (int j = 1; j <= n; ++j) //依次寻找对应的数 从 1...n
                {
                    //找到一个数，若没有进入过结果排列集，减一，直至 order == 0
                    //则表示找到该排列中的第 i 个数，
                    //修改标志集对应位置为已进入结果排序集
                    order -= valid[j]; //
                    if (order == 0)
                    {
                        ans.Append(j);
                        valid[j] = 0;
                        break;
                    }
                }
                //之后 k 对于已取得的数的排列位数取余，得到下一位需要的
                k %= factorial[n - i]; //
            }
            return ans.ToString();
        }

        /// <summary>
        /// 不对 K 进行任何技巧性操作的代码。
        /// 200/200 cases passed (96 ms)
        /// Your runtime beats 58.62 % of csharp submissions
        /// Your memory usage beats 70.69 % of csharp submissions(22.7 MB)
        /// 作者：anarkitek
        /// 链接：https://leetcode-cn.com/problems/permutation-sequence/solution/bu-shi-yong-k-de-c-dai-ma-by-anarkitek-db8t/
        /// </summary>
        /// <param name="n"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public string GetPermutation(int n, int k)
        {
            // n 个数字，就有 n! 种排列方式
            // 所以第一个数就是 k / (n - 1)! + 1，确定第一个数后，后面剩下 k' = k % (n - 1)!
            // 然后在剩下的数字里面从小到大选第 k' / (n - 2)! + 1 大的数
            // 那我们就需要一个 bool vector 来存储某个值是否已经被使用
            string ans = "";
            List<bool> used = new List<bool>(new bool[n+1]);
            List<int> factorials = new List<int>(new int[n + 1]);
            factorials[0] = 1;
            for (int i = 1; i <= n; ++i)
            {
                factorials[i] = i * factorials[i - 1];
            }
            for (int i = 0; i < n; ++i)
            {
                int cnt = 0;
                int subPerms = factorials[n - i - 1];
                // k 等于 0 意味着从当前 index 往后全部倒序排列
                if (k == 0)
                {
                    break;
                }
                // k 能被 subperms 整除说明除当前的index，后面全部倒序排列
                else if (k % subPerms == 0)
                {
                    cnt = k / subPerms;
                }
                // 最正常就是不能整除，很好理解
                else
                {
                    cnt = k / subPerms + 1;
                }
                for (int j = 0; j < n; ++j)
                {
                    if (!used[j + 1])
                    {
                        --cnt;
                    }
                    if (cnt == 0)
                    {
                        ans += (j + 1);
                        used[j + 1] = true;
                        break;
                    }
                }
                k %= subPerms;
            }
            //这对应 k=0 的情况，将没有用的数字倒序排列。
            for (int i = n; i >= 1; --i)
            {
                if (!used[i])
                {
                    ans += (i);
                }
            }
            return ans;
        }
    }
}
