using System;
using System.Collections.Generic;
using TreeNode = CSharpConsoleApp.Solutions.SolutionBase.TreeNode;
using System.Text;
namespace CSharpConsoleApp.Solutions
{

    /*
        * @lc app=leetcode.cn id=449 lang=csharp
        *
        * [449] 序列化和反序列化二叉搜索树
        *
        * https://leetcode-cn.com/problems/serialize-and-deserialize-bst/description/
        *
        * Category	Difficulty	Likes	Dislikes
        * algorithms	Medium (55.37%)	188	-
        * Tags
        * tree
        * 
        * Companies
        * amazon
        * 
        * Total Accepted:    13.1K
        * Total Submissions: 23.7K
        * Testcase Example:  '[2,1,3]'
        *
        * 序列化是将数据结构或对象转换为一系列位的过程，以便它可以存储在文件或内存缓冲区中，或通过网络连接链路传输，以便稍后在同一个或另一个计算机环境中重建。
        * 
        * 设计一个算法来序列化和反序列化 二叉搜索树 。 对序列化/反序列化算法的工作方式没有限制。
        * 您只需确保二叉搜索树可以序列化为字符串，并且可以将该字符串反序列化为最初的二叉搜索树。
        * 
        * 编码的字符串应尽可能紧凑。
        * 
        * 
        * 示例 1：
        * 输入：root = [2,1,3]
        * 输出：[2,1,3]
        * 
        * 
        * 示例 2：
        * 输入：root = []
        * 输出：[]
        * 
        * 
        * 提示：
        * 树中节点数范围是 [0, 10^4]
        * 0 <= Node.val <= 104
        * 题目数据 保证 输入的树是一棵二叉搜索树。
        * 
        * 注意：不要使用类成员/全局/静态变量来存储状态。 你的序列化和反序列化算法应该是无状态的。
        */

    // @lc code=start
    /**
        * Definition for a binary tree node.
        * public class TreeNode {
        *     public int val;
        *     public TreeNode left;
        *     public TreeNode right;
        *     public TreeNode(int x) { val = x; }
        * }
        */

    //由于二叉搜索树的特殊性质，先序遍历或后序遍历即可唯一确定二叉搜索树的结构，
    public class Solution449 : SolutionBase
    {
        /// <summary>
        /// </summary>
        /// <param name="sw"></param>
        /// <returns></returns>
        public override bool Test(System.Diagnostics.Stopwatch sw)
        {
            bool isSuccess = true;

            TreeNode node = TreeNode.Create(new int[] { 2, 1, 3 }, -1);
            Codec codec = new Codec();
            string ser = codec.serialize(node);
            TreeNode node2 = codec.deserialize(ser);

            isSuccess &= IsSame(node, node2);
            PrintResult(isSuccess, node.GetNodeString(), node2.GetNodeString());
            return isSuccess;
        }

        //二叉树可以通过前序序列或后序序列和中序序列构造。
        //二叉搜索树的中序序列是递增排序的序列，inorder = sorted(preorder)。
        //对于反序列化我们选择后续遍历会更好

        //方法一：后序遍历优化树结构的空间
        //方法二：将节点值转换为四个字节的字符串优化空间
        //方法三：不使用分隔符

        /// <summary>
        /// 62/62 cases passed (136 ms)
        ///Your runtime beats 28.57 % of csharp submissions
        ///Your memory usage beats 57.14 % of csharp submissions(30.6 MB)
        /// https://leetcode-cn.com/problems/serialize-and-deserialize-bst/solution/xu-lie-hua-he-fan-xu-lie-hua-er-cha-sou-suo-shu-2/
        /// 方法三：不使用分隔符
        /// </summary>
        public class Codec
        {
            // Encodes a tree to a single string.
            public string serialize(TreeNode root)
            {
                StringBuilder sb = postorder(root, new StringBuilder());
                if (sb.Length > 0)
                    sb.Remove(sb.Length - 1, 1);
                return sb.ToString();
            }

            // Decodes your encoded data to tree.
            public TreeNode deserialize(string data)
            {
                if (string.IsNullOrEmpty(data))
                    return null;
                LinkedList<int> nums = new LinkedList<int>();
                foreach (String s in data.Split(' ')) //Java  data.split("\\s+") \\s+ --->以空格进行分割, 至少出现一个空格，
                    nums.AddLast(int.Parse(s));           //Java  nums.add(Integer.valueOf(s));
                return helper(int.MinValue, int.MaxValue, nums);
            }

            public StringBuilder postorder(TreeNode root, StringBuilder sb)
            {
                if (root == null)
                    return sb;
                postorder(root.left, sb);
                postorder(root.right, sb);
                sb.Append(root.val);
                sb.Append(' ');
                return sb;
            }

            public TreeNode helper(int lower, int upper, LinkedList<int> nums)
            {
                if (nums.Count == 0)
                    return null;
                int val = nums.Last.Value;
                if (val < lower || val > upper)
                    return null;

                nums.RemoveLast();
                TreeNode root = new TreeNode(val);
                root.right = helper(val, upper, nums);
                root.left = helper(lower, val, nums);
                return root;
            }
        }

    }
    // Your Codec object will be instantiated and called as such:
    // Codec ser = new Codec();
    // Codec deser = new Codec();
    // String tree = ser.serialize(root);
    // TreeNode ans = deser.deserialize(tree);
    // return ans;
    // @lc code=end
}
