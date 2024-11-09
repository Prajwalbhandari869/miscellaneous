using SharedLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace PrajwalQueue
{
    public class DynamicCircularQueue<T>
    {
        private Node<T>? Front;
        private Node<T>? Rear;
        public DynamicCircularQueue()
        {
            Front = null;
            Rear = null;
        }
        public bool IsEmpty()
        {
            return Front == null && Rear == null;
        }
        public void Enqueue(T data)
        {
            var newNode = new Node<T>(data);
            if (IsEmpty())
            {
                Front = newNode;
                Rear = newNode;
                newNode.Next = newNode;
            }
            else if (Front != null && Rear != null)
            {
                Rear.Next = newNode;
                Rear = newNode;
                newNode.Next = Front;
            }
        }
        public T? Dequeue()
        {
            T? data = default;
            if (IsEmpty())
            {
                throw new InvalidOperationException("Queue is empty. No element exist to dequeue.");
            }
            else if (Front != null && Rear != null)
            {
                data = Front.Data;
                if (Front == Rear)
                {
                    Front = null;
                    Rear = null;
                }
                else
                {
                    Front = Front.Next;
                    Rear.Next = Front;
                }
            }
            return data;
        }
    }
}
