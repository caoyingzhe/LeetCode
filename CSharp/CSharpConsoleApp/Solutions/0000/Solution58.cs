using System;
namespace CSharpConsoleApp.Solutions
{
    public class Solution58
    {
        public int LengthOfLastWord(string s)
        {
            int c = 0;
            int i = s.Length - 1;
            while (i >= 0 && s[i] == ' ') --i;
            while (i >= 0 && s[i--] != ' ') ++c;
            return c;
        }

        ///作者：Xiaohu9527
        ///链接：https://leetcode-cn.com/problems/length-of-last-word/solution/csong-fen-pian-zan-ti-by-xiaohu9527-06o9/

    }
}
