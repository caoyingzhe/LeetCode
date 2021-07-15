using System;
namespace CSharpConsoleApp.Solutions
{
    /*
     * @lc app=leetcode.cn id=278 lang=csharp
     *
     * [278] 第一个错误的版本
     *
     * https://leetcode-cn.com/problems/first-bad-version/description/
     *
     * Category	Difficulty	Likes	Dislikes
     * algorithms	Easy (45.16%)	336	-
     * Tags
     * binary-search
     * 
     * Companies
     * facebook
     * 
     * Total Accepted:    119.9K
     * Total Submissions: 265.6K
     * Testcase Example:  '5\n4'
     *
     * 你是产品经理，目前正在带领一个团队开发新的产品。不幸的是，你的产品的最新版本没有通过质量检测。由于每个版本都是基于之前的版本开发的，所以错误的版本之后的所有版本都是错的。
     * 
     * 假设你有 n 个版本 [1, 2, ..., n]，你想找出导致之后所有版本出错的第一个错误的版本。
     * 
     * 你可以通过调用 bool isBadVersion(version) 接口来判断版本号 version
     * 是否在单元测试中出错。实现一个函数来查找第一个错误的版本。你应该尽量减少对调用 API 的次数。
     * 
     * 
     * 示例 1：
     * 输入：n = 5, bad = 4
     * 输出：4
     * 解释：
     * 调用 isBadVersion(3) -> false 
     * 调用 isBadVersion(5) -> true 
     * 调用 isBadVersion(4) -> true
     * 所以，4 是第一个错误的版本。
     * 
     * 
     * 示例 2：
     * 输入：n = 1, bad = 1
     * 输出：1
     * 
     * 
     * 提示：
     * 1 <= bad <= n <= 2^31 - 1
     */

    // @lc code=start
    /* The isBadVersion API is defined in the parent class VersionControl.
          bool IsBadVersion(int version); */

    public class Solution278 : SolutionBase 
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
        public override Tag[] GetTags() { return new Tag[] { Tag.BinarySearch, }; }

        public override bool Test(System.Diagnostics.Stopwatch sw)
        {
            bool isSuccess = true;
            bool result, checkResult;
            int version, badVersion;

            version = 5; badVersion = 4;
            this.SetBadVersion(badVersion);
            checkResult = true;
            result = IsBadVersion(version);
            isSuccess &= IsSame(result, checkResult);
            PrintResult(isSuccess, (result), (checkResult));

            return isSuccess;
        }

        //用于测试的代码：设定坏版本
        private int badVersion = 0;
        public void SetBadVersion(int badVersion)
        {
            this.badVersion = badVersion;
        }

        ///The isBadVersion API is defined in the parent class VersionControl.
        public bool IsBadVersion(int version)
        {
            return version >= badVersion;
        }

        /// <summary>
        /// 22/22 cases passed (48 ms)
        /// Your runtime beats 41.48 % of csharp submissions
        /// Your memory usage beats 73.7 % of csharp submissions(14.8 MB)
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public int FirstBadVersion(int n)
        {
            int L = 1, R = n;
            while (L < R)
            {
                // 循环直至区间左右端点相同
                int mid = L + (R - L) / 2; // 防止计算时溢出
                if (IsBadVersion(mid))
                {
                    R = mid; // 答案在区间 [left, mid] 中
                }
                else
                {
                    L = mid + 1; // 答案在区间 [mid+1, right] 中
                }
            }
            // 此时有 left == right，区间缩为一个点，即为答案
            return L;
        }
    }

    // @lc code=end


}
