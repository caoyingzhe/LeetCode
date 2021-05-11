using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpConsoleApp.Solutions._0500
{
    /*
     * @lc app=leetcode.cn id=551 lang=csharp
     *
     * [551] 学生出勤记录 I
     *
     * https://leetcode-cn.com/problems/student-attendance-record-i/description/
     *
     * Category	Difficulty	Likes	Dislikes
     * algorithms	Easy (52.65%)	71	-
     * Tags
     * string
     * 
     * Companies
     * google
     * 
     * Total Accepted:    26.6K
     * Total Submissions: 50.5K
     * Testcase Example:  '"PPALLP"'
     *
     * 给定一个字符串来代表一个学生的出勤记录，这个记录仅包含以下三个字符：
     * 
     * 'A' : Absent，缺勤
     * 'L' : Late，迟到
     * 'P' : Present，到场
     * 
     * 如果一个学生的出勤记录中不超过一个'A'(缺勤)并且不超过两个连续的'L'(迟到),那么这个学生会被奖赏。
     * 
     * 你需要根据这个学生的出勤记录判断他是否会被奖赏。
     * 
     * 示例 1:
     * 输入: "PPALLP"
     * 输出: True
     * 
     * 
     * 示例 2:
     * 输入: "PPALLL"
     * 输出: False
     * 
     * 
     */
    class Solution551 : SolutionBase
    {   
        /// <summary>
        /// 难度
        /// </summary>
        public override Difficulity GetDifficulity() { return Difficulity.Hard; }
        /// <summary>
        /// 关键字:
        /// </summary>
        public override string[] GetKeyWords() { return new string[] { "二叉树中的最大路径和", }; }
        /// <summary>
        /// 标签：
        /// </summary>
        public override Tag[] GetTags() { return new Tag[] { Tag.Tree, Tag.DepthFirstSearch }; }

        public override bool Test(System.Diagnostics.Stopwatch sw)
        {
            bool isSuccess = true;
            string s;
            bool result;
            bool checkResult;

            s = "PPALLP";
            checkResult = true;
            result = CheckRecord(s);
            isSuccess &= (checkResult == result);
            Print("isSuccess ={0} | result = {1} | checkResult = {2}", isSuccess, result, checkResult);

            s = "PPALLL";
            checkResult = false;
            result = CheckRecord(s);
            isSuccess &= (checkResult == result);
            Print("isSuccess ={0} | result = {1} | checkResult = {2}", isSuccess, result, checkResult);
            
            s = "AAAA";
            checkResult = false;
            result = CheckRecord(s);
            isSuccess &= (checkResult == result);
            Print("isSuccess ={0} | result = {1} | checkResult = {2}", isSuccess, result, checkResult);

            return isSuccess;
        }
        /// <summary>
        /// Accepted
        /// 113/113 cases passed (72 ms)
        /// Your runtime beats 97.83 % of csharp submissions
        /// Your memory usage beats 36.96 % of csharp submissions(22.4 MB)
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public bool CheckRecord(string s)
        {
            int ca = 0;
            int i = 0;
            int n = s.Length;
            while(i<n)
            {
                if (s[i] == 'A')
                {
                    ca++;
                    if (ca >= 2)
                        return false;
                }
                else if (s[i] == 'L')
                {
                    if (i + 2 < n && s[i + 1] == 'L' && s[i + 2] == 'L')
                    {
                        //cll++;
                        return false;
                    }
                }
                i++;
            }
            //Print("A:{0} | LL:{1}", ca, cll);
            return true;
        }
    }
}
