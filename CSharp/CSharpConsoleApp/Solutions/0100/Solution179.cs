using System;
namespace CSharpConsoleApp.Solutions
{
    /*
 * @lc app=leetcode.cn id=179 lang=csharp
 *
 * [179] 最大数
 *
 * https://leetcode-cn.com/problems/largest-number/description/
 *
 * Category	Difficulty	Likes	Dislikes
 * algorithms	Medium (40.89%)	737	-
 * Tags
 * sort
 * 
 * Companies
 * Unknown
 * 
 * Total Accepted:    108.3K
 * Total Submissions: 264.9K
 * Testcase Example:  '[10,2]'
 *
 * 给定一组非负整数 nums，重新排列每个数的顺序（每个数不可拆分）使之组成一个最大的整数。
 * 注意：输出结果可能非常大，所以你需要返回一个字符串而不是整数。
 * 
 * 
 * 示例 1：
 * 输入：nums = [10,2]
 * 输出："210"
 * 
 * 示例 2：
 * 输入：nums = [3,30,34,5,9]
 * 输出："9534330"
 * 
 * 
 * 示例 3：
 * 输入：nums = [1]
 * 输出："1"
 * 
 * 
 * 示例 4：
 * 输入：nums = [10]
 * 输出："10"
 * 
 * 
 * 提示：
 * 1 <= nums.length <= 10^0
 * 0 <= nums[i] <= 10^9
 */

    // @lc code=start
    public class Solution179 : SolutionBase
    {
        /// <summary>
        /// 难度
        /// </summary>
        public override Difficulity GetDifficulity() { return Difficulity.Medium; }
        /// <summary>
        /// 关键字:
        /// </summary>
        public override string[] GetKeyWords() { return new string[] { "", }; }
        /// <summary>
        /// 标签：
        /// </summary>
        public override Tag[] GetTags() { return new Tag[] { Tag.Sort }; }

        public int NULL = -1;
        public override bool Test(System.Diagnostics.Stopwatch sw)
        {
            bool isSuccess = true;
            int[] s;
            string result, checkResult;

            s = new int[] { 2, 10 };
            checkResult = "210";
            result = LargestNumber(s);
            isSuccess &= IsSame(result, checkResult);
            PrintResult(isSuccess, result, checkResult);

            s = new int[] { 3, 30, 34, 5, 9 };
            checkResult = "9534330";
            result = LargestNumber(s);
            isSuccess &= IsSame(result, checkResult);
            PrintResult(isSuccess, result, checkResult);

            s = new int[] {  10 };
            checkResult = "10";
            result = LargestNumber(s);
            isSuccess &= IsSame(result, checkResult);
            PrintResult(isSuccess, result, checkResult);

            return isSuccess;
        }

        //作者：bu-yao-xiong-xiong-da
        //链接：https://leetcode-cn.com/problems/largest-number/solution/zi-ding-yi-pai-xu-an-abhe-bade-zi-dian-x-5mp8/
        /// <summary>
        /// 229/229 cases passed (136 ms)
        /// Your runtime beats 77.11 % of csharp submissions
        /// Your memory usage beats 76.86 % of csharp submissions(26.7 MB)
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public string LargestNumber(int[] nums)
        {
            string temp = string.Join(",", nums);
            string[] arr = temp.Split(',');
            //自定义排序，比较a+b和b+a，降序排
            Array.Sort(arr, (a, b) => { return (b + a).CompareTo(a + b); });
            bool isAllZero = true;
            foreach (var s in arr)
            {
                if (s != "0")
                {
                    isAllZero = false;
                    break;
                }
            }
            //全为0时的特殊处理
            if (isAllZero) return "0";
            return string.Join("", arr);
        }

        
    }
    // @lc code=end


}
