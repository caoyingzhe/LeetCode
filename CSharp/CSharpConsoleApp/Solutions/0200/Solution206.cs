using System;
using System.Collections.Generic;

namespace CSharpConsoleApp.Solutions
{
    /*
     * @lc app=leetcode.cn id=206 lang=csharp
     *
     * [206] 反转链表
     *
     * https://leetcode-cn.com/problems/reverse-linked-list/description/
     *
     * Category	Difficulty	Likes	Dislikes
     * algorithms	Easy (71.75%)	1784	-
     * Tags
     * linked-list
     * 
     * Companies
     * adobe | amazon | apple | bloomberg | facebook | microsoft | snapchat | twitter | uber | yahoo | yelp | zenefits
     * 
     * Total Accepted:    569.6K
     * Total Submissions: 793.9K
     * Testcase Example:  '[1,2,3,4,5]' 
     * 给你单链表的头节点 head ，请你反转链表，并返回反转后的链表。
     * 
     * 示例 1：
     * 输入：head = [1,2,3,4,5]
     * 输出：[5,4,3,2,1]
     * 
     * 示例 2：
     * 输入：head = [1,2]
     * 输出：[2,1]
     * 
     * 示例 3：
     * 输入：head = []
     * 输出：[]
     * 
     * 提示：
     * 链表中节点的数目范围是 [0, 5000]
     * -5000 
     * 进阶：链表可以选用迭代或递归方式完成反转。你能否用两种方法解决这道题？
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
    public class Solution206 : SolutionBase
    {
        /// <summary>
        /// 难度
        /// </summary>
        public override Difficulity GetDifficulity() { return Difficulity.Easy; }
        /// <summary>
        /// 关键字:
        /// </summary>
        public override string[] GetKeyWords() { return new string[] { }; }
        /// <summary>
        /// 标签：
        /// </summary>
        public override Tag[] GetTags() { return new Tag[] { Tag.Array }; }

        public override bool Test(System.Diagnostics.Stopwatch sw)
        {
            bool isSuccess = true;
            ListNode points, result, checkResult;

            points = new ListNode(new int[] { 1,2,3,4,5 });
            checkResult = new ListNode(new int[] { 5,4,3,2,1 });
            result = ReverseList(points);
            isSuccess &= IsListSame(result.GetValueList(), checkResult.GetValueList());
            Print("isSuccess = {0} | result = {1} | anticipated = {2}", isSuccess, GetArrayStr(result.GetValueList()), GetArrayStr(checkResult.GetValueList()));

            return isSuccess;
        }

        /// <summary>
        /// 28/28 cases passed (104 ms)
        /// Your runtime beats 88.67 % of csharp submissions
        /// Your memory usage beats 32.18 % of csharp submissions(24.6 MB)
        /// </summary>
        /// <param name="head"></param>
        /// <returns></returns>
        public ListNode ReverseList(ListNode head)
        {
            var list = GetValueList(head);
            list.Reverse();

            ListNode node = head;
            foreach(int val in list)
            {
                node.val = val;
                node = node.next;
            }
            return head;
        }

        public List<int> GetValueList(ListNode head)
        {
            List<int> list = new List<int>();

            ListNode node = head;
            while (node != null)
            {
                list.Add(node.val);
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
