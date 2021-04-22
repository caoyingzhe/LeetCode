using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpConsoleApp.Solutions
{
    /// <summary>
    /// 合并区间
    /// </summary>
    class Solution56 : SolutionBase
    {
        /// <summary>
        /// 难易度:
        /// </summary>
        public override Difficulity GetDifficulity() { return Difficulity.Medium; }
        /// <summary>
        /// 关键字:
        /// </summary>
        public override string[] GetKeyWords() { return new string[] { "数组排序和合并" }; }
        /// <summary>
        /// 标签： 图
        /// </summary>
        public override Tag[] GetTags() { return new Tag[] { Tag.Array }; }

        public override bool Test(System.Diagnostics.Stopwatch sw)
        {
            bool isSuccess = true;

            int[][] intervals = new int[][] {
                new int[] { 1,3 },
                new int[] { 2,6 },
                new int[] { 8,10 },
                new int[] { 15,18 }
            };
            int[][] checkresult = new int[][] {
                new int[] { 1,6 },
                new int[] { 8,10 },
                new int[] { 15,18 }
            };
            int[][] result = Merge(intervals);
            isSuccess &= IsArraySame(result, checkresult);
            Print("isSuccess = " + isSuccess + " | Anticipated = " + GetArrayStr(checkresult, ",", ",") + " | Result = " + GetArrayStr(result, ",", ","));
            return isSuccess;
        }

        public int[][] Merge(int[][] intervals)
        {
            if (intervals.Length == 0)
                return new int[0][];

            List<int[]> intervalsSorted = new List<int[]>();
            for(int i=0; i<intervals.Length; i++)
            {
                intervalsSorted.Add(intervals[i]);
            }
            intervalsSorted.Sort((a, b) => { return a[0] - b[0]; });

            List<int[]> mergedList = new List<int[]>();
            for (int i = 0; i < intervalsSorted.Count; i++)
            {
                int L = intervalsSorted[i][0];
                int R = intervalsSorted[i][1];

                if (mergedList.Count == 0 || mergedList[mergedList.Count - 1][1] < L) //合并列表为空，或者合并列表最后一个的右侧小于当前左侧时，添加新的范围
                {
                    mergedList.Add(new int[] { L, R });
                }
                else
                {
                    //更新原有范围的右侧值
                    mergedList[mergedList.Count - 1][1] = Math.Max(mergedList[mergedList.Count - 1][1], R);
                }
            }
            
            return mergedList.ToArray();
        }
    }
}
