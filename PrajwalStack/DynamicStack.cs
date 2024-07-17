
using SharedLibrary;

namespace PrajwalStack
{
    public class DynamicStack<T>
    {
        private Node<T>? Top;
        internal int _size;
        public DynamicStack()
        {
            Top = null;
        }
        public bool IsEmpty()
        {
            return Top == null;
        }
        public void Push(T value)
        {
            Node<T>? newNode = new Node<T>(value);
            newNode.Next = Top;
            Top = newNode;
            _size++;
        }
        public T? Pop()
        {
            if (Top == null)
            {
                throw new InvalidOperationException("Stack Underflow. No data elements to pop.");
            }
            T? value = Top.Data;
            Top = Top.Next;
            _size--;
            return value;
        }
        public T? GetTopData()
        {
            if (Top != null)
                return Top.Data;
            return default(T);
        }

        public int Size => _size;
    }
}
