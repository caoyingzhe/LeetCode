using System;
using System.Collections.Generic;
namespace CSharpConsoleApp.Solutions
{
    /*
     * @lc app=leetcode.cn id=82 lang=csharp
     *
     * [82] 删除排序链表中的重复元素 II
     *
     * https://leetcode-cn.com/problems/remove-duplicates-from-sorted-list-ii/description/
     *
     * Category	Difficulty	Likes	Dislikes
     * algorithms	Medium (52.40%)	639	-
     * Tags
     * linked-list
     * 
     * Companies
     * Unknown
     * 
     * Total Accepted:    146.5K
     * Total Submissions: 279.6K
     * Testcase Example:  '[1,2,3,3,4,4,5]'
     *
     * 存在一个按升序排列的链表，给你这个链表的头节点 head ，请你删除链表中所有存在数字重复情况的节点，只保留原始链表中 没有重复出现 的数字。
     * 返回同样按升序排列的结果链表。
     * 
     * 
     * 示例 1：
     * 输入：head = [1,2,3,3,4,4,5]
     * 输出：[1,2,5]
     * 
     * 
     * 示例 2：
     * 输入：head = [1,1,1,2,3]
     * 输出：[2,3]
     *
     * 
     * 提示：
     * 链表中节点数目在范围 [0, 300] 内
     * -100 <= Node.val <= 100
     * 题目数据保证链表已经按升序排列
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
    public class Solution82 : SolutionBase
    {
        /// <summary>
        /// 难易度:
        /// </summary>
        public override Difficulity GetDifficulity() { return Difficulity.Medium; }
        /// <summary>
        /// 关键字:
        /// </summary>
        public override string[] GetKeyWords() { return new string[] { }; }
        /// <summary>
        /// 标签： 图
        /// </summary>
        public override Tag[] GetTags() { return new Tag[] { Tag.LinkedList }; }

        /// <summary>
        /// 195/195 cases passed (104 ms)
        /// Your runtime beats 89.9 % of csharp submissions
        /// Your memory usage beats 95.45 % of csharp submissions(24.5 MB)
        /// </summary>
        /// <param name="sw"></param>
        /// <returns></returns>
        public override bool Test(System.Diagnostics.Stopwatch sw)
        {
            bool isSuccess = true;
            ListNodeList list;
            ListNode result, checkResult;

            //list = new ListNodeList(new int[] { 1, 1, 1, 2, 3 });
            //checkResult = list.list.Find(a => a.val == 2);
            //result = DeleteDuplicates(list.first);
            //isSuccess &= result == checkResult;
            //Print("isSuccess = {0} result = {1} | checkResult = {2}", isSuccess, (result), (checkResult));

            //list = new ListNodeList(new int[] { 1, 1 });
            //checkResult = null;
            //result = DeleteDuplicates(list.first);
            //isSuccess &= result == checkResult;
            //Print("isSuccess = {0} result = {1} | checkResult = {2}", isSuccess, (result), (checkResult));

            //ListNode nullNode = null;
            //checkResult = null;
            //result = DeleteDuplicates(nullNode);
            //isSuccess &= result == checkResult;
            //Print("isSuccess = {0} result = {1} | checkResult = {2}", isSuccess, (result), (checkResult));

            //1,2,3,3,4,4,5
            list = new ListNodeList(new int[] { 1, 2, 3, 3, 4, 4, 5 });
            checkResult = list.list.Find(a => a.val == 1); ;
            result = DeleteDuplicates(list.first);
            isSuccess &= result == checkResult;
            Print("isSuccess = {0} result = {1} | checkResult = {2}", isSuccess, (result), (checkResult));

            return isSuccess;
        }
        /// <summary>
        /// 166/166 cases passed (112 ms)
        /// Your runtime beats 61.94 % of csharp submissions
        /// Your memory usage beats 43.61 % of csharp submissions(25.8 MB)
        /// </summary>
        /// <param name="head"></param>
        /// <returns></returns>
        public ListNode DeleteDuplicates(ListNode head)
        {
            List<ListNode> list = GetValueList(head);

            //int preVal = list[list.Count - 1].val;
            bool remove = false;
            for (int i = list.Count - 1; i >= 0; i--)
            {
                if (i > 0)
                {
                    if (list[i - 1].val == list[i].val)
                    {
                        remove = true;
                        list.RemoveAt(i);
                    }
                    else
                    {
                        if (remove)
                        {
                            remove = false;
                            list.RemoveAt(i);
                        }
                    }
                }
                else
                {
                    if (remove)
                    {
                        list.RemoveAt(i);
                    }
                }
            }
            for (int i = 0; i < list.Count; i++)
            {
                if (i >= list.Count - 1)
                    list[i].next = null;
                else
                    list[i].next = list[i + 1];
            }
            return list.Count == 0 ? null : list[0];
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
    // @lc code=end


}
