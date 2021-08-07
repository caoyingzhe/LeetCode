using System;
using System.Collections.Generic;
namespace CSharpConsoleApp.Solutions
{
    /*
 * @lc app=leetcode.cn id=475 lang=csharp
 *
 * [475] 供暖器
 *
 * https://leetcode-cn.com/problems/heaters/description/
 *
 * Category	Difficulty	Likes	Dislikes
 * algorithms	Medium (32.51%)	201	-
 * Tags
 * binary-search
 * 
 * Companies
 * google
 * 
 * Total Accepted:    17.9K
 * Total Submissions: 54.9K
 * Testcase Example:  '[1,2,3]\n[2]'
 *
 * 冬季已经来临。 你的任务是设计一个有固定加热半径的供暖器向所有房屋供暖。
 * 
 * 在加热器的加热半径范围内的每个房屋都可以获得供暖。
 * 
 * 现在，给出位于一条水平线上的房屋 houses 和供暖器 heaters 的位置，请你找出并返回可以覆盖所有房屋的最小加热半径。
 * 
 * 说明：所有供暖器都遵循你的半径标准，加热的半径也一样。
 * 
 * 
 * 
 * 示例 1:
 * 输入: houses = [1,2,3], heaters = [2]
 * 输出: 1
 * 解释: 仅在位置2上有一个供暖器。如果我们将加热半径设为1，那么所有房屋就都能得到供暖。
 * 
 * 
 * 示例 2:
 * 输入: houses = [1,2,3,4], heaters = [1,4]
 * 输出: 1
 * 解释: 在位置1, 4上有两个供暖器。我们需要将加热半径设为1，这样所有房屋就都能得到供暖。
 * 
 * 
 * 示例 3：
 * 输入：houses = [1,5], heaters = [2]
 * 输出：3
 * 
 * 提示：
 *1 <= houses.length, heaters.length <= 3 * 104
 *1 <= houses[i], heaters[i] <= 109
 */

    public class Solution475 : SolutionBase
    {
        /// <summary>
        /// 难度
        /// </summary>
        public override Difficulity GetDifficulity() { return Difficulity.Medium; }
        /// <summary>
        /// 关键字:
        /// </summary>
        public override string[] GetKeyWords() { return new string[] { "" }; }
        /// <summary>
        /// 标签：
        /// </summary>
        public override Tag[] GetTags() { return new Tag[] { Tag.DynamicProgramming, }; }

        public override bool Test(System.Diagnostics.Stopwatch sw)
        {
            bool isSuccess = true;
            int[] houses, heaters;
            int result, checkResult;

            houses = new int[] { 1, 2, 3 };
            heaters = new int[] { 2 };
            checkResult = 1;
            result = FindRadius(houses, heaters);
            isSuccess &= result == checkResult;
            Print("isSuccess = {0} | result = {1} | anticipated = {2}", isSuccess, (result), (checkResult));


            houses = new int[] { 1, 2, 3, 4 };
            heaters = new int[] { 1, 4 };
            checkResult = 1;
            result = FindRadius(houses, heaters);
            isSuccess &= result == checkResult;
            Print("isSuccess = {0} | result = {1} | anticipated = {2}", isSuccess, (result), (checkResult));

            houses = new int[] { 1, 5 };
            heaters = new int[] { 2 };
            checkResult = 3;
            result = FindRadius(houses, heaters);
            isSuccess &= result == checkResult;
            Print("isSuccess = {0} | result = {1} | anticipated = {2}", isSuccess, (result), (checkResult));

            houses = new int[] { 1, 5 };
            heaters = new int[] { 10 };
            checkResult = 9;
            result = FindRadius(houses, heaters);
            isSuccess &= result == checkResult;
            Print("isSuccess = {0} | result = {1} | anticipated = {2}", isSuccess, (result), (checkResult));

            return isSuccess;
        }

        /// <summary>
        /// 30/30 cases passed (196 ms)
        /// Your runtime beats 60 % of csharp submissions
        /// Your memory usage beats 80 % of csharp submissions(34.8 MB)
        /// </summary>
        /// <param name="houses"></param>
        /// <param name="heaters"></param>
        /// <returns></returns>
        //作者：wyyang-acvv
        //链接：https://leetcode-cn.com/problems/heaters/solution/java-tan-xin-er-fen-ping-heng-shu-san-ch-hk8t/
        public int FindRadius(int[] houses, int[] heaters)
        {
            Array.Sort(houses);
            Array.Sort(heaters);
            int res = 0;
            foreach (int house in houses)
            {
                // 二分查找
                int l = 0;
                int r = heaters.Length - 1;
                // 在heaters中找到最接近house的左侧的值
                while (l < r)
                {
                    int mid = l + r >> 1;
                    if (heaters[mid] >= house) r = mid;
                    else l = mid + 1;
                }
                int leftTmp = l;
                l = 0;
                r = heaters.Length - 1;
                // 在heaters中找到最接近house的左侧的值
                while (l < r)
                {
                    int mid = l + r + 1 >> 1;
                    if (heaters[mid] <= house) l = mid;
                    else r = mid - 1;
                }

                int rightTmp = r;
                // 左右侧值取最小的，结果取所有最小中的最大的
                res = Math.Max(res, Math.Min(Math.Abs(heaters[leftTmp] - house), Math.Abs(heaters[rightTmp] - house)));
            }
            return res;
        }

        public int FindRadius_MY(int[] houses, int[] heaters)
        {
            List<int[]> list = new List<int[]>();
            int n = houses.Length;
            for (int i = 0; i < n; i++)
            {
                list.Add(new int[] { houses[i], i });
            }
            for (int i = 0; i < heaters.Length; i++)
            {
                list.Add(new int[] { heaters[i], n + i });
            }
            list.Sort((a, b) => { return a[0] - b[0]; }); //排位升序

            int maxRadius2X = int.MinValue;

            bool isHeaterPre = list[0][1] >= n;
            int preIdx = isHeaterPre ? 0 : -1;
            for (int i = 1; i < list.Count; i++)
            {
                bool isHeater = list[0][1] >= n;

                if (isHeaterPre)
                    maxRadius2X = Math.Max(maxRadius2X, list[i][0] - list[preIdx][0]);
                else
                    maxRadius2X = Math.Max(maxRadius2X, (list[i][0] - list[preIdx][0]) * 2);

                if (isHeaterPre == isHeater)
                {
                    preIdx = i;
                }
                //else
                //{

                //}
            }

            return maxRadius2X / 2;
        }
    }
}
