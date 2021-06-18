using System;
using System.Text;
namespace CSharpConsoleApp.Solutions
{
    /*
     * @lc app=leetcode.cn id=482 lang=csharp
     *
     * [482] 密钥格式化
     *
     * https://leetcode-cn.com/problems/license-key-formatting/description/
     *
     * Category	Difficulty	Likes	Dislikes
     * algorithms	Easy (42.08%)	66	-
     * Tags
     * Unknown
     * 
     * Companies
     * google
     * 
     * Total Accepted:    16.7K
     * Total Submissions: 39.6K
     * Testcase Example:  '"5F3Z-2e-9-w"\n4'
     *
     * 有一个密钥字符串 S ，只包含字母，数字以及 '-'（破折号）。其中， N 个 '-' 将字符串分成了 N+1 组。
     * 
     * 给你一个数字 K，请你重新格式化字符串，使每个分组恰好包含 K 个字符。特别地，第一个分组包含的字符个数必须小于等于 K，但至少要包含 1
     * 个字符。两个分组之间需要用 '-'（破折号）隔开，并且将所有的小写字母转换为大写字母。
     * 
     * 给定非空字符串 S 和数字 K，按照上面描述的规则进行格式化。
     * 
     * 
     * 
     * 示例 1：
     * 
     * 输入：S = "5F3Z-2e-9-w", K = 4
     * 输出："5F3Z-2E9W"
     * 解释：字符串 S 被分成了两个部分，每部分 4 个字符；
     * 注意，两个额外的破折号需要删掉。
     * 
     * 
     * 示例 2：
     * 
     * 输入：S = "2-5g-3-J", K = 2
     * 输出："2-5G-3J"
     * 解释：字符串 S 被分成了 3 个部分，按照前面的规则描述，第一部分的字符可以少于给定的数量，其余部分皆为 2 个字符。
     * 
     * 
     * 
     * 
     * 提示:
     * 
     * 
     * S 的长度可能很长，请按需分配大小。K 为正整数。
     * S 只包含字母数字（a-z，A-Z，0-9）以及破折号'-'
     * S 非空
     * 
     * 
     * 
     * 
     */

    // @lc code=start
    public class Solution482 : SolutionBase
    {
        /// <summary>
        /// 难度
        /// </summary>
        public override Difficulity GetDifficulity() { return Difficulity.Easy; }
        /// <summary>
        /// 关键字:
        /// </summary>
        public override string[] GetKeyWords() { return new string[] { "" }; }
        /// <summary>
        /// 标签：
        /// </summary>
        public override Tag[] GetTags() { return new Tag[] { Tag.String, }; }

        public override bool Test(System.Diagnostics.Stopwatch sw)
        {
            bool isSuccess = true;
            string s; int k;
            string result, checkResult;

            //houses = new int[] { 1, 3, -1, -3, 5, 3, 6, 7 }; k = 3;
            //checkResult = new double[] { 1, -1, -1, 3, 5, 6 };
            //result = MedianSlidingWindow(houses, k);

            //isSuccess &= IsArraySame(result, checkResult);
            //Print("isSuccess = {0} | result = {1} | anticipated = {2}", isSuccess, GetArrayStr(result), GetArrayStr(checkResult));

            s = "---"; k = 3;
            checkResult = "";
            result = LicenseKeyFormatting(s, k);

            isSuccess &= IsSame(result, checkResult);
            PrintResult(isSuccess, (result), (checkResult));

            return isSuccess;
        }
        //38/38 cases passed (1032 ms)
        //Your runtime beats 39.13 % of csharp submissions
        //Your memory usage beats 26.09 % of csharp submissions(41.1 MB)
        public string LicenseKeyFormatting1(string S, int K)
        {
            S = S.ToUpper().Replace("-", "");
            int n = S.Length;
            for (int i = 1; i * K < n; i++)
            {
                S = S.Insert(n - i * K, "-");
            }
            return S;
        }

        /// <summary>
        /// 35/38 cases passed (N/A)
        /// "---"
        /// 38/38 cases passed (1352 ms)
        /// Your runtime beats 8.7 % of csharp submissions
        /// Your memory usage beats 78.26 % of csharp submissions(27.2 MB)
        /// </summary>
        /// <param name="S"></param>
        /// <param name="K"></param>
        /// <returns></returns>
        public string LicenseKeyFormatting(string S, int K)
        {
            S = S.ToUpper();
            StringBuilder sb = new StringBuilder();
            int n = S.Length;

            for(int i=n-1,j=0; i>=0; --i)
            {
                if(S[i] != '-')
                {
                    sb.Insert(0,S[i]);
                    j++;

                    if(j== K && sb.Length > 0)
                    {
                        sb.Insert(0,'-');
                        j = 0;
                    }
                }
            }
            if (sb.Length > 0 && sb[0] == '-')
                sb.Remove(0, 1);
            return sb.ToString();
        }
    }
    // @lc code=end


}
