using SharedLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace PrajwalLinkedList
{
    /// <summary>
    /// Not nullable Header Linked List.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class HeaderLinkedList<T>
    {
        private Node<T> Head;
        public HeaderLinkedList(T metaData)
        {
            Head = new Node<T>(metaData);
        }
        public void AddNode(T data)
        {
            Node<T> newNode = new Node<T>(data);
            var currentNode = Head;
            while (currentNode.Next != null)
            { 
                currentNode = currentNode.Next;
            }
            currentNode.Next = newNode;
        }
        public void TraverseList()
        {
            var currentNode = Head.Next;
            while (currentNode != null)
            {
                Console.WriteLine(currentNode.Data);
                currentNode = currentNode.Next;
            }
        }
        public void TraverseListRecursive(Node<T>? currentNode)
        { 
            if (currentNode == null)
                return;
            Console.WriteLine(currentNode.Data);
            TraverseListRecursive(currentNode.Next);
        }
    }
}
