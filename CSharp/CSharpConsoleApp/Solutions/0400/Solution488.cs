using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace CSharpConsoleApp.Solutions
{
    /// <summary>
    /// [488] 祖玛游戏 Baidu
    /// </summary>
    class Solution488 : SolutionBase
    {
        /// <summary>
        /// 难度
        /// </summary>
        public override Difficulity GetDifficulity() { return Difficulity.Hard; }
        /// <summary>
        /// 关键字:
        /// </summary>
        public override string[] GetKeyWords() { return new string[] { "DFS"}; }
        /// <summary>
        /// 标签： 
        /// </summary>
        public override Tag[] GetTags() { return new Tag[] { Tag.DepthFirstSearch }; }
        public override bool Test(Stopwatch sw)
        {
            string board;
            string hand;
            int result;
            int checkResult;
            bool isSuccess = true;

            board = "WRRBBW";
            hand = "RB";
            checkResult = -1;
            result = FindMinStep(board, hand);
            isSuccess &= (checkResult == result);
            Print("{4} board ={0} board={1} result={2} | anticipated = {3}", board, hand, result, checkResult, isSuccess);
            
            board = "WWRRBBWW";
            hand = "WRBRW";
            checkResult = 2;
            result = FindMinStep(board, hand);
            isSuccess &= (checkResult == result);
            Print("{4} board ={0} board={1} result={2} | anticipated = {3}", board, hand, result, checkResult, isSuccess);
            
            board = "G";
            hand = "GGGGG";
            checkResult = 2;
            result = FindMinStep(board, hand);
            isSuccess &= (checkResult == result);
            Print("{4} board ={0} board={1} result={2} | anticipated = {3}", board, hand, result, checkResult, isSuccess);

            board = "RBYYBBRRB";
            hand = "YRBGB";
            checkResult = 3;
            result = FindMinStep(board, hand);
            isSuccess &= (checkResult == result);
            Print("{4} board ={0} board={1} result={2} | anticipated = {3}", board, hand, result, checkResult, isSuccess);

            return isSuccess;
        }
#if !USE_JAVA 
        private int result = int.MaxValue;
        private int[] map = new int[26];
        private char[] colors = { 'R', 'Y', 'B', 'G', 'W' };

        public int FindMinStep(String board, String hand)
        {
            //由于使用了私有变量，连续测试时，测试用例4不过，原因是变量值未重置，重置即可。
            result = int.MaxValue;
            map = new int[26];
            colors = new char[] { 'R', 'Y', 'B', 'G', 'W' };

            for (int i = 0; i < hand.Length; i++)
            {
                map[hand[i] - 'A']++;
            }
            dfs(new StringBuilder(board), 0);
            return result == int.MaxValue ? -1 : result;
        }

        private void dfs(StringBuilder board, int step)
        {
            if (step >= result)
            {
                return;
            }
            if (board.Length == 0)
            {
                result = Math.Min(step, result);
                return;
            }
            for (int i = 0; i < board.Length; i++)
            {
                char c = board[i];
                int j = i;
                while (j + 1 < board.Length && board[j + 1] == c)
                {
                    j++;
                }
                if (j == i && map[c - 'A'] >= 2)
                {  //只有单个球
                    StringBuilder tmp = new StringBuilder(board.ToString());
                    tmp.Insert(i, c + "" + c); //tmp.insert(i, c + "" + c);
                    map[c - 'A'] -= 2;
                    dfs(eliminate(tmp), step + 2);
                    map[c - 'A'] += 2;
                }
                else if (j == i + 1)
                {    //存在两个颜色相同且相邻的球
                    if (map[c - 'A'] >= 1)
                    {
                        StringBuilder tmp = new StringBuilder(board.ToString());
                        tmp.Insert(i, c);
                        map[c - 'A']--;
                        dfs(eliminate(tmp), step + 1);
                        map[c - 'A']++;
                    }
                    foreach (char color in colors)
                    {
                        if (color == c)
                        {
                            continue;
                        }
                        if (map[color - 'A'] >= 1)
                        {
                            StringBuilder tmp = new StringBuilder(board.ToString());
                            tmp.Insert(i + 1, color);   //尝试往这两个颜色相同且相邻的球中间插入一个颜色不同的球
                            map[color - 'A']--;
                            dfs(eliminate(tmp), step + 1);
                            map[color - 'A']++;
                        }
                    }
                }
            }
        }

        private StringBuilder eliminate(StringBuilder sb)
        {
            bool flag = true;
            while (flag)
            {
                flag = false;
                for (int i = 0; i < sb.Length; i++)
                {
                    int j = i + 1;
                    while (j < sb.Length && sb[j] == sb[i])
                    {
                        j++;
                    }
                    if (j - i >= 3)
                    {
                        sb.Remove(i, j-i); // sb.delete(i, j); //Java StringBuilder delete?(int start, int end)
                        flag = true;
                    }
                }
            }
            return sb;
        }
     //作者：617076674
     //https://leetcode-cn.com/problems/zuma-game/solution/zu-ma-you-xi-by-617076674/

#elif USE_CPP
        #region Version C++  测试用例2不过
        //作者：金木盐
        //链接：https://leetcode-cn.com/problems/zuma-game/solution/zu-ma-you-xi-by-617076674/

        int ans = int.MaxValue;
        public int FindMinStep(string board, string hand)
        {
            List<int> cnts = new List<int>();
            for(int i=0;i<26;i++)
            {
                cnts.Add(0);
            }
            foreach(char ch in hand)
            { 
                ++cnts[(int)ch - (int)'A']; //'A~Z:65~90  a~z:97~122
            }
            dfs(board, cnts, 0);
            return ans == int.MaxValue ? -1 : ans;
        }

        void dfs(string s, List<int> cnts, int step) 
        {
            if (step >= ans) return;
            if(string.IsNullOrEmpty(s)) {
                ans = Math.Min(ans, step);
                return;
            }
            int n = s.Length;
            for (int i = 0; i<n; ++i) {
                int j = i;
                if (j + 1 < n && s[j + 1] == s[i]) ++j;
                if (i == j && cnts[s[i] - 'A'] > 1) { //当只有一个连续的球且剩余的相同的球数大于1
                    string nb = s;
                    string tmp = ""+ s[i] + s[i]; // string(2, s[i]);
                    nb.Insert(i, tmp); //nb.insert(nb.begin() + i, tmp.begin(), tmp.end());
                    cnts[s[i] - 'A'] -= 2;

                    dfs(eliminate(nb), cnts, step + 2); //因为一次插入了两个球因此+2
                    cnts[s[i] - 'A'] += 2;
                }
                else if (j > i) {  //当有两个连续相同的球时。
                    if (cnts[s[i] - 'A'] > 0) {
                        string nb = s;
                        nb.Insert(i, s[i].ToString());
                        cnts[s[i] - 'A']--;
                        dfs(eliminate(nb), cnts, step + 1);
                        cnts[s[i] - 'A']++;
                    }

                    foreach (char ch in "RYBGW") {  //在两个连续相同球之间插入不同的球。
                        if (ch == s[i] || cnts[ch - 'A'] != 0) continue;
                        string nb = s;
                        nb.Insert(j, ch.ToString());
                        cnts[ch - 'A']--;
                        dfs(eliminate(nb), cnts, step + 1);
                        cnts[ch - 'A']++;
                    }
                }
            }
        }

        string eliminate(string s)
        {
            if (s.Length <= 2) return s;
            bool flag = true;
            while (flag)
            {
                flag = false;
                for (int i = 0; i < s.Length; ++i)
                {
                    int j = i + 1;
                    while (j < s.Length && s[j] == s[i]) ++j;
                    if (j - i > 2)
                    {
                        flag = true;
                        //s.erase(s.begin() + i, s.begin() + j); // pos=i, n = j;
                        s.Remove(i, j - i);
                    }
                }
            }
            return s;
        }
        #endregion
#endif
    }
}
