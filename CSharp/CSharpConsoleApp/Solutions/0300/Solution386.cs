using System;
using System.Collections.Generic;
namespace CSharpConsoleApp.Solutions
{
    /*
 * @lc app=leetcode.cn id=386 lang=csharp
 *
 * [386] 字典序排数
 *
 * https://leetcode-cn.com/problems/lexicographical-numbers/description/
 *
 * Category	Difficulty	Likes	Dislikes
 * algorithms	Medium (73.85%)	182	-
 * Tags
 * Unknown
 * 
 * Companies
 * bloomberg
 * 
 * Total Accepted:    19.3K
 * Total Submissions: 26.1K
 * Testcase Example:  '13'
 *
 * 给定一个整数 n, 返回从 1 到 n 的字典顺序。
 * 
 * 例如，
 * 
 * 给定 n =1 3，返回 [1,10,11,12,13,2,3,4,5,6,7,8,9] 。
 * 
 * 请尽可能的优化算法的时间复杂度和空间复杂度。 输入的数据 n 小于等于 5,000,000。
 * 
 */

    // @lc code=start
    public class Solution386 : SolutionBase
    {
        /// <summary>
        /// 难度
        /// </summary>
        public override Difficulity GetDifficulity() { return Difficulity.Medium; }
        /// <summary>
        /// 关键字:
        /// </summary>
        public override string[] GetKeyWords() { return new string[] { "查找重复的数", "Floyd 判圈算法", "141. 环形链表 I", "142. 环形链表 II", }; }
        /// <summary>
        /// 标签：
        /// </summary>
        public override Tag[] GetTags() { return new Tag[] { Tag.DepthFirstSearch, Tag.Tree, }; }

        
        /// <summary>
        /// </summary>
        /// <param name="sw"></param>
        /// <returns></returns>
        public override bool Test(System.Diagnostics.Stopwatch sw)
        {
            bool isSuccess = true;

            int n;
            IList<int> result, checkResult;

            n = 13;
            checkResult = new int[] { 1, 10, 11, 12, 13, 2, 3, 4, 5, 6, 7, 8, 9 };
            result = LexicalOrder(n);
            isSuccess &= IsListSame(result, checkResult);
            PrintResult(isSuccess, GetArrayStr(result), GetArrayStr(checkResult));

            return isSuccess;
        }


        /// <summary>
        /// 作者：ppppjcute
        /// 链接：https://leetcode-cn.com/problems/lexicographical-numbers/solution/java-zi-dian-xu-de-bian-li-by-ppppjqute/
        /// 
        /// 26/26 cases passed (244 ms)
        /// Your runtime beats 100 % of csharp submissions
        /// Your memory usage beats 80 % of csharp submissions(31.4 MB)
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public IList<int> LexicalOrder(int n)
        {
            List<int> list = new List<int>();
            for (int i = 1; i < 10; i++)
            {
                DFS(n, i, list);
            }
            return list;
        }

        private void DFS(int n, int i, List<int> list)
        {
            if (i > n) return;

            list.Add(i);
            for (int j = 0; j <= 9; j++)
            {
                DFS(n, i * 10 + j, list);
            }
        }
    }
    // @lc code=end


}
