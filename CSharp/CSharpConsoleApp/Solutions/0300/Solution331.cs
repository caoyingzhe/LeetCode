using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpConsoleApp.Solutions._0300
{
    /*
     * @lc app=leetcode.cn id=331 lang=csharp
     *
     * [331] 验证二叉树的前序序列化
     *
     * https://leetcode-cn.com/problems/verify-preorder-serialization-of-a-binary-tree/description/
     *
     * Category	Difficulty	Likes	Dislikes
     * algorithms	Medium (47.88%)	313	-
     * Tags
     * stack
     * 
     * Companies
     * google
     * 
     * Total Accepted:    41.2K
     * Total Submissions: 85.9K
     * Testcase Example:  '"9,3,4,#,#,1,#,#,2,#,6,#,#"'
     *
     * 序列化二叉树的一种方法是使用前序遍历。当我们遇到一个非空节点时，我们可以记录下这个节点的值。如果它是一个空节点，我们可以使用一个标记值记录，例如 #。
     * 
     * ⁠    _9_
     * ⁠   /   \
     * ⁠  3     2
     * ⁠ / \   / \
     * ⁠4   1  #  6
     * / \ / \   / \
     * # # # #   # #
     * 
     * 
     * 例如，上面的二叉树可以被序列化为字符串 "9,3,4,#,#,1,#,#,2,#,6,#,#"，其中 # 代表一个空节点。
     * 
     * 给定一串以逗号分隔的序列，验证它是否是正确的二叉树的前序序列化。编写一个在不重构树的条件下的可行算法。
     * 
     * 每个以逗号分隔的字符或为一个整数或为一个表示 null 指针的 '#' 。
     * 
     * 你可以认为输入格式总是有效的，例如它永远不会包含两个连续的逗号，比如 "1,,3" 。
     * 
     * 示例 1:
     * 
     * 输入: "9,3,4,#,#,1,#,#,2,#,6,#,#"
     * 输出: true
     * 
     * 示例 2:
     * 
     * 输入: "1,#"
     * 输出: false
     * 
     * 
     * 示例 3:
     * 
     * 输入: "9,#,#,1"
     * 输出: false
     * 
     */

    class Solution331 : SolutionBase
    {
        /// <summary>
        /// 难易度:
        /// </summary>
        public override Difficulity GetDifficulity() { return Difficulity.Medium; }
        /// <summary>
        /// 关键字:
        /// </summary>
        public override string[] GetKeyWords() { return new string[] { "前序序列化", "入度出度" }; }
        /// <summary>
        /// 标签：
        /// </summary>
        public override Tag[] GetTags() { return new Tag[] { Tag.Stack, Tag.DivideAndConquer }; }

        //TODO
        public override bool Test(System.Diagnostics.Stopwatch sw)
        {
            bool isSuccess = true;

            isSuccess &= IsValidSerialization("9,3,4,#,#,1,#,#,2,#,6,#,#") == true;
            return isSuccess;
        }

        
        /// <summary>
        /// 弄清楚前序遍历的遍历顺序：
        /// 1. 根节点
        /// 2. 左子树
        /// 3. 右子树
        /// 
        /// 我们知道，对于一棵二叉树的前序序列，其根节点一定是序列的首元素，
        /// 左子树根节点一定是第2个元素，
        /// 右子树的根节点是未知的，要通过左子树的遍历才能直到。
        /// </summary>
        /// <param name="preorder"></param>
        /// <returns></returns>
        // 方法2：分治算法
        public bool IsValidSerialization(String preorder)
        {
            return dfs(preorder, "start") && index == preorder.Length;
        }

        int index = 0;
        int count = 0;
        public bool dfs(String s, string info="")
        {
            count++;
            if (index == s.Length) return false;

            if (s[index] == ',')
            {
                Print(info + "1.  index = {0:D2} | count ={2} | {1}", index, s[index], count);
                index++;//发现节点分隔符，index++
            }
            if (s[index] == '#')         //发现空节点，index++ 
            {
                Print(info + "2.  index = {0:D2} | count ={2} | {1}", index, s[index], count);
                index++;
                return true;
            }
            else
            {
                Print(info + "3.1 index = {0:D2} | count ={2} | {1}", index, s[index], count);
                while (index < s.Length && s[index] <= '9' && s[index] >= '0') //发现数字字符，index++
                    index++;
            }
            return dfs(s, "Last Left Count=" + count + " Index=" + index) && dfs(s, "Last Right Count=" + count + " Index=" + index);
        }
    }
}
