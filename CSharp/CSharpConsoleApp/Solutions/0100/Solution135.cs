using System;
namespace CSharpConsoleApp.Solutions
{
    /*
 * @lc app=leetcode.cn id=135 lang=csharp
 *
 * [135] 分发糖果
 *
 * https://leetcode-cn.com/problems/candy/description/
 *
 * Category	Difficulty	Likes	Dislikes
 * algorithms	Hard (48.23%)	580	-
 * Tags
 * greedy
 * 
 * Companies
 * Unknown
 * 
 * Total Accepted:    83.3K
 * Total Submissions: 172.6K
 * Testcase Example:  '[1,0,2]'
 *
 * 老师想给孩子们分发糖果，有 N 个孩子站成了一条直线，老师会根据每个孩子的表现，预先给他们评分。
 * 
 * 你需要按照以下要求，帮助老师给这些孩子分发糖果：
 *      每个孩子至少分配到 1 个糖果。
 *      评分更高的孩子必须比他两侧的邻位孩子获得更多的糖果。
 * 那么这样下来，老师至少需要准备多少颗糖果呢？
 * 
 * 示例 1：
 * 输入：[1,0,2]
 * 输出：5
 * 解释：你可以分别给这三个孩子分发 2、1、2 颗糖果。
 * 
 * 
 * 示例 2：
 * 输入：[1,2,2]
 * 输出：4
 * 解释：你可以分别给这三个孩子分发 1、2、1 颗糖果。
 * ⁠    第三个孩子只得到 1 颗糖果，这已满足上述两个条件。
 * 
 */

    // @lc code=start
    public class Solution135 : SolutionBase
    {
        /// <summary>
        /// 难度
        /// </summary>
        public override Difficulity GetDifficulity() { return Difficulity.Hard; }
        /// <summary>
        /// 关键字:
        /// </summary>
        public override string[] GetKeyWords() { return new string[] {  }; }
        /// <summary>
        /// 标签：
        /// </summary>
        public override Tag[] GetTags() { return new Tag[] { Tag.Greedy }; }

        public int NULL = -1;
        public override bool Test(System.Diagnostics.Stopwatch sw)
        {
            bool isSuccess = true;
            int[] s;
            int result, checkResult;

            s = new int[] { 1, 0, 2 };
            checkResult = 5;
            result = Candy(s);
            isSuccess &= IsSame(result, checkResult);
            PrintResult(isSuccess, result, checkResult);

            s = new int[] { 1, 2, 2 };
            checkResult = 4;
            result = Candy(s);
            isSuccess &= IsSame(result, checkResult);
            PrintResult(isSuccess, result, checkResult);


            return isSuccess;
        }

        /// <summary>
        /// 作者：LeetCode - Solution
        /// 链接：https://leetcode-cn.com/problems/candy/solution/fen-fa-tang-guo-by-leetcode-solution-f01p/
        /// 48/48 cases passed (96 ms)
        /// Your runtime beats 100 % of csharp submissions
        /// Your memory usage beats 100 % of csharp submissions(29.3 MB)
        /// </summary>
        /// <param name="ratings"></param>
        /// <returns></returns>
        public int Candy(int[] ratings)
        {
            int n = ratings.Length;

            int ret = 1;

            int inc = 1; //最近的递增序列的长度 inc
            int dec = 0; //当前递减序列的长度 dec
            int pre = 1; //前一个同学分得的糖果数量 pre 
            for (int i = 1; i < n; i++)
            {
                //如果当前同学比上一个同学评分高，说明我们就在最近的递增序列中，
                //直接分配给该同学 pre+1 个糖果即可。
                if (ratings[i] >= ratings[i - 1])
                {
                    dec = 0;
                    pre = ratings[i] == ratings[i - 1] ? 1 : pre + 1;
                    ret += pre;
                    inc = pre;
                }
                //否则我们就在一个递减序列中，我们直接分配给当前同学一个糖果，
                //并把该同学所在的递减序列中所有的同学都再多分配一个糖果，
                //以保证糖果数量还是满足条件。
                else
                {
                    dec++;
                    if (dec == inc)
                    {
                        dec++;
                    }
                    ret += dec;
                    pre = 1;
                }
            }
            return ret;
        }
    }
    // @lc code=end


}
