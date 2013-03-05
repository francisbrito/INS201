using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace INS201.Structures
{
    public class Node<T>
    {
        private T _value;
        private Node<T> _next;
        private Node<T> _previous;

        public Node(T value)
        {
            _value = value;
            _next = null;
            _previous = null;
        }

        public T Value
        {
            get
            {
                return _value;
            }
        }

        public Node<T> Next
        {
            get
            {
                return _next;
            }
        }

        public Node<T> Previous
        {
            get
            {
                return _previous;
            }
        }
    }
}
