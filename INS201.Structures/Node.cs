using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace INS201.Structures
{
    public class Node<T>
    {
        private T _value;

        public Node(T value)
        {
            _value = value;
            Next = null;
            Previous = null;
        }

        public T Value
        {
            get
            {
                return _value;
            }
        }

        public Node<T> Next { get; set; }
        public Node<T> Previous { get; set; }
    }
}
