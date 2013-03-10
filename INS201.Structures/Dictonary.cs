using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace INS201.Structures
{
    public class Dictonary<TKey, TValue>
    {

        #region Prime Numbers
        public static int[] PRIME_SET = new int[] {
            31, 37, 41, 43, 47, 53, 59, 
            61, 67, 71, 73, 79, 83, 89, 97, 101, 103, 107, 109, 113, 127, 131, 
            137, 139, 149, 151, 157, 163, 167, 173, 179, 181, 191, 193, 197, 199, 
            211, 223, 227, 229, 233, 239, 241, 251, 257, 263, 269, 271, 277, 281, 
            283, 293, 307, 311, 313, 317, 331, 337, 347, 349, 353, 359, 367, 373, 
            379, 383, 389, 397, 401, 409, 419, 421, 431, 433, 439, 443, 449, 457, 
            461, 463, 467, 479, 487, 491, 499, 503, 509, 521, 523, 541, 547, 557, 
            563, 569, 571, 577, 587, 593, 599, 601, 607, 613, 617, 619, 631, 641, 
            643, 647, 653, 659, 661, 673, 677, 683, 691, 701, 709, 719, 727, 733, 
            739, 743, 751, 757, 761, 769, 773, 787, 797, 809, 811, 821, 823, 827, 
            829, 839, 853, 857, 859, 863, 877, 881, 883, 887, 907, 911, 919, 929, 
            937, 941, 947, 953, 967, 971, 977, 983, 991, 997
        };
        #endregion

        private int _currentPrimePivot = 0;

        private int _length;

        private DynamicArray<LinkedList<TValue>> _items;

        public Dictonary()
        {
            _length = 0;
            _items = new DynamicArray<LinkedList<TValue>>();
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
            int preHash = key.GetHashCode(); // Relaying of .NET's Object#GetHashCode method to resolve hash of ANY type.

            preHash = (preHash * PRIME_SET[_currentPrimePivot]) % _length;

            return preHash;
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
                var curr = list.Head;

                while (curr != null)
                {
                    curr = curr.Next;    
                }
            }

            return result;
        }
    }
}
