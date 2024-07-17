using SharedLibrary;

namespace PrajwalLinkedList
{
    public class LinkedList<T>
    {
        private Node<T>? head;
        public LinkedList()
        {
            head = null;
        }
        public Node<T>? GetHead()
        {
            return head;
        }
        public void AddNode(T data)
        {
            Node<T> newNode = new Node<T>(data);
            if (head == null)
            {
                head = newNode;
            }
            else
            {
                Node<T> currentNode = head;
                while (currentNode.Next != null)
                {
                    currentNode = currentNode.Next;
                }
                currentNode.Next = newNode;
            }
        }        
        public void TraverseList()
        {
            Node<T>? current = head;
            while (current != null)
            {
                Console.WriteLine(current.Data);
                current = current.Next;
            }
        }
        public void TraverseListRecursive(Node<T>? current)
        {
            if (current != null)
            {
                Console.WriteLine(current.Data);
                TraverseListRecursive(current.Next);
            }
        }
        public Node<T>? SearchNode(T key)
        {
            Node<T>? currentNode = head;
            while (currentNode != null)
            {
                if (currentNode.Data != null && currentNode.Data.Equals(key))
                {
                    return currentNode;
                }
                currentNode = currentNode.Next;
            }
            return null;
        }
        public Node<T>? SearchNodeRecursive(Node<T>? current, T key)
        {
            if (current != null)
            {
                if (current.Data != null && current.Data.Equals(key))
                    return current;
                else
                    return SearchNodeRecursive(current.Next, key);
            }
            return null;
        }
        public void InsertAtBegining(T data)
        {
            Node<T> newNede = new Node<T>(data);
            if (head == null)
            {
                head = newNede;
            }
            else
            {
                newNede.Next = head;
                head = newNede;
            }
        }
        public void InsertAfter(Node<T> prevNode, T data)
        {
            if (prevNode == null)
            {
                throw new NullReferenceException("Cannot insert to null Node");
            }
            Node<T> newNode = new Node<T>(data);
            newNode.Next = prevNode.Next;
            prevNode.Next = newNode;
        }
        public void DeleteAtBegining()
        {
            Node<T> ? currentNode = head;
            if (currentNode == null)
            {
                throw new InvalidOperationException("Cannot Delete Begining of Empty List");
            }
            head = currentNode.Next;
        }
        public void DeleteAfter(Node<T> prevNode)
        {
            if (prevNode == null || prevNode.Next == null)
            {
                throw new InvalidOperationException("Cannot Delete Null Node");
            }
            Node<T>? nodeToDelete = prevNode.Next;
            prevNode.Next = nodeToDelete.Next;
        }
        public void ReverseList()
        {
            Node<T>? prevNode = null;
            Node<T>? currentNode = head;
            Node<T>? nextNode;
            while (currentNode != null)
            {
                nextNode = currentNode.Next;
                currentNode.Next = prevNode;
                prevNode = currentNode;
                currentNode = nextNode;
            }
            head = prevNode;
        }
    }
}
