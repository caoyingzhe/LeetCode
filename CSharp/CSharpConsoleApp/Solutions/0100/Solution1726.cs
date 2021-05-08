using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CSharpConsoleApp.Solutions
{
    public class Solution1726 : SolutionBase
    {
        public override bool Test(System.Diagnostics.Stopwatch sw)
        {
            //int[] nums = { 2, 3, 4, 6 }; //reuslt = 8;
            //int[] nums = { 1, 2, 4, 5, 10 }; //reuslt = 16;
            int[] nums = { 2, 3, 4, 6, 8, 12 }; //reuslt = 40;
            //int[] nums = { 2, 3, 5, 7 }; //reuslt = 0;
            int result = TupleSameProduct(nums);
            System.Diagnostics.Debug.Print("Result = " + result);
            return true;
        }

        /// <summary>
        /// 给你一个由 不同 正整数组成的数组 nums ，请你返回满足 a * b = c * d 的元组 (a, b, c, d) 的数量。其中 a、b、c 和 d 都是 nums 中的元素，且 a != b != c != d 。
        /// 解法：其实很无聊，只是公式题目， 计算特殊逻辑的排列组合。 关键参数 4, 代表意义：每组正反两种排序 * 两组交换正反的排序 = 2 * 2;
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int TupleSameProduct(int[] nums)
        {
            //Dictionary<int, List<int[]>> dict_mult = new Dictionary<int, List<int[]>>(); //用于保留结果
            Dictionary<int, int> dict_mult = new Dictionary<int, int>(); //只用于计数
            int len = nums.Length;
            for (int i = 0; i < len; i++)
            {
                for (int j = i + 1; j < len; j++)
                {
                    int mul = nums[i] * nums[j];

                    //List<int[]> list = null;
                    //int[] infos = new int[] { i, j, nums[i], nums[j] };//用于保留结果
                    if (!dict_mult.ContainsKey(mul))
                    {
                        //list = new List<int[]>();
                        //list.Add(infos);//用于保留结果
                        //dict_mult[mul] = list;//用于保留结果
                        dict_mult[mul] = 1;
                    }
                    else
                    {
                        //dict_mult[mul].Add(infos);//用于保留结果
                        dict_mult[mul] = dict_mult[mul] + 1;
                    }
                }
            }
            int result = 0;

            //int tmpListCount;
            //int tmpCount = 1;
            //foreach (List<int[]> list in dict_mult.Values)//用于保留结果
            foreach (int tmpListCount in dict_mult.Values)//用于保留结果
            {
                //tmpListCount = list.Count;//用于保留结果
                if (tmpListCount > 1)
                {
                    result += tmpListCount * (tmpListCount - 1) * 4;
                }
            }
            return result;
        }
    }
}
