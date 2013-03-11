using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace INS201.Structures
{
    public class Dictonary<TKey, TValue>
    {
        public const int INITIAL_INNER_SIZE = 4;

        private int _length;

        private DynamicArray<LinkedList<TValue>> _items;

        public Dictonary()
        {
            _length = 0;
            InitializeItems();
        }

        private void InitializeItems()
        {
            _items = new DynamicArray<LinkedList<TValue>>();

            for (int i = 0; i < INITIAL_INNER_SIZE; i++)
            {
                _items.Add(new LinkedList<TValue>());
            }
        }

        public int Length
        {
            get
            {
                return _length;
            }
        }

        private int Hash(TKey key)
        {
            // Relaying of .NET's Object#GetHashCode method to resolve hash of ANY type.
            // NOTE: The hash may be negative so, we get its absolute value.
            int preHash = Math.Abs(key.GetHashCode());

            preHash = (preHash * GetSalt()) % _items.Length;

            return preHash;
        }

        private int GetSalt()
        {
            // NOTE: This should return a prime number.
            return 1;
        }

        public void Insert(TKey key, TValue value)
        {
            int hash = Hash(key);

            // If the list hasn't being created.
            if (_items[hash] == null)
            {
                _items[hash] = new LinkedList<TValue>();
            }

            // Hackery~
            // Wraps value into a 'KeyedNode' object, so
            // it possible to determine EXACTLY what key belongs to this value
            // this is useful for finding values.
            var node = new KeyedNode<TKey, TValue>(key, value);

            // Add item to the list.
            _items[hash].AddFirst(node);

            _length++;

            // NOTE:
            // Should check for LOAD FACTOR somewhere around here...
        }

        public void Remove(TKey key)
        {
            // If the dictionary is empty.
            if (_length == 0)
            {
                throw new InvalidOperationException();
            }

            // If the key doesn't exists.
            if (Find(key).Equals(default(TValue)))
            {
                throw new KeyNotFoundException();
            }

            int hash = Hash(key);

            // If the list with such key is empty, as If all elements were deleted.
            if (_items[hash].Length == 0)
            {
                throw new InvalidOperationException("Cannot delete from empty list.");
            }

            // NOTE:
            // DO NOT DELETE THE WHOLE LIST.
            // Walk it and find the item to be deleted.

            // _items[hash] = null;

            var curr = _items[hash].Head as KeyedNode<TKey, TValue>;

            while (curr != null)
            {
                if (curr.Key.Equals(key))
                {
                    curr = null;
                    break;
                }

                curr = curr.Next as KeyedNode<TKey, TValue>;
            }
        }

        public TValue Find(TKey key)
        {
            TValue result = default(TValue);

            // First, find the 'Spot' where this key belongs,
            // then walk along the list doing a 'key to key' comparition
            // if they match, you've got what you wanted, baby!

            int hash = Hash(key);

            var list = _items[hash];

            // If there's a list associated to key, walk it.
            if (list != null)
            {
                var curr = list.Head as KeyedNode<TKey, TValue>;

                while (curr != null)
                {
                    // If an element happens to match given key.
                    if (curr.Key.Equals(key))
                    {
                        result = curr.Value;
                        break;
                    }

                    curr = curr.Next as KeyedNode<TKey, TValue>;    
                }
            }

            return result;
        }
    }
}
