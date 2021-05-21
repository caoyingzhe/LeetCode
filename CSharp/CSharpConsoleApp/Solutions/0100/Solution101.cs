using System;
using System.Collections.Generic;
namespace CSharpConsoleApp.Solutions
{
    /*
     * @lc app=leetcode.cn id=101 lang=csharp
     *
     * [101] 对称二叉树
     *
     * https://leetcode-cn.com/problems/symmetric-tree/description/
     *
     * algorithms
     * Easy (54.93%)
     * Likes:    1385
     * Dislikes: 0
     * Total Accepted:    325.3K
     * Total Submissions: 591.9K
     * Testcase Example:  '[1,2,2,3,4,4,3]'
     *
     * 给定一个二叉树，检查它是否是镜像对称的。
     * 
     * 
     * 
     * 例如，二叉树 [1,2,2,3,4,4,3] 是对称的。
     * 
     * ⁠   1
     * ⁠  / \
     * ⁠ 2   2
     * ⁠/ \ / \
     * 3  4 4  3
     * 
     * 
     * 
     * 
     * 但是下面这个 [1,2,2,null,3,null,3] 则不是镜像对称的:
     * 
     * ⁠   1
     * ⁠  / \
     * ⁠ 2   2
     * ⁠  \   \
     * ⁠  3    3
     * 
     * 
     * 
     * 
     * 进阶：
     * 
     * 你可以运用递归和迭代两种方法解决这个问题吗？
     * 
     */

    // @lc code=start
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
    public class Solution101 : SolutionBase
    {
        public override bool Test(System.Diagnostics.Stopwatch sw)
        {
            TreeNode node = TreeNode.Create(new string[] { "7", "1", "5", "3", "6", "4" });
            Print("" + IsSymmetric(node));
            return true;
        }

        /// <summary>
        /// 递归
        ///
        /// 196/196 cases passed (112 ms)
        /// Your runtime beats 57.43 % of csharp submissions
        /// Your memory usage beats 83.71 % of csharp submissions(24.9 MB)
        /// https://leetcode-cn.com/problems/symmetric-tree/solution/dui-cheng-er-cha-shu-by-leetcode-solution/
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public bool IsSymmetric(TreeNode root)
        {
            //return Check(root, root);
            return Check_Iterator(root, root);
        }

        public bool Check(TreeNode p, TreeNode q)
        {
            if (p == null && q == null)
            {
                return true;
            }
            if (p == null || q == null)
            {
                return false;
            }
            return p.val == q.val && Check(p.left, q.right) && Check(p.right, q.left);
        }

        /// <summary>
        /// 迭代  (比递归效率高）
        /// 196/196 cases passed (108 ms)
        /// Your runtime beats 82 % of csharp submissions
        /// Your memory usage beats 17.14 % of csharp submissions(25.3 MB)
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public bool Check_Iterator(TreeNode u, TreeNode v)
        {
            Queue<TreeNode> q = new Queue<TreeNode>();
            q.Enqueue(u);  //q.offer(u);  //List.AddLast(10);   
            q.Enqueue(v);  //q.offer(v);
            while (q.Count != 0)
            {
                u = q.Dequeue();  //u = q.poll();
                v = q.Dequeue();   //v = q.poll();

                if (u == null && v == null)
                {
                    continue;
                }
                if ((u == null || v == null) || (u.val != v.val))
                {
                    return false;
                }

                q.Enqueue(u.left); //q.offer(u.left);
                q.Enqueue(v.right); //q.offer(v.right);

                q.Enqueue(u.right); //q.offer(u.right);
                q.Enqueue(v.left); //q.offer(v.left);
            }
            return true;
        }
    }
}
