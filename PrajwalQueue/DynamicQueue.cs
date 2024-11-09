using SharedLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrajwalQueue
{
    public class DynamicQueue<T>
    {
        private Node<T>? Front;
        private Node<T>? Rear;

        public DynamicQueue()
        {
            Front = null;
            Rear = null;
        }
        public bool IsEmpty()
        {
            return Front == null || Rear == null;
        }
        public void Enqueue(T data)
        {
            var newNode = new Node<T>(data);
            if (IsEmpty())
            {
                Front = newNode;
            }
            else if (Rear != null)
            {
                Rear.Next = newNode;
            }
            Rear = newNode;
        }
        public T? Dequeue()
        {
            T? obj = default;
            if (IsEmpty())
            {
                throw new InvalidOperationException("Queue is empty. No element exist to dequeue.");
            }
            else if (Front != null)
            {
                obj = Front.Data;
                Front = Front.Next;
                if (Front == null)
                {
                    Rear = null;
                }
            }
            return obj;
        }
    }
}
