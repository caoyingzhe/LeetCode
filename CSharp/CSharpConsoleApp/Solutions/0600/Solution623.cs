using System;
namespace CSharpConsoleApp.Solutions
{
    /*
 * @lc app=leetcode.cn id=623 lang=csharp
 *
 * [623] 在二叉树中增加一行
 *
 * https://leetcode-cn.com/problems/add-one-row-to-tree/description/
 *
 * algorithms
 * Medium (54.29%)
 * Likes:    91
 * Dislikes: 0
 * Total Accepted:    10.3K
 * Total Submissions: 19K
 * Testcase Example:  '[4,2,6,3,1,5]\n1\n2'
 *
 * 给定一个二叉树，根节点为第1层，深度为 1。在其第 d 层追加一行值为 v 的节点。
 * 
 * 添加规则：给定一个深度值 d （正整数），针对深度为 d-1 层的每一非空节点 N，为 N 创建两个值为 v 的左子树和右子树。
 * 
 * 将 N 原先的左子树，连接为新节点 v 的左子树；将 N 原先的右子树，连接为新节点 v 的右子树。
 * 
 * 如果 d 的值为 1，深度 d - 1 不存在，则创建一个新的根节点 v，原先的整棵树将作为 v 的左子树。
 * 
 * 示例 1:
 * 
 * 
 * 输入: 
 * 二叉树如下所示:
 * ⁠      4
 * ⁠    /   \
 * ⁠   2     6
 * ⁠  / \   / 
 * ⁠ 3   1 5   
 * 
 * v = 1
 * 
 * d = 2
 * 
 * 输出: 
 * ⁠      4
 * ⁠     / \
 * ⁠    1   1
 * ⁠   /     \
 * ⁠  2       6
 * ⁠ / \     / 
 * ⁠3   1   5   
 * 
 * 
 * 
 * 示例 2:
 * 
 * 
 * 输入: 
 * 二叉树如下所示:
 * ⁠     4
 * ⁠    /   
 * ⁠   2    
 * ⁠  / \   
 * ⁠ 3   1    
 * 
 * v = 1
 * 
 * d = 3
 * 
 * 输出: 
 * ⁠     4
 * ⁠    /   
 * ⁠   2
 * ⁠  / \    
 * ⁠ 1   1
 * ⁠/     \  
 * 3       1
 * 
 * 
 * 注意:
 * 
 * 
 * 输入的深度值 d 的范围是：[1，二叉树最大深度 + 1]。
 * 输入的二叉树至少有一个节点。
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
    public class Solution623 : SolutionBase
    {
        /// <summary>
        /// 难度
        /// </summary>
        public override Difficulity GetDifficulity() { return Difficulity.Medium; }
        /// <summary>
        /// 关键字:
        /// </summary>
        public override string[] GetKeyWords() { return new string[] { "抄作业" }; }
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
            bool isSuccess = true;
            TreeNode node; int val, depth;
            TreeNode result, checkResult;
            //TODO
            node = TreeNode.CreateBST(new int[] { 4, 2, 6, 3, 1, 5 });
            val = 1; depth = 2;
            checkResult = TreeNode.CreateBST(new int[] { 4, 1, 1, 2, 6, 3, 1, 5 });
            //p1 = [0,0], p2 = [1,1], p3 = [1,0], p4 = [0,1]
            result = AddOneRow(node, val, depth);
            isSuccess &= IsSame(node, checkResult);
            //TODO 不明白为何打印结果不对
            PrintResult(isSuccess, result.GetNodeString(true), checkResult.GetNodeString(true));
            return isSuccess;
        }

        //作者：LeetCode
        //链接：https://leetcode-cn.com/problems/add-one-row-to-tree/solution/zai-er-cha-shu-zhong-zeng-jia-yi-xing-by-leetcode/
        //109/109 cases passed(84 ms)
        //Your runtime beats 80 % of csharp submissions
        //Your memory usage beats 100 % of csharp submissions(26.7 MB)
        public TreeNode AddOneRow(TreeNode root, int val, int depth)
        {
            if (depth == 1)
            {
                TreeNode n = new TreeNode(val);
                n.left = root;
                return n;
            }
            Insert(val, root, 1, depth);
            return root;
        }

        public void Insert(int val, TreeNode node, int depth, int n)
        {
            if (node == null)
                return;

            if (depth == n - 1) //当前层为插入层
            {
                TreeNode t = node.left;
                node.left = new TreeNode(val);
                node.left.left = t;
                t = node.right;
                node.right = new TreeNode(val);
                node.right.right = t;
            }
            else //当前层为非插入层
            {
                Insert(val, node.left, depth + 1, n);
                Insert(val, node.right, depth + 1, n);
            }
        }
    }
    // @lc code=end


}
