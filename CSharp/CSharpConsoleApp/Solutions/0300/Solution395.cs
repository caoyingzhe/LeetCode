using System;
using System.Collections.Generic;
namespace CSharpConsoleApp.Solutions
{
    /*
     * @lc app=leetcode.cn id=395 lang=csharp
     *
     * [395] 至少有 K 个重复字符的最长子串
     *
     * https://leetcode-cn.com/problems/longest-substring-with-at-least-k-repeating-characters/description/
     *
     * Category	Difficulty	Likes	Dislikes
     * algorithms	Hard (55.29%)	483	-
     * Tags
     * binary-search | dynamic-programming
     * 
     * Companies
     * baidu | facebook
     * 
     * Total Accepted:    44.8K
     * Total Submissions: 86.4K
     * Testcase Example:  '"aaabb"\n3'
     *
     * 给你一个字符串 s 和一个整数 k ，请你找出 s 中的最长子串， 要求该子串中的每一字符出现次数都不少于 k 。返回这一子串的长度。
     * 
     * 示例 1：
     * 输入：s = "aaabb", k = 3
     * 输出：3
     * 解释：最长子串为 "aaa" ，其中 'a' 重复了 3 次。
     * 
     * 示例 2：
     * 输入：s = "ababbc", k = 2
     * 输出：5
     * 解释：最长子串为 "ababb" ，其中 'a' 重复了 2 次， 'b' 重复了 3 次。
     * 
     * 提示：
     * 1 <= nums.length <= 1000
     * 0 <= nums[i] <= 10^6
     * 1 <= m <= min(50, nums.length)
     */
    public class Solution395
    {
        public int LongestSubstring(String s, int k)
        {
            int n = s.Length;
            return DFS(s, 0, n - 1, k);
        }

        //private List<int> cnt = new List<int>();

        /// <summary>
        /// 32/32 cases passed (76 ms)
        /// Your runtime beats 100 % of csharp submissions
        /// Your memory usage beats 75.12 % of csharp submissions(22.1 MB)
        ///
        /// 补充： 将cnt数组改为List可以节省一点空间，但会牺牲一点性能
        /// 32/32 cases passed (84 ms)
        /// Your runtime beats 94.03 % of csharp submissions
        /// Your memory usage beats 79.6 % of csharp submissions(22 MB)
        /// 
        /// 作者：LeetCode-Solution
        /// 链接：https://leetcode-cn.com/problems/longest-substring-with-at-least-k-repeating-characters/solution/zhi-shao-you-kge-zhong-fu-zi-fu-de-zui-c-o6ww/
        /// </summary>
        /// <param name="s">字符串</param>
        /// <param name="l">字符串左边索引</param>
        /// <param name="r">字符串右边索引</param>
        /// <param name="k">重复字数</param>
        /// <returns></returns>
        public int DFS(String s, int l, int r, int k)
        {
            //全部小写字母的出现次数表
            int[] cnt = new int[26];

            //搜索左右中各个字符的个数（题目要求为全部小写字母）
            int i;
            for (i = l; i <= r; i++)
            {
                cnt[s[i] - 'a']++;
            }

            char split = (char)0;
            for (i = 0; i < 26; i++)
            {
                if (cnt[i] > 0 && cnt[i] < k)
                {
                    //发现存在大于0小于k的数量的字符，截断；
                    split = (char)(i + 'a');
                    break;
                }
            }

            //不存在可截断字符数量，按最大值返回。
            if (split == 0)
            {
                return r - l + 1;
            }

            i = l;
            int ret = 0;
            while (i <= r)
            {
                while (i <= r && s[i] == split) //向右递增，直至未发现分隔符（可截断字符）
                {
                    i++;
                }
                if (i > r)
                {
                    break;
                }

                int start = i;
                while (i <= r && s[i] != split)  //向右递增，直至发现分隔符（可截断字符）
                {
                    i++;
                }

                //计算该期间的最大长度 （使用了DFS，计算分割符号时，有部分重复计算，可改进）
                int length = DFS(s, start, i - 1, k);
                ret = Math.Max(ret, length);
            }
            return ret;
        }
    }
}
