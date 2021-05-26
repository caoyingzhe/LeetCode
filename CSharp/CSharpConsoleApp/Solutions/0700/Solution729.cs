using System;
using System.Collections.Generic;
namespace CSharpConsoleApp.Solutions
{
    /*
     * @lc app=leetcode.cn id=729 lang=csharp
     *
     * [729] 我的日程安排表 I
     *
     * https://leetcode-cn.com/problems/my-calendar-i/description/
     *
     * Category	Difficulty	Likes	Dislikes
     * algorithms	Medium (50.45%)	77	-
     * Tags
     * array
     * 
     * Companies
     * google
     * 
     * Total Accepted:    6.1K
     * Total Submissions: 12.2K
     * Testcase Example:  '["MyCalendar","book","book","book"]\n[[],[10,20],[15,25],[20,30]]'
     *
     * 实现一个 MyCalendar 类来存放你的日程安排。如果要添加的时间内没有其他安排，则可以存储这个新的日程安排。
     * 
     * MyCalendar 有一个 book(int start, int end)方法。它意味着在 start 到 end
     * 时间内增加一个日程安排，注意，这里的时间是半开区间，即 [start, end), 实数 x 的范围为，  start 。
     * 
     * 当两个日程安排有一些时间上的交叉时（例如两个日程安排都在同一时间内），就会产生重复预订。
     * 
     * 每次调用 MyCalendar.book方法时，如果可以将日程安排成功添加到日历中而不会导致重复预订，返回 true。否则，返回 false
     * 并且不要将该日程安排添加到日历中。
     * 
     * 请按照以下步骤调用 MyCalendar 类: MyCalendar cal = new MyCalendar();
     * MyCalendar.book(start, end)
     * 
     * 示例 1:
     * MyCalendar();
     * MyCalendar.book(10, 20); // returns true
     * MyCalendar.book(15, 25); // returns false
     * MyCalendar.book(20, 30); // returns true
     * 解释: 
     * 第一个日程安排可以添加到日历中.  第二个日程安排不能添加到日历中，因为时间 15 已经被第一个日程安排预定了。
     * 第三个日程安排可以添加到日历中，因为第一个日程安排并不包含时间 20 。
     * 
     * 说明:
     * 每个测试用例，调用 MyCalendar.book 函数最多不超过 1000次。
     * 调用函数 MyCalendar.book(start, end)时， start 和 end 的取值范围为 [0, 10^9]。
     * 
     * 
     */
    public class Solution729 : SolutionBase
    {
        public override bool Test(System.Diagnostics.Stopwatch sw)
        {
            bool isSuccess = true;
            MyCalendar calendar = new MyCalendar();
            calendar.Book(10, 20); // returns true
            calendar.Book(15, 25); // returns false
            calendar.Book(20, 30); // returns true
            //Print("isSuccess = {0} | result = {1} | anticipated = {2}", isSuccess, GetArrayStr<int>(result), GetArrayStr<int>(checkResult));
            //Print("isSuccess = {0} | result = {1} | anticipated = {2}", isSuccess, (result), (checkResult));

            return isSuccess;
        }
    }

    /// <summary>
    /// 108/108 cases passed (380 ms)
    /// Your runtime beats 67.86 % of csharp submissions
    /// Your memory usage beats 82.14 % of csharp submissions(43.8 MB)
    /// </summary>
    public class MyCalendar
    {
        List<int[]> calendar;
        public MyCalendar()
        {
            calendar = new List<int[]>();
        }

        public bool Book(int start, int end)
        {
            for(int i=0; i<calendar.Count; i++)
            {
                int[] iv = calendar[i];
                if (iv[0] < end && start < iv[1])
                    return false;
            }
            calendar.Add(new int[] { start, end });
            return true;
        }
    }
}
