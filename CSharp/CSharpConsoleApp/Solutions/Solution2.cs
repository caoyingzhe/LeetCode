using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CSharpConsoleApp.Solutions
{
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
