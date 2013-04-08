using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace INS201.Structures
{
    public class BinaryTree
    {
        private int _size;
        private int _depth;
        private TreeNode _root;
        
        private bool _shouldInsertLeft = true;

        public BinaryTree()
        {
            _size = 0;
            _depth = 0;
            _root = null;
        }

        public TreeNode Root
        {
            get
            {
                return _root;
            }
        }

        public void Insert(int key, int value)
        {
            var newNode = new TreeNode(key, value);

            if (_root == null)
            {
                _root = newNode;
            }
            else
            {
                _root.Insert(key, value);
            }
        }
    }
}
