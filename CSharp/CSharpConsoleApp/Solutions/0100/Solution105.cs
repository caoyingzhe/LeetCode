using System;
using System.Collections.Generic;
namespace CSharpConsoleApp.Solutions
{
    /*
     * @lc app=leetcode.cn id=105 lang=csharp
     *
     * [105] 从前序与中序遍历序列构造二叉树
     *
     * https://leetcode-cn.com/problems/construct-binary-tree-from-preorder-and-inorder-traversal/description/
     *
     * Category	Difficulty	Likes	Dislikes
     * algorithms	Medium (69.96%)	1095	-
     * Tags
     * array | tree | depth-first-search
     * 
     * Companies
     * bloomberg
     * 
     * Total Accepted:    210.3K
     * Total Submissions: 300.6K
     * Testcase Example:  '[3,9,20,15,7]\n[9,3,15,20,7]'
     *
     * 根据一棵树的前序遍历与中序遍历构造二叉树。
     * 
     * 注意:
     * 你可以假设树中没有重复的元素。
     * 
     * 例如，给出
     * 
     * 前序遍历 preorder = [3,9,20,15,7]
     * 中序遍历 inorder = [9,3,15,20,7]
     * 
     * 返回如下的二叉树：
     * 
     * ⁠   3
     * ⁠  / \
     * ⁠ 9  20
     * ⁠   /  \
     * ⁠  15   7
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
    public class Solution105 : SolutionBase
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
        //重点： 前序遍历的数组第一个元素代表的即为根节点
        //      二叉树前序遍历的顺序为：
        //          先遍历根节点；
        //          随后递归地遍历左子树；
        //          最后递归地遍历右子树。

        public override bool Test(System.Diagnostics.Stopwatch sw)
        {
            bool isSuccess = true;

            int[] inorder, postorder;
            TreeNode result, checkResult;

            //      ⁠     0
            //      ⁠   /   \
            //       2       4
            //      /  \    /  \
            //    1     N   3   -1
            //   / \       / \  / \
            //  5   1     N  6  N  8
            //[0,2,4,1,null,3,-1,5,1,null,6,null,8]
            inorder = new int[] { 3, 9, 20, 15, 7 };
            postorder = new int[] { 9, 3, 15, 20, 7 };
            result = BuildTree(inorder, postorder);
            checkResult = TreeNode.Create(new int[] { 3, 9, 20, NULL, NULL, 15, 17 }, NULL);

            isSuccess &= IsSame(result, checkResult);
            PrintResult(isSuccess, (result).GetNodeString(true), (checkResult).GetNodeString(true));
            return isSuccess;
        }

        /// <summary>
        /// 作者：windliang
        /// 链接：https://leetcode-cn.com/problems/construct-binary-tree-from-preorder-and-inorder-traversal/solution/xiang-xi-tong-su-de-si-lu-fen-xi-duo-jie-fa-by--22/
        /// 202/202 cases passed (108 ms)
        /// Your runtime beats 97.04 % of csharp submissions
        /// Your memory usage beats 76.3 % of csharp submissions(26.5 MB)
        /// </summary>
        /// <param name="preorder"></param>
        /// <param name="inorder"></param>
        /// <returns></returns>
        public TreeNode BuildTree(int[] preorder, int[] inorder)
        {
            return buildTreeHelper(preorder, 0, preorder.Length, inorder, 0, inorder.Length);
        }

        /// <summary>
        /// 构建二叉树（by 前序遍历数组 + 中序遍历数组 ）
        /// </summary>
        /// <param name="preorder">前序遍历的数组</param>
        /// <param name="p_start">前序遍历的开始索引</param>
        /// <param name="p_end">前序遍历的结束索引</param>
        /// <param name="inorder">中序遍历的数组</param>
        /// <param name="i_start">中序遍历的开始索引</param>
        /// <param name="i_end">中序遍历的结束索引</param>
        /// <returns></returns>
        private TreeNode buildTreeHelper(int[] preorder, int p_start, int p_end, int[] inorder, int i_start, int i_end)
        {
            // preorder 为空，直接返回 null
            if (p_start == p_end)
            {
                return null;
            }

            //前序遍历的跟节点
            int root_val = preorder[p_start];
            TreeNode root = new TreeNode(root_val);
            //在中序遍历中找到根节点的位置
            int i_root_index = 0;
            for (int i = i_start; i < i_end; i++)
            {
                if (root_val == inorder[i])
                {
                    i_root_index = i;
                    break;
                }
            }

            //中序数组中，跟节点到开始节点的位置偏移
            int leftNum = i_root_index - i_start;
            //递归的构造左子树
            root.left = buildTreeHelper(preorder, p_start + 1, p_start + leftNum + 1, inorder, i_start, i_root_index);
            //递归的构造右子树
            root.right = buildTreeHelper(preorder, p_start + leftNum + 1, p_end, inorder, i_root_index + 1, i_end);
            return root;
        }
    }
}
