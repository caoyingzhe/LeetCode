using System;
namespace CSharpConsoleApp.Solutions
{
    /*
     * @lc app=leetcode.cn id=72 lang=csharp
     *
     * [72] 编辑距离
     *
     * https://leetcode-cn.com/problems/edit-distance/description/
     *
     * algorithms
     * Hard (60.74%)
     * Likes:    1607
     * Dislikes: 0
     * Total Accepted:    134.6K
     * Total Submissions: 221.6K
     * Testcase Example:  '"horse"\n"ros"'
     *
     * 给你两个单词 word1 和 word2，请你计算出将 word1 转换成 word2 所使用的最少操作数 。
     * 
     * 你可以对一个单词进行如下三种操作：
     * 
     * 插入一个字符
     * 删除一个字符
     * 替换一个字符
     * 
     * 示例 1：
     * 输入：word1 = "horse", word2 = "ros"
     * 输出：3
     * 解释：
     * horse -> rorse (将 'h' 替换为 'r')
     * rorse -> rose (删除 'r')
     * rose -> ros (删除 'e')
     * 
     * 
     * 示例 2：
     * 输入：word1 = "intention", word2 = "execution"
     * 输出：5
     * 解释：
     * intention -> inention (删除 't')
     * inention -> enention (将 'i' 替换为 'e')
     * enention -> exention (将 'n' 替换为 'x')
     * exention -> exection (将 'n' 替换为 'c')
     * exection -> execution (插入 'u')
     * 
     * 
     * 提示：
     * 0 <= word1.length, word2.length <= 500
     * word1 和 word2 由小写英文字母组成
     */
    public class Solution72
    {
        //作者：LeetCode-Solution
        //链接：https://leetcode-cn.com/problems/edit-distance/solution/bian-ji-ju-chi-by-leetcode-solution/
        /// <summary>
        /// 1146/1146 cases passed (96 ms)
        /// Your runtime beats 74.75 % of csharp submissions
        /// Your memory usage beats 89.9 % of csharp submissions(25.9 MB)
        /// </summary>
        /// <param name="word1"></param>
        /// <param name="word2"></param>
        /// <returns></returns>
        public int MinDistance(String word1, String word2)
        {
            int n = word1.Length;
            int m = word2.Length;

            // 有一个字符串为空串
            if (n * m == 0)
            {
                return n + m;
            }

            // DP 数组; D[i][j] 表示 A 的前 i 个字母和 B 的前 j 个字母之间的编辑距离。
            //我们有word1和word2，我们定义dp[i][j]的含义为：word1的前i个字符和word2的前j个字符的编辑距离。
            //意思就是word1的前i个字符，变成word2的前j个字符，最少需要这么多步。
            //例如word1 = "horse", word2 = "ros"，那么dp[3][2] = X就表示"hor"和“ro”的编辑距离，即把"hor"变成“ro”最少需要X步。
            int[][] D = new int[n + 1][];
            for (int i = 0; i < n + 1; i++) D[i] = new int[m+1];

            // 边界状态初始化
            for (int i = 0; i < n + 1; i++)
            {
                D[i][0] = i;
            }
            for (int j = 0; j < m + 1; j++)
            {
                D[0][j] = j;
            }

            // 计算所有 DP 值
            for (int i = 1; i < n + 1; i++)
            {
                for (int j = 1; j < m + 1; j++)
                {
                    int left = D[i - 1][j] + 1;         //D[i][j]=A，在单词 A 中插入一个字符，需要步数 = A+1
                    int down = D[i][j - 1] + 1;         //D[i][j]=B，在单词 B 中插入一个字符，需要步数 = B+1

                    int left_down = D[i - 1][j - 1];    //D[i][j]=C，修改单词 A 的一个字符，需要步数 = C (word1和word2最后一个字符串相等情况下)
                    if (word1[i - 1] != word2[j - 1])   
                    {
                        left_down += 1;                 //D[i][j]=C，修改单词 A 的一个字符，word1和word2最后一个字符串不等， 需要步数不变 = C+1
                    }
                    D[i][j] = Math.Min(left, Math.Min(down, left_down)); //取三者最小
                }
            }
            return D[n][m];
        }
    }
}
