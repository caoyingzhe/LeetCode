using System;
using System.Collections.Generic;
namespace CSharpConsoleApp.Solutions
{
    /*
     * @lc app=leetcode.cn id=106 lang=csharp
     *
     * [106] 从中序与后序遍历序列构造二叉树
     *
     * https://leetcode-cn.com/problems/construct-binary-tree-from-inorder-and-postorder-traversal/description/
     *
     * Category	Difficulty	Likes	Dislikes
     * algorithms	Medium (71.93%)	524	-
     * Tags
     * array | tree | depth-first-search
     * 
     * Companies
     * microsoft
     * 
     * Total Accepted:    113.7K
     * Total Submissions: 158.1K
     * Testcase Example:  '[9,3,15,20,7]\n[9,15,7,20,3]'
     *
     * 根据一棵树的中序遍历与后序遍历构造二叉树。
     * 
     * 注意:
     * 你可以假设树中没有重复的元素。
     * 
     * 例如，给出
     * 
     * 中序遍历 inorder = [9,3,15,20,7]
     * 后序遍历 postorder = [9,15,7,20,3]
     * 
     * 返回如下的二叉树：
     * 
     * ⁠   3
     * ⁠  / \
     * ⁠ 9  20
     * ⁠   /  \
     * ⁠  15   7
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
    public class Solution106 : SolutionBase
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

        ///「105. 从前序与中序遍历序列构造二叉树」
        ///
        //// 中序遍历
        //void inorder(TreeNode* root)
        //{
        //    if (root == nullptr)
        //    {
        //        return;
        //    }
        //    inorder(root->left);
        //    ans.push_back(root->val);
        //    inorder(root->right);
        //}
        //// 后序遍历
        //void postorder(TreeNode* root)
        //{
        //    if (root == nullptr)
        //    {
        //        return;
        //    }
        //    postorder(root->left);
        //    postorder(root->right);
        //    ans.push_back(root->val);
        //}
        //重点： 后序遍历的数组最后一个元素代表的即为根节点
        //作者：LeetCode-Solution
        //链接：https://leetcode-cn.com/problems/construct-binary-tree-from-inorder-and-postorder-traversal/solution/cong-zhong-xu-yu-hou-xu-bian-li-xu-lie-gou-zao-14/

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
            inorder = new int[] { 9, 3, 15, 20, 7 };
            postorder = new int[] { 9, 15, 7, 20, 3 };
            result = BuildTree(inorder, postorder);
            checkResult = TreeNode.Create(new int[] { 3,9,20,NULL, NULL, 15,17 }, NULL);

            isSuccess &= IsSame(result, checkResult);
            PrintResult(isSuccess, (result).GetNodeString(true), (checkResult).GetNodeString(true));
            return isSuccess;
        }

        //跟节点在中序遍历数组中的下标
        int post_idx;

        /// <summary>
        /// 202/202 cases passed (116 ms)
        /// Your runtime beats 84.06 % of csharp submissions
        /// Your memory usage beats 53.62 % of csharp submissions(26.7 MB)
        /// </summary>
        /// <param name="inorder"></param>
        /// <param name="postorder"></param>
        /// <returns></returns>
        public TreeNode BuildTree(int[] inorder, int[] postorder)
        {
            // 从后序遍历的最后一个元素开始
            post_idx = postorder.Length - 1;

            // 建立（元素，下标）键值对的哈希表
            int idx = 0;
            //[元素-下标]键值对的哈希表，用于高效查找根节点元素在中序遍历数组中的下标，存储中序序列数据。
            Dictionary<int, int> idx_map = new Dictionary<int, int>();
            foreach (int val in inorder)
            {
                idx_map[val] = idx++;
            }
            return helper(0, inorder.Length - 1, inorder, postorder, idx_map);
        }

        //作者：LeetCode-Solution
        //链接：https://leetcode-cn.com/problems/construct-binary-tree-from-inorder-and-postorder-traversal/solution/cong-zhong-xu-yu-hou-xu-bian-li-xu-lie-gou-zao-14/
        /// <summary>
        /// 根据 中序遍历数组 和 后序遍历数组 寻找根节点
        /// </summary>
        /// <param name="in_left">左边索引</param>
        /// <param name="in_right">右边索引</param>
        /// <param name="inorder">中序遍历数组</param>
        /// <param name="postorder">后序遍历数组</param>
        /// <param name="idx_map">
        ///     [元素-下标]键值对的哈希表， 用于高效查找根节点元素在中序遍历数组中的下标，存储中序序列数据。
        /// </param>
        /// <returns></returns>
        public TreeNode helper(int in_left, int in_right,  int[] inorder, int[] postorder, Dictionary<int, int> idx_map)
        {
            // 如果这里没有节点构造二叉树了，就结束
            if (in_left > in_right)
            {
                return null;
            }

            // 选择 post_idx 位置的元素作为当前子树根节点
            int root_val = postorder[post_idx];
            TreeNode root = new TreeNode(root_val);

            // 根据 root 所在位置分成左右两棵子树
            int index = idx_map[root_val];

            // 下标减一
            post_idx--;
            // 构造右子树
            root.right = helper(index + 1, in_right, inorder, postorder, idx_map);
            // 构造左子树
            root.left = helper(in_left, index - 1, inorder, postorder, idx_map);
            return root;
        }


    }
    // @lc code=end


}
