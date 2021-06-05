using System;
namespace CSharpConsoleApp.Solutions
{
    /*
     * @lc app=leetcode.cn id=74 lang=csharp
     *
     * [74] 搜索二维矩阵
     *
     * https://leetcode-cn.com/problems/search-a-2d-matrix/description/
     *
     * Category	Difficulty	Likes	Dislikes
     * algorithms	Medium (44.90%)	442	-
     * Tags
     * array | binary-search
     * 
     * Companies
     * Unknown
     * Total Accepted:    140.3K
     * Total Submissions: 312.4K
     * Testcase Example:  '[[1,3,5,7],[10,11,16,20],[23,30,34,60]]\n3'
     *
     * 编写一个高效的算法来判断 m x n 矩阵中，是否存在一个目标值。该矩阵具有如下特性：
     * 每行中的整数从左到右按升序排列。
     * 每行的第一个整数大于前一行的最后一个整数。
     * 
     * 示例 1：
     * 输入：matrix = [[1,3,5,7],[10,11,16,20],[23,30,34,60]], target = 3
     * 输出：true
     * 
     * 示例 2：
     * 输入：matrix = [[1,3,5,7],[10,11,16,20],[23,30,34,60]], target = 13
     * 输出：false
     * 
     * 提示：
     * m == matrix.length
     * n == matrix[i].length
     * 1 <= m, n <= 100
     * -10^4 <= matrix[i][j], target <= 10^4
     */
    public class Solution74
    {
        /// <summary>
        /// 133/133 cases passed (112 ms)
        /// Your runtime beats 62.66 % of csharp submissions
        /// Your memory usage beats 16.76 % of csharp submissions(25 MB)
        /// 作者：LeetCode-Solution
        /// 链接：https://leetcode-cn.com/problems/search-a-2d-matrix/solution/sou-suo-er-wei-ju-zhen-by-leetcode-solut-vxui/
        /// </summary>
        /// <param name="matrix"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public bool SearchMatrix(int[][] matrix, int target)
        {
            int m = matrix.Length, n = matrix[0].Length;
            int low = 0, high = m * n - 1;
            while (low <= high)
            {
                int mid = (high - low) / 2 + low;
                int x = matrix[mid / n][mid % n];
                if (x < target)
                {
                    low = mid + 1;
                }
                else if (x > target)
                {
                    high = mid - 1;
                }
                else
                {
                    return true;
                }
            }
            return false;
        }
    }
}
