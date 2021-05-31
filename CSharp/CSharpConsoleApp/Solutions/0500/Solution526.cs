using System;
namespace CSharpConsoleApp.Solutions
{
    /*
     * @lc app=leetcode.cn id=526 lang=csharp
     *
     * [526] 优美的排列
     *
     * https://leetcode-cn.com/problems/beautiful-arrangement/description/
     *
     * Category	Difficulty	Likes	Dislikes
     * algorithms	Medium (65.08%)	136	-
     * Tags
     * backtracking
     * 
     * Companies
     * google
     * 
     * Total Accepted:    11.2K
     * Total Submissions: 17.2K
     * Testcase Example:  '2'
     *
     * 假设有从 1 到 N 的 N 个整数，如果从这 N 个数字中成功构造出一个数组，使得数组的第 i 位 (1 <= i <= N)
     * 满足如下两个条件中的一个，我们就称这个数组为一个优美的排列。条件：
     * 
     * 第 i 位的数字能被 i 整除
     * i 能被第 i 位上的数字整除
     * 现在给定一个整数 N，请问可以构造多少个优美的排列？
     * 
     * 示例1:
     * 输入: 2
     * 输出: 2
     * 解释: 
     * 
     * 第 1 个优美的排列是 [1, 2]:
     * ⁠ 第 1 个位置（i=1）上的数字是1，1能被 i（i=1）整除
     * ⁠ 第 2 个位置（i=2）上的数字是2，2能被 i（i=2）整除
     * 
     * 第 2 个优美的排列是 [2, 1]:
     * ⁠ 第 1 个位置（i=1）上的数字是2，2能被 i（i=1）整除
     * ⁠ 第 2 个位置（i=2）上的数字是1，i（i=2）能被 1 整除
     * 
     * 
     * 说明:
     * N 是一个正整数，并且不会超过15。
     */
    public class Solution526 : SolutionBase
    {
        /// <summary>
        /// 难易度:
        /// </summary>
        public override Difficulity GetDifficulity() { return Difficulity.Medium; }
        /// <summary>
        /// 关键字:
        /// </summary>
        public override string[] GetKeyWords() { return new string[] { "优美的排列", "C#比Java慢（相同的代码）" }; }
        /// <summary>
        /// 标签： 
        /// </summary>
        public override Tag[] GetTags() { return new Tag[] { Tag.Backtracking}; }

        public override bool Test(System.Diagnostics.Stopwatch sw)
        {
            int count = CountArrangement_ViolenceTLE(12);
            Print("N={0}, count = {1}", 2, count);
            return true;
        }
        #region  ------------ 暴力法 TLE/OK ----------------
        int count = 0;
        public int CountArrangement_ViolenceTLE(int N)
        {
            int[] nums = new int[N];
            for (int i = 1; i <= N; i++)
                nums[i - 1] = i;
            Permute(nums, 0); //Permute_LTE(nums, 0);
            return count;
        }
        
        public void Swap(int[] nums, int x, int y)
        {
            if (x == y) return;
            int temp = nums[x];
            nums[x] = nums[y];
            nums[y] = temp;
        }

        #region  ------------ 暴力法 改进前后 ----------------
        /// <summary>
        /// Permute : 置换；交换；变更;
        /// </summary>
        /// <param name="nums">N长度数组</param>
        /// <param name="l">优美排列的长度</param>
        public void Permute_LTE(int[] nums, int l)
        {
            if (l == nums.Length - 1) //最后一个索引
            {
                //Print("[{0}] count ={1}", GetArrayStr(nums), count);
                int i;
                for (i = 1; i <= nums.Length; i++)
                {
                    if (nums[i - 1] % i != 0 && i % nums[i - 1] != 0)
                        break;
                }
                //全部通过规则测试，i=nums.Length+1，则count++
                if (i > nums.Length)
                {
                    count++;
                }
            }

            for (int i = l; i < nums.Length; i++)
            {
                Swap(nums, i, l);    //交换i,l
                Permute_LTE(nums, l + 1);//下一个长度
                Swap(nums, i, l);    //交换i,l
            }
        }

        public void Permute(int[] nums, int l)
        {
            if (l == nums.Length)
            {
                count++;
            }
            for (int i = l; i < nums.Length; i++)
            {
                Swap(nums, i, l);
                if (nums[l] % (l + 1) == 0 || (l + 1) % nums[l] == 0)
                    Permute_LTE(nums, l + 1);
                Swap(nums, i, l);
            }
        }
        #endregion
        #endregion

        #region ----------- 回溯法 --------------

        /// <summary>
        /// 时间复杂度：O(k)。k 是有效排列的数目。
        /// 空间复杂度：O(n)。这里 n 是给定的整数 n。使用了大小为 n 的数组 visited。递归树的深度最多为 n，
        /// 15/15 cases passed (144 ms)
        /// Your runtime beats 33.33 % of csharp submissions
        /// Your memory usage beats 25 % of csharp submissions(14.9 MB)
        /// </summary>
        /// <param name="N"></param>
        /// <returns></returns>
        public int CountArrangement(int N)
        {
            bool[] visited = new bool[N + 1];
            calculate(N, 1, visited);
            return count;
        }
        public void calculate(int N, int pos, bool[] visited)
        {
            if (pos > N)
                count++;
            for (int i = 1; i <= N; i++)
            {
                if (!visited[i] && (pos % i == 0 || i % pos == 0))
                {
                    visited[i] = true;
                    calculate(N, pos + 1, visited);
                    visited[i] = false;
                }
            }
        }
        #endregion
    }
}
