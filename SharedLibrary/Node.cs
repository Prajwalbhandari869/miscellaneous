using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedLibrary
{
    public class Node<T>(T data)
    {
        public T? Data { get; set; } = data;
        public Node<T>? Next { get; set; } = null;
        public Node<T>? Prev { get; set; } = null;
    }
    public class TreeNode<T>(T data)
    {
        public TreeNode<T>? Left { get; set; } = null;
        public T Data { get; set; } = data;
        public TreeNode<T>? Right { get; set; } = null;
        public int Height { get; set; } = 1;
    }
}
