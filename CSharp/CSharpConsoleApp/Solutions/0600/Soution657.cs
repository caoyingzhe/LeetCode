using System;
namespace CSharpConsoleApp.Solutions
{
    public class Soution657
    {
        /// <summary>
        /// 72/72 cases passed (92 ms)
        /// Your runtime beats 70.77 % of csharp submissions
        /// Your memory usage beats 73.85 % of csharp submissions(25.7 MB)
        /// </summary>
        /// <param name="moves"></param>
        /// <returns></returns>
        public bool JudgeCircle(string moves)
        {
            int x = 0, y = 0;
            int n = moves.Length;
            for (int i = 0; i < n; i++)
            {
                switch(moves[i])
                {
                    case  'U':
                        y--; break;
                    case 'D':
                        y++; break;
                    case 'L':
                        x--; break;
                    case 'R':
                        x++; break;
                }
            }
            return x == 0 && y == 0;
        }
    }
}
