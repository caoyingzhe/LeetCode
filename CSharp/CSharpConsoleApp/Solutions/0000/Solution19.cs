using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpConsoleApp.Solutions._0000
{
    /*
     * @lc app=leetcode.cn id=19 lang=csharp
     *
     * [19] 删除链表的倒数第 N 个结点
     *
     * https://leetcode-cn.com/problems/remove-nth-node-from-end-of-list/description/
     *
     * Category	Difficulty	Likes	Dislikes
     * algorithms	Medium (41.71%)	1351	-
     * Tags
     * linked-list | two-pointers
     * 
     * Companies
     * Unknown
     * 
     * Total Accepted:    383.4K
     * Total Submissions: 918.4K
     * Testcase Example:  '[1,2,3,4,5]\n2'
     *
     * 给你一个链表，删除链表的倒数第 n 个结点，并且返回链表的头结点。
     * 
     * 进阶：你能尝试使用一趟扫描实现吗？
     * 
     * 示例 1：
     * 输入：head = [1,2,3,4,5], n = 2
     * 输出：[1,2,3,5]
     * 
     * 示例 2：
     * 输入：head = [1], n = 1
     * 输出：[]
     * 
     * 示例 3：
     * 输入：head = [1,2], n = 1
     * 输出：[1]
     * 
     * 提示：
     * 链表中结点的数目为 sz
     * 1 <= sz <= 30
     * 0 <= Node.val <= 100
     * 1 <= n <= sz
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
    class Solution19 : SolutionBase
    {
        public override bool Test(System.Diagnostics.Stopwatch sw)
        {
            return true;
        }
        /// <summary>
        /// 作者：LeetCode-Solution
        /// 链接：https://leetcode-cn.com/problems/remove-nth-node-from-end-of-list/solution/shan-chu-lian-biao-de-dao-shu-di-nge-jie-dian-b-61/
        /// </summary>
        /// <param name="head"></param>
        /// <param name="n"></param>
        /// <returns></returns>
        public ListNode RemoveNthFromEnd_Common(ListNode head, int n)
        {
            ListNode dummy = new ListNode(0, head);
            int length = GetLength(head);
            ListNode cur = dummy;
            for (int i = 1; i < length - n + 1; ++i)
            {
                cur = cur.next;
            }
            cur.next = cur.next.next;
            ListNode ans = dummy.next;
            return ans;
        }

        public int GetLength(ListNode head)
        {
            int length = 0;
            while (head != null)
            {
                ++length;
                head = head.next;
            }
            return length;
        }

        /// <summary>
        /// 方法二：栈
        /// </summary>
        /// <param name="head"></param>
        /// <param name="n"></param>
        /// <returns></returns>
        public ListNode RemoveNthFromEnd(ListNode head, int n)
        {
            ListNode dummy = new ListNode(0, head);
            Stack<ListNode> stack = new Stack<ListNode>();
            ListNode cur = dummy;
            while (cur != null)         //连同哑节点一起压栈了（数量= n+1)
            {
                stack.Push(cur);
                cur = cur.next;
            }
            ListNode deleteNode = null;
            for (int i = 0; i < n; ++i)  //Pop节点，直到倒数第n个停止。
            {
                deleteNode = stack.Pop();
            }
            //ListNode prev = stack.Pop();//prev是删除节点的前一个节点 Pop()和Peek()结果一样
            ListNode prev = stack.Peek();//prev是删除节点的前一个节点 Pop()和Peek()结果一样
            prev.next = prev.next.next;  //链接删除节点前一个和后一个
            ListNode ans = dummy.next;   //哑节点的next即Head节点
            return ans;
        }
        
    }
}
