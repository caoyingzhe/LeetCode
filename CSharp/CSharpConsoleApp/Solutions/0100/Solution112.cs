using System;
using System.Collections.Generic;
namespace CSharpConsoleApp.Solutions
{
    /*
     * @lc app=leetcode.cn id=112 lang=csharp
     *
     * [112] 路径总和
     *
     * https://leetcode-cn.com/problems/path-sum/description/
     *
     * algorithms
     * Easy (52.33%)
     * Likes:    606
     * Dislikes: 0
     * Total Accepted:    221.4K
     * Total Submissions: 423.1K
     * Testcase Example:  '[5,4,8,11,null,13,4,7,2,null,null,null,1]\n22'
     *
     * 给你二叉树的根节点 root 和一个表示目标和的整数 targetSum ，判断该树中是否存在 根节点到叶子节点
     * 的路径，这条路径上所有节点值相加等于目标和 targetSum 。
     * 
     * 叶子节点 是指没有子节点的节点。
     * 
     * 
     * 示例 1：
     * 输入：root = [5,4,8,11,null,13,4,7,2,null,null,null,1], targetSum = 22
     * 输出：true
     * 
     * 
     * 示例 2：
     * 输入：root = [1,2,3], targetSum = 5
     * 输出：false
     * 
     * 
     * 示例 3：
     * 输入：root = [1,2], targetSum = 0
     * 输出：false
     * 
     * 
     * 提示：
     * 树中节点的数目在范围 [0, 5000] 内
     * -1000 
     * -1000 
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

    public class Solution112 : SolutionBase
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

            TreeNode root; int targetSum;
            bool result, checkResult;

            //      ⁠    5
            //      ⁠   /   \
            //       4        8
            //      /  \     /  \
            //    11    N   13   4
            //   / \   / \ / \
            //  7   2 N  N N  1 
            root = TreeNode.Create(new int[] { 5, 4, 8, 11, NULL, 13, 4, 7, 2, NULL, NULL, NULL, 1 }, NULL);
            targetSum = 22;
            checkResult = true;
            result = HasPathSum(root, targetSum);
            isSuccess &= IsSame(result, checkResult);
            PrintResult(isSuccess, (result), (checkResult));
            return isSuccess;
        }

        public bool HasPathSum(TreeNode root, int targetSum)
        {
            //return HasPathSum_DFS(root, targetSum); 
            return HasPathSum_BFS(root, targetSum);
        }
        /// <summary>
        /// 深度优先遍历
        /// 
        /// 时间复杂度：O(N)，其中 N 是树的节点数。对每个节点访问一次。
        /// 空间复杂度：O(H)，其中 H 是树的高度。
        /// 116/116 cases passed (128 ms)
        /// Your runtime beats 17.9 % of csharp submissions
        /// Your memory usage beats 74.07 % of csharp submissions(26 MB)
        /// </summary>
        /// <param name="root"></param>
        /// <param name="targetSum"></param>
        /// <returns></returns>
        public bool HasPathSum_DFS(TreeNode root, int targetSum)
        {
            if (root == null)
            {
                return false;
            }
            if (root.left == null && root.right == null)
            {
                return targetSum == root.val;
            }
            return HasPathSum_DFS(root.left, targetSum - root.val) || HasPathSum_DFS(root.right, targetSum - root.val);
        }

        /// <summary>
        /// BFS  效率不错，内存使用过多
        /// 116/116 cases passed (112 ms)
        /// Your runtime beats 80.25 % of csharp submissions
        /// Your memory usage beats 5.55 % of csharp submissions(26.9 MB)
        /// https://leetcode-cn.com/problems/path-sum/solution/lu-jing-zong-he-de-si-chong-jie-fa-dfs-hui-su-bfs-/
        /// </summary>
        /// <param name="root"></param>
        /// <param name="targetSum"></param>
        /// <returns></returns>
        public bool HasPathSum_BFS(TreeNode root, int targetSum)
        {
            if (root == null) return false;

            LinkedList<Data> queue = new LinkedList<Data>();
            queue.AddLast(new Data(root, root.val));

            while (queue.Count > 0)
            {
                Data data = queue.First.Value; //queue.shift();
                queue.RemoveFirst();

                if (data.node == null)
                    continue;

                TreeNode node = data.node;
                int sum = data.sum;

                // 把当前节点的值累加
                if (node.left == null && node.right == null && data.sum == targetSum)
                {
                    return true;
                }
                if (node.left != null)
                    queue.AddLast(new Data(node.left, sum + node.left.val));
                if (node.right != null)
                    queue.AddLast(new Data(node.right, sum + node.right.val));
            }
            return false;
        }
        public class Data
        {
            public TreeNode node;
            public int sum;
            public Data(TreeNode node, int sum)
            {
                this.node = node;
                this.sum = sum;
            }
        }
    }
}
