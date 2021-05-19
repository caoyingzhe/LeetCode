using System;
using System.Collections.Generic;

namespace CSharpConsoleApp.Solutions
{
    /*
     * @lc app=leetcode.cn id=45 lang=csharp
     *
     * [45] 跳跃游戏 II
     *
     * https://leetcode-cn.com/problems/jump-game-ii/description/
     *
     * algorithms
     * Medium (39.78%)
     * Likes:    971
     * Dislikes: 0
     * Total Accepted:    130.5K
     * Total Submissions: 327.5K
     * Testcase Example:  '[2,3,1,1,4]'
     *
     * 给定一个非负整数数组，你最初位于数组的第一个位置。
     * 
     * 数组中的每个元素代表你在该位置可以跳跃的最大长度。
     * 
     * 你的目标是使用最少的跳跃次数到达数组的最后一个位置。
     * 
     * 假设你总是可以到达数组的最后一个位置。
     * 
     * 
     * 
     * 示例 1:
     * 输入: [2,3,1,1,4]
     * 输出: 2
     * 解释: 跳到最后一个位置的最小跳跃数是 2。
     * 从下标为 0 跳到下标为 1 的位置，跳 1 步，然后跳 3 步到达数组的最后一个位置。
     * 
     * 
     * 示例 2:
     * 输入: [2,3,0,1,4]
     * 输出: 2
     * 
     * 提示:
     * 1 <= nums.length <= 1000
     * 0 <= nums[i] <= 10^5
     * 
     * 
     */
    public class Solution45 : SolutionBase
    {
        /// <summary>
        /// 难易度:
        /// </summary>
        public override Difficulity GetDifficulity() { return Difficulity.Hard; }
        /// <summary>
        /// 关键字:
        /// </summary>
        public override string[] GetKeyWords() { return new string[] { "动态编程", "字符串" }; }
        /// <summary>
        /// 标签： 图
        /// </summary>
        public override Tag[] GetTags() { return new Tag[] { Tag.String, Tag.DynamicProgramming }; }

        public override bool Test(System.Diagnostics.Stopwatch sw)
        {
            bool isSuccess = true;
            int[] nums;
            int result, checkResult;

            //nums = new int[] { 2, 3, 1, 1, 4 };
            //checkResult = 2;
            //result = Jump(nums);
            //isSuccess &= result == checkResult;
            //Print("isSuccess = {0} result = {1} | checkResult = {2}", isSuccess, (result), (checkResult));

            //nums = new int[] { 2, 3, 0, 1, 4 };
            //checkResult = 2;
            //result = Jump(nums);
            //isSuccess &= result == checkResult;
            //Print("isSuccess = {0} result = {1} | checkResult = {2}", isSuccess, (result), (checkResult));

            //nums = new int[] { 2, 5, 1, 1, 8, 0, 1, 1, 2, 3, 1, 4 };
            //checkResult = 3;
            //result = Jump(nums);
            //nums             { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33,34,35,36,37,38 };
            //nums = new int[] { 5, 6, 4, 4, 6, 9, 4, 4, 7, 4, 4, 8, 2, 6, 8, 1, 5, 9, 6, 5, 2, 7, 9, 7, 9, 6, 9, 4, 1, 6, 8, 8, 4, 4, 2, 0, 3, 8, 5 };
            //checkResult = 5;
            //result = Jump(nums);

            //isSuccess &= result == checkResult;
            //Print("isSuccess = {0} result = {1} | checkResult = {2}", isSuccess, (result), (checkResult));

            //minJump = int.MaxValue;
            ////nums           { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33,34,35,36,37,38,39,40,41,42,43 };
            //nums = new int[] { 5, 6, 4, 4, 6, 9, 4, 4, 7, 4, 4, 8, 2, 6, 8, 1, 5, 9, 6, 5, 2, 7, 9, 7, 9, 6, 9, 4, 1, 6, 8, 8, 4, 4, 2, 0, 3, 8, 5, 1, 3, 2, 4, 7};
            //checkResult = 6;
            //result = Jump(nums);
            //isSuccess &= result == checkResult;
            //Print("isSuccess = {0} result = {1} | checkResult = {2}", isSuccess, (result), (checkResult));

            //minJump = int.MaxValue;
            ////nums =         { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10,11}
            //nums = new int[] { 5, 9, 3, 2, 1, 0, 2, 3, 3, 1, 0, 0 };  //该例子很特殊 5 =>9[1]=> 0[10] 结束，不能到达终点，实际是可以到达的 5, 9,[1]=>3[8]=> 0
            //checkResult = 3;
            //result = Jump(nums);
            //isSuccess &= result == checkResult;
            //Print("isSuccess = {0} result = {1} | checkResult = {2}", isSuccess, (result), (checkResult));

            ////nums =       { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10,11,12,13,14,15,
            nums = new int[] { 5, 4, 0, 1, 3, 6, 8, 0, 9, 4, 9, 1, 8, 7, 4, 8 };  //该例子很特殊 5 =>9[1]=> 0[10] 结束，不能到达终点，实际是可以到达的 5, 9,[1]=>3[8]=> 0
            checkResult = 3;
            result = Jump(nums);
            isSuccess &= result == checkResult;
            Print("isSuccess = {0} result = {1} | checkResult = {2}", isSuccess, (result), (checkResult));

            return isSuccess;
        }
        #region ====== 未完成代码 =========
        int minJump = int.MaxValue;
        public int Jump_MY(int[] nums)
        {
            if (nums.Length == 1 && nums[0] == 0)
                return 0;

            List<int> list = new List<int>();
            //list.Add(nums[0]);
            DFS(0, 0, list, nums);

            if (minJump == int.MaxValue) minJump = 0;
            return minJump;
        }

        public void DFS_LTE(int pos, int currJump, List<int> list, int[] nums)
        {
            int n = nums.Length;
            if (pos >= n - 1)
            {
                if (currJump < minJump)
                { 
                    minJump = currJump;
                }
                Print("minJump = {0} | currJump ={1} | {2}", minJump, currJump, string.Join(",", list));

                return;
            }

            if (nums[pos] == 0)
            {
                return;
            }

            int maxPos = pos + nums[pos] >= n ? n - 1  : pos + nums[pos];

            for (int i= maxPos; i> pos; i--)
            {
                list.Add(nums[i]);
                DFS(i, currJump+1, list, nums);
                list.RemoveAt(list.Count - 1);
            }
        }

        //With Bug
        public void DFS(int pos, int currJump, List<int> list, int[] nums)
        {
            int n = nums.Length;
            if (pos >= n - 1)
            {
                //Print("nums[{0}] = {1} | currJump = {2}", pos, nums[pos], currJump);
                if (currJump < minJump)
                {
                    minJump = currJump;
                    Print("minJump = {0} | currJump ={1} | {2}", minJump, currJump, string.Join(",", list));
                }
                return;
            }
            //Print("nums[{0}] = {1} | currJump = {2}", pos, nums[pos], currJump);

            int maxPos = pos + nums[pos];
            if (maxPos >= n-1)
            {
                //已经超过最后一位，结束处理
                list.Add(nums[n-1]);
                DFS(n - 1, currJump + 1, list, nums);
                return;
            }
            
            //此处需要剪枝
            //对于   { 5, 6, 4, 4, 6, 9}， 只需要处理9就可以了。
            //变幻后 { 5, 6+1, 4+2, 4+3, 6+4, 9+5}，对于5，数组中数值表示最多可以跳多少步，取最大值即可。

            List<int> jumpSteps = new List<int>();
            List<int> jumpIndices = new List<int>();
            List<int> jumpNums = new List<int>();
            int maxNextPos = pos;
            int maxIndex = pos;
            for (int i = pos+1; i <= maxPos; i++)
            {
                if(maxNextPos <= i+ nums[i])
                {
                    maxNextPos = i + nums[i];
                    maxIndex = i;
                }
                jumpSteps.Add((i - pos) + nums[i]);
                jumpIndices.Add(i);
                jumpNums.Add(nums[i]);
            }
            if (maxNextPos != pos)
                list.Add(nums[maxIndex]);

            Print(string.Join(",", jumpSteps));
            Print(string.Join(",", jumpIndices));
            Print(string.Join(",", jumpNums));
            //Print(string.Join(",", list));

            Print("Add maxIndex = {0}, maxNextPos = {1}", maxIndex, maxNextPos);
            //不能再前进了，直接返回。
            if (maxNextPos == pos)
                return;

            //不能再前进了，而且没有到达终点。需要回溯
            if (maxNextPos < n - 1) //&& nums[maxNextPos] == 0)
            {
                int startPos = maxNextPos - 1;
                int maxAdd = 0;
                for (int i = startPos; i > pos; i--)
                {
                    if (i - startPos + nums[i] >= maxAdd)
                    {
                        maxAdd = i - startPos + nums[i];
                        maxIndex = i;
                    }
                    //jumpSteps.Add((i - pos) + nums[i]);
                    //jumpIndices.Add(i);
                    //jumpNums.Add(nums[i]);
                }
                if (maxAdd > 0)
                    maxNextPos = maxIndex;
            }

            if (maxNextPos > n - 1)
                maxNextPos = n - 1;
            
            Print("Add maxIndex = {0}, maxNextPos = {1}", maxIndex, maxNextPos);

            list.Add(nums[maxNextPos]);
            DFS(maxNextPos, currJump + 2, list, nums);
        }
        #endregion

        /// <summary>
        /// 92/92 cases passed (108 ms)
        /// Your runtime beats 70.21 % of csharp submissions
        /// Your memory usage beats 47.52 % of csharp submissions(24.2 MB)
        ///  作者：LeetCode-Solution
        ///  链接：https://leetcode-cn.com/problems/jump-game-ii/solution/tiao-yue-you-xi-ii-by-leetcode-solution/
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int Jump(int[] nums)
        {
            int length = nums.Length;
            int end = 0;
            int maxPosition = 0;
            int steps = 0;
            for (int i = 0; i < length - 1; i++)
            {
                if(maxPosition < i+nums[i])
                    maxPosition = i + nums[i];  //Print("    i={0} max={1}", i, maxPosition);
                
                if (i == end)
                {
                    end = maxPosition;
                    steps++;            //Print("i={0} max={1} steps={2}", i, maxPosition, steps);
                }
            }
            return steps;
        }

       
    }
}
