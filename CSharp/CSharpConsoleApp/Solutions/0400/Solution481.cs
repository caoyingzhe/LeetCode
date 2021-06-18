using System;
namespace CSharpConsoleApp.Solutions
{
    /*
    * @lc app=leetcode.cn id=481 lang=csharp
    *
    * [481] 神奇字符串
    *
    * https://leetcode-cn.com/problems/magical-string/description/
    *
    * algorithms
    * Medium (52.76%)
    * Likes:    50
    * Dislikes: 0
    * Total Accepted:    4.8K
    * Total Submissions: 9.2K
    * Testcase Example:  '6'
    *
    * 神奇的字符串 S 只包含 '1' 和 '2'，并遵守以下规则：
    * 字符串 S 是神奇的，因为串联字符 '1' 和 '2' 的连续出现次数会生成字符串 S 本身。
    * 字符串 S 的前几个元素如下：S = “1221121221221121122 ......”
    * 如果我们将 S 中连续的 1 和 2 进行分组，它将变成：
    * 
    * 1 22 11 2 1 22 1 22 11 2 11 22 ......
    * 并且每个组中 '1' 或 '2' 的出现次数分别是：
    * 1 2 2 1 1 2 1 2 2 1 2 2 ......
    * 
    * 你可以看到上面的出现次数就是 S 本身。
    * 给定一个整数 N 作为输入，返回神奇字符串 S 中前 N 个数字中的 '1' 的数目。
    * 注意：N 不会超过 100,000。
    * 
    * 示例：
    * 输入：6
    * 输出：3
    * 解释：神奇字符串 S 的前 6 个元素是 “12211”，它包含三个 1，因此返回 3。
    * 
    */
    public class Solution481
    {
        //作者：wu-ming-130
        //链接：https://leetcode-cn.com/problems/magical-string/solution/shi-jian-ji-bai-100nei-cun-ji-bai-9787-by-wu-ming-/
        //64/64 cases passed (52 ms)
        //Your runtime beats 33.33 % of csharp submissions
        //Your memory usage beats 33.33 % of csharp submissions (31.6 MB)
        public int MagicalString_1(int n)
        {
            {
                int fast = 2;
                int ans = 1;
                if (n == 0) return 0;
                if (n <= 3) return 1;

                int[] s = new int[200002];
                s[0] = 1;
                s[1] = s[2] = 2;
                for (int i = 2; i < n; i++)
                {
                    if (s[i] == 2)
                    {
                        if (s[fast] == 2)
                        {
                            s[++fast] = 1;
                            s[++fast] = 1;
                        }
                        else
                        {
                            s[++fast] = 2;
                            s[++fast] = 2;
                        }
                    }
                    else
                    {
                        ans++;
                        if (s[fast] == 1)
                        {
                            s[++fast] = 2;
                        }
                        else
                        {
                            s[++fast] = 1;
                        }
                    }
                }
                return ans;
            }
        }

        //64/64 cases passed (40 ms)
        //Your runtime beats 100 % of csharp submissions
        //Your memory usage beats 33.33 % of csharp submissions(16.3 MB)
        //作者：william134
        //链接：https://leetcode-cn.com/problems/magical-string/solution/an-zhao-gui-ze-cong-qian-wang-hou-bian-sheng-cheng/
        public int MagicalString(int n)
        {
            if (n == 0)
                return 0;
            if (n <= 3)
                return 1;
            int[] nums = new int[n + 1];
            int index = 2, end = 3, count = 1;
            nums[0] = 1;
            nums[1] = 2;
            nums[2] = 2;
            while (end < n)
            {
                //temp表示即将添加到字符串尾部的数字
                int temp = 3 - nums[end - 1];
                //index指针用于指导end指针生成字符串
                //nums[index]==2表示需要在字符串尾部添加两个temp，反之添加一个temp
                if (nums[index] == 2)
                {
                    nums[end] = temp;
                    nums[end + 1] = temp;
                    //累加1出现的次数
                    if (temp == 1)
                    {
                        if (end + 1 < n)
                            count += 2;
                        else
                            count++;
                    }
                    end += 2;
                }
                else
                {
                    nums[end] = temp;
                    //累加1出现的次数
                    if (temp == 1)
                        count++;
                    end++;
                }
                index++;
            }
            return count;

            
        }
    }
}