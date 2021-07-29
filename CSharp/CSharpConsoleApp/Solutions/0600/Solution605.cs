using System;
using System.Collections.Generic;
namespace CSharpConsoleApp.Solutions
{
    /*
     * @lc app=leetcode.cn id=605 lang=csharp
     *
     * [605] 种花问题
     *
     * https://leetcode-cn.com/problems/can-place-flowers/description/
     *
     * Category	Difficulty	Likes	Dislikes
     * algorithms	Easy (33.58%)	367	-
     * Tags
     * array
     * 
     * Companies
     * linkedin
     * 
     * Total Accepted:    101.6K
     * Total Submissions: 302.7K
     * Testcase Example:  '[1,0,0,0,1]\n1'
     *
     * 假设有一个很长的花坛，一部分地块种植了花，另一部分却没有。可是，花不能种植在相邻的地块上，它们会争夺水源，两者都会死去。
     * 
     * 给你一个整数数组  flowerbed 表示花坛，由若干 0 和 1 组成，其中 0 表示没种植花，1 表示种植了花。另有一个数 n
     * ，能否在不打破种植规则的情况下种入 n 朵花？能则返回 true ，不能则返回 false。
     * 
     * 
     * 
     * 示例 1：
     * 输入：flowerbed = [1,0,0,0,1], n = 1
     * 输出：true
     * 
     * 
     * 示例 2：
     * 输入：flowerbed = [1,0,0,0,1], n = 2
     * 输出：false
     * 
     * 
     * 提示：
     * 1 <= flowerbed.length <= 2 * 10^4 
     * flowerbed[i] 为 0 或 1
     * flowerbed 中不存在相邻的两朵花
     * 0 <= n <= flowerbed.length
     */

    // @lc code=start
    public class Solution605 : SolutionBase
    {
        /// <summary>
        /// 难度
        /// </summary>
        public override Difficulity GetDifficulity() { return Difficulity.Medium; }
        /// <summary>
        /// 关键字:
        /// </summary>
        public override string[] GetKeyWords() { return new string[] { "简单Lv=1" }; }
        /// <summary>
        /// 标签：
        /// </summary>
        public override Tag[] GetTags() { return new Tag[] { Tag.Tree, Tag.DepthFirstSearch, Tag.BreadthFirstSearch }; }

        
        /// <summary>
        /// </summary>
        /// <param name="sw"></param>
        /// <returns></returns>
        public override bool Test(System.Diagnostics.Stopwatch sw)
        {
            bool isSuccess = true;
            int[] flowerbed; int n;
            bool result, checkResult;

            flowerbed = new int[] { 1, 3, 2, 5, 3, NULL, 9 }; n = 10;
            checkResult = true;
            result = CanPlaceFlowers(flowerbed, n);
            isSuccess &= IsSame(result, checkResult);
            PrintResult(isSuccess, result, checkResult);

            flowerbed = new int[] { 1, 3, 2, 5, 3, NULL, 9 }; n = 10;
            checkResult = true;
            result = CanPlaceFlowers(flowerbed, n);
            isSuccess &= IsSame(result, checkResult);
            PrintResult(isSuccess, result, checkResult);

            return isSuccess;
        }

        /// <summary>
        /// 124/124 cases passed (76 ms)
        /// Your runtime beats 100 % of csharp submissions
        /// Your memory usage beats 77.78 % of csharp submissions(29.6 MB)
        /// </summary>
        /// <param name="flowerbed"></param>
        /// <param name="n"></param>
        /// <returns></returns>
        public bool CanPlaceFlowers(int[] flowerbed, int n)
        {
            int count = flowerbed.Length;
            for (int i = 0; i < count && n > 0;)
            {
                
                if (flowerbed[i] == 1)
                {
                    i += 2; //当前位置有花
                }
                else if (i == count - 1 || flowerbed[i + 1] == 0)
                {
                    n--;    //当前位置无花，并且为最后一个位置，或者下一个位置无花
                    i += 2; 
                }
                else
                {
                    i += 3; //当前位置无花，并且下一个位置有花
                }
            }
            return n <= 0;
        }
    }
    // @lc code=end


}
