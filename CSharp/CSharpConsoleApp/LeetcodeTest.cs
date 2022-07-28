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
        public static bool onlyTestSpecific = false; //change [onlyTestSpecific] into true to test specific solutions.
        public static List<int> specificSolutionNoList = new List<int>(new int[] { 111, 679 }); //Add specific solution No list here.

        static void Main(string[] args)
        {
            var types = Assembly.GetExecutingAssembly().GetTypes().Where((t) => t.BaseType == typeof(SolutionBase)).OrderBy(t => t.Name).ToArray();

            int solutionSucceedCount = 0;

            var sw = new System.Diagnostics.Stopwatch();

            for (int i = 0; i < types.Length; i++)
            {
                Type type = types[i];
                int problemNo = SolutionBase.GetProblemNo(type);

                if (onlyTestSpecific && !specificSolutionNoList.Contains(problemNo))
                {
                    continue;
                }

                System.Diagnostics.Debug.Print(string.Format("\n-------- Test Problem [{0}] {1} --------", problemNo, type.Name));
                SolutionBase solution = Activator.CreateInstance(type) as SolutionBase;

                bool isSucceed = false;
                try
                {
                    isSucceed = solution.Test(sw);
                    TimeSpan ts = sw.Elapsed;

                    if (isSucceed)
                    {
                        solutionSucceedCount += 1;
                    }
                }
                catch(Exception ex)
                {
                    System.Diagnostics.Debug.Print(ex.StackTrace);
                }
                System.Diagnostics.Debug.Print(string.Format(">>>>>> Test Result : {0} used time = {1} <<<<<<\n", isSucceed, ($"　{sw.ElapsedMilliseconds}ms")));
            }
            if(!onlyTestSpecific)
                System.Diagnostics.Debug.Print(string.Format("-------->>>>>> All Test Results : {0} | Success statics : {1} / {2} <<<<<<--------", solutionSucceedCount == types.Length, solutionSucceedCount, types.Length));
            else
                System.Diagnostics.Debug.Print(string.Format("-------->>>>>> Specific Test Results : {0} | Success statics : {1} / {2} <<<<<<--------", solutionSucceedCount == specificSolutionNoList.Count, solutionSucceedCount, specificSolutionNoList.Count));

        }
    }
}
