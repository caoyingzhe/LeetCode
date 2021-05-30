using System;
using System.Collections.Generic;
namespace CSharpConsoleApp.Solutions
{
    public class Solution652 : SolutionBase
    {
        public override bool Test(System.Diagnostics.Stopwatch sw)
        {
            bool isSuccess = true;
            return isSuccess;
        }

        int t;
        Dictionary<String, int> trees;
        Dictionary<int, int> count;
        List<TreeNode> ans;

        /// <summary>
        /// 方法二：唯一标识符 （优秀的算法）
        /// 时间复杂度：O(N) N 二叉树上节点的数量
        /// 空间复杂度：O(N)
        ///
        /// 175/175 cases passed (304 ms)
        /// Your runtime beats 100 % of csharp submissions
        /// Your memory usage beats 94.74 % of csharp submissions(34.6 MB)
        /// 作者：LeetCode
        /// 链接：https://leetcode-cn.com/problems/find-duplicate-subtrees/solution/xun-zhao-zhong-fu-de-zi-shu-by-leetcode/
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public IList<TreeNode> FindDuplicateSubtrees(TreeNode root)
        {
            t = 1;
            trees = new Dictionary<String, int>();
            count = new Dictionary<int, int>();
            ans = new List<TreeNode>();
            Lookup(root);
            return ans;
        }

        public int Lookup(TreeNode node)
        {
            if (node == null) return 0;
            String serial = node.val + "," + Lookup(node.left) + "," + Lookup(node.right);
            int uid = GetOrDefault(trees, serial, t++); //int uid = trees.computeIfAbsent(serial, x->t++);
            count[uid] = GetOrDefault(count, uid, 0) + 1;
            if (count[uid] == 2)
                ans.Add(node);
            return uid;
        }
    }
}
