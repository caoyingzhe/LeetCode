using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpConsoleApp.Solutions._0000
{
    /*
     * @lc app=leetcode.cn id=21 lang=csharp
     *
     * [21] 合并两个有序链表
     *
     * https://leetcode-cn.com/problems/merge-two-sorted-lists/description/
     *
     * Category	Difficulty	Likes	Dislikes
     * algorithms	Easy (65.92%)	1698	-
     * Tags
     * linked-list
     * 
     * Companies
     * amazon | apple | linkedin | microsoft
     * 
     * Total Accepted:    559.8K
     * Total Submissions: 848.6K
     * Testcase Example:  '[1,2,4]\n[1,3,4]'
     *
     * 将两个升序链表合并为一个新的 升序 链表并返回。新链表是通过拼接给定的两个链表的所有节点组成的。 
     * 
     * 示例 1：
     * 输入：l1 = [1,2,4], l2 = [1,3,4]
     * 输出：[1,1,2,3,4,4]
     * 
     * 示例 2：
     * 输入：l1 = [], l2 = []
     * 输出：[]
     * 
     * 示例 3：
     * 输入：l1 = [], l2 = [0]
     * 输出：[0]
     * 
     * 提示：
     * 两个链表的节点数目范围是 [0, 50]
     * -100 <= Node.val <= 100
     * l1 和 l2 均按 非递减顺序 排列
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
    class Solution21 : SolutionBase
    {
        ///
        public override bool Test(System.Diagnostics.Stopwatch sw)
        {
            ListNode l1 = new ListNode(new int[] { 1, 2, 4 });
            ListNode l2 = new ListNode(new int[] { 1, 3, 4 });
            ListNode resultNode;
            List<int> result;
            int[] checkResult;
            bool isSuccess = true;

            l1 = new ListNode(new int[] { });
            l2 = new ListNode(new int[] { });
            checkResult = new int[] { };
            resultNode = MergeTwoLists(l1, l2);
            result = (resultNode == null) ? null : resultNode.GetValueList();
            isSuccess &= IsArraySame(result.ToArray(), checkResult);
            Print("isSuccess = {0} | result = {1} | anticipated = {2}", isSuccess, GetArrayStr<int>(result), GetArrayStr<int>(checkResult));


            l1 = new ListNode(new int[] { -29, -29, -25, -20, -20, -16, -14, -13, -12, -2, 4, 6, 14, 19, 21, 27, 29, 29});
            l2 = new ListNode(new int[] { -30, -30, -30, -29, -29, -28, -27, -27, -26, -22, -21, -20, -18, -16, -16, -14, -14, -13, -12, -11, -9, -7, -6, -5, -5, -4, -3, -2, -2, -1, -1, 2, 3, 6, 8, 16, 17, 18, 20, 20, 23, 24 });
            checkResult = new int[] { -30, -30, -30, -29, -29, -29, -29, -28, -27, -27, -26, -25, -22, -21, -20, -20, -20, -18, -16, -16, -16, -14, -14, -14, -13, -13, -12, -12, -11, -9, -7, -6, -5, -5, -4, -3, -2, -2, -2, -1, -1, 2, 3, 4, 6, 6, 8, 14, 16, 17, 18, 19, 20, 20, 21, 23, 24, 27, 29, 29 };
            resultNode = MergeTwoLists(l1, l2);
            result = (resultNode == null) ? null : resultNode.GetValueList();
            isSuccess &= IsArraySame(result.ToArray(), checkResult);
            Print("isSuccess = {0} | result = {1} | anticipated = {2}", isSuccess, GetArrayStr<int>(result), GetArrayStr<int>(checkResult));

            l1 = new ListNode(new int[] { 5 });
            l2 = new ListNode(new int[] { 1, 2, 4 });
            checkResult = new int[] { 1, 2, 4, 5 };
            resultNode = MergeTwoLists(l1, l2);
            result = (resultNode == null) ? null : resultNode.GetValueList();
            isSuccess &= IsArraySame(result.ToArray(), checkResult);
            Print("isSuccess = {0} | result = {1} | anticipated = {2}", isSuccess, GetArrayStr<int>(result), GetArrayStr<int>(checkResult));


            //l1 = new ListNode(new int[] { });
            //l2 = new ListNode(new int[] { });
            //checkResult = new int[] { };
            //resultNode = MergeTwoLists(l1, l2);
            //result = (resultNode == null) ? null : resultNode.GetValueList();
            //isSuccess &= IsArraySame(result.ToArray(), checkResult);
            //Print("isSuccess = {0} | result = {1} | anticipated = {2}", isSuccess, GetArrayStr<int>(result), GetArrayStr<int>(checkResult));

            return true;
        }

        /// <summary>
        /// 208/208 cases passed (116 ms)
        /// Your runtime beats 32.6 % of csharp submissions
        /// Your memory usage beats 67.54 % of csharp submissions(25.7 MB)
        /// </summary>
        /// <param name="l1"></param>
        /// <param name="l2"></param>
        /// <returns></returns>
        public ListNode MergeTwoLists(ListNode l1, ListNode l2)
        {
            if (l1 == null && l2 == null)
                return null;
            else if (l1 == null)
                return l2;
            else if (l2 == null)
                return l1;

            List<ListNode> list = new List<ListNode>();
            GetNodeList(l1, list);
            GetNodeList(l2, list);
            list.Sort((a ,b) => { return a.val - b.val; });

            //Bug在此，循环中漏掉了 list[Count-1].next的更新，会造成死循环。
            for(int i=0; i<list.Count-1; i++)
            {
                list[i].next = list[i + 1];
            }
            //此处是Bug对应，更新list[Count-1].next为空，避免死循环。
            list[list.Count - 1].next = null;
            return list[0];
        }

        public void GetNodeList(ListNode node, List<ListNode> list)
        {
            if (list == null || node == null)
                return;

            ListNode temp = node;
            while (temp != null)
            {
                list.Add(temp);
                temp = temp.next;
            }
        }
    }
}
