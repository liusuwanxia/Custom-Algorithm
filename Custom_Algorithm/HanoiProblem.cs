using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Custom_Algorithm
{
    public class HanoiProblem
    {
        /// <summary>
        /// num块积木的汉诺塔问题
        /// 算法复杂度为O(2^num)
        /// </summary>
        /// <param name="num"></param>
        public static void Hanoi(int num)
        {
            if (num > 0)
            {
                Hanoi_Recursive(num, "left", "mid", "right");
            }
        }

        private static void Hanoi_Recursive(int num, string source, string transit, string dst)
        {
            if (num == 1)
            {
                Console.WriteLine("Move 1 from " + source + " to " + dst);
            }
            else
            {
                Hanoi_Recursive(num - 1, source, dst, transit);
                //Hanoi_Recursive(1, source, transit, dst);
                Console.WriteLine(string.Format("Move {0} from {1} to {2}", num, source, dst));
                Hanoi_Recursive(num - 1, transit, source, dst);
            }
        }

        /// <summary>
        /// Hanoi_Step的非递归形式
        /// 时间复杂度为O(num), 空间复杂度为O(1)
        /// </summary>
        /// <param name="arr"></param>
        /// <returns></returns>
        public static int Hanoi_Step_Loop(int[] arr)
        {
            if (arr == null || arr.Length == 0)
            {
                return -1;
            }

            int sub_length = arr.Length;
            int step = 0;

            int src = 1;
            int transit = 2;
            int dst = 3;
            int temp = 0;

            while (sub_length >= 1)
            {
                if (arr[sub_length - 1] != src && arr[sub_length-1] != dst)
                {
                    return -1;
                }
                else if (arr[sub_length - 1] == dst)
                {
                    step += 1 << sub_length - 1;
                    temp = src;
                    src = transit;
                }
                else
                {
                    temp = dst;
                    dst = transit;
                }

                transit = temp;
                sub_length--;
            }

            return step;
        }

        /// <summary>
        /// 根据汉诺塔当前状态判断所处最优解的步骤
        /// 时间复杂度为O(num*1), 空间复杂度(栈深度)为O(num)
        /// </summary>
        /// <param name="arr">表示状态的数组, 积木大小沿索引递增, 每个元素的取值仅为1,2,3</param>
        /// <returns>当前所处最优解的位置, 不属于最优解则返回-1</returns>
        public static int Hanoi_Step_Recursive(int[] arr)
        {
            if (arr == null || arr.Length == 0)
            {
                return -1;
            }

            return Hanoi_Step_Recursive_Process(arr, arr.Length, 1, 2, 3);        
        }

        /// <summary>
        /// 根据汉诺塔的最大积木所在位置判断汉诺塔所处的大致方位
        /// 逐渐递归直到汉诺塔积木长度为0(基线条件,返回0, 表示汉诺塔处于初始状态)
        /// </summary>
        /// <param name="arr"></param>
        /// <param name="sub_length"></param>
        /// <param name="src"></param>
        /// <param name="transit"></param>
        /// <param name="dst"></param>
        /// <returns></returns>
        private static int Hanoi_Step_Recursive_Process(int[] arr, int sub_length, int src, int transit, int dst)
        {
            if (sub_length == 0)
            {
                return 0;
            }

            if (arr[sub_length-1] != src && arr[sub_length-1] != dst)
            {
                return -1;
            }
            else if(arr[sub_length-1] == src)
            {
                return Hanoi_Step_Recursive_Process(arr, sub_length - 1, src, dst, transit);
            }
            else
            {
                int step = Hanoi_Step_Recursive_Process(arr, sub_length - 1, transit, src, dst);
                if (step == -1)
                {
                    return -1;
                }
                else
                {
                    return (1 << (sub_length-1)) + step;
                }
            }
        }


        public static void Hanoi_Adjacent_Move_Recursive(int num, string left, string mid, string right, string src, string dst)
        {
            if (num < 1)
            {
                Console.WriteLine("Wrong Hanoi Num： " +  num);
                return;
            }

            if (num == 1)
            {
                if (src==mid || dst==mid)
                {
                    Console.WriteLine(string.Format("Move 1 from {0} to {1}", src, dst));
                }
                else
                {
                    Console.WriteLine(string.Format("Move 1 from {0} to {1}", src, mid));
                    Console.WriteLine(string.Format("Move 1 from {0} to {1}", mid, dst));
                }
            }
            else
            {
                if (src == mid || dst == mid)
                {
                    string transimit = (src == left || dst == left) ? right : left;
                    Hanoi_Adjacent_Move_Recursive(num - 1, left, mid, right, src, transimit);
                    //Hanoi_Adjacent_Move_Recursive(1, left, mid, right, src, dst);
                    Console.WriteLine(string.Format("Move {0} from {1} to {2}", num, src, dst));
                    Hanoi_Adjacent_Move_Recursive(num - 1, left, mid, right, transimit, dst);
                }
                else
                {
                    Hanoi_Adjacent_Move_Recursive(num - 1, left, mid, right, src, dst);
                    //Hanoi_Adjacent_Move_Recursive(1, left, mid, right, src, mid);
                    Console.WriteLine(string.Format("Move {0} from {1} to {2}", num, src, mid));
                    Hanoi_Adjacent_Move_Recursive(num - 1, left, mid, right, dst, src);
                    //Hanoi_Adjacent_Move_Recursive(1, left, mid, right, mid, dst);
                    Console.WriteLine(string.Format("Move {0} from {1} to {2}", num, mid, dst));
                    Hanoi_Adjacent_Move_Recursive(num - 1, left, mid, right, src, dst);
                }
            }
        }

        private enum Action
        {
            No, LToM, MToL, MToR, RToM
        }

        public enum Hanoi_Tower
        {
            Hanoi_Left, Hanoi_Middle, Hanoi_Right
        }

        public static void Hanoi_Adjacent_Move_Loop(int num, Hanoi_Tower src, Hanoi_Tower dst)
        {
            Stack<int> stackLeft = new Stack<int>();
            Stack<int> stackRight = new Stack<int>();
            Stack<int> stackMid = new Stack<int>();

            Stack<int> stackSrc;
            Stack<int> stackDst;

            stackLeft.Push(int.MaxValue);
            stackMid.Push(int.MaxValue);
            stackRight.Push(int.MaxValue);

            //这里使用数组是为了可以更改preAction的值
            Action preAction = Action.No;

            switch (src)
            {
                case Hanoi_Tower.Hanoi_Left:
                    stackSrc = stackLeft;
                    break;
                case Hanoi_Tower.Hanoi_Middle:
                    stackSrc = stackMid;
                    break;
                case Hanoi_Tower.Hanoi_Right:
                    stackSrc = stackRight;
                    break;
                default:
                    Console.WriteLine("Wrong src position");
                    return;
            }

            switch (dst)
            {
                case Hanoi_Tower.Hanoi_Left:
                    stackDst = stackLeft;
                    break;
                case Hanoi_Tower.Hanoi_Middle:
                    stackDst = stackMid;
                    break;
                case Hanoi_Tower.Hanoi_Right:
                    stackDst = stackRight;
                    break;
                default:
                    Console.WriteLine("Wrong dst position");
                    return;
            }

            for (int i = num; i > 0; i--)
            {
                stackSrc.Push(i);
            }

            while (stackDst.Count != num + 1)
            {
                Hanoi_Adjacent_Move_Loop_Process(ref preAction, Action.MToL, Action.LToM, stackLeft, stackMid, "Left", "Mid");
                Hanoi_Adjacent_Move_Loop_Process(ref preAction, Action.LToM, Action.MToL, stackMid, stackLeft, "Mid", "Left");
                Hanoi_Adjacent_Move_Loop_Process(ref preAction, Action.RToM, Action.MToR, stackMid, stackRight, "Mid", "Right");
                Hanoi_Adjacent_Move_Loop_Process(ref preAction, Action.MToR, Action.RToM, stackRight, stackMid, "Right", "Mid");
            }
        }

        private static void Hanoi_Adjacent_Move_Loop_Process(ref Action preAction, Action preNoAction, Action curAction, Stack<int> srcStack, Stack<int> dstStack, string src, string dst)
        {
            if (preAction != preNoAction && srcStack.Peek() < dstStack.Peek())
            {
                dstStack.Push(srcStack.Pop());
                preAction = curAction;
                Console.WriteLine(string.Format("Move {0} from {1} to {2}", dstStack.Peek(), src, dst));
            }
        }

    }
}
