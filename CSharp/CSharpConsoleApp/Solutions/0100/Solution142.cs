using System;
namespace CSharpConsoleApp.Solutions
{
    /*
     * @lc app=leetcode.cn id=142 lang=csharp
     *
     * [142] 环形链表 II
     *
     * https://leetcode-cn.com/problems/linked-list-cycle-ii/description/
     *
     * Category	Difficulty	Likes	Dislikes
     * algorithms	Medium (54.82%)	1053	-
     * Tags
     * linked-list | two-pointers
     * 
     * Companies
     * Unknown
     * 
     * Total Accepted:    249.1K
     * Total Submissions: 454.2K
     * Testcase Example:  '[3,2,0,-4]\n1'
     *
     * 给定一个链表，返回链表开始入环的第一个节点。 如果链表无环，则返回 null。
     * 
     * 为了表示给定链表中的环，我们使用整数 pos 来表示链表尾连接到链表中的位置（索引从 0 开始）。 如果 pos 是
     * -1，则在该链表中没有环。注意，pos 仅仅是用于标识环的情况，并不会作为参数传递到函数中。
     * 
     * 说明：不允许修改给定的链表。
     * 
     * 进阶：
     * 
     * 
     * 你是否可以使用 O(1) 空间解决此题？
     * 
     * 
     * 
     * 
     * 示例 1：
     * 
     * 
     * 
     * 
     * 输入：head = [3,2,0,-4], pos = 1
     * 输出：返回索引为 1 的链表节点
     * 解释：链表中有一个环，其尾部连接到第二个节点。
     * 
     * 
     * 示例 2：
     * 
     * 
     * 
     * 
     * 输入：head = [1,2], pos = 0
     * 输出：返回索引为 0 的链表节点
     * 解释：链表中有一个环，其尾部连接到第一个节点。
     * 
     * 
     * 示例 3：
     * 
     * 
     * 
     * 
     * 输入：head = [1], pos = -1
     * 输出：返回 null
     * 解释：链表中没有环。
     * 
     * 
     * 
     * 
     * 提示：
     * 
     * 
     * 链表中节点的数目范围在范围 [0, 10^4] 内
     * -10^5 
     * pos 的值为 -1 或者链表中的一个有效索引
     * 
     * 
     */

    // @lc code=start
    /**
     * Definition for singly-linked list.
     * public class ListNode {
     *     public int val;
     *     public ListNode next;
     *     public ListNode(int x) {
     *         val = x;
     *         next = null;
     *     }
     * }
     */
    public class Solution142 : SolutionBase
    {
        /// <summary>
        /// 难度
        /// </summary>
        public override Difficulity GetDifficulity() { return Difficulity.Medium; }
        /// <summary>
        /// 关键字:
        /// </summary>
        public override string[] GetKeyWords() { return new string[] { "快慢指针相遇法" }; }
        /// <summary>
        /// 标签：
        /// </summary>
        public override Tag[] GetTags() { return new Tag[] { Tag.LinkedList, Tag.TwoPointers }; }

        
        public override bool Test(System.Diagnostics.Stopwatch sw)
        {
            bool isSuccess = true;

            ListNodeList list = new ListNodeList(new int[] { 2, 3, 4, 5 });
            isSuccess &= DetectCycle(list.first) == null;
            PrintResult(isSuccess, "null", "null");

            list.first.next.next.next.next = list.first.next;
            isSuccess &= DetectCycle(list.first) == list.first.next;
            PrintResult(isSuccess, list.first.next.val, "3");
            return isSuccess;
        }

        /// <summary>
        /// 作者：LeetCode-Solution
        /// 链接：https://leetcode-cn.com/problems/linked-list-cycle-ii/solution/huan-xing-lian-biao-ii-by-leetcode-solution/
        /// 16/16 cases passed (104 ms)
        /// Your runtime beats 98 % of csharp submissions
        /// Your memory usage beats 57.33 % of csharp submissions(25.8 MB)
        /// </summary>
        /// <param name="head"></param>
        /// <returns></returns>
        public ListNode DetectCycle(ListNode head)
        {
            if (head == null) return null;

            ListNode slow = head, fast = head;

            //循环终止条件：快指针 == null
            while (fast != null)
            {
                slow = slow.next;
                if (fast.next != null)
                {
                    fast = fast.next.next;
                }
                else
                {
                    return null;
                }

                //快慢指针相遇，确定链表有环，
                //为了确定入口位置，需要将慢指针置为链表头，重新再跑一边，直至相遇。相遇即为入口处。
                if (fast == slow)
                {
                    ListNode ptr = head;
                    while (ptr != slow)
                    {
                        ptr = ptr.next;
                        slow = slow.next;
                    }
                    return ptr;
                }
            }
            return null;
        }
    }
    // @lc code=end
}
