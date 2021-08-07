using System;
namespace CSharpConsoleApp.Solutions
{
    /*
     * @lc app=leetcode.cn id=148 lang=csharp
     *
     * [148] 排序链表
     *
     * https://leetcode-cn.com/problems/sort-list/description/
     *
     * Category	Difficulty	Likes	Dislikes
     * algorithms	Medium (66.79%)	1203	-
     * Tags
     * linked-list | sort
     * 
     * Companies
     * Unknown
     * 
     * Total Accepted:    181.5K
     * Total Submissions: 271.7K
     * Testcase Example:  '[4,2,1,3]'
     *
     * 给你链表的头结点 head ，请将其按 升序 排列并返回 排序后的链表 。
     * 
     * 进阶：
     * 你可以在 O(n log n) 时间复杂度和常数级空间复杂度下，对链表进行排序吗？
     * 
     * 
     * 示例 1：
     * 输入：head = [4,2,1,3]
     * 输出：[1,2,3,4]
     * 
     * 
     * 示例 2：
     * 输入：head = [-1,5,3,4,0]
     * 输出：[-1,0,3,4,5]
     * 
     * 
     * 示例 3：
     * 输入：head = []
     * 输出：[]
     * 
     * 
     * 提示：
     * 链表中节点的数目在范围 [0, 5 * 10^4] 内
     * -10^5 <= Node.val <= 10^5
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
    public class Solution148 : SolutionBase
    {
        /// <summary>
        /// 难度
        /// </summary>
        public override Difficulity GetDifficulity() { return Difficulity.Medium; }
        /// <summary>
        /// 关键字:
        /// </summary>
        public override string[] GetKeyWords() { return new string[] { "", }; }
        /// <summary>
        /// 标签：
        /// </summary>
        public override Tag[] GetTags() { return new Tag[] { Tag.LinkedList, Tag.Sort }; }


        public override bool Test(System.Diagnostics.Stopwatch sw)
        {
            bool isSuccess = true;
            ListNode n;
            ListNode result, checkResult;

            ListNodeList list = new ListNodeList(new int[] { 4, 2, 1, 3 });
            n = list.first;
            checkResult = new ListNodeList(new int[] { 1, 2, 3, 4 }).first;
            result = SortList(n);
            isSuccess &= IsSame(result, checkResult);
            PrintResult(isSuccess, (result).ToString(), (checkResult).ToString());

            return isSuccess;
        }

        //作者：LeetCode-Solution
        //链接：https://leetcode-cn.com/problems/sort-list/solution/pai-xu-lian-biao-by-leetcode-solution/
        public ListNode SortList(ListNode head)
        {
            if (head == null)
            {
                return head;
            }
            int length = 0;
            ListNode node = head;
            while (node != null)
            {
                length++;
                node = node.next;
            }
            ListNode dummyHead = new ListNode(0, head);
            for (int subLength = 1; subLength < length; subLength <<= 1)
            {
                ListNode prev = dummyHead, curr = dummyHead.next;
                while (curr != null)
                {
                    ListNode head1 = curr;
                    for (int i = 1; i < subLength && curr.next != null; i++)
                    {
                        curr = curr.next;
                    }
                    ListNode head2 = curr.next;
                    curr.next = null;
                    curr = head2;
                    for (int i = 1; i < subLength && curr != null && curr.next != null; i++)
                    {
                        curr = curr.next;
                    }
                    ListNode next = null;
                    if (curr != null)
                    {
                        next = curr.next;
                        curr.next = null;
                    }
                    ListNode merged = Merge(head1, head2);
                    prev.next = merged;
                    while (prev.next != null)
                    {
                        prev = prev.next;
                    }
                    curr = next;
                }
            }
            return dummyHead.next;
        }

        public ListNode Merge(ListNode head1, ListNode head2)
        {
            ListNode dummyHead = new ListNode(0);
            ListNode temp = dummyHead, temp1 = head1, temp2 = head2;
            while (temp1 != null && temp2 != null)
            {
                if (temp1.val <= temp2.val)
                {
                    temp.next = temp1;
                    temp1 = temp1.next;
                }
                else
                {
                    temp.next = temp2;
                    temp2 = temp2.next;
                }
                temp = temp.next;
            }
            if (temp1 != null)
            {
                temp.next = temp1;
            }
            else if (temp2 != null)
            {
                temp.next = temp2;
            }
            return dummyHead.next;
        }
    }
}
