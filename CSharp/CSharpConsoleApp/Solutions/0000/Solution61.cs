using System;
using System.Collections.Generic;
namespace CSharpConsoleApp.Solutions
{
    /*
     * @lc app=leetcode.cn id=61 lang=csharp
     *
     * [61] 旋转链表
     *
     * https://leetcode-cn.com/problems/rotate-list/description/
     *
     * Category	Difficulty	Likes	Dislikes
     * algorithms	Medium (41.80%)	570	-
     * Tags
     * linked-list | two-pointers
     * 
     * Companies
     * Unknown
     * 
     * Total Accepted:    170.7K
     * Total Submissions: 408.5K
     * Testcase Example:  '[1,2,3,4,5]\n2'
     *
     * 给你一个链表的头节点 head ，旋转链表，将链表每个节点向右移动 k 个位置。
     * 
     * 
     * 示例 1：
     * 输入：head = [1,2,3,4,5], k = 2
     * 输出：[4,5,1,2,3]
     * 
     * 示例 2：
     * 输入：head = [0,1,2], k = 4
     * 输出：[2,0,1]
     * 
     * 提示：
     * 链表中节点的数目在范围 [0, 500] 内
     * -100 <= Node.val <= 100
     * 0 <= k <= 2 * 10^9
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
    public class Solution61 : SolutionBase
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
        public override Tag[] GetTags() { return new Tag[] { Tag.LinkedList, Tag.TwoPointers }; }

        public override bool Test(System.Diagnostics.Stopwatch sw)
        {
            bool isSuccess = true;

            ListNode head; ListNode result; int k;

            head = new ListNode(new int[] { 1,2,3,4,5});
            k = 6;

            result = RotateRight(head, k);
            Print(GetArrayStr((result).GetValueList()));
            return isSuccess;
        }

        /// <summary>
        /// 231/231 cases passed (120 ms)
        /// Your runtime beats 20.9 % of csharp submissions
        /// Your memory usage beats 13.28 % of csharp submissions(25.5 MB)
        /// </summary>
        /// <param name="head"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public ListNode RotateRight(ListNode head, int k)
        {
            if (head == null || head.next == null)
                return head;

            List<ListNode> list = GetValueList(head);
            int n = list.Count;
            k %= n;
            if (k % n == 0)
                return head;
                
            ListNode newHead = list[(n - k)];
            ListNode newTail = list[(n - k - 1)];
            list[n - 1].next = list[0];
            newTail.next = null;
            return newHead;
        }

        public List<ListNode> GetValueList(ListNode head)
        {
            List<ListNode> list = new List<ListNode>();

            ListNode node = head;
            while (node != null)
            {
                list.Add(node);
                if (node == node.next)
                {
                    //Warning
                    break;
                }
                node = node.next;
            }
            return list;
        }
    }
}
