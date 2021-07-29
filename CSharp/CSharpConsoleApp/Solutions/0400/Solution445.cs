using System;
using System.Collections.Generic;
namespace CSharpConsoleApp.Solutions
{
    /*
     * @lc app=leetcode.cn id=445 lang=csharp
     *
     * [445] 两数相加 II
     *
     * https://leetcode-cn.com/problems/add-two-numbers-ii/description/
     *
     * Category	Difficulty	Likes	Dislikes
     * algorithms	Medium (58.49%)	402	-
     * Tags
     * linked-list
     * 
     * Companies
     * bloomberg | microsoft
     * 
     * Total Accepted:    74.1K
     * Total Submissions: 126.6K
     * Testcase Example:  '[7,2,4,3]\n[5,6,4]'
     *
     * 给你两个 非空 链表来代表两个非负整数。数字最高位位于链表开始位置。它们的每个节点只存储一位数字。将这两数相加会返回一个新的链表。
     * 你可以假设除了数字 0 之外，这两个数字都不会以零开头。
     * 
     * 
     * 进阶：
     * 如果输入链表不能修改该如何处理？换句话说，你不能对列表中的节点进行翻转。
     * 
     * 
     * 示例：
     * 输入：(7 -> 2 -> 4 -> 3) + (5 -> 6 -> 4)
     * 输出：7 -> 8 -> 0 -> 7
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
    public class Solution445 : SolutionBase
    {
        /// <summary>
        /// 难度
        /// </summary>
        public override Difficulity GetDifficulity() { return Difficulity.Medium; }
        /// <summary>
        /// 关键字:
        /// </summary>
        public override string[] GetKeyWords() { return new string[] {  }; }
        /// <summary>
        /// 标签：
        /// </summary>
        public override Tag[] GetTags() { return new Tag[] { Tag.LinkedList, Tag.Stack  }; }

        
        /// <summary>
        /// </summary>
        /// <param name="sw"></param>
        /// <returns></returns>
        public override bool Test(System.Diagnostics.Stopwatch sw)
        {
            bool isSuccess = true;

            ListNode l1, l2;
            ListNode result; IList<int> checkResult;
            ListNodeList list1 = new ListNodeList(new int[] { 4, 3, 2, 1, 0 });
            ListNodeList list2 = new ListNodeList(new int[] { 5, 6, 7, 8, 9 });
            l1 = list1.first;
            l2 = list2.first;

            checkResult = new int[] { 9, 9, 9, 9, 9 };
            result = AddTwoNumbers(l1, l2);
            isSuccess &= IsListSame(result.GetValueList(), checkResult);
            PrintResult(isSuccess, GetArrayStr(result.GetValueList()), GetArrayStr(checkResult));

            return isSuccess;
        }

        /// <summary>
        /// 双栈法
        /// 1563/1563 cases passed (96 ms)
        /// Your runtime beats 100 % of csharp submissions
        /// Your memory usage beats 83.33 % of csharp submissions(27.4 MB)
        ///
        /// 使用双栈存储每个位数的值
        /// 链表中数位的顺序与我们做加法的顺序是相反的，为了逆序处理所有数位，我们可以使用栈：
        ///
        /// 作者：LeetCode - Solution
        /// 链接：https://leetcode-cn.com/problems/add-two-numbers-ii/solution/liang-shu-xiang-jia-ii-by-leetcode-solution/
        /// 
        /// </summary>
        /// <param name="l1"></param>
        /// <param name="l2"></param>
        /// <returns></returns>
        public ListNode AddTwoNumbers(ListNode l1, ListNode l2)
        {
            Stack<int> stack1 = new Stack<int>();
            Stack<int> stack2 = new Stack<int>();
            while (l1 != null)
            {
                stack1.Push(l1.val); l1 = l1.next;
            }
            while (l2 != null)
            {
                stack2.Push(l2.val); l2 = l2.next;
            }

            int carry = 0; //两数和的进位
            ListNode ans = null;
            while (stack1.Count != 0 || stack2.Count != 0 || carry != 0)
            {
                int a = stack1.Count == 0 ? 0 : stack1.Pop();
                int b = stack2.Count == 0 ? 0 : stack2.Pop();
                int cur = a + b + carry;
                carry = cur / 10;
                cur %= 10;
                ListNode curnode = new ListNode(cur);
                curnode.next = ans;
                ans = curnode;
            }
            return ans;
        }
    }
    // @lc code=end


}
