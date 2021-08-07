using System;
namespace CSharpConsoleApp.Solutions
{
    /*
     * @lc app=leetcode.cn id=611 lang=csharp
     *
     * [611] 有效三角形的个数
     *
     * https://leetcode-cn.com/problems/valid-triangle-number/description/
     *
     * Category	Difficulty	Likes	Dislikes
     * algorithms	Medium (48.75%)	280	-
     * Tags
     * array
     * 
     * Companies
     * Unknown
     * Total Accepted:    46.3K
     * Total Submissions: 87.1K
     * Testcase Example:  '[2,2,3,4]'
     *
     * 给定一个包含非负整数的数组，你的任务是统计其中可以组成三角形三条边的三元组个数。
     * 
     * 示例 1:
     * 输入: [2,2,3,4]
     * 输出: 3
     * 解释:
     * 有效的组合是: 
     * 2,3,4 (使用第一个 2)
     * 2,3,4 (使用第二个 2)
     * 2,2,3
     * 
     * 
     * 注意:
     * 数组长度不超过1000。
     * 数组里整数的范围为 [0, 1000]。
     */

    // @lc code=start
    public class Solution611
    {
        public int TriangleNumber(int[] nums)
        {
            int n = nums.Length;
            Array.Sort(nums);
            int ans = 0;
            for (int i = 0; i < n; ++i)
            {
                for (int j = i + 1; j < n; ++j)
                {
                    int L = j + 1, R = n - 1, k = j;
                    while (L <= R)
                    {
                        int mid = (L + R) / 2;
                        if (nums[mid] < nums[i] + nums[j])
                        {
                            k = mid;
                            L = mid + 1;
                        }
                        else
                        {
                            R = mid - 1;
                        }
                    }
                    ans += k - j;
                }
            }
            return ans;
        }
    }
    // @lc code=end


}
