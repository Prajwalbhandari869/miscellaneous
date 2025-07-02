using SharedLibrary;
using System.Net.NetworkInformation;
using System.Reflection.Metadata.Ecma335;

namespace PrajwalTree
{
    public class BinarySearchTree<T> where T : IComparable<T>
    {
        private TreeNode<T> Root;
        public BinarySearchTree(T rootData)
        {
            Root = new TreeNode<T>(rootData);
        }

        public TreeNode<T>? SearchNode(T data)
        {
            return SearchNode(Root, data);
        }
        private int Compare(T data1, T data2)
        {
            return data1.CompareTo(data2);
        }
        private TreeNode<T>? SearchNode(TreeNode<T>? currentNode, T data)
        {
            if (currentNode == null || currentNode.Data != null && currentNode.Data.Equals(data))
                return currentNode;
            if (currentNode.Data != null && Compare(data, currentNode.Data) < 0)
            {
                return SearchNode(currentNode.Left, data);
            }
            return SearchNode(currentNode.Right, data); //If wraped in bracket, all code path wont return value error will occur.
        }

        public void Insert(T data)
        {
            var newNode = new TreeNode<T>(data);
            InsertRecursively(Root, ref newNode);
        }

        private void InsertRecursively(TreeNode<T> currentNode, ref TreeNode<T> newNode)
        {
            if (Compare(newNode.Data, currentNode.Data) < 0)
            {
                if (currentNode.Left == null)
                {
                    currentNode.Left = newNode;
                }
                else
                {
                    InsertRecursively(currentNode.Left, ref newNode);
                }
            }
            else if (Compare(newNode.Data, currentNode.Data) > 0)
            {
                if (currentNode.Right == null)
                {
                    currentNode.Right = newNode;
                }
                else
                {
                    InsertRecursively(currentNode.Right, ref newNode);
                }
            }

        }
        public void TraverseInOrder()
        {
            TraverseInOrder(Root);
        }

        private void TraverseInOrder(TreeNode<T>? currentNode)
        {
            if (currentNode == null)
                return;
            else
            {
                TraverseInOrder(currentNode.Left);
                Console.WriteLine(currentNode.Data);
                TraverseInOrder(currentNode.Right);
            }
        }
        public void TraversePreOrder()
        {
            TraversePreOrder(Root);
        }

        private void TraversePreOrder(TreeNode<T>? currentNode)
        {
            if (currentNode == null)
                return;
            Console.WriteLine(currentNode.Data);
            TraversePreOrder(currentNode.Left);
            TraversePreOrder(currentNode.Right);
        }
        public void TraversePostOrder()
        {
            TraversePostOrder(Root);
        }

        private void TraversePostOrder(TreeNode<T>? currentNode)
        {
            if (currentNode == null)
                return;
            TraversePostOrder(currentNode.Left);
            TraversePostOrder(currentNode.Right);
            Console.WriteLine(currentNode.Data);
        }
        public void Delete(T data)
        {
            DeleteNode(Root, data);
        }
        //Very Complicated. Revise often.
        private TreeNode<T>? DeleteNode(TreeNode<T>? currentNode, T data)
        {
            if (currentNode == null)
                return null;
            if (Compare(data, currentNode.Data) < 0)
            {
                currentNode.Left = DeleteNode(currentNode.Left, data);
            }
            else if (Compare(data, currentNode.Data) > 0)
            {
                currentNode.Right = DeleteNode(currentNode.Right, data);
            }
            else
            {
                //For no child node or only one child node.
                if (currentNode.Right == null)
                {
                    TreeNode<T>? tempNode = currentNode.Left;
                    currentNode.Left = null;
                    return tempNode;
                }
                else if (currentNode.Left == null)
                {
                    TreeNode<T> tempNode = currentNode.Right;
                    currentNode.Right = null;
                    return tempNode;
                }
                //For two child node
                TreeNode<T>? largeValueNode = FindMaxValueNode(currentNode.Left);//Finding maximum predecessor.
                currentNode.Data = largeValueNode.Data;
                currentNode.Left = DeleteNode(currentNode.Left, largeValueNode.Data);
            }
            return currentNode;
        }

        private TreeNode<T> FindMaxValueNode(TreeNode<T> currentNode)
        {
            while (currentNode.Right != null)
            {
                currentNode = currentNode.Right;
            }
            return currentNode;
        }
    }
}
