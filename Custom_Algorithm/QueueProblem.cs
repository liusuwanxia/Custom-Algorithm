using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Custom_Algorithm
{
    public class QueueProblem
    {
        /// <summary>
        /// 在指定数组上获取指定大小窗口的最大值数组
        /// </summary>
        /// <param name="arr"></param>
        /// <param name="windowSize"></param>
        /// <returns></returns>
        public static int[] GetMaxWindow(int[] arr, int windowSize)
        {
            if (arr == null || windowSize<1 || arr.Length < windowSize)
            {
                Console.WriteLine("Wrong Arguement");
                return null;
            }

            int[] maxWindow = new int[arr.Length - windowSize + 1];
            
            LinkedList<int> maxQueue = new LinkedList<int>();

            for (int index = 0; index < arr.Length; index++)
            {
                while (maxQueue.Count != 0 && arr[maxQueue.Last.Value] <= arr[index])
                {
                    maxQueue.RemoveLast();
                }

                maxQueue.AddLast(index);

                if (maxQueue.First.Value <= index-windowSize )
                {
                    maxQueue.RemoveFirst();
                }

                if (index >= windowSize-1)
                {
                    maxWindow[index - windowSize + 1] = arr[maxQueue.First.Value];
                }
            }

            return maxWindow;
        }
    }
}
