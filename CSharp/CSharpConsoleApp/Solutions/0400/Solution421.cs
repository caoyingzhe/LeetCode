using System;
using System.Collections.Generic;
namespace CSharpConsoleApp.Solutions
{
    /*
     * @lc app=leetcode.cn id=421 lang=csharp
     *
     * [421] 数组中两个数的最大异或值
     *
     * https://leetcode-cn.com/problems/maximum-xor-of-two-numbers-in-an-array/description/
     *
     * Category	Difficulty	Likes	Dislikes
     * algorithms	Medium (62.36%)	362	-
     * Tags
     * bit-manipulation | trie
     * 
     * Companies
     * google
     * 
     * Total Accepted:    30.7K
     * Total Submissions: 49.3K
     * Testcase Example:  '[3,10,5,25,2,8]'
     *
     * 给你一个整数数组 nums ，返回 nums[i] XOR nums[j] 的最大运算结果，其中 0 ≤ i ≤ j < n 。
     * 进阶：你可以在 O(n) 的时间解决这个问题吗？
     * 
     * 示例 1：
     * 输入：nums = [3,10,5,25,2,8]
     * 输出：28
     * 解释：最大运算结果是 5 XOR 25 = 28.
     * 
     * 示例 2：
     * 输入：nums = [0]
     * 输出：0
     * 
     * 示例 3：
     * 输入：nums = [2,4]
     * 输出：6
     * 
     * 示例 4：
     * 输入：nums = [8,10,2]
     * 输出：10
     * 
     * 示例 5：
     * 输入：nums = [14,70,53,83,49,91,36,80,92,51,66,70]
     * 输出：127
     * 
     * 提示：
     */
    public class Solution421
    {
        #region --------------- 哈希表 方法 (勉强通过)--------------------
        // 最高位的二进制位编号为 30
        const int BIT_30 = 30;

        /// <summary>
        /// 哈希表法
        /// 时间复杂度 O（N） ，实际是30*N,仍然属于O（N）范畴。当N<30时速度反而不如暴力快。
        /// 41/41 cases passed (500 ms)
        ///Your runtime beats 6.35 % of csharp submissions
        ///Your memory usage beats 15.87 % of csharp submissions(44.5 MB)
        /// 作者：LeetCode-Solution
        /// 链接：https://leetcode-cn.com/problems/maximum-xor-of-two-numbers-in-an-array/solution/shu-zu-zhong-liang-ge-shu-de-zui-da-yi-h-n9m9/
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int FindMaximumXOR_HashTable(int[] nums)
        {
            int x = 0;

            //从高位到低位计算0/1的值，存入哈希表。
            for (int k = BIT_30; k >= 0; --k)
            {
                HashSet<int> seen = new HashSet<int>();
                // 将所有的 pre^k(a_j) 放入哈希表中
                foreach (int num in nums)
                {
                    // 如果只想保留从最高位开始到第 k 个二进制位为止的部分
                    // 只需将其右移 k 位
                    seen.Add(num >> k);
                }

                // 目前 x 包含从最高位开始到第 k+1 个二进制位为止的部分
                // 我们将 x 的第 k 个二进制位，设置为 1，即为 x = x*2+1
                int xNext = x * 2 + 1;
                bool found = false;

                // 枚举 i
                foreach (int num in nums)
                {
                    if (seen.Contains(xNext ^ (num >> k)))
                    {
                        found = true;
                        break;
                    }
                }

                if (found)
                {
                    x = xNext;
                }
                else
                {
                    // 如果没有找到满足等式的 a_i 和 a_j，那么 x 的第 k 个二进制位只能为 0
                    // 即为 x = x*2
                    x = xNext - 1;
                }
            }
            return x;
        }
        #endregion
        #region --------------- Trie 方法 (勉强通过)--------------------
        ///41/41 cases passed(328 ms)
        ///Your runtime beats 6.35 % of csharp submissions
        ///Your memory usage beats 12.69 % of csharp submissions(50.5 MB)

        Trie421 root = new Trie421();
        // 最高位的二进制位编号为 30
        const int HIGH_BIT = 30;

        public int FindMaximumXOR_Trie(int[] nums)
        {
            int n = nums.Length;
            int x = 0;
            for (int i = 1; i < n; ++i)
            {
                // 将 nums[i-1] 放入字典树，此时 nums[0 .. i-1] 都在字典树中
                Add(nums[i - 1]);
                // 将 nums[i] 看作 ai，找出最大的 x 更新答案
                x = Math.Max(x, Check(nums[i]));
            }
            return x;
        }

        public void Add(int num)
        {
            Trie421 cur = root;
            for (int k = HIGH_BIT; k >= 0; --k)
            {
                int bit = (num >> k) & 1;
                if (bit == 0)
                {
                    if (cur.left == null)
                        cur.left = new Trie421();
                    cur = cur.left;
                }
                else
                {
                    if (cur.right == null)
                        cur.right = new Trie421();
                    cur = cur.right;
                }
            }
        }

        public int Check(int num)
        {
            Trie421 cur = root;
            int x = 0;
            for (int k = HIGH_BIT; k >= 0; --k)
            {
                int bit = (num >> k) & 1;
                if (bit == 0)
                {
                    // a_i 的第 k 个二进制位为 0，应当往表示 1 的子节点 right 走
                    if (cur.right != null)
                    {
                        cur = cur.right;
                        x = x * 2 + 1;
                    }
                    else
                    {
                        cur = cur.left;
                        x = x * 2;
                    }
                }
                else
                {
                    // a_i 的第 k 个二进制位为 1，应当往表示 0 的子节点 left 走
                    if (cur.left != null)
                    {
                        cur = cur.left;
                        x = x * 2 + 1;
                    }
                    else
                    {
                        cur = cur.right;
                        x = x * 2;
                    }
                }
            }
            return x;
        }

        class Trie421 : SolutionBase.Trie
        {
            public Trie421 left = null;  // 左子树指向表示 0 的子节点
            public Trie421 right = null; // 右子树指向表示 1 的子节点
        }
        #endregion
    }
}
