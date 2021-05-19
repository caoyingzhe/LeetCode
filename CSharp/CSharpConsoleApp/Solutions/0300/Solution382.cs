using System;
namespace CSharpConsoleApp.Solutions
{
    /*
     * @lc app=leetcode.cn id=382 lang=csharp
     *
     * [382] 链表随机节点
     *
     * https://leetcode-cn.com/problems/linked-list-random-node/description/
     *
     * Category	Difficulty	Likes	Dislikes
     * algorithms	Medium (61.02%)	132	-
     * Tags
     * reservoir-sampling
     * 
     * Companies
     * google
     * 
     * Total Accepted:    12.2K
     * Total Submissions: 20.1K
     * Testcase Example:  '["Solution","getRandom","getRandom","getRandom","getRandom","getRandom"]\n' +
      '[[[1,2,3]],[],[],[],[],[]]'
     *
     * 给定一个单链表，随机选择链表的一个节点，并返回相应的节点值。保证每个节点被选的概率一样。
     * 
     * 进阶:
     * 如果链表十分大且长度未知，如何解决这个问题？你能否使用常数级空间复杂度实现？
     * 
     * 示例:
     * 
     * 
     * // 初始化一个单链表 [1,2,3].
     * ListNode head = new ListNode(1);
     * head.next = new ListNode(2);
     * head.next.next = new ListNode(3);
     * Solution solution = new Solution(head);
     * 
     * // getRandom()方法应随机返回1,2,3中的一个，保证每个元素被返回的概率相等。
     * solution.getRandom();
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

/**
* Your Solution object will be instantiated and called as such:
* Solution obj = new Solution(head);
* int param_1 = obj.GetRandom();
*/
    public class Solution382 : SolutionBase
    {
        /// <summary>
        /// 难度
        /// </summary>
        public override Difficulity GetDifficulity() { return Difficulity.Medium; }
        /// <summary>
        /// 关键字:
        /// </summary>
        public override string[] GetKeyWords() { return new string[] { "Math", "BitManipulation" }; }
        /// <summary>
        /// 标签： 
        /// </summary>
        public override Tag[] GetTags() { return new Tag[] { Tag.BitManipulation, Tag.Math }; }
        public override bool Test(System.Diagnostics.Stopwatch sw)
        {
            bool isSuccess = true;
            return isSuccess;
        }

        /** @param head The linked list's head.
        Note that the head is guaranteed to be not null, so it contains at least one node. */

        public class Solution { 
            public Solution(ListNode head)
            {

            }

            /** Returns a random node's value. */
            public int GetRandom()
            {
                Random rand = new Random();
                return rand.Next();
            }
        }
    }
}
