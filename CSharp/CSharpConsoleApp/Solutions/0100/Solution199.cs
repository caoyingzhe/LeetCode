using System;
using System.Collections.Generic;
namespace CSharpConsoleApp.Solutions
{
    /*
     * @lc app=leetcode.cn id=199 lang=csharp
     *
     * [199] 二叉树的右视图
     *
     * https://leetcode-cn.com/problems/binary-tree-right-side-view/description/
     *
     * Category	Difficulty	Likes	Dislikes
     * algorithms	Medium (64.89%)	483	-
     * Tags
     * tree | depth-first-search | breadth-first-search
     * 
     * Companies
     * amazon
     * 
     * Total Accepted:    115K
     * Total Submissions: 177.3K
     * Testcase Example:  '[1,2,3,null,5,null,4]'
     *
     * 给定一棵二叉树，想象自己站在它的右侧，按照从顶部到底部的顺序，返回从右侧所能看到的节点值。
     * 
     * 示例:
     * 
     * 输入: [1,2,3,null,5,null,4]
     * 输出: [1, 3, 4]
     * 解释:
     * 
     * ⁠  1            <---
     * ⁠/   \
     * 2     3         <---
     * ⁠\     \
     * ⁠ 5     4       <---
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
    public class Solution199 : SolutionBase
    {
        /// <summary>
        /// 难度
        /// </summary>
        public override Difficulity GetDifficulity() { return Difficulity.Medium; }
        /// <summary>
        /// 关键字:
        /// </summary>
        public override string[] GetKeyWords() { return new string[] { "", }; }
        /// <summary>
        /// 标签：
        /// </summary>
        public override Tag[] GetTags() { return new Tag[] { Tag.Tree,  Tag.BreadthFirstSearch, Tag.DepthFirstSearch}; }

        const int NULL = int.MinValue;
        /// <summary>
        /// </summary>
        /// <param name="sw"></param>
        /// <returns></returns>
        public override bool Test(System.Diagnostics.Stopwatch sw)
        {
            bool isSuccess = true;
            //
            var result = RightSideView(TreeNode.Create(new int[] { 1, 2, 3, NULL, 5, NULL, 4 }, NULL));
            Print(GetArrayStr(result));

            return isSuccess;
        }
        //作者：moao
        //链接：https://leetcode-cn.com/problems/binary-tree-right-side-view/solution/dfsan-shen-du-fen-ceng-da-yin-mei-yi-cen-ttuq/
        /// <summary>
        /// 215/215 cases passed (284 ms)
        /// Your runtime beats 53.52 % of csharp submissions
        /// Your memory usage beats 12.67 % of csharp submissions(30.8 MB)
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public IList<int> RightSideView(TreeNode root)
        {
            List<int> ans = new List<int>();
            if (root == null) return ans;
            DFS(root, 1);
            for (int i = 1; i <= maxDepth; i++)
                ans.Add (layer[i][layer[i].Count - 1].val);
            return ans;
        }

        Dictionary<int, List<TreeNode>> layer = new Dictionary<int, List<TreeNode>>();
        int maxDepth = 0;
        void DFS(TreeNode root, int depth)
        {
            maxDepth = Math.Max(maxDepth, depth);

            if (!layer.ContainsKey(depth))
                layer.Add(depth, new List<TreeNode>());
            layer[depth].Add(root);

            if (root.left != null) DFS(root.left, depth + 1);
            if (root.right != null) DFS(root.right, depth + 1);
        }
    }
}
