using System;
namespace CSharpConsoleApp.Solutions
{
    /*
     * @lc app=leetcode.cn id=725 lang=csharp
     *
     * [725] 分隔链表
     *
     * https://leetcode-cn.com/problems/split-linked-list-in-parts/description/
     *
     * Category	Difficulty	Likes	Dislikes
     * algorithms	Medium (56.18%)	144	-
     * Tags
     * linked-list
     * 
     * Companies
     * amazon
     * Total Accepted:    22K
     * Total Submissions: 39.1K
     * Testcase Example:  '[1,2,3]\n5'
     *
     * 给定一个头结点为 root 的链表, 编写一个函数以将链表分隔为 k 个连续的部分。
     * 每部分的长度应该尽可能的相等: 任意两部分的长度差距不能超过 1，也就是说可能有些部分为 null。
     * 这k个部分应该按照在链表中出现的顺序进行输出，并且排在前面的部分的长度应该大于或等于后面的长度。
     * 返回一个符合上述规则的链表的列表。
     *
     * 举例： 1->2->3->4, k = 5 // 5 结果 [ [1], [2], [3], [4], null ]
     * 
     * 示例 1：
     * 输入: 
     * root = [1, 2, 3], k = 5
     * 输出: [[1],[2],[3],[],[]]
     * 解释:
     * 输入输出各部分都应该是链表，而不是数组。
     * 例如, 输入的结点 root 的 val= 1, root.next.val = 2, \root.next.next.val = 3, 且
     * root.next.next.next = null。
     * 第一个输出 output[0] 是 output[0].val = 1, output[0].next = null。
     * 最后一个元素 output[4] 为 null, 它代表了最后一个部分为空链表。
     * 
     * 
     * 示例 2：
     * 输入: 
     * root = [1, 2, 3, 4, 5, 6, 7, 8, 9, 10], k = 3
     * 输出: [[1, 2, 3, 4], [5, 6, 7], [8, 9, 10]]
     * 解释:
     * 输入被分成了几个连续的部分，并且每部分的长度相差不超过1.前面部分的长度大于等于后面部分的长度。
     *
     * 
     * 提示:
     * root 的长度范围： [0, 1000].
     * 输入的每个节点的大小范围：[0, 999].
     * k 的取值范围： [1, 50].
     */

    // @lc code=start
    /**
     * Definition for singly-linked list.
     * public class ListNode {
     *     public int val;
     *     public ListNode next;
     *     public ListNode(int val=0, ListNode next=null) {
     *         this.val = val;
     *         this.next = next;
     *     }
     * }
     */
    public class Solution725 : SolutionBase
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
        public override Tag[] GetTags() { return new Tag[] { Tag.Tree }; }

        public const int N = int.MinValue;
        /// <summary>
        /// </summary>
        /// <param name="sw"></param>
        /// <returns></returns>
        public override bool Test(System.Diagnostics.Stopwatch sw)
        {
            bool isSuccess = true;
            return isSuccess;
        }

        //作者：LeetCode
        //链接：https://leetcode-cn.com/problems/split-linked-list-in-parts/solution/fen-ge-lian-biao-by-leetcode-2/
        /// <summary>
        /// 43/43 cases passed (272 ms)
        /// Your runtime beats 78.57 % of csharp submissions
        /// Your memory usage beats 7.14 % of csharp submissions(31.7 MB)
        /// </summary>
        /// <param name="root"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public ListNode[] SplitListToParts1(ListNode root, int k)
        {
            ListNode cur = root;
            //计算链表的长度
            int N = 0;
            while (cur != null)
            {
                cur = cur.next;
                N++;
            }
            //求出链表的最少长度，余数
            int width = N / k, rem = N % k;

            ListNode[] ans = new ListNode[k];
            cur = root;
            for (int i = 0; i < k; ++i)
            {
                ListNode head = new ListNode(0), write = head;
                for (int j = 0; j < width + (i < rem ? 1 : 0); ++j)
                {
                    write = write.next = new ListNode(cur.val);
                    if (cur != null) cur = cur.next;
                }
                ans[i] = head.next;
            }
            return ans;
        }
        /// <summary>
        /// 43/43 cases passed (280 ms)
        /// Your runtime beats 42.86 % of csharp submissions
        /// Your memory usage beats 50 % of csharp submissions(31 MB)
        /// </summary>
        /// <param name="root"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public ListNode[] SplitListToParts(ListNode root, int k)
        {
            ListNode cur = root;
            int N = 0;
            while (cur != null)
            {
                cur = cur.next;
                N++;
            }

            int width = N / k, rem = N % k;

            ListNode[] ans = new ListNode[k];
            cur = root;
            for (int i = 0; i < k; ++i)
            {
                ListNode head = cur;
                for (int j = 0; j < width + (i < rem ? 1 : 0) - 1; ++j)
                {
                    if (cur != null) cur = cur.next;
                }
                if (cur != null)
                {
                    ListNode prev = cur;
                    cur = cur.next;
                    prev.next = null;
                }
                ans[i] = head;
            }
            return ans;
        }
    }
    // @lc code=end


}
