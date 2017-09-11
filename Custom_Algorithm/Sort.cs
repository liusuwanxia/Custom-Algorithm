using System.Collections.Generic;

namespace Custom_Algorithm
{
    public class Sort
    {
        /// <summary>
        /// 查找指定int列表中的最小值, 算法运行时间为 O(n)
        /// </summary>
        /// <param name="list">待查找的列表</param>
        /// <returns>列表中最小的整数</returns>
        public static int FindSmallest(List<int> list)
        {
            int smallest = list[0];
            int smallest_index = 0;

            for (int i = 0; i < list.Count; i++)
            {
                if (smallest > list[i])
                {
                    smallest = list[i];
                    smallest_index = i;
                }
            }
            
            return smallest_index;
        }

        /// <summary>
        /// 选择排序, 按照升序排列指定的列表, 并返回一个排序后的新列表, 算法运行时间为 O(n^2)
        /// </summary>
        /// <param name="list">待排序的列表</param>
        /// <returns>排序后产生的新列表</returns>
        public static List<int> SelectionSort(List<int> list)
        {
            List<int> newArr = new List<int>();
            int count = list.Count;

            for (int i = 0; i < count; i++)
            {
                int smallest_index = FindSmallest(list);
                newArr.Add(list[smallest_index]);
                list.RemoveAt(smallest_index);
            }

            return newArr;
        }

        /// <summary>
        /// 快速排序, 按照升序排列指定的列表, 并返回一个排序后的新列表, 算法运行时间为 O(n log n)
        /// 该实现方法的缺点——每次递归需要创建两个新列表, 比较浪费内存
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        public static List<int> QuickSort(List<int> list)
        {
            if(list.Count <= 1)
            {
                return list;
            }
            else
            {
                int pivot = list[0];
                List<int> less = new List<int>();
                List<int> greater = new List<int>();

                foreach (var item in list.GetRange(1, list.Count-1))
                {
                    if (item <= pivot)
                    {
                        less.Add(item);
                    }
                    else
                    {
                        greater.Add(item);
                    }
                }

                List<int> sortedList = QuickSort(less);

                sortedList.Add(pivot);
                sortedList.AddRange(QuickSort(greater));

                return sortedList;
            }
        }
    }
}
