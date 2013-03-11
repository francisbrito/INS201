using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INS201.Structures
{
    public class DynamicArray<T>
    {
        public const int GROWTH_CONSTANT = 2;
        public const int SHRINK_CONSTANT = GROWTH_CONSTANT * GROWTH_CONSTANT;

        private int _length;
        private T[] _items;

        public DynamicArray() : this(GROWTH_CONSTANT) 
        {
            //So it grows on-pair with GROWTH_CONSTANT.
        } 

        public DynamicArray(int capacity)
        {
            _items = new T[capacity];
        }

        public void Add(T newItem)
        {
            if (_length == _items.Length)
            {
                Resize(_items.Length * GROWTH_CONSTANT);
            }

            _items[_length] = newItem;
            _length++;
        }

        public int Length
        {
            get
            {
                return _length;
            }
        }

        public T At(int index)
        {
            if (index < 0 || index > _length)
            {
                throw new IndexOutOfRangeException();
            }
            return _items[index];
        }

        public T Pop()
        {
            if (_length == 0)
            {
                throw new InvalidOperationException();
            }

            if (_length == _items.Length / SHRINK_CONSTANT)
            {
                Resize(_items.Length / SHRINK_CONSTANT);
            }

            var ret = _items[_length - 1];

            if (_items[_length - 1] is IDisposable)
            {
                // If item is disposable, call its 'Dispose' method.
                (_items[_length - 1] as IDisposable).Dispose();

                // NOTE:
                // I'm not really sure whether this is adviceable...
                // Imagine disposing a resource you'd like to use in the future.
            }
            else
            {
                // "default-izes" item. 
                // If its a reference type (i.e: object) sets it to null, 
                // if its a value type sets it to its default value.
                _items[_length - 1] = default(T);
            }

            _length--;

            return ret;
        }

        private void Resize(int newLength)
        {
            var temp = new T[newLength];

            for (int i = 0; i < _length; i++)
            {
                temp[i] = _items[i];
            }

            _items = temp;
        }

        public bool Has(T item)
        {
            for (int i = 0; i < _length; i++)
            {
                var it = _items[i];

                if (item.Equals(it)) // '==' operator cannot be used unless implemented.
                {
                    return true;
                }
            }

            return false;
        }

        public void Replace(int index, T newValue)
        {
            if (index < 0 || index > _length)
            {
                throw new InvalidOperationException();
            }

            _items[index] = newValue;
        }

        public T this[int index]
        {
            get
            {
                return At(index);
            }

            set
            {
                Replace(index, value);
            }
        }

        public T[] Items
        {
            get
            {
                return _items;
            }
        }
    }
}
