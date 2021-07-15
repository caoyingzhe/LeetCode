using System;
using System.Collections.Generic;
namespace CSharpConsoleApp.Solutions
{
    /*
     * @lc app=leetcode.cn id=234 lang=csharp
     *
     * [234] 回文链表
     *
     * https://leetcode-cn.com/problems/palindrome-linked-list/description/
     *
     * Category	Difficulty	Likes	Dislikes
     * algorithms	Easy (48.29%)	1027	-
     * Tags
     * linked-list | two-pointers
     * 
     * Companies
     * amazon | facebook
     * 
     * Total Accepted:    263.9K
     * Total Submissions: 546.3K
     * Testcase Example:  '[1,2,2,1]'
     *
     * 请判断一个链表是否为回文链表。
     * 
     * 示例 1:
     * 
     * 输入: 1->2
     * 输出: false
     * 
     * 示例 2:
     * 
     * 输入: 1->2->2->1
     * 输出: true
     * 
     * 
     * 进阶：
     * 你能否用 O(n) 时间复杂度和 O(1) 空间复杂度解决此题？
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
    public class Solution234 : SolutionBase
    {
        /// <summary>
        /// 难度
        /// </summary>
        public override Difficulity GetDifficulity() { return Difficulity.Easy; }
        /// <summary>
        /// 关键字:
        /// </summary>
        public override string[] GetKeyWords() { return new string[] { "回文", }; }
        /// <summary>
        /// 标签：
        /// </summary>
        public override Tag[] GetTags() { return new Tag[] { Tag.TwoPointers, Tag.LinkedList, }; }

        /// <summary>
        /// </summary>
        /// <param name="sw"></param>
        /// <returns></returns>
        public override bool Test(System.Diagnostics.Stopwatch sw)
        {
            bool isSuccess = true;
            ListNodeList list = new ListNodeList(new int[] { 1,2,2,1});
            Print("{0} | {1}", list.list[0].ToString(","), IsPalindrome(list.list[0]));

            list = new ListNodeList(new int[] { 1, 2, 3, 2, 1 });
            Print("{0} | {1}", list.list[0].ToString(","), IsPalindrome(list.list[0]));

            list = new ListNodeList(new int[] { 1, 2, 3, 5, 2, 1 });
            Print("{0} | {1}", list.list[0].ToString(","), IsPalindrome(list.list[0]));
            return isSuccess;
        }

        /// <summary>
        /// 85/85 cases passed (324 ms)
        /// Your runtime beats 75.2 % of csharp submissions
        /// Your memory usage beats 36.8 % of csharp submissions(47.6 MB)
        /// </summary>
        /// <param name="head"></param>
        /// <returns></returns>
        public bool IsPalindrome(ListNode head)
        {
            List<int> vals = new List<int>();

            // 将链表的值复制到数组中
            ListNode currentNode = head;
            while (currentNode != null)
            {
                vals.Add(currentNode.val);
                currentNode = currentNode.next;
            }

            // 使用双指针判断是否回文
            int front = 0;
            int back = vals.Count - 1;
            while (front < back)
            {
                if (vals[front] != vals[back])
                {
                    return false;
                }
                front++;
                back--;
            }
            return true;
        }
    }
}
