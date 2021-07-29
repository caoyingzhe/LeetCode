using System;
using System.Collections.Generic;
namespace CSharpConsoleApp.Solutions
{
    /*
     * @lc app=leetcode.cn id=450 lang=csharp
     *
     * [450] 删除二叉搜索树中的节点
     *
     * https://leetcode-cn.com/problems/delete-node-in-a-bst/description/
     *
     * Category	Difficulty	Likes	Dislikes
     * algorithms	Medium (47.81%)	475	-
     * Tags
     * tree
     * 
     * Companies
     * uber
     * 
     * Total Accepted:    48.3K
     * Total Submissions: 101K
     * Testcase Example:  '[5,3,6,2,4,null,7]\n3'
     *
     * 给定一个二叉搜索树的根节点 root 和一个值 key，删除二叉搜索树中的 key
     * 对应的节点，并保证二叉搜索树的性质不变。返回二叉搜索树（有可能被更新）的根节点的引用。
     * 
     * 一般来说，删除节点可分为两个步骤：
     * 
     * 
     * 首先找到需要删除的节点；
     * 如果找到了，删除它。
     * 
     * 
     * 说明： 要求算法时间复杂度为 O(h)，h 为树的高度。
     * 
     * 示例:
     * 
     * 
     * root = [5,3,6,2,4,null,7]
     * key = 3
     * 
     * ⁠   5
     * ⁠  / \
     * ⁠ 3   6
     * ⁠/ \   \
     * 2   4   7
     * 
     * 给定需要删除的节点值是 3，所以我们首先找到 3 这个节点，然后删除它。
     * 
     * 一个正确的答案是 [5,4,6,2,null,null,7], 如下图所示。
     * 
     * ⁠   5
     * ⁠  / \
     * ⁠ 4   6
     * ⁠/     \
     * 2       7
     * 
     * 另一个正确答案是 [5,2,6,null,4,null,7]。
     * 
     * ⁠   5
     * ⁠  / \
     * ⁠ 2   6
     * ⁠  \   \
     * ⁠   4   7
     * 
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
    public class Solution450 : SolutionBase
    {
        /// <summary>
        /// 难度
        /// </summary>
        public override Difficulity GetDifficulity() { return Difficulity.Hard; }
        /// <summary>
        /// 关键字:
        /// </summary>
        public override string[] GetKeyWords() { return new string[] { "向内扩展螺旋状", "向外扩展螺旋状" }; }
        /// <summary>
        /// 标签：
        /// </summary>
        public override Tag[] GetTags() { return new Tag[] { Tag.Math }; }

        
        public override bool Test(System.Diagnostics.Stopwatch sw)
        {
            bool isSuccess = true;
            TreeNode root; int key;
            TreeNode result, checkResult;

            root = TreeNode.Create(new int[] { 5, 3, 6, 2, 4, NULL, 7 }, NULL);
            key = 3;
            checkResult = TreeNode.Create(new int[] { 5, 4, 6, 2, NULL, NULL, 7 }, NULL);
            //checkResult = TreeNode.Create(new int[] { 5, 2, 6, NULL, 4, NULL, 7 }, NULL);
            result = DeleteNode(root, key);
            isSuccess &= IsSame(result, checkResult);
            PrintResult(isSuccess, (result).GetNodeString(true), (checkResult).GetNodeString(true));

            return isSuccess;
        }

        /// <summary>
        /// 作者：Terry2020
        /// 链接：https://leetcode-cn.com/problems/delete-node-in-a-bst/solution/miao-dong-jiu-wan-shi-liao-by-terry2020-tc0o/
        /// 
        /// 根据二叉搜索树的性质
        /// 
        /// 如果目标节点大于当前节点值，则去右子树中删除；
        /// 如果目标节点小于当前节点值，则去左子树中删除；
        /// 如果目标节点就是当前节点，分为以下三种情况：
        ///
        /// 其无左子：
        ///     其右子顶替其位置，删除了该节点；
        /// 其无右子：
        ///     其左子顶替其位置，删除了该节点；
        /// 其左右子节点都有：
        ///     其左子树转移到其右子树的最左节点的左子树上，
        ///     然后右子树顶替其位置，由此删除了该节点。
        /// 
        /// </summary>
        /// <param name="root"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public TreeNode DeleteNode_NG(TreeNode root, int key)
        {
            if (root == null) return null;
            if (key > root.val)
                root.right = DeleteNode_NG(root.right, key); // 去右子树删除
            else if (key < root.val)
                root.left = DeleteNode_NG(root.left, key);   // 去左子树删除
            else                                          // 当前节点就是要删除的节点
            {
                // 情况1，欲删除节点无左子
                if (root.left != null)
                    return root.right; 

                // 情况2，欲删除节点无右子
                if (root.right != null)
                    return root.left;  

                // 情况3，欲删除节点左右子都有 
                TreeNode node = root.right;           
                while (node.left != null)          // 寻找欲删除节点右子树的最左节点
                    node = node.left;
                node.left = root.left;             // 将欲删除节点的左子树成为其右子树的最左节点的左子树
                root = root.right;                 // 欲删除节点的右子顶替其位置，节点被删除
            }
            return root;
        }

        /// <summary>
        /// 作者：Booooo_
        /// 链接：https://leetcode-cn.com/problems/delete-node-in-a-bst/solution/shan-chu-er-cha-sou-suo-shu-zhong-de-jie-nitz/
        /// 91/91 cases passed (100 ms)
        /// Your runtime beats 95.12 % of csharp submissions
        /// Your memory usage beats 51.22 % of csharp submissions(29.9 MB)
        /// </summary>
        /// <param name="root"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public TreeNode DeleteNode(TreeNode root, int key)
        {
            if (root == null) return null;
            if (root.val == key)
            {
                //情况 1 ： 当待删除的节点的度为 0 时， 删除后并不影响 BSTBST 结构的特性，所有可以直接删除；
                if (root.left == null) return root.right; // 情况 1 和 2
                //情况 2 ：当待删除的节点的度为 1 时，
                //该节点有右子树/左子树，删除该节点后，为了维持 BSTBST 结构的特性，
                //需要将其右子树/左子树 "上移" 到删除节点的位置，
                //要让这个孩子来接替自己的位置；
                if (root.right == null) return root.left;

                // 情况 3 ： 当待删除的节点的度为 2 时，该节点有左、右子树
                // 删除节点后，为了维持 BSTBST 的结构特性，需从其左子树中选出一个最大值节点
                //（或从右子树中选出一个最小值节点）"上移" 到删除的节点的位置上。
                TreeNode minNode = GetMin(root.right);
                root.val = minNode.val;
                root.right = DeleteNode(root.right, minNode.val);
            }
            else if (root.val > key)
            {

                root.left = DeleteNode(root.left, key);
            }
            else
            {

                root.right = DeleteNode(root.right, key);
            }

            return root;
        }

        /// <summary>
        /// 找到子树的最小节点
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        private TreeNode GetMin(TreeNode node)
        {
            while (node.left != null) node = node.left;
            return node;
        }
    }
    // @lc code=end


}
