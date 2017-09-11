using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Custom_Algorithm
{
    /// <summary>
    /// 二叉树结点类
    /// </summary>
    public class Node
    {
        public Node left;
        public Node right;
        public int data;

        public Node(int value)
        {
            this.data = value;
        }
    }
}
