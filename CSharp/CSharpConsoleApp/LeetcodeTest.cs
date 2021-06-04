using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

using CSharpConsoleApp.Solutions;

namespace CSharpConsoleApp
{
    /// <summary>
    /// KeyWord
    ///     WPF： Windows Presentation Foundation 
    /// </summary>
    class LeetcodeTest
    {
        static void Main(string[] args)
        {
            var types = Assembly.GetExecutingAssembly().GetTypes().Where((t) => t.BaseType == typeof(SolutionBase)).OrderBy(t => t.Name).ToArray();

            int solutionSucceedCount = 0;

            var sw = new System.Diagnostics.Stopwatch();

            for (int i = 0; i < types.Length; i++)
            {
                Type type = types[i];
                int problemNo = SolutionBase.GetProblemNo(type);
                if (problemNo != 59)
                    continue;

                System.Diagnostics.Debug.Print(string.Format("\n-------- Test Problem [{0}] {1} --------", problemNo, type.Name));
                SolutionBase solution = Activator.CreateInstance(type) as SolutionBase;

                bool isSucceed = solution.Test(sw);
                
                TimeSpan ts = sw.Elapsed;

                if (isSucceed)
                {
                    solutionSucceedCount += 1;
                }
                System.Diagnostics.Debug.Print(string.Format(">>>>>> Test Result : {0} used time = {1} <<<<<<\n", isSucceed, ($"　{sw.ElapsedMilliseconds}ms")));
            }
            System.Diagnostics.Debug.Print(string.Format("-------->>>>>> All Test Results : {0} | Success statics : {1} / {2} <<<<<<--------", solutionSucceedCount == types.Length, solutionSucceedCount, types.Length));
        }
    }
}
