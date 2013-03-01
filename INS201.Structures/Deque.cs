using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace INS201.Structures
{
    //NOTE:
    // A Deque is two STACKS joined from the bottom!
    // You can implement them using a dynamic array!
    public class Deque<T>
    {
        private int _tail;
        private int _head;
        private int _length;
        private DynamicArray<T> _headItems;
        private DynamicArray<T> _tailItems;
        
        public Deque()
        {
            _head = -1;
            _tail = -1;
            _length = 0;
            _headItems = new DynamicArray<T>();
            _tailItems = new DynamicArray<T>();
        }

        public int Length 
        {
            get
            {
                return _length;
            }
        }

        public void AddBack(T item)
        {
            _tailItems.Add(item);

            _length++;
            _tail++;
        }

        public void AddFront(T item)
        {
            _headItems.Add(item);

            _length++;
            _head++;
        }

        public T PopBack()
        {
            if (_length == 0)
            {
                throw new InvalidOperationException();
            }

            if (_tail == 0)
            {
                throw new InvalidOperationException();
            }

            _length--;
            _tail--;
            return _tailItems.Pop();
        }

        public T PopFront()
        {
            if (_length == 0)
            {
                throw new InvalidOperationException();
            }

            if (_head == 0)
            {
                throw new InvalidOperationException();
            }

            _length--;
            _head--;
            return _headItems.Pop();
        }

        public T Back()
        {
            if (_length == 0)
            {
                throw new InvalidOperationException();
            }

            return _tailItems[_tail];
        }

        public T Front()
        {
            if (_length == 0)
            {
                throw new InvalidOperationException();
            }

            return _headItems[_head];
        }

        public T At(int index)
        {
            if (_length == 0)
            {
                throw new InvalidOperationException();
            }

            if (index < 0 || index > _length - 1)
            {
                throw new IndexOutOfRangeException();
            }

            var offset = _length / 2;

            // If it is lower than the middle position,
            // then it belongs to head.
            if (index > offset)
            {
                return _headItems[_head - offset];
            }
            // Otherwise it belongs to tail.
            else
            {
                return _tailItems[offset - _tail + 1];
            }
        }
    }
}
