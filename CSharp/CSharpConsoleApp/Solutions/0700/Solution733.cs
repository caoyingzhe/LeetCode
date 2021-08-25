using System;
namespace CSharpConsoleApp.Solutions
{
    /*
     * @lc app=leetcode.cn id=733 lang=csharp
     *
     * [733] 图像渲染
     *
     * https://leetcode-cn.com/problems/flood-fill/description/
     *
     * Category	Difficulty	Likes	Dislikes
     * algorithms	Easy (57.83%)	203	-
     * Tags
     * depth-first-search
     * 
     * Companies
     * Unknown
     * 
     * Total Accepted:    55K
     * Total Submissions: 94.7K
     * Testcase Example:  '[[1,1,1],[1,1,0],[1,0,1]]\n1\n1\n2'
     *
     * 有一幅以二维整数数组表示的图画，每一个整数表示该图画的像素值大小，数值在 0 到 65535 之间。
     * 
     * 给你一个坐标 (sr, sc) 表示图像渲染开始的像素值（行 ，列）和一个新的颜色值 newColor，让你重新上色这幅图像。
     * 
     * 
     * 为了完成上色工作，从初始坐标开始，记录初始坐标的上下左右四个方向上像素值与初始坐标相同的相连像素点，接着再记录这四个方向上符合条件的像素点与他们对应四个方向上像素值与初始坐标相同的相连像素点，……，重复该过程。将所有有记录的像素点的颜色值改为新的颜色值。
     * 
     * 最后返回经过上色渲染后的图像。
     * 
     * 示例 1:
     * 
     * 
     * 输入: 
     * image = [[1,1,1],[1,1,0],[1,0,1]]
     * sr = 1, sc = 1, newColor = 2
     * 输出: [[2,2,2],[2,2,0],[2,0,1]]
     * 解析: 
     * 在图像的正中间，(坐标(sr,sc)=(1,1)),
     * 在路径上所有符合条件的像素点的颜色都被更改成2。
     * 注意，右下角的像素没有更改为2，
     * 因为它不是在上下左右四个方向上与初始点相连的像素点。
     * 
     * 
     * 注意:
     * 
     * 
     * image 和 image[0] 的长度在范围 [1, 50] 内。
     * 给出的初始点将满足 0 <= sr < image.length 和 0 <= sc < image[0].length。
     * image[i][j] 和 newColor 表示的颜色值在范围 [0, 65535]内。
     * 
     * 
     */

    // @lc code=start
    public class Solution733 : SolutionBase
    {
        /// <summary>
        /// 难度
        /// </summary>
        public override Difficulity GetDifficulity() { return Difficulity.Easy; }
        /// <summary>
        /// 关键字:
        /// </summary>
        public override string[] GetKeyWords() { return new string[] { "抄作业" }; }
        /// <summary>
        /// 标签：
        /// </summary>
        public override Tag[] GetTags() { return new Tag[] { Tag.DepthFirstSearch }; }

        /// <summary>
        /// </summary>
        /// <param name="sw"></param>
        /// <returns></returns>
        public override bool Test(System.Diagnostics.Stopwatch sw)
        {
            bool isSuccess = true;
            //TODO
            //PrintDatas(PoorPigs(new int[] { 0, 0 }, new int[] { 1, 1 }, new int[] { 1, 0 }, new int[] { 0, 1 }));
            return isSuccess;
        }

        private int Origin;

        /// <summary>
        /// 277/277 cases passed (244 ms)
        /// Your runtime beats 55.68 % of csharp submissions
        /// Your memory usage beats 86.36 % of csharp submissions(32.5 MB)
        /// </summary>
        /// <param name="image"></param>
        /// <param name="sr"></param>
        /// <param name="sc"></param>
        /// <param name="newColor"></param>
        /// <returns></returns>
        public int[][] FloodFill(int[][] image, int sr, int sc, int newColor)
        {
            Origin = image[sr][sc];
            //Console.WriteLine(image.Length);
            if (Origin != newColor)
            {
                dfs(image, sr, sc, newColor);
            }
            return image;
        }

        public void dfs(int[][] img, int sr, int sc, int newColor)
        {
            //超出边界，或者颜色不等的直接返回
            if (sr < 0 || sr >= img.Length || sc < 0 || sc >= img[0].Length || img[sr][sc] != Origin)
            {
                return;
            }
            //先更新当前颜色，然后深度搜索周围的像素并更新。
            img[sr][sc] = newColor;
            dfs(img, sr + 1, sc, newColor);
            dfs(img, sr - 1, sc, newColor);
            dfs(img, sr, sc + 1, newColor);
            dfs(img, sr, sc - 1, newColor);
        }

        public char nextGreatestLetter(char[] letters, char target)
        {
            int n = letters.Length, L = 0, R = n;
            while (L < R)
            {
                int mid = L + (R - L) / 2;
                if (letters[mid] <= target) L = mid + 1;
                else R = mid;
            }
            return letters[L % n];
        }
    }
    // @lc code=end
}
