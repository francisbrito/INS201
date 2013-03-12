using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace INS201.Structures
{
    public class Dictionary<TKey, TValue>
    {
        public const int INITIAL_INNER_SIZE = 2;
        public const float IDEAL_LOAD_FACTOR = 1.0F;
        public const int GROWTH_CONSTANT = 2;

        private int _length;
        private int _collisions;

        private DynamicArray<LinkedList<TValue>> _items;

        public Dictionary()
        {
            _length = 0;
            _collisions = 0;

            InitializeItems();
        }

        private void InitializeItems()
        {
            _items = new DynamicArray<LinkedList<TValue>>(INITIAL_INNER_SIZE);
        }

        public int Length
        {
            get
            {
                return _length;
            }
        }

        private int Hash(TKey key, int size)
        {
            // Relaying of .NET's Object#GetHashCode method to resolve hash of ANY type.
            // NOTE: The hash may be negative so, we get its absolute value.
            int preHash = Math.Abs(key.GetHashCode());

            // Hash function depends in the capacity of the dictionary
            // making it hardly useful outside of its context...
            preHash = (preHash * GetSalt()) % size;

            return preHash;
        }

        private int Hash(TKey key)
        {
            // This work-around 'softens' coupling a little.
            return Hash(key, _items.Capacity);
        }

        private int GetSalt()
        {
            // NOTE: This should return a prime number.
            return 1;
        }

        public void Insert(TKey key, TValue value)
        {
            var currentLoad = GetLoadFactor();

            // If current load is higher than expected load factor.
            if (currentLoad > IDEAL_LOAD_FACTOR)
            {
                RehashItems();
            }

            int hash = Hash(key);

            // If the list hasn't being created.
            if (_items[hash] == null)
            {
                _items[hash] = new LinkedList<TValue>();
            }
            // If the list is created, then this is a collision.
            else
            {
                _collisions++;
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

        private void RehashItems()
        {
            var newCapacity = _items.Capacity * GROWTH_CONSTANT;
            var oldList = _items;
            
            _length = 0; // Reset length.
            _collisions = 0; // Reset collisions.

            _items = new DynamicArray<LinkedList<TValue>>(newCapacity);

            for (int i = 0; i < oldList.Capacity; i++)
            {
                var currList = oldList[i];

                // No need to work on empty lists.
                if (currList == null)
                {
                    continue;
                }

                var curr = currList.Head as KeyedNode<TKey, TValue>;

                while (curr != null)
                {
                    Insert(curr.Key, curr.Value);

                    curr = curr.Next as KeyedNode<TKey, TValue>;
                }
            }
        }

        private float GetLoadFactor()
        {
            return (float) _length / _items.Capacity;
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

            var list = _items[hash];

            var curr = list.Head as KeyedNode<TKey, TValue>;

            while (curr != null)
            {
                if (curr.Key.Equals(key))
                {
                    // NOTE: This DOES NOT remove the element from list.
                    // curr = null;
                    list.RemoveNode(curr);
                    break;
                }

                curr = curr.Next as KeyedNode<TKey, TValue>;
            }

            _length--;
        }

        public TValue Find(TKey key)
        {
            // Theres an Issue with this return value,
            // since any non-null value is actually a good value.
            // Consider throwing an exception instead.
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
                        // TODO: Move element to front.
                        break;
                    }

                    curr = curr.Next as KeyedNode<TKey, TValue>;
                }
            }

            return result;
        }
    }
}
