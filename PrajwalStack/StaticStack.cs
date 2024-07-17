namespace PrajwalStack
{
    public class StaticStack<T>
    {
        private int Top;
        private T[] Stack;
        private int Size;
        /// <summary>
        /// Expects required size of static stack.
        /// </summary>
        /// <param name="size"></param>
        public StaticStack(int size)
        {
            Top = -1;
            Stack = new T[size];
            Size = size;
        }
        /// <summary>
        /// Insert a value at the top of the stack.
        /// </summary>
        /// <param name="value"></param>
        /// <exception cref="InvalidOperationException"></exception>
        public void Push(T value)
        {
            if (this.IsFull())
            {
                throw new InvalidOperationException("Stack Overflow. Cannot insert more data");
            }
            Stack[++Top] = value;
        }
        /// <summary>
        /// Pop and returns the value from the top of the stack.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="InvalidOperationException"></exception>
        public T Pop()
        {
            if (this.IsEmpty())
            {
                throw new InvalidOperationException("Stack Underflow. No data elements to pop.");
            }
            return Stack[Top--];
        }
        /// <summary>
        /// Checks if stack is full or not.
        /// </summary>
        /// <returns></returns>
        public bool IsFull()
        {
            return Top == Size - 1;
        }
        /// <summary>
        /// Checks if stack is empty or not.
        /// </summary>
        /// <returns></returns>
        public bool IsEmpty()
        {
            return Top == -1;
        }
    }
}
