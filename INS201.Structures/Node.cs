using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace INS201.Structures
{
    public class Node<T>
    {
        public Node(T value)
        {
            Value = value;
            Next = null;
            Previous = null;
        }

        public T Value { get; set; }
        public Node<T> Next { get; set; }
        public Node<T> Previous { get; set; }
    }
}
