using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace INS201.Structures
{
    public class CircularQueue<T> : BaseQueue<T>
    {
        private int _head;
        private int _tail;
        private int _length;

        public CircularQueue()
        {
            _head = 0;
            _tail = 0;
            _length = 0;
        }

        public override void Enqueue(T item)
        {
            base.Enqueue(item);
        }

    }
}
