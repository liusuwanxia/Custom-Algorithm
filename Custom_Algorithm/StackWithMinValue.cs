using System;
using System.Collections.Generic;

namespace Custom_Algorithm
{
    /// <summary>
    /// 具有GetMin功能的栈
    /// </summary>
    public class StackWithMinValue
    {
        private Stack<int> stackData;
        private Stack<int> stackMin;

        public StackWithMinValue()
        {
            stackData = new Stack<int>();
            stackMin = new Stack<int>();
        }

        public void Push(int newNum)
        {
            if (this.stackMin.Count == 0)
            {
                this.stackMin.Push(newNum);
            }
            else if (newNum <= this.GetMin())
            {
                this.stackMin.Push(newNum);
            }

            this.stackData.Push(newNum);
        }

        public int Pop()
        {
            if (this.stackData.Count == 0)
            {
                Console.WriteLine("The stack is empty, so Pop() fails.");
                return int.MinValue;
            }

            int value = stackData.Pop();
            if (value == this.GetMin())
            {
                stackMin.Pop();
            }
            return value;
        }

        public int GetMin()
        {
            if (this.stackMin.Count == 0)
            {
                Console.WriteLine("The stack is empty, so GetMin() fails.");
                return int.MinValue;
            }
            return stackMin.Peek();
        }
    }
}
