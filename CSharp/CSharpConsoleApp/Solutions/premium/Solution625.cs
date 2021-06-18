using System;
namespace CSharpConsoleApp.Solutions.premium
{
    //Minimum Factorization 最小因数分解
    /**
    * Given a positive integer a, find the smallest positive integer b whose multiplication of each digit equals to a.
    * 
    * If there is no answer or the answer is not fit in 32-bit signed integer, then return 0.
    * 
    * Example 1
    * Input:
    * 48 
    * Output:
    * 68
    * 
    * 
    * Example 2
    * Input:
    * 15
    * Output:
    * 35
    */

    //TODO
    public class Solution625
    {
        public int SmallestFactorization(int a)
        {
            if (a == 1) return 1;
            string res = "";
            for (int k = 9; k >= 2; --k)
            {
                while (a % k == 0)
                {
                    res = k.ToString() + res;
                    a /= k;
                }
            }
            if (a > 1) return 0;
            long num = long.Parse(res);
            return num > long.MaxValue ? 0 : (int) num;
        }
    }
}
