using System;
namespace CSharpConsoleApp.Solutions
{
    /*
 * @lc app=leetcode.cn id=147 lang=csharp
 *
 * [147] 对链表进行插入排序
 *
 * https://leetcode-cn.com/problems/insertion-sort-list/description/
 *
 * algorithms
 * Medium (67.74%)
 * Likes:    403
 * Dislikes: 0
 * Total Accepted:    91.6K
 * Total Submissions: 135.2K
 * Testcase Example:  '[4,2,1,3]'
 *
 * 对链表进行插入排序。
 * 
 * 
 * 插入排序的动画演示如上。从第一个元素开始，该链表可以被认为已经部分排序（用黑色表示）。
 * 每次迭代时，从输入数据中移除一个元素（用红色表示），并原地将其插入到已排好序的链表中。
 * 
 * 
 * 
 * 插入排序算法：
 * 
 * 
 * 插入排序是迭代的，每次只移动一个元素，直到所有元素可以形成一个有序的输出列表。
 * 每次迭代中，插入排序只从输入数据中移除一个待排序的元素，找到它在序列中适当的位置，并将其插入。
 * 重复直到所有输入数据插入完为止。
 * 
 * 
 * 
 * 
 * 示例 1：
 * 
 * 输入: 4->2->1->3
 * 输出: 1->2->3->4
 * 
 * 
 * 示例 2：
 * 
 * 输入: -1->5->3->4->0
 * 输出: -1->0->3->4->5
 * 
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
    public class Solution147 : SolutionBase
    {
        /// <summary>
        /// 难度
        /// </summary>
        public override Difficulity GetDifficulity() { return Difficulity.Medium; }
        /// <summary>
        /// 关键字:
        /// </summary>
        public override string[] GetKeyWords() { return new string[] { "插入排序" }; }
        /// <summary>
        /// 标签：
        /// </summary>
        public override Tag[] GetTags() { return new Tag[] { Tag.LinkedList, Tag.Sort }; }


        public override bool Test(System.Diagnostics.Stopwatch sw)
        {
            bool isSuccess = true;
            string result, checkResult;

            ListNodeList list = new ListNodeList(new int[] { 4, 2, 1, 3 });
            checkResult = GetArrayStr(new int[] { 1, 2, 3, 4 });
            result = InsertionSortList(list.first).ToString(",");
            isSuccess &= IsSame(result, checkResult);
            PrintResult(isSuccess, result, checkResult);

            list = new ListNodeList(new int[] { -1, 5, 3, 4, 0 });
            checkResult = GetArrayStr(new int[] { -1, 0, 3, 4, 5 });
            result = InsertionSortList(list.first).ToString(",");
            isSuccess &= IsSame(result, checkResult);
            PrintResult(isSuccess, result, checkResult);

            return isSuccess;
        }

        /// <summary>
        /// 插入排序：
        /// 基本思想是，维护一个有序序列，
        /// 初始时有序序列只有一个元素，
        /// 每次将一个新的元素插入到有序序列中，将有序序列的长度增加 1，
        /// 直到全部元素都加入到有序序列中。
        /// 
        /// 作者：LeetCode-Solution
        /// 链接：https://leetcode-cn.com/problems/insertion-sort-list/solution/dui-lian-biao-jin-xing-cha-ru-pai-xu-by-leetcode-s/
        /// 19/19 cases passed (92 ms)
        /// Your runtime beats 100 % of csharp submissions
        /// Your memory usage beats 50 % of csharp submissions(25.4 MB)
        /// </summary>
        /// <param name="head"></param>
        /// <returns></returns>
        public ListNode InsertionSortList(ListNode head)
        {
            if (head == null) return head;

            //创建哑节点，设置节点到head之前。
            ListNode dummyHead = new ListNode(0);
            dummyHead.next = head;

            //逐次插入
            ListNode lastSorted = head, curr = head.next;
            while (curr != null)
            {
                //比较是否为最后一个节点
                if (lastSorted.val <= curr.val)
                {
                    lastSorted = lastSorted.next;
                }
                else
                {
                    //不是最后一个节点，从开头节点，逐次向后比较
                    ListNode prev = dummyHead;
                    while (prev.next.val <= curr.val)
                    {
                        prev = prev.next;
                    }
                    //插入节点
                    lastSorted.next = curr.next;
                    curr.next = prev.next;
                    prev.next = curr;
                }
                curr = lastSorted.next;
            }
            return dummyHead.next;
        }
    }
    // @lc code=end


}
