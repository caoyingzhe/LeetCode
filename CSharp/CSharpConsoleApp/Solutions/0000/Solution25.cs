using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpConsoleApp.Solutions._0000
{
    /*
     * @lc app=leetcode.cn id=25 lang=csharp
     *
     * [25] K 个一组翻转链表
     *
     * https://leetcode-cn.com/problems/reverse-nodes-in-k-group/description/
     *
     * Category	Difficulty	Likes	Dislikes
     * algorithms	Hard (64.78%)	1087	-
     * Tags
     * linked-list
     * 
     * Companies
     * facebook | microsoft
     * 
     * Total Accepted:    171.2K
     * Total Submissions: 264.2K
     * Testcase Example:  '[1,2,3,4,5]\n2'
     *
     * 给你一个链表，每 k 个节点一组进行翻转，请你返回翻转后的链表。
     * 
     * k 是一个正整数，它的值小于或等于链表的长度。
     * 
     * 如果节点总数不是 k 的整数倍，那么请将最后剩余的节点保持原有顺序。
     * 
     * 进阶：
     * 你可以设计一个只使用常数额外空间的算法来解决此问题吗？
     * 你不能只是单纯的改变节点内部的值，而是需要实际进行节点交换。
     * 
     * 示例 1：
     * 输入：head = [1,2,3,4,5], k = 2
     * 输出：[2,1,4,3,5]
     * 
     * 示例 2：
     * 输入：head = [1,2,3,4,5], k = 3
     * 输出：[3,2,1,4,5]
     * 
     * 示例 3：
     * 输入：head = [1,2,3,4,5], k = 1
     * 输出：[1,2,3,4,5]
     * 
     * 示例 4：
     * 输入：head = [1], k = 1
     * 输出：[1]
     * 
     * 提示：
     * 列表中节点的数量在范围 sz 内
     * 1 <= sz <= 5000
     * 0 <= Node.val <= 1000
     * 1 <= k <= sz
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

    /// 思路一：用栈，我们把 k 个数压入栈中，然后弹出来的顺序就是翻转的！
    /// 思路二：尾插法。意思就是,依次把cur移到tail后面 ？？？
    /// 思路三：递归
    class Solution25 : SolutionBase
    {
        public override bool Test(System.Diagnostics.Stopwatch sw)
        {
            ListNode head;
            int k;
            ListNode resultNode;
            List<int> result;
            int[] checkResult;
            bool isSuccess = true;

            head = new ListNode(new int[] { 1, 2, 3, 4, 5 });
            k = 2;
            checkResult = new int[] { 2, 1, 4, 3, 5 };
            resultNode = ReverseKGroup(head, k);
            result = (resultNode == null) ? null : resultNode.GetValueList();
            isSuccess &= IsArraySame(result.ToArray(), checkResult);
            Print("isSuccess = {0} | result = {1} | anticipated = {2}", isSuccess, GetArrayStr<int>(result), GetArrayStr<int>(checkResult));


            head = new ListNode(new int[] { 1, 2, 3, 4, 5 });
            k = 3;
            checkResult = new int[] { 3, 2, 1, 4, 5 };
            resultNode = ReverseKGroup(head, k);
            result = (resultNode == null) ? null : resultNode.GetValueList();
            isSuccess &= IsArraySame(result.ToArray(), checkResult);
            Print("isSuccess = {0} | result = {1} | anticipated = {2}", isSuccess, GetArrayStr<int>(result), GetArrayStr<int>(checkResult));

            return isSuccess;
        }

        /// <summary>
        /// 自己的常规写法，效率比较差
        /// 
        /// 62/62 cases passed (124 ms)
        /// Your runtime beats 22.08 % of csharp submissions
        /// Your memory usage beats 8.44 % of csharp submissions(26.7 MB)
        /// </summary>
        /// <param name="head"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public ListNode ReverseKGroup_My(ListNode head, int k)
        {
            if (head == null || head.next == null || k == 1)
                return head;

            List<ListNode> list = new List<ListNode>();
            GetNodeList(head, list);

            int n = list.Count;
            for (int i = 0; i < n; i += k)
            {
                if (i + k - 1 >= n)
                    break;

                int mid = k / 2;
                int rOffset = k % 2 == 0 ? -1 : 0;

                for (int j = 1; j <= mid; j++)
                {
                    int l = i + mid - j;
                    int r = i + mid + j + rOffset;
                    ListNode L = list[l];
                    ListNode R = list[r];
                    list[l] = R;
                    list[r] = L;
                }
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

        /// <summary>
        /// 使用节点断开 递归的方法，会非常块。
        /// 62/62 cases passed (104 ms)
        /// Your runtime beats 97.4 % of csharp submissions
        /// Your memory usage beats 81.82 % of csharp submissions(26 MB)
        /// 
        /// 链接：https://leetcode-cn.com/problems/reverse-nodes-in-k-group/solution/tu-jie-kge-yi-zu-fan-zhuan-lian-biao-by-user7208t/
        /// 
        /// </summary>
        /// <param name="head"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public ListNode ReverseKGroup(ListNode head, int k)
        {
            ListNode dummy = new ListNode(0);
            dummy.next = head;

            ListNode pre = dummy; //pre 代表待翻转链表的前,   最初为head
            ListNode end = dummy; //end 代表待翻转链表的末尾，最初为head

            while (end.next != null)
            {
                for (int i = 0; i < k && end != null; i++)
                    end = end.next;
                if (end == null)
                    break;

                ListNode start = pre.next;
                ListNode next = end.next;
                end.next = null;            //断开k位置的后续节点

                pre.next = Reverse(start);  //执行翻转前，start节点已经是k长度。
                start.next = next;          //翻转后,更新start的next节点
                pre = start;                //为了下次翻转处理，更新pre为start节点

                end = pre;                  //为了本次翻转处理，更新end为start节点
            }
            return dummy.next;
        }

        /// <summary>
        /// 链接：https://leetcode-cn.com/problems/reverse-nodes-in-k-group/solution/tu-jie-kge-yi-zu-fan-zhuan-lian-biao-by-user7208t/
        /// </summary>
        /// <param name="head"></param>
        /// <returns></returns>
        private ListNode Reverse(ListNode head)
        {
            ListNode pre = null;
            ListNode curr = head;
            while (curr != null)
            {
                ListNode next = curr.next;
                curr.next = pre;
                pre = curr;
                curr = next;
            }
            return pre;
        }
    }
}
