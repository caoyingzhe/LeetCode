using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpConsoleApp.Solutions
{
    /*
     * @lc app=leetcode.cn id=257 lang=csharp
     *
     * [257] 二叉树的所有路径
     *
     * https://leetcode-cn.com/problems/binary-tree-paths/description/
     *
     * algorithms
     * Easy (67.18%)
     * Likes:    489
     * Dislikes: 0
     * Total Accepted:    111.6K
     * Total Submissions: 166.1K
     * Testcase Example:  '[1,2,3,null,5]'
     *
     * 给定一个二叉树，返回所有从根节点到叶子节点的路径。
     * 
     * 说明: 叶子节点是指没有子节点的节点。
     * 
     * 示例:
     * 
     * 输入:
     * 
     * ⁠  1
     * ⁠/   \
     * 2     3
     * ⁠\
     * ⁠ 5
     * 
     * 输出: ["1->2->5", "1->3"]
     * 
     * 解释: 所有根节点到叶子节点的路径为: 1->2->5, 1->3
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
    class Solution257 : SolutionBase
    {
        /// <summary>
        /// 难度
        /// </summary>
        public override Difficulity GetDifficulity() { return Difficulity.Easy; }
        /// <summary>
        /// 关键字:
        /// </summary>
        public override string[] GetKeyWords() { return new string[] { "二叉树的所有路径", }; }
        /// <summary>
        /// 标签：
        /// </summary>
        public override Tag[] GetTags() { return new Tag[] { Tag.Tree, Tag.DepthFirstSearch }; }

        public override bool Test(System.Diagnostics.Stopwatch sw)
        {
            bool isSuccess = true;
            TreeNode node;
            string[] result;
            string[] checkResult;

            node = TreeNode.Create(new string[] { "1", "2", "3", null, "5" });
            checkResult = new string[] { "1->2->5", "1->3" };
            result = BinaryTreePaths(node).ToArray();
            isSuccess &= IsListSame(checkResult, result);
            Print("isSuccess ={0} | result = {1} | checkResult = {2}", isSuccess, GetArrayStr(result), GetArrayStr(checkResult));
            return isSuccess;
        }
        public List<String> BinaryTreePaths(TreeNode root)
        {
            //return BinaryTreePaths_DFS(root);
            return BinaryTreePaths_BFS(root);
        }

        /// <summary>
        /// 时间复杂度：O(N^2)，其中 NN 表示节点数目。
        /// 空间复杂度：O(N^2)，其中 NN 表示节点数目。
        /// 
        /// BFS的优缺点：速度不错，但是内存使用量过大。
        /// 
        /// 208/208 cases passed (284 ms)
        /// Your runtime beats 92.06 % of csharp submissions
        /// Your memory usage beats 6.35 % of csharp submissions(32.2 MB)
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public List<String> BinaryTreePaths_BFS(TreeNode root)
        {
            List<string> paths = new List<string>();
            if (root == null)
            {
                return paths;
            }
            LinkedList<TreeNode> nodeQueue = new LinkedList<TreeNode>();
            LinkedList<String> pathQueue = new LinkedList<String>();

            nodeQueue.AddLast(root);  //nodeQueue.offer(root);
            pathQueue.AddLast(root.val.ToString()); //pathQueue.offer(Integer.toString(root.val));

            while (nodeQueue.Count != 0)  // while (!nodeQueue.isEmpty())
            {
                //poll() 从 PriorityQueue 的头部删除一个节点，也就是从小顶堆的堆顶删除一个节点
                TreeNode node = nodeQueue.Last(); //TreeNode node = nodeQueue.poll(); 
                nodeQueue.RemoveLast();
                string path = pathQueue.Last(); // String path = pathQueue.poll();
                pathQueue.RemoveLast();

                if (node.left == null && node.right == null)
                {
                    paths.Add(path);
                }
                else
                {
                    if (node.left != null)
                    {
                        nodeQueue.AddLast(node.left); //nodeQueue.offer(node.left);
                        pathQueue.AddLast(new StringBuilder(path).Append("->").Append(node.left.val).ToString()); //pathQueue.offer(new StringBuffer(path).append("->").append(node.left.val).toString());
                    }

                    if (node.right != null)
                    {
                        nodeQueue.AddLast(node.right); //nodeQueue.offer(node.right);
                        pathQueue.AddLast(new StringBuilder(path).Append("->").Append(node.right.val).ToString()); //pathQueue.offer(new StringBuffer(path).append("->").append(node.right.val).toString());
                    }
                }
            }
            return paths;
        }
        /// <summary>
        /// 时间复杂度：O(N^2)，其中 NN 表示节点数目
        /// 时间复杂度：O(N^2)，其中 NN 表示节点数目
        /// 
        /// 最好情况下，当二叉树为平衡二叉树时，
        /// 它的高度为 logN，此时空间复杂度为 O((logN) 2 )。
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public List<String> BinaryTreePaths_DFS(TreeNode root)
        {
            List<string> paths = new List<string>();
            ConstructPaths(root, "", paths);
            return paths;
        }

        public void ConstructPaths(TreeNode root, String path, List<String> paths)
        {
            if (root != null)
            {
                StringBuilder pathSB = new StringBuilder(path);
                pathSB.Append(root.val);
                if (root.left == null && root.right == null)
                {  // 当前节点是叶子节点
                    paths.Add(pathSB.ToString());  // 把路径加入到答案中
                }
                else
                {
                    pathSB.Append("->");  // 当前节点不是叶子节点，继续递归遍历
                    ConstructPaths(root.left, pathSB.ToString(), paths);
                    ConstructPaths(root.right, pathSB.ToString(), paths);
                }
            }
        }
    }
}
