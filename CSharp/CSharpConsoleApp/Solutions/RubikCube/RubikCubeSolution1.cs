using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO;
*/
namespace CSharpConsoleApp.Solutions.RubikCube
{
    class RubikCubeSolution1 : CSharpConsoleApp.Solutions.SolutionBase
    {
        public override bool Test(System.Diagnostics.Stopwatch sw)
        {
            List<int> result = new List<int>();
            int[] checkResult = null;
            bool isSuccess = true;

            Print("isSuccess = {0} | result= {1} | resultChecked = {2}", isSuccess, string.Join(",", result), string.Join(",", checkResult));

            isSuccess &= IsArraySame(checkResult, result.ToArray());

            return isSuccess;
        }
    }
}
