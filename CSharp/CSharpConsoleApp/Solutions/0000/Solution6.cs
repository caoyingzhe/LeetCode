using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpConsoleApp.Solutions
{
    /*
     * @lc app=leetcode.cn id=6 lang=csharp
     *
     * [6] Z 字形变换
     *
     * https://leetcode-cn.com/problems/zigzag-conversion/description/
     *
     * Category	Difficulty	Likes	Dislikes
     * algorithms	Medium (49.79%)	1084	-
     * Tags
     * string
     * 
     * Companies
     * Unknown
     * 
     * Total Accepted:    233.2K
     * Total Submissions: 468.4K
     * Testcase Example:  '"PAYPALISHIRING"\n3'
     *
     * 将一个给定字符串 s 根据给定的行数 numRows ，以从上往下、从左到右进行 Z 字形排列。
     * 
     * 比如输入字符串为 "PAYPALISHIRING" 行数为 3 时，排列如下：
     * 
     * 
     * P   A   H   N
     * A P L S I I G
     * Y   I   R
     * 
     * 之后，你的输出需要从左往右逐行读取，产生出一个新的字符串，比如："PAHNAPLSIIGYIR"。
     * 
     * 请你实现这个将字符串进行指定行数变换的函数：
     * 
     * string convert(string s, int numRows);
     * 
     * 示例 1：
     * 输入：s = "PAYPALISHIRING", numRows = 3
     * 输出："PAHNAPLSIIGYIR"
     * 
     * 示例 2：
     * 输入：s = "PAYPALISHIRING", numRows = 4
     * 输出："PINALSIGYAHRPI"
     * 解释：
     * P     I    N
     * A   L S  I G
     * Y A   H R
     * P     I
     * 
     * 
     * 示例 3：
     * 输入：s = "A", numRows = 1
     * 输出："A"
     * 
     * 提示：
     * 1 
     * s 由英文字母（小写和大写）、',' 和 '.' 组成
     * 1 
     */
    class Solution6 : SolutionBase
    {
        public override bool Test(System.Diagnostics.Stopwatch sw)
        {
            sw.Restart();

            bool isSucceed = true;
            string s;
            int numRows;
            string result;
            string checkResult;

            s = "PAYPALISHIRING";
            numRows = 3;
            checkResult = "PAHNAPLSIIGYIR";
            result = Convert(s, numRows);
            Print(result + " | " + checkResult);
            isSucceed &= (checkResult == result);

            s = "PAYPALISHIRING";
            numRows = 4;
            checkResult = "PINALSIGYAHRPI";
            result = Convert(s, numRows);
            Print(result + " | " + checkResult);
            isSucceed &= (checkResult == result);

            s = "A";
            numRows = 1;
            checkResult = "A";
            result = Convert(s, numRows);
            Print(result + " | " + checkResult);
            isSucceed &= (checkResult == result);

            return isSucceed;
        }
        /// <summary>
        /// 效率很低
        /// Your runtime beats 21.85 % of csharp submissions
        /// Your memory usage beats 18.49 % of csharp submissions(28.8 MB)
        /// </summary>
        /// <param name="s"></param>
        /// <param name="numRows"></param>
        /// <returns></returns>
        public string Convert(string s, int numRows)
        {
            if (string.IsNullOrEmpty(s))
                return s;
            if (numRows == 1)
                return s;
            if (s.Length == 1)
                return s;

            int n = s.Length;
            int increment = (numRows - 1);
            int numCol = GetCol(n, increment);
            char[][] list = new char[numRows][];
            for (int i = 0; i < numRows; i++)
            {
                list[i] = new char[numCol];
                for (int j = 0; j < numCol; j++)
                    list[i][j] = ' ';
            }

            int row = 0; int col = 0;
            int rowDir = 1; int colDir = 0;
            for (int i = 0; i < s.Length; i++)
            {
                list[row][col] = s[i];

                rowDir = i % (increment * 2) < increment ? 1 : -1;
                colDir = i % (increment * 2) < increment ? 0 : 1;

                row += rowDir;
                col += colDir;
            }

            string result = "";
            for (int i = 0; i < numRows; i++)
            {
                for (int j = 0; j < numCol; j++)
                    if (list[i][j] != ' ')
                        result += list[i][j];
            }
            return result;
        }

        int GetCol(int index, int increment)
        {
            int foldCount = (index - 1) / increment;
            int foldMod = (index - 1) % increment;
            int column = 1 + (foldCount / 2) * increment + foldCount % 2 * foldMod;

            return column;
        }
    }
}
