using System;
using System.Collections.Generic;
namespace CSharpConsoleApp.Solutions
{
    /*
     * @lc app=leetcode.cn id=402 lang=csharp
     *
     * [402] 移掉K位数字
     *
     * https://leetcode-cn.com/problems/remove-k-digits/description/
     *
     * Category	Difficulty	Likes	Dislikes
     * algorithms	Medium (32.76%)	582	-
     * Tags
     * stack | greedy
     * 
     * Companies
     * google | snapchat
     * 
     * Total Accepted:    68.7K
     * Total Submissions: 209.6K
     * Testcase Example:  '"1432219"\n3'
     *
     * 给定一个以字符串表示的非负整数 num，移除这个数中的 k 位数字，使得剩下的数字最小。
     * 
     * 注意:
     * num 的长度小于 10002 且 ≥ k。
     * num 不会包含任何前导零。
     * 
     * 示例 1 :
     * 输入: num = "1432219", k = 3
     * 输出: "1219"
     * 解释: 移除掉三个数字 4, 3, 和 2 形成一个新的最小的数字 1219。
     * 
     * 示例 2 :
     * 输入: num = "10200", k = 1
     * 输出: "200"
     * 解释: 移掉首位的 1 剩下的数字为 200. 注意输出不能有任何前导零。
     * 
     * 示例 3 :
     * 输入: num = "10", k = 2
     * 输出: "0"
     * 解释: 从原数字移除所有的数字，剩余为空就是0。
     */
    public class Solution402 : SolutionBase
    {
        /// <summary>
        /// 难度
        /// </summary>
        public override Difficulity GetDifficulity() { return Difficulity.Medium; }
        /// <summary>
        /// 关键字:
        /// </summary>
        public override string[] GetKeyWords() { return new string[] { }; }
        /// <summary>
        /// 标签：
        /// </summary>
        public override Tag[] GetTags() { return new Tag[] { Tag.Stack, Tag.Greedy, }; }

        public override bool Test(System.Diagnostics.Stopwatch sw)
        {
            return true;
        }

        //作者：LeetCode-Solution
        //链接：https://leetcode-cn.com/problems/remove-k-digits/solution/yi-diao-kwei-shu-zi-by-leetcode-solution/

        /// <summary>
        /// 40/40 cases passed (108 ms)
        /// Your runtime beats 69.01 % of csharp submissions
        /// Your memory usage beats 39.43 % of csharp submissions(26.5 MB)
        /// </summary>
        /// <param name="num"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public string RemoveKdigits(string num, int k)
        {
            LinkedList<char> deque = new LinkedList<char>();  //Deque<Character> deque = new LinkedList<Character>(); 
            int length = num.Length;
            for (int i = 0; i < length; ++i)
            {
                char digit = num[i];
                while (deque.Count != 0 && k > 0 && deque.Last.Value > digit) //deque.peekLast() > digit //检查尾部
                {
                    deque.RemoveLast();  //deque.pollLast(); //移除尾部
                    k--;
                }
                deque.AddLast(digit); //deque.offerLast(digit); //插入尾部
            }

            for (int i = 0; i < k; ++i)
            {
                deque.RemoveLast();  // deque.pollLast();
            }

            System.Text.StringBuilder ret = new System.Text.StringBuilder();
            bool leadingZero = true;
            while (deque.Count != 0)
            {
                char digit = deque.First.Value; //char digit = deque.pollFirst();  //移除头部
                deque.RemoveFirst();
                if (leadingZero && digit == '0')
                {
                    continue;
                }
                leadingZero = false;
                ret.Append(digit);
            }
            return ret.Length == 0 ? "0" : ret.ToString();
        }
    }
}
