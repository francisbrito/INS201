using System;
namespace INS201.Structures
{
    public class BaseQueue<T>
    {
        private int _length;
        private int _head;
        private int _tail;
        private DynamicArray<T> _items;

        protected BaseQueue()
        {
            _length = 0;
            _head = 0;
            _tail = 0;
            _items = new DynamicArray<T>();
        }

        public virtual T Dequeue()
        {
            if (_length == 0)
            {
                throw new InvalidOperationException();
            }

            _length--;

            return _items.At(_head++);
        }

        public virtual void Enqueue(T item)
        {
            // Add item, move tail forward, increase length.
            _items.Add(item);
            _tail++;

            _length++;
        }

        public virtual int Head
        {
            get
            {
                return _head;
            }
        }

        public virtual int Tail
        {
            get
            {
                return _tail;
            }
        }

        public virtual int Length
        {
            get
            {
                return _length;
            }
        }

        public virtual T Peek()
        {
            if (_length == 0)
            {
                throw new InvalidOperationException();
            }

            return _items.At(_head);
        }

    }
}
