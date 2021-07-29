using System;
using System.Collections.Generic;
namespace CSharpConsoleApp.Solutions
{
    /*
     * @lc app=leetcode.cn id=559 lang=csharp
     *
     * [559] N 叉树的最大深度
     *
     * https://leetcode-cn.com/problems/maximum-depth-of-n-ary-tree/description/
     *

     * Category	Difficulty	Likes	Dislikes
     * algorithms	Easy (72.49%)	179	-
     * Tags
     * Unknown
     * 
     * Companies
     * Unknown
     * 
     * Total Accepted:    55.8K
     * Total Submissions: 76.9K
     * Testcase Example:  '[1,null,3,2,4,null,5,6]'
     *
     * 给定一个 N 叉树，找到其最大深度。
     * 最大深度是指从根节点到最远叶子节点的最长路径上的节点总数。
     * N 叉树输入按层序遍历序列化表示，每组子节点由空值分隔（请参见示例）。
     * 
     * 示例 1：
     * 输入：root = [1,null,3,2,4,null,5,6]
     * 输出：3
     * 
     * 示例 2：
     * 输入：root =
     * [1,null,2,3,4,5,null,null,6,7,null,8,null,9,10,null,null,11,null,12,null,13,null,null,14]
     * 输出：5
     * 
     * 提示：
     * 树的深度不会超过 1000 。
     * 树的节点数目位于 [0, 10^4] 之间。
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

        public Node(int _val, IList<Node> _children) {
            val = _val;
            children = _children;
        }
    }
    */

    public class Solution559 : SolutionBase
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

        public const int N = int.MinValue;
        /// <summary>
        /// </summary>
        /// <param name="sw"></param>
        /// <returns></returns>
        public override bool Test(System.Diagnostics.Stopwatch sw)
        {
            bool isSuccess = true;
            return isSuccess;
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
        /// 38/38 cases passed (320 ms)
        /// Your runtime beats 70.59 % of csharp submissions
        /// Your memory usage beats 5.88 % of csharp submissions(33.9 MB)
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public int MaxDepth_My(Node root)
        {
            if (root == null) return 0;
            return DFS(root, 1);
        }
        public int DFS(Node root, int depth)
        {
            if (root == null)
                return depth;

            int maxDepth = depth;
            foreach(Node child in root.children)
            {
                maxDepth = Math.Max(maxDepth, DFS(child, depth+1));
            }
            return maxDepth;
        }

        //作者：windmajor
        //链接：https://leetcode-cn.com/problems/maximum-depth-of-n-ary-tree/solution/chao-100-java-di-gui-xie-fa-jiang-jie-ji-huwe/
        /// <summary>
        /// 38/38 cases passed (256 ms)
        /// Your runtime beats 98.04 % of csharp submissions
        /// Your memory usage beats 19.61 % of csharp submissions(32.9 MB)
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public int MaxDepth(Node root)
        {
            if (root == null) return 0;
            if (root.children == null || root.children.Count == 0) return 1;

            int max = 0;
            foreach (Node node in root.children)
            {
                max = Math.Max(MaxDepth(node), max);
            }
            return max + 1;
        }
    }
    // @lc code=end


}
