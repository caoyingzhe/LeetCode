using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpConsoleApp.Solutions._0000
{
    /*
     * @lc app=leetcode.cn id=24 lang=csharp
     *
     * [24] 两两交换链表中的节点
     *
     * https://leetcode-cn.com/problems/swap-nodes-in-pairs/description/
     *
     * Category	Difficulty	Likes	Dislikes
     * algorithms	Medium (69.56%)	908	-
     * Tags
     * linked-list
     * 
     * Companies
     * bloomberg | microsoft | uber
     * Total Accepted:    255.7K
     * Total Submissions: 367.3K
     * Testcase Example:  '[1,2,3,4]'
     *
     * 给定一个链表，两两交换其中相邻的节点，并返回交换后的链表。
     * 
     * 你不能只是单纯的改变节点内部的值，而是需要实际的进行节点交换。
     * 
     * 示例 1：
     * 输入：head = [1,2,3,4]
     * 输出：[2,1,4,3]
     * 
     * 示例 2：
     * 输入：head = []
     * 输出：[]
     * 
     * 示例 3：
     * 输入：head = [1]
     * 输出：[1]
     * 提示：
     * 链表中节点的数目在范围 [0, 100] 内
     * 0 <= Node.val <= 100
     * 
     * 进阶：你能在不修改链表节点值的情况下解决这个问题吗?（也就是说，仅修改节点本身。）
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
    class Solution24 : SolutionBase
    {
        public override bool Test(System.Diagnostics.Stopwatch sw)
        {
            ListNode head;
            ListNode resultNode;
            List<int> result;
            int[] checkResult;
            bool isSuccess = true;

            head = new ListNode(new int[] { 1, 2, 3, 4 });
            checkResult = new int[] { 2, 1, 4, 3};
            resultNode = SwapPairs(head);
            result = (resultNode == null) ? null : resultNode.GetValueList();
            isSuccess &= IsArraySame(result.ToArray(), checkResult);
            Print("isSuccess = {0} | result = {1} | anticipated = {2}", isSuccess, GetArrayStr<int>(result), GetArrayStr<int>(checkResult));

            return isSuccess;
        }
        //两两交换
        public ListNode SwapPairs(ListNode head)
        {
            if (head == null || head.next == null)
                return head;

            List<ListNode> list = new List<ListNode>();
            GetNodeList(head, list);

            int n = list.Count;
            for(int i=0; i< n; i+=2)
            {
                if (i + 1 >= n)
                    break;

                ListNode L = list[i];
                ListNode R = list[i + 1];
                list[i] = R;
                list[i+1] = L;
            }

            //更新node的next值
            for (int i = 0; i < list.Count - 1; i++)
            {
                list[i].next = list[i + 1];
            }
            //更新list[Count-1].next为空，避免死循环。
            list[list.Count - 1].next = null;
            return list[0];
        }

        public void GetNodeList(ListNode node, List<ListNode> list)
        {
            if (list == null || node == null)
                return;

            while (node != null)
            {
                list.Add(node);
                node = node.next;
            }
        }
    }
}
