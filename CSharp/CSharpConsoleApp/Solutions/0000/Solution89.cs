using System;
using System.Collections.Generic;
namespace CSharpConsoleApp.Solutions
{
    /*
     * @lc app=leetcode.cn id=89 lang=csharp
     *
     * [89] 格雷编码
     *
     * https://leetcode-cn.com/problems/gray-code/description/
     *
     * Category	Difficulty	Likes	Dislikes
     * algorithms	Medium (70.66%)	301	-
     * Tags
     * backtracking
     * 
     * Companies
     * amazon
     * 
     * Total Accepted:    51.2K
     * Total Submissions: 72.5K
     * Testcase Example:  '2'
     *
     * 格雷编码是一个二进制数字系统，在该系统中，两个连续的数值仅有一个位数的差异。
     * 给定一个代表编码总位数的非负整数 n，打印其格雷编码序列。即使有多个不同答案，你也只需要返回其中一种。
     * 格雷编码序列必须以 0 开头。
     * 
     * 示例 1:
     * 输入: 2
     * 输出: [0,1,3,2]
     * 解释:
     * 00 - 0
     * 01 - 1
     * 11 - 3
     * 10 - 2
     * 
     * 对于给定的 n，其格雷编码序列并不唯一。
     * 例如，[0,2,3,1] 也是一个有效的格雷编码序列。
     * 
     * 00 - 0
     * 10 - 2
     * 11 - 3
     * 01 - 1
     * 
     * 示例 2:
     * 输入: 0
     * 输出: [0]
     * 解释: 我们定义格雷编码序列必须以 0 开头。
     * 给定编码总位数为 n 的格雷编码序列，其长度为 2^n。当 n = 0 时，长度为 2^0 = 1。
     * 因此，当 n = 0 时，其格雷编码序列为 [0]。
     */

    // @lc code=start
    public class Solution89 : SolutionBase
    {
        /// <summary>
        /// 难易度:
        /// </summary>
        public override Difficulity GetDifficulity() { return Difficulity.Medium; }
        /// <summary>
        /// 关键字:
        /// </summary>
        public override string[] GetKeyWords() { return new string[] { "" }; }
        /// <summary>
        /// 标签： binary-search | divide-and-conquer | sort | binary-indexed-tree | segment-tree
        /// </summary>
        public override Tag[] GetTags() { return new Tag[] { Tag.Backtracking }; }

        public override bool Test(System.Diagnostics.Stopwatch sw)
        {
            bool isSuccess = false;
            //TODO
            return isSuccess;
        }
        //作者：Xiaohu9527
        //链接：https://leetcode-cn.com/problems/gray-code/solution/c5xing-dai-ma-xiang-xi-jie-xi-dui-xin-sh-xrkw/
        /// <summary>
        /// 16/16 cases passed (240 ms)
        /// Your runtime beats 100 % of csharp submissions
        /// Your memory usage beats 46.34 % of csharp submissions(31.9 MB)
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public IList<int> GrayCode(int n)
        {
            List<int> ans = new List<int>();
            int powN = 1 << n;
            for (int i = 0; i < powN; ++i)
                ans.Add(i ^ i >> 1);
            return ans;
        }
    }
    // @lc code=end


}
