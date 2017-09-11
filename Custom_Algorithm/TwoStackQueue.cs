using System;
using System.Collections.Generic;

namespace Custom_Algorithm
{
    /// <summary>
    /// 使用两个栈模拟一个队列
    /// </summary>
    public class TwoStackQueue
    {
        public Stack<int> stackPush;
        public Stack<int> stackPop;

        public TwoStackQueue()
        {
            stackPush = new Stack<int>();
            stackPop = new Stack<int>();
        }

        public void Enqueue(int newData)
        {
            stackPush.Push(newData);
        }

        public int Dequeue()
        {
            if (stackPush.Count == 0 && stackPop.Count == 0)
            {
                Console.WriteLine("The queue is empty, so Dequeue() fails.");
                return int.MinValue;
            }
            else if (stackPop.Count == 0)
            {
                while (stackPush.Count!=0)
                {
                    int value = stackPush.Pop();
                    stackPop.Push(value);
                }
            }

            return stackPop.Pop();
        }

        public int Peek()
        {
            if (stackPush.Count == 0 && stackPop.Count == 0)
            {
                Console.WriteLine("The queue is empty, so Dequeue() fails.");
                return int.MinValue;
            }
            else if (stackPop.Count == 0)
            {
                while (stackPush.Count != 0)
                {
                    int value = stackPush.Pop();
                    stackPop.Push(value);
                }
            }

            return stackPop.Peek();
        }
    }
}
