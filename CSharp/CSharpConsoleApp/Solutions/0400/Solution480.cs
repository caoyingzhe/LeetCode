using System;
using System.Collections.Generic;
namespace CSharpConsoleApp.Solutions
{
    /*
     * @lc app=leetcode.cn id=480 lang=csharp
     *
     * [480] 滑动窗口中位数
     *
     * https://leetcode-cn.com/problems/sliding-window-median/description/
     *
     * Category	Difficulty	Likes	Dislikes
     * algorithms	Hard (44.86%)	293	-
     * Tags
     * sliding-window
     * 
     * Companies
     * google
     * 
     * Total Accepted:    27.2K
     * Total Submissions: 60.7K
     * Testcase Example:  '[1,3,-1,-3,5,3,6,7]\n3'
     *
     * 中位数是有序序列最中间的那个数。如果序列的长度是偶数，则没有最中间的数；此时中位数是最中间的两个数的平均数。
     * 
     * 例如：
     * [2,3,4]，中位数是 3
     * [2,3]，中位数是 (2 + 3) / 2 = 2.5
     * 
     * 给你一个数组 nums，有一个长度为 k 的窗口从最左端滑动到最右端。窗口中有 k 个数，每次窗口向右移动 1
     * 位。你的任务是找出每次窗口移动后得到的新窗口中元素的中位数，并输出由它们组成的数组。
     * 
     * 示例：
     * 给出 nums = [1,3,-1,-3,5,3,6,7]，以及 k = 3。
     * 窗口位置                      中位数
     * ---------------              -----
     * [1  3  -1] -3  5  3  6  7      1
     * ⁠1 [3  -1  -3] 5  3  6  7      -1
     * ⁠1  3 [-1  -3  5] 3  6  7      -1
     * ⁠1  3  -1 [-3  5  3] 6  7       3
     * ⁠1  3  -1  -3 [5  3  6] 7       5
     * ⁠1  3  -1  -3  5 [3  6  7]      6
     * 
     * 
     * 因此，返回该滑动窗口的中位数数组 [1,-1,-1,3,5,6]。
     * 
     * 
     * 提示：
     * 你可以假设 k 始终有效，即：k 始终小于等于输入的非空数组的元素个数。
     * 与真实值误差在 10 ^ -5 以内的答案将被视作正确答案。
     */

    public class Solution480 : SolutionBase
    {
        /// <summary>
        /// 难度
        /// </summary>
        public override Difficulity GetDifficulity() { return Difficulity.Hard; }
        /// <summary>
        /// 关键字:
        /// </summary>
        public override string[] GetKeyWords() { return new string[] { "平衡树", "双堆", "滑动窗口" }; }
        /// <summary>
        /// 标签：
        /// </summary>
        public override Tag[] GetTags() { return new Tag[] { Tag.SlidingWindow, }; }

        public override bool Test(System.Diagnostics.Stopwatch sw)
        {
            bool isSuccess = true;
            int[] houses; int k;
            double[] result, checkResult;

            //houses = new int[] { 1, 3, -1, -3, 5, 3, 6, 7 }; k = 3;
            //checkResult = new double[] { 1, -1, -1, 3, 5, 6 };
            //result = MedianSlidingWindow(houses, k);

            //isSuccess &= IsArraySame(result, checkResult);
            //Print("isSuccess = {0} | result = {1} | anticipated = {2}", isSuccess, GetArrayStr(result), GetArrayStr(checkResult));

            houses = new int[] { 1, 3, -1, -3, 5, 3, 6, 7 }; k = 6;
            checkResult = new double[] { 2, 3, 4 };
            result = MedianSlidingWindow(houses, k);

            isSuccess &= IsArraySame(result, checkResult);
            Print("isSuccess = {0} | result = {1} | anticipated = {2}", isSuccess, GetArrayStr(result), GetArrayStr(checkResult));

            return isSuccess;
        }
        ///科普一下本题常见解法的时间复杂度
        ///最佳解为平衡树，但由于并不是所有语言都包含平衡树的标准库，
        ///且平衡树的手动实现过于复杂，不在绝大多数面试考察范围内
        ///
        ///对数时间删除指定元素的二叉堆是可以做到的，
        ///仅需要手动建立并维护元素和堆中索引的双向映射，
        ///便可以使单次「找到指定元素」的复杂度降低至 O(1),
        ///进而使得「删除指定元素」操作的时间复杂度为 O(k),与平衡树一致。
        ///但是一般编程语言中的优先队列/二叉堆均不支持此操作，
        ///因此需要手动实现二叉堆
        ///
        /// 42/42 cases passed (356 ms)
        /// Your runtime beats 100 % of csharp submissions
        /// Your memory usage beats 100 % of csharp submissions(35.8 MB)
        ///作者：ace7j
        ///https://leetcode-cn.com/problems/sliding-window-median/solution/ke-pu-yi-xia-chang-jian-jie-fa-de-shi-ji-kvt3/
        public double[] MedianSlidingWindow(int[] nums, int k)
        {
            double[] res = new double[nums.Length - k + 1];
            MedianFinder window = new MedianFinder();
            //添加初始值
            for (int i = 0; i < k; i++)
            {
                window.AddNum(nums[i]);
            }
            res[0] = window.FindMedian();
            //窗口滑动
            for (int i = 0; i < nums.Length - k; i++)
            {
                window.DelNum(nums[i]);
                window.AddNum(nums[i + k]);
                res[i + 1] = window.FindMedian();
            }
            return res;
        }
    }

    //295号题拷贝过来的
    class MedianFinder
    {
        public class TreeNode
        {
            public int val;
            //拓展的数量字段，保存当前节点及其子节点的个数，用于logn复杂度求解中位数
            public int size;
            public TreeNode left;
            public TreeNode right;

            public TreeNode(int val)
            {
                this.val = val;
                this.size = 1;
            }
        }

        private TreeNode root;

        //对外的添加元素方法
        public void AddNum(int num)
        {
            if (this.root == null)
            {
                root = new TreeNode(num);
            }
            else
            {
                this.addNum(num, this.root);
            }
        }

        //对外的删除元素方法
        public void DelNum(int num)
        {
            this.root = delNum(num, this.root);
        }

        //求解中位数，依托于search方法
        public double FindMedian()
        {
            //根据数量字段求解中位数
            if (this.root.size % 2 == 1)
            {
                return search(this.root.size / 2 + 1, this.root);
            }
            else
            {
                int left = search(this.root.size / 2, this.root);
                int right = search(this.root.size / 2 + 1, this.root);
                return left / 2.0 + right / 2.0;
            }
        }


        //内部的添加元素方法
        private void addNum(int num, TreeNode node)
        {
            if (node.val >= num)
            {
                if (node.left == null)
                {
                    node.left = new TreeNode(num);
                }
                else
                {
                    addNum(num, node.left);
                }
            }
            else
            {
                if (node.right == null)
                {
                    node.right = new TreeNode(num);
                }
                else
                {
                    addNum(num, node.right);
                }
            }
            //维护数量字段
            node.size++;
        }

        //内部的删除元素方法
        private TreeNode delNum(int num, TreeNode node)
        {
            if (node.val > num)
            {
                node.left = delNum(num, node.left);
                //维护数量字段
                node.size--;
            }
            else if (node.val < num)
            {
                node.right = delNum(num, node.right);
                //维护数量字段
                node.size--;
            }
            else
            {
                if (node.left == null && node.right == null)
                {
                    return null;
                }
                else if (node.left == null)
                {
                    //无需维护数量字段
                    node = node.right;
                }
                else if (node.right == null)
                {
                    //无需维护数量字段
                    node = node.left;
                }
                else
                {
                    //找到右子树的最小节点，也就是右子树下标为1的节点
                    int min = search(1, node.right);
                    //替换为当前节点的值
                    node.val = min;
                    //删除右子树下的最小节点
                    node.right = delNum(min, node.right);
                    //维护数量字段
                    node.size--;
                }
            }
            return node;
        }

        //核心方法，搜索目标node中下标为index的值，从1开始
        private int search(int index, TreeNode node)
        {
            //数量为1，返回当前
            if (node.size == 1)
            {
                return node.val;
            }
            //判断是否有左子节点
            int leftSize = node.left != null ? node.left.size : 0;
            //用左子节点的数量和index比较
            if (leftSize >= index)
            {
                //index在左子节点下
                return search(index, node.left);
            }
            else if (leftSize + 1 == index)
            {
                //index为当前节点
                return node.val;
            }
            else
            {
                //index在右子节点下
                return search(index - leftSize - 1, node.right);
            }
        }
    }
}
