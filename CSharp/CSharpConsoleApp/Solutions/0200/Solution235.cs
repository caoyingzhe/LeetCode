using System;
using System.Collections.Generic;
namespace CSharpConsoleApp.Solutions
{
    public class Solution235 : SolutionBase
    {
        /// <summary>
        /// 难度
        /// </summary>
        public override Difficulity GetDifficulity() { return Difficulity.Easy; }
        /// <summary>
        /// 关键字:
        /// </summary>
        public override string[] GetKeyWords() { return new string[] { }; }
        /// <summary>
        /// 标签：
        /// </summary>
        public override Tag[] GetTags() { return new Tag[] { Tag.LinkedList }; }

        public override bool Test(System.Diagnostics.Stopwatch sw)
        {
            bool isSuccess = true;
            TreeNode root, p, q;

            int result, checkResult;
            TreeNode resultNode;

            root = TreeNode.Create(new string[] { "6", "2", "8", "0", "4", "7", "9" });
            List<TreeNode> list = root.GetNodeList();
            p = list.Find(o => o!= null && o.val == 4);
            q = list.Find(o => o!= null && o.val == 8);
            checkResult = 6;
            resultNode = LowestCommonAncestor(root, p, q);
            result = resultNode == null ? -1 : resultNode.val;
            isSuccess &= (result == checkResult);
            Print("isSuccess = {0} | result = {1} | anticipated = {2}", isSuccess, result, checkResult);

            p = list.Find(o => o != null && o.val == 2);
            q = list.Find(o => o != null && o.val == 4);
            checkResult = 6;
            resultNode = LowestCommonAncestor(root, p, q);
            result = resultNode == null ? -1 : resultNode.val;
            isSuccess &= (result == checkResult);
            Print("isSuccess = {0} | result = {1} | anticipated = {2}", isSuccess, result, checkResult);

            return isSuccess;
        }

        /// <summary>
        /// 关键条件：二叉搜索树 （符合中序排列：左边小，右边大）
        /// 作者：LeetCode-Solution
        /// 链接：https://leetcode-cn.com/problems/lowest-common-ancestor-of-a-binary-search-tree/solution/er-cha-sou-suo-shu-de-zui-jin-gong-gong-zu-xian-26/
        /// </summary>
        /// <param name="root"></param>
        /// <param name="p"></param>
        /// <param name="q"></param>
        /// <returns></returns>
        public TreeNode LowestCommonAncestor(TreeNode root, TreeNode p, TreeNode q)
        {
            TreeNode ancestor = root;
            while (true)
            {
                if (p.val < ancestor.val && q.val < ancestor.val)
                {
                    ancestor = ancestor.left;
                }
                else if (p.val > ancestor.val && q.val > ancestor.val)
                {
                    ancestor = ancestor.right;
                }
                else
                {
                    break;
                }
            }
            return ancestor;
        }
        public TreeNode LowestCommonAncestor_MyTODO(TreeNode root, TreeNode p, TreeNode q)
        {
            List<TreeNode> pParents = new List<TreeNode>();
            List<TreeNode> qParents = new List<TreeNode>();
            GetParentNodeList(root, p, pParents);
            GetParentNodeList(root, q, qParents);

            int minCount = Math.Min(pParents.Count, qParents.Count);

            TreeNode rtn = null;
            for (int i=0; i<minCount; i++)
            {
                if(pParents[i] == qParents[i])
                {
                    rtn = pParents[i];
                }
                else
                {
                    break;
                }
            }
            return rtn;
        }

        public List<TreeNode> GetPath(TreeNode root, TreeNode target)
        {
            List<TreeNode> path = new List<TreeNode>();
            TreeNode node = root;
            while (node != target)
            {
                path.Add(node);
                if (target.val < node.val)
                {
                    node = node.left;
                }
                else
                {
                    node = node.right;
                }
            }
            path.Add(node);
            return path;
        }
        /// <summary>
        /// TODO 取得父对象列表 
        /// </summary>
        /// <param name="node"></param>
        /// <param name="childNode"></param>
        /// <param name="nodeList"></param>
        /// <returns></returns>
        public static int GetParentNodeList(TreeNode node, TreeNode childNode, List<TreeNode> nodeList)
        {

            if (node == null || childNode == null)
            {
                return 0;
            }
            if (node.left == childNode)
            {
                nodeList.Add(node);
                return 1;
            }
            else if (node.left == childNode)
            {
                nodeList.Add(node);
                return 2;
            }

            if (GetParentNodeList(node.left, childNode, nodeList) == 1)
            {
                nodeList.Add(node.left);
                return 1;
            }
            if (GetParentNodeList(node.right, childNode, nodeList) == 2)
            {
                nodeList.Add(node.right);
                return 2;
            }
            return 0;
        }

    }
}
