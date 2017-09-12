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
    public class BinaryTreeNode
    {
        public BinaryTreeNode left;
        public BinaryTreeNode right;
        public int data;

        public BinaryTreeNode(int value)
        {
            this.data = value;
        }
    }
}
