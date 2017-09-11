namespace Custom_Algorithm
{
    public class Search
    {
        /// <summary>
        /// 二分查找法, 快速从指定数组中查找元素(int数组), 算法运行时间为 O(log n)
        /// </summary>
        /// <param name="list">待查找的列表</param>
        /// <param name="item">查找的指定元素</param>
        /// <returns>如果存在指定元素, 返回它所在的索引; 否则, 返回-1</returns>
        public static int Binary_search(int[] list, int item)
        {
            int low = 0;
            int high = list.Length - 1;

            do
            {
                int mid = (low + high) / 2;
                int guess = list[mid];

                if (item == guess)
                    return mid;

                if (item > guess)
                {
                    low = mid + 1;
                }
                else
                {
                    high = mid - 1;
                }
            } while (low <= high);

            return -1;
        }
    }
}
