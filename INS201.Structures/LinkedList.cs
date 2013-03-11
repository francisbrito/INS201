using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace INS201.Structures
{
    public class LinkedList<T>
    {
        private int _length;
        private Node<T> _head;
        private Node<T> _tail;

        public LinkedList()
        {
            _length = 0;
            _head = _tail = null;
        }


        public int Length
        {
            get
            {
                return _length;
            }
        }

        public Node<T> Head
        {
            get
            {
                return _head;
            }
        }

        public Node<T> Tail
        {
            get
            {
                return _tail;
            }
        }

        public void AddFirst(T value)
        {
            var node = new Node<T>(value);

            AddFirst(node);
        }

        public void AddFirst(Node<T> node)
        {
            // If list is empty.
            if (_length == 0)
            {
                _head = _tail = node;
            }
            // If there's only one element in the list.
            //else if (_length == 1)
            //{
            //    // NOTE: Check this later.
            //    node.Next = _head; // Could as well point to tail 
            //    _tail.Previous = node;

            //    _head = node;

            //}
            else
            {
                node.Next = _head;
                _head.Previous = node;

                _head = node;
            }

            _length++;
        }

        public void AddLast(T value)
        {
            var node = new Node<T>(value);

            AddLast(node);
        }

        public void AddLast(Node<T> node)
        {
            // If list is empty.
            if (_length == 0)
            {
                _tail = _head = node;
            }
            else
            {
                _tail.Next = node;
                node.Previous = _tail;

                _tail = node;
            }

            _length++;
        }

        public void RemoveFirst()
        {
            if (_length == 0)
            {
                throw new InvalidOperationException();
            }
            // If there's only one element in list.
            else if (_length == 1)
            {
                _head = _tail = null;
            }
            else
            {
                _head.Next.Previous = null;
                _head = _head.Next;
            }

            _length--;
        }

        public void RemoveLast()
        {
            if (_length == 0)
            {
                throw new InvalidOperationException();
            }
            else if (_length == 1)
            {
                _tail = _head = null;
            }
            else
            {
                _tail.Previous.Next = null;
                _tail = _tail.Previous;
            }

            _length--;
        }

        private void Swap(Node<T> firstNode, Node<T> secondNode)
        {
            if (firstNode == null || secondNode == null)
            {
                throw new ArgumentNullException("At least one of your nodes is null.");
            }

            var tempValue = firstNode.Value;

            firstNode.Value = secondNode.Value;
            secondNode.Value = tempValue;
        }

        public void SwapHead(Node<T> node)
        {
            Swap(_head, node);
        }

        public void SwapTail(Node<T> node)
        {
            Swap(_tail, node);
        }
    }
}
