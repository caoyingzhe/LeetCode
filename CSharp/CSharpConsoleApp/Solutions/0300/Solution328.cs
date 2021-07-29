using System;
namespace CSharpConsoleApp.Solutions
{
    /*
     * @lc app=leetcode.cn id=328 lang=csharp
     *
     * [328] 奇偶链表
     *
     * https://leetcode-cn.com/problems/odd-even-linked-list/description/
     *
     * Category	Difficulty	Likes	Dislikes
     * algorithms	Medium (65.67%)	442	-
     * Tags
     * linked-list
     * 
     * Companies
     * Unknown
     * 
     * Total Accepted:    117.2K
     * Total Submissions: 178.4K
     * Testcase Example:  '[1,2,3,4,5]'
     *
     * 给定一个单链表，把所有的奇数节点和偶数节点分别排在一起。请注意，这里的奇数节点和偶数节点指的是节点编号的奇偶性，而不是节点的值的奇偶性。
     * 
     * 请尝试使用原地算法完成。你的算法的空间复杂度应为 O(1)，时间复杂度应为 O(nodes)，nodes 为节点总数。
     * 
     * 示例 1:
     * 输入: 1->2->3->4->5->NULL
     * 输出: 1->3->5->2->4->NULL
     * 
     * 
     * 示例 2:
     * 输入: 2->1->3->5->6->4->7->NULL 
     * 输出: 2->3->6->7->1->5->4->NULL
     * 
     * 说明:
     * 应当保持奇数节点和偶数节点的相对顺序。
     * 链表的第一个节点视为奇数节点，第二个节点视为偶数节点，以此类推。
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
    public class Solution328 : SolutionBase
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
        public override Tag[] GetTags() { return new Tag[] { Tag.LinkedList}; }

        
        public override bool Test(System.Diagnostics.Stopwatch sw)
        {
            bool isSuccess = true;

            ListNode head;
            ListNodeList list;
            ListNode result, checkResult;

            list = new ListNodeList(new int[] { 1, 2, 5 });
            head = list.first;

            checkResult = new ListNodeList(new int[] { 1, 5, 2 }).first;
            result = OddEvenList(head);
            isSuccess &= IsSame(result, checkResult);
            PrintResult(isSuccess, (result).ToString(), (checkResult).ToString());

            return isSuccess;
        }

        /// <summary>
        /// 需要维护3个指针，所以空间复杂度为 O(1)。
        /// 1. 偶数链表的头节点
        /// 2. 奇数头节点
        /// 3. 偶数头节点
        /// 作者：sui - ji - guo - cheng - sui - ji - guo
        /// 链接：https://leetcode-cn.com/problems/odd-even-linked-list/solution/qi-ou-lian-biao-java-by-sui-ji-guo-cheng-00i1/
        ///
        /// 70/70 cases passed (92 ms)
        /// Your runtime beats 97.01 % of csharp submissions
        /// Your memory usage beats 86.57 % of csharp submissions(25.4 MB)
        /// </summary>
        /// <param name="head"></param>
        /// <returns></returns>
        public ListNode OddEvenList(ListNode head)
        {
            if (head == null) return head;

            // 偶数链表的头节点
            ListNode evenHead = head.next;
            // 两个指针指向奇数节点和偶数节点
            ListNode odd = head, even = evenHead;

            while (even != null && even.next != null)
            {
                // 将奇数节点的下一个节点指向下一个奇数节点
                odd.next = even.next;
                // 将奇数节点向后移动
                odd = odd.next;
                // 偶数节点的处理方法相同
                even.next = odd.next;
                even = even.next;
            }
            odd.next = evenHead;
            return head;
        }
    }
    // @lc code=end


}
