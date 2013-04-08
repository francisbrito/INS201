using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace INS201.Structures
{
    public class TreeNode
    {
        private int _key;
        private bool _isComplete;

        public TreeNode(int key, int value)
        {
            _key = key;

            Value = value;
            Left = null;
            Right = null;
        }

        public TreeNode Left { get; set; }
        public TreeNode Right { get; set; }

        public int Key
        {
            get
            {
                return _key;
            }
        }

        public int Value { get; set; }

        public void Insert(int key, int value)
        {
            var newNode = new TreeNode(key, value);
        }

        public void TraverseAndDo(Action<TreeNode> action)
        {
            action(this);
            if (Left == null)
            {
                return;
            }
            else
            {
                Left.TraverseAndDo(action);
            }

            if (Right == null)
            {
                return;
            }
            else
            {
                Right.TraverseAndDo(action);
            }
        }
    }
}
