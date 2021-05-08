using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpConsoleApp.Solutions
{
    /* 
    *  @lc app=leetcode.cn id=5 lang=csharp
    * 
    *  [5] 最长回文子串
    * 
    *  https://leetcode-cn.com/problems/longest-palindromic-substring/description/
    * 
    *  Category	Difficulty	Likes	Dislikes
    *  algorithms	Medium (33.69%)	3436	-
    *  Tags
    *  string | dynamic-programming
    *  
    *  Companies
    *  amazon | bloomberg | microsoft
    *  
    *  Total Accepted:    530.6K
    *  Total Submissions: 1.6M
    *  Testcase Example:  '"babad"'
    * 
    *  给你一个字符串 s，找到 s 中最长的回文子串。
    *  
    *  示例 1：
    *  输入：s = "babad"
    *  输出："bab" 
    *  解释："aba" 同样是符合题意的答案。
    *  
    *  示例 2：
    *  输入：s = "cbbd"
    *  输出："bb"
    *  
    *  示例 3：
    *  输入：s = "a"
    *  输出："a"
    *  
    *  示例 4：
    *  输入：s = "ac"
    *  输出："a"
    *  
    *  提示：
    *  1 
    *  s 仅由数字和英文字母（大写和/或小写）组成
    */
    class Solution5 : SolutionBase
    {
        /// <summary>
        /// 难度
        /// </summary>
        public override Difficulity GetDifficulity() { return Difficulity.Medium; }
        /// <summary>
        /// 关键字:
        /// </summary>
        public override string[] GetKeyWords() { return new string[] { "回文子串" }; }
        /// <summary>
        /// 标签： 
        /// </summary>
        public override Tag[] GetTags() { return new Tag[] { Tag.String, Tag.DynamicProgramming }; }

        public override bool Test(System.Diagnostics.Stopwatch sw)
        {
            string s;
            string checkResult;
            bool isSuccess = true;
            string result;

            s = "abaabd";
            result = LongestPalindrome(s);
            isSuccess &= result == "baab";
            Print("result =  {0}  | checkResult = {1}", result, "baab");

            //s = "babad";
            //result = LongestPalindrome(s);
            //isSuccess &= result == "bab" || result == "aba";
            //Print("result =  {0}  | checkResult = {1}", result, "bab or aba");
            //
            //s = "abbc";
            //checkResult = "bb";
            //result = LongestPalindrome(s);
            //Print("result =  {0}  | checkResult = {1}", result, checkResult);
            //isSuccess &= result == checkResult;
            //
            //s = "ac";
            //checkResult = "a";
            //result = LongestPalindrome(s);
            //Print("result =  {0}  | checkResult = {1}", result, "a or c");
            //isSuccess &= result == "a" || result == "c"; ;
            //
            //s = "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaabbbbbbbbbbbbbbbcccccccccccccccccbbbbbbbbbbbbbbbaaaaaaaaaaaaaaaaaaacccccccccccccccccbbbbbbbbbbbbb";
            //checkResult = "aaaaaaaaaaaaaaaaaaabbbbbbbbbbbbbbbcccccccccccccccccbbbbbbbbbbbbbbbaaaaaaaaaaaaaaaaaaa";
            //result = LongestPalindrome(s);
            //isSuccess &= result.Equals(checkResult);
            //Print("result =  {0}  | checkResult = {1}", result, checkResult);
            //
            //sw.Start();
            //s = "wsgdzojcrxtfqcfkhhcuxxnbwtxzkkeunmpdsqfvgfjhusholnwrhmzexhfqppatkexuzdllrbaxygmovqwfvmmbvuuctcwxhrmepxmnxlxdkyzfsqypuroxdczuilbjypnirljxfgpuhhgusflhalorkcvqfknnkqyprxlwmakqszsdqnfovptsgbppvejvukbxaybccxzeqcjhmnexlaafmycwopxntuisxcitxdbarsicvwrvjmxsapmhbbnuivzhkgcrshokkioagwidhmfzjwwywastecjsolxmhfnmgommkoimiwlgwxxdsxhuwwjhpxxgmeuzhdzmuqhmhnfwwokgvwsznfcoxbferdonrexzanpymxtfojodcfydedlxmxeffhwjeegqnagoqlwwdctbqnuxngrgovrjesrkjrfjawknbrsfywljscfvnjhczhyeoyzrtbkvvfvofykkwoiclgxyaddhpdoztdhcbauaagjmfzkkdqexkczfsztckdlujgqzjyuittnudpldjvsbwbzcsazjpxrwfafievenvuetzcxynnmskoytgznvqdlkhaowjtetveahpjguiowkiuvikwewmgxhgfjuzkgrkqhmxxavbriftadtogmhlatczusxkktcsyrnwjbeshifzbykqibghmmvecwwtwdcscikyzyiqlgwzycptlxiwfaigyhrlgtjocvajcnqyenxrnjgogeqtvkxllxpuoxargzgcsfwavwbnktchwjebvwwhfghqkcjhuhuqwcdsixrkfjxuzvhjxlyoxswdlwfytgbtqbeimzzogzrlovcdpseoafuxfmrhdswwictsctawjanvoafvzqanvhaohgndbsxlzuymvfflyswnkvpsvqezekeidadatsymbvgwobdrixisknqpehddjrsntkqpsfxictqbnedjmsveurvrtvpvzbengdijkfcogpcrvwyf";
            //checkResult = "knnk"; //xllx
            //result = LongestPalindrome(s);
            //sw.Stop();
            //Print("eclipse time = {0} ms | result = {1}", sw.ElapsedMilliseconds, result); // 542 ms
            //isSuccess &= result == checkResult || result == "xllx"; ;


            return isSuccess;
        }

        /// <summary>
        /// 常规算法  Time Limit Exceeded
        /// 竟然通过了，可惜速度太慢。耗时964 ms，勉强通过。
        /// 
        /// 176/176 cases passed (964 ms)
        /// Your runtime beats 5.05 % of csharp submissions
        /// Your memory usage beats 71.43 % of csharp submissions(24.4 MB)
        /// 
        /// 简单优化内容:
        /// 1. 使用哈希表保存搜索结果，
        /// 2. 删除substring的使用,用索引取代 
        /// 
        /// 第一次没有通过的case
        /// 169/176 cases passed (N/A)
        /// s = "wsgdzojcrxtfqcfkhhcuxxnbwtxzkkeunmpdsqfvgfjhusholnwrhmzexhfqppatkexuzdllrbaxygmovqwfvmmbvuuctcwxhrmepxmnxlxdkyzfsqypuroxdczuilbjypnirljxfgpuhhgusflhalorkcvqfknnkqyprxlwmakqszsdqnfovptsgbppvejvukbxaybccxzeqcjhmnexlaafmycwopxntuisxcitxdbarsicvwrvjmxsapmhbbnuivzhkgcrshokkioagwidhmfzjwwywastecjsolxmhfnmgommkoimiwlgwxxdsxhuwwjhpxxgmeuzhdzmuqhmhnfwwokgvwsznfcoxbferdonrexzanpymxtfojodcfydedlxmxeffhwjeegqnagoqlwwdctbqnuxngrgovrjesrkjrfjawknbrsfywljscfvnjhczhyeoyzrtbkvvfvofykkwoiclgxyaddhpdoztdhcbauaagjmfzkkdqexkczfsztckdlujgqzjyuittnudpldjvsbwbzcsazjpxrwfafievenvuetzcxynnmskoytgznvqdlkhaowjtetveahpjguiowkiuvikwewmgxhgfjuzkgrkqhmxxavbriftadtogmhlatczusxkktcsyrnwjbeshifzbykqibghmmvecwwtwdcscikyzyiqlgwzycptlxiwfaigyhrlgtjocvajcnqyenxrnjgogeqtvkxllxpuoxargzgcsfwavwbnktchwjebvwwhfghqkcjhuhuqwcdsixrkfjxuzvhjxlyoxswdlwfytgbtqbeimzzogzrlovcdpseoafuxfmrhdswwictsctawjanvoafvzqanvhaohgndbsxlzuymvfflyswnkvpsvqezekeidadatsymbvgwobdrixisknqpehddjrsntkqpsfxictqbnedjmsveurvrtvpvzbengdijkfcogpcrvwyf";
        /// checkResult = "knnk";
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public string LongestPalindrome_My(string s)
        {
            //保存回文的前后索引的哈希表
            HashSet<long> palindromeDict = new HashSet<long>();
            if (string.IsNullOrEmpty(s))
                return "";

            string result = "";
            int n = s.Length;

            int maxi = 0;
            int maxj = 0;
            int maxLen = (maxj - maxi + 1);
            for (int i = 0; i < n; i++)
            {
                int j = n-1;
                if (j - i + 1 <= maxLen)
                    break;

                
                while (j > i)
                {
                    //滤掉长度小于当前最大长度的字符串
                    if (j - i + 1 < maxLen)
                        break;

                    //if (IsPalindromeOld(s, i, j, palindromeDict))
                    if (IsPalindrome(s, i, j, palindromeDict))
                    {
                        if (maxLen < j - i + 1)
                        {
                            maxi = i; maxj = j;
                            maxLen = (maxj - maxi + 1);
                        }
                        break;
                    }
                    j--;
                }
            }

            if (n > 0 && maxLen == 0)
                result = s.Substring(0, 1);
            else
                result = s.Substring(maxi, maxLen);
            //Print("{0} => {1}", s, result);
            return result;
        }

        /// <summary>
        /// 判断是否是回文
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        private bool IsPalindromeOld(string org, int startIndex, int endIndex, HashSet<long> set)
        {
            //为了加快速度，该判断可以省略
            if (string.IsNullOrEmpty(org))
                return false;

            //为了加快速度，保证startIndex,endIndex为可靠输入的话,该判断可以省略
            if (endIndex >= org.Length || startIndex >= org.Length)
                return false;

            //如果已经存在与哈希表中了，就不比较了
            if (set.Contains( ((long)startIndex << 32) | (long)endIndex))
                return true;

            string s = org.Substring(startIndex, endIndex - startIndex + 1);
            if (s.Length == 1)
            {
                //返回true，但是并不添加到哈希表中
                return true;
            }
            bool isEven = s.Length % 2 == 0;
            int n = s.Length; int hn = n / 2;
            //从中间开始比较左右两侧
            for(int i= 1; i<= hn; i++)
            {
                int L = hn - i;
                int R = isEven ? hn + i - 1 : hn + i;  //根据奇偶获取右侧比较值的索引
                if (s[L] != s[R])  // n = 4, hn=2, hn-1 = 1; hn+1-1 = 2; i =0, s[1] == s[2] / i = 1, s[0] == s[3] 
                    return false;

                //set.Add(L << 32 | R);
            }

            //长度大于1，添加到哈希表中
            set.Add(((long)startIndex << 32) | (long)endIndex);

            //Print(s);
            return true;
        }

        private bool IsPalindrome(string org, int startIndex, int endIndex, HashSet<long> set)
        {
            //为了加快速度，该判断可以省略
            if (string.IsNullOrEmpty(org))
                return false;

            //为了加快速度，保证startIndex,endIndex为可靠输入的话,该判断可以省略
            if (endIndex >= org.Length || startIndex >= org.Length)
                return false;

            //如果已经存在与哈希表中了，就不比较了
            if (set.Contains(((long)startIndex << 32) | (long)endIndex))
                return true;

            if (endIndex == startIndex)
            {
                //返回true，但是并不添加到哈希表中
                return true;
            }
            int n = (endIndex - startIndex + 1); int hn = n / 2;
            bool isEven = n % 2 == 0;
            //从中间开始比较左右两侧
            for (int i = 1; i <= hn; i++)
            {
                int L = hn - i;
                int R = isEven ? hn + i - 1 : hn + i;  //根据奇偶获取右侧比较值的索引
                if (org[startIndex + L] != org[startIndex + R])  // n = 4, hn=2, hn-1 = 1; hn+1-1 = 2; i =0, s[1] == s[2] / i = 1, s[0] == s[3] 
                    return false;

                //set.Add(L << 32 | R);
            }

            //长度大于1，添加到哈希表中
            set.Add(((long)startIndex << 32) | (long)endIndex);

            //Print(s);
            return true;
        }

        /// <summary>
        /// 方法二：中心扩展算法 
        /// 169/176 cases passed (N/A)  0ms
        /// sgdzojcrxtfqcfkhhcuxxnbwtxzkkeunmpdsqfvgfjhusholnwrhmzexhfqppatkexuzdllrbaxygmovqwfvmmbvuuctcwxhrmepxmnxlxdkyzfsqypuroxdczuilbjypnirljxfgpuhhgusflhalorkcvqfknnkqyprxlwmakqszsdqnfovptsgbppvejvukbxaybccxzeqcjhmnexlaafmycwopxntuisxcitxdbarsicvwrvjmxsapmhbbnuivzhkgcrshokkioagwidhmfzjwwywastecjsolxmhfnmgommkoimiwlgwxxdsxhuwwjhpxxgmeuzhdzmuqhmhnfwwokgvwsznfcoxbferdonrexzanpymxtfojodcfydedlxmxeffhwjeegqnagoqlwwdctbqnuxngrgovrjesrkjrfjawknbrsfywljscfvnjhczhyeoyzrtbkvvfvofykkwoiclgxyaddhpdoztdhcbauaagjmfzkkdqexkczfsztckdlujgqzjyuittnudpldjvsbwbzcsazjpxrwfafievenvuetzcxynnmskoytgznvqdlkhaowjtetveahpjguiowkiuvikwewmgxhgfjuzkgrkqhmxxavbriftadtogmhlatczusxkktcsyrnwjbeshifzbykqibghmmvecwwtwdcscikyzyiqlgwzycptlxiwfaigyhrlgtjocvajcnqyenxrnjgogeqtvkxllxpuoxargzgcsfwavwbnktchwjebvwwhfghqkcjhuhuqwcdsixrkfjxuzvhjxlyoxswdlwfytgbtqbeimzzogzrlovcdpseoafuxfmrhdswwictsctawjanvoafvzqanvhaohgndbsxlzuymvfflyswnkvpsvqezekeidadatsymbvgwobdrixisknqpehddjrsntkqpsfxictqbnedjmsveurvrtvpvzbengdijkfcogpcrvwyf";
        /// s = "w
        /// checkResult = "knnk";
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public string LongestPalindrome(string s)
        {
            if (s == null || s.Length< 1)
            {
                return "";
            }
            //当前最大回文的开始和结束索引
            int start = 0, end = 0;
            for (int i = 0; i < s.Length; i++)
            {
                //这里的i代表的是搜索开始的中心索引
                int len1 = expandAroundCenter(s, i, i);     //从索引0开始，直至 n-1
                int len2 = expandAroundCenter(s, i, i + 1); //从索引0开始，直至 n
                int len = Math.Max(len1, len2);
                if (len > end - start)
                {
                    //解释：对于"abaabd"，有 len = 4, i = 2, 
                    //  i代表中心索引，[aba 中的最后一个a索引为2；
                    //  搜索到 baab，长度len=4;
                    //start = (2-(4-1)/2 = 2-1 = 1;
                    //end   = (2+(4-1)/2 = 2+1 = 3;
                    start = i - (len - 1) / 2;         //起初为 (i-len +1) /2  对应中央位置可能为负数？？   
                    end = i + len / 2;                 //起初为 (i+len) /2
                }
            }
            return s.Substring(start, end + 1 - start);
        }

        public int expandAroundCenter(String s, int left, int right)
        {
            while (left >= 0 && right < s.Length && s[left] == s[right])
            {
                --left;
                ++right;
            }
            return right - left - 1;
        }
    }
}
