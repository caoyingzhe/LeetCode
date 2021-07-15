using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace CSharpConsoleApp.Solutions
{
    /*
 * @lc app=leetcode.cn id=116 lang=csharp
 *
 * [116] 填充每个节点的下一个右侧节点指针
 *
 * https://leetcode-cn.com/problems/populating-next-right-pointers-in-each-node/description/
 *
 * Category	Difficulty	Likes	Dislikes
 * algorithms	Medium (69.73%)	476	-
 * Tags
 * tree | depth-first-search
 * 
 * Companies
 * microsoft
 * 
 * Total Accepted:    125.3K
 * Total Submissions: 179.6K
 * Testcase Example:  '[1,2,3,4,5,6,7]'
 *
 * 给定一个 完美二叉树 ，其所有叶子节点都在同一层，每个父节点都有两个子节点。二叉树定义如下：
 * struct Node {
 * ⁠ int val;
 * ⁠ Node *left;
 * ⁠ Node *right;
 * ⁠ Node *next;
 * }
 * 
 * 填充它的每个 next 指针，让这个指针指向其下一个右侧节点。如果找不到下一个右侧节点，则将 next 指针设置为 NULL。
 * 
 * 初始状态下，所有 next 指针都被设置为 NULL。
 * 
 * 
 * 进阶：
 * 你只能使用常量级额外空间。
 * 使用递归解题也符合要求，本题中递归程序占用的栈空间不算做额外的空间复杂度。
 * 
 * 
 * 示例：
 * 输入：root = [1,2,3,4,5,6,7]
 * 输出：[1,#,2,3,#,4,5,6,7,#]
 * 解释：给定二叉树如图 A 所示，你的函数应该填充它的每个 next 指针，以指向其下一个右侧节点，如图 B
 * 所示。序列化的输出按层序遍历排列，同一层节点由 next 指针连接，'#' 标志着每一层的结束。
 * 
 * 
 * 提示：
 * 树中节点的数量少于 4096
 * -1000 <= node.val <= 1000 
 */

    // @lc code=start
    /*
    // Definition for a Node.*/
    

    public class Solution116 : SolutionBase
    {
        /// <summary>
        /// 难度
        /// </summary>
        public override Difficulity GetDifficulity() { return Difficulity.Medium; }
        /// <summary>
        /// 关键字:
        /// </summary>
        public override string[] GetKeyWords() { return new string[] { "中序遍历", "后序遍历", "[105] 从前序与中序遍历序列构造二叉树" }; }
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
            Print(ComplexNumberMultiply("1+1i", "1+1i"));
            Print(ComplexNumberMultiply("1+-1i", "1+-1i"));
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

        //https://leetcode-cn.com/problems/populating-next-right-pointers-in-each-node/solution/tian-chong-mei-ge-jie-dian-de-xia-yi-ge-you-ce-2-4/
        /// <summary>
        /// 使用已建立的 next 指针
        /// 58/58 cases passed (120 ms)
        /// Your runtime beats 72.45 % of csharp submissions
        /// Your memory usage beats 92.86 % of csharp submissions(29.2 MB)
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public Node Connect(Node root)
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
                    head.left.next = head.right;

                    // CONNECTION 2
                    if (head.next != null)
                    {
                        head.right.next = head.next.left;
                    }
                    // 指针向后移动
                    head = head.next;
                }
                // 去下一层的最左的节点
                leftmost = leftmost.left;
            }
            return root;
        }

        /// <summary>
        /// 55/55 cases passed (112 ms)
        /// Your runtime beats 41.67 % of csharp submissions
        /// Your memory usage beats 100 % of csharp submissions(22.5 MB)
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public string ComplexNumberMultiply(string a, string b)
        {
            //using System.Text.RegularExpressions;
            //正则表达式
            //string[] x = Regex.Split(a, "\\+|i", RegexOptions.IgnoreCase);
            //string[] y = Regex.Split(b, "\\+|i", RegexOptions.IgnoreCase);

            string[] x = a.Remove(a.Length-1).Split('+');
            string[] y = b.Remove(b.Length - 1).Split('+');
            int a_real = int.Parse(x[0].ToString());
            int a_img = int.Parse(x[1].ToString());
            int b_real = int.Parse(y[0].ToString());
            int b_img = int.Parse(y[1].ToString());
            Print("{0} | {1} | {2} | {3} ", a_real, a_img, b_real, b_img);
            return (a_real * b_real - a_img * b_img) + "+" + (a_real * b_img + a_img * b_real) + "i";
        }

//        作者：Code_respect
//        链接：https://leetcode-cn.com/problems/complex-number-multiplication/solution/javazi-fu-chuan-chu-li-by-code_respect-vpc0/
    }
    // @lc code=end


}
