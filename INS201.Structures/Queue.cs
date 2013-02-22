using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INS201.Structures
{
    public class Queue<T>
    {
        private int _length;
        private int _head;
        private int _tail;
        private DynamicArray<T> _items;

        public Queue()
        {
            _items = new DynamicArray<T>();
        }

        public int Length
        {
            get
            {
                return _length;
            }
        }

        public int Head
        {
            get
            {
                return _head;
            }
        }

        public int Tail
        {
            get
            {
                return _tail;
            }
        }

        public void Enqueue(T item)
        {
            // Add item, move tail forward, increase length.
            _items.Add(item);
            _tail++;

            _length++;
        }

        public T Peek()
        {
            if (_length == 0)
            {
                throw new InvalidOperationException();
            }

            return _items.At(_head);
        }

        public T Dequeue()
        {
            if (_length == 0)
            {
                throw new InvalidOperationException();
            }

            _length--;

            return _items.At(_head++);
        }
    }
}
