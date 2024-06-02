using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryTree
{
    class Node<T> where T : IComparable<T>
    {
        public T Data { get; set; }
        public Node<T>? Left { get; set; }
        public Node<T>? Right { get; set; }
        public int SuccessorCount { get; set; }

        public Node(T data)
        {
            Data = data;
            Left = null;
            Right = null;
            SuccessorCount = 0;
        }
    }
}
