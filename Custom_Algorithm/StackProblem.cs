using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Custom_Algorithm
{
    /// <summary>
    /// 用于逆序栈的类
    /// </summary>
    public static class StackProblem
    {
        /// <summary>
        /// 获得栈底的元素
        /// 基线条件: 栈中只有一个元素时, 直接返回栈顶元素
        /// 递归条件: 栈中不止一个元素, 移除栈顶元素, 获取栈底元素后再使元素进栈
        /// </summary>
        /// <param name="stack"></param>
        /// <returns></returns>
        public static int GetAndRemoveLastElement(Stack<int> stack)
        {
            int value = stack.Pop();
            if (stack.Count == 0)
            {
                return value;
            }
            else
            {
                int minVal = GetAndRemoveLastElement(stack);
                stack.Push(value);
                return minVal;
            }
        }

        /// <summary>
        /// 翻转栈中所有元素
        /// 基线条件: 栈中没有元素, 无需任何操作
        /// 递归条件: 栈中有元素, 移除栈底元素, 翻转剩余元素后把栈底元素push进栈
        /// </summary>
        /// <param name="stack"></param>
        public static void ReverseStack(Stack<int> stack)
        {
            if (stack.Count == 0)
            {
                return;
            }

            int last = GetAndRemoveLastElement(stack);
            ReverseStack(stack);
            stack.Push(last);
        }

        // 3,2,1
        // 1
        // 

        /// <summary>
        /// 使用栈结构对另一个栈结构排序, 栈顶到栈底升序
        /// 算法复杂度为O(n^2)
        /// </summary>
        /// <param name="stack"></param>
        public static void SortStackWithStack(Stack<int> stack)
        {
            Stack<int> stackHelp = new Stack<int>();

            while (stack.Count != 0)
            {
                int peek = stack.Pop();

                while (stackHelp.Count != 0 && peek < stackHelp.Peek())
                {
                    stack.Push(stackHelp.Pop());
                }

                stackHelp.Push(peek);
            }

            while (stackHelp.Count != 0)
            {
                stack.Push(stackHelp.Pop());
            }

        }

        /// <summary>
        /// 获取数组的MaxTree
        /// </summary>
        /// <param name="arr"></param>
        /// <returns></returns>
        public static BinaryTreeNode GetMaxTree(int[] arr)
        {
            BinaryTreeNode root = null;

            BinaryTreeNode[] nodeList = new BinaryTreeNode[arr.Length];
            for (int i = 0; i < nodeList.Length; i++)
            {
                nodeList[i] = new BinaryTreeNode(arr[i]);
            }

            Stack<BinaryTreeNode> nodeStack = new Stack<BinaryTreeNode>();  //Use to find nearest bigger item

            Dictionary<BinaryTreeNode, BinaryTreeNode> leftFirstBigger = new Dictionary<BinaryTreeNode, BinaryTreeNode>();
            Dictionary<BinaryTreeNode, BinaryTreeNode> rightFirstBigger = new Dictionary<BinaryTreeNode, BinaryTreeNode>();

            for (int i = 0; i < nodeList.Length; i++)
            {
                while (nodeStack.Count != 0 && nodeStack.Peek().data < nodeList[i].data)
                {
                    BinaryTreeNode popNode = nodeStack.Pop();
                    BinaryTreeNode leftFirstBiggerNode = nodeStack.Count == 0 ? null : nodeStack.Peek();
                    leftFirstBigger.Add(popNode, leftFirstBiggerNode);
                    rightFirstBigger.Add(popNode, nodeList[i]);
                }

                nodeStack.Push(nodeList[i]);
            }

            while (nodeStack.Count != 0)
            {
                BinaryTreeNode popNode = nodeStack.Pop();
                BinaryTreeNode leftFirstBiggerNode = nodeStack.Count == 0 ? null : nodeStack.Peek();
                leftFirstBigger.Add(popNode, leftFirstBiggerNode);
                rightFirstBigger.Add(popNode, null);
            }

            for (int i = 0; i < nodeList.Length; i++)
            {
                BinaryTreeNode curNode = nodeList[i];
                BinaryTreeNode leftFirstBiggerNode = leftFirstBigger[curNode];
                BinaryTreeNode rightFirstBiggerNode = rightFirstBigger[curNode];

                if (leftFirstBiggerNode == null && rightFirstBiggerNode == null)
                {
                    root = curNode;
                }
                else if(leftFirstBiggerNode == null)
                {
                    if (rightFirstBiggerNode.left == null)
                    {
                        rightFirstBiggerNode.left = curNode;
                    }
                    else
                    {
                        rightFirstBiggerNode.right = curNode;
                    }
                }
                else if(rightFirstBiggerNode == null)
                {
                    if (leftFirstBiggerNode.left == null)
                    {
                        leftFirstBiggerNode.left = curNode;
                    }
                    else
                    {
                        leftFirstBiggerNode.right = curNode;
                    }
                }
                else
                {
                    BinaryTreeNode parent = leftFirstBiggerNode.data > rightFirstBiggerNode.data ? rightFirstBiggerNode : leftFirstBiggerNode;
                    if (parent.left == null)
                    {
                        parent.left = curNode;
                    }
                    else
                    {
                        parent.right = curNode;
                    }
                }


            }

            return root;
        }

        /// <summary>
        /// 获得0/1矩阵中的最大长方形
        /// </summary>
        /// <param name="matrix"></param>
        /// <returns></returns>
        public static int MaxRectSize(int[,] matrix)
        {
            if (matrix == null || matrix.Length == 0 || matrix.GetLength(1) == 0)
            {
                return 0;
            }

            int maxArea = 0;
            int[] height = new int[matrix.GetLength(1)];
            for (int i = 0; i < height.Length; i++)
            {
                height[i] = 0;
            }

            for(int row=0; row<matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    height[col] = matrix[row,col] == 0 ? 0 : height[col] + 1;
                }
                maxArea = Math.Max(MaxRectFromBottom(height), maxArea);
            }
            return maxArea;
        }

        private static int MaxRectFromBottom(int[] height)
        {
            int area = 0;
            Stack<int> stackHeight = new Stack<int>();

            for (int i = 0; i < height.Length; i++)
            {
                while (stackHeight.Count != 0 && height[stackHeight.Peek()] > height[i])
                {
                    int popIndex = stackHeight.Pop();
                    int leftFirstLowerIndex = stackHeight.Count == 0 ? 0 : stackHeight.Peek()+1;
                    int rightFirstLowerIndex = i - 1;
                    area = Math.Max((rightFirstLowerIndex - leftFirstLowerIndex + 1) * height[popIndex], area);
                }
                stackHeight.Push(i);
            }

            while (stackHeight.Count != 0)
            {
                int popIndex = stackHeight.Pop();
                int leftFirstLowerIndex = stackHeight.Count == 0 ? 0 : stackHeight.Peek() + 1;
                int rightFirstLowerIndex = height.Length - 1;
                area = Math.Max((rightFirstLowerIndex - leftFirstLowerIndex + 1) * height[popIndex], area);
            }

            return area;
        }

        /// <summary>
        /// 最大值减去最小值小于或等于num的子数组数量 
        /// </summary>
        /// <param name="arr"></param>
        /// <param name="threshold"></param>
        /// <returns></returns>
        public static int GetSubArrayCountByMaxAndMin(int[] arr, int threshold)
        {
            if (arr == null || arr.Length == 0)
            {
                return 0;
            }

            LinkedList<int> maxWindow = new LinkedList<int>();
            LinkedList<int> minWindow = new LinkedList<int>();

            int start = 0;
            int end = 0;
            int count = 0;

            while (start < arr.Length)
            {
                while (end < arr.Length)
                {
                    while (maxWindow.Count != 0 && arr[maxWindow.Last.Value] <= arr[end])
                    {
                        maxWindow.RemoveLast();
                    }
                    maxWindow.AddLast(end);

                    while (minWindow.Count != 0 && arr[minWindow.Last.Value] >= arr[end])
                    {
                        minWindow.RemoveLast();
                    }
                    minWindow.AddLast(end);

                    if (arr[maxWindow.First.Value] - arr[minWindow.First.Value] > threshold)
                    {
                        break;
                    }
                    end++;
                }

                if (minWindow.First.Value == start)
                {
                    minWindow.RemoveFirst();
                }
                if (maxWindow.First.Value == start)
                {
                    maxWindow.RemoveFirst();
                }
                count += end - start;
                start++;
            }

            return count;
            
        }
    }
}
