using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Custom_Algorithm
{
    public static class LinkedListProblem
    {        
        public static void PrintCommonPart(SingleLinkedListNode head1, SingleLinkedListNode head2)
        {
            Console.WriteLine("Common Part: ");
            while (head1 != null && head2 != null)
            {
                if (head1.data < head2.data)
                {
                    head1 = head1.next;
                }
                else if(head1.data > head2.data)
                {
                    head2 = head2.next;
                }
                else
                {
                    Console.WriteLine(head1.data + " ");
                    head1 = head1.next;
                    head2 = head2.next;
                }
            }
            Console.WriteLine();
        }

        /// <summary>
        /// 删除单链表的倒数第K个结点
        /// </summary>
        /// <param name="head"></param>
        /// <param name="lastKth"></param>
        /// <returns>删除操作后的链表头</returns>
        public static SingleLinkedListNode RemoveLastKthNode(SingleLinkedListNode head, int lastKth)
        {
            int count = lastKth;
            if (head == null || lastKth < 1)
            {
                return head;
            }
            SingleLinkedListNode current = head;
            while (current != null)
            {
                lastKth--;
                current = current.next;
            }

            if (count == 0)
            {
                head = head.next;
            }
            else if(count < 0)
            {
                current = head;
                while (count != 0)
                {
                    count--;
                    current = current.next;
                }
                current.next = current.next.next;
            }
            return head;
        }

        public static DoubleLinkedListNode RemoveLastKthNode(DoubleLinkedListNode head, int lastKth)
        {
            int count = lastKth;
            if (head == null || lastKth < 1)
            {
                return head;
            }
            DoubleLinkedListNode current = head;
            while (current != null)
            {
                lastKth--;
                current = current.next;
            }

            if (count == 0)
            {
                head = head.next;
                head.before = null;
            }
            else if (count < 0)
            {
                current = head;
                while (count != 0)
                {
                    count--;
                    current = current.next;
                }
                current.next = current.next.next;
                if (current.next != null)
                {
                    current.next.before = current;
                }
            }
            return head;
        }
    }
}
