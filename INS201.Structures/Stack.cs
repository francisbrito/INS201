using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INS201.Structures
{
    public class Stack<T>
    {
        private int _length;
        private DynamicArray<T> _items;

        public Stack()
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

        public void Push(T item)
        {
            _length++;
            _items.Add(item);
        }

        public T Pop()
        {
            if (_length == 0)
            {
                throw new InvalidOperationException();
            }

            _length--;
            return _items.Pop();
        }

        public T Peek()
        {
            if (_length == 0)
            {
                throw new InvalidOperationException();
            }

            return _items.At(Length - 1);
        }
    }
}
