using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpConsoleApp.Solutions
{
    /// <summary>
    /// 合并K个升序链表
    /// </summary>
    class Solution23 : SolutionBase
    {
        //public class ListNode
        //{
        //    public int val;
        //    public ListNode next;
        //    public ListNode(int val = 0, ListNode next = null)
        //    {
        //        this.val = val;
        //        this.next = next;
        //    }
        //}
        /// <summary>
        /// 难度
        /// </summary>
        public override Difficulity GetDifficulity() { return Difficulity.Hard; }
        /// <summary>
        /// 关键字:
        /// </summary>
        public override string[] GetKeyWords() { return new string[] { "LinkedList" }; }
        /// <summary>
        /// 标签： 
        /// </summary>
        public override Tag[] GetTags() { return new Tag[] { Tag.DivideAndConquer, Tag.Heap, Tag.LinkedList }; }
        public override bool Test(System.Diagnostics.Stopwatch sw)
        {
            bool isSuccess = true;
            ListNode[] nodes;
            ListNode checkResult;
            ListNode result = null;

            nodes = new ListNode[] {
                new ListNode( new int[]{ 1, 4, 5 }),
                new ListNode( new int[]{ 1, 3, 4 }),
                new ListNode( new int[]{ 2, 6 }),
            };
            checkResult = new ListNode(new int[] { 1, 1, 2, 3, 4, 4, 5, 6 });

            //Print(string.Format("isSuccss ={0}, result={1} checkResult={2}", isSuccess, checkResult, checkResult));

            result = MergeKLists(nodes);
            isSuccess = ListNode.IsSame(result, checkResult);
            
            Print(string.Format("isSuccss ={0}, result={1} checkResult={2}", isSuccess, result, checkResult));
            return isSuccess;
        }
        /// <summary>
        /// 133/133 cases passed (128 ms)
        /// Your runtime beats 87.61 % of csharp submissions
        /// Your memory usage beats 35.89 % of csharp submissions(29.4 MB)
        /// 
        /// Your runtime beats 96.15 % of csharp submissions
        /// Your memory usage beats 9.82 % of csharp submissions (29.8 MB)
        /// 竟然一次完成，这是难题么？(内存使用率不佳)
        /// </summary>
        /// <param name="lists"></param>
        /// <returns></returns>
        public ListNode MergeKLists(ListNode[] lists)
        {
            if(lists.Length == 0)
                return new ListNode();

            Dictionary<int, ListNode> dict = new Dictionary<int, ListNode>();

            ListNode tailNode = null;
            List<ListNode> firstNodeList = new List<ListNode>();

            for(int i=0; i<lists.Length; i++)
            {
                ListNode curNode = lists[i];
                while (true)
                {
                    if (dict.ContainsKey(curNode.val))
                    {
                        dict[curNode.val].next = curNode; //对于i=1, 此处会破坏原有列表结构 dict[1].next({1,4,5}) => {1,1,3,4}
                        dict[curNode.val] = curNode;      //对于i=1, 此处会破坏原有列表结构 dict[1] = {1,1,3,4} => {1 | 1,3,4}
                        tailNode = curNode;
                    }
                    else
                    {
                        firstNodeList.Add(curNode);      
                        if (tailNode != null)            //对于i=1, tailNode = dict[1] = {1,1,3,4} => {1 | 1,3,4} => {1 | 1, null}
                            tailNode.next = null;
                        dict.Add(curNode.val, curNode);  //对于i=1, dict[3] = {3,4}
                        tailNode = curNode;              //对于i=1, tailNode = dict[3] = {3,4}
                    }
                    if (curNode.next == null)
                    {
                        break;
                    }
                    curNode = curNode.next;
                }
            }
            if (firstNodeList.Count == 0)
                return null;

            firstNodeList.Sort((a, b) => { return a.val - b.val; });

            for(int i=0; i< firstNodeList.Count -1; i++)
            {
                dict[firstNodeList[i].val].next = firstNodeList[i + 1];
            }
            return firstNodeList[0];
        }
    }
}
