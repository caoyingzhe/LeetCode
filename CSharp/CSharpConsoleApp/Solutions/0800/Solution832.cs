using System;
namespace CSharpConsoleApp.Solutions
{
    public class Solution832
    {
        /// <summary>
        /// 时间复杂度：O(n^2)O(n2)，其中 nn 是矩阵
        /// 空间复杂度：O(1)O(1)。除了返回值以外，额外使用的空间为常数。
        /// 82/82 cases passed (228 ms)
        /// Your runtime beats 100 % of csharp submissions
        /// Your memory usage beats 33.33 % of csharp submissions(32 MB)
        /// </summary>
        /// <param name="image"></param>
        /// <returns></returns>
        public int[][] FlipAndInvertImage(int[][] image)
        {
            int n = image.Length;
            for (int i = 0; i < n; i++)
            {
                int L = 0, R = n - 1;
                while (L < R)
                {
                    if (image[i][L] == image[i][R])
                    {
                        image[i][L] ^= 1;
                        image[i][R] ^= 1;
                    }
                    L++;
                    R--;
                }
                if (L == R)
                {
                    image[i][L] ^= 1;
                }
            }
            return image;
        }
    }
}
