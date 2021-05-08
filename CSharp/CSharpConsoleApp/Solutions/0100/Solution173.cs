using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TreeNode = CSharpConsoleApp.Solutions.SolutionBase.TreeNode;
namespace CSharpConsoleApp.Solutions
{
    /// <summary>
    /// 二叉搜索树迭代器 
    /// 
    /// 树中节点的数目在范围 [1, 105] 内
    /// 0 <= Node.val <= 106
    /// 最多调用 105 次 hasNext 和 next 操作
    /// 
    /// 进阶：
    /// 你可以设计一个满足下述条件的解决方案吗？next() 和 hasNext() 操作均摊时间复杂度为 O(1) ，
    /// 并使用 O(h) 内存。其中 h 是树的高度。
    /// 
    /// 作者：LeetCode-Solution
    /// 链接：https://leetcode-cn.com/problems/binary-search-tree-iterator/solution/er-cha-sou-suo-shu-die-dai-qi-by-leetcod-4y0y/
    /// </summary>
    class Solution173 : SolutionBase
    {
        /// <summary>
        /// 难度
        /// </summary>
        public override Difficulity GetDifficulity() { return Difficulity.Medium; }
        /// <summary>
        /// 关键字:
        /// </summary>
        public override string[] GetKeyWords() { return new string[] { "二叉搜索树迭代器类", "BSTIterator", "设计", "按中序遍历", "BST" }; }
        /// <summary>
        /// 标签： 
        /// </summary>
        public override Tag[] GetTags() { return new Tag[] { Tag.Stack, Tag.Design, Tag.Tree}; }

        public override bool Test(System.Diagnostics.Stopwatch sw)
        {
            bool isSuccess = true;
            TreeNode treeRoot = TreeNode.CreateBST(new int[]{ 7, 3, 15, 9, 20 });//???  { 7, 3, 15, null, null, 9, 20 }
            BSTIterator bSTIterator = new BSTIterator(treeRoot);
            System.Diagnostics.Debug.Assert(bSTIterator.next() == 3);        // 返回 3
            System.Diagnostics.Debug.Assert(bSTIterator.next() == 7);        // 返回 7
            System.Diagnostics.Debug.Assert(bSTIterator.hasNext() == true);  // 返回 True
            System.Diagnostics.Debug.Assert(bSTIterator.next() == 9);        // 返回 9
            System.Diagnostics.Debug.Assert(bSTIterator.hasNext() == true);  // 返回 True
            System.Diagnostics.Debug.Assert(bSTIterator.next() == 15);       // 返回 15
            System.Diagnostics.Debug.Assert(bSTIterator.hasNext() == true);  // 返回 True
            System.Diagnostics.Debug.Assert(bSTIterator.next() == 20);       // 返回 20
            System.Diagnostics.Debug.Assert(bSTIterator.hasNext() == false); // 返回 False
            return isSuccess;
        }
    }
    
    class BSTIterator
    {
        private int idx;
        private List<int> arr;

        public BSTIterator(TreeNode root)
        {
            idx = 0;
            arr = new List<int>();
            inorderTraversal(root, arr);
        }

        public int next()
        {
            return arr[idx++];
        }

        public bool hasNext()
        {
            return idx < arr.Count;
        }

        /// <summary>
        /// 递归遍历
        /// </summary>
        /// <param name="root"></param>
        /// <param name="arr"></param>
        private void inorderTraversal(TreeNode root, List<int> arr)
        {
            if (root == null)
            {
                return;
            }
            inorderTraversal(root.left, arr); // 增加节点 左侧
            arr.Add(root.val);                // 增加节点 自身 
            inorderTraversal(root.right, arr);// 增加节点 右侧
        }
    }
}
