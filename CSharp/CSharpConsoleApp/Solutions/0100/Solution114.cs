using System;
using System.Collections.Generic;
namespace CSharpConsoleApp.Solutions
{
    /*
     * @lc app=leetcode.cn id=114 lang=csharp
     *
     * [114] 二叉树展开为链表
     *
     * https://leetcode-cn.com/problems/flatten-binary-tree-to-linked-list/description/
     *
     * algorithms
     * Medium (72.36%)
     * Likes:    830
     * Dislikes: 0
     * Total Accepted:    146.7K
     * Total Submissions: 202.7K
     * Testcase Example:  '[1,2,5,3,4,null,6]'
     *
     * 给你二叉树的根结点 root ，请你将它展开为一个单链表：
     * 
     * 
     * 展开后的单链表应该同样使用 TreeNode ，其中 right 子指针指向链表中下一个结点，而左子指针始终为 null 。
     * 展开后的单链表应该与二叉树 先序遍历 顺序相同。
     *
     * 
     * 示例 1：
     * 输入：root = [1,2,5,3,4,null,6]
     * 输出：[1,null,2,null,3,null,4,null,5,null,6]
     * 
     * 
     * 示例 2：
     * 输入：root = []
     * 输出：[]
     * 
     * 
     * 示例 3：
     * 输入：root = [0]
     * 输出：[0]
     *
     * 
     * 提示：
     * 树中结点数在范围 [0, 2000] 内
     * -100
     * 
     * 进阶：你可以使用原地算法（O(1) 额外空间）展开这棵树吗？
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
    public class Solution114 : SolutionBase
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

            TreeNode root;
            string result, checkResult;
            //      ⁠    1
            //      ⁠   /  \
            //       2      5
            //      /  \   / \
            //    3    4  N   6
            //root = TreeNode.Create(new int[] { 1, 2, 5, 3, 4, NULL, 6}, NULL);
            //checkResult = GetArrayStr(new int[] { 1, 2, 3, 4, 5, 6 });
            //Flatten(root);
            //result = root.GetNodeString(true);
            //isSuccess &= IsSame(result, checkResult);
            //PrintResult(isSuccess, (result), (checkResult));

            //      ⁠    1            ⁠    1
            //      ⁠   /  \             / \
            //       2      N          N   2
            //      /  \                    \  
            //    3    4                     3     
            //   /                            \
            //  5                              5
            //                                  \
            //                                   4

            //根据此TestCase，得出此题是要求按前序编列。
            //Testcase        [1,2,null,3,4,5]
            //My       Answer [1,null,2,null,3,null,4,null,5]
            //Expected Answer [1,null,2,null,3,null,5,null,4]
            root = TreeNode.Create(new int[] { 1, 2, NULL, 3, 4, NULL, NULL, 5 }, NULL);
            checkResult = GetArrayStr(new int[] { 1, 2, 3, 5, 4 });
            Flatten(root);
            result = root.GetNodeString(true);
            isSuccess &= IsSame(result, checkResult);
            PrintResult(isSuccess, (result), (checkResult));

            return isSuccess;
        }

        /// <summary>
        /// 225/225 cases passed (104 ms)
        /// Your runtime beats 95.45 % of csharp submissions
        /// Your memory usage beats 64.55 % of csharp submissions(25.1 MB)
        /// </summary>
        /// <param name="root"></param>
        public void Flatten(TreeNode root)
        {
            if (root == null) return;

            List<TreeNode> list = new List<TreeNode>();
            GetNodeList(root, list, true);

            //list.Sort((a,b) =>  a.val - b.val);
            for (int i = 1; i < list.Count; i++)
            {
                list[i - 1].left = null;
                list[i - 1].right = list[i];
            }
            list[list.Count - 1].left = null;
            list[list.Count - 1].right = null;
        }

        /// <summary>
        /// 取得所有的Node列表 (返回结果已经是按照 左序排列）
        /// </summary>
        /// <param name="node"></param>
        /// <param name="nodeList"></param>
        /// <param name="nodeList"></param>
        public void GetNodeList(TreeNode node, List<TreeNode> nodeList, bool noAddNullNode = false)
        {
            if (node == null)
            {
                if (!noAddNullNode)
                    nodeList.Add(node);
                return;
            }
            //前序编列
            nodeList.Add(node);
            GetNodeList(node.left, nodeList, noAddNullNode);
            GetNodeList(node.right, nodeList, noAddNullNode);
        }
    }
    // @lc code=end


}
