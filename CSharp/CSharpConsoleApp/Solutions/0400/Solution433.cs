using System;
namespace CSharpConsoleApp.Solutions
{
    /*
     * @lc app=leetcode.cn id=433 lang=csharp
     *
     * [433] 最小基因变化
     *
     * https://leetcode-cn.com/problems/minimum-genetic-mutation/description/
     *
     * Category	Difficulty	Likes	Dislikes
     * algorithms	Medium (53.47%)	78	-
     * Tags
     * Unknown
     * 
     * Companies
     * twitter
     * 
     * Total Accepted:    13.7K
     * Total Submissions: 25.6K
     * Testcase Example:  '"AACCGGTT"\n"AACCGGTA"\n["AACCGGTA"]'
     *
     * 一条基因序列由一个带有8个字符的字符串表示，其中每个字符都属于 "A", "C", "G", "T"中的任意一个。
     * 假设我们要调查一个基因序列的变化。一次基因变化意味着这个基因序列中的一个字符发生了变化。
     * 
     * 例如，基因序列由"AACCGGTT" 变化至 "AACCGGTA" 即发生了一次基因变化。
     * 与此同时，每一次基因变化的结果，都需要是一个合法的基因串，即该结果属于一个基因库。
     * 
     * 现在给定3个参数 — start, end,
     * bank，分别代表起始基因序列，目标基因序列及基因库，请找出能够使起始基因序列变化为目标基因序列所需的最少变化次数。如果无法实现目标变化，请返回
     * -1。
     * 
     * 注意：
     * 起始基因序列默认是合法的，但是它并不一定会出现在基因库中。
     * 如果一个起始基因序列需要多次变化，那么它每一次变化之后的基因序列都必须是合法的。
     * 假定起始基因序列与目标基因序列是不一样的。
     *
     * 
     * 示例 1：
     * start: "AACCGGTT"
     * end:   "AACCGGTA"
     * bank: ["AACCGGTA"]
     * 返回值: 1
     * 
     * 
     * 示例 2：
     * start: "AACCGGTT"
     * end:   "AAACGGTA"
     * bank: ["AACCGGTA", "AACCGCTA", "AAACGGTA"]
     * 返回值: 2
     * 
     * 
     * 示例 3：
     * start: "AAAAACCC"
     * end:   "AACCCCCC"
     * bank: ["AAAACCCC", "AAACCCCC", "AACCCCCC"]
     * 返回值: 3
     */

    // @lc code=start
    public class Solution433 : SolutionBase
    {
        /// <summary>
        /// 难度
        /// </summary>
        public override Difficulity GetDifficulity() { return Difficulity.Medium; }
        /// <summary>
        /// 关键字:
        /// </summary>
        public override string[] GetKeyWords() { return new string[] { "基因序列" , "碱基(A、C、G、T)" }; }
        /// <summary>
        /// 标签：
        /// </summary>
        public override Tag[] GetTags() { return new Tag[] { Tag.Unknown, Tag.DepthFirstSearch }; }

        public override bool Test(System.Diagnostics.Stopwatch sw)
        {
            bool isSuccess = true;
            string start, end; string[] bank;

            int result, checkResult;

            start = "AACCGGTT"; end = "AACCGGTA";
            bank = new string[] { "AACCGGTA" };
            checkResult = 1;
            result = MinMutation(start, end, bank);
            isSuccess &= IsSame(result, checkResult);
            PrintResult(isSuccess, (result), (checkResult));

            return isSuccess;
        }

        //作者：JsonLuo
        //链接：https://leetcode-cn.com/problems/minimum-genetic-mutation/solution/java-dfs-bu-xu-yao-ji-lu-shi-yong-guo-de-pian-duan/
        // 执行耗时:0 ms,击败了100.00% 的Java用户
        // 内存消耗:37.1 MB,击败了98.97% 的Java用户

        /// <summary>
        /// 14/14 cases passed (116 ms)
        /// Your runtime beats 66.67 % of csharp submissions
        /// Your memory usage beats 100 % of csharp submissions(23.8 MB)
        /// </summary>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <param name="bank"></param>
        /// <returns></returns>
        public int MinMutation(string start, string end, string[] bank)
        {
            char[][] banks = new char[bank.Length][];
            for (int i = 0; i < bank.Length; i++)
            {
                banks[i] = bank[i].ToCharArray();
            }
            DFS(start.ToCharArray(), end.ToCharArray(), banks, 0);
            return minChange == int.MaxValue ? -1 : minChange;
        }

        int minChange = int.MaxValue;
        private void DFS(char[] start, char[] end, char[][] bank, int change)
        {
            if (IsArraySame(start, end)) // 此处不能使用 Array.Equal(A,B)方法（该方法为内存比较）
            {
                minChange = Math.Min(minChange, change);
                return;
            }

            for (int j = 0; j < bank.Length; j++)
            {
                char[] piece = bank[j];
                if (piece == null) continue; // 已用过的片段
                int diff = 0; // 获取基因库中不同为1的片段,作为改变一次后的新start
                for (int i = 0; i < start.Length; i++)
                {
                    if (start[i] != piece[i]) diff++;
                }
                if (diff == 1)
                {
                    bank[j] = null; // 置空,防止循环使用
                    DFS(piece, end, bank, change + 1);
                    bank[j] = piece; // 还原回溯
                }
            }
        }

        public bool IsArraySame<T>(T[] a, T[] b, bool ignoreTail = true)
        {
            int alen = a == null ? 0 : a.Length;
            int blen = b == null ? 0 : b.Length;

            if (!ignoreTail)
            {
                if (alen != blen)
                    return false;
            }

            int compareLen = Math.Min(alen, blen);
            {
                for (int i = 0; i < compareLen; i++)
                {
                    if (!a[i].Equals(b[i]))
                        return false;
                }
            }
            return true;
        }
    }
    // @lc code=end


}
