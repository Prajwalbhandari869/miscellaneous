using SharedLibrary;

namespace PrajwalTree
{
    public class AVLTree<T> where T : IComparable<T>
    {
        private TreeNode<T> Root;

        public AVLTree(T data)
        {
            Root = new TreeNode<T>(data);
        }
        public void Delete(T data)
        {
            Root = DeleteNode(Root, data) ?? Root;
        }
        private TreeNode<T>? DeleteNode(TreeNode<T>? currentNode, T data)
        {
            if (currentNode == null)
            {
                return null;
            }
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
                // For no child node or only one child node.
                if (currentNode.Left == null)
                {
                    TreeNode<T>? tempNode = currentNode.Right;
                    currentNode.Right = null;
                    return tempNode;
                }
                else if (currentNode.Right == null)
                {
                    TreeNode<T>? tempNode = currentNode.Left;
                    currentNode.Left = null;
                    return tempNode;
                }
                // For two child node.
                TreeNode<T> leftLargeValueNode = FindMaxValueNode(currentNode.Left);
                currentNode.Data = leftLargeValueNode.Data;
                currentNode.Left = DeleteNode(currentNode.Left, leftLargeValueNode.Data);
            }
            currentNode.Height = 1 + Math.Max(Height(currentNode.Left), Height(currentNode.Right));
            int balanceFactor = BalanceFactor(currentNode);

            if (balanceFactor < -1)
            {
                int balanceFactorRightNode = BalanceFactor(currentNode.Right);
                if (balanceFactorRightNode == 0 || balanceFactorRightNode == -1)
                {
                    currentNode = RotateLeft(currentNode);
                }
                else if(balanceFactorRightNode == 1 && currentNode.Right != null)
                {
                    currentNode.Right = RotateRight(currentNode.Right);
                    currentNode = RotateLeft(currentNode);
                }
            }
            else if (balanceFactor > 1)
            {
                int balanceFactorRightNode = BalanceFactor(currentNode.Left);
                if (balanceFactorRightNode == 0 || balanceFactorRightNode == 1)
                {
                    currentNode = RotateRight(currentNode);
                }
                else if (balanceFactorRightNode == -1 && currentNode.Left != null)
                {
                    currentNode.Left = RotateLeft(currentNode.Left);
                    currentNode = RotateRight(currentNode);
                }
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
        public void Insert(T data)
        {
            var newNode = new TreeNode<T>(data);
            Root = InsertNode(Root, newNode);
        }

        private TreeNode<T> InsertNode(TreeNode<T>? currentNode, TreeNode<T> newNode)
        {
            if (currentNode == null)
            {
                return newNode;
            }
            if (Compare(newNode.Data, currentNode.Data) < 0)
            {
                currentNode.Left = InsertNode(currentNode.Left, newNode);
            }
            else if (Compare(newNode.Data, currentNode.Data) > 0)
            {
                currentNode.Right = InsertNode(currentNode.Right, newNode);
            }
            else
            {
                return currentNode;
            }
            currentNode.Height = 1 + Math.Max(Height(currentNode.Left), Height(currentNode.Right));
            int balanceFactor = BalanceFactor(currentNode);

            if (balanceFactor > 1 && currentNode.Left != null && Compare(newNode.Data, currentNode.Left.Data) < 0)
            {
                currentNode = RotateRight(currentNode);
            }
            else if (balanceFactor < -1 && currentNode.Right != null && Compare(newNode.Data, currentNode.Right.Data) > 0)
            {
                currentNode = RotateLeft(currentNode);
            }
            else if (balanceFactor > 1 && currentNode.Left != null && Compare(newNode.Data, currentNode.Left.Data) > 0)
            {
                currentNode.Left = RotateLeft(currentNode.Left);
                currentNode = RotateRight(currentNode);
            }
            else if (balanceFactor < -1 && currentNode.Right != null && Compare(newNode.Data, currentNode.Right.Data) < 0)
            {
                currentNode.Right = RotateRight(currentNode.Right);
                currentNode = RotateLeft(currentNode);
            }
            return currentNode;
        }
        private TreeNode<T> RotateLeft(TreeNode<T> currentNode)
        {
            var rightNode = currentNode.Right;
            var rightLeft = rightNode.Left;

            rightNode.Left = currentNode;
            currentNode.Right = rightLeft;

            currentNode.Height = 1 + Math.Max(Height(currentNode.Left), Height(currentNode.Right));
            rightNode.Height = 1 + Math.Max(Height(rightNode.Left), Height(rightNode.Right));

            return rightNode;
        }
        private TreeNode<T> RotateRight(TreeNode<T> currentNode)
        {
            var leftNode = currentNode.Left;
            var leftRight = leftNode.Right;

            leftNode.Right = currentNode;
            currentNode.Left = leftRight;

            currentNode.Height = 1 + Math.Max(Height(currentNode.Left), Height(currentNode.Right));
            leftNode.Height = 1 + Math.Max(Height(leftNode.Left), Height(leftNode.Right));

            return leftNode;
        }
        private int BalanceFactor(TreeNode<T>? currentNode)
        {
            return currentNode != null ? Height(currentNode.Left) - Height(currentNode.Right) : 0;
        }

        private int Height(TreeNode<T>? node)
        {
            return node == null ? 0 : node.Height;
        }

        private int Compare(T data1, T data2)
        {
            return data1.CompareTo(data2);
        }
        public void PostOrderTraverse()
        {
            PostOrderTraverse(Root);
        }
        public void PostOrderTraverse(TreeNode<T>? currentNode)
        {
            if (currentNode == null)
            {
                return;
            }
            PostOrderTraverse(currentNode.Left);
            PostOrderTraverse(currentNode.Right);
            Console.WriteLine(currentNode.Data);
        }
        public void PreOrderTraverse()
        {
            PreOrderTraverse(Root);
        }
        public void PreOrderTraverse(TreeNode<T>? currentNode)
        {
            if (currentNode == null)
            {
                return;
            }
            Console.WriteLine(currentNode.Data);
            PreOrderTraverse(currentNode.Left);
            PreOrderTraverse(currentNode.Right);
        }
        public void InOrderTraverse()
        {
            InOrderTraverse(Root);
        }
        private void InOrderTraverse(TreeNode<T>? currentNode)
        {
            if (currentNode == null)
            {
                return;
            }
            InOrderTraverse(currentNode.Left);
            Console.WriteLine(currentNode.Data);
            InOrderTraverse(currentNode.Right);
        }
    }
}
