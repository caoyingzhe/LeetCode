using System;
using System.Collections.Generic;
namespace CSharpConsoleApp.Solutions
{
    /*
     * @lc app=leetcode.cn id=506 lang=csharp
     *
     * [506] 相对名次
     *
     * https://leetcode-cn.com/problems/relative-ranks/description/
     *
     * algorithms
     * Easy (56.02%)
     * Likes:    74
     * Dislikes: 0
     * Total Accepted:    17.1K
     * Total Submissions: 30.5K
     * Testcase Example:  '[5,4,3,2,1]'
     *
     * 给出 N 名运动员的成绩，找出他们的相对名次并授予前三名对应的奖牌。前三名运动员将会被分别授予 “金牌”，“银牌” 和“ 铜牌”（"Gold
     * Medal", "Silver Medal", "Bronze Medal"）。
     * 
     * (注：分数越高的选手，排名越靠前。)
     * 
     * 示例 1:
     * 输入: [5, 4, 3, 2, 1]
     * 输出: ["Gold Medal", "Silver Medal", "Bronze Medal", "4", "5"]
     * 解释: 前三名运动员的成绩为前三高的，因此将会分别被授予 “金牌”，“银牌”和“铜牌” ("Gold Medal", "Silver Medal"
     * and "Bronze Medal").
     * 余下的两名运动员，我们只需要通过他们的成绩计算将其相对名次即可。
     * 
     * 提示:
     * N 是一个正整数并且不会超过 10000。
     * 所有运动员的成绩都不相同。（该处理太简单）
     *
     */
    public class Solution506 : SolutionBase
    {
        /// <summary>
        /// 难度
        /// </summary>
        public override Difficulity GetDifficulity() { return Difficulity.Medium; }
        /// <summary>
        /// 关键字:
        /// </summary>
        public override string[] GetKeyWords() { return new string[] { "等差数列" }; }
        /// <summary>
        /// 标签：
        /// </summary>
        public override Tag[] GetTags() { return new Tag[] { Tag.Math, Tag.DynamicProgramming, }; }

        public override bool Test(System.Diagnostics.Stopwatch sw)
        {
            int[] score; string[] result;
            score = new int[] { 5, 4, 3, 2, 1 };
            result = FindRelativeRanks(score);
            Print(GetArrayStr(result));
            score = new int[] { 5, 4, 3, 3, 3, 3, 2, 1 };
            result = FindRelativeRanks(score);
            Print(GetArrayStr(result));

            score = new int[] { 5, 5, 5, 5, 3, 3, 2, 1 };
            result = FindRelativeRanks(score);
            Print(GetArrayStr(result));

            score = new int[] { 5, 4, 4, 3, 3, 3, 2, 1 };
            result = FindRelativeRanks(score);
            Print(GetArrayStr(result));

            score = new int[] { 5, 4, 4, 4, 3, 3, 2, 1 };
            result = FindRelativeRanks(score);
            Print(GetArrayStr(result));

            score = new int[] { 5, 5, 5, 3, 3, 3, 2, 2, 1 };
            result = FindRelativeRanks(score);
            Print(GetArrayStr(result));

            return true;
        }
        public String[] FindRelativeRanks(int[] score)
        {
            //return FindRelativeRanks_Java(score);
            return FindRelativeRanks_MY(score);
        }

        /// 17/17 cases passed(304 ms)
        /// Your runtime beats 72.22 % of csharp submissions
        /// Your memory usage beats 16.67 % of csharp submissions(35.5 MB)
        //作者：Qiumg
        //链接：https://leetcode-cn.com/problems/relative-ranks/solution/qiumg-java-jie-zhu-hashmap-by-qiumg-4npy/
        public String[] FindRelativeRanks_Java(int[] score)
        {
            Dictionary<int, String> map = new Dictionary<int, String>();
            int[] c = new List<int>(score).ToArray();
            String[] a = new String[score.Length];
            Array.Sort(c);
            for (int i = a.Length - 1; i >= 0; i--)
            {
                if (i == a.Length - 1)
                {
                    a[i] = "Gold Medal";
                    if(!map.ContainsKey(c[i]))
                        map.Add(c[i], a[i]);
                    else
                        map[c[i]] = a[i];
                }
                else if (i == a.Length - 2)
                {
                    a[i] = "Silver Medal";
                    if (!map.ContainsKey(c[i]))
                        map.Add(c[i], a[i]);
                    else
                        map[c[i]] = a[i];
                }
                else if (i == a.Length - 3)
                {
                    a[i] = "Bronze Medal";
                    if (!map.ContainsKey(c[i]))
                        map.Add(c[i], a[i]);
                    else
                        map[c[i]] = a[i];
                }
                else
                {
                    a[i] = a.Length - i + "";
                    if (!map.ContainsKey(c[i]))
                        map.Add(c[i], a[i]);
                    else
                        map[c[i]] = a[i];
                }
            }
            for (int i = 0; i < score.Length; i++)
                a[i] = map[score[i]];
            return a;
        }


        /// <summary>
        /// 该方法有Bug，只适合降序的数组。不能对应任意数组；
        /// 
        /// 题目中说明不会出现相同成绩。
        /// 本方法依然能对应相同成绩。但是对应不只一个奖牌（允许多个金牌多个银牌无铜牌）
        /// 奖牌可以是三个以上（比如 金牌>3，1金+银>2,1金+1银+铜>2） 
        /// </summary>
        /// <param name="score"></param>
        /// <returns></returns>
        public string[] FindRelativeRanks_MY(int[] score)
        {
            Array.Sort(score);
            Array.Reverse(score);

            string[] rtn = new string[score.Length];

            int  rank = 1;
            int  rankVal = score[0];
            rtn[0] = "Gold Medal";
            int rank1Count = 1;
            int rank2Count = 0;
            int preCount = 1;
            for (int i=1; i< score.Length; i++)
            {
                if (score[i] < rankVal)
                {
                    rank++;
                    rankVal = score[i];
                    preCount = i;
                }
                switch (rank)
                {
                    case 1:
                        rank1Count++;
                        rtn[i] = "Gold Medal";
                        break;
                    case 2:
                        rank2Count++;
                        if (rank1Count <= 2)
                            rtn[i] = "Silver Medal";
                        else
                            rtn[i] = "" + (preCount + 1);
                        break;
                    case 3:
                        if (rank1Count + rank2Count <= 2)
                            rtn[i] = "Bronze Medal";
                        else
                            rtn[i] = "" + (preCount + 1);
                        break;
                    default:
                        rtn[i] = "" + (preCount+1);
                        break;
                }
            }
            return rtn;
        }
    }
}
