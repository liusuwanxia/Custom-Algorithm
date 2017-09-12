using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Custom_Algorithm
{
    public class SingleLinkedListNode
    {
        public SingleLinkedListNode next;
        public int data;

        public SingleLinkedListNode(int val)
        {
            this.data = val;
        }
    }

    public class DoubleLinkedListNode
    {
        public DoubleLinkedListNode before;
        public DoubleLinkedListNode next;
        public int data;

        public DoubleLinkedListNode(int val)
        {
            this.data = val;
        }
    }
}
