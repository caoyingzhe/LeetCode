using System;
namespace CSharpConsoleApp.Solutions
{
    /*
 * @lc app=leetcode.cn id=606 lang=csharp
 *
 * [606] 根据二叉树创建字符串
 *
 * https://leetcode-cn.com/problems/construct-string-from-binary-tree/description/
 *
 * Category	Difficulty	Likes	Dislikes
 * algorithms	Easy (56.41%)	201	-
 * Tags
 * string | tree
 * 
 * Companies
 * amazon
 * 
 * Total Accepted:    25.8K
 * Total Submissions: 45.7K
 * Testcase Example:  '[1,2,3,4]'
 *
 * 你需要采用前序遍历的方式，将一个二叉树转换成一个由括号和整数组成的字符串。
 * 
 * 空节点则用一对空括号 "()" 表示。而且你需要省略所有不影响字符串与原始二叉树之间的一对一映射关系的空括号对。
 * 
 * 示例 1:
 * 
 * 
 * 输入: 二叉树: [1,2,3,4]
 * ⁠      1
 * ⁠    /   \
 * ⁠   2     3
 * ⁠  /    
 * ⁠ 4     
 * 
 * 输出: "1(2(4))(3)"
 * 
 * 解释: 原本将是“1(2(4)())(3())”，
 * 在你省略所有不必要的空括号对之后，
 * 它将是“1(2(4))(3)”。
 * 
 * 
 * 示例 2:
 * 
 * 
 * 输入: 二叉树: [1,2,3,null,4]
 * ⁠      1
 * ⁠    /   \
 * ⁠   2     3
 * ⁠    \  
 * ⁠     4 
 * 
 * 输出: "1(2()(4))(3)"
 * 
 * 解释: 和第一个示例相似，
 * 除了我们不能省略第一个对括号来中断输入和输出之间的一对一映射关系。
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
    public class Solution606 : SolutionBase
    {
        /// <summary>
        /// 难度
        /// </summary>
        public override Difficulity GetDifficulity() { return Difficulity.Easy; }
        /// <summary>
        /// 关键字:
        /// </summary>
        public override string[] GetKeyWords() { return new string[] { "前序遍历" }; }
        /// <summary>
        /// 标签：
        /// </summary>
        public override Tag[] GetTags() { return new Tag[] { Tag.String, Tag.Tree }; }

        public const int NULL = int.MinValue;
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
            TreeNode root;
            string result, checkResult;

            root = TreeNode.Create(new int[] { 1,2,3,4 }, NULL);
            checkResult = "1(2(4))(3)";
            result = Tree2str(root);
            isSuccess &= IsSame(result, checkResult);
            PrintResult(isSuccess, result, checkResult);

            root = TreeNode.Create(new int[] { 1, 2, 3, NULL, 4 }, NULL);
            checkResult = "1(2()(4))(3)";
            result = Tree2str(root);
            isSuccess &= IsSame(result, checkResult);
            PrintResult(isSuccess, result, checkResult);
            return isSuccess;
        }

        System.Text.StringBuilder sb; 
        public string Tree2str(TreeNode root)
        {
            sb = new System.Text.StringBuilder();
            DFS(root);
            return sb.ToString();
        }

        public void DFS(TreeNode root, bool isRoot = true)
        {
            if(root == null)
            {
                //sb.Append("()");
                return ;
            }
            sb.Append(root.val);

            if(root.left != null || root.right != null)
            {
                sb.Append("(");
                DFS(root.left, false);
                sb.Append(")");

                if(root.right != null)
                { 
                    sb.Append("(");
                    DFS(root.right, false);
                    sb.Append(")");
                }
            }
        }
    }
    // @lc code=end


}
