using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace INS201.Structures
{
    public class KeyedNode<TKey, TValue> : Node<TValue>
    {
        private TKey _key;

        public KeyedNode(TKey key, TValue value) : base(value)
        {
            _key = key;
        }

        public TKey Key
        {
            get
            {
                return _key;
            }
        }
    }
}
