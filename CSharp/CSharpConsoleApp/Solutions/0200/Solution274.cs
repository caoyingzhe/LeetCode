using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpConsoleApp.Solutions
{
    /*
     * @lc app=leetcode.cn id=274 lang=csharp
     *
     * [274] H 指数
     *
     * https://leetcode-cn.com/problems/h-index/description/
     *
     * algorithms
     * Medium (39.33%)
     * Likes:    141
     * Dislikes: 0
     * Total Accepted:    25.2K
     * Total Submissions: 64K
     * Testcase Example:  '[3,0,6,1,5]'
     *
     * 给定一位研究者论文被引用次数的数组（被引用次数是非负整数）。编写一个方法，计算出研究者的 h 指数。
     * 
     * h 指数的定义：h 代表“高引用次数”（high citations），一名科研人员的 h 指数是指他（她）的 （N 篇论文中）总共有 h
     * 篇论文分别被引用了至少 h 次。且其余的 N - h 篇论文每篇被引用次数 不超过 h 次。
     * 
     * 例如：某人的 h 指数是 20，这表示他已发表的论文中，每篇被引用了至少 20 次的论文总共有 20 篇。
     * 
     * 示例：
     * 输入：citations = [3,0,6,1,5]
     * 输出：3 
     * 解释：给定数组表示研究者总共有 5 篇论文，每篇论文相应的被引用了 3, 0, 6, 1, 5 次。
     * 由于研究者有 3 篇论文每篇 至少 被引用了 3 次，其余两篇论文每篇被引用 不多于 3 次，所以她的 h 指数是 3。
     * 
     * 提示：如果 h 有多种可能的值，h 指数是其中最大的那个。
     * 
     */

    class Solution274 : SolutionBase
    {
        /// <summary>
        /// 难度
        /// </summary>
        public override Difficulity GetDifficulity() { return Difficulity.Medium; }
        /// <summary>
        /// 关键字:
        /// </summary>
        public override string[] GetKeyWords() { return new string[] { "直方图"  }; }
        /// <summary>
        /// 标签： 
        /// </summary>
        public override Tag[] GetTags() { return new Tag[] { Tag.HashTable, Tag.Sort }; }

        public override bool Test(System.Diagnostics.Stopwatch sw)
        {
            bool isSuccess = true;
            isSuccess &= (HIndex(new int[] { 3, 0, 6, 1, 5 }) == 3);
            //isSuccess &= (HIndex(new int[] { 1,3,1 }) == 1);
            return isSuccess;
        }

        /// <summary>
        /// 渣渣算法
        /// Your runtime beats 5.56 % of csharp submissions
        /// Your memory usage beats 5.56 % of csharp submissions(25.2 MB)
        /// </summary>
        /// <param name="citations"></param>
        /// <returns></returns>
        public int HIndex_My(int[] citations)
        {
            int n = citations.Length;
            Dictionary<int, int> map = new Dictionary<int, int>();
            List<int> list = new List<int>(citations);
            list.Sort();

            // 0,1,3,
            for(int i=n-1; i>=0; i--)
            {
                //list[i]代表被引用的次数, i+1代表第几篇文章
                int h = i + 1;
                map.Add(h, list.Where<int>(t => t >= h).Count());
                
                if(h <= map[h])
                    return h;
            }
            return 0;
        }

        /// <summary>
        /// 直方图比较法
        /// </summary>
        /// <param name="citations"></param>
        /// <returns></returns>
        public int HIndex_Diagram(int[] citations)
        {
            // 排序（注意这里是升序排序，因此下面需要倒序扫描）
            List<int> list = new List<int>(citations);
            list.Sort();

            int n = citations.Length;
            // 线性扫描找出最大的 i
            int i = 0;
            while (i < n && list[n - 1 - i] > i)
            {
                i++;
            }
            return i;
        }

        /// <summary>
        /// 计数法
        /// </summary>
        /// <param name="citations"></param>
        /// <returns></returns>
        public int HIndex(int[] citations)
        {
            int n = citations.Length;

            // 计数 (从0～n)  [3, 0, 6, 1, 5] => [1,1,0,1,0,2] => c[3]++, c[0]++， c[5]++, c[1]++ c[5]++
            int[] papers = new int[n + 1];
            foreach (int c in citations)
                papers[Math.Min(n, c)]++;

            // 找出最大的 k
            int k = n;
            //从后到前计数 
            //步骤 
            // s = 2 < k = 5 | k-- => 4, papker[k] = 2
            // s = 2 < k = 4 | k-- => 3, papker[k] = 0
            // s = 3 < k = 3 | k-- => 2, papker[k] = 1
            int s = papers[n];
            for (; s < k ; s += papers[k])
            {
                Print("s={0} < k= {1} |  k -- => {2}, papker[k] = {3}", s, k, (k-1), papers[k]);
                k--;
            }
            Print("s={0} < k= {1} |  k -- => {2}, papker[k] = {3}", s, k, (k - 1), papers[k]);
            return k;
        }
    }
}
