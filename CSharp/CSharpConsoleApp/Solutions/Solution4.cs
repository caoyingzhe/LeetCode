using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpConsoleApp.Solutions
{
    /// <summary>
    /// 给定两个大小分别为 m 和 n 的正序（从小到大）数组 nums1 和 nums2。请你找出并返回这两个正序数组的 中位数 。
    /// nums1.Length == m
    /// nums2.Length == n
    /// 0 <= m <= 1000
    /// 0 <= n <= 1000
    /// 1 <= m + n <= 2000
    /// -106 <= nums1[i], nums2[i] <= 106
    /// 
    /// 进阶：你能设计一个时间复杂度为 O(log (m+n)) 的算法解决此问题吗？
    /// </summary>
    /// <Tag> array | binary-search | divide-and-conquer </Tag>
    class Solution4 : SolutionBase
    {
        public override bool Test(System.Diagnostics.Stopwatch sw)
        {
            sw.Restart();

            bool isSucceed = true;
            int[] nums1;
            int[] nums2;
            double result;

            nums1 = new int[] { 1, 3 };
            nums2 = new int[] { 2 };
            result = 2.0;
            isSucceed &= FindMedianSortedArrays(nums1, nums2, result);
            
            nums1 = new int[] { 1, 2 };
            nums2 = new int[] { 3, 4 };
            result = 2.5;
            isSucceed &= FindMedianSortedArrays(nums1, nums2, result);

            nums1 = new int[] { 0, 0 };
            nums2 = new int[] { 0, 0 };
            result = 0.0;
            isSucceed &= FindMedianSortedArrays(nums1, nums2, result);

            nums1 = new int[] { };
            nums2 = new int[] { 1 };
            result = 1.0;
            isSucceed &= FindMedianSortedArrays(nums1, nums2, result);

            nums1 = new int[] { 2 };
            nums2 = new int[] {  };
            result = 2.0;
            isSucceed &= FindMedianSortedArrays(nums1, nums2, result);

            nums1 = new int[] { 2, 4, 8 };
            nums2 = new int[] { 1, 3, 5, 6, 7 };
            result = 4.5;
            isSucceed &= FindMedianSortedArrays(nums1, nums2, result);

            nums1 = new int[] { 2,4,8 };
            nums2 = new int[] { 1,3,5,6,7,9 };
            result = 5.0;
            isSucceed &= FindMedianSortedArrays(nums1, nums2, result);

            if (true)
            {
                int maxLen = 1000; int loop = 1;//
                //int maxLen =    1000000;  int loop = 100;//100次 15513ms vs 14997ms vs 15091ms vs 14977ms
                //int maxLen =    100000;   int loop = 1;//100次 ？ vs ？ vs 7074ms - 6998ms - 7030ms vs 7886ms - 7040ms
                //int maxLen =   10000000;  int loop = 1;//1次   1705ms  vs 1595ms  vs 1619ms
                //int maxLen =  100000000;  int loop = 1;//1次   17339ms vs 16611ms vs 16793ms vs 16622ms  // slow vs Fast vs Fast2 vs Fast3 (only function without Checking result)

                //测试结果，数据超过1亿条，只有不到1秒的优势，原以为会秒杀慢速算法，这个结果是相当意外
                //测试结果，数据100万条，测试100次，也是不到1秒的优势，原以为会秒杀慢速算法，这个结果是相当意外
                //另外一次的数据越小，整体处理时间更短，算法差距越小。
                //在相同处理数量的条件下，多次和一次测试结果，明显多次的处理时间更短。虽然意义不同，可以参考， 

                for (int m=0; m<loop; m ++)
                { 
                    List<int> nums1List = new List<int>();
                    List<int> nums2List = new List<int>();
                    Random rd = new Random();
                    for (int i = 0; i < maxLen; i++)
                    {
                        int random1 = rd.Next(-106, 106);
                        int random2 = rd.Next(-106, 106);

                        nums1List.Add(random1);
                        nums2List.Add(random2);
                    }
                    nums1List.Sort();
                    nums2List.Sort();

                    if(loop < 10000)
                    { 
                        nums1List.AddRange(nums2List.ToArray());
                        nums1List.Sort();
                        result = (double) (nums1List[maxLen] + nums1List[maxLen - 1]) / 2;
                        isSucceed &= FindMedianSortedArrays(nums1List.ToArray(), nums2List.ToArray(), result);
                    }
                    else
                    {
                        FindMedianSortedArrays(nums1List.ToArray(), nums2List.ToArray(), -1);
                    }
                }
            }
            sw.Stop();
            return isSucceed;
        }
        public bool FindMedianSortedArrays(int[] nums1, int[] nums2, double checkResult)
        {
            double result = FindMedianSortedArrays_20210401(nums1, nums2);
            bool isSuccess = (result == checkResult);
            System.Diagnostics.Debug.Print(string.Format("isSuccess = {3} nums1.len = {0} nums2.len ={1} | result = {2} | checkResult = {4}", nums1.Length, nums2.Length, result, isSuccess, checkResult));
            return isSuccess;
        }

        /// <summary>
        /// 解法：二分法
        /// 难点：限制了时间复杂度为 O(log (m+n))， 不能合并数组，否则不达标
        ///     归并的方法简单易懂，时间复杂度与空间复杂度均为线性复杂度O(m+n)
        ///     
        /// 分析1：m+n 的奇偶不确定，因此需要分情况来讨论，
        ///     对于奇数的情况，直接找到最中间的数即可，
        ///     偶数的话需要求最中间两个数的平均值。
        ///     
        /// 分析2：选择短的那个数组作为查找数组，能够使时间复杂度变为O(log(min(m,n)))
        /// 
        /// 
        /// Time Limit Exceeded : O(log (m+n))
        /// </summary>
        /// <param name="nums1"></param>
        /// <param name="nums2"></param>
        /// <returns></returns>
        /// 
        public double FindMedianSortedArrays_Common(int[] nums1, int[] nums2)
        {
            int l1 = nums1.Length;
            int l2 = nums2.Length;
            int mid = (l1 + l2) / 2;

            int[] s = new int[mid + 1];
            int j = 0, k = 0;
            for (int i = 0; i < mid + 1; i++)
            {
                if (j < l1 && (k == l2 || nums1[j] < nums2[k])) //左侧没到尽头 +（右侧到尽头了 | 左侧比右侧小）
                {
                    s[i] = nums1[j++];
                }
                else //其他情况（右边大）
                {
                    s[i] = nums2[k++];
                }
            }
            double result;
            if ((l1 + l2) % 2 != 0)
            {
                result = (double)s[mid];
            }
            else
            {
                result = (double)(s[mid - 1] + s[mid]) / 2.0;
            }
            //System.Diagnostics.Debug.Print(string.Join(",", s) + " | result = " + result);
            return result;
        }

        /// https://github.com/grandyang/leetcode/issues/4 java解法1
        public double FindMedianSortedArrays_Fast2(int[] nums1, int[] nums2)
        {
            int m = nums1.Length, n = nums2.Length, left = (m + n + 1) / 2, right = (m + n + 2) / 2;
            return (findKth(nums1, 0, nums2, 0, left) + findKth(nums1, 0, nums2, 0, right)) / 2.0;
        }
        int findKth(int[] nums1, int i, int[] nums2, int j, int k)
        {
            if (i >= nums1.Length) return nums2[j + k - 1];
            if (j >= nums2.Length) return nums1[i + k - 1];
            if (k == 1) return Math.Min(nums1[i], nums2[j]);
            int midVal1 = (i + k / 2 - 1 < nums1.Length) ? nums1[i + k / 2 - 1] : int.MaxValue;
            int midVal2 = (j + k / 2 - 1 < nums2.Length) ? nums2[j + k / 2 - 1] : int.MaxValue;
            if (midVal1 < midVal2)
            {
                return findKth(nums1, i + k / 2, nums2, j, k - k / 2);
            }
            else
            {
                return findKth(nums1, i, nums2, j + k / 2, k - k / 2);
            }
        }

        public double FindMedianSortedArrays_Fast(int[] nums1, int[] nums2)
        {
            double result = 0;

            int length = nums1.Length + nums2.Length;
            //选择长度较小的那个数组进行查找
            if (nums1.Length > nums2.Length) return FindMedianSortedArrays_Fast(nums2, nums1);
            if (nums1.Length == 0)
            {
                if (nums2.Length % 2 != 0) return nums2[length / 2];
                else return (nums2[length / 2 - 1] + nums2[length / 2]) / 2.0;
            }
            ////初始化二分查找的边界
            int L_edge = 0, R_edge = nums1.Length;
            int cur1 = 0, cur2 = 0;
            while (L_edge <= R_edge)
            {
                cur1 = L_edge + (R_edge - L_edge) / 2;
                cur2 = (length + 1) / 2 - cur1;
                //计算出L1，R1，L2，R2
                double L1 = cur1 == 0 ? int.MinValue : nums1[cur1 - 1];
                double R1 = cur1 == nums1.Length ? int.MaxValue : nums1[cur1];
                double L2 = cur2 == 0 ? int.MinValue : nums2[cur2 - 1];
                double R2 = cur2 == nums2.Length ? int.MaxValue: nums2[cur2];
                //二分查找，重新划定边界
                if (L1 > R2) R_edge = cur1 - 1;
                else if (L2 > R1) L_edge = cur1 + 1;
                else
                {
                    //注意长度为奇数偶数的问题，奇数取中间的那个值，偶数则取两边的和的一半
                    if (length % 2 != 0) result = Math.Max(L1, L2);
                    else result = (Math.Max(L1, L2) + Math.Min(R1, R2)) / 2.0;
                    break;
                }
            }

            return result;
        }

        public double FindMedianSortedArrays_Fast3(int[] nums1, int[] nums2)
        {
            //假定m为长数组的长度
            int m = nums1.Length, n = nums2.Length;
            if (m < n) return FindMedianSortedArrays_Fast3(nums2, nums1); //这个写法省去了繁琐的交换处理。
            if (n == 0) return (nums1[(m - 1) / 2] + nums1[m / 2]) / 2.0; //特殊情况，有一个数组长度为0

            //这里已经确定m为长数组的长度
            int left = 0, right = 2 * n;
            while (left <= right)
            {
                int mid2 = (left + right) / 2; //中位数索引最初为n，不停循环之后一直增加向右。
                int mid1 = m + n - mid2;       //中位数索引偏差，不停循环之后一直减小向左

                //L1代表 nums1的左边，R1代表 nums1的右边；
                //L2代表 nums2的左边，R2代表 nums2的右边；
                double L1 = mid1 == 0 ? Double.MinValue : nums1[(mid1 - 1) / 2];
                double L2 = mid2 == 0 ? Double.MinValue : nums2[(mid2 - 1) / 2];
                double R1 = mid1 == m * 2 ? Double.MaxValue : nums1[mid1 / 2];
                double R2 = mid2 == n * 2 ? Double.MaxValue : nums2[mid2 / 2];
                if (L1 > R2) left = mid2 + 1;
                else if (L2 > R1) right = mid2 - 1;
                else return (Math.Max(L1, L2) + Math.Min(R1, R2)) / 2;
            }
            return -1;
        }

        /// 解法：二分法
        /// 难点：限制了时间复杂度为 O(log (m+n))， 不能合并数组，否则不达标
        ///     归并的方法简单易懂，时间复杂度与空间复杂度均为线性复杂度O(m+n)
        ///     
        /// 分析1：m+n 的奇偶不确定，因此需要分情况来讨论，
        ///     对于奇数的情况，直接找到最中间的数即可，
        ///     偶数的话需要求最中间两个数的平均值。
        ///     
        /// 分析2：选择短的那个数组作为查找数组，能够使时间复杂度变为O(log(min(m,n)))
        /// 
        /// 
        /// Time Limit Exceeded : O(log (m+n))
        public double FindMedianSortedArrays_20210401X(int[] nums1, int[] nums2)
        {
            double result = -1;

            //假定m为长数组的长度
            int m = nums1.Length, n = nums2.Length;
            if (m < n) return FindMedianSortedArrays_20210401X(nums2, nums1); //这个写法省去了繁琐的交换处理。
            if (n == 0) return (nums1[(m - 1) / 2] + nums1[m / 2]) / 2.0; //特殊情况，有一个数组长度为0

            //这里已经确定m为长数组的长度
            int left = 0;
            int right = 2 * n; //短数组长度2倍

            int mid2, mid1;
            double L1, L2, R1, R2;
            while (left <= right)
            {
                mid2 = (left + right) / 2;
                mid1 = (m + n) - mid2;

                L1 = (mid1 == 0) ? int.MinValue : nums1[(mid1 - 1) / 2];
                L2 = (mid2 == 0) ? int.MinValue : nums2[(mid2 - 1) / 2];
                R1 = (mid1 == m * 2) ? int.MaxValue : nums1[(mid1) / 2];
                R2 = (mid2 == n * 2) ? int.MaxValue : nums2[(mid2) / 2];
                if (L1 > R2) left = mid2 + 1;
                else if (R1 < L2) right = mid2 - 1;
                else
                {
                    result = (Math.Max(L1, L2) + Math.Min(R1, R2)) / 2;
                    System.Diagnostics.Debug.Print(string.Format("nums1.len = {0} nums2.len ={1} | result = {2}", m, n, result));
                    break;
                }
            }
            return result;
        }

        public double FindMedianSortedArrays_20210401(int[] nums1, int[] nums2)
        {
            double result = -1;
            //假定m为长数组的长度
            int m = nums1.Length, n = nums2.Length;
            if (m < n) return FindMedianSortedArrays_20210401(nums2, nums1); //这个写法省去了繁琐的交换处理。
            if (n == 0) return (nums1[(m - 1) / 2] + nums1[m / 2]) / 2.0; //特殊情况，有一个数组长度为0

            //这里已经确定m为长数组的长度
            int left = 0;
            int right = 2 * n; //短数组长度2倍

            int mid2, mid1;
            double L1, L2, R1, R2;
            while (left <= right)
            {
                mid2 = (left + right) / 2;
                mid1 = (m + n) - mid2;

                L1 = (mid1 == 0) ? int.MinValue : nums1[(mid1 - 1) / 2];
                L2 = (mid2 == 0) ? int.MinValue : nums2[(mid2 - 1) / 2];
                R1 = (mid1 == m * 2) ? int.MaxValue : nums1[(mid1) / 2];
                R2 = (mid2 == n * 2) ? int.MaxValue : nums2[(mid2) / 2];
                if (L1 > R2) left = mid2 + 1;
                else if (R1 < L2) right = mid2 - 1;
                else
                {
                    result = (Math.Max(L1, L2) + Math.Min(R1, R2)) / 2;
                    break;
                }
            }
            return result;
        }
        /// <summary>
        /// 温故知新 20210403
        /// </summary>
        /// <param name="nums1"></param>
        /// <param name="nums2"></param>
        /// <returns></returns>
        public double FindMedianSortedArrays_20210403(int[] nums1, int[] nums2)
        {
            //假定m为长数组的长度
            int m = nums1.Length;
            int n = nums2.Length;
            if (m < n) return FindMedianSortedArrays_20210403(nums2, nums1);
            //纯粹马虎问题
            //错误： return (nums1[(m - 1) / 2] + nums2[(m) / 2]) / 2.0;
            //正确： return (nums1[(m - 1) / 2] + nums1[(m) / 2]) / 2.0;
            if (n == 0) return (nums1[(m - 1) / 2] + nums1[(m) / 2]) / 2.0;

            int left = 0;
            int right = 2 * n;
            int mid2, mid1;
            double L1, L2, R1, R2;
            while (left <= right)
            {
                mid2 = (left + right) / 2; //L2,R2中位数索引
                mid1 = m + n - mid2;     //L1,R1中位数索引

                //L1,L2,R1,R2为值对象，为了
                //这里用int.MaxValue和double.MaxValue没有区别。
                L1 = (mid1 == 0) ? int.MinValue : nums1[(mid1 - 1) / 2];
                L2 = (mid2 == 0) ? int.MinValue : nums2[(mid2 - 1) / 2];

                //重点：判断基准为
                //     错误写法1:  mid1 >= m
                //     错误写法2:  mid1 >= m * 2
                //     正确写法 ： mid1 == m * 2
                R1 = (mid1 == m * 2) ? int.MaxValue : nums1[(mid1) / 2];
                //重点：判断基准为 
                //     错误写法1:  mid2 >= n
                //     错误写法2:  mid2 >= n * 2
                //     正确写法 ： mid2 == n * 2
                R2 = (mid2 == n * 2) ? int.MaxValue : nums2[(mid2) / 2];
                //重点：索引更改计算基准为mid2
                if (L1 > R2) left = mid2 + 1;

                //犯错1： if (L2 > R2)  不应该比较L2和R2,而是R1.
                //犯错1： if (L2 < R2)  不应该用 <
                //正确 ： if (L2 > R1)  
                else if (L2 > R1) right = mid2 - 1;
                //纯粹马虎问题
                //错误： else return (Math.Max(L1, L2) + Math.Min(R1, R2) / 2);
                //正确： else return (Math.Max(L1, L2) + Math.Min(R1, R2)) / 2;
                else return (Math.Max(L1, L2) + Math.Min(R1, R2)) / 2;
            }
            return -1;
        }
    }
}
