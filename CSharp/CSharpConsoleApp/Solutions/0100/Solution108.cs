using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpConsoleApp.Solutions
{
    /// <summary>
    /// [108] 将有序数组转换为二叉搜索树
    /// 给你一个整数数组 nums ，其中元素已经按 升序 排列，请你将其转换为一棵 高度平衡 二叉搜索树。
    /// 高度平衡 二叉树是一棵满足「每个节点的左右两个子树的高度差的绝对值不超过 1 」的二叉树。
    /// 
    /// 前言:
    ///     二叉搜索树的中序遍历是升序序列
    ///     
    /// 输入：nums = [-10,-3,0,5,9]
    /// 输出：[0,-3,9,-10,null,5]
    /// 解释：[0,-10,5,null,-3,null,9] 也将被视为正确答案：
    /// 
    /// 输入：nums = [1,3]
    /// 输出：[3,1]
    /// 解释：[1,3] 和[3, 1] 都是高度平衡二叉搜索树。
    /// </summary>
    class Solution108 : SolutionBase
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
        public override Tag[] GetTags() { return new Tag[] { Tag.Stack, Tag.Design, Tag.Tree }; }

        public override bool Test(System.Diagnostics.Stopwatch sw)
        {
            bool isSuccess = true;
            int[] nums = new int[] { -10, -3, 0, 5, 9 };
            //int[] checkResult = new int[] {0, -3, 9, -10, null, 5};
            TreeNode resultNode = SortedArrayToBST(nums);// Use Helper1 function : {0,-10,5,null,-3,null,9};
            //null,-10,null,-3,null,0,null,5,null,9,null
            Print(resultNode.GetNodeString());
            return isSuccess;
        }

        /// <summary>
        /// 方法一：中序遍历，总是选择中间位置左边的数字作为根节点
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public TreeNode SortedArrayToBST(int[] nums)
        {
            //return Helper1(nums, 0, nums.Length - 1); // 该方法不合Leetcode测试结果
            //return Helper2(nums, 0, nums.Length - 1);
            return Helper3(nums, 0, nums.Length - 1, new Random());
        }

        public TreeNode Helper1(int[] nums, int left, int right)
        {
            if (left > right)
            {
                return null;
            }

            // 总是选择中间位置左边的数字作为根节点
            int mid = (left + right) / 2;

            TreeNode root = new TreeNode(nums[mid]);
            root.left = Helper1(nums, left, mid - 1);
            root.right = Helper1(nums, mid + 1, right);
            return root;
        }

        /// <summary>
        /// 方法二：中序遍历，总是选择中间位置右边的数字作为根节点
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public TreeNode Helper2(int[] nums, int left, int right)
        {
            if (left > right)
            {
                return null;
            }

            // 总是选择中间位置右边的数字作为根节点
            int mid = (left + right + 1) / 2;

            TreeNode root = new TreeNode(nums[mid]);
            root.left = Helper2(nums, left, mid - 1);
            root.right = Helper2(nums, mid + 1, right);
            return root;
        }

        
        /// <summary>
        /// 方法三：中序遍历，选择任意一个中间位置数字作为根节点
        /// </summary>
        public TreeNode Helper3(int[] nums, int left, int right, Random rand)
        {
            if (left > right)
            {
                return null;
            }

            // 选择任意一个中间位置数字作为根节点
            int mid = (left + right + rand.Next(2)) / 2;

            TreeNode root = new TreeNode(nums[mid]);
            root.left = Helper3(nums, left, mid - 1, rand);
            root.right = Helper3(nums, mid + 1, right, rand);
            return root;
        }
    }
}
