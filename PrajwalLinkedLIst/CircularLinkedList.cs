using SharedLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrajwalLinkedList
{
    public class CircularLinkedList<T>
    {
        public Node<T>? Head { get; set; }
        public CircularLinkedList()
        {
            Head = null;
        }
        public void AddNode(T data)
        {
            Node<T> newNode = new Node<T>(data);
            if (Head == null)
            { 
                Head = newNode;
                Head.Next = Head;
            }
            else
            {
                Node<T>? current = Head;
                while (current.Next != Head)
                {
                    current = current.Next;
                }
                current.Next = newNode;
                newNode.Next = Head;
            }
        }
        public void TraverseList()
        {
            Node<T>? current = Head;
            do
            {
                Console.WriteLine(current.Data);
                current = current.Next;
            } 
            while (current != Head);
        }
    }
}
