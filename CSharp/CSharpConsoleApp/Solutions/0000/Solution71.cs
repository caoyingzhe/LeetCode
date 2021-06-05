using System;
using System.Collections.Generic;
namespace CSharpConsoleApp.Solutions
{
    /*
     * @lc app=leetcode.cn id=71 lang=csharp
     *
     * [71] 简化路径
     *
     * https://leetcode-cn.com/problems/simplify-path/description/
     *
     * Category	Difficulty	Likes	Dislikes
     * algorithms	Medium (41.91%)	280	-
     * Tags
     * string | stack
     * 
     * Companies
     * facebook | microsoft
     * Total Accepted:    80.5K
     * Total Submissions: 191.9K
     * Testcase Example:  '"/home/"'
     *
     * 给你一个字符串 path ，表示指向某一文件或目录的 Unix 风格 绝对路径 （以 '/' 开头），请你将其转化为更加简洁的规范路径。
     * 
     * 在 Unix 风格的文件系统中，
     * 一个点（.）表示当前目录本身；
     * 此外，两个点 （..）表示将目录切换到上一级（指向父目录）；
     * 两者都可以是复杂相对路径的组成部分。
     * 任意多个连续的斜杠（即，'//'）都被视为单个斜杠 '/' 。
     * 对于此问题，任何其他格式的点（例如，'...'）均被视为文件/目录名称。
     * 
     * 请注意，返回的 规范路径 必须遵循下述格式：
     * 
     * 
     * 始终以斜杠 '/' 开头。
     * 两个目录名之间必须只有一个斜杠 '/' 。
     * 最后一个目录名（如果存在）不能 以 '/' 结尾。
     * 此外，路径仅包含从根目录到目标文件或目录的路径上的目录（即，不含 '.' 或 '..'）。
     * 
     * 返回简化后得到的 规范路径 。
     * 
     * 示例 1：
     * 输入：path = "/home/"
     * 输出："/home"
     * 解释：注意，最后一个目录名后面没有斜杠。 
     * 
     * 示例 2：
     * 输入：path = "/../"
     * 输出："/"
     * 解释：从根目录向上一级是不可行的，因为根目录是你可以到达的最高级。
     * 
     * 示例 3：
     * 输入：path = "/home//foo/"
     * 输出："/home/foo"
     * 解释：在规范路径中，多个连续斜杠需要用一个斜杠替换。
     * 
     * 示例 4：
     * 输入：path = "/a/./b/../../c/"
     * 输出："/c"
     * 
     * 提示：
     * 1 <= path.length <= 3000
     * path 由英文字母，数字，'.'，'/' 或 '_' 组成。
     * path 是一个有效的 Unix 风格绝对路径。
     */
    public class Solution71 : SolutionBase
    {
        /// <summary>
        /// 难度
        /// </summary>
        public override Difficulity GetDifficulity() { return Difficulity.Medium; }
        /// <summary>
        /// 关键字:
        /// </summary>
        public override string[] GetKeyWords() { return new string[] { }; }
        /// <summary>
        /// 标签：
        /// </summary>
        public override Tag[] GetTags() { return new Tag[] { Tag.String, Tag.Stack}; }

        public override bool Test(System.Diagnostics.Stopwatch sw)
        {
            bool isSuccess = true;
            return isSuccess;
        }

        /// <summary>
        /// 256/256 cases passed (104 ms)
        /// Your runtime beats 87.67 % of csharp submissions
        /// Your memory usage beats 57.53 % of csharp submissions(25.3 MB)
        /// 作者：powcai
        /// 链接：https://leetcode-cn.com/problems/simplify-path/solution/zhan-by-powcai/
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public string SimplifyPath(string path)
        {
            Stack<String> stack = new Stack<String>();
            foreach (String item in path.Split('/')) //此处Split可以分隔多个连续的/，简化了处理。
            {
                if (item.Equals(".."))
                {
                    if (stack.Count != 0) //如果遇到..，返回上级目录，需要弹出栈
                        stack.Pop();
                }
                else if (!string.IsNullOrEmpty(item) && !item.Equals(".")) //如果没有遇到.，表示不是当前目录，需要压入栈
                    stack.Push(item);
            }

            //    String res = "";
            //    foreach (String d in stack)
            //        res = "/" + d + res;
            //    return string.IsNullOrEmpty(res) ? "/" : res;
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            foreach (String d in stack)
                sb.Insert(0, "/").Insert(0, d);
            return sb.Length == 0 ? "/" : sb.ToString();
        }
    }
}
