using System;
namespace CSharpConsoleApp.Solutions
{
    /*
 * @lc app=leetcode.cn id=654 lang=csharp
 *
 * [654] 最大二叉树
 *
 * https://leetcode-cn.com/problems/maximum-binary-tree/description/
 *
 * Category	Difficulty	Likes	Dislikes
 * algorithms	Medium (81.00%)	299	-
 * Tags
 * tree
 * 
 * Companies
 * microsoft
 * 
 * Total Accepted:    48.4K
 * Total Submissions: 59.8K
 * Testcase Example:  '[3,2,1,6,0,5]'
 *
 * 给定一个不含重复元素的整数数组 nums 。一个以此数组直接递归构建的 最大二叉树 定义如下：
 * 
 * 二叉树的根是数组 nums 中的最大元素。
 * 左子树是通过数组中 最大值左边部分 递归构造出的最大二叉树。
 * 右子树是通过数组中 最大值右边部分 递归构造出的最大二叉树。
 * 
 * 返回有给定数组 nums 构建的 最大二叉树 。
 * 
 * 
 * 示例 1：
 * 输入：nums = [3,2,1,6,0,5]
 * 输出：[6,3,5,null,2,0,null,null,1]
 * 解释：递归调用如下所示：
 * - [3,2,1,6,0,5] 中的最大值是 6 ，左边部分是 [3,2,1] ，右边部分是 [0,5] 。
 * ⁠   - [3,2,1] 中的最大值是 3 ，左边部分是 [] ，右边部分是 [2,1] 。
 * ⁠       - 空数组，无子节点。
 * ⁠       - [2,1] 中的最大值是 2 ，左边部分是 [] ，右边部分是 [1] 。
 * ⁠           - 空数组，无子节点。
 * ⁠           - 只有一个元素，所以子节点是一个值为 1 的节点。
 * ⁠   - [0,5] 中的最大值是 5 ，左边部分是 [0] ，右边部分是 [] 。
 * ⁠       - 只有一个元素，所以子节点是一个值为 0 的节点。
 * ⁠       - 空数组，无子节点。
 * 
 * 
 * 示例 2：
 * 输入：nums = [3,2,1]
 * 输出：[3,null,2,null,1]
 *
 * 
 * 提示：
 * 1 <= nums.length <= 1000
 * 0 <= nums[i] <= 1000
 * nums 中的所有整数 互不相同
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
    public class Solution654 : SolutionBase
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
        public override Tag[] GetTags() { return new Tag[] { Tag.Tree }; }

        public override bool Test(System.Diagnostics.Stopwatch sw)
        {
            bool isSuccess = true;
            TreeNode result, checkResult;
            int[] nums;

            nums = new int[] { 3, 2, 1, 6, 0, 5 };
            checkResult = TreeNode.Create(new int[] { 6, 3, 5, NULL, 2, 0, NULL, NULL, 1 }, NULL);
            result = ConstructMaximumBinaryTree(nums);
            isSuccess &= IsSame(result, checkResult);
            PrintResult(isSuccess, result.GetNodeString(), checkResult.GetNodeString());

            return isSuccess;
        }

        /// <summary>
        /// 107/107 cases passed (104 ms)
        /// Your runtime beats 82.5 % of csharp submissions
        /// Your memory usage beats 22.5 % of csharp submissions(29.1 MB)
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public TreeNode ConstructMaximumBinaryTree(int[] nums)
        {
            return DFS(nums, 0, nums.Length);
        }
        public TreeNode DFS(int[] nums, int l, int r)
        {
            if (l == r)
                return null;
            int max_i = max(nums, l, r);

            TreeNode root = new TreeNode(nums[max_i]);
            root.left = DFS(nums, l, max_i);
            root.right = DFS(nums, max_i + 1, r);
            return root;
        }

        //求(l,r)范围中的最大值对应的索引
        public int max(int[] nums, int l, int r)
        {
            int max_i = l;
            for (int i = l; i < r; i++)
            {
                if (nums[max_i] < nums[i])
                    max_i = i;
            }
            return max_i;
        }

        //作者：LeetCode
        //链接：https://leetcode-cn.com/problems/maximum-binary-tree/solution/zui-da-er-cha-shu-by-leetcode/
    }
    // @lc code=end


}
