using System;
using System.Collections.Generic;
namespace CSharpConsoleApp.Solutions
{
    /*
     * @lc app=leetcode.cn id=501 lang=csharp
     *
     * [501] 二叉搜索树中的众数
     *
     * https://leetcode-cn.com/problems/find-mode-in-binary-search-tree/description/
     *
     * Category	Difficulty	Likes	Dislikes
     * algorithms	Easy (50.84%)	315	-
     * Tags
     * tree
     * 
     * Companies
     * google
     * 
     * Total Accepted:    56.2K
     * Total Submissions: 110.6K
     * Testcase Example:  '[1,null,2,2]'
     *
     * 给定一个有相同值的二叉搜索树（BST），找出 BST 中的所有众数（出现频率最高的元素）。
     * 
     * 假定 BST 有如下定义：
     * 
     * 结点左子树中所含结点的值小于等于当前结点的值
     * 结点右子树中所含结点的值大于等于当前结点的值
     * 左子树和右子树都是二叉搜索树
     * 
     * 例如：
     * 给定 BST [1,null,2,2],
     * 
     * ⁠  1
     * ⁠   \
     * ⁠    2
     * ⁠   /
     * ⁠  2
     * 
     * 返回[2].
     * 
     * 提示：如果众数超过1个，不需考虑输出顺序
     * 进阶：你可以不使用额外的空间吗？（假设由递归产生的隐式调用栈的开销不被计算在内）
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
    public class Solution501 : SolutionBase
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
        public override Tag[] GetTags() { return new Tag[] { Tag.Array, }; }

        public override bool Test(System.Diagnostics.Stopwatch sw)
        {
            bool isSuccess = true;
            TreeNode nums;
            int[] result, checkResult;

            nums = TreeNode.Create(new string[] { "1", "null", "2", "null", "null", "2" });
            checkResult = new int[] { 2 };
            result = FindMode(nums);

            isSuccess &= IsSame(result, checkResult);
            PrintResult(isSuccess, (result), (checkResult));
            return isSuccess;
        }

        /// <summary>
        /// 22/22 cases passed (292 ms)
        /// Your runtime beats 61.76 % of csharp submissions
        /// Your memory usage beats 82.35 % of csharp submissions(33 MB)
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public int[] FindMode(TreeNode root)
        {
            BST(root);
            return list.ToArray();
        }

        int count = 0;  //记当前个数
        int max = 1;    //记最大值
        int pre_value = 0;  //记前一个value
        List<int> list = new List<int>();  //一个个添加 只能用list

        //作者：zhao-106
        //链接：https://leetcode-cn.com/problems/find-mode-in-binary-search-tree/solution/java-zhong-xu-bian-li-di-gui-100-by-zhao-odh6/
        public void BST(TreeNode root)
        {
            //左根右；中序遍历；从小到大
            if (root == null) return;

            //Step1. 处理左边节点
            BST(root.left);

            //Step2. 处理中间节点
            { 
                if (root.val == pre_value)
                {
                    //如果和前一个相同 count+1
                    count++;
                }
                else
                {
                    //不同； 刷新count=1；刷新pre_value
                    pre_value = root.val;
                    count = 1;
                }
                if (count == max)
                {   //如果是最大个数
                    list.Add(root.val); //加入list里
                }
                else if (count > max)
                {   //如果超过最大个数
                    list.Clear();   //清空整个list
                    list.Add(root.val); //加入list里（新的max）
                    max = count;    //刷新max
                }
            }
            //Step3. 处理右边节点
            BST(root.right);
        }

        
    }
    // @lc code=end


}
