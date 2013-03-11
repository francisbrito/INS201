using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using INS201.Structures;

namespace INS201.Structures.Tests
{
    [TestClass]
    public class LinkedListTest
    {
        [TestMethod]
        public void LengthShouldDefaultToZero()
        {
            var l = new LinkedList<int>();

            Assert.AreEqual(0, l.Length);
        }
        [TestMethod]
        public void LengthShouldIncreaseOnAddFirst()
        {
            var l = new LinkedList<int>();

            l.AddFirst(1);

            Assert.AreEqual(1, l.Length);

            l.AddFirst(2);

            Assert.AreEqual(2, l.Length);

            l.AddFirst(3);

            Assert.AreEqual(3, l.Length);
        }

        [TestMethod]
        public void LengthShouldIncreaseOnAddLast()
        {
            var l = new LinkedList<int>();

            l.AddLast(1);

            Assert.AreEqual(1, l.Length);

            l.AddLast(2);

            Assert.AreEqual(2, l.Length);

            l.AddLast(3);

            Assert.AreEqual(3, l.Length);
        }

        [TestMethod]
        public void LengthShouldDecreaseOnRemoveFirst()
        {
            var l = new LinkedList<int>();

            l.AddFirst(1);
            l.AddFirst(2);
            l.AddFirst(3);

            Assert.AreEqual(3, l.Length);

            l.RemoveFirst();

            Assert.AreEqual(2, l.Length);

            l.RemoveFirst();

            Assert.AreEqual(1, l.Length);

            l.RemoveFirst();

            Assert.AreEqual(0, l.Length);
        }

        [TestMethod]
        public void LengthShouldDecreaseOnRemoveLast()
        {
            var l = new LinkedList<int>();

            l.AddLast(1);
            l.AddLast(2);
            l.AddLast(3);

            Assert.AreEqual(3, l.Length);

            l.RemoveLast();

            Assert.AreEqual(2, l.Length);

            l.RemoveLast();

            Assert.AreEqual(1, l.Length);

            l.RemoveLast();

            Assert.AreEqual(0, l.Length);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void RemoveFirstShouldThrowExceptionIfListIsEmpty()
        {
            var l = new LinkedList<int>();

            l.RemoveFirst();
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void RemoveLastShouldThrowExceptionIfListIsEmpty()
        {
            var l = new LinkedList<int>();

            l.RemoveLast();
        }

        [TestMethod]
        public void AddFirstChangesHeadToNewNode()
        {
            var l = new LinkedList<int>();

            Assert.IsNull(l.Head);

            l.AddFirst(1);

            Assert.AreEqual(1, l.Head.Value);

            l.AddFirst(2);

            Assert.AreEqual(2, l.Head.Value);

            l.AddFirst(3);

            Assert.AreEqual(3, l.Head.Value);
        }

        [TestMethod]
        public void AddLastChangesTailToNewNode()
        {
            var l = new LinkedList<int>();

            Assert.IsNull(l.Tail);

            l.AddLast(1);

            Assert.AreEqual(1, l.Tail.Value);

            l.AddLast(2);

            Assert.AreEqual(2, l.Tail.Value);

            l.AddLast(3);

            Assert.AreEqual(3, l.Tail.Value);
        }

        [TestMethod]
        public void RemoveFirstChangesHeadToNextNode()
        {
            var l = new LinkedList<int>();

            l.AddFirst(1);
            l.AddFirst(2);
            l.AddFirst(3);

            Assert.AreEqual(3, l.Head.Value);

            l.RemoveFirst();

            Assert.AreEqual(2, l.Head.Value);
            
            l.RemoveFirst();
            
            Assert.AreEqual(1, l.Head.Value);

            l.RemoveFirst();

            Assert.IsNull(l.Head);
            Assert.IsNull(l.Tail);
        }

        [TestMethod]
        public void RemoveLastShouldChangeTailToPreviousNode()
        {
            var l = new LinkedList<int>();

            l.AddFirst(1);
            l.AddFirst(2);
            l.AddFirst(3);

            Assert.AreEqual(1, l.Tail.Value);

            l.RemoveLast();

            Assert.AreEqual(2, l.Tail.Value);

            l.RemoveLast();
            
            Assert.AreEqual(3, l.Tail.Value);

            l.RemoveLast();

            Assert.IsNull(l.Tail);
            Assert.IsNull(l.Head);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void SwapHeadShouldThrowExceptionIfNodeIsNull()
        {
            var l = new LinkedList<int>();

            l.SwapHead(null);
        }

        [TestMethod]
        public void SwapHeadChangesNodeValues()
        {
            var l = new LinkedList<int>();

            l.AddFirst(3);
            l.AddFirst(2);
            l.AddFirst(1);

            Assert.AreEqual(1, l.Head.Value);
            Assert.AreEqual(3, l.Tail.Value);

            l.SwapHead(l.Tail);

            Assert.AreEqual(3, l.Head.Value);
            Assert.AreEqual(1, l.Tail.Value);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void SwapTailShouldThrowExceptionIfNodeIsNull()
        {
            var l = new LinkedList<int>();

            l.SwapTail(null);
        }

        [TestMethod]
        public void SwapTailChangesNodeValues()
        {
            var l = new LinkedList<int>();

            l.AddLast(3);
            l.AddLast(2);
            l.AddLast(1);

            Assert.AreEqual(3, l.Head.Value);
            Assert.AreEqual(1, l.Tail.Value);

            l.SwapTail(l.Head);

            Assert.AreEqual(1, l.Head.Value);
            Assert.AreEqual(3, l.Tail.Value);
        }
    }
}
