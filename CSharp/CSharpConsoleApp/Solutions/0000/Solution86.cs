using System;
using System.Collections.Generic;
namespace CSharpConsoleApp.Solutions
{
    /*
     * @lc app=leetcode.cn id=86 lang=csharp
     *
     * [86] 分隔链表
     *
     * https://leetcode-cn.com/problems/partition-list/description/
     *
     * Category	Difficulty	Likes	Dislikes
     * algorithms	Medium (62.90%)	414	-
     * Tags
     * linked-list | two-pointers
     * 
     * Companies
     * Unknown
     * 
     * Total Accepted:    105.8K
     * Total Submissions: 168.2K
     * Testcase Example:  '[1,4,3,2,5,2]\n3'
     *
     * 给你一个链表的头节点 head 和一个特定值 x ，请你对链表进行分隔，使得所有 小于 x 的节点都出现在 大于或等于 x 的节点之前。
     * 你应当 保留 两个分区中每个节点的初始相对位置。
     *
     * 
     * 示例 1：
     * 输入：head = [1,4,3,2,5,2], x = 3
     * 输出：[1,2,2,4,3,5]
     * 
     * 
     * 示例 2：
     * 输入：head = [2,1], x = 2
     * 输出：[1,2]
     * 
     * 
     * 提示：
     * 链表中节点的数目在范围 [0, 200] 内
     * -100 <= Node.val <= 100
     * -200 <= x <= 200
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
    public class Solution86 : SolutionBase
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
            ListNodeList list;
            int[] result, checkResult;

            //1,2,3,3,4,4,5
            list = new ListNodeList(new int[] { 1, 4, 3, 2, 5, 2 });
            checkResult = new int[] { 1, 2, 2, 4, 3, 5 };

            ListNode resultNode = Partition(list.first, 3);
            result = resultNode.GetValueList().ToArray();
            isSuccess &= IsArraySame(result, checkResult);
            Print("isSuccess = {0} result = {1} | checkResult = {2}", isSuccess, GetArrayStr(result), GetArrayStr(checkResult));

            return isSuccess;
        }

        //作者：LeetCode-Solution
        //链接：https://leetcode-cn.com/problems/partition-list/solution/fen-ge-lian-biao-by-leetcode-solution-7ade/
        /// <summary>
        /// 设置左右两个空节点存储分隔链表，
        /// 左节点按原始顺序存储小于x的节点，R存储大于x的节点，
        /// 最后链接左链表和右链表。
        ///
        /// 168/168 cases passed (100 ms)
        /// Your runtime beats 92.86 % of csharp submissions
        /// Your memory usage beats 33.33 % of csharp submissions(24.9 MB)
        /// </summary>
        /// <param name="head"></param>
        /// <param name="x"></param>
        /// <returns></returns>
        public ListNode Partition(ListNode head, int x)
        {
            ListNode L = new ListNode(0);
            ListNode LHead = L;

            ListNode R = new ListNode(0);
            ListNode RHead = R;
            while (head != null)
            {
                //Print("head:[{0}] => head.next[{1}]", head.val, (head.next == null ? "null" : "" + head.next.val));
                if (head.val < x)
                {
                    //Print("L:[{0}].next = {1} | L:[{2}] => L.next:[{3}]", L.val, head.val, L.val, head.val);
                    L.next = head;
                    L = L.next;
                }
                else
                {
                    //Print("R:[{0}].next = {1} | R:[{2}] => R.next:[{3}]", R.val, head.val, R.val, head.val);

                    R.next = head;
                    R = R.next;
                }
                head = head.next;
            }
            R.next = null;
            L.next = RHead.next;
            return LHead.next;
        }

        public ListNode Partition_MY(ListNode head, int x)
        {
            List<ListNode> list = GetValueList(head);
            list.Sort((a, b) => a.val - b.val);

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
