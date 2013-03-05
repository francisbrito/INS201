using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace INS201.Structures
{
    public class LinkedList<T>
    {
        private int _length;

        public LinkedList()
        {
            _length = 0;
        }


        public int Length 
        {
            get
            {
                return _length;
            }
        }

        public void AddFirst(Node<T> node)
        {
            _length++;

        }

        public void AddLast(Node<T> node)
        {
            _length++;
        }

        public void RemoveFirst()
        {
            if (_length == 0)
            {
                throw new InvalidOperationException();
            }
            _length--;
        }

        public void RemoveLast()
        {
            if (_length == 0)
            {
                throw new InvalidOperationException();
            }
            _length--;
        }
    }
}
