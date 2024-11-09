using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrajwalQueue
{
    public class StaticCircularQueue<T>
    {
        private int Size;
        private T[] Queue;
        private int Front;
        private int Rear;

        public StaticCircularQueue(int size)
        {
            Size = size;
            Queue = new T[size];
            Front = -1;
            Rear = -1;
        }
        public bool IsEmpty()
        {
            return Front == -1 && Rear == -1;
        }
        public bool IsFull()
        {
            return (Front == 0 && Rear == Size - 1) || Front == Rear + 1;
        }
        public void Enqueue(T data)
        {
            if (IsFull())
            {
                throw new InvalidOperationException("Queue is full. Cannot enqueue the element.");
            }
            if (IsEmpty())
            {
                Front = 0;
                Rear = 0;
            }
            else
            {
                Rear = (Rear + 1) % Size;
            }
            Queue[Rear] = data;
        }
        public T Dequeue()
        {
            if (IsEmpty())
            {
                throw new InvalidOperationException("Queue is empty. No element exist to dequeue.");
            }
            var data = Queue[Front];
            if (Front == Rear)
            {
                Front = -1;
                Rear = -1;
            }
            else
            {
                Front = (Front + 1) % Size;
            }
            return data;
        }
    }
}
