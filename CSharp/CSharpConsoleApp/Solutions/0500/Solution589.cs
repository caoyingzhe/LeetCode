using System;
using System.Collections.Generic;
using Node = CSharpConsoleApp.Solutions.SolutionBase.NodeN.Node;
namespace CSharpConsoleApp.Solutions
{
    /*
     * @lc app=leetcode.cn id=589 lang=csharp
     *
     * [589] N 叉树的前序遍历
     *
     * https://leetcode-cn.com/problems/n-ary-tree-preorder-traversal/description/
     *
     * Category	Difficulty	Likes	Dislikes
     * algorithms	Easy (74.37%)	170	-
     * Tags
     * Unknown
     * 
     * Companies
     * Unknown
     * 
     * Total Accepted:    83K
     * Total Submissions: 111.5K
     * Testcase Example:  '[1,null,3,2,4,null,5,6]'
     *
     * 给定一个 N 叉树，返回其节点值的 前序遍历 。
     * 
     * N 叉树 在输入中按层序遍历进行序列化表示，每组子节点由空值 null 分隔（请参见示例）。
     * 
     * 
     * 进阶：
     * 递归法很简单，你可以使用迭代法完成此题吗?
     *
     * 
     * 示例 1：
     * 输入：root = [1,null,3,2,4,null,5,6]
     * 输出：[1,3,5,6,2,4]
     * 
     * 示例 2：
     * 输入：root =
     * [1,null,2,3,4,5,null,null,6,7,null,8,null,9,10,null,null,11,null,12,null,13,null,null,14]
     * 输出：[1,2,3,6,7,11,14,4,8,12,5,9,13,10]
     * 
     * 
     * 提示：
     * N 叉树的高度小于或等于 1000
     * 节点总数在范围 [0, 10^4] 内
     */

    // @lc code=start
    /*
    // Definition for a Node.
    public class Node {
        public int val;
        public IList<Node> children;

        public Node() {}

        public Node(int _val) {
            val = _val;
        }

        public Node(int _val,IList<Node> _children) {
            val = _val;
            children = _children;
        }
    }
    */

    public class Solution589 : SolutionBase
    {
        /// <summary>
        /// 难度
        /// </summary>
        public override Difficulity GetDifficulity() { return Difficulity.Easy; }
        /// <summary>
        /// 关键字:
        /// </summary>
        public override string[] GetKeyWords() { return new string[] { }; }
        /// <summary>
        /// 标签：
        /// </summary>
        public override Tag[] GetTags() { return new Tag[] { Tag.Tree }; }

        /// <summary>
        /// </summary>
        /// <param name="sw"></param>
        /// <returns></returns>
        public override bool Test(System.Diagnostics.Stopwatch sw)
        {
            return true;
        }

        public class Node
        {
            public int val;
            public IList<Node> children;

            public Node() { }

            public Node(int _val)
            {
                val = _val;
            }

            public Node(int _val, IList<Node> _children)
            {
                val = _val;
                children = _children;
            }
        }

        /// <summary>
        /// 38/38 cases passed (308 ms)
        /// runtime beats 72.92 % of csharp submissions
        /// Your memory usage beats 100 % of csharp submissions(33.7 MB)
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public IList<int> Preorder(Node root)
        {
            List<int> list = new List<int>();
            DFS(root, list);
            return list;
        }
        public void DFS(Node root, List<int> list)
        {
            if (root == null)
                return;

            list.Add(root.val);
            foreach(var child in root.children)
            {
                DFS(child, list);
            }
        }
    }
    // @lc code=end


}
