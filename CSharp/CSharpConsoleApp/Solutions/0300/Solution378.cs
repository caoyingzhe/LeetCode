using System;
namespace CSharpConsoleApp.Solutions
{
    /*
     * @lc app=leetcode.cn id=378 lang=csharp
     *
     * [378] 有序矩阵中第 K 小的元素
     *
     * https://leetcode-cn.com/problems/kth-smallest-element-in-a-sorted-matrix/description/
     *
     * Category	Difficulty	Likes	Dislikes
     * algorithms	Medium (63.39%)	587	-
     * Tags
     * binary-search | heap
     * 
     * Companies
     * google | twitter
     * 
     * Total Accepted:    68.8K
     * Total Submissions: 108.6K
     * Testcase Example:  '[[1,5,9],[10,11,13],[12,13,15]]\n8'
     *
     * 给你一个 n x n 矩阵 matrix ，其中每行和每列元素均按升序排序，找到矩阵中第 k 小的元素。
     * 请注意，它是 排序后 的第 k 小元素，而不是第 k 个 不同 的元素。
     * 
     * 示例 1：
     * 输入：matrix = [[1,5,9],[10,11,13],[12,13,15]], k = 8
     * 输出：13
     * 解释：矩阵中的元素为 [1,5,9,10,11,12,13,13,15]，第 8 小元素是 13
     * 
     * 示例 2：
     * 输入：matrix = [[-5]], k = 1
     * 输出：-5
     * 
     * 提示：
     * n == matrix.length
     * n == matrix[i].length
     * 1 <= n <= 300
     * -10^9 <= matrix[i][j] <= 10^9
     * 题目数据 保证 matrix 中的所有行和列都按 非递减顺序 排列
     * 1 <= k <= n2 
     */
    public class Solution378 : SolutionBase
    {
        /// <summary>
        /// 难度
        /// </summary>
        public override Difficulity GetDifficulity() { return Difficulity.Medium; }
        /// <summary>
        /// 关键字:
        /// </summary>
        public override string[] GetKeyWords() { return new string[] { "有序矩阵", "二进制搜索" }; }
        /// <summary>
        /// 标签： 
        /// </summary>
        public override Tag[] GetTags() { return new Tag[] { Tag.BinarySearch, Tag.Heap }; }

        public override bool Test(System.Diagnostics.Stopwatch sw)
        {
            bool isSuccess = true;
            int[][] matrix = new int[][]  {
                new int[] { 1, 5, 6,  9},
                new int[] { 10,11,12, 13},
                new int[] { 12,21,26, 28},
                new int[] { 18,25,27, 29}
            };
            int k = 8;

            int result = KthSmallest(matrix, k);

            Print("result = {0}", k);

            isSuccess &= result == 12;
            return isSuccess;
        }


        //作者：LeetCode-Solution
        //链接：https://leetcode-cn.com/problems/kth-smallest-element-in-a-sorted-matrix/solution/you-xu-ju-zhen-zhong-di-kxiao-de-yuan-su-by-leetco/
        /// <summary>
        /// 85/85 cases passed (148 ms)
        /// Your runtime beats 79.17 % of csharp submissions
        /// Your memory usage beats 45.83 % of csharp submissions(30.9 MB)
        /// </summary>
        /// <param name="matrix"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public int KthSmallest(int[][] matrix, int k)
        {
            int n = matrix.Length;
            int left = matrix[0][0];
            int right = matrix[n - 1][n - 1];

            while (left < right)
            {
                int mid = left + ((right - left) >> 1); // mid = L + (R-L)/2  L R MID =>  1,5,3  / 1, 15, 8,

                if (Check(matrix, mid, k, n))
                {
                    Print("Move to Right=>{2} | L={0}, R={1}, mid={2}", left, right, mid);
                    //不大于mid的数量 > K，即搜寻结果的最大值一定不小于mid，更新右侧=mid
                    right = mid;
                }
                else
                {
                    Print("Move to Left=> {2} | L={0}, R={1}, mid={2}", left, right, mid);
                    //不大于mid的数量 < K，即搜寻结果的最小值一定大于mid，更新右侧=mid
                    left = mid + 1;
                }
            }
            return left;
        }

        public bool Check(int[][] matrix, int mid, int k, int n)
        {
            //初始位置在 matrix[n−1][0]（即左下角）；
            int i = n - 1;  //行号
            int j = 0;      //列号
            int num = 0;    //不大于 mid 的数的数量
            while (i >= 0 && j < n)
            {
                Print("i={0} j={1} num={2}| mid ={3} [i][j] ={4}", i, j, num, mid, matrix[i][j]);

                //设当前位置为 matrix[i][j]，
                //若midmatrix[i][j] ≤ mid，则将当前所在列的不大于 mid 的数的数量（即i+1）
                //累加到答案中，并向右移动，否则向上移动；

                if (matrix[i][j] <= mid)
                {
                    num += i + 1; // num地表倒数第几，需要加 i+1 移动户，（每列增加的小于mid的数量为 i+1）
                    j++;          // j为列，j++代表并向右移动

                    Print("j++ i={0} j={1} num={2} ", i, j, num);
                }
                else
                {
                    i--;         　//i为行，i--代表向上移动；
                    //Print("i-- i={0} j={1} num={2} ", i, j, num);
                }
            }
            Print("num={0}| k ={1}", num, k);
            return num >= k;
        }

    }
}
