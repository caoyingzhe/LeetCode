using System;
namespace CSharpConsoleApp.Solutions
{
    /*
     * @lc app=leetcode.cn id=109 lang=csharp
     *
     * [109] 有序链表转换二叉搜索树
     *
     * https://leetcode-cn.com/problems/convert-sorted-list-to-binary-search-tree/description/
     *
     * Category	Difficulty	Likes	Dislikes
     * algorithms	Medium (76.36%)	540	-
     * Tags
     * linked-list | depth-first-search
     * 
     * Companies
     * zenefits
     * 
     * Total Accepted:    83.7K
     * Total Submissions: 109.7K
     * Testcase Example:  '[-10,-3,0,5,9]'
     *
     * 给定一个单链表，其中的元素按升序排序，将其转换为高度平衡的二叉搜索树。
     * 
     * 本题中，一个高度平衡二叉树是指一个二叉树每个节点 的左右两个子树的高度差的绝对值不超过 1。
     * 
     * 示例:
     * 给定的有序链表： [-10, -3, 0, 5, 9],
     * 一个可能的答案是：[0, -3, 9, -10, null, 5], 它可以表示下面这个高度平衡二叉搜索树：
     * 
     * ⁠     0
     * ⁠    / \
     * ⁠  -3   9
     * ⁠  /   /
     * ⁠-10  5
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
     * Definition for a binary tree node.
     * public class TreeNode {
     *     public int val;
     *     public TreeNode left;
     *     public TreeNode right;
     *     public TreeNode(int val=0, TreeNode left=null, TreeNode right=null) {
     *         this.val = val;
     *         this.left = left;
     *         this.right = right;
     *     }
     * }
     */
    public class Solution109 : SolutionBase
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
        public override Tag[] GetTags() { return new Tag[] { Tag.LinkedList, Tag.DepthFirstSearch, Tag.TwoPointers }; }

        public override bool Test(System.Diagnostics.Stopwatch sw)
        {
            bool isSuccess = true;
            //TODO
            return isSuccess;
        }

        //作者：LeetCode-Solution
        //链接：https://leetcode-cn.com/problems/convert-sorted-list-to-binary-search-tree/solution/you-xu-lian-biao-zhuan-huan-er-cha-sou-suo-shu-1-3/
        //32/32 cases passed(116 ms)
        //Your runtime beats 68.42 % of csharp submissions
        //Your memory usage beats 31.58 % of csharp submissions(27.3 MB)
        public TreeNode SortedListToBST(ListNode head)
        {
            return BuildTree(head, null);
        }

        public TreeNode BuildTree(ListNode left, ListNode right)
        {
            if (left == right)
            {
                return null;
            }
            ListNode mid = GetMedian(left, right);
            TreeNode root = new TreeNode(mid.val);
            root.left = BuildTree(left, mid);
            root.right = BuildTree(mid.next, right);
            return root;
        }

        public ListNode GetMedian(ListNode left, ListNode right)
        {
            ListNode fast = left;
            ListNode slow = left;
            while (fast != right && fast.next != right)
            {
                fast = fast.next;
                fast = fast.next;
                slow = slow.next;
            }
            return slow;
        }
    }
    // @lc code=end


}
