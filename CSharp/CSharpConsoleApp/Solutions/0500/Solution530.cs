using System;
using System.Collections.Generic;
namespace CSharpConsoleApp.Solutions
{
    public class Solution530 : SolutionBase
    {
        public override bool Test(System.Diagnostics.Stopwatch sw)
        {
            return true;
        }

        //作者：wo-yao-chu-qu-luan-shuo
        //链接：https://leetcode-cn.com/problems/minimum-absolute-difference-in-bst/solution/530-er-cha-sou-suo-shu-de-zui-xiao-jue-d-1nqx/

        /// <summary>
        /// 索然无味
        /// 188/188 cases passed (124 ms)
        /// Your runtime beats 37.5 % of csharp submissions
        /// Your memory usage beats 14.58 % of csharp submissions(28.4 MB)
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public int GetMinimumDifference(TreeNode root)
        {
            List<int> nums = new List<int>();
            DFS(root, nums);                            //此时nums已经是一个有序数组了

            int min_val = int.MaxValue;
            for (int i = 1; i < nums.Count; i++)     //遍历找两个相邻值之间的最小差
            {
                int t = nums[i] - nums[i - 1];
                min_val = Math.Min(min_val, t);
            }

            return min_val;
        }
        //中序遍历模板
        void DFS(TreeNode root, List<int> nums)     
        {
            if (root == null) return;

            DFS(root.left, nums);
            nums.Add(root.val);
            DFS(root.right, nums);
        }
    }
}
