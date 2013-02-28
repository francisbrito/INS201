using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INS201.Structures
{
    public class Queue<T> : BaseQueue<T>
    {
        private int _length;
        private int _head;
        private int _tail;
        private DynamicArray<T> _items;

        public Queue()
        {
            _items = new DynamicArray<T>();
        }
    }
}
