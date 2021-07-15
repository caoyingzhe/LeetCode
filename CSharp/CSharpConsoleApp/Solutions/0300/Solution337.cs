using System;
using System.Collections.Generic;
namespace CSharpConsoleApp.Solutions
{
    /*
     * @lc app=leetcode.cn id=337 lang=csharp
     *
     * [337] 打家劫舍 III
     *
     * https://leetcode-cn.com/problems/house-robber-iii/description/
     *
     * Category	Difficulty	Likes	Dislikes
     * algorithms	Medium (61.05%)	901	-
     * Tags
     * tree | depth-first-search
     * 
     * Companies
     * uber
     * 
     * Total Accepted:    113.1K
     * Total Submissions: 185.3K
     * Testcase Example:  '[3,2,3,null,3,null,1]'
     *
     * 在上次打劫完一条街道之后和一圈房屋后，小偷又发现了一个新的可行窃的地区。这个地区只有一个入口，我们称之为“根”。
     * 除了“根”之外，每栋房子有且只有一个“父“房子与之相连。一番侦察之后，聪明的小偷意识到“这个地方的所有房屋的排列类似于一棵二叉树”。
     * 如果两个直接相连的房子在同一天晚上被打劫，房屋将自动报警。
     * 
     * 计算在不触动警报的情况下，小偷一晚能够盗取的最高金额。
     * 
     * 示例 1:
     * 
     * 输入: [3,2,3,null,3,null,1]
     * 
     * ⁠    3
     * ⁠   / \
     * ⁠  2   3
     * ⁠   \   \ 
     * ⁠    3   1
     * 
     * 输出: 7 
     * 解释: 小偷一晚能够盗取的最高金额 = 3 + 3 + 1 = 7.
     * 
     * 示例 2:
     * 
     * 输入: [3,4,5,1,3,null,1]
     * 
     * 3
     * ⁠   / \
     * ⁠  4   5
     * ⁠ / \   \ 
     * ⁠1   3   1
     * 
     * 输出: 9
     * 解释: 小偷一晚能够盗取的最高金额 = 4 + 5 = 9.
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
    public class Solution337 : SolutionBase
    {
        /// <summary>
        /// 难度
        /// </summary>
        public override Difficulity GetDifficulity() { return Difficulity.Medium; }
        /// <summary>
        /// 关键字:
        /// </summary>
        public override string[] GetKeyWords() { return new string[] { "" }; }
        /// <summary>
        /// 标签： 
        /// </summary>
        public override Tag[] GetTags() { return new Tag[] { Tag.Tree, Tag.DepthFirstSearch }; }

        public int NULL = -1;
        public override bool Test(System.Diagnostics.Stopwatch sw)
        {
            bool isSuccess = true;

            TreeNode root;
            int result, checkResult;

            root = TreeNode.Create(new int[] { 3, 2, 3, NULL, 3, NULL, 1 }, NULL);
            checkResult = 7;
            result = Rob(root);
            isSuccess &= IsSame(result, checkResult);
            PrintResult(isSuccess, result, checkResult);

            root = TreeNode.Create(new int[] { 3, 4, 5, 1, 3, NULL, 1 }, NULL);
            checkResult = 9;
            result = Rob(root);
            isSuccess &= IsSame(result, checkResult);
            PrintResult(isSuccess, result, checkResult);

            return isSuccess;
        }
        //作者：LeetCode - Solution
        //链接：https://leetcode-cn.com/problems/house-robber-iii/solution/da-jia-jie-she-iii-by-leetcode-solution/

        
        //f(o) 表示选择 o 节点的情况下，o节点的子树上被选择的节点的最大权值和
        Dictionary<TreeNode, int> f = new Dictionary<TreeNode, int>();
        //g(o) 表示不选择 o 节点的情况下，o 节点的子树上被选择的节点的最大权值和
        Dictionary<TreeNode, int> g = new Dictionary<TreeNode, int>();

        /// <summary>
        /// 124/124 cases passed (104 ms)
        /// Your runtime beats 97.22 % of csharp submissions
        /// Your memory usage beats 6.94 % of csharp submissions(28.7 MB)
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public int Rob(TreeNode root)
        {
            dfs(root);
            return Math.Max(f.ContainsKey(root) ? f[root] : 0, g.ContainsKey(root) ? g[root] : 0);
        }
        public void dfs(TreeNode node)
        {
            if (node == null)
            {
                return;
            }

            //l 和 r 代表 o 的左右孩子。
            dfs(node.left);
            dfs(node.right);

            int gLeft = node.left != null && g.ContainsKey(node.left) ? g[node.left] : 0;
            int gRight = node.right != null && g.ContainsKey(node.right) ? g[node.right] : 0;
            int fLeft = node.left != null && f.ContainsKey(node.left) ? f[node.left] : 0;
            int fRight = node.right != null && f.ContainsKey(node.right) ? f[node.right] : 0;

            //当 oo 被选中时, o 的左右孩子都不能被选中, 即f(o)=g(l)+g(r)。
            f[node] = node.val + gLeft + gRight;
            //当 o不被选中时，o 的左右孩子可以被选中，也可以不被选中。, 即 g(o)=max{f(l),g(l)}+max{f(r),g(r)}。
            g[node] = Math.Max(fLeft, gLeft) + Math.Max(fRight, gRight);
        }
    }
    // @lc code=end


}
