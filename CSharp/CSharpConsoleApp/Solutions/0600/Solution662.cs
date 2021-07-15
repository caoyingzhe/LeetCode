using System;
using System.Collections.Generic;
namespace CSharpConsoleApp.Solutions
{
    public class Solution662 : SolutionBase
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

        public const int N = int.MinValue;
        /// <summary>
        /// </summary>
        /// <param name="sw"></param>
        /// <returns></returns>
        public override bool Test(System.Diagnostics.Stopwatch sw)
        {
            bool isSuccess = true;
            return isSuccess;
        }

        /// <summary>
        /// TODO
        /// 112/112 cases passed (132 ms)
        /// Your runtime beats 15.38 % of csharp submissions
        /// Your memory usage beats 15.38 % of csharp submissions(26.4 MB)
        /// </summary>
        Dictionary<int, int> left;
        int ans;
        public int WidthOfBinaryTree(TreeNode root)
        {
            ans = 0;
            left = new Dictionary<int, int>();
            DFS(root, 0, 0);
            return ans;
        }
        public void DFS(TreeNode root, int depth, int pos)
        {
            if (root == null) return;
            if (!left.ContainsKey(depth))
                left.Add(depth, pos);
            ans = Math.Max(ans, pos - left[depth] + 1);
            DFS(root.left, depth + 1, 2 * pos);
            DFS(root.right, depth + 1, 2 * pos + 1);
        }
    }
}
