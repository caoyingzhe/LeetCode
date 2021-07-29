using System;
namespace CSharpConsoleApp.Solutions
{
    /*
     * @lc app=leetcode.cn id=430 lang=csharp
     *
     * [430] 扁平化多级双向链表
     *
     * https://leetcode-cn.com/problems/flatten-a-multilevel-doubly-linked-list/description/
     *
     * Category	Difficulty	Likes	Dislikes
     * algorithms	Medium (53.78%)	211	-
     * Tags
     * Unknown
     * 
     * Companies
     * Unknown
     * 
     * Total Accepted:    20.1K
     * Total Submissions: 37.4K
     * Testcase Example:  '[1,2,3,4,5,6,null,null,null,7,8,9,10,null,null,11,12]'
     *
     * 
     * 多级双向链表中，除了指向下一个节点和前一个节点指针之外，它还有一个子链表指针，可能指向单独的双向链表。这些子列表也可能会有一个或多个自己的子项，依此类推，生成多级数据结构，如下面的示例所示。
     * 
     * 给你位于列表第一级的头节点，请你扁平化列表，使所有结点出现在单级双链表中。
     * 
     * 
     * 
     * 示例 1：
     * 输入：head = [1,2,3,4,5,6,null,null,null,7,8,9,10,null,null,11,12]
     * 输出：[1,2,3,7,8,11,12,9,10,4,5,6]
     * 解释：
     * 
     * 输入的多级列表如下图所示：
     * 
     * 
     * 
     * 扁平化后的链表如下图：
     * 
     * 
     * 
     * 
     * 示例 2：
     * 
     * 输入：head = [1,2,null,3]
     * 输出：[1,3,2]
     * 解释：
     * 
     * 输入的多级列表如下图所示：
     * 
     * ⁠ 1---2---NULL
     * ⁠ |
     * ⁠ 3---NULL
     * 
     * 
     * 示例 3：
     * 
     * 输入：head = []
     * 输出：[]
     * 
     * 
     * 
     * 
     * 如何表示测试用例中的多级链表？
     * 
     * 以 示例 1 为例：
     * 
     * ⁠1---2---3---4---5---6--NULL
     * ⁠        |
     * ⁠        7---8---9---10--NULL
     * ⁠            |
     * ⁠            11--12--NULL
     * 
     * 序列化其中的每一级之后：
     * 
     * [1,2,3,4,5,6,null]
     * [7,8,9,10,null]
     * [11,12,null]
     * 
     * 
     * 为了将每一级都序列化到一起，我们需要每一级中添加值为 null 的元素，以表示没有节点连接到上一级的上级节点。
     * 
     * [1,2,3,4,5,6,null]
     * [null,null,7,8,9,10,null]
     * [null,11,12,null]
     * 
     * 
     * 合并所有序列化结果，并去除末尾的 null 。
     * 
     * [1,2,3,4,5,6,null,null,null,7,8,9,10,null,null,11,12]
     * 
     * 
     * 
     * 提示：
     * 
     * 
     * 节点数目不超过 1000
     * 1 <= Node.val <= 10^5
     * 
     * 
     */

    // @lc code=start
    /*
    // Definition for a Node.
    public class Node {
        public int val;
        public Node prev;
        public Node next;
        public Node child;
    }
    */

    public class Solution430 : SolutionBase
    {
        public class Node
        {
            public int val;
            public Node prev;
            public Node next;
            public Node child;
        }

        /// <summary>
        /// 难易度:
        /// </summary>
        public override Difficulity GetDifficulity() { return Difficulity.Hard; }
        /// <summary>
        /// 关键字:
        /// </summary>
        public override string[] GetKeyWords() { return new string[] { "" }; }
        /// <summary>
        /// 标签： 
        /// </summary>
        public override Tag[] GetTags() { return new Tag[] { Tag.Design }; }

        public override bool Test(System.Diagnostics.Stopwatch sw)
        {
            bool isSuccess = false;
            Node head;
            Node result, checkResult;


            head = new Node() ;
            checkResult = new Node();
            result = Flatten(head);
            isSuccess &= IsSame(result, checkResult);
            PrintResult(isSuccess, result, checkResult);

            return isSuccess;
        }

        // 作者：venturekwok
        // 链接：https://leetcode-cn.com/problems/flatten-a-multilevel-doubly-linked-list/solution/java-jing-cai-di-gui-dai-ma-jian-ji-yi-d-n1lb/
        /// <summary>
        /// 26/26 cases passed (84 ms)
        /// Your runtime beats 100 % of csharp submissions
        /// Your memory usage beats 14.29 % of csharp submissions(24.8 MB)
        /// </summary>
        /// <param name="head"></param>
        /// <returns></returns>
        public Node Flatten(Node head)
        {
            if (head == null) return head;

            Node cur = head;
            while (cur != null)
            {
                if (cur.child != null)
                {
                    Node temp = cur.next;
                    //扁平化子节点的链表
                    Node child = Flatten(cur.child);
                    //取得链表的最后一个节点
                    Node childEnd = GetEnd(child);

                    childEnd.next = cur.next;
                    child.prev = cur;
                    if (cur.next != null)
                        cur.next.prev = childEnd;
                    cur.next = child;
                    //变换前：[1,null,2,null,3,null
                    //变换后：1 -> null
                    //       2
                    //       3
                    cur.child = null;
                    cur = temp;
                }
                else
                {
                    cur = cur.next;
                }
            }
            //System.out.println(head.val);
            return head;
        }

        //取得链表的最后一个节点
        public Node GetEnd(Node child)
        {
            while (child.next != null)
                child = child.next;

            return child;
        }
    }
    // @lc code=end


}
