using SharedLibrary;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrajwalLinkedList
{
    public class DoublyLinkedList<T>
    {
        private Node<T>? Head { get; set; }
        private Node<T>? Tail { get; set; }
        public DoublyLinkedList()
        {
            Head = null;
            Tail = null;
        }
        public void AddNode(T data)
        {
            Node<T> newNode = new Node<T>(data);
            if (Head == null)
            {
                Head = newNode;
            }
            else
            {
                Node<T> current = Head;
                while (current.Next != null)
                {
                    current = current.Next;
                }
                current.Next = newNode;
                newNode.Prev = current;
            }
            Tail = newNode;
        }
        public void TraverseList()
        {
            Node<T>? currentNode = Head;
            while (currentNode != null)
            {
                Console.WriteLine(currentNode.Data);
                currentNode = currentNode.Next;
            }
        }
        public void TraverseListReverse()
        {
            Node<T>? currentNode = Tail;
            while (currentNode != null)
            {
                Console.WriteLine(currentNode.Data);
                currentNode = currentNode.Prev;
            }
        }
        public void InsertAtBegining(T data)
        {
            Node<T> newNode = new(data);
            if (Head == null)
            {
                Head = newNode;
                Tail = newNode;
            }
            else
            {
                Node<T> temp = Head;
                newNode.Next = temp;
                temp.Prev = newNode;
                Head = newNode;
            }
        }
        public void InsertAtEnd(T data)
        {
            Node<T> newNode = new Node<T>(data);
            if (Tail == null)
            {
                Head = newNode;
                Tail = newNode;
            }
            else
            {
                Node<T> temp = Tail;
                temp.Next = newNode;
                newNode.Prev = temp;
                Tail = newNode;
            }
        }
        public void DeleteAtBegining()
        {
            Node<T>? currentNode = Head;
            if (currentNode == null)
            {
                throw new InvalidOperationException("Cannot delete empty list.");
            }
            Head = currentNode.Next;
            if (Head != null)
                Head.Prev = null;
        }

        public void DeleteAtEnd()
        {
            Node<T>? currentNode = Tail;
            if (currentNode == null)
            {
                throw new InvalidOperationException();
            }
            Tail = currentNode.Prev;
            if (Tail != null)
                Tail.Next = null;
        }
    }
}
