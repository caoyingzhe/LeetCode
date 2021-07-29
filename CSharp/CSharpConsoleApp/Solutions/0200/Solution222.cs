using System;
namespace CSharpConsoleApp.Solutions
{
    /*
 * @lc app=leetcode.cn id=222 lang=csharp
 *
 * [222] 完全二叉树的节点个数
 *
 * https://leetcode-cn.com/problems/count-complete-tree-nodes/description/
 *
 * Category	Difficulty	Likes	Dislikes
 * algorithms	Medium (77.69%)	505	-
 * Tags
 * binary-search | tree
 * 
 * Companies
 * Unknown
 * 
 * Total Accepted:    102.6K
 * Total Submissions: 131.9K
 * Testcase Example:  '[1,2,3,4,5,6]'
 *
 * 给你一棵 完全二叉树 的根节点 root ，求出该树的节点个数。
 * 
 * 完全二叉树
 * 的定义如下：在完全二叉树中，除了最底层节点可能没填满外，其余每层节点数都达到最大值，并且最下面一层的节点都集中在该层最左边的若干位置。若最底层为第 h
 * 层，则该层包含 1~ 2^h 个节点。
 * 
 * 
 * 示例 1：
 * 输入：root = [1,2,3,4,5,6]
 * 输出：6
 * 
 * 
 * 示例 2：
 * 输入：root = []
 * 输出：0
 * 
 * 
 * 示例 3：
 * 输入：root = [1]
 * 输出：1
 * 
 * 
 * 提示：
 * 树中节点的数目范围是[0, 5 * 10^4]
 * 0 <= Node.val <= 5 * 10^4
 * 题目数据保证输入的树是 完全二叉树
 * 
 * 
 * 进阶：遍历树来统计节点是一种时间复杂度为 O(n) 的简单解决方案。你可以设计一个更快的算法吗？
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
    public class Solution222 : SolutionBase
    {
        /// <summary>
        /// 难度
        /// </summary>
        public override Difficulity GetDifficulity() { return Difficulity.Medium; }
        /// <summary>
        /// 关键字:
        /// </summary>
        public override string[] GetKeyWords() { return new string[] { "", }; }
        /// <summary>
        /// 标签：
        /// </summary>
        public override Tag[] GetTags() { return new Tag[] { Tag.BinarySearch, Tag.Tree }; }

        
        public override bool Test(System.Diagnostics.Stopwatch sw)
        {
            bool isSuccess = true;
            TreeNode root;
            int result, checkResult;

            root = TreeNode.CreateBST(new int[] { 1, 2, 3, 4, 5, 6 });
            checkResult = 6;
            result = CountNodes_NG(root);
            isSuccess &= IsSame(result, checkResult);
            PrintResult(isSuccess, (result).ToString(), (checkResult).ToString());

            //root = TreeNode.CreateBST(new int[] { 1, 2, 3, 4, 5, 6, 7, 8 });
            //checkResult = 8;
            //result = CountNodes(root);
            //isSuccess &= IsSame(result, checkResult);
            //PrintResult(isSuccess, (result).ToString(), (checkResult).ToString());

            ///      1
            ///     2,3
            ///  4,5,6,7,
            /// 8,9
            //root = TreeNode.CreateBST(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 });
            //checkResult = 9;
            //result = CountNodes(root);
            //isSuccess &= IsSame(result, checkResult);
            //PrintResult(isSuccess, (result).ToString(), (checkResult).ToString());

            //root = TreeNode.Create(new int[] { NULL }, NULL);
            //checkResult = 0;
            //result = CountNodes(root);
            //isSuccess &= IsSame(result, checkResult);
            //PrintResult(isSuccess, (result).ToString(), (checkResult).ToString());

            //root = TreeNode.CreateBST(new int[] { 1 });
            //checkResult = 1;
            //result = CountNodes(root);
            //isSuccess &= IsSame(result, checkResult);
            //PrintResult(isSuccess, (result).ToString(), (checkResult).ToString());

            return isSuccess;
        }

        ///      1
        ///     2,3
        ///  4,5,6,7,
        /// 8,9
        /// 作者：xiao-ping-zi-5
        /// 链接：https://leetcode-cn.com/problems/count-complete-tree-nodes/solution/chang-gui-jie-fa-he-ji-bai-100de-javajie-fa-by-xia/
        /// <param name="root"></param>
        /// <returns></returns>
        public int CountNodes_NG2(TreeNode root)
        {
            if (root == null)
            {
                return 0;
            }
            int L = CountLevel(root.left);
            int R = CountLevel(root.right);
            //Print("L:{0} R:{1}", L, R);
            if (L == R)
            {
                int RR = CountNodes_NG2(root.right);
                int LP = (1 << L);
                //Print("L:{3} R:{4}  | LP + RR [{0} + {1}]= {2}", LP, RR, RR + LP, L, R);
                return RR + LP;
            }
            else
            {
                int LL = CountNodes_NG2(root.left);
                int RP = (1 << R);
                //return CountNodes(root.left) + (1 << R);
                //Print("L:{3} R:{4}  | RP + LL [{0} + {1}]= {2}", RP, LL, LL + RP, L, R);
                return LL + RP;
            }
        }

        private int CountLevel(TreeNode root)
        {
            int level = 0;
            while (root != null)
            {
                level++;
                root = root.left;
            }
            return level;
        }

        /// <summary>
        /// 完全二叉树的最左边的节点一定位于最底层，
        /// 因此从根节点出发，每次访问左子节点，直到遇到叶子节点，
        /// 该叶子节点即为完全二叉树的最左边的节点，经过的路径长度即为最大层数 h。
        /// 
        /// 作者：LeetCode-Solution
        /// 链接：https://leetcode-cn.com/problems/count-complete-tree-nodes/solution/wan-quan-er-cha-shu-de-jie-dian-ge-shu-by-leetco-2/
        public int CountNodes_NG(TreeNode root)
        {
            if (root == null) return 0;
            
            int depth = 0;
            TreeNode node = root;
            while (node.left != null)
            {
                depth++;
                node = node.left;
            }

            int low = 1 << depth, high = (1 << (depth + 1)) - 1;
            while (low < high)
            {
                Print("L:{0} | H:{1}", low, high);
                int mid = (high - low + 1) / 2 + low;
                if (Exists(root, depth, mid))
                {
                    Print("Low[{0}]=> Mid[{1}]", low, mid);
                    low = mid;
                }
                else
                {
                    Print("high[{0}]=> Mid-1[{1}]", high, mid-1);
                    high = mid - 1;
                }
            }
            return low;
        }

        public bool Exists(TreeNode root, int level, int k)
        {
            int bits = 1 << (level - 1);
            TreeNode node = root;
            while (node != null && bits > 0)
            {
                if ((bits & k) == 0)
                    node = node.left;
                else
                    node = node.right;
                bits >>= 1;
            }
            return node != null;
        }


    }
    // @lc code=end
}
