using System;
using System.Collections.Generic;
namespace CSharpConsoleApp.Solutions
{
    /*
     * @lc app=leetcode.cn id=99 lang=csharp
     *
     * [99] 恢复二叉搜索树
     *
     * https://leetcode-cn.com/problems/recover-binary-search-tree/description/
     *
     * Category	Difficulty	Likes	Dislikes
     * algorithms	Medium (61.83%)	499	-
     * Tags
     * tree | depth-first-search
     * 
     * Companies
     * Unknown
     * 
     * Total Accepted:    60K
     * Total Submissions: 97K
     * Testcase Example:  '[1,3,null,null,2]'
     *
     * 给你二叉搜索树的根节点 root ，该树中的两个节点被错误地交换。请在不改变其结构的情况下，恢复这棵树。
     * 
     * 进阶：使用 O(n) 空间复杂度的解法很容易实现。你能想出一个只使用常数空间的解决方案吗？
     * 
     * 
     * 示例 1：
     * 输入：root = [1,3,null,null,2]
     * 输出：[3,1,null,null,2]
     * 解释：3 不能是 1 左孩子，因为 3 > 1 。交换 1 和 3 使二叉搜索树有效。
     * 
     * 
     * 示例 2：
     * 输入：root = [3,1,4,null,null,2]
     * 输出：[2,1,4,null,null,3]
     * 解释：2 不能在 3 的右子树中，因为 2 < 3 。交换 2 和 3 使二叉搜索树有效。
     * 
     * 
     * 提示：
     * 树上节点的数目在范围 [2, 1000] 内
     * -2^31 <= Node.val <= -2^31 
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
    public class Solution99 : SolutionBase
    {
        /// <summary>
        /// 难易度:
        /// </summary>
        public override Difficulity GetDifficulity() { return Difficulity.Medium; }
        /// <summary>
        /// 关键字:
        /// </summary>
        public override string[] GetKeyWords() { return new string[] { "二叉搜索树", "Morris中序遍历" }; }
        /// <summary>
        /// 标签：
        /// </summary>
        public override Tag[] GetTags() { return new Tag[] { Tag.Tree, Tag.DynamicProgramming }; }

        /// <summary>
        /// </summary>
        /// <param name="sw"></param>
        /// <returns></returns>
        public override bool Test(System.Diagnostics.Stopwatch sw)
        {
            bool isSuccess = true;
            string s;
            IList<string> result, checkResult;

            //s = "19216801";
            //checkResult = new string[] { "192.168.0.1" };
            //result = RestoreIpAddresses(s);
            //isSuccess &= IsListSame(result, checkResult);
            //Print("isSuccess = {0} result = {1} | checkResult = {2}", isSuccess, GetArrayStr(result), GetArrayStr(checkResult));

            return isSuccess;
        }


        /// <summary>
        /// 1. 找到二叉搜索树中序遍历得到值序列的不满足条件的位置。
        /// 2. 如果有两个，我们记为 i 和 j（i<j 且 a[i]> a[i + 1] && a[j]>a[j + 1])，
        ///    那么对应被错误交换的节点即为 a[i] 对应的节点和 a[j + 1] 对应的节点，我们分别记为 x 和 y。
        /// 3. 如果有一个，我们记为i，
        ///    那么对应被错误交换的节点即为a[i] 和 对应的节点和 a[i + 1] 对应的节点，我们分别记为 x 和 y。
        /// 4. 交换 x 和 y 两个节点即可
        /// 
        /// 作者：LeetCode-Solution
        /// 链接：https://leetcode-cn.com/problems/recover-binary-search-tree/solution/hui-fu-er-cha-sou-suo-shu-by-leetcode-solution/
        ///
        /// 1918/1918 cases passed (132 ms)
        /// Your runtime beats 60 % of csharp submissions
        /// Your memory usage beats 20 % of csharp submissions(27.8 MB)
        /// </summary>
        /// <param name="root"></param>
        public void RecoverTree(TreeNode root)
        {
            //取得中序遍历列表
            List<int> nums = new List<int>();
            Inorder(root, nums);

            int[] swapped = FindTwoSwapped(nums);
            Recover(root, 2, swapped[0], swapped[1]);
        }

        //中序遍历
        public void Inorder(TreeNode root, List<int> nums)
        {
            if (root == null)
            {
                return;
            }
            Inorder(root.left, nums);
            nums.Add(root.val);
            Inorder(root.right, nums);
        }

        //寻找交换点
        public int[] FindTwoSwapped(List<int> nums)
        {
            int n = nums.Count;
            int x = -1, y = -1;
            for (int i = 0; i < n - 1; ++i)
            {
                if (nums[i + 1] < nums[i])
                {
                    y = nums[i + 1];
                    if (x == -1)
                    {
                        x = nums[i];
                    }
                    else
                    {
                        break;
                    }
                }
            }
            return new int[] { x, y };
        }

        //恢复交换点
        public void Recover(TreeNode root, int count, int x, int y)
        {
            if (root != null)
            {
                if (root.val == x || root.val == y)
                {
                    root.val = root.val == x ? y : x;
                    if (--count == 0)
                    {
                        return;
                    }
                }
                Recover(root.right, count, x, y);
                Recover(root.left, count, x, y);
            }
        }
    }
    // @lc code=end


}
