using System;
using System.Collections.Generic;
using System.Linq;
namespace CSharpConsoleApp.Solutions
{
    public class Solution9999 : SolutionBase
    {
        public override bool Test(System.Diagnostics.Stopwatch sw)
        {
            bool isSuccess = true;

            SortedSet<int> sortSet = new SortedSet<int>();
            List<int> List = new List<int>();
            Random rand = new Random();

            for(int i=0; i< 10; i++)
            {
                int randNum = rand.Next() % 100;
                sortSet.Add(randNum);
                List.Add(randNum);
            }

            int noExist = List.Where<int>(a => a > 100).First();
            Print("noexit = " + noExist);
            //sortSet.i
            Print("{0} \n {1} ", GetArrayStr(sortSet.Where<int>(a => a > 0).ToArray()), GetArrayStr(List.ToArray()));
            return isSuccess;
        }
    }
}
