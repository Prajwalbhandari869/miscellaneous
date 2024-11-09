
namespace PrajwalQueue
{
    public class StaticQueue<T>
    {
        private int Front;
        private int Rear;
        private T[] Queue;
        private int Size;

        /// <summary>
        /// Expectes size of the queue.
        /// </summary>
        /// <param name="size"></param>
        public StaticQueue(int size)
        {
            Front = -1;
            Rear = -1;
            Queue = new T[size];
            Size = size;
        }

        public bool IsFull()
        {
            return Rear == Size - 1;
        }
        public bool IsEmpty()
        { 
            return Front == -1;  
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
                Rear++;
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
            else Front++;
            return data;
        }
    }
}
