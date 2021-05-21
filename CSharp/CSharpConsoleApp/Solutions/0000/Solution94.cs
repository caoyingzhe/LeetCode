using System;
using System.Collections.Generic;

namespace CSharpConsoleApp.Solutions
{
    public class Solution94 : SolutionBase
    {
        /// <summary>
        /// 难易度:
        /// </summary>
        public override Difficulity GetDifficulity() { return Difficulity.Easy; }
        /// <summary>
        /// 关键字:
        /// </summary>
        public override string[] GetKeyWords() { return new string[] { "LinkedList", "Stack", "Tree" }; }
        /// <summary>
        /// 标签： 图
        /// </summary>
        public override Tag[] GetTags() { return new Tag[] { Tag.LinkedList, Tag.Stack, Tag.Tree, }; }
        public override bool Test(System.Diagnostics.Stopwatch sw)
        {
            bool isSuccess = true;
            return isSuccess;
        }

        /// <summary>
        /// 68/68 cases passed (284 ms)
        /// Your runtime beats 44.51 % of csharp submissions
        /// Your memory usage beats 66.03 % of csharp submissions(29.8 MB)
        /// 作者：LeetCode-Solution
        /// 链接：https://leetcode-cn.com/problems/binary-tree-inorder-traversal/solution/er-cha-shu-de-zhong-xu-bian-li-by-leetcode-solutio/
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public List<int> InorderTraversal(TreeNode root)
        {
            List<int> res = new List<int>();
            Inorder(root, res);
            return res;
        }

        public void Inorder(TreeNode root, List<int> res)
        {
            if (root == null)
            {
                return;
            }
            Inorder(root.left, res);
            res.Add(root.val);
            Inorder(root.right, res);
        }
    }
}
