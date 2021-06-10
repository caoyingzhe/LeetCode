using System;
namespace CSharpConsoleApp.Solutions
{
    public class Solution169 : SolutionBase
    {
        /// <summary>
        /// 难度
        /// </summary>
        public override Difficulity GetDifficulity() { return Difficulity.Easy; }
        /// <summary>
        /// 关键字:
        /// </summary>
        public override string[] GetKeyWords() { return new string[] { }; }
        /// <summary>
        /// 标签：
        /// </summary>
        public override Tag[] GetTags() { return new Tag[] { Tag.Array}; }

        public override bool Test(System.Diagnostics.Stopwatch sw)
        {
            bool isSuccess = true;
            int[] points; int result, checkResult;

            points = new int[] { 2, 2, 1, 1, 1, 2, 2 };
            checkResult = 2;
            result = MajorityElement(points);
            isSuccess &= result == checkResult;
            Print("isSuccess = {0} | result = {1} | anticipated = {2}", isSuccess, (result), (checkResult));

            points = new int[] { 2, 2, 1, 1, 1, 1, 3,3, 1, 2, 2 };
            checkResult = 1;
            result = MajorityElement(points);
            isSuccess &= result == checkResult;
            Print("isSuccess = {0} | result = {1} | anticipated = {2}", isSuccess, (result), (checkResult));

            return isSuccess;
        }

        /// <summary>
        /// 47/47 cases passed (144 ms)
        /// Your runtime beats 49.87 % of csharp submissions
        /// Your memory usage beats 24.93 % of csharp submissions(29.7 MB)
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int MajorityElement(int[] nums)
        {
            if (nums == null || nums.Length == 0)
                return 0;
            
            Array.Sort(nums);

            int val = nums[0];
            int curr = 1;
            int max = 1;
            int maxVal = val;
            for (int i=1;i<nums.Length; i++)
            {
                if(val == nums[i])
                {
                    curr++;
                    if (i == nums.Length - 1)
                    {
                        if(max < curr)
                        {
                            max = curr;
                            maxVal = val;
                        }
                    }
                }
                else
                {
                    if (max < curr)
                    {
                        max = curr;
                        maxVal = val;
                    }
                    val = nums[i];
                    curr = 1;
                }
            }
            return maxVal;
        }
    }
}
