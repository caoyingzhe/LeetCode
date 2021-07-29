using System;
using System.Collections.Generic;
namespace CSharpConsoleApp.Solutions
{
    /*
     * @lc app=leetcode.cn id=143 lang=csharp
     *
     * [143] 重排链表
     *
     * https://leetcode-cn.com/problems/reorder-list/description/
     *
     * Category	Difficulty	Likes	Dislikes
     * algorithms	Medium (60.93%)	610	-
     * Tags
     * linked-list
     * 
     * Companies
     * Unknown
     * 
     * Total Accepted:    105.1K
     * Total Submissions: 172.4K
     * Testcase Example:  '[1,2,3,4]'
     *
     * 给定一个单链表 L：L0→L1→…→Ln-1→Ln ，
     * 将其重新排列后变为： L0→Ln→L1→Ln-1→L2→Ln-2→…
     * 
     * 你不能只是单纯的改变节点内部的值，而是需要实际的进行节点交换。
     * 
     * 示例 1:
     * 
     * 给定链表 1->2->3->4, 重新排列为 1->4->2->3.
     * 
     * 示例 2:
     * 
     * 给定链表 1->2->3->4->5, 重新排列为 1->5->2->4->3.
     * 
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
    public class Solution143 : SolutionBase
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
        public override Tag[] GetTags() { return new Tag[] { Tag.LinkedList }; }

        
        public override bool Test(System.Diagnostics.Stopwatch sw)
        {
            bool isSuccess = true;
            string result, checkResult;

            ListNodeList list = new ListNodeList(new int[] { 1, 2, 3, 4, 5 });
            checkResult = GetArrayStr(new int[] { 1, 5, 2, 4, 3 });
            ReorderList(list.first);
            result = list.first.ToString(",");
            isSuccess &= IsSame(result, checkResult);
            PrintResult(isSuccess, result, checkResult);

            list = new ListNodeList(new int[] { 1, 2, 3, 4 });
            checkResult = GetArrayStr(new int[] { 1, 4, 2, 3 });
            ReorderList(list.first);
            result = list.first.ToString(",");
            isSuccess &= IsSame(result, checkResult);
            PrintResult(isSuccess, result, checkResult);

            return isSuccess;
        }


        /// <summary>
        /// 作者：venturekwok
        /// 链接：https://leetcode-cn.com/problems/reorder-list/solution/java-si-lu-hao-li-jie-shi-pin-jiang-jie-zhan-de-yi/
        /// 12/12 cases passed (96 ms)
        /// Your runtime beats 100 % of csharp submissions
        /// Your memory usage beats 75.61 % of csharp submissions(29.8 MB)
        /// </summary>
        /// <param name="head"></param>
        public void ReorderList(ListNode head)
        {
            if (head == null) return;

            LinkedList<ListNode> stack = new LinkedList<ListNode>();
            ListNode cur = head;
            while (cur != null)
            {
                stack.AddLast(cur);
                cur = cur.next;
            }

            cur = head;
            ListNode stack_cur = new ListNode(int.MaxValue);

            while (cur.next != stack_cur.next)
            {
                //stack_cur = stack.poll();    //Java
                stack_cur = stack.Last.Value;  
                stack.RemoveLast();

                stack_cur.next = cur.next;
                cur.next = stack_cur;

                cur = cur.next.next;
            }
            stack_cur.next = null;      //to avoid the cycle
        }
    }
    // @lc code=end


}
