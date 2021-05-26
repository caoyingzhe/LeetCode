using System;
using System.Collections.Generic;
namespace CSharpConsoleApp.Solutions
{
    public class Solution541 : SolutionBase
    {
        public override bool Test(System.Diagnostics.Stopwatch sw)
        {
            string result = ReverseStr("abcdefg", 2);
            Print(result);

            result = ReverseStr("abcxyzqwemnbe", 3);
            Print(result);
            result = ReverseStr("abcxyzqwemnbzyxpe", 3);
            Print(result);
            return true;
        }

        /// <summary>
        /// 60/60 cases passed (104 ms)
        /// Your runtime beats 75 % of csharp submissions
        /// Your memory usage beats 22.92 % of csharp submissions(26.5 MB)
        /// </summary>
        /// <param name="s"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public string ReverseStr(string s, int k)
        {
            List<char> list = new List<char>(s.ToCharArray());

            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            int count = s.Length / (2 * k);
            int mod = s.Length % (2 * k);
            for (int i=0; i< count; i++)
            {
                List<char> L = list.GetRange(i * 2 * k, k);
                List<char> R = list.GetRange(i * 2 * k + k, k);
                L.Reverse();
                sb.Append(L.ToArray()).Append(R.ToArray());
            }
            
            if (mod != 0)
            {
                int last = count * 2 * k;
                if (mod <= k)
                {
                    List<char> L = list.GetRange(last, mod);
                    L.Reverse();
                    sb.Append(L.ToArray());
                }
                else
                {
                    List<char> L = list.GetRange(last, k);
                    List<char> R = list.GetRange(last + k, mod -k);
                    L.Reverse();
                    sb.Append(L.ToArray()).Append(R.ToArray());
                } 
            }
            return sb.ToString();
        }
    }
}
