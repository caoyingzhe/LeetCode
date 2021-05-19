using System;
using System.Collections.Generic;
namespace CSharpConsoleApp.Solutions
{
    /*
     * @lc app=leetcode.cn id=49 lang=csharp
     *
     * [49] 字母异位词分组
     *
     * https://leetcode-cn.com/problems/group-anagrams/description/
     *
     * Category	Difficulty	Likes	Dislikes
     * algorithms	Medium (65.79%)	735	-
     * Tags
     * hash-table | string
     * 
     * Companies
     * amazon | bloomberg | facebook | uber | yelp
     * 
     * Total Accepted:    190.4K
     * Total Submissions: 289.4K
     * Testcase Example:  '["eat","tea","tan","ate","nat","bat"]'
     *
     * 给定一个字符串数组，将字母异位词组合在一起。字母异位词指字母相同，但排列不同的字符串。
     * 
     * 示例:
     * 
     * 输入: ["eat", "tea", "tan", "ate", "nat", "bat"]
     * 输出:
     * [
     * ⁠ ["ate","eat","tea"],
     * ⁠ ["nat","tan"],
     * ⁠ ["bat"]
     * ]
     * 
     * 说明：
     * 所有输入均为小写字母。
     * 不考虑答案输出的顺序。
     * 
     * 
     */

    public class Solution49 : SolutionBase
    {
        public override bool Test(System.Diagnostics.Stopwatch sw)
        {
            var result = GroupAnagrams(new string[] { "eat", "tea", "tan", "ate", "nat", "bat" });

            Print(GetArray2DStr(result));
            return true;
        }

        /// <summary>
        /// 114/114 cases passed (340 ms)
        /// Your runtime beats 82.42 % of csharp submissions
        /// Your memory usage beats 68.48 % of csharp submissions(38.3 MB)
        /// </summary>
        /// <param name="strs"></param>
        /// <returns></returns>
        public IList<IList<string>> GroupAnagrams(string[] strs)
        {
            List<IList<string>> result = new List<IList<string>>();
            Dictionary<string,int> set = new Dictionary<string, int>();

            int listCount = 0;
            for(int i=0; i<strs.Length; i++)
            {
                if (strs[i] == null)
                    continue; 

                char[] chars = strs[i].ToCharArray();
                Array.Sort(chars);
                string key = string.Join("", chars);

                IList<string> list = null;
                if (!set.ContainsKey(key))
                {
                    list = new List<string>();
                    result.Add(list);
                    set.Add(key, listCount);

                    listCount++;
                }
                else
                {
                    list = result[set[key]];
                }
                list.Add(strs[i]);
            }

            return result;
        }
        
        bool[] vis; //保存数字的数组

        /// <summary>
        /// 生成所有字母组合的单词列表
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public IList<string> GetPermuteUnique(string key)
        {
            int n = key.Length;
            vis = new bool[key.Length];
            for (int i = 0; i < key.Length; i++) vis[i] = false;
            List<string> ans = new List<string>();

            List<char> perm = new List<char>();
            //Array.Sort(nums); //确定key已经排过序

            Backtrack(key, ans, 0, perm);
            return ans;
        }

        public void Backtrack(string nums, List<string> ans, int idx, List<char> perm)
        {
            if (idx == nums.Length)
            {
                ans.Add(string.Join("",perm));
                return;
            }
            for (int i = 0; i < nums.Length; ++i)
            {
                if (vis[i] || (i > 0 && nums[i] == nums[i - 1] && !vis[i - 1]))
                {
                    continue;
                }
                perm.Add(nums[i]);
                vis[i] = true;
                Backtrack(nums, ans, idx + 1, perm);
                vis[i] = false;
                perm.RemoveAt(idx);
            }
        }
    }
}
