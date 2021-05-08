using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TreeNode = CSharpConsoleApp.Solutions.SolutionBase.TreeNode;
namespace CSharpConsoleApp.Solutions
{
    /*
     * @lc app=leetcode.cn id=230 lang=csharp
     *
     * [230] 二叉搜索树中第K小的元素
     *
     * https://leetcode-cn.com/problems/kth-smallest-element-in-a-bst/description/
     *
     * algorithms
     * Medium (73.15%)
     * Likes:    387
     * Dislikes: 0
     * Total Accepted:    107K
     * Total Submissions: 145.7K
     * Testcase Example:  '[3,1,4,null,2]\n1'
     *
     * 给定一个二叉搜索树的根节点 root ，和一个整数 k ，请你设计一个算法查找其中第 k 个最小元素（从 1 开始计数）。
     * 
     * 
     * 
     * 示例 1：
     * 
     * 
     * 输入：root = [3,1,4,null,2], k = 1
     * 输出：1
     * 
     * 
     * 示例 2：
     * 
     * 
     * 输入：root = [5,3,6,2,4,null,null,1], k = 3
     * 输出：3
     * 
     * 
     * 
     * 
     * 
     * 
     * 提示：
     * 
     * 
     * 树中的节点数为 n 。
     * 1 
     * 0 
     * 
     * 
     * 
     * 
     * 进阶：如果二叉搜索树经常被修改（插入/删除操作）并且你需要频繁地查找第 k 小的值，你将如何优化算法？
     * 
     */

    class Solution230 : SolutionBase
    {
        /// <summary>
        /// 难度 
        /// </summary>
        public override Difficulity GetDifficulity() { return Difficulity.Medium; }
        /// <summary>
        /// 关键字:
        /// </summary>
        public override string[] GetKeyWords() { return new string[] { }; }
        /// <summary>
        /// 标签： 
        /// </summary>
        public override Tag[] GetTags() { return new Tag[] { Tag.Tree, Tag.BinarySearch, Tag.BinarySearchTree}; }
        public override bool Test(System.Diagnostics.Stopwatch sw)
        {
            bool isSuccess = true;
            int checkresult;
            int k;
            TreeNode node;

            node = TreeNode.Create(new string[] { "5", "3", "6", "2", "4", null, null, "1" });
            k = 3;
            checkresult = 3;
            isSuccess &= KthSmallest(node, k) == checkresult;

            node = TreeNode.Create(new string[] { "3", "1", "4",null, "2" });
            k = 1;
            checkresult = 1;
            isSuccess &= KthSmallest(node, k) == checkresult;
            System.Diagnostics.Debug.Assert(isSuccess);

            return isSuccess;
        }

        /// <summary>
        ///  二叉搜索树中第K小的元素
        /// 通过构造 BST 的中序遍历序列，则第 k-1 个元素就是第 k 小的元素。
        /// 
        /// Your runtime beats 98.95 % of csharp submissions
        /// Your memory usage beats 7.37 % of csharp submissions
        /// 
        /// </summary>
        /// <param name="root"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public int KthSmallest_MySelf(TreeNode root, int k)
        {
            List<TreeNode> nodeList = new List<TreeNode>();
            TreeNode.GetNodeList(root, nodeList);
            return nodeList[k - 1].val;
            /*
            /// 自己最初的算法，效率很低。
            /// Your runtime beats 22.11 % of csharp submissions
            /// Your memory usage beats 5.27 % of csharp submissions(29.3 MB)
            List<int> nodeValues = new List<int>();
            foreach(TreeNode node in nodeList)
            {
                if(node != null)
                    nodeValues.Add(node.val);
            }
            nodeValues.Sort();
            return nodeValues[k-1];
            */
        }

        
        /// 官方答案，其实和自己的一样。
        public int KthSmallest(TreeNode root, int k)
        {
            List<int> nums = inorder(root, new List<int>());
            return nums[k - 1];
        }
        public List<int> inorder(TreeNode root, List<int> arr)
        {
            if (root == null) return arr;

            inorder(root.left, arr);
            arr.Add(root.val);
            inorder(root.right, arr);
            return arr;
        }
    }

    
}
