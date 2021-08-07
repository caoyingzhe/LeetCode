using System;
namespace CSharpConsoleApp.Solutions
{
    /*
     * @lc app=leetcode.cn id=538 lang=csharp
     *
     * [538] 把二叉搜索树转换为累加树
     *
     * https://leetcode-cn.com/problems/convert-bst-to-greater-tree/description/
     *
     * Category	Difficulty	Likes	Dislikes
     * algorithms	Medium (68.38%)	543	-
     * Tags
     * tree
     * 
     * Companies
     * amazon
     * 
     * Total Accepted:    94.6K
     * Total Submissions: 138.3K
     * Testcase Example:  '[4,1,6,0,2,5,7,null,null,null,3,null,null,null,8]'
     *
     * 给出二叉 搜索 树的根节点，该树的节点值各不相同，请你将其转换为累加树（Greater Sum Tree），使每个节点 node
     * 的新值等于原树中大于或等于 node.val 的值之和。
     * 
     * 提醒一下，二叉搜索树满足下列约束条件：
     * 
     * 
     * 节点的左子树仅包含键 小于 节点键的节点。
     * 节点的右子树仅包含键 大于 节点键的节点。
     * 左右子树也必须是二叉搜索树。
     * 
     * 
     * 注意：本题和 1038:
     * https://leetcode-cn.com/problems/binary-search-tree-to-greater-sum-tree/
     * 相同
     * 
     * 
     * 示例 1：
     * 输入：[4,1,6,0,2,5,7,null,null,null,3,null,null,null,8]
     * 输出：[30,36,21,36,35,26,15,null,null,null,33,null,null,null,8]
     * 
     * 
     * 示例 2：
     * 输入：root = [0,null,1]
     * 输出：[1,null,1]
     * 
     * 
     * 示例 3：
     * 输入：root = [1,0,2]
     * 输出：[3,3,2]
     * 
     * 
     * 示例 4：
     * 输入：root = [3,2,4,1]
     * 输出：[7,9,4,10]
     * 
     * 
     * 提示：
     * 树中的节点数介于 0 和 10^4^ 之间。
     * 每个节点的值介于 -10^4 和 10^4 之间。
     * 树中的所有值 互不相同 。
     * 给定的树为二叉搜索树。
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
    public class Solution538 : SolutionBase
    {
        /// <summary>
        /// 难度
        /// </summary>
        public override Difficulity GetDifficulity() { return Difficulity.Medium; }
        /// <summary>
        /// 关键字:
        /// </summary>
        public override string[] GetKeyWords() { return new string[] { "累加树 (反序中序遍历BST)", "Morris遍历" }; }
        /// <summary>
        /// 标签：
        /// </summary>
        public override Tag[] GetTags() { return new Tag[] { Tag.Tree }; }

        public const int N = int.MinValue;
        /// <summary>
        /// 160/160 cases passed (124 ms)
        /// Your runtime beats 100 % of csharp submissions
        /// Your memory usage beats 88.89 % of csharp submissions(28.2 MB)
        /// </summary>
        /// <param name="sw"></param>
        /// <returns></returns>
        public override bool Test(System.Diagnostics.Stopwatch sw)
        {
            bool isSuccess = true;
            TreeNode root, root2;
            TreeNode result, checkResult;

            root = TreeNode.Create(new int[] { 4, 1, 6, 0, 2, 5, 7, N, N, N, 3, N, N, N, 8 }, N);
            root2 = TreeNode.Create(new int[] { 1, 2, 3, N, 4 }, N);
            checkResult = TreeNode.Create(new int[] { 30, 36, 21, 36, 35, 26, 15, N, N, N, 33, N, N, N, 8 }, N);
            result = ConvertBST(root);
            isSuccess &= IsSame(result, checkResult);
            PrintResult(isSuccess, result.GetNodeString(true), checkResult.GetNodeString(true));
            return isSuccess;
        }

        //作者：LeetCode - Solution
        //链接：https://leetcode-cn.com/problems/convert-bst-to-greater-tree/solution/ba-er-cha-sou-suo-shu-zhuan-huan-wei-lei-jia-sh-14/

        int sum = 0;
        /// <summary>
        /// 反序中序遍历BST
        /// 空间复杂度：O(n)
        /// 时间复杂度：O(n)
        ///
        /// 215/215 cases passed (136 ms)
        /// Your runtime beats 38.1 % of csharp submissions
        /// Your memory usage beats 9.52 % of csharp submissions(29.4 MB)
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public TreeNode ConvertBST_RevertBST(TreeNode root)
        {
            if (root != null)
            {
                ConvertBST(root.right);
                sum += root.val;
                root.val = sum;
                ConvertBST(root.left);
            }
            return root;
        }

        /// <summary>
        /// Morris 遍历 1979
        /// 空间复杂度：O(1)
        /// 时间复杂度：O(n)
        ///
        /// TODO 待理解 该方法的优越性
        /// Morris 遍历的核心思想是利用树的大量空闲指针，实现空间开销的极限缩减。其反序中序遍历规则总结如下：
        /// 1. 如果当前节点的右子节点为空，处理当前节点，并遍历当前节点的左子节点；
        /// 2. 如果当前节点的右子节点不为空，找到当前节点右子树的最左节点（该节点为当前节点中序遍历的前驱节点）；
        ///    2.1 如果最左节点的左指针为空，将最左节点的左指针指向当前节点，遍历当前节点的右子节点；
        ///    2.2 如果最左节点的左指针不为空，将最左节点的左指针重新置为空（恢复树的原状），处理当前节点，并将当前节点置为其左节点；
        /// 3. 重复步骤 1 和步骤 2，直到遍历结束。
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public TreeNode ConvertBST(TreeNode root)
        {
            sum = 0;
            TreeNode node = root;

            while (node != null)
            {
                if (node.right == null)
                {
                    sum += node.val;
                    node.val = sum;
                    node = node.left;
                }
                else
                {
                    TreeNode succ = getSuccessor(node);
                    if (succ.left == null)
                    {
                        succ.left = node;
                        node = node.right;
                    }
                    else
                    {
                        succ.left = null;
                        sum += node.val;
                        node.val = sum;
                        node = node.left;
                    }
                }
            }

            return root;
        }

        public TreeNode getSuccessor(TreeNode node)
        {
            TreeNode succ = node.right;
            while (succ.left != null && succ.left != node)
            {
                succ = succ.left;
            }
            return succ;
        }
    }
    // @lc code=end


}
