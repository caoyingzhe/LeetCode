using System;
using System.Collections.Generic;
namespace CSharpConsoleApp.Solutions
{
    /*
     * @lc app=leetcode.cn id=355 lang=csharp
     *
     * [355] 设计推特
     *
     * https://leetcode-cn.com/problems/design-twitter/description/
     *
     * algorithms
     * Medium (40.74%)
     * Likes:    224
     * Dislikes: 0
     * Total Accepted:    22.9K
     * Total Submissions: 56.1K
     * Testcase Example:  '["Twitter","postTweet","getNewsFeed","follow","postTweet","getNewsFeed","unfollow","getNewsFeed"]\n' +
      '[[],[1,5],[1],[1,2],[2,6],[1],[1,2],[1]]'
     *
     * 
     * 设计一个简化版的推特(Twitter)，可以让用户实现发送推文，关注/取消关注其他用户，能够看见关注人（包括自己）的最近十条推文。你的设计需要支持以下的几个功能：
     * 
     * 
     * postTweet(userId, tweetId): 创建一条新的推文
     * getNewsFeed(userId):
     * 检索最近的十条推文。每个推文都必须是由此用户关注的人或者是用户自己发出的。推文必须按照时间顺序由最近的开始排序。
     * follow(followerId, followeeId): 关注一个用户
     * unfollow(followerId, followeeId): 取消关注一个用户
     * 
     * 
     * 示例:
     * 
     * 
     * Twitter twitter = new Twitter();
     * 
     * // 用户1发送了一条新推文 (用户id = 1, 推文id = 5).
     * twitter.postTweet(1, 5);
     * 
     * // 用户1的获取推文应当返回一个列表，其中包含一个id为5的推文.
     * twitter.getNewsFeed(1);
     * 
     * // 用户1关注了用户2.
     * twitter.follow(1, 2);
     * 
     * // 用户2发送了一个新推文 (推文id = 6).
     * twitter.postTweet(2, 6);
     * 
     * // 用户1的获取推文应当返回一个列表，其中包含两个推文，id分别为 -> [6, 5].
     * // 推文id6应当在推文id5之前，因为它是在5之后发送的.
     * twitter.getNewsFeed(1);
     * 
     * // 用户1取消关注了用户2.
     * twitter.unfollow(1, 2);
     * 
     * // 用户1的获取推文应当返回一个列表，其中包含一个id为5的推文.
     * // 因为用户1已经不再关注用户2.
     * twitter.getNewsFeed(1);
     * 
     * 
     */

    public class Solution355 : SolutionBase
    {
        /// <summary>
        /// 难度
        /// </summary>
        public override Difficulity GetDifficulity() { return Difficulity.Medium; }
        /// <summary>
        /// 关键字:
        /// </summary>
        public override string[] GetKeyWords() { return new string[] { "设计推特",}; }
        /// <summary>
        /// 标签：
        /// </summary>
        public override Tag[] GetTags() { return new Tag[] { Tag.Design, Tag.HashTable, Tag.Heap }; }

        public override bool Test(System.Diagnostics.Stopwatch sw)
        {
            bool isSuccess = true;

            Twitter twitter = new Twitter();

            //// 用户1发送了一条新推文 (用户id = 1, 推文id = 5).
            //twitter.PostTweet(1, 5);

            //// 用户1的获取推文应当返回一个列表，其中包含一个id为5的推文.
            //Print(GetArrayStr(twitter.GetNewsFeed(1)));

            //// 用户1关注了用户2.
            //twitter.Follow(1, 2);

            //// 用户2发送了一个新推文 (推文id = 6).
            //twitter.PostTweet(2, 6);

            //// 用户1的获取推文应当返回一个列表，其中包含两个推文，id分别为 -> [6, 5].
            //// 推文id6应当在推文id5之前，因为它是在5之后发送的.
            //Print(GetArrayStr(twitter.GetNewsFeed(1)));

            //// 用户1取消关注了用户2.
            //twitter.Unfollow(1, 2);

            //// 用户1的获取推文应当返回一个列表，其中包含一个id为5的推文.
            //// 因为用户1已经不再关注用户2.
            //Print(GetArrayStr(twitter.GetNewsFeed(1)));


            // 用户1关注了用户2.
            twitter.Follow(1, 5);

            Print(GetArrayStr(twitter.GetNewsFeed(1)));

            return isSuccess;
        }

        #region
        //推文类，是一个单链表（结点视角）
        //包含上一次推特的推送的引用，数据结构为单向链表
        public class Tweet
        {
            //推文 id
            public int id;
            //发推文的时间戳
            public int timestamp;

            //保存上一次推特的推送，数据结构为单向链表
            public Tweet next;

            public Tweet(int id, int timestamp)
            {
                this.id = id;
                this.timestamp = timestamp;
            }
        }
        public class ComparerSolution355 : IComparer<Tweet>
        {
            public int Compare(Tweet pair1, Tweet pair2)
            {
                if (pair1 == null && pair2 == null) return 0;
                if (pair1 == null) return -1;
                if (pair2 == null) return -1;
                return pair1.timestamp - pair2.timestamp;
            }
        }

        // @lc code=start
        /// <summary>
        /// 哈希表 + 链表 + 优先队列（经典多路归并问题）（Java）
        /// https://leetcode-cn.com/problems/design-twitter/solution/ha-xi-biao-lian-biao-you-xian-dui-lie-java-by-liwe/
        /// 16/16 cases passed (296 ms)
        /// Your runtime beats 88.89 % of csharp submissions
        /// Your memory usage beats 44.44 % of csharp submissions(30.7 MB)
        /// </summary>
        public class Twitter 
        {
            Dictionary<int, HashSet<int>> followings;

            //用户 id 和推文（单链表）的对应关系
            Dictionary<int, Tweet> twitter;

            //全局使用的时间戳字段，用户每发布一条推文之前 + 1
            private static int timestamp = 0;

            //合并 k 组推文使用的数据结构（可以在方法里创建使用），声明成全局变量非必需，视个人情况使用
            private static PriorityQueue<Tweet> maxHeap;

            /** Initialize your data structure here. */
            public Twitter()
            {
                followings = new Dictionary<int, HashSet<int>>();
                twitter = new Dictionary<int, Tweet>();
                maxHeap = new PriorityQueue<Tweet>(new ComparerSolution355());
                //PriorityQueue<int[]> pq = new PriorityQueue<int[]> (new ComparerSolution407());
            }

            /** Compose a new tweet. */
            public void PostTweet(int userId, int tweetId)
            {
                timestamp++;
                if (twitter.ContainsKey(userId))
                {
                    Tweet oldHead = twitter[userId];
                    Tweet newHead = new Tweet(tweetId, timestamp);
                    //更新推送的链表数据
                    newHead.next = oldHead;
                    twitter[userId] = newHead;
                }
                else
                {
                    twitter[userId] = new Tweet(tweetId, timestamp);
                }
            }

            /** Retrieve the 10 most recent tweet ids in the user's news feed. Each item in the news feed must be posted by users who the user followed or by the user herself. Tweets must be ordered from most recent to least recent. */
            public IList<int> GetNewsFeed(int userId)
            {
                // 由于是全局使用的，使用之前需要清空
                //maxHeap.Clear();
                maxHeap = new PriorityQueue<Tweet>(new ComparerSolution355());


                // 如果自己发了推文也要算上
                if (twitter.ContainsKey(userId))
                {
                    maxHeap.Push(twitter[userId]);
                }

                if (followings.ContainsKey(userId) && followings[userId].Count > 0)
                {
                    HashSet<int> followingList = followings[userId];

                    foreach (int followingId in followingList)
                    {
                        
                        if (twitter.ContainsKey(followingId))
                        {
                            Tweet tweet = twitter[followingId];
                            maxHeap.Push(tweet);
                        }
                    }
                }

                List<int> res = new List<int>();
                int count = 0;
                while (!maxHeap.IsEmpty() && count < 10)
                {
                    Tweet head = maxHeap.Pop();
                    res.Add(head.id);

                    // 这里最好的操作应该是 replace，但是 Java 没有提供
                    if (head.next != null)
                    {
                        maxHeap.Push(head.next);
                    }
                    count++;
                }
                return res;

            }
            /** Follower follows a followee. If the operation is invalid, it should be a no-op. */
            public void Follow(int followerId, int followeeId)
            {
                // 被关注人不能是自己
                if (followeeId == followerId)
                {
                    return;
                }

                // 获取我自己的关注列表
                if (!followings.ContainsKey(followerId))
                {
                    HashSet<int> init = new HashSet<int>();
                    init.Add(followeeId);
                    followings[followerId] = init;
                }
                else
                {
                    HashSet<int> followingList = followings[followerId];
                    if (followingList.Contains(followeeId))
                    {
                        return;
                    }
                    followingList.Add(followeeId);
                }
            }

            /** Follower unfollows a followee. If the operation is invalid, it should be a no-op. */
            public void Unfollow(int followerId, int followeeId)
            {
                if (followeeId == followerId)
                {
                    return;
                }

                // 获取我自己的关注列表
                if (!followings.ContainsKey(followerId))
                {
                    return;
                }
                HashSet<int> followingList = followings[followerId];
                // 这里删除之前无需做判断，因为查找是否存在以后，就可以删除，反正删除之前都要查找
                followingList.Remove(followeeId);
            }
        }

        /**
         * Your Twitter object will be instantiated and called as such:
         * Twitter obj = new Twitter();
         * obj.PostTweet(userId,tweetId);
         * IList<int> param_2 = obj.GetNewsFeed(userId);
         * obj.Follow(followerId,followeeId);
         * obj.Unfollow(followerId,followeeId);
         */
        // @lc code=end
        #endregion

    }
}
