using System;
using System.Collections.Generic;
namespace CSharpConsoleApp.Solutions
{
    /*
     * @lc app=leetcode.cn id=92 lang=csharp
     *
     * [92] 反转链表 II
     *
     * https://leetcode-cn.com/problems/reverse-linked-list-ii/description/
     *
     * algorithms
     * Medium (54.31%)
     * Likes:    939
     * Dislikes: 0
     * Total Accepted:    177.4K
     * Total Submissions: 326.6K
     * Testcase Example:  '[1,2,3,4,5]\n2\n4'
     *
     * 给你单链表的头指针 head 和两个整数 left 和 right ，其中 left  。请你反转从位置 left 到位置 right 的链表节点，返回
     * 反转后的链表 。
     * 
     * 
     * 示例 1：
     * 输入：head = [1,2,3,4,5], left = 2, right = 4
     * 输出：[1,4,3,2,5]
     * 
     * 
     * 示例 2：
     * 输入：head = [5], left = 1, right = 1
     * 输出：[5]
     * 
     * 
     * 提示：
     * 链表中节点数目为 n
     * 1 <= n <= 500
     * -500 <= Node.val <= 500
     * 1 <= left <= right <= n
     * 
     * 
     * 进阶： 你可以使用一趟扫描完成反转吗？
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
    public class Solution92 : SolutionBase
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
        public override Tag[] GetTags() { return new Tag[] { Tag.LinkedList, Tag.TwoPointers }; }

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
            ListNodeList list; ListNode resultNode;
            int left, right;
            int[] result, checkResult;

            //1,2,3,3,4,4,5
            list = new ListNodeList(new int[] { 1, 2, 3, 4, 5 });
            left = 2; right = 4;
            checkResult = new int[] { 1, 4, 3, 2, 5 };
            resultNode = ReverseBetween(list.first, left, right);
            result = resultNode.GetValueList().ToArray();
            isSuccess &= IsArraySame(result, checkResult);
            Print("isSuccess = {0} result = {1} | checkResult = {2}", isSuccess, GetArrayStr(result), GetArrayStr(checkResult));

            list = new ListNodeList(new int[] { 1, 2, 3, 4, 5, 6 });
            left = 2; right = 5;
            checkResult = new int[] { 1, 5, 4, 3, 2, 6 };
            resultNode = ReverseBetween(list.first, left, right);
            result = resultNode.GetValueList().ToArray();
            isSuccess &= IsArraySame(result, checkResult);
            Print("isSuccess = {0} result = {1} | checkResult = {2}", isSuccess, GetArrayStr(result), GetArrayStr(checkResult));

            return isSuccess;
        }

        /// <summary>
        /// 44/44 cases passed (108 ms)
        /// Your runtime beats 69.39 % of csharp submissions
        /// Your memory usage beats 35.71 % of csharp submissions(24.1 MB)
        /// </summary>
        /// <param name="head"></param>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public ListNode ReverseBetween(ListNode head, int left, int right)
        {
            int diff = right - left;

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

            int mid = (left + right - 2) / 2;
            int len = (right - left + 1);
            int halfLen = len / 2;
            bool isOdd = len % 2 == 1;
            for (int i = 1; i <= halfLen; i++)
            {
                ListNode tmp = list[mid + i];
                if (isOdd)
                {
                    //Print("[{0}]:{1} <=> [{2}]:{3}", mid - i, list[mid - i], mid + i, list[mid + i]);
                    list[mid + i] = list[mid - i];
                    list[mid - i] = tmp;
                }
                else
                {
                    //Print("[{0}]:{1} <=> [{2}]:{3}", mid - i, list[mid - i], mid + i, list[mid + i]);
                    list[mid + i] = list[mid - i + 1];
                    list[mid - i + 1] = tmp;
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
    }
    // @lc code=end


}
