using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TreeNode = CSharpConsoleApp.Solutions.SolutionBase.TreeNode;

namespace CSharpConsoleApp.Solutions._0200
{
    /*
     * @lc app=leetcode.cn id=297 lang=csharp
     *
     * [297] 二叉树的序列化与反序列化
     *
     * https://leetcode-cn.com/problems/serialize-and-deserialize-binary-tree/description/
     *
     * Category	Difficulty	Likes	Dislikes
     * algorithms	Hard (54.91%)	575	-
     * Tags
     * tree | design
     * 
     * Companies
     * amazon | bloomberg | facebook | google | linkedin | microsoft | uber | yahoo
     *
     * Total Accepted:    76.4K
     * Total Submissions: 140.4K
     * Testcase Example:  '[1,2,3,null,null,4,5]'
     *
     * 
     * 序列化是将一个数据结构或者对象转换为连续的比特位的操作，进而可以将转换后的数据存储在一个文件或者内存中，同时也可以通过网络传输到另一个计算机环境，采取相反方式重构得到原数据。
     * 
     * 请设计一个算法来实现二叉树的序列化与反序列化。这里不限定你的序列 /
     * 反序列化算法执行逻辑，你只需要保证一个二叉树可以被序列化为一个字符串并且将这个字符串反序列化为原始的树结构。
     * 
     * 提示: 输入输出格式与 LeetCode 目前使用的方式一致，详情请参阅 LeetCode
     * 序列化二叉树的格式。你并非必须采取这种方式，你也可以采用其他的方法解决这个问题。
     * 
     * 
     * 示例 1：
     * 输入：root = [1,2,3,null,null,4,5]
     * 输出：[1,2,3,null,null,4,5]
     * 
     * 
     * 示例 2：
     * 输入：root = []
     * 输出：[]
     * 
     * 
     * 示例 3：
     * 输入：root = [1]
     * 输出：[1]
     * 
     * 
     * 示例 4：
     * 输入：root = [1,2]
     * 输出：[1,2]
     * 
     * 
     * 提示：
     * 树中结点数在范围 [0, 10^4] 内
     * -1000 
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
    class Solution297 : SolutionBase
    {
        public override bool Test(System.Diagnostics.Stopwatch sw)
        {
            bool isSuccess = true;
            int num = 0;

            TreeNode node = new TreeNode();

            Codec obj = new Codec();
            string data = obj.serialize(node);
            TreeNode des = obj.deserialize(data);

            return isSuccess;
        }
    }
    //Using string
    //52/52 cases passed(1104 ms)
    //Your runtime beats 5.06 % of csharp submissions
    //Your memory usage beats 7.6 % of csharp submissions(48.7 MB)

    //Using stringBuilder replace of string.
    //52/52 cases passed(448 ms)
    //Your runtime beats 25.32 % of csharp submissions
    //Your memory usage beats 83.54 % of csharp submissions(33.2 MB)

    //Using stringBuilder replace of string.
    //use index++ replace of list.RemoveAt(0);
    //52/52 cases passed(136 ms)
    //Your runtime beats 84.81 % of csharp submissions
    //Your memory usage beats 60.76 % of csharp submissions(33.4 MB)
    //作者：LeetCode - Solution
    //链接：https://leetcode-cn.com/problems/serialize-and-deserialize-binary-tree/solution/er-cha-shu-de-xu-lie-hua-yu-fan-xu-lie-hua-by-le-2/
    public class Codec
    {
        string STRING_NULL = "NULL";
        char CHAR_SPLIT = ',';
        int rdesIndex = 0;
        // Encodes a tree to a single string.
        public StringBuilder rserialize(TreeNode root, StringBuilder sb)
        {
            if (root == null)
            {
                //根为空，添加空字符+分隔符, 默认为 "NULL,";
                //str += STRING_NULL + CHAR_SPLIT;
                sb.Append("NULL,");
            }
            else
            {
                //处理顺序：根->左->右。
                sb.Append(root.val).Append(CHAR_SPLIT); //string.valueOf = .Tostring()
                sb = rserialize(root.left, sb);
                sb = rserialize(root.right, sb);
            }
            return sb;
        }

        public TreeNode rdeserialize(List<string> l)
        {
            //if (l[0].Equals(STRING_NULL))
            if (l[rdesIndex].Equals("NULL"))
            {
                //l.RemoveAt(0);  //
                rdesIndex++;
                return null;
            }

            //处理顺序：根->左->右。
            TreeNode root = new TreeNode(int.Parse(l[rdesIndex]));
            //l.RemoveAt(0);
            rdesIndex++;
            root.left = rdeserialize(l);
            root.right = rdeserialize(l);

            return root;
        }

        public string serialize(TreeNode root) {
            return rserialize(root, new StringBuilder()).ToString();
        }

        // Decodes your encoded data to tree.
        public TreeNode deserialize(string data)
        {
            string[] data_array = data.Split(CHAR_SPLIT);
            List<string> data_list = new List<string>(data_array);

            this.rdesIndex = 0;
            return rdeserialize(data_list);
        }
    }
}