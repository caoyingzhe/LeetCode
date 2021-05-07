using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CSharpConsoleApp.Solutions
{
    /*
    * @lc app=leetcode.cn id=2 lang=csharp
    *
    * [2] 两数相加
    * 
    * Category	Difficulty	Likes	Dislikes
    * algorithms	Medium (39.82%)	5917	-
    * Tags
    * linked-list | math
    * 
    * Companies
    * adobe | airbnb | amazon | bloomberg | microsoft
    * 
    * 给你两个 非空 的链表，表示两个非负的整数。它们每位数字都是按照 逆序 的方式存储的，并且每个节点只能存储 一位 数字。
    * 
    * 请你将两个数相加，并以相同形式返回一个表示和的链表。
    * 
    * 你可以假设除了数字 0 之外，这两个数都不会以 0 开头。
    * 
    * 示例 1：
    * 输入：l1 = [2,4,3], l2 = [5,6,4]
    * 输出：[7,0,8]
    * 解释：342 + 465 = 807.
    * 
    * 示例 2：
    * 输入：l1 = [0], l2 = [0]
    * 输出：[0]
    * 
    * 示例 3：
    * 输入：l1 = [9,9,9,9,9,9,9], l2 = [9,9,9,9]
    * 输出：[8,9,9,9,0,0,0,1]
    * 
    * 提示：
    * 每个链表中的节点数在范围 [1, 100] 内
    * 0 <= Node.val <= 9
    * 题目数据保证列表表示的数字不含前导零
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
    public class Solution2 : SolutionBase
    {
        #region Test2 : AddTwoNumbers
        public override bool Test(System.Diagnostics.Stopwatch sw)
        {
            ListNode l1 = new ListNodeList(new int[] { 9, 9, 9, 9, 9, 9, 9 }).first;
            ListNode l2 = new ListNodeList(new int[] { 9, 9, 9, 9 }).first;

            //ListNode l1 = new ListNodeList(new int[] { 1, 2, 3, 4, 5, 6, 7 }).first;
            //ListNode l2 = new ListNodeList(new int[] { 1, 2, 3, 4 }).first;
            ListNode result = AddTwoNumbers(l1, l2);

            List<int> resultlist = new List<int>();

            ListNode node = result;
            while (node != null)
            {
                resultlist.Add(node.val);
                node = node.next;
            }
            System.Diagnostics.Debug.Print("Result = " + string.Join(",", resultlist));
            return true;
        }

        /*
         1568/1568 cases passed (128 ms)
            Your runtime beats 65 % of csharp submissions
            Your memory usage beats 98.46 % of csharp submissions (27.3 MB)
             */
        public ListNode AddTwoNumbers(ListNode l1, ListNode l2)
        {
            ListNode c1 = l1;
            ListNode c2 = l2;

            //int currentSum = c1.val + c2.val;
            //int nextAddVal = currentSum >= 10 ? 1 : 0;
            //int preAddVal = nextAddVal;
            //int currentVal = currentSum - 10 * nextAddVal;
            //
            //ListNode firstNode = new ListNode(currentVal);
            //ListNode preNode = firstNode;
            ListNode firstNode = null, preNode = null;
            int currentSum = 0;
            int nextAddVal = 0;
            int preAddVal = 0;
            int currentVal = 0;
            int currentNextValue1 = 0;
            int currentNextValue2 = 0;

            while (true)
            {
                bool isNextNull1 = (c1 == null || c1.next == null);
                bool isNextNull2 = (c2 == null || c2.next == null);
                if (isNextNull1 && isNextNull2 && preAddVal == 0)
                    break;

                currentNextValue1 = isNextNull1 ? 0 : c1.next.val;
                currentNextValue2 = isNextNull2 ? 0 : c2.next.val;

                currentSum = currentNextValue1 + currentNextValue2 + preAddVal;
                nextAddVal = currentSum >= 10 ? 1 : 0;
                currentVal = currentSum - 10 * nextAddVal;

                ListNode newNode = new ListNode(currentVal);

                if (firstNode == null)
                {
                    preNode = firstNode = newNode;
                }

                preNode.next = newNode;
                preNode = newNode;
                preAddVal = nextAddVal;

                c1 = c1 != null ? c1.next : null;
                c2 = c2 != null ? c2.next : null;
            }
            return firstNode;
        }
        #endregion
    }
}
