using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpConsoleApp.Solutions
{
    /// <summary>
    /// 128. 最长连续序列
    /// 128. longest-consecutive-sequence
    /// </summary>
    class Solution128 : SolutionBase
    {
        public override bool Test(System.Diagnostics.Stopwatch sw)
        {
            bool isSuccess = false;
            int[] nums;
            int checkResult;

            nums = new int[] {100,4,200,1,3,2};
            checkResult = 4;
            isSuccess = LongestConsecutive(nums, checkResult);

            nums = new int[] { 0, 3, 7, 2, 5, 8, 4, 6, 0, 1 };
            checkResult = 9;
            isSuccess = LongestConsecutive(nums, checkResult);
            return isSuccess;
        }

        public bool LongestConsecutive(int[] nums, int checkResult)
        {
            int result = LongestConsecutive_20210403(nums);
            System.Diagnostics.Debug.Print(string.Format("isSuccess = {3} nums1.len = {0} | result = {1} | checkResult = {2}", nums.Length, result, checkResult, result == checkResult));

            return result == checkResult;
        }
        /// <summary>
        /// 202100403
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int LongestConsecutive_20210403(int[] nums)
        {
            if (nums == null || nums.Length == 0)
                return 0;

            Dictionary<int, int> dict = new Dictionary<int, int>();
            List<int> numList = new List<int>(nums);
            //numList.Sort((a, b) => { return a - b; });
            numList.Sort();

            int lastNum = numList[0];
            int currLen = 1;
            dict.Add(lastNum, currLen);
            int maxLen = 1;
            
            for (int i = 1; i < numList.Count; i++)
            {
                int currentNum = numList[i];
                if (!dict.ContainsKey(currentNum)) //过滤掉重复的数
                {
                    if (currentNum == lastNum + 1) //包含连续数组，继续判断
                    { 
                        dict.Add(currentNum, currLen);
                        currLen++;
                        if(currLen > maxLen)
                            maxLen = currLen;

                        lastNum = currentNum;
                    }
                    else
                    {
                        //不再连续，重新计算currLen
                        lastNum = currentNum;
                        currLen = 1;
                        dict.Add(currentNum, 1);
                    }
                }
            }
            return maxLen;
        }
    }
}
