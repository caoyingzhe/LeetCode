using System;
namespace CSharpConsoleApp.Solutions
{
    public class Solution111 : SolutionBase
    {
        public override bool Test(System.Diagnostics.Stopwatch sw)
        {
            TreeNode node = TreeNode.Create(new string[] { "3","9", "20",null,null, "15", "7" });
            int result = MinDepth(node);
            Print("Depth = {0} | anticipated = {1}", result, 2);

            node = TreeNode.Create(new string[] { "2", null,"3", null, null, null,"4", null, null, null, null, null, null, null, "5", null, null, null, null, null, null, null, null, null, null, null, null, null, null, null,"6" });
            result = MinDepth(node);
            Print("Depth = {0} | anticipated = {1}", result, 5);

            return true;
        }

        /// <summary>
        /// 52/52 cases passed (328 ms)
        /// Your runtime beats 63.64 % of csharp submissions
        /// Your memory usage beats 25.32 % of csharp submissions(50.2 MB)
        /// 作者：reals
        /// 链接：https://leetcode-cn.com/problems/minimum-depth-of-binary-tree/solution/li-jie-zhe-dao-ti-de-jie-shu-tiao-jian-by-user7208/
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public int MinDepth(TreeNode root)
        {
            if (root == null) return 0;

            int m1 = MinDepth(root.left);
            int m2 = MinDepth(root.right);

            if (root.left == null || root.right == null) //2.如果都不为空，返回较小深度+1
                return m1 + m2 + 1;
            else
                return Math.Min(m1, m2) + 1;             //1.如果左孩子和右孩子有为空的情况，直接返回m1+m2+1
        }

    }
}
