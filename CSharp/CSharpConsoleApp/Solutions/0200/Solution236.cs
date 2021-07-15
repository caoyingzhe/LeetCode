using System;
using System.Collections.Generic;
namespace CSharpConsoleApp.Solutions
{
    /*
     * @lc app=leetcode.cn id=236 lang=csharp
     *
     * [236] 二叉树的最近公共祖先
     *
     * https://leetcode-cn.com/problems/lowest-common-ancestor-of-a-binary-tree/description/
     *
     * Category	Difficulty	Likes	Dislikes
     * algorithms	Medium (67.39%)	1164	-
     * Tags
     * tree
     * 
     * Companies
     * amazon | apple | facebook | linkedin | microsoft
     * 
     * Total Accepted:    212.2K
     * Total Submissions: 314.9K
     * Testcase Example:  '[3,5,1,6,2,0,8,null,null,7,4]\n5\n1'
     *
     * 给定一个二叉树, 找到该树中两个指定节点的最近公共祖先。
     * 
     * 百度百科中最近公共祖先的定义为：“对于有根树 T 的两个节点 p、q，最近公共祖先表示为一个节点 x，满足 x 是 p、q 的祖先且 x
     * 的深度尽可能大（一个节点也可以是它自己的祖先）。”
     * 
     * 
     * 示例 1：
     * 输入：root = [3,5,1,6,2,0,8,null,null,7,4], p = 5, q = 1
     * 输出：3
     * 解释：节点 5 和节点 1 的最近公共祖先是节点 3 。
     * 
     * 
     * 示例 2：
     * 输入：root = [3,5,1,6,2,0,8,null,null,7,4], p = 5, q = 4
     * 输出：5
     * 解释：节点 5 和节点 4 的最近公共祖先是节点 5 。因为根据定义最近公共祖先节点可以为节点本身。
     * 
     * 
     * 示例 3：
     * 输入：root = [1,2], p = 1, q = 2
     * 输出：1
     *
     * 
     * 提示：
     * 树中节点数目在范围 [2, 10^5] 内。
     * -109 <= Node.val <= 109
     * 所有 Node.val 互不相同 。
     * p != q
     * p 和 q 均存在于给定的二叉树中。
     */

    // @lc code=start
    /**
     * Definition for a binary tree node.
     * public class TreeNode {
     *     public int val;
     *     public TreeNode left;
     *     public TreeNode right;
     *     public TreeNode(int x) { val = x; }
     * }
     */
    public class Solution236 : SolutionBase
    {
        /// <summary>
        /// 难度
        /// </summary>
        public override Difficulity GetDifficulity() { return Difficulity.Medium; }
        /// <summary>
        /// 关键字:
        /// </summary>
        public override string[] GetKeyWords() { return new string[] { "Solution34 并集", }; }
        /// <summary>
        /// 标签：
        /// </summary>
        public override Tag[] GetTags() { return new Tag[] { Tag.Tree, }; }

        const int NULL = int.MinValue;
        /// <summary>
        /// </summary>
        /// <param name="sw"></param>
        /// <returns></returns>
        public override bool Test(System.Diagnostics.Stopwatch sw)
        {
            bool isSuccess = true;
            TreeNode root, p, q;
            List<TreeNode> list;

            //*         3
            //*      /     \
            //*    5        1
            //*   / \      / \
            //*  6    2   0   8
            //  / \  / \ 
            //* N N  7 4

            root = TreeNode.Create(new int[] { 3, 5, 1, 6, 2, 0, 8, NULL, NULL, 7, 4 }, NULL);
            list = root.GetNodeList(true);
            p = list.Find(a => a.val == 5);
            q = list.Find(a => a.val == 1);

            TreeNode result; int checkResult = 3;

            result = LowestCommonAncestor(root, p, q);
            isSuccess &= IsSame(result.val, checkResult);
            PrintResult(isSuccess, result.val, checkResult);

            return isSuccess;
        }
        public TreeNode LowestCommonAncestor(TreeNode root, TreeNode p, TreeNode q)
        {
            this.DFS(root, p, q);
            return this.ans;
        }
        private TreeNode ans;
        //作者：LeetCode-Solution
        //链接：https://leetcode-cn.com/problems/lowest-common-ancestor-of-a-binary-tree/solution/er-cha-shu-de-zui-jin-gong-gong-zu-xian-by-leetc-2/
        /// <summary>
        /// 31/31 cases passed (124 ms)
        /// Your runtime beats 67.5 % of csharp submissions
        /// Your memory usage beats 77.5 % of csharp submissions(28.1 MB)
        /// </summary>
        /// <param name="root"></param>
        /// <param name="p"></param>
        /// <param name="q"></param>
        /// <returns></returns>
        private bool DFS(TreeNode root, TreeNode p, TreeNode q)
        {
            if (root == null) return false;
            bool lson = DFS(root.left, p, q);
            bool rson = DFS(root.right, p, q);

            if ((lson && rson) ||                                             // 左孩子和右孩子都找到了
                ((root.val == p.val || root.val == q.val) && (lson || rson))) //root节点正好是 p/q 之一，并且 在左边或右边已经找到 p/q
            {
                //第二个判定条件的意思是，暂且先找到一个p或者q的临时父节点
                //从底部开始搜索，暂时设定为先找到的父节点，逐级向上，最后达成第一个条件， 更新共同的祖先 ？？
                ans = root;
            }
            return lson || rson || (root.val == p.val || root.val == q.val); //root节点正好是 p/q 之一，或者 在左边或右边已经找到 p/q
        }

        //TODO
        #region ----- MySolution  NG -----------
        List<TreeNode> parents_p = new List<TreeNode>();
        List<TreeNode> parents_q = new List<TreeNode>();
        bool find_q = false, find_p = false;
        public TreeNode LowestCommonAncestor_MY(TreeNode root, TreeNode p, TreeNode q)
        {
            GetParent(root, p, q);

            int m = parents_p.Count;
            int n = parents_q.Count;

            int len1 = 0, len2 = 0;
            TreeNode lastSameNode = null;
            while (len1 < m && len2 < n)
            {
                if (parents_p[len1] == parents_q[len2])
                {
                    lastSameNode = parents_p[len1];
                }
                else 
                {
                    if (lastSameNode != null)
                        break;
                }

                len1 = Math.Min(len1 + 1, m - 1);
                len2 = Math.Min(len2 + 1, n - 1);

                if(len1 == m - 1 && len2 == n-1)
                    break;
            }
            return lastSameNode;
        }

        //TODO 获取父对象列表
        public void GetParent(TreeNode root, TreeNode p, TreeNode q)
        {
            if (root == null) return;

            if(!find_p)
                parents_p.Add(root);
            if(!find_q)
                parents_q.Add(root);

            if (p == root)
            { parents_p.Add(root); find_p = true; }
            if (q == root)
            { parents_q.Add(root); find_q = true; }

            if (find_p && find_q)
                return;

            GetParent(root.left, p, q);

            GetParent(root.right, p, q);

            if (!find_p)
                parents_p.Add(root);
            if (!find_q)
                parents_q.Add(root);
        }
        #endregion
    }
    // @lc code=end


}
