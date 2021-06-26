using System;
namespace CSharpConsoleApp.Solutions
{
    /*
 * @lc app=leetcode.cn id=117 lang=csharp
 *
 * [117] 填充每个节点的下一个右侧节点指针 II
 *
 * https://leetcode-cn.com/problems/populating-next-right-pointers-in-each-node-ii/description/
 *
 * Category	Difficulty	Likes	Dislikes
 * algorithms	Medium (60.10%)	412	-
 * Tags
 * tree | depth-first-search
 * 
 * Companies
 * bloomberg | facebook | microsoft
 * 
 * Total Accepted:    74.5K
 * Total Submissions: 123.9K
 * Testcase Example:  '[1,2,3,4,5,null,7]'
 *
 * 给定一个二叉树
 * struct Node {
 * ⁠ int val;
 * ⁠ Node *left;
 * ⁠ Node *right;
 * ⁠ Node *next;
 * }
 * 
 * 填充它的每个 next 指针，让这个指针指向其下一个右侧节点。如果找不到下一个右侧节点，则将 next 指针设置为 NULL。
 * 初始状态下，所有 next 指针都被设置为 NULL。
 * 
 * 
 * 进阶：
 * 你只能使用常量级额外空间。
 * 使用递归解题也符合要求，本题中递归程序占用的栈空间不算做额外的空间复杂度。
 * 
 * 
 * 示例：
 * 输入：root = [1,2,3,4,5,null,7]
 * 输出：[1,#,2,3,#,4,5,7,#]
 * 解释：给定二叉树如图 A 所示，你的函数应该填充它的每个 next 指针，以指向其下一个右侧节点，如图 B 所示。序列化输出按层序遍历顺序（由 next
 * 指针连接），'#' 表示每层的末尾。
 * 
 * 
 * 提示：
 * 树中的节点数小于 6000
 * -100 <= node.val <= 100
 */

    // @lc code=start
    /*
    // Definition for a Node.
    public class Node {
        public int val;
        public Node left;
        public Node right;
        public Node next;

        public Node() {}

        public Node(int _val) {
            val = _val;
        }

        public Node(int _val, Node _left, Node _right, Node _next) {
            val = _val;
            left = _left;
            right = _right;
            next = _next;
        }
    }
    */

    public class Solution117 : SolutionBase
    {
        /// <summary>
        /// 难度
        /// </summary>
        public override Difficulity GetDifficulity() { return Difficulity.Medium; }
        /// <summary>
        /// 关键字:
        /// </summary>
        public override string[] GetKeyWords() { return new string[] { "C#，Java 中的指针遍历 for循环", }; }
        /// <summary>
        /// 标签：
        /// </summary>
        public override Tag[] GetTags() { return new Tag[] { Tag.Array, Tag.Tree, Tag.BreadthFirstSearch }; }

        const int NULL = int.MinValue;
        /// <summary>
        /// 入度：每个课程节点的入度数量等于其先修课程的数量；
        /// 出度：每个课程节点的出度数量等于其指向的后续课程数量；
        /// 所以只有当一个课程节点的入度为零时，其才是一个可以学习的自由课程。
        ///
        /// 拓扑排序即是将一个无环有向图转换为线性排序的过程。
        /// </summary>
        /// <param name="sw"></param>
        /// <returns></returns>
        public override bool Test(System.Diagnostics.Stopwatch sw)
        {
            bool isSuccess = true;

            //    1
            // ⁠  / \
            //  2   3
            // / \ / \
            //4  5 N  7
            //Node n1 = new Node(1);
            //Node n2 = new Node(2);
            //Node n3 = new Node(3);
            //Node n4 = new Node(4);
            //Node n5 = new Node(5);
            //Node n7 = new Node(7);

            //n1.left = n2;   n1.right = n3;
            //n2.left = n4;   n2.right = n5;
            //n3.left = null; n3.right = n7;
            //Node[] arr = new Node[] {n1,n2,n3,n4,n5,n7};
            //Connect(n1);

            //for(int i=0; i<arr.Length; i++)
            //{
            //    Print("{0} | next = {1} ", arr[i].val, (arr[i].next == null ? "null" : arr[i].next.val.ToString()));
            //}

            //Node n1 = new Node(1);
            //Node n2 = new Node(2);
            //Node n3 = new Node(3);
            //Node n4 = new Node(4);
            //Node n5 = new Node(5);

            //n1.left = n2; n1.right = n3;
            //n2.left = n4; n2.right = n5;
            //n3.left = null; n3.right = null;
            //Node[] arr = new Node[] { n1, n2, n3, n4, n5};
            //Connect(n1);

            //for (int i = 0; i < arr.Length; i++)
            //{
            //    Print("{0} | next = {1} ", arr[i].val, (arr[i].next == null ? "null" : arr[i].next.val.ToString()));
            //}

            //[3,9,20,null,null,15,7]
            //    1
            // ⁠  / \
            //  2   3
            // / \ / \
            //N  N 4  5
            Node n1 = new Node(1);
            Node n2 = new Node(2);
            Node n3 = new Node(3);
            Node n4 = new Node(4);
            Node n5 = new Node(5);

            n1.left = n2; n1.right = n3;
            n2.left = null; n2.right = null;
            n3.left = n4; n3.right = n5;
            Node[] arr = new Node[] { n1, n2, n3, n4, n5 };
            Connect(n1);

            for (int i = 0; i < arr.Length; i++)
            {
                Print("{0} | next = {1} ", arr[i].val, (arr[i].next == null ? "null" : arr[i].next.val.ToString()));
            }

            return isSuccess;
        }

        public class Node
        {
            public int val;
            public Node left;
            public Node right;
            public Node next;

            public Node() { }

            public Node(int _val)
            {
                val = _val;
            }
            public Node(int _val, Node _left, Node _right, Node _next)
            {
                val = _val;
                left = _left;
                right = _right;
                next = _next;
            }
        }


        //作者：LeetCode - Solution
        //链接：https://leetcode-cn.com/problems/populating-next-right-pointers-in-each-node-ii/solution/tian-chong-mei-ge-jie-dian-de-xia-yi-ge-you-ce-15/
        //因为必须处理树上的所有节点，所以无法降低时间复杂度，但是可以尝试降低空间复杂度。

        //关键变量1 上次最后一个有效节点 / 本次最初有效节点
        Node last = null, nextStart = null;

        /// <summary>
        /// 55/55 cases passed (112 ms)
        /// Your runtime beats 95.35 % of csharp submissions
        /// Your memory usage beats 93.02 % of csharp submissions(26.7 MB)
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public Node Connect(Node root)
        {
            if (root == null)
            {
                return null;
            }
            Node start = root;
            while (start != null)
            {
                last = null;
                nextStart = null;
                //C#，Java 中的指针遍历 for循环
                for (Node p = start; p != null; p = p.next)
                {
                    if (p.left != null)
                    {
                        handle(p.left);
                    }
                    if (p.right != null)
                    {
                        handle(p.right);
                    }
                }
                start = nextStart;
            }
            return root;
        }
        public void handle(Node p)
        {
            if (last != null)
            {
                last.next = p;
            }
            if (nextStart == null)
            {
                nextStart = p;
            }
            last = p;
        }


        #region ----- My NG Solution ---------
        //Testcase     : [3,9,20,null,null,15,7]
        //My Answer    : [3,#,9,20,#,15,#]
        //Right Answer : [3,#,9,20,#,15,7,#]
        //    1
        // ⁠  / \
        //  2   3
        // / \ / \
        //N  N 4  5
        public Node Connect_NG(Node root)
        {
            if (root == null) return root;

            // 从根节点开始
            Node leftmost = root;
            while (leftmost.left != null)
            {
                // 遍历这一层节点组织成的链表，为下一层的节点更新 next 指针
                Node head = leftmost;

                while (head != null)
                {
                    // CONNECTION 1
                    if (head.right != null)
                    {
                        if (head.left != null)
                            head.left.next = head.right;
                        head.right.next = FindNextFirstChild(head);
                    }
                    else
                    {
                        if (head.left != null)
                            head.left.next = FindNextFirstChild(head);
                    }

                    // 指针向后移动
                    head = head.next;
                }
                // 去下一层的最左的节点
                leftmost = leftmost.left;
            }
            return root;
        }

        public Node FindNextFirstChild(Node node)
        {
            Node parent;
            return FindNextFirstChild(node, null, out parent);
        }
        public Node FindNextFirstChild(Node nodeNext, Node curChild, out Node parent)
        {
            parent = null;
            Node head = nodeNext;
            while (head != null)
            {
                if (head.left == null && head.right == null)
                    head = head.next;
                else if (curChild != null && head.left == curChild && head.right == null)
                {
                    head = head.next;
                }
                else if (curChild != null && head.right == curChild)
                {
                    head = head.next;
                }
                else
                {
                    parent = head;
                    return head.left == null ? head.right : (curChild != null && head.left == curChild ? head.right : head.left);

                }
            }
            return null;
        }
        #endregion
    }
    // @lc code=end


}
